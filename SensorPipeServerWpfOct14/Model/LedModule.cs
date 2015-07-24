
namespace SensorPipeServerWpfOct14
{
   //class module for led on/off state
   public class LedModule
   {
       public static int ledControl(int n, Led [] LedArray)
       {
           string s = n.ToString();
           
           switch (n)
           {
               case 1:
                   LedArray[1].switchLED(1);
                   break;
               case 2:
                   LedArray[1].switchLED(0);
                   break;
               case 3:
                   LedArray[2].switchLED(1);
                   break;
               case 4:
                   LedArray[2].switchLED(0);
                   break;
               case 5:
                   LedArray[3].switchLED(1);
                   break;
               case 6:
                   LedArray[3].switchLED(0);
                   break;
               case 7:
                   LedArray[4].switchLED(1);
                   break;
               case 8:
                   LedArray[4].switchLED(0);
                   break;
               case 9:
                   LedArray[5].switchLED(1);
                   break;
               case 10:
                   LedArray[5].switchLED(0);
                   break;
               case 11:
                   LedArray[6].switchLED(1);
                   break;
               case 12:
                   LedArray[6].switchLED(0);
                   break;
           }
           return n;
       }
   }
}
