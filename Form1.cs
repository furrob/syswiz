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

            try
            {
                if(int.Parse(maskedTextBoxWidth.Text) <= 0)
                {
                    statusLabel.Text = "Input video width set incorrectly";
                    resetTimer();
                    return;
                }

                if(int.Parse(maskedTextBoxHeight.Text) <= 0)
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
    }

}
