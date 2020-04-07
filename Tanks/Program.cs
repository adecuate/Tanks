using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Cybele.Thinfinity.VirtualUI().Start();
           // Controller_MainForm cm;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           /* switch (arg.Length)
            {
                case 0: cm = new Controller_MainForm(); break;
                case 1: cm = new Controller_MainForm(Convert.ToInt32(arg[0])); break;
                case 2: cm = new Controller_MainForm(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1])); break;
                case 3: cm = new Controller_MainForm(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2])); break;
                case 4: cm = new Controller_MainForm(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2]), Convert.ToInt32(arg[3])); break;
                default: cm = new Controller_MainForm(); break;
            }*/

            Application.Run(new Controller_MainForm());
        }
    }
}
