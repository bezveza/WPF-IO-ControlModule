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
using System.Windows.Shapes;

namespace SensorPipeServerWpfOct14.Model
{
    /// <summary>
    /// Interaction logic for HelpAboutWindow.xaml
    /// </summary>
    public partial class HelpAboutWindow : Window
    {
        public HelpAboutWindow(string t, string s)
        {
            InitializeComponent();
            this.Title = t;

            aboutBox.AppendText(s);
            aboutBox.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            aboutBox.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //attempt to close the Window 
                this.Close();
                // if (MainWindow.cs != null)
                // MainWindow.cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
