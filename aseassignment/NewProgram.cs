using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aseassignment
{

    //another independent program window  which can has a separate program and execute it on same canvus
    //the constroctor of new program.

    public partial class NewProgram : Form
    {
        private Canvas canvas;

        public NewProgram(Canvas canvas)
        {
            InitializeComponent();
            this.canvas = canvas;
        }

        /// <summary>
        /// Called when run button is pressed. It will run the program.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private async void btnRun_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            // Check if the program is syntecally correct
            if (await Form1.Instance.IsValidProgram(rtbInput.Text))
            {
                // Run the program. It will run all the commands in the text box.
                await Form1.Instance.executerun(rtbInput.Text, canvas: canvas);
            }
            else
            {
                // Show that the commands are syntecally incorrect.
                lbStatus.Text = Form1.Instance.errorString;
                lbStatus.ForeColor = Color.Red;
                Form1.Instance.errorString = "";
            }
        }
        /// <summary>
        /// Called when browse button is clicked. It will open the file dialog to select the file on local system.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Only text files are allowed.
            openFileDialog.Filter = "Text File(*.txt)|*.txt";

            DialogResult result = openFileDialog.ShowDialog();

            // If the user selects a file.
            if (result == DialogResult.OK)
            {
                // Set the path in the tbFilePath.
                tbFilePath.Text = openFileDialog.FileName;
            }
            // Free the dialog box resources.
            openFileDialog.Dispose();
        }

        /// <summary>
        /// Called when the load button is clicked. It will load the data from the path given in tbFilePath into the program box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The arguments passed on this event</param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Check if the file exists at the given path exists.
            if (File.Exists(tbFilePath.Text))
            {
                // Read data from file and load the data in array of String.
                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                // Join all the lines into one string and display it in the program richTextBox.
                String text = String.Join(Environment.NewLine, lines);
                rtbInput.Text = text;

                // After loading the data, clear the file path text box.
                tbFilePath.Text = "";
            }
            else
            {
                // Display the error message if the file does not exists.
                lbFileStatus.Text = "File does not exists.";
                lbFileStatus.ForeColor = Color.Red;
            }
            // Free the dialog box resources.
            openFileDialog.Dispose();
        }

        /// <summary>
        /// Called when the save button is clicked. It will save the data to the path provided or selected through file dialog.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>

        private void btnSave_Click(object sender, EventArgs e)
        {
            // If there is no path in the tbFilePath text box.
            if (tbFilePath.Text.Equals(""))
            {
                // Only text files are allowed.
                openFileDialog.Filter = "(*.txt;)| *.txt;";

                // Do not check if the file exists.
                openFileDialog.CheckFileExists = false;

                // Show the file dialog.
                DialogResult result = openFileDialog.ShowDialog();

                // If the user selects a file.
                if (result == DialogResult.OK)
                {
                    try
                    { // If the file on the path chosen exists.
                        if (File.Exists(openFileDialog.FileName))
                        { // Ask whether the user wants to overwrite the existing file.
                            if (MessageBox.Show("Do want to overwrite the selected file.", "File already exits", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            { // Using the stream writer (resource) write the text in that file.
                                using (StreamWriter sw = File.CreateText(openFileDialog.FileName))
                                {
                                    // Write the text in the file.
                                    sw.Write(rtbInput.Text);
                                }
                                // Display the success message.
                                lbFileStatus.Text = "File saved successfully.";
                                lbFileStatus.ForeColor = Color.Green;
                            }
                        }
                        else
                        { // Using the stream writer (resource) write the text in that file.
                            using (StreamWriter sw = File.CreateText(openFileDialog.FileName))
                            {
                                // Write the text in the file.
                                sw.Write(rtbInput.Text);
                            }
                            // Display the success message.
                            lbFileStatus.Text = "File saved successfully.";
                            lbFileStatus.ForeColor = Color.Green;
                        }
                    }
                    catch (IOException)
                    {
                        // Display the error message if the file is in use.
                        lbFileStatus.Text = "There was an error saving the file.";
                        lbFileStatus.ForeColor = Color.Red;
                    }
                }
                // Free the dialog box resources.
                openFileDialog.Dispose();
            }
            else
            { // If the tbFilePath has a path in text field.
                try
                { // If the file on the path entered exists.
                    if (File.Exists(tbFilePath.Text))
                    { // Ask whether the user wants to overwrite the existing file.
                        if (MessageBox.Show("Do want to overwrite the selected file.", "File already exits", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        { // Using the stream writer (resource) write the text in that file.
                            using (StreamWriter sw = File.CreateText(tbFilePath.Text))
                            {
                                // Write the text in the file.
                                sw.Write(rtbInput.Text);
                            }
                            // Display the success message.
                            lbFileStatus.Text = "File saved successfully.";
                            lbFileStatus.ForeColor = Color.Green;
                        }
                    }
                    else
                    { // using the stream writer (resource) write the text in that file.
                        using (StreamWriter sw = File.CreateText(tbFilePath.Text))
                        {
                            // Write the text in the file.
                            sw.Write(rtbInput.Text);
                        }
                        // Display the success message.
                        lbFileStatus.Text = "File saved successfully.";
                        lbFileStatus.ForeColor = Color.Green;
                    }
                }
                // Display the error message if an exception is thrown.
                catch (Exception)
                {
                    lbFileStatus.Text = "There was an error saving the file.";
                    lbFileStatus.ForeColor = Color.Red;
                }
            }
        }

        // cloce the independent NewProgram FORM and return to main form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Called when syntex check button is clicked. It will check the program whether is syntecally correct or not.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private async void btnSyntax_Click(object sender, EventArgs e)
        {
            // Check if the program is syntecally correct
            if (await Form1.Instance.IsValidProgram(rtbInput.Text))
            {
                // Show that the commands are syntecally correct
                lbStatus.Text = "Syntex OK";
                lbStatus.ForeColor = Color.Green;
            }
            else
            {
                // Show that the commands are syntecally incorrect.
                lbStatus.Text = Form1.Instance.errorString;
                lbStatus.ForeColor = Color.Red;
                Form1.Instance.errorString = "";
            }
        }

            private async void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                // Check if the "enter" key is pressed.
                if (e.KeyCode == Keys.Enter)
                {
                    Form1.Instance.CommandsExecuted = rtbInput.Text;
                    try
                    {
                        // If the command executes successfully then empty the commandline.
                        if (await Form1.Instance.execute(textBox1.Text, resetFromNewProgram: true, canvas: canvas))
                        {
                            if (textBox1.Text.Equals("reset"))
                            {
                                rtbInput.Text = "";
                                textBox1.Text = "";
                                tbFilePath.Text = "";
                            }
                            textBox1.Text = "";// Check if the given command is "run". 
                        }
                    }
                    catch (Exception)
                    { }

                    Form1.Instance.CommandsExecuted = "";

                    // The event was handled. So, set the Handled property to true.
                    e.Handled = true;

                    // Do not send the key to the control.
                    e.SuppressKeyPress = true;
                }
            }
        

    }
}
