using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar1.Maximum = 4000;
            for (int i = 0; i < 100000; i++)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    this.ProgressBar1.Value = i;
                }),
                System.Windows.Threading.DispatcherPriority.Background);
            }
        }
    }
}
