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
            components = new System.ComponentModel.Container();
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
            tColorTransition = new System.Windows.Forms.Timer(components);
            lbStatus = new Label();
            lbFileStatus = new Label();
            btnNewProgram = new Button();
            ((System.ComponentModel.ISupportInitialize)pbOutput).BeginInit();
            SuspendLayout();
            // 
            // pbOutput
            // 
            pbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbOutput.BackColor = Color.DimGray;
            pbOutput.Location = new Point(535, 53);
            pbOutput.Name = "pbOutput";
            pbOutput.Size = new Size(415, 441);
            pbOutput.TabIndex = 0;
            pbOutput.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(43, 511);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(426, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // rtbInput
            // 
            rtbInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rtbInput.Location = new Point(43, 88);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(426, 349);
            rtbInput.TabIndex = 2;
            rtbInput.Text = "";
            rtbInput.TextChanged += rtbInput_TextChanged;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(400, 53);
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
            btnExit.Location = new Point(856, 583);
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
            tbFilePath.Location = new Point(43, 583);
            tbFilePath.Margin = new Padding(3, 4, 3, 4);
            tbFilePath.Name = "tbFilePath";
            tbFilePath.Size = new Size(613, 27);
            tbFilePath.TabIndex = 6;
            // 
            // lbProgramSyntex
            // 
            lbProgramSyntex.AutoSize = true;
            lbProgramSyntex.Location = new Point(43, 65);
            lbProgramSyntex.Name = "lbProgramSyntex";
            lbProgramSyntex.Size = new Size(113, 20);
            lbProgramSyntex.TabIndex = 7;
            lbProgramSyntex.Text = "Program Syntex";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(535, 31);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 8;
            label2.Text = "Canvas";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(43, 488);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 9;
            label3.Text = "Command Line";
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(735, 583);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(54, 29);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "&Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(795, 583);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(54, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(43, 559);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 10;
            label1.Text = "File Path";
           
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBrowse.Location = new Point(664, 583);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(64, 29);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "&Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // tColorTransition
            // 
            tColorTransition.Interval = 500;
            tColorTransition.Tick += tColorTransition_Tick;
            // 
            // lbStatus
            // 
            lbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(43, 441);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(0, 20);
            lbStatus.TabIndex = 9;
            // 
            // lbFileStatus
            // 
            lbFileStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbFileStatus.ForeColor = SystemColors.ControlText;
            lbFileStatus.Location = new Point(110, 559);
            lbFileStatus.Name = "lbFileStatus";
            lbFileStatus.Size = new Size(547, 20);
            lbFileStatus.TabIndex = 9;
            lbFileStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNewProgram
            // 
            btnNewProgram.Location = new Point(195, 53);
            btnNewProgram.Name = "btnNewProgram";
            btnNewProgram.Size = new Size(125, 29);
            btnNewProgram.TabIndex = 4;
            btnNewProgram.Text = "New Program";
            btnNewProgram.UseVisualStyleBackColor = true;
            btnNewProgram.Click += btnNewProgram_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 627);
            Controls.Add(label1);
            Controls.Add(lbStatus);
            Controls.Add(lbFileStatus);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbProgramSyntex);
            Controls.Add(tbFilePath);
            Controls.Add(btnBrowse);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(btnExit);
            Controls.Add(btnNewProgram);
            Controls.Add(btnSyntax);
            Controls.Add(btnRun);
            Controls.Add(rtbInput);
            Controls.Add(textBox1);
            Controls.Add(pbOutput);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Programming Language";
            ResizeEnd += Form1_ResizeEnd;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pbOutput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private System.Windows.Forms.Timer tColorTransition;
        public PictureBox pbOutput;
        private Label lbStatus;
        private Label lbFileStatus;
        private Button btnNewProgram;
    }
}