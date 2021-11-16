using System;
using System.Diagnostics;
using System.Threading;


namespace Examen_AnderGaona
{
    class Program
    {
        static int time = 0;
        static void Main(string[] args)
        {
            //Ejer 1
            Console.WriteLine("Abriendo Chrome...");
            Thread.Sleep(1000);
            Process.Start(@"‪C:\Program Files\Google\Chrome\Application\chrome.exe");
            Console.WriteLine("Chrome Abierto");

            //Ejer2
            int i = 0;
            while (i < 5)
            {
                time += 1000;
                var th = new Thread(ExecuteInForeground);
                Thread.Sleep(time);
                th.Start();
                i++;
            }
        }

        private static void ExecuteInForeground()
        {
            
            var sw = Stopwatch.StartNew();
            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(1000);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }
    }
}
