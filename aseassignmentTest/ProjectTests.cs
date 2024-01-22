namespace aseassignmentTest
{
    using aseassignment;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="ProjectTests" />. Tests of the aseassignment user input.
    /// </summary>
    public class ProjectTests

    {
        //  This method is executed before each test.
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test to check if the individual commands are as per requirement.
        /// </summary>
        /// <param name="command">A single individual command.</param>
        [Test]
        [TestCase("rectangle 10,20")]
        [TestCase("circle 30 pen red fill on")]
        [TestCase("triangle 30,40 pen green")]
        [TestCase("clear")]
        [TestCase("reset")]
        [TestCase("run")]
        public void IsValidCommand_ValidCommandsAdded_ReturnsTrue(string command)
        {
            // Check if the given command is valid.
            Assert.That(Parser.isValidSyntex(command), Is.True);
        }

        /// <summary>
        /// Test to check if the incorrect individual commands are validated.
        /// </summary>
        /// <param name="command">A single individual command.</param>
        [Test]
        [TestCase("rectangle 10, 20")]
        [TestCase("circle 30  pen red fill on")]
        [TestCase("triangle 30, pen green")]
        [TestCase("clear -")]
        [TestCase("reset this")]
        [TestCase("run.")]
        public void IsValidCommand_InValidCommandsAdded_ReturnsFalse(string command)
        {
            // Check if the given command is invalid.
            Assert.That(Parser.isValidSyntex(command), Is.False);
        }

        /// <summary>
        /// Test valid simple commands from a program.
        /// </summary>
        [Test]
        public void InputFromText_SimpleCommandProgram_ReturnsTrue()
        {
            bool result = false;

            // Load the program1 text.
            using (StreamReader streamReader = File.OpenText("..\\..\\..\\Testing\\program1.txt"))
            {
                // Read the text from the file.
                string reader = streamReader.ReadToEnd();
                // Save the result after validating the program.
                result = Parser.isValidSyntex(reader);
            }

            // Check the result of the validation.
            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Test valid while loop command from a program.
        /// </summary>
        [Test]
        public void InputFromText_WhileloopProgram_ReturnsTrue()
        {
            bool result = false;

            // Load the program2 text.
            using (StreamReader streamReader = File.OpenText("..\\..\\..\\Testing\\program2.txt"))
            {
                // Read the text from the file.
                string reader = streamReader.ReadToEnd();
                // Save the result after validating the program.
                result = Form1.Instance.IsValidProgram(reader).Result;
            }

            // Check the result of the validation.
            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Test valid while loop with single if command from a program.
        /// </summary>
        [Test]
        public void InputFromText_WhileLoopWithIfProgram_ReturnsTrue()
        {
            bool result = false;

            // Load the program3 text.
            using (StreamReader streamReader = File.OpenText("..\\..\\..\\Testing\\program3.txt"))
            {
                // Read the text from the file.
                string reader = streamReader.ReadToEnd();
                // Save the result after validating the program.
                result = Form1.Instance.IsValidProgram(reader).Result;
            }

            // Check the result of the validation.
            Assert.That(result, Is.True);
        }


    }
}