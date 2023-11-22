namespace aseassignment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbOutput = new PictureBox();
            label2 = new Label();
            btnExit = new Button();
            rtbInput = new RichTextBox();
            lbProgramSyntex = new Label();
            btnRun = new Button();
            btnSyntax = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            tbFilePath = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            btnLoad = new Button();
            btnBrowse = new Button();
            ((System.ComponentModel.ISupportInitialize)pbOutput).BeginInit();
            SuspendLayout();
            // 
            // pbOutput
            // 
            pbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbOutput.BackColor = Color.DimGray;
            pbOutput.Location = new Point(666, 64);
            pbOutput.Margin = new Padding(3, 4, 3, 4);
            pbOutput.Name = "pbOutput";
            pbOutput.Size = new Size(610, 581);
            pbOutput.TabIndex = 0;
            pbOutput.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(686, 40);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(55, 20);
            label2.TabIndex = 8;
            label2.Text = "Canvas";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExit.Location = new Point(1190, 653);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 31);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // rtbInput
            // 
            rtbInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rtbInput.Location = new Point(12, 103);
            rtbInput.Margin = new Padding(3, 4, 3, 4);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(628, 398);
            rtbInput.TabIndex = 2;
            rtbInput.Text = "";
            // 
            // lbProgramSyntex
            // 
            lbProgramSyntex.AutoSize = true;
            lbProgramSyntex.Location = new Point(27, 75);
            lbProgramSyntex.Name = "lbProgramSyntex";
            lbProgramSyntex.Size = new Size(113, 20);
            lbProgramSyntex.TabIndex = 7;
            lbProgramSyntex.Text = "Program Syntex";
            lbProgramSyntex.Click += lbProgramSyntex_Click;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(556, 64);
            btnRun.Margin = new Padding(3, 4, 3, 4);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(86, 31);
            btnRun.TabIndex = 3;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            // 
            // btnSyntax
            // 
            btnSyntax.Location = new Point(464, 64);
            btnSyntax.Margin = new Padding(3, 4, 3, 4);
            btnSyntax.Name = "btnSyntax";
            btnSyntax.Size = new Size(86, 31);
            btnSyntax.TabIndex = 4;
            btnSyntax.Text = "check";
            btnSyntax.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(14, 545);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(628, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(27, 521);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 9;
            label3.Text = "Command Line";
            // 
            // tbFilePath
            // 
            tbFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbFilePath.Location = new Point(14, 618);
            tbFilePath.Margin = new Padding(3, 4, 3, 4);
            tbFilePath.Name = "tbFilePath";
            tbFilePath.Size = new Size(628, 27);
            tbFilePath.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(27, 594);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 12;
            label1.Text = "File Path";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(556, 653);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 31);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(464, 653);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(86, 31);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBrowse.Location = new Point(372, 653);
            btnBrowse.Margin = new Padding(3, 4, 3, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(86, 31);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 708);
            Controls.Add(btnBrowse);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(tbFilePath);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(btnSyntax);
            Controls.Add(btnRun);
            Controls.Add(lbProgramSyntex);
            Controls.Add(rtbInput);
            Controls.Add(btnExit);
            Controls.Add(label2);
            Controls.Add(pbOutput);
            Name = "Form1";
            Text = "Simple Programming Languape";
            ((System.ComponentModel.ISupportInitialize)pbOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbOutput;
        private Label label2;
        private Button btnExit;
        private RichTextBox rtbInput;
        private Label lbProgramSyntex;
        private Button btnRun;
        private Button btnSyntax;
        private TextBox textBox1;
        private Label label3;
        private TextBox tbFilePath;
        private Label label1;
        private Button btnSave;
        private Button btnLoad;
        private Button btnBrowse;
    }
}