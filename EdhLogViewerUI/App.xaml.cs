using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace EdhLogViewerUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private ProcessLogViewModel dc;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            dc = new ProcessLogViewModel();

            var mw = new MainWindow(dc);

            mw.Show();
        }
    }
}