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


    }
}