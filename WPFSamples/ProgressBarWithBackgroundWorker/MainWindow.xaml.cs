using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressBarWithBackgroundWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker backgroundWorker;

        public MainWindow()
        {
            InitializeComponent();

            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.DoWork += BackgroundWorker_DoWork;
            this.backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            this.backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
        }

        void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //NOTE : Never play with the UI thread here.
            int length = Convert.ToInt32(e.Argument);
            int progressValue = 0; 
            while(progressValue < length)
            {
                Thread.Sleep(100);
                progressValue = progressValue + 10;
                backgroundWorker.ReportProgress(progressValue);
            }
        }

        void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here play with the main UI thread
            this.ProgressBar.Value = e.ProgressPercentage;
        }

        void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync(100);
        }
    }
}