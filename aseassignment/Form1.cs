using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using static System.Windows.Forms.LinkLabel;
using System.Security.Cryptography;
using System.IO;
using System.Net.NetworkInformation;

namespace aseassignment
{

    /// <summary>
    /// Main Form class. It is the main display point for the application. It will display the canvas and the buttons.
    /// It will also be used to take commands from the user and pass them to the canvas. You can write a program,
    /// Save it or load it from other text files.
    /// </summary>
    public partial class Form1 : Form
    {
        //The canvas object. It will be used to draw the shapes on the the object it's been passed.Here we will be using the canvas object to draw the shapes on a picturebox.
        // This line declares a private instance variable of type Canvas named _thisCanvas. The private keyword indicates that this variable can only be accessed within the class it is declared in.

        private Canvas _thisCanvas;

        // This line declares a public instance variable of type Canvas named Canvas.
        // The public keyword indicates that this variable can be accessed from outside the class.

        public Canvas Canvas;


        // It will contain all the commands that are used to make the current canvas (picturebox).
        public string CommandsExecuted = "";

        // The width and height of the current form
        int formWidth, formHeight;

        // The varibles used to store the integer values in the program.
        //This declares a generic list (List<>) that can hold elements of type Tuple<string, int>. Each element in the list is a tuple consisting of a string and an integer.
        //  It's a list that will store tuples, where each tuple contains a string and an integer.
        //(= new List<Tuple<string, int>>();) : This initializes the list by creating a new instance of List<Tuple<string, int>>.
        //This means that when an object of the class is created, variables will be an empty list ready to store tuples.

        private List<Tuple<string, int>> variables = new List<Tuple<string, int>>();

        // The index at which the loop starts.
        private int loopStart = 0;

        // Static instance of the Form1 class to be used in other classes.
        //This line declares a private static variable named instance of type Form1.
        //The static keyword means that this variable is shared among all instances of the class, and it's initially set to null (the ? indicates that it can be nullable).

        private static Form1? instance;

        //This public static property serves as a getter for the singleton instance of the Form1 class. 
        //This implementation ensures that only one instance of Form1 is created,
        //and it provides a way to access that instance globally through the Instance property.

        public static Form1 Instance
        {
            //The getter block (get) checks whether the instance variable is null.
            //If it is, a new instance of Form1 is created and assigned to instance. Subsequent calls to Instance will return the existing instance.

            get
            {
                // If there is no instance of the Form1 class, create one.
                if (instance == null)
                {
                    instance = new Form1();
                }
                // Return the instance of the Form1 class.
                return instance;
            }
        }

        /// <summary>
        /// Constructor for the Form class. It will initialize all the GUI components set the default values to the attributes.
        /// It will also set the canvas object to the picturebox. and store the form dimensions in the attributes.
        /// </summary>
        private Form1()
        {
            // Initialize the GUI components
            InitializeComponent();

            // Set the canvas object to the picturebox. It will be used to draw the shapes on the picturebox.
            _thisCanvas = new Canvas(pbOutput);
            Canvas = _thisCanvas;

            // Set the form dimensions to the attributes.
            formWidth = this.Size.Width;
            formHeight = this.Size.Height;

        }

