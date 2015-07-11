using SensorPipeServerWpfOct14.Model;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SensorPipeServerWpfOct14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Led Led1, Led2, Led3, Led4, Led5, Led6 = null;
        TextBox[] inTxt = new TextBox[8];
        Ellipse[] led = new Ellipse[8];
        Led[] LedArray = new Led[8];
        string m { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //event registered in mainwindow.xaml
        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            try
            {
                initProcess();
            }
            catch (Exception ex)
            {
                Data.Source.Msg("Error : " + ex.Message);
            }

            statBar.Content = "Ready";
                       
        }
        
        private void display_TextChanged(object sender, TextChangedEventArgs e) //event registered in mainwindow.xaml
        {
            display.ScrollToEnd();
        }
        //debug mode panel start server
        private void serverButton_Click(object sender, RoutedEventArgs e)
        {
            serverButton.IsEnabled = false;
        }
        //debug mode panel manual on/off trigger
        private async  void clientButton_Click(object sender, RoutedEventArgs e)
        {
            await SensorPipeClient.PipeClientAsync(m);
        }
        //disable button for each led module 1 to 6
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            LedArray[1].disableLED(0);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            LedArray[2].disableLED(0);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
             LedArray[3].disableLED(0);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            LedArray[4].disableLED(0);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
             LedArray[5].disableLED(0);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            LedArray[6].disableLED(0);
        }
        //main sensor panel manual button
        private void ManualBtn_Click(object sender, RoutedEventArgs e)
        {
            var inputLed = InputLedTxtBox.Text;
            int num = 0;
            var errorMsg =  "Enter int  1 to 12  only";
            try
            {
                num = int.Parse(inputLed);
                if ( num < 1 || num > 12) { InputLedTxtBox.Text = errorMsg; }
            }
            
            catch //catch all inputs that are not integer
            {
                InputLedTxtBox.Text = errorMsg;
            }

            LedModule.ledControl(num, LedArray);
            
        }
        //main sensor panel random led on/off trigger
        private async void RandomBtn_Click(object sender, RoutedEventArgs e)
        {
            await SensorPipeClient.PipeClientAsync(m);
        }
        //main sensor panel "manual input" expander textbox focus event
        private void InputLedTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InputLedTxtBox.Text = "";
        }
        //main sensor panel "control pattern" expander textbox expanded event (should be synchronized with manual input)
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            CtrlPtrn.IsExpanded = true;
        }

        //initialization, object element creation, prop settings, etc.
        private async void initProcess()
        {
            //register event textbox display
            EventUser eventMsg = new EventUser(display);
            //Expander Manual Input TextBox
            InputLedTxtBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            //Debug Mode Panel
            CtrlPtrnTxtBox.Text = "Led1     ON = 1,   OFF = 2" + "            Led5     ON = 9,    OFF = 10\n" + "Led2     ON = 3,   OFF = 4" + "            Led4     ON = 7,    OFF = 8\n" +
                                  "Led3     ON = 5,   OFF = 6" + "            Led6     ON = 11,  OFF = 12\n";

            display.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            display.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            display.IsReadOnly = true;


            led[1] = led1; led[2] = led2; led[3] = led3; led[4] = led4; led[5] = led5; led[6] = led6; led[7] = ledServer;

            LedArray[1] = Led1 = new Led(led1, inTxt1, btn1);
            LedArray[2] = Led2 = new Led(led2, inTxt2, btn2);
            LedArray[3] = Led3 = new Led(led3, inTxt3, btn3);
            LedArray[4] = Led4 = new Led(led4, inTxt4, btn4);
            LedArray[5] = Led5 = new Led(led5, inTxt5, btn5);
            LedArray[6] = Led6 = new Led(led6, inTxt6, btn6);

            serverButton.IsEnabled = false;

            await SensorPipeServer.PipeServerAsync(led, LedArray);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var ab = new HelpAboutWindow("About Test App", "This is an Input/Output simulation tool used for digital control systems. This is a work in progress.");
        }
    }
}

