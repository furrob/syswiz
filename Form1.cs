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
                return;
            }

            if(!File.Exists(textBoxInputFile.Text))
            {
                statusLabel.Text = "Path to input file is not valid";
                return;
            }

            if(!Directory.Exists(Path.GetDirectoryName(textBoxOutputFile.Text)))
            {
                statusLabel.Text = "Output directory does not exist";
                return;
            }

            try
            {
                if(int.Parse(maskedTextBoxWidth.Text) <= 0)
                {
                    statusLabel.Text = "Input video width set incorrectly";
                    return;
                }

                if(int.Parse(maskedTextBoxHeight.Text) <= 0)
                {
                    statusLabel.Text = "Input video height set incorrectly";
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wrong video dimensions\n" + ex.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            

            //argumenty do ffmpega
            String args = String.Format("-i {0} -c:v rawvideo -pix_fmt yuv420p D:/temp.yuv",
                textBoxInputFile.Text);

            //odpalenie ffmpega żeby wypluł plik yuv do obróbki
            Process ffmpeg = new Process();

            ffmpeg.StartInfo.FileName = textBoxFFmegPath.Text;
            ffmpeg.StartInfo.Arguments = args;

            ffmpeg.Start();

            ffmpeg.WaitForExit();
            statusLabel.Text = String.Empty;
        }
    }

}