        /// <summary>
        /// Method to parse a command containing the varibles.
        /// </summary>
        /// <param name="command">The variable command.</param>
        /// <returns>Return true if the variable command was valid and executed, Otherwise false.</returns>
        /// <exception cref="Exception">Throw the exception if the the variable is divided by 0.</exception>
        private bool getVariable(string command)
        {
            // First split the variable name and the value or expression.
            string[] commandArgs = command.Split('=');

            if (commandArgs.Length == 2)
            {
                string variableName = commandArgs[0].Trim();
                string variableValue = commandArgs[1].Trim();

                // If the variable is already present in the list of variables.
                if (variables.Any(x => x.Item1.Equals(variableName)))
                {
                    // If the value expression is of sum.
                    if (variableValue.Contains("+"))
                    {
                        string[] variableValueArgs = variableValue.Split('+');
                        if (variableValueArgs.Length == 2)
                        {
                            string variableValue1 = variableValueArgs[0].Trim();
                            string variableValue2 = variableValueArgs[1].Trim();

                            // Sum the values of the values and save it. Then return true.
                            variables[variables.FindIndex(x => x.Item1.Equals(variableName))] = new Tuple<string, int>(variableName, GetVariableValue(variableValue1) + GetVariableValue(variableValue2));
                            return true;
                        }
                    }
                    // If the variable is of substraction.
                    else if (variableValue.Contains("-"))
                    {
                        string[] variableValueArgs = variableValue.Split('-');
                        if (variableValueArgs.Length == 2)
                        {
                            string variableValue1 = variableValueArgs[0].Trim();
                            string variableValue2 = variableValueArgs[1].Trim();

                            // Subtract the values of the values and save it. Then return true.
                            variables[variables.FindIndex(x => x.Item1.Equals(variableName))] = new Tuple<string, int>(variableName, GetVariableValue(variableValue1) - GetVariableValue(variableValue2));
                            return true;
                        }
                    }
                    // If the variable is of multiplication.
                    else if (variableValue.Contains("*"))
                    {
                        string[] variableValueArgs = variableValue.Split('*');
                        if (variableValueArgs.Length == 2)
                        {
                            string variableValue1 = variableValueArgs[0].Trim();
                            string variableValue2 = variableValueArgs[1].Trim();

                            // Multiply the values of the values and save it. Then return true.
                            variables[variables.FindIndex(x => x.Item1.Equals(variableName))] = new Tuple<string, int>(variableName, GetVariableValue(variableValue1) * GetVariableValue(variableValue2));
                            return true;
                        }
                    }
                    // If the variable is of division.
                    else if (variableValue.Contains("/"))
                    {
                        string[] variableValueArgs = variableValue.Split('/');
                        if (variableValueArgs.Length == 2)
                        {
                            string variableValue1 = variableValueArgs[0].Trim();
                            string variableValue2 = variableValueArgs[1].Trim();

                            if (GetVariableValue(variableValue2) == 0)
                            {
                                // Throw an exception if the variable is divided by 0.
                                throw new Exception("Cannot divide by zero");
                            }
                            else
                            {
                                // Divide the values of the values and save it. Then return true.
                                variables[variables.FindIndex(x => x.Item1.Equals(variableName))] = new Tuple<string, int>(variableName, GetVariableValue(variableValue1) / GetVariableValue(variableValue2));
                                return true;
                            }
                        }
                    }
                    // If the variable is of module.
                    else
                    {
                        // Save the value of the variable. Then return true.
                        variables[variables.FindIndex(x => x.Item1.Equals(variableName))] = new Tuple<string, int>(variableName, GetVariableValue(variableValue));
                        return true;
                    }
                }
                else
                {
                    int value = 0;
                    if (int.TryParse(variableValue, out value))
                    {
                        // If the variable is not present in the list of variables, add it to the list. Then return true.
                        variables.Add(new Tuple<string, int>(variableName, value));
                        return true;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// This function will return the variable value if exits otherwise converts the value into integer and returns it.
        /// </summary>
        /// <param name="value">The variable values.</param>
        /// <returns>The integer value of the variable.</returns>
        /// <exception cref="Exception"></exception>
        public int GetVariableValue(string value)
        {
            // check if the value is a variable
            string variableName = value;

            if (variables.Any(x => x.Item1 == variableName))
            {
                // get the value of the variable
                return variables.First(x => x.Item1 == variableName).Item2;
            }
            else
            {
                // return the value of the variable
                if (int.TryParse(value, out int valueInt))
                {
                    return valueInt;
                }
                else
                {
                    // throw an exception if the value is not a variable or integer
                    throw new Exception("Invalid variable name");
                }
            }
        }

        /// <summary>
        /// This function will check if the command is a variable declaration. Check the condition and return the appropriate boolean value.
        /// </summary>
        /// <param name="conditional">The type of conditional statement.</param>
        /// <param name="conditionalStatement">The full cobntional statement with the condition.</param>
        /// <returns></returns>
        private bool CheckCondition(string conditional, string conditionalStatement)
        {
            // get the condition of the loop or if statement
            //conditionalStatement.IndexOf(conditional): This part finds the index of the first occurrence of the conditional substring within the conditionalStatement.
            //It returns the starting index of the conditional substring.
            //+ conditional.Length: This part adds the length of the conditional substring to the index .
            //It effectively moves the starting position to the end of the conditional substring within the conditionalStatement.
            string condition = conditionalStatement.Substring(conditionalStatement.IndexOf(conditional) + conditional.Length).Trim();

            // get the left and right operands
            //The StringSplitOptions.None parameter is used to include empty substrings in the result array if there are consecutive delimiters.
            //For example, if there are two consecutive relational operators in the condition, it ensures that an empty string is included between them in the resulting array.
            string[] operands = condition.Split(new string[] { "==", "<=", ">=", "<", ">" }, StringSplitOptions.None);

            // get the left and right values
            string left = operands[0].Trim();
            string right = operands[1].Trim();

            // get the left and right values
            int leftValue = GetVariableValue(left);
            int rightValue = GetVariableValue(right);

            // return the result of the condition
            if (condition.Contains("=="))
            {
                return leftValue == rightValue;
            }
            else if (condition.Contains("<="))
            {
                return leftValue <= rightValue;
            }
            else if (condition.Contains(">="))
            {
                return leftValue >= rightValue;
            }
            else if (condition.Contains("<"))
            {
                return leftValue < rightValue;
            }
            else if (condition.Contains(">"))
            {
                return leftValue > rightValue;
            }

            // return false if the condition is not recognized
            return false;
        }





        /// <summary>
        /// Called when the exit button is pressed. It will exit the application.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Exit the application.
            Application.Exit();
        }

        /// <summary>
        /// Called when run button is pressed. It will run the program.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            // Run the program. It will run all the commands in the text box.
            executerun(rtbInput.Text);
        }

        /// <summary>
        /// Called when the "enter" key is pressed while typing in command line. It will run the command.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the "enter" key is pressed.
            if (e.KeyCode == Keys.Enter)
            {
                // If the command executes successfully then empty the commandline.
                if (execute(textBox1.Text)) textBox1.Text = "";

                // The event was handled. So, set the Handled property to true.
                e.Handled = true;

                // Do not send the key to the control.
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Called when syntex check button is clicked. It will check the program whether is syntecally correct or not.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private void btnSyntax_Click(object sender, EventArgs e)
        {
            // Check the program whether is syntecally correct or not.
            if (Parser.isValidSyntex(rtbInput.Text))
            {
                // Display the message if the program is syntecally correct.
                MessageBox.Show("All the command are written correctly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Display the message if the program is not syntecally correct.
                MessageBox.Show("There is an error in the given program.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// This method will execute the program line by line. It will execute the commands in the richTextBox.
        /// It will ignore the empty lines. It will not start if the program is syntecally incorrect.
        /// </summary>
        /// <param name="input">The multi-command Strind seperated by newline character</param>
        private void executerun(String input)
        {
            try
            {
                // Check if the input program is syntecally correct.
                if (Parser.isValidSyntex(input))
                {
                    // Split the input program into line commands.
                    String[] commands = input.Split('\n');

                    // Loop through all the commands.
                    foreach (String command in commands)
                    {
                        // skip if the line is empty
                        if (command.Equals("")) continue;

                        // normally execute the command
                        execute(command);
                    }
                }
                else
                {
                    // Display the error message if the program is not syntecally correct.
                    MessageBox.Show("Invalid program, please try again", "Syntex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                // Display the error message if a exception is thrown.
                MessageBox.Show("Invalid program, please try again", "Syntex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Called when the form is done resizing. It is used to resize and fit the canvas (picturebox).
        /// It is also used to redraw the canvas with the commands that are given before the canvas size changed.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            // If the form has same dimesions, do nothing. It means if the form is moved do nothing.
            if (this.Size.Width == formWidth && this.Size.Height == formHeight) return;

            // If the form is resized, then resize the canvas (picturebox) to fit the form.
            Canvas = new Canvas(pbOutput);

            // Redraw the canvas with the commands that are given before the canvas size changed.
            executerun(CommandsExecuted);
        }

        /// <summary>
        /// Called when the form is maximized. It is used to resize and fit the canvas (picturebox).
        /// It is also used to redraw the canvas with the commands that are given before the canvas size changed.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            // To catch the event when form is maximized.
            if (WindowState == FormWindowState.Maximized)
            {
                // If the form is resized, then resize the canvas (picturebox) to fit the form.
                Canvas = new Canvas(pbOutput);

                // Redraw the canvas with the commands that are given before the canvas size changed.
                executerun(CommandsExecuted);
            }
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
                MessageBox.Show("No file found at the given path.", "File Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
                                MessageBox.Show("The file has been save successfully.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                            MessageBox.Show("The file has been save successfully.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (IOException)
                    {
                        // Display the error message if the file is in use.
                        MessageBox.Show("There was an error saving the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("The file has been save successfully.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                        MessageBox.Show("The file has been save successfully.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                // Display the error message if an exception is thrown.
                catch (Exception) { MessageBox.Show("There was an error saving the file. The path entered can be incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

    }
}
