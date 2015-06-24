using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SensorPipeServerWpfOct14
{
    //led visual on/off control
    public class Led
    {
        //bool IsDisableLEDSwitchON { get; set; }
        bool IsDisableLEDSwitchON = true;
        SolidColorBrush ledON = null;
        SolidColorBrush ledOFF = null;

        Ellipse led = null;
        TextBox inTxt = null;
        Button btn = null;
        //Label ledlbl = null;


        public Led(Ellipse led, TextBox inTxt, Button btn /*, Label ledlbl*/)
        {
            ledON = new SolidColorBrush();
            ledON.Color = Color.FromArgb(255, 255, 255, 0);  // ON Yellow
            ledOFF = new SolidColorBrush();
            ledOFF.Color = Color.FromArgb(100, 171, 153, 153);  //OFF No Color

            this.led = led;
            this.inTxt = inTxt;
            this.btn = btn;
            //this.ledlbl = ledlbl;
        }

        public int switchLED( /*Ellipse led, */int x)
        {
            if (led.IsEnabled == true && x == 1)
            {
                led.Fill = ledON;
                inTxt.Text = "1";
                //ledlbl.Content = "LED1 is On";
            }
            if (led.IsEnabled == true && x == 0)
            {
                led.Fill = ledOFF;
                inTxt.Text = "0";
                //ledlbl.Content = "LED1 is Off";
            }
            return x;
        }

        public bool disableLED(/*Ellipse led, */int x) //toggle switch
        {
            if (IsDisableLEDSwitchON == true && x == 0)
            {
                this.switchLED(0);
                led.IsEnabled = false;
                btn.Content = "OFF";
                inTxt.Text = "OFF";
                inTxt.IsEnabled = false;
                //led.IsEnabled = false;
                //btn.Content = "OFF";
                //ledlbl.Content = "Disabled";
                IsDisableLEDSwitchON = false;
            }
            else //if (x == 1)
            {
                this.switchLED(1);
                led.IsEnabled = true;
                btn.Content = "ON";
                inTxt.IsEnabled = true;
                inTxt.Text = "";
                //ledlbl.Content = "Enabled";
                IsDisableLEDSwitchON = true;
            }

            if (x == 0)
                return true;
            else
                return false;
        }

    }
}
