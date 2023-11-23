using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aseassignment
{
    /// <summary>
    /// Parser class. It parses the input string commands.
    /// It validates the commands and returns the type and parameters required from the command.
    /// </summary>
    public class Parser
    {
        // The input entered by the user. It can be a single as well as multiple commands seperated by newline character.
        String input;

        /// <summary>
        /// constructor for the parser class.
        /// It takes the input string as a parameter and assigns it to input attribute after lowercasing it.
        /// </summary>

        public Parser(String commands)
        {
            // As the commands are case insensitive, we convert the input string to lowercase.
            this.input = commands.ToLower();
        }

        /// <summary>
        /// This method gets the command type. The command type is the first word in the command.
        /// </summary>
        /// <returns>It returns the command's type</returns>
        public String getCommandType()
        {
            String commandType = "";
            int i = 0;
            // As the command type is the first word in the command, we iterate through the input string until we find a space.
            while (i < input.Length && input[i] != ' ')
            {
                // We append the characters to the commandType string until we find a space.
                commandType += input[i];
                i++;
            }
            // We return the commandType string.
            return commandType;
        }

        /// <summary>
        /// This method gets all the command arguments and values. 
        /// For example, if the command is "rectangle 50,100" then the argument is rectangle and parameters are 50 and 100.
        /// </summary>
        /// <returns>It return the array of arguments after spliting the command on space(' ')</returns>
        public String[] getCommandArgs()
        {
            // This means that each word in the input string will become an element in the resulting array.
            String[] commandArgs = input.Split(' ');
            return commandArgs;
        }

        /// <summary>
        /// This method will get the parameters depending on the number of command arguments. Parameters are the values of the arguments.
        /// For example, if the command is "rectangle 20,40" then the parameters are 20 and 40.
        /// </summary>
        public List<String> parameters
        {
            // The getter will return the list of parameters.
            get
            {
                // Get the raw arguments and values of the command.
                string[] commands = getCommandArgs();

                // First argument is the command type and its parameters are cordinates which are seperated by comma.
                String[] values = commands[1].Split(',');

                // The list of parameters to be returned.  Initializes a new list named parameters to store the extracted values.
                List<String> parameters = new List<string>();

                // Get all the cordinates and add them to the list of parameters.
                for (int i = 0; i < values.Length; i++)
                {
                    parameters.Add(values[i]);
                }

                // If the pen argument is given than take the parameter of that argument
                if (commands.Length > 3) parameters.Add(commands[3]);

                // If the fill argument is given than take the parameter of that argument
                if (commands.Length > 4) parameters.Add(commands[5]);

                return parameters;
            }
        }

        /// <summary>
        /// Get the number of argument and values in the command.
        /// </summary>
        /// <returns>It will return the number of arguments and values</returns>
        public int getCommandArgsLength()
        {
            return getCommandArgs().Length;
        }
    }

}
