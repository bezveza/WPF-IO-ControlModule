using System;
using System.Windows;

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
