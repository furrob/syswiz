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
            this.components = new System.ComponentModel.Container();
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBoxWidth = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBoxHeight = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBoxBitsPerSample = new System.Windows.Forms.MaskedTextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFFmpegSearch
            // 
            this.buttonFFmpegSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFFmpegSearch.Location = new System.Drawing.Point(497, 4);
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
            this.textBoxFFmegPath.Size = new System.Drawing.Size(401, 20);
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
            this.textBoxInputFile.Size = new System.Drawing.Size(401, 20);
            this.textBoxInputFile.TabIndex = 4;
            // 
            // buttonInputFileSearch
            // 
            this.buttonInputFileSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInputFileSearch.Location = new System.Drawing.Point(497, 30);
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
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output file:";
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputFile.Location = new System.Drawing.Point(90, 84);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.Size = new System.Drawing.Size(401, 20);
            this.textBoxOutputFile.TabIndex = 7;
            // 
            // buttonOutputFileSearch
            // 
            this.buttonOutputFileSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutputFileSearch.Location = new System.Drawing.Point(497, 82);
            this.buttonOutputFileSearch.Name = "buttonOutputFileSearch";
            this.buttonOutputFileSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonOutputFileSearch.TabIndex = 8;
            this.buttonOutputFileSearch.Text = "Search";
            this.buttonOutputFileSearch.UseVisualStyleBackColor = true;
            this.buttonOutputFileSearch.Click += new System.EventHandler(this.buttonOutputFileSearch_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 218);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(22, 17);
            this.statusLabel.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Input video dimensions:";
            // 
            // maskedTextBoxWidth
            // 
            this.maskedTextBoxWidth.Location = new System.Drawing.Point(211, 58);
            this.maskedTextBoxWidth.Mask = "9999";
            this.maskedTextBoxWidth.Name = "maskedTextBoxWidth";
            this.maskedTextBoxWidth.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxWidth.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "x";
            // 
            // maskedTextBoxHeight
            // 
            this.maskedTextBoxHeight.Location = new System.Drawing.Point(270, 58);
            this.maskedTextBoxHeight.Mask = "9999";
            this.maskedTextBoxHeight.Name = "maskedTextBoxHeight";
            this.maskedTextBoxHeight.Size = new System.Drawing.Size(32, 20);
            this.maskedTextBoxHeight.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "px";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Bits per sample:";
            // 
            // maskedTextBoxBitsPerSample
            // 
            this.maskedTextBoxBitsPerSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBoxBitsPerSample.Enabled = false;
            this.maskedTextBoxBitsPerSample.Location = new System.Drawing.Point(471, 58);
            this.maskedTextBoxBitsPerSample.Mask = "99";
            this.maskedTextBoxBitsPerSample.Name = "maskedTextBoxBitsPerSample";
            this.maskedTextBoxBitsPerSample.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxBitsPerSample.TabIndex = 18;
            this.maskedTextBoxBitsPerSample.Text = "8";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(497, 192);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 19;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 240);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.maskedTextBoxBitsPerSample);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBoxHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBoxWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonOutputFileSearch);
            this.Controls.Add(this.textBoxOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonInputFileSearch);
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFFmegPath);
            this.Controls.Add(this.buttonFFmpegSearch);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "checkerboarding";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBitsPerSample;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer timer;
    }
}

