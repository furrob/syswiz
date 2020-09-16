namespace checkerboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonFFmpegSearch = new System.Windows.Forms.Button();
            this.textBoxFFmegPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.buttonInputFileSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.buttonOutputFileSearch = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // buttonFFmpegSearch
            // 
            this.buttonFFmpegSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFFmpegSearch.Location = new System.Drawing.Point(713, 4);
            this.buttonFFmpegSearch.Name = "buttonFFmpegSearch";
            this.buttonFFmpegSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonFFmpegSearch.TabIndex = 0;
            this.buttonFFmpegSearch.Text = "Search";
            this.buttonFFmpegSearch.UseVisualStyleBackColor = true;
            this.buttonFFmpegSearch.Click += new System.EventHandler(this.buttonFFmpegSearch_Click);
            // 
            // textBoxFFmegPath
            // 
            this.textBoxFFmegPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFFmegPath.Location = new System.Drawing.Point(90, 6);
            this.textBoxFFmegPath.Name = "textBoxFFmegPath";
            this.textBoxFFmegPath.Size = new System.Drawing.Size(617, 20);
            this.textBoxFFmegPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "FFmpeg path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input file:";
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInputFile.Location = new System.Drawing.Point(90, 32);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(617, 20);
            this.textBoxInputFile.TabIndex = 4;
            // 
            // buttonInputFileSearch
            // 
            this.buttonInputFileSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInputFileSearch.Location = new System.Drawing.Point(713, 30);
            this.buttonInputFileSearch.Name = "buttonInputFileSearch";
            this.buttonInputFileSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonInputFileSearch.TabIndex = 5;
            this.buttonInputFileSearch.Text = "Search";
            this.buttonInputFileSearch.UseVisualStyleBackColor = true;
            this.buttonInputFileSearch.Click += new System.EventHandler(this.buttonInputFileSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output file:";
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputFile.Location = new System.Drawing.Point(90, 58);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.Size = new System.Drawing.Size(617, 20);
            this.textBoxOutputFile.TabIndex = 7;
            // 
            // buttonOutputFileSearch
            // 
            this.buttonOutputFileSearch.Location = new System.Drawing.Point(713, 56);
            this.buttonOutputFileSearch.Name = "buttonOutputFileSearch";
            this.buttonOutputFileSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonOutputFileSearch.TabIndex = 8;
            this.buttonOutputFileSearch.Text = "Search";
            this.buttonOutputFileSearch.UseVisualStyleBackColor = true;
            this.buttonOutputFileSearch.Click += new System.EventHandler(this.buttonOutputFileSearch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonOutputFileSearch);
            this.Controls.Add(this.textBoxOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonInputFileSearch);
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFFmegPath);
            this.Controls.Add(this.buttonFFmpegSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonFFmpegSearch;
        private System.Windows.Forms.TextBox textBoxFFmegPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.Button buttonInputFileSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOutputFile;
        private System.Windows.Forms.Button buttonOutputFileSearch;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

