using System;
using System.Windows.Forms;

namespace AnketaStudenta
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Обработка необработанных исключений
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show($"Необработанное исключение:\n{e.Exception.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                MessageBox.Show($"Критическая ошибка:\n{(e.ExceptionObject as Exception)?.Message}",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            
            Application.Run(new MainForm());
        }
    }
}