using System;

namespace Euler
{
    public abstract class Problem
    {
        private bool _newLine = true;
        private DateTime timestamp;
        public abstract void Calculate();
        
        public void Print(object print, bool newLine = true)
        {
            if (newLine) {
                if (!_newLine) { 
                    Console.WriteLine();
                    _newLine = true;
                }
                Console.WriteLine(print);
            }
            else
            {
                Console.Write(print);
                _newLine = false;
            }
        }
        public void PrintTemp(object print)
        {
            Print(String.Format("\r{0}", print), false);
        }

        public void Start()
        {
            timestamp = DateTime.Now;
            Print(String.Format("Starting calculating {0}", this.GetType().Name));
        }

        public void Stop()
        {
            int miliseconds = Convert.ToInt32(DateTime.Now.TimeOfDay.TotalMilliseconds - timestamp.TimeOfDay.TotalMilliseconds);
            int seconds = miliseconds / 1000;
            if (miliseconds < 10000)
            { 
                Print(String.Format("Finished calculating after {0} miliseconds.", miliseconds));
            }
            else if (miliseconds < 600000)
            {
                Print(String.Format("Finished calculating after {0} seconds.", seconds));
            }
            else
            {
                Print(String.Format("Finished calculating after {0} minutes, {1} seconds.", seconds / 60, seconds % 60));
            }
        }

        public string[] ReadTextFile(string file = null, string location = null)
        {
            if (file == null) file = this.GetType().Name;
            if (location == null) location = String.Format(@"Files\{0}.txt", file);
            return System.IO.File.Exists(location) ? System.IO.File.ReadAllLines(location): new string[0];
        }
    }
}
