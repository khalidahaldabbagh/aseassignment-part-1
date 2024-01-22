namespace aseassignment
{
    partial class NewProgram
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
            label1 = new Label();
            lbFileStatus = new Label();
            label3 = new Label();
            lbProgramSyntex = new Label();
            tbFilePath = new TextBox();
            btnBrowse = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnExit = new Button();
            btnSyntax = new Button();
            btnRun = new Button();
            rtbInput = new RichTextBox();
            textBox1 = new TextBox();
            lbStatus = new Label();
            openFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(8, 870);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 32);
            label1.TabIndex = 24;
            label1.Text = "File Path";
            // 
            // lbFileStatus
            // 
            lbFileStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbFileStatus.ForeColor = SystemColors.ControlText;
            lbFileStatus.Location = new Point(115, 870);
            lbFileStatus.Margin = new Padding(5, 0, 5, 0);
            lbFileStatus.Name = "lbFileStatus";
            lbFileStatus.Size = new Size(585, 32);
            lbFileStatus.TabIndex = 22;
            lbFileStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(8, 776);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(176, 32);
            label3.TabIndex = 23;
            label3.Text = "Command Line";
            // 
            // lbProgramSyntex
            // 
            lbProgramSyntex.AutoSize = true;
            lbProgramSyntex.Location = new Point(8, 51);
            lbProgramSyntex.Margin = new Padding(5, 0, 5, 0);
            lbProgramSyntex.Name = "lbProgramSyntex";
            lbProgramSyntex.Size = new Size(181, 32);
            lbProgramSyntex.TabIndex = 21;
            lbProgramSyntex.Text = "Program Syntex";
            // 
            // tbFilePath
            // 
            tbFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbFilePath.Location = new Point(8, 909);
            tbFilePath.Margin = new Padding(5, 6, 5, 6);
            tbFilePath.Name = "tbFilePath";
            tbFilePath.Size = new Size(690, 39);
            tbFilePath.TabIndex = 20;
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBrowse.Location = new Point(234, 974);
            btnBrowse.Margin = new Padding(5, 5, 5, 5);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(104, 46);
            btnBrowse.TabIndex = 16;
            btnBrowse.Text = "&Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(447, 974);
            btnSave.Margin = new Padding(5, 5, 5, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 46);
            btnSave.TabIndex = 17;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoad.Location = new Point(349, 974);
            btnLoad.Margin = new Padding(5, 5, 5, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(88, 46);
            btnLoad.TabIndex = 18;
            btnLoad.Text = "&Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExit.Location = new Point(546, 974);
            btnExit.Margin = new Padding(5, 5, 5, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(153, 46);
            btnExit.TabIndex = 19;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSyntax
            // 
            btnSyntax.Location = new Point(468, 32);
            btnSyntax.Margin = new Padding(5, 5, 5, 5);
            btnSyntax.Name = "btnSyntax";
            btnSyntax.Size = new Size(107, 46);
            btnSyntax.TabIndex = 15;
            btnSyntax.Text = "check";
            btnSyntax.UseVisualStyleBackColor = true;
            btnSyntax.Click += btnSyntax_Click;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(587, 32);
            btnRun.Margin = new Padding(5, 5, 5, 5);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(114, 46);
            btnRun.TabIndex = 13;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // rtbInput
            // 
            rtbInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rtbInput.Location = new Point(8, 88);
            rtbInput.Margin = new Padding(5, 5, 5, 5);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(690, 636);
            rtbInput.TabIndex = 12;
            rtbInput.Text = "";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(8, 813);
            textBox1.Margin = new Padding(5, 5, 5, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(690, 39);
            textBox1.TabIndex = 11;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // lbStatus
            // 
            lbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(11, 734);
            lbStatus.Margin = new Padding(5, 0, 5, 0);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(0, 32);
            lbStatus.TabIndex = 25;
            //
            // NewProgram
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 1038);
            Controls.Add(lbStatus);
            Controls.Add(label1);
            Controls.Add(lbFileStatus);
            Controls.Add(label3);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewProgram";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NewProgram";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbFileStatus;
        private Label label3;
        private Label lbProgramSyntex;
        private TextBox tbFilePath;
        private Button btnBrowse;
        private Button btnSave;
        private Button btnLoad;
        private Button btnExit;
        private Button btnSyntax;
        private Button btnRun;
        private RichTextBox rtbInput;
        private TextBox textBox1;
        private Label lbStatus;
        private OpenFileDialog openFileDialog;
    }
}