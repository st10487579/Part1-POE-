using System;
using System.Drawing; // Requires System.Drawing.Common NuGet package

namespace Part1
{
    // This class handles the conversion of a JPG image into ASCII art.
    public class logo
    {
        string path_logo = AppDomain.CurrentDomain.BaseDirectory;

        public logo()
        {
            asci();
        }

        private void asci()
        {
            try
            {
                // Navigate to the main project folder to find the image.
                string full_path = path_logo.Replace(@"\bin\Debug\", @"\") + "logo.jpg";
                Bitmap image = new Bitmap(full_path);

                // Resize the image to fit within the console window dimensions.
                int width = 80;
                int height = 40;
                Bitmap resized = new Bitmap(image, new Size(width, height));

                // Characters used to represent different shades of gray.
                string asciiChars = "@#S%?*+;:,. ";

                // Loop through every pixel in the image (Height then Width).
                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        Color pixel = resized.GetPixel(x, y);

                        // Calculate the grayscale value (average of R, G, and B).
                        int gray = (pixel.R + pixel.G + pixel.B) / 3;

                        // Map the 0-255 brightness to our string of ASCII characters.
                        int index = (gray * (asciiChars.Length - 1)) / 255;

                        Console.Write(asciiChars[index]);
                    }
                    // Move to the next line after finishing a row of pixels.
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                // Fallback UI if the image processing fails.
                Console.WriteLine("**************************************");
                Console.WriteLine("* GUARDIO CYBERSECURITY BOT       *");
                Console.WriteLine("**************************************");
            }
        }
    }
}