using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace checkerboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void buttonFFmpegSearch_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "exe files (*.exe)|*.exe";
            openFileDialog.Title = "FFmpeg executable";
            openFileDialog.FileName = String.Empty;

            openFileDialog.ShowDialog();

            textBoxFFmegPath.Text = openFileDialog.FileName;
        }

        private void buttonInputFileSearch_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "mp4 files (*.mp4)|*.mp4|webm files (*.webm)|*.webm";
            openFileDialog.Title = "Video file";
            openFileDialog.FileName = String.Empty;
            
            openFileDialog.ShowDialog();

            textBoxInputFile.Text = openFileDialog.FileName;
        }

        private void buttonOutputFileSearch_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Output file";
            saveFileDialog.FileName = "output";
            saveFileDialog.DefaultExt = ".webm";

            saveFileDialog.ShowDialog();

            textBoxOutputFile.Text = saveFileDialog.FileName;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //walidacja
            if(!File.Exists(textBoxFFmegPath.Text))
            {
                //jak pliku z ffmpegiem ni ma
                statusLabel.Text = "Path to ffmpeg.exe is not valid"; //dodać jakieś wygaszanie tego napisu czy coś
                resetTimer();
                return;
            }

            if(!File.Exists(textBoxInputFile.Text))
            {
                statusLabel.Text = "Path to input file is not valid";
                resetTimer();
                return;
            }

            if(!Directory.Exists(Path.GetDirectoryName(textBoxOutputFile.Text)))
            {
                statusLabel.Text = "Output directory does not exist";
                resetTimer();
                return;
            }

            int videoWidth;
            int videoHeight;

            try
            {
                videoWidth = int.Parse(maskedTextBoxWidth.Text);
                if(videoWidth <= 0)
                {
                    statusLabel.Text = "Input video width set incorrectly";
                    resetTimer();
                    return;
                }

                videoHeight = int.Parse(maskedTextBoxHeight.Text);
                if(videoHeight <= 0)
                {
                    statusLabel.Text = "Input video height set incorrectly";
                    resetTimer();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Incorrect video dimensions\n" + ex.Message, "Error", MessageBoxButtons.OK);
                return;
            }

            if(File.Exists(textBoxOutputFile.Text)) 
            {
                var result = MessageBox.Show(String.Format("File {0} already exist in output directory. Override it?", Path.GetFileName(textBoxOutputFile.Text)),
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.No)
                    return;
            }

            String tempFilePath = Path.GetDirectoryName(textBoxOutputFile.Text) + "\\temp.yuv";

            //argumenty do ffmpega
            String args = String.Format("-i {0} -c:v rawvideo -pix_fmt yuv420p {1}",
                textBoxInputFile.Text, tempFilePath);

            //odpalenie ffmpega żeby wypluł plik yuv do obróbki
            Process ffmpeg = new Process();

            ffmpeg.StartInfo.FileName = textBoxFFmegPath.Text;
            ffmpeg.StartInfo.Arguments = args;

            statusLabel.Text = "Calling FFmpeg...";
            resetTimer();

            ffmpeg.Start();

            ffmpeg.WaitForExit();
            statusLabel.Text = String.Empty;

            var workerArgs = new BackgroundWorkerArguments(tempFilePath, videoWidth, videoHeight);
            backgroundWorker.RunWorkerAsync(workerArgs);

            statusLabel.Text = "Processing...";

            buttonStart.Enabled = false;
            buttonFFmpegSearch.Enabled = false;
            buttonInputFileSearch.Enabled = false;
            buttonOutputFileSearch.Enabled = false;
            maskedTextBoxWidth.Enabled = false;
            maskedTextBoxHeight.Enabled = false;
            textBoxFFmegPath.Enabled = false;
            textBoxInputFile.Enabled = false;
            textBoxOutputFile.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = String.Empty;
            timer.Stop();
        }

        private void resetTimer()
        {
            if(timer.Enabled)
            {
                timer.Interval = 5000;
            }
            else
            {
                timer.Start();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            BackgroundWorkerArguments workerArguments = (BackgroundWorkerArguments)e.Argument;

            String workingDir = Path.GetDirectoryName(workerArguments.InputFilePath);
            int videoWidth = workerArguments.VideoWidth;
            int videoHeight = workerArguments.VideoHeight;

            FrameReader frameReader = new FrameReader(workerArguments.InputFilePath, videoWidth, videoHeight);

            //rozmiary w bajtach
            long inputFileSize = (new FileInfo(workerArguments.InputFilePath)).Length;
            long singleInputFrameSize = videoWidth * videoHeight + videoWidth * videoHeight / 2;
            long inputFrameCount = inputFileSize / singleInputFrameSize;

            //tutaj cała pracka powinna iść
            byte[] combinedYFrame = new byte[videoWidth * videoHeight * 4];
            byte[] combinedUFrame = new byte[videoWidth * videoHeight];
            byte[] combinedVFrame = new byte[videoWidth * videoHeight];
            //miejsce na wejściowe
            byte[] input1Y = frameReader.getNextFrameY();
            byte[] input1U = frameReader.getNextFrameU();
            byte[] input1V = frameReader.getNextFrameV();

            byte[] input2Y;
            byte[] input2U;
            byte[] input2V;

            String outTempFilePath = workingDir + "\\out_temp.yuv";

            using(BinaryWriter outputFile = new BinaryWriter(File.Open(outTempFilePath, FileMode.Create)))
            {
                //o jedna mniej niż klatka wejściowa
                //każda klatka 
                for(long i = 0; i < inputFrameCount - 1; ++i)
                {
                    input2Y = frameReader.getNextFrameY();
                    input2U = frameReader.getNextFrameU();
                    input2V = frameReader.getNextFrameV();

                    long idx;

                    //dla każdej próbki w Y
                    for(long px = 0; px < videoWidth * videoHeight; ++px)
                    {
                        idx = (px / videoWidth) * (4 * videoWidth) + 2 * (px % videoWidth);
                        combinedYFrame[idx] = input1Y[px]; //"pierwsza" klatka

                        combinedYFrame[idx + 1] = input2Y[px]; //"druga" klatka

                        idx += (videoWidth * 2) + 1;
                        combinedYFrame[idx] = input1Y[px]; //"pierwsza" klatka

                        combinedYFrame[idx - 1] = input2Y[px]; //"druga" klatka
                    }
                    //dla każdej próbki w U
                    for(long px = 0; px < (videoWidth * videoHeight) / 4; ++px)
                    {
                        idx = (px / (videoWidth / 2)) * (4 * (videoWidth / 2)) + 2 * (px % (videoWidth / 2));
                        combinedUFrame[idx] = input1U[px]; //"pierwsza" klatka

                        combinedUFrame[idx + 1] = input2U[px]; //"druga" klatka

                        idx += videoWidth + 1;
                        combinedUFrame[idx] = input1U[px]; //"pierwsza" klatka

                        combinedUFrame[idx - 1] = input2U[px]; //"druga" klatka
                    }
                    //dla każdej próbki w V
                    for(long px = 0; px < (videoWidth * videoHeight) / 4; ++px)
                    {
                        idx = (px / (videoWidth / 2)) * (4 * (videoWidth / 2)) + 2 * (px % (videoWidth / 2));
                        combinedVFrame[idx] = input1V[px]; //"pierwsza" klatka

                        combinedVFrame[idx + 1] = input2V[px]; //"druga" klatka

                        idx += videoWidth + 1;
                        combinedVFrame[idx] = input1V[px]; //"pierwsza" klatka

                        combinedVFrame[idx - 1] = input2V[px]; //"druga" klatka
                    }

                    input1Y = input2Y;
                    input1U = input2U;
                    input1V = input2V;

                    outputFile.Write(combinedYFrame);
                    outputFile.Write(combinedUFrame);
                    outputFile.Write(combinedVFrame);

                    worker.ReportProgress((int)((i * 100) / inputFrameCount));
                }
            }

            e.Result = new BackgroindWorkerResult(outTempFilePath, workerArguments.InputFilePath, 2 * videoWidth, 2 * videoHeight);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //raportowanie postępów
            progressBar.Value = e.ProgressPercentage;
            statusLabel.Text = "Processing... " + e.ProgressPercentage + "%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //koniec pracki workera
            progressBar.Value = progressBar.Maximum;
            statusLabel.Text = "Done assembling";

            var result = (BackgroindWorkerResult)e.Result;

            statusLabel.Text = "Calling FFmpeg again...";

            //String intermediateFilePath = Path.GetDirectoryName(textBoxOutputFile.Text) + "\\out_muted.webm";

            //"-s {0}x{1} -i {2} -c:v libvpx-vp9 -crf 30 -b:v 0 {3}"
            //kolejne odpalenie ffmpega żeby wypluł webm z yuv CRF JEST DO STEROWANIA JAKOŚCIĄ MOŻNA TO DAĆ DO WYBORU!!!!!!!!!!!!!!!!!!
            String args = String.Format("-s {0}x{1} -i {2} -i {3} -map 0:v -map 1:a -c:v libvpx-vp9 -crf 30 -b:v 0 {4}",
                result.VideoWidth, result.VideoHeight, result.OutTempFilePath, textBoxInputFile.Text, textBoxOutputFile.Text);

            //odpalenie ffmpega żeby wypluł plik yuv do obróbki
            Process ffmpeg = new Process();

            ffmpeg.StartInfo.FileName = textBoxFFmegPath.Text;
            ffmpeg.StartInfo.Arguments = args;

            ffmpeg.Start();

            ffmpeg.WaitForExit();

            //args = String.Format("-i {0} -i {1} -map 0:v -map 1:a  -codec copy -shortest {2}",
                //intermediateFilePath, textBoxInputFile.Text, textBoxOutputFile.Text);

            //ffmpeg.StartInfo.Arguments = args;

            //ffmpeg.Start();

            //ffmpeg.WaitForExit();

            try
            {
                File.Delete(result.InputTempFilePath);
                File.Delete(result.OutTempFilePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show("anlaki trzeba usunąć pliki tymczasowe ręcznie (wszystko w folderze wyjściowym)\n" + ex.Message);
            }

            progressBar.Value = 0;

            buttonStart.Enabled = true;
            buttonFFmpegSearch.Enabled = true;
            buttonInputFileSearch.Enabled = true;
            buttonOutputFileSearch.Enabled = true;
            maskedTextBoxWidth.Enabled = true;
            maskedTextBoxHeight.Enabled = true;
            textBoxFFmegPath.Enabled = true;
            textBoxInputFile.Enabled = true;
            textBoxOutputFile.Enabled = true;

            statusLabel.Text = "Done";
            resetTimer();
        }

        private void maskedTextBoxWidth_Click(object sender, EventArgs e)
        {
            maskedTextBoxWidth.Select(0, maskedTextBoxWidth.Text.Length);
        }

        private void maskedTextBoxHeight_Click(object sender, EventArgs e)
        {
            maskedTextBoxHeight.Select(0, maskedTextBoxHeight.Text.Length);
        }
    }

    public struct BackgroundWorkerArguments
    {
        public String InputFilePath
        {
            get; private set;
        }
        public int VideoWidth
        {
            get; private set;
        }
        public int VideoHeight
        {
            get; private set;
        }

        public BackgroundWorkerArguments(String inPath,  int width, int height)
        {
            InputFilePath = inPath;
            VideoWidth = width;
            VideoHeight = height;
        }

    }

    public struct BackgroindWorkerResult
    {
        public String OutTempFilePath
        {
            get; private set;
        }
        public String InputTempFilePath
        {
            get; private set;
        }
        public int VideoWidth
        {
            get; private set;
        }
        public int VideoHeight
        {
            get; private set;
        }

        public BackgroindWorkerResult(String outTempPath, String inputTempPath, int width, int height)
        {
            OutTempFilePath = outTempPath;
            InputTempFilePath = inputTempPath;
            VideoWidth = width;
            VideoHeight = height;
        }
    }
}
