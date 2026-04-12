using System;
using System.Media; // Required for SoundPlayer

namespace Part1
{
    // This class handles the multimedia aspect of the voice greeting.
    public class voice
    {
        // Get the directory where the app is running.
        string path = AppDomain.CurrentDomain.BaseDirectory;

        public voice()
        {
            // Automatically trigger the voice method on creation.
            greetvoice();
        }

        private void greetvoice()
        {
            try
            {
                // Adjust the path to locate the 'voice.wav' in the root project folder.
                string fullpath = path.Replace(@"bin\Debug\", "");
                string joined_path = fullpath + "voice.wav";

                // Initialize the SoundPlayer with the file path.
                SoundPlayer play_voice = new SoundPlayer(joined_path);
                play_voice.Load();
                
                // Play() allows the program to continue running while the sound plays.
                play_voice.Play(); 
            }
            catch (Exception )
            {
                // Graceful handling if the file is missing or blocked.
                Console.WriteLine("System Note: Audio greeting unavailable.");
            }
        }
    }
}