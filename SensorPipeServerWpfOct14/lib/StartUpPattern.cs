using System.Threading.Tasks;

namespace SensorPipeServerWpfOct14.Model
{
    class StartUpPattern
    {
        //pattern 1
        public static async Task startupCheckAsync(Led[] LedArray)
        {
            //Led1 will always have a 1 output in the textbox as the ledServer uses it as dummy variable. 
            await Task.Delay(150);
            LedArray[1].switchLED(1);
            await Task.Delay(150);
            LedArray[2].switchLED(1);
            await Task.Delay(150);
            LedArray[3].switchLED(1);
            await Task.Delay(150);
            LedArray[4].switchLED(1);
            await Task.Delay(150);
            LedArray[5].switchLED(1);
            await Task.Delay(150);
            LedArray[6].switchLED(1);
            await Task.Delay(150);
            LedArray[7].switchLED(0);
            await Task.Delay(250);
            LedArray[7].switchLED(1);
            await Task.Delay(150);
            LedArray[7].switchLED(0);
            await Task.Delay(250);
            LedArray[7].switchLED(1);
        }
        //pattern 2
        public static async Task startupCheckAsync2(Led[] LedArray)
        {
             //turning led on from Led1 to Led7
            await Task.Delay(150);
            LedArray[7].switchLED(0);
            await Task.Delay(150);
            LedArray[6].switchLED(0);
            await Task.Delay(150);
            LedArray[5].switchLED(0);
            await Task.Delay(150);
            LedArray[4].switchLED(0);
            await Task.Delay(150);
            LedArray[3].switchLED(0);
            await Task.Delay(150);
            LedArray[2].switchLED(0);
            await Task.Delay(150);
            LedArray[1].switchLED(0);
            await Task.Delay(250);
            LedArray[7].switchLED(1);
            await Task.Delay(150);
            LedArray[7].switchLED(0);
            await Task.Delay(250);
            LedArray[7].switchLED(1);
        }
        //pattern 3
        public static async Task startupCheckAsync3(Led[] LedArray)
        {
            //remember there is no Led0 or LedArray[0]!!!
            int timer = 50;
            for (int i = 7; i >= 1; i--)
            {
                await Task.Delay(timer);
                LedArray[i].switchLED(0);
            }
            for (int i = 1; i < 4; i++)
            {
                LedArray[7].switchLED(0);
                await Task.Delay(timer);
                LedArray[7].switchLED(1);
                await Task.Delay(timer);
            }
        }
        //pattern 4
        public static async Task startupCheckAsync4(Led[] LedArray)
        {
            //remember there is no Led0 or LedArray[0]!!!
            int timer = 50;
            for (int i = 1; i < 7; i++)
            {
                await Task.Delay(timer);
                LedArray[i].switchLED(1);
            }
        }
    }
}
