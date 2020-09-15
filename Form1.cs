using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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


        }
    }

}
