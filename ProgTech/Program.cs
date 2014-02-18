using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProgTech
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*using (System.IO.StreamWriter writer = new System.IO.StreamWriter("TestRates.txt"))
            {
                writer.WriteLine("January");
                Random rand = new Random();
                for (int i = 0; i < 30; i++)
                {
                    writer.WriteLine(25 + rand.NextDouble() * 15);
                    writer.WriteLine(35 + rand.NextDouble() * 20);
                    writer.WriteLine(20 + rand.NextDouble() * 15);
                }
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
