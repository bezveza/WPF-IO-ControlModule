using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SensorPipeServerWpfOct14
{
    public class Led
    {
        bool IsDisableLEDSwitchON = true;

        SolidColorBrush ledON = null; //yellow
        SolidColorBrush ledOFF = null; //grey, this is to show that the led was turn off instead of just the default no color
        Ellipse led = null;
        TextBox inTxt = null;
        Button btn = null;

        public Led(Ellipse led, TextBox inTxt, Button btn)
        {
            ledON = new SolidColorBrush();
            ledON.Color = Color.FromArgb(255, 255, 255, 0);  // ON Yellow
            ledOFF = new SolidColorBrush();
            ledOFF.Color = Color.FromArgb(100, 171, 153, 153);  //OFF No Color

            this.led = led;
            this.inTxt = inTxt;
            this.btn = btn;
        }

        //method to turn the led ON/OFF
        public int switchLED(int x)
        {
            //Note: Check led.IsEnabled is set to true in XAML. Should be set to true, by default it is set to false.  
            if (led.IsEnabled == true && x == 1)
            {
                led.Fill = ledON;
                inTxt.Text = "1";
            }
            if (led.IsEnabled == true && x == 0)
            {
                led.Fill = ledOFF;
                inTxt.Text = "0";
            }
            return x;
        }

        //disable a specific led module, acts like a toggle switch 
        public bool disableLED(int x)
        {
            if (IsDisableLEDSwitchON == true && x == 0)
            {
                this.switchLED(0);
                led.IsEnabled = false;
                btn.Content = "OFF";
                inTxt.Text = "OFF";
                inTxt.IsEnabled = false;
                IsDisableLEDSwitchON = false;
            }
            else //if (x == 1)
            {
                this.switchLED(1);
                led.IsEnabled = true;
                btn.Content = "ON";
                inTxt.IsEnabled = true;
                inTxt.Text = "";
                IsDisableLEDSwitchON = true;
            }

            if (x == 0)
                return true;
            else
                return false;
        }
    }
}
