using SensorPipeServerWpfOct14.Model;
using System;
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
        Led Led1, Led2, Led3, Led4, Led5, Led6, Led7 = null;
        TextBox[] inTxt = new TextBox[8];
        Ellipse[] led = new Ellipse[8];
        Led[] LedArray = new Led[8];
        string n { get; set; }
        HelpAboutWindow about = null;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //event registered in mainwindow.xaml
        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            initProcess();
        }
        
        //debug display autoscroll
        private void display_TextChanged(object sender, TextChangedEventArgs e)
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
          
            await SensorPipeClient.PipeClientAsync(n);
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

        //main sensor panel manual control button
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
            await SensorPipeClient.PipeClientAsync(n);
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
            //register debug textbox display event. Using event instead of databinding 
            EventUser eventMsg = new EventUser(display);
            //Expander Manual Input TextBox
            InputLedTxtBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            //Debug Mode Panel
            CtrlPtrnTxtBox.Text = "Led1     ON = 1,   OFF = 2" + "            Led5     ON = 9,    OFF = 10\n" + "Led2     ON = 3,   OFF = 4" + "            Led4     ON = 7,    OFF = 8\n" +
                                  "Led3     ON = 5,   OFF = 6" + "            Led6     ON = 11,  OFF = 12\n" +
                                  "\nUse odd numbers to turn ON any led.    Use even numbers to turn OFF.";

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
           // LedArray[7] = Led7 = new Led(ledServer, null, null); //for debug only
            LedArray[7] = Led7 = new Led(ledServer, inTxt1, btn1); //shared textbox output with led1 

            serverButton.IsEnabled = false;
        
            try
            {
                await StartUpPattern.startupCheckAsync4(LedArray);
                await StartUpPattern.startupCheckAsync3(LedArray);
                await SensorPipeServer.PipeServerAsync(LedArray);
            }
            catch (Exception ex)
            {
                statBar.Content = "Not Ready. There seems to be an error during startup.";
                MessageBox.Show(ex.Message, "ERROR!!!");
            }
        }

        private void Help_Menu_Click(object sender, RoutedEventArgs e)
        {
            about = new HelpAboutWindow("About SensorPipeServer App", "This is a simple Input/Output simulation tool. \n\nThis is a work in progress. \n\n-Ed Alegrid");
        }
 
        private void Settings_Menu_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Exit();
        }
        void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}

