using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MouseSS
{
    public class Exec : Form
    {
        public Exec() { }

        public void Start()
        {
            Console.WriteLine("How many minutes to wait?");
            string minutesToWait = Console.ReadLine();
            Console.WriteLine("How many hours to run?");
            string hoursToRun = Console.ReadLine();

            int minutes;
            if (int.TryParse(minutesToWait, out minutes))
            {
                if ((minutes * 60 * 1000) < int.MaxValue)
                {
                    int millisecondsToWait = minutes * 60 * 1000;
                    double hours;
                    if (double.TryParse(hoursToRun, out hours))
                    {
                        long current = DateTime.Now.Ticks;
                        long stop = DateTime.Now.AddHours(hours).Ticks;
                        while (current < stop)
                        {
                            Thread.Sleep(millisecondsToWait);
                            MoveCursorUp();
                            Thread.Sleep(millisecondsToWait);
                            MoveCursorDown();
                            current = DateTime.Now.Ticks;
                        }
                    }
                }
            }
            Console.WriteLine("exiting...");
        }

        /// <summary>
        /// Move Cursor Up
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.cursor.position?redirectedfrom=MSDN&view=netcore-3.1#System_Windows_Forms_Cursor_Position"/>
        /// </summary>
        private void MoveCursorUp()
        {
            Cursor = new Cursor(Cursor.Current.Handle);
            Point currentposition = Cursor.Position;
            Cursor.Position = new Point(currentposition.X - 1, currentposition.Y - 1);
        }

        /// <summary>
        /// Move Cursor Down
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.cursor.position?redirectedfrom=MSDN&view=netcore-3.1#System_Windows_Forms_Cursor_Position"/>
        /// </summary>
        private void MoveCursorDown()
        {
            Cursor = new Cursor(Cursor.Current.Handle);
            Point currentposition = Cursor.Position;
            Cursor.Position = new Point(currentposition.X + 1, currentposition.Y + 1);            
        }
    }
}
