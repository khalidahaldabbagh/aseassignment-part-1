using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aseassignment
{
    /// <summary>
    /// It is the canvas class. 
    /// It consists of a Graphics object which is used to draw the shapes on the canvas.
    /// It also has a bitmap which is used to manipulate the pixels of the canvas.
    /// Note: The canvas mentioned here is the picturebox on which the shapes are drawn.
    /// It has basic methods like moveto (to move on the canvas),
    /// drawto (to draw a line on the canvas), clear (to clear the canvas), etc.
    /// It also contains the methods that draw the 3 basic shapes (circle, triangle and rectangle).
    /// </summary>
    class Canvas
    {
        // This graphic object is used to draw different shapes on the canvas. 
        Graphics g;

        // x and y corrdinates of the cursor on the canvas.
        // The cursor shows your location on the canvas and from where you can start drawing.
        // It is used to store the original pixels where the cursor is drawn.
        public int xPos, yPos;

        // The 2 dimensional array that contains the pixels of the cursor on the canvas.
        // It is used to store the pixels of the spot the cursor is moved on, so that it can be restored later.
        Color[,] cursor;

        // It is the bitmap that is used to manipulate the pixels of the canvas.
        // It contains all the pixels of the canvas in the form of a 2 dimensional array of colors.
        Bitmap bitmap;

        /// <summary>
        /// Constructor for the canvas class.
        /// It takes the picturebox as a parameter and uses it to initialize the bitmap and the graphics objects,
        /// because we want to make the shapes inside the given picturebox.
        /// </summary>
        /// <param name="pictureBox">The instance of picturebox in which the shapes and drawing is to be drawn</param>
        public Canvas(PictureBox pictureBox)
        {
            // Set the initial position of the cursor to (0,0) cordinated on canvas (or picturebox)
            xPos = yPos = 0;

            // Make an object of 2 dimensional pixel array, size same as of picturebox. Store it in bitmap.
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);

            // Set the 2 dimensional pixel array of the bitmap to the 2 dimensional pixel array of the picturebox.
            // Image is also like a 2 dimensional array of pixels.
            // Bitmap is also the implementation of Image so we can store bitmap in Image.
            pictureBox.Image = bitmap;

            // Get the graphics object of the picturebox.
            // Now the graphics object can be used to draw the shapes on the canvas (picturebox).
            // Initializes the graphics object from the bitmap, allowing drawing on the canvas.
            this.g = Graphics.FromImage(bitmap);

            // Initialize the curor 2 dimensional array.
            //Initializes the cursor array with a size of 10x10. This is the area around the cursor that is saved for later restoration.
            cursor = new Color[10, 10];

            // This method is used to store the pixels where the cursor will be drawn on.
            SaveStateBeforeCursor();

            // This will move the cursor to the initial position (0,0) on the canvas.
            MoveTo(xPos, yPos);
        }

        /// <summary>
        /// Method to remove the cursor pixels and restore that point's state where the cursor was on.
        /// It will use the cursor 2 dimensional array to restore the pixels which are stored before moving the cursor to a location.
        /// </summary>
        private void RemoveCursor()
        {
            // x and y cordinate of the cursor image, to remove the cursor as a rectangle of 10x10 pixels around the current location pointer we subtract 1 from the both xPos and yPos. 
            //It subtracts 1 from both xPos and yPos to ensure that the cursor removal area extends one pixel beyond the current cursor position.
            int x = xPos - 1, y = yPos - 1;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //This line sets the pixel at the current position (x + i, y + j) on the bitmap (canvas) to the color value stored in the corresponding position (i, j) of the cursor array.
                    //This effectively restores the original color of the canvas in the region where the cursor was previously drawn.
                    // The code is wrapped in a try-catch block to handle any potential exceptions that might occur if the cursor removal area extends beyond the canvas boundaries.
                    // The try block attempts to set the pixel color, and if an exception occurs (for example, if the pixel is outside the canvas), it is caught and ignored (catch (Exception) { })
                   
                    try { bitmap.SetPixel(x + i, y + j, cursor[i, j]); } catch (Exception) { }
                }
            }
        }

        /// <summary>
        /// Method to draw the cursor on the current location.
        /// It will use the bitmap to draw the cursor in 10x10 rectangle around the current location.
        /// </summary>
        private void DrawCursor()
        {
            // x and y cordinate of the cursor image, to draw the cursor as a rectangle of 10x10 pixels around the current location pointer we subtract 1 from the both xPos and yPos. 
            int x = xPos - 1, y = yPos - 1;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Leave the center of the cursor as it is.
                    if (i == 1 && j == 1) continue;
                    //  This line sets the pixel at the current position (x + i, y + j) on the bitmap (canvas) to the color red,
                    //  creating the red-colored rectangle that represents the cursor.
                    try { bitmap.SetPixel(x + i, y + j, Color.Red); } catch (Exception) { }
                }
            }

        }

        /// <summary>
        /// Method to save the pixels of the location where the cursor is to be drawn.
        /// It will store all those pixels in the cursor 2 dimensional array which is the same size as our cursor.
        /// </summary>
        private void SaveStateBeforeCursor()
        {
            // x and y cordinate of the cursor image, to save pixels of the cursor .
            //  It subtracts 1 from both xPos and yPos to ensure that the cursor drawing area extends one pixel beyond the current cursor position.
            int x = xPos - 1, y = yPos - 1;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Store the pixel at curent position (x+i,y+j) cordinates in the cursor, 2 dimensional array to restore the canvas without cursor.
                    //  If an exception occurs (for example, if the pixel is outside the canvas), it is caught, and the cursor array is assigned a default color (Color.DimGray).
                    try { cursor[i, j] = bitmap.GetPixel(x + i, y + j); } catch (Exception) { cursor[i, j] = Color.DimGray; }
                }
            }
        }
    }
}
