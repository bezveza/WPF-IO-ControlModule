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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
