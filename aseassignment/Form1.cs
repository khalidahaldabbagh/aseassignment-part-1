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


        // This will store the error string
        public string errorString = "";


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

            // Start the cursor color transitions.
            tColorTransition.Start();

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
        /// Get the index where the loop statement ends. 
        /// </summary>
        /// <param name="i">Starting index of the loop statement.</param>
        /// <param name="commands">The commands array.</param>
        /// <returns>The index where the loop ends.</returns>
        private int GetEndloopIndex(int i, string[] commands)
        {
            int endloopIndex = -1;
            for (int j = i; j < commands.Length; j++)
            {
                // check if the command is endloop
                if (commands[j].Trim().Equals("endloop"))
                {
                    // Endloop index is found
                    endloopIndex = j;
                    break;
                }
            }

            // return the endloop index
            return endloopIndex;
        }

        /// <summary>
        /// Get the index where the if statement ends.
        /// </summary>
        /// <param name="i">Starting index of the if statement.</param>
        /// <param name="commands">The commands array.</param>
        /// <returns>The index where the if statement ends.</returns>
        private int GetEndIfIndex(int i, string[] commands)
        {
            int endIfIndex = -1;
            for (int j = i; j < commands.Length; j++)
            {
                // check if the command is endif
                if (commands[j].Trim().Equals("endif"))
                {
                    // Endif index is found
                    endIfIndex = j;
                    break;
                }
            }

            // return the endif index
            return endIfIndex;
        }

        /// <summary>
        /// The method to execute the single command from the progrom or command line.
        /// It will take the command and validate it.
        /// If it is valid, It will parse parameters from the command and use the canvas object to draw the shape.
        /// </summary>
        /// <param name="command">The String of commands to be executed</param>
        public async Task<bool> execute(string command, bool isResize = false, bool resetFromNewProgram = false, Canvas canvas = null)
        {
            if (canvas != null)
            {
                Canvas = canvas;
            }
            else
            {
                Canvas = _thisCanvas;
            }

            Parser parser = new Parser(command);
            // Check if the command is valid. If it is not valid, it will return false.
            lbFileStatus.Text = "";
            if (Parser.isValidSyntex(command))
            {
                try
                {
                    // Check if the given command is "run". 
                    if (command.Equals("run"))
                    {
                        /* If the command is "run".
                         * Get the commands from the richTextBox. It will be used to execute the program.
                         *  await is used in asynchronous programming to make the code wait for the completion of asynchronous
                         *  tasks without blocking the main thread.
                         */
                        if (await IsValidProgram(CommandsExecuted))
                        {
                            await executerun(CommandsExecuted);
                        }
                        else
                        {
                            // Show that the commands are syntecally incorrect.
                            lbStatus.Text = errorString;
                            lbStatus.ForeColor = Color.Red;
                            errorString = "";
                        }
                    }
                    // Check if the command is "clear". 
                    else if (command.Equals("clear"))
                    {
                        /* If the command is "clear".
                         * Clear the canvas (picturebox).
                         */
                        Canvas.Clear();
                    }
                    // Check if the command is "reset".
                    else if (command.Equals("reset"))
                    {
                        /* If the command is "reset".
                         * Clear the canvas (picturebox) and reset it to default. 
                         * Clear the program box, file path textbox and command line.
                         */
                        if (!resetFromNewProgram)
                        {
                            rtbInput.Text = "";
                            textBox1.Text = "";
                            tbFilePath.Text = "";
                        }
                        Canvas.Clear();
                    }
                    // Check if the command is "moveto".
                    else if (parser.getCommandType().Equals("moveto"))
                    {
                        /* If the command is "moveto".
                         * Get the x and y coordinates from the parser object.
                         * Using canvas object, move the pointer to the given coordinates.
                         */
                        int x = GetVariableValue(parser.parameters[0]);
                        int y = GetVariableValue(parser.parameters[1]);
                        Canvas.MoveTo(x, y);
                    }
                    // Check if the command is "drawto".
                    else if (parser.getCommandType().Equals("drawto"))
                    {
                        /* If the command is "drawto".
                         * Get the x and y coordinates from the parser object.
                         * Using canvas object, draw a line from the pointer to the given coordinates.
                         */
                        int x = GetVariableValue(parser.parameters[0]);
                        int y = GetVariableValue(parser.parameters[1]);

                        // Check whether the "pen" argumant was also passed to change the color of the line.
                        if (parser.getCommandArgsLength() == 2)
                        {
                            // Draw line without color.
                            Canvas.DrawTo(x, y);
                        }
                        else
                        {
                            // Draw line with color.
                            Canvas.DrawTo(x, y, parser.parameters[2]);
                        }
                    }
                    // Check if the command is "circle". It will draw a circle with pointer as center.
                    else if (parser.getCommandType().Equals("circle"))
                    {
                        /* If the command is "circle".
                         * Get the radius from the parser object.
                         * Using canvas object, draw a circle with pointer as center and given radius.
                         */
                        int radius = GetVariableValue(parser.parameters[0]);

                        // Check if only the radius was passed.
                        if (parser.getCommandArgsLength() == 2)
                        {
                            // Draw circle with default color.
                            Canvas.DrawCircle(radius);
                        }
                        // Check if the "pen" argumant was also passed.
                        else if (parser.getCommandArgsLength() == 4)
                        {
                            // Draw outlined circle with given color.
                            Canvas.DrawCircle(radius, parser.parameters[1]);
                        }
                        // Check if the "fill" argumant was also passed.
                        else if (parser.getCommandArgsLength() == 6)
                        {
                            // Draw filled circle with given color.
                            Canvas.DrawCircle(radius, parser.parameters[1], parser.parameters[2]);
                        }
                    }
                    // Check if the command is "triangle".
                    else if (parser.getCommandType().Equals("triangle"))
                    {
                        /* If the command is "triangle".
                         * Get the size from the parser object.
                         * Using canvas object, draw a triangle with pointer as center and given size.
                         */
                        int size = GetVariableValue(parser.parameters[0]);

                        // Check if only the size was passed.
                        if (parser.getCommandArgsLength() == 2)
                        {
                            // Draw triangle with default color.
                            Canvas.DrawTriangle(size);
                        }
                        // Check if the "pen" argumant was also passed.
                        else if (parser.getCommandArgsLength() == 4)
                        {
                            // Draw outlined triangle with given color.
                            Canvas.DrawTriangle(size, parser.parameters[1]);
                        }
                        // Check if the "fill" argumant was also passed.
                        else if (parser.getCommandArgsLength() == 6)
                        {
                            // Draw filled triangle with given color.
                            Canvas.DrawTriangle(size, parser.parameters[1], parser.parameters[2]);
                        }
                    }
                    // Check if the command is "rectangle". It will draw a rectangle with pointer as center.
                    else if (parser.getCommandType().Equals("rectangle"))
                    {
                        /* If the command is "rectangle".
                         * Get the width and height from the parser object.
                         * Using canvas object, draw a rectangle with pointer as center and given width and height.
                         */
                        int width = GetVariableValue(parser.parameters[0]);
                        int height = GetVariableValue(parser.parameters[1]);

                        // Check if only the width and height were passed.
                        if (parser.getCommandArgsLength() == 2)
                        {
                            // Draw rectangle with default color.
                            Canvas.DrawRectangle(width, height);
                        }
                        // Check if the "pen" argumant was also passed.
                        else if (parser.getCommandArgsLength() == 4)
                        {
                            // Draw outlined rectangle with given color.
                            Canvas.DrawRectangle(width, height, parser.parameters[2]);
                        }
                        // Check if the "fill" argumant was also passed.
                        else if (parser.getCommandArgsLength() == 6)
                        {
                            // Draw filled rectangle with given color.
                            Canvas.DrawRectangle(width, height, parser.parameters[2], parser.parameters[3]);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Syntex Error");
                }

                // Check if the command is not of any sigle argument command types.
                if (!(command.Equals("clear") || command.Equals("reset") || command.Equals("run")))
                {
                    // Add the commands in the CommandsExecuted variable to provide input when the canvas size changes and it is redrawn.
                    if (!isResize)
                    {
                        CommandsExecuted += command + "\n";
                    }
                }
                else
                {
                    // Check if the command is not "run".
                    if (!command.Equals("run"))
                        /* CommandsExecuted is used to store the commands that are used when the canvas (picturebox) size changes and it is redrawn.
                         * If it is not "run", then the CommandsExecuted variable is cleared to avoid the commands being repeated when the canvas is redrawn.
                         */
                        CommandsExecuted = ""; // Clear the CommandsExecuted variable.
                }

                // The most important line. It will call the paint function of the picturebox to re-paint the changes in the picturebox
                pbOutput.Invalidate();
            }
            else
            {
                if (getVariable(command) == false)
                {
                    return false;
                }
                else
                {
                    if (!isResize)
                    {
                        // Add the commands in the CommandsExecuted variable to provide input when the canvas size changes and it is redrawn.
                        CommandsExecuted += command + "\n";
                    }
                }
            }

            // Return true if the command is executed successfully.
            return true;
        }

        /// <summary>
        /// This method will execute the program line by line. It will execute the commands in the richTextBox.
        /// It will ignore the empty lines. It will not start if the program is syntecally incorrect.
        /// </summary>
        /// <param name="input">The multi-command Strind seperated by newline character</param>
        /// <param name="isResize">The boolean value to check if the canvas size is changed.</param>
        public async Task executerun(string input, bool isResize = false, Canvas canvas = null)
        {
            // Clear the variables list for new program
            variables.Clear();
            // Set the loop index to default
            loopStart = 0;

            // Split the input program into line commands.
            // As the commands are case insensitive, we convert the input string to lowercase.
            string[] commands = input.ToLower().Split('\n');

            // Loop through all the commands.
            for (int i = 0; i < commands.Length; i++)
            {
                // skip if the line is empty
                if (string.IsNullOrWhiteSpace(commands[i]) || string.IsNullOrEmpty(commands[i])) continue;

                // Parse the command to get the command type
                Parser parser = new Parser(commands[i]);

                // Check if the command is a loop
                if (parser.getCommandType().Equals("while"))
                {
                    // If the loop condition is true
                    if (CheckCondition("while", commands[i]))
                    {
                        loopStart = i;
                    }
                    else
                    {
                        // If the loop condition is false, skip the loop
                        int endLoopIndex = GetEndloopIndex(i, commands);
                        i = endLoopIndex == -1 ? throw new Exception("EndLoop tag not found.") : endLoopIndex;
                    }
                }
                // Check if the command is an if statement.
                else if (parser.getCommandType().Equals("if"))
                {
                    // If the if condition is false, skip the if statement
                    if (!CheckCondition("if", commands[i]))
                    {
                        int endIfIndex = GetEndIfIndex(i, commands);
                        i = endIfIndex == -1 ? throw new Exception("EndIf tag not found.") : endIfIndex;
                    }
                }
                // Check if the command is an endloop statement.
                else if (parser.getCommandType().Equals("endloop"))
                {
                    // If the endloop is not written correct throw an exception
                    if (!commands[i].Trim().Equals("endloop"))
                    {
                        throw new Exception("Sytnex error");
                    }
                    // Now the loop is ended, so set the loop index to start loop
                    i = loopStart - 1;
                }
                // Check if the command is an endif statement.
                else if (parser.getCommandType().Equals("endif"))
                {
                    // If the endif is not written correct throw an exception.
                    if (!commands[i].Trim().Equals("endif"))
                    {
                        throw new Exception("Sytnex error");
                    }
                }
                // Otherwise execute the command.
                else
                {
                    // Execute the command and if it returns false throw an exception.
                    if (!await execute(commands[i], isResize, canvas: canvas)) throw new Exception("Sytnex error");

                    await Task.Delay(2000);
                }
            }
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
            if (await IsValidProgram(rtbInput.Text))
            {
                // Run the program. It will run all the commands in the text box.
                await executerun(rtbInput.Text);
            }
            else
            {
                // Show that the commands are syntecally incorrect.
                lbStatus.Text = errorString;
                lbStatus.ForeColor = Color.Red;
                errorString = "";
            }
        }


        /// <summary>
        /// Called when the "enter" key is pressed while typing in command line. It will run the command.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the "enter" key is pressed.
            if (e.KeyCode == Keys.Enter)
            {
                CommandsExecuted = rtbInput.Text;
                try
                {
                    // If the command executes successfully then empty the commandline.
                    if (await execute(textBox1.Text)) textBox1.Text = "";
                }
                catch (Exception)
                { }

                // The event was handled. So, set the Handled property to true.
                e.Handled = true;
                CommandsExecuted = "";

                // Do not send the key to the control.
                e.SuppressKeyPress = true;
            }
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
        /// Called when syntex check button is clicked. It will check the program whether is syntecally correct or not.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private async void btnSyntax_Click(object sender, EventArgs e)
        {
            // Check if the program is syntecally correct
            if (await IsValidProgram(rtbInput.Text))
            {
                // Show that the commands are syntecally correct
                lbStatus.Text = "Syntex OK";
                lbStatus.ForeColor = Color.Green;
            }
            else
            {
                // Show that the commands are syntecally incorrect.
                lbStatus.Text = errorString;
                lbStatus.ForeColor = Color.Red;
                errorString = "";
            }
        }


        /// <summary>
        /// This method will check if the program is syntecally correct.
        /// </summary>
        /// <param name="input">Input command program.</param>
        /// <returns>Return true if the program </returns>
        public Task<bool> IsValidProgram(string input)
        {
            variables.Clear();
            int codeLinesIndex = 0;
            loopStart = 0;

            try
            {
                // Split the input program into line commands.
                // As the commands are case insensitive, we convert the input string to lowercase.
                string[] commands = input.ToLower().Split('\n');

                // Loop through all the commands.
                for (int i = 0; i < commands.Length; i++)
                {
                    codeLinesIndex = i;

                    // skip if the line is empty
                    if (string.IsNullOrWhiteSpace(commands[i]) || string.IsNullOrEmpty(commands[i])) continue;

                    Parser parser = new Parser(commands[i]);

                    // Check if the command is a loop
                    if (parser.getCommandType().Equals("while"))
                    {
                        // If the loop condition is false, skip the loop
                        int endLoopIndex = GetEndloopIndex(i, commands);
                        if (endLoopIndex == -1)
                        {
                            codeLinesIndex = commands.Length - 1;
                            throw new Exception("EndLoop tag not found");
                        }

                        // If the loop condition is true
                        if (CheckCondition("while", commands[i]))
                        {
                            loopStart = i;
                        }
                        else
                        {
                            i = endLoopIndex;
                        }
                    }
                    // Check if the command is an if statement.
                    else if (parser.getCommandType().Equals("if"))
                    {
                        int endIfIndex = GetEndIfIndex(i, commands);
                        if (endIfIndex == -1)
                        {
                            codeLinesIndex = commands.Length - 1;
                            throw new Exception("EndIf tag not found");
                        }

                        // If the if condition is false, skip the if statement
                        if (!CheckCondition("if", commands[i]))
                        {
                            i = endIfIndex;
                        }
                    }
                    // Check if the command is an endloop statement.
                    else if (parser.getCommandType().Equals("endloop"))
                    {
                        // If the endloop is not written correct throw an exception
                        if (!commands[i].Trim().Equals("endloop"))
                        {
                            throw new Exception("Sytnex error");
                        }

                        // Now the loop is ended, so set the loop index to start loop
                        i = loopStart - 1;
                    }
                    // Check if the command is an endif statement.
                    else if (parser.getCommandType().Equals("endif"))
                    {
                        // If the endif is not written correct throw an exception.
                        if (!commands[i].Trim().Equals("endif"))
                        {
                            throw new Exception("Sytnex error");
                        }
                    }
                    // Otherwise execute the command.
                    else
                    {
                        if (!Parser.isValidSyntex(commands[i]))
                        {
                            // If the command is not valid, throw an exception.
                            if (getVariable(commands[i]) == false)
                            {
                                // Display the error message if the command is not recognized.
                                throw new Exception("Sytnex error");
                            }
                        }
                    }
                }
                //used in asynchronous programming to represent an operation that is already completed.
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                // store the error message if a exception is thrown.
                errorString = "Line " + (codeLinesIndex + 1) + ", " + ex.Message + ".";
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Called when the form is done resizing. It is used to resize and fit the canvas (picturebox).
        /// It is also used to redraw the canvas with the commands that are given before the canvas size changed.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private async void Form1_ResizeEnd(object sender, EventArgs e)
        {
            // If the form has same dimesions, do nothing. It means if the form is moved do nothing.
            if (this.Size.Width == formWidth && this.Size.Height == formHeight) return;

            // Check if the form is size is increased.
            if (this.Size.Width + this.Size.Height > formWidth + formHeight)
            {
                // If the form is resized, then resize the canvas (picturebox) to fit the form.
                Canvas = new Canvas(pbOutput);

                // Store the form size
                formWidth = this.Size.Width;
                formHeight = this.Size.Height;

                // Check if the program is syntecally correct
                if (await IsValidProgram(rtbInput.Text))
                {
                    // Redraw the canvas with the commands that are given before the canvas size changed.
                    await executerun(CommandsExecuted, true);
                }
                else
                {
                    // Show that the commands are syntecally incorrect.
                    lbStatus.Text = errorString;
                    lbStatus.ForeColor = Color.Red;
                    errorString = "";
                }
            }
        }


        /// <summary>
        /// Called when the form is maximized. It is used to resize and fit the canvas (picturebox).
        /// It is also used to redraw the canvas with the commands that are given before the canvas size changed.
        /// </summary>
        /// <param name="sender">The object that is the sender of this event</param>
        /// <param name="e">The arguments passed on this event</param>
        private async void Form1_Resize(object sender, EventArgs e)
        {
            // To catch the event when form is maximized.
            if (WindowState == FormWindowState.Maximized)
            {
                // If the form is resized, then resize the canvas (picturebox) to fit the form.
                Canvas = new Canvas(pbOutput);

                // Check if the program is syntecally correct
                if (await IsValidProgram(rtbInput.Text))
                {
                    // Redraw the canvas with the commands that are given before the canvas size changed.
                    await executerun(CommandsExecuted, true);
                }
                else
                {
                    // Show that the commands are syntecally incorrect.
                    lbStatus.Text = errorString;
                    lbStatus.ForeColor = Color.Red;
                    errorString = "";
                }
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


        //This program implements a graphical user interface (GUI) feature for color transitions in a cursor.
        //It utilizes a timer to trigger regular color updates, and the cursor'sappearance is managed through a Canvas class.
        //The resulting changes are reflected in a PictureBox (pbOutput) within the GUI.
        private void tColorTransition_Tick(object sender, EventArgs e)
        {
            // Transition the cursor color
            Canvas.DrawCursor();
            // Update the canvas
            pbOutput.Invalidate();
        }

        //This code snippet is an event handler for the TextChanged event of a RichTextBox (rtbInput).
        //The primary purpose of this event handler is to respond to changes in the text content of the RichTextBox
        //by clearing any error messages or status labels.
        private void rtbInput_TextChanged(object sender, EventArgs e)
        {
            // If there is an activity in the rich text box. clear the errors.
            lbFileStatus.Text = "";
            lbStatus.Text = "";
        }

        //This code snippet is an event handler for the TextChanged event of a textbox1.
        //The primary purpose of this event handler is to respond to changes in the text content of the TextBox1
        //by clearing any error messages or status labels.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // If there is an activity in the text box. clear the errors.
            lbFileStatus.Text = "";
            lbStatus.Text = "";
        }


        private void btnNewProgram_Click(object sender, EventArgs e)
        {
            NewProgram newProgram = new NewProgram(new Canvas(pbOutput));
            newProgram.Show();
        }

       
    }
}
