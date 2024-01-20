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
            textBox1 = new TextBox();
            rtbInput = new RichTextBox();
            btnRun = new Button();
            btnSyntax = new Button();
            btnExit = new Button();
            tbFilePath = new TextBox();
            lbProgramSyntex = new Label();
            label2 = new Label();
            label3 = new Label();
            btnLoad = new Button();
            btnSave = new Button();
            label1 = new Label();
            openFileDialog = new OpenFileDialog();
            btnBrowse = new Button();
            ((System.ComponentModel.ISupportInitialize)pbOutput).BeginInit();
            SuspendLayout();
            // 
            // pbOutput
            // 
            pbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbOutput.BackColor = Color.DimGray;
            pbOutput.Location = new Point(535, 53);
            pbOutput.Margin = new Padding(4, 2, 4, 2);
            pbOutput.Name = "pbOutput";
            pbOutput.Size = new Size(415, 494);
            pbOutput.TabIndex = 0;
            pbOutput.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(44, 520);
            textBox1.Margin = new Padding(4, 2, 4, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(426, 27);
            textBox1.TabIndex = 1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // rtbInput
            // 
            rtbInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rtbInput.Location = new Point(44, 88);
            rtbInput.Margin = new Padding(4, 2, 4, 2);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(426, 406);
            rtbInput.TabIndex = 2;
            rtbInput.Text = "";
            // 
            // btnRun
            // 
            btnRun.Location = new Point(400, 53);
            btnRun.Margin = new Padding(4, 2, 4, 2);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(70, 29);
            btnRun.TabIndex = 3;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnSyntax
            // 
            btnSyntax.Location = new Point(327, 53);
            btnSyntax.Margin = new Padding(4, 2, 4, 2);
            btnSyntax.Name = "btnSyntax";
            btnSyntax.Size = new Size(66, 29);
            btnSyntax.TabIndex = 4;
            btnSyntax.Text = "check";
            btnSyntax.UseVisualStyleBackColor = true;
            btnSyntax.Click += btnSyntax_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExit.Location = new Point(856, 573);
            btnExit.Margin = new Padding(4, 2, 4, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 5;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // tbFilePath
            // 
            tbFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbFilePath.Location = new Point(44, 573);
            tbFilePath.Margin = new Padding(4);
            tbFilePath.Name = "tbFilePath";
            tbFilePath.Size = new Size(426, 27);
            tbFilePath.TabIndex = 6;
            // 
            // lbProgramSyntex
            // 
            lbProgramSyntex.AutoSize = true;
            lbProgramSyntex.Location = new Point(44, 66);
            lbProgramSyntex.Margin = new Padding(4, 0, 4, 0);
            lbProgramSyntex.Name = "lbProgramSyntex";
            lbProgramSyntex.Size = new Size(113, 20);
            lbProgramSyntex.TabIndex = 7;
            lbProgramSyntex.Text = "Program Syntex";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(535, 31);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 8;
            label2.Text = "Canvas";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(48, 498);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 9;
            label3.Text = "Command Line";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(652, 573);
            btnLoad.Margin = new Padding(4, 2, 4, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "&Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(754, 573);
            btnSave.Margin = new Padding(4, 2, 4, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(44, 549);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 10;
            label1.Text = "File Path";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "program.txt";
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBrowse.Location = new Point(550, 573);
            btnBrowse.Margin = new Padding(4, 2, 4, 2);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "&Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 627);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbProgramSyntex);
            Controls.Add(tbFilePath);
            Controls.Add(btnBrowse);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(btnExit);
            Controls.Add(btnSyntax);
            Controls.Add(btnRun);
            Controls.Add(rtbInput);
            Controls.Add(textBox1);
            Controls.Add(pbOutput);
            Margin = new Padding(4, 2, 4, 2);
            Name = "Form1";
            Text = "Simple Programming Language";
            ResizeEnd += Form1_ResizeEnd;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pbOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbOutput;
        private TextBox textBox1;
        private RichTextBox rtbInput;
        private Button btnRun;
        private Button btnSyntax;
        private Button btnExit;
        private TextBox tbFilePath;
        private Label lbProgramSyntex;
        private Label label2;
        private Label label3;
        private Button btnLoad;
        private Button btnSave;
        private Label label1;
        private OpenFileDialog openFileDialog;
        private Button btnBrowse;
    }
}