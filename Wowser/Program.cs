using System;
using System.Windows.Forms;
using CefDriver;
using Serilog;

namespace Wowser
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("wowser.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var url = args.Length > 0 ? args[0] : "about:blank";
            var form = new MainForm(url, logger) { BlockImages = false };
            Application.Run(form);
        }
    }
}
