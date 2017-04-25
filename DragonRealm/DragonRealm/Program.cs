using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DragonRealm
{
    
    static class Program
    {       
        static string GetName()
        {
            WriteLine("Hello Player. What´s is your name ?");
            return ReadLine();
        }
        static void DisplayIntro(string name)
        {
            WriteLine($"Hello {name} you are in the DRAGON REALM and the cave is very SCARY !!!.....");
        }        

        static int ChooseCave()
        {
            int val = 0;
            char key = ' ';
                        
                WriteLine("The dragon is hungry and eats you up in one of the Caves.");
                WriteLine("You are between 2 SCARY Caves choose one of these. (1/2) ?");
                            

            while (key != '1' && key != '2')
            {
                key = (ReadLine()[0]);
                if (key != '1' && key != '2')
                    WriteLine("You must choose between 1 and 2.");

            }
            val = (int)(key -'0');

            return val;
        }

        static bool CheckCave(int playercave)
        {
            Random dragon = new Random();
            bool ok = false;

            int dragonCave = dragon.Next(1, 3);
            // WriteLine($"{ dragonCave}");

            if(playercave == dragonCave)
            {
                WriteLine("Dragon took you and ate you up in at once. You are dead.");
            }
            else
            {
                WriteLine("No Dragon here. You are ALIVE... Continue ...");
                ok = true;
            }
            return ok;
        }

        static void Main(string[] args)
        {
            string playerName = GetName();
            int cave;
            bool isAlive = true;
            bool playAgain = true;
            int numLive;            

            do
            {
                // Show intro.
                Clear();

                DisplayIntro(playerName);
                numLive = 3;

                do
                {
                    cave = ChooseCave();
                    isAlive = CheckCave(cave);

                    if(!isAlive )
                    {
                        
                        numLive--;
                        if(numLive == 0)
                        {
                            WriteLine("You are Dead!!");
                        } else
                        {
                            WriteLine($"You loose one lives and now you have {numLive} lifes left !");
                        }
                    }

                } while (numLive > 0);

                WriteLine("Do you want to play again? (Y/N) ?");
                string answer = ReadLine();
                playAgain = (answer.ToUpper() == "Y") ? true : false;

            } while (playAgain);

            WriteLine($"You will miss us. Bye, {playerName} hope to see you soon. ");

            ReadKey();
        }
    }
}
