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
            pbOutput.Location = new Point(869, 85);
            pbOutput.Margin = new Padding(6, 4, 6, 4);
            pbOutput.Name = "pbOutput";
            pbOutput.Size = new Size(674, 706);
            pbOutput.TabIndex = 0;
            pbOutput.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(71, 742);
            textBox1.Margin = new Padding(6, 4, 6, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(689, 39);
            textBox1.TabIndex = 1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // rtbInput
            // 
            rtbInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rtbInput.Location = new Point(71, 141);
            rtbInput.Margin = new Padding(6, 4, 6, 4);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(689, 557);
            rtbInput.TabIndex = 2;
            rtbInput.Text = "";
            rtbInput.TextChanged += rtbInput_TextChanged;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(650, 85);
            btnRun.Margin = new Padding(6, 4, 6, 4);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(113, 47);
            btnRun.TabIndex = 3;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnSyntax
            // 
            btnSyntax.Location = new Point(531, 85);
            btnSyntax.Margin = new Padding(6, 4, 6, 4);
            btnSyntax.Name = "btnSyntax";
            btnSyntax.Size = new Size(108, 47);
            btnSyntax.TabIndex = 4;
            btnSyntax.Text = "check";
            btnSyntax.UseVisualStyleBackColor = true;
            btnSyntax.Click += btnSyntax_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExit.Location = new Point(1391, 917);
            btnExit.Margin = new Padding(6, 4, 6, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(152, 47);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // tbFilePath
            // 
            tbFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbFilePath.Location = new Point(71, 858);
            tbFilePath.Margin = new Padding(6, 6, 6, 6);
            tbFilePath.Name = "tbFilePath";
            tbFilePath.Size = new Size(689, 39);
            tbFilePath.TabIndex = 6;
            // 
            // lbProgramSyntex
            // 
            lbProgramSyntex.AutoSize = true;
            lbProgramSyntex.Location = new Point(71, 105);
            lbProgramSyntex.Margin = new Padding(6, 0, 6, 0);
            lbProgramSyntex.Name = "lbProgramSyntex";
            lbProgramSyntex.Size = new Size(181, 32);
            lbProgramSyntex.TabIndex = 7;
            lbProgramSyntex.Text = "Program Syntex";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(869, 49);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 32);
            label2.TabIndex = 8;
            label2.Text = "Canvas";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(71, 706);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(176, 32);
            label3.TabIndex = 9;
            label3.Text = "Command Line";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(578, 917);
            btnLoad.Margin = new Padding(6, 4, 6, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(87, 47);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(676, 917);
            btnSave.Margin = new Padding(6, 4, 6, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(87, 47);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(71, 819);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 32);
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
            btnBrowse.Location = new Point(462, 917);
            btnBrowse.Margin = new Padding(6, 4, 6, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(104, 47);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 1003);
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
            Margin = new Padding(6, 4, 6, 4);
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