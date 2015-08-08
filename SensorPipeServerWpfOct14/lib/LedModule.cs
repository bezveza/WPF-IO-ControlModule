using LedSystemLib;
namespace SensorPipeServerWpfOct14
{
   //class module to control the led according to a certain pattern
    //You can create your own pattern if you like

    /* Using a simple integer pattern
     Led1   ON = 1,  OFF = 2
     Led2   ON = 3,  OFF = 4
     Led3   ON = 5,  OFF = 6
     Led4   ON = 7,  OFF = 8
     Led5   ON = 9,  OFF = 10 
     Led6   ON = 11, OFF = 12
    */

    //method to accept the above pattern  
    public class LedModule
   {
       public static int ledControl(int n, Led [] LedArray)
       {
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
               case 13:
                   LedArray[7].switchLED(1);
                   break;
               case 14:
                   LedArray[7].switchLED(0);
                   break;
           }
           return n;
       }
   }
}
