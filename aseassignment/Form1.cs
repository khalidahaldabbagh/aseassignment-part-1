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

namespace aseassignment
{
    /// <summary>
    /// Main Form class. It is the main display point for the application. It will display the canvas and the buttons.
    /// It will also be used to take commands from the user and pass them to the canvas.
    /// You can write a program, Save it or load it from other text files.
    /// </summary>
    public partial class Form1 : Form
    {
        /* The canvas object.Here we will use the canvas object to draw the shapes on a picturebox. */
        Canvas Canvas;

        // It will contain all the commands that are used to make the current canvas (picturebox).
        String commandsGiven = "";

        // The width and height of the current form
        int formWidth, formHeight;

        /// <summary>
        /// Constructor for the Form class. It will initialize all the GUI components set the default values to the attributes.
        /// It will also set the canvas object to the picturebox and store the form dimensions in the attributes.
        /// </summary>
        public Form1()
        {
            // Initialize the GUI components
            InitializeComponent();

            // Set the canvas object to the picturebox. It will be used to draw the shapes on the picturebox.
            Canvas = new Canvas(pbOutput);

            // Set the form dimensions to the attributes.
            formWidth = this.Size.Width;
            formHeight = this.Size.Height;
        }

        /// <summary>
        /// The method to execute the single command from the progrom or command line.
        /// It will take the command and validate it.
        /// If it is valid, It will parse parameters from the command and use the canvas object to draw the shape.
        /// </summary>
        /// <param name="command">The String of commands to be executed</param>
        private bool execute(String command)
        {
            // As the commands are case insensitive, we convert the input string to lowercase.
            command = command.ToLower();

            // Check if the command is valid. If it is not valid, it will return false.
            if (Parser.isValidSyntex(command))
            {
                try
                {
                    Parser Parser = new Parser(command);

                    // Check if the given command is "run". 
                    if (command.Equals("run"))
                    {
                        /* If the command is "run".
                         * Get the commands from the richTextBox. It will be used to execute the program.
                         */
                        executerun(rtbInput.Text);
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
                        // just move the pointer to the starting point of the canvas.
                        Canvas.MoveTo(0, 0);
                    }
                    // Check if the command is "moveto".
                    else if (Parser.getCommandType().Equals("moveto"))
                    {
                        /* If the command is "moveto".
                         * Get the x and y coordinates from the parser object.
                         * Using canvas object, move the pointer to the given coordinates.
                         */
                        int x = Convert.ToInt32(Parser.parameters[0]);
                        int y = Convert.ToInt32(Parser.parameters[1]);
                        Canvas.MoveTo(x, y);
                    }
                    // Check if the command is "drawto".
                    else if (Parser.getCommandType().Equals("drawto"))
                    {
                        /* If the command is "drawto".
                         * Get the x and y coordinates from the parser object.
                         * Using canvas object, draw a line from the pointer to the given coordinates.
                         */
                        int x = Convert.ToInt32(Parser.parameters[0]);
                        int y = Convert.ToInt32(Parser.parameters[1]);

                        // Check whether the "pen" argumant was also passed to change the color of the line.
                        if (Parser.getCommandArgsLength() == 2)
                        {
                            // Draw line without color.
                            Canvas.DrawTo(x, y);
                        }
                        else
                        {
                            // Draw line with color.
                            Canvas.DrawTo(x, y, Parser.parameters[2]);
                        }
                    }
                    // Check if the command is "circle". It will draw a circle with pointer as center.
                    else if (Parser.getCommandType().Equals("circle"))
                    {
                        /* If the command is "circle".
                         * Get the radius from the parser object.
                         * Using canvas object, draw a circle with pointer as center and given radius.
                         */
                        int radius = Convert.ToInt32(Parser.parameters[0]);

                        // Check if only the radius was passed.
                        if (Parser.getCommandArgsLength() == 2)
                        {
                            // Draw circle with default color.
                            Canvas.DrawCircle(radius);
                        }
                        // Check if the "pen" argumant was also passed.
                        else if (Parser.getCommandArgsLength() == 4)
                        {
                            // Draw outlined circle with given color.
                            Canvas.DrawCircle(radius, Parser.parameters[2]);
                        }
                        // Check if the "fill" argumant was also passed.
                        else if (Parser.getCommandArgsLength() == 6)
                        {
                            // Draw filled circle with given color.
                            Canvas.DrawCircle(radius, Parser.parameters[2], Parser.parameters[3]);
                        }
                    }
                    // Check if the command is "triangle".
                    else if (Parser.getCommandType().Equals("triangle"))
                    {
                        /* If the command is "triangle".
                         * Get the size from the parser object.
                         * Using canvas object, draw a triangle with pointer as center and given size.
                         */
                        int size = Convert.ToInt32(Parser.parameters[0]);

                        // Check if only the size was passed.
                        if (Parser.getCommandArgsLength() == 2)
                        {
                            // Draw triangle with default color.
                            Canvas.DrawTriangle(size);
                        }
                        // Check if the "pen" argumant was also passed.
                        else if (Parser.getCommandArgsLength() == 4)
                        {
                            // Draw outlined triangle with given color.
                            Canvas.DrawTriangle(size, Parser.parameters[2]);
                        }
                        // Check if the "fill" argumant was also passed.
                        else if (Parser.getCommandArgsLength() == 6)
                        {
                            // Draw filled triangle with given color.
                            Canvas.DrawTriangle(size, Parser.parameters[2], Parser.parameters[3]);
                        }
                    }
                    // Check if the command is "rectangle". It will draw a rectangle with pointer as center.
                    else if (Parser.getCommandType().Equals("rectangle"))
                    {
                        /* If the command is "rectangle".
                         * Get the width and height from the parser object.
                         * Using canvas object, draw a rectangle with pointer as center and given width and height.
                         */
                        int width = Convert.ToInt32(Parser.parameters[0]);
                        int height = Convert.ToInt32(Parser.parameters[1]);

                        // Check if only the width and height were passed.
                        if (Parser.getCommandArgsLength() == 2)
                        {
                            // Draw rectangle with default color.
                            Canvas.DrawRectangle(width, height);
                        }
                        // Check if the "pen" argumant was also passed.
                        else if (Parser.getCommandArgsLength() == 4)
                        {
                            // Draw outlined rectangle with given color.
                            Canvas.DrawRectangle(width, height, Parser.parameters[2]);
                        }
                        // Check if the "fill" argumant was also passed.
                        else if (Parser.getCommandArgsLength() == 6)
                        {
                            // Draw filled rectangle with given color.
                            Canvas.DrawRectangle(width, height, Parser.parameters[2], Parser.parameters[3]);
                        }
                    }
                    else
                    {
                        // Display the error message if the command is not recognized.
                        MessageBox.Show("Invalid command, please try again", "Syntex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                catch (Exception)
                {
                    // Display the error message if a exception is thrown.
                    MessageBox.Show("Invalid command, please try again", "Syntex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Check if the command is not of any sigle argument command types.
                if (!(command.Equals("clear") || command.Equals("reset") || command.Equals("run")))
                {
                    // Add the commands in the commandsGiven variable to provide input when the canvas size changes and it is redrawn.
                    commandsGiven += command + "\n";
                }
                else
                {
                    // Check if the command is not "run".
                    if (!command.Equals("run"))
                        /* commandsGiven is used to store the commands that are used when the canvas (picturebox) size changes and it is redrawn.
                         * If it is not "run", then the commandsGiven variable is cleared to avoid the commands being repeated when the canvas is redrawn.
                         */
                        commandsGiven = ""; // Clear the commandsGiven variable.
                }

                // The most important line. It will call the paint function of the picturebox to re-paint the changes in the picturebox
                pbOutput.Invalidate();

            }
            else
            {
                // Display the error message if there is an syntex error in the command.
                MessageBox.Show("Invalid command, please try again", "Syntex Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
        /// Called when syntex check button is clicked. It will check the program whether is correct or not.
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

    }
}