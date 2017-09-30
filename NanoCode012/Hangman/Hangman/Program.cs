using System;
using System.Text;
using System.Collections.Generic;

namespace Hangman
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var list = new List<string>
            {
                "happy",
                "tired",
                "bear",
                "tiger",
                "beautiful",
                "bottle",
                "charger",
                "emotion",
                "drawers",
                "pillow",
                "queen",
                "eat",
                "schedule",
                "avocado",
                "durian",
                "lychee"
            };

            var random = new Random();
            var index = random.Next(0, list.Count);
            var word = new StringBuilder(list[index]);
            var wordLength = word.Length;
            var spots = new StringBuilder("");
            var lives = 3;
            for (var i = 0; i < wordLength; i++)
            {
                spots.Append("_"); 
            }

            Console.WriteLine("===============================");
            //Lives control
            Console.WriteLine("Please choose how many one-digit extra lives you want(default is 3): ");
            var tempLivesString = Console.ReadLine();
            if (tempLivesString.Length == 1 && int.TryParse(tempLivesString, out int tempLivesInteger)) 
            {
                if (tempLivesInteger == 0)
                {
                    Console.WriteLine("So Daring!! You can't make any mistake!");
                }
				lives = tempLivesInteger;
            }
            else
            {
                Console.WriteLine("You entered an invalid value. Lives set to default.");
            }

            //MainGame
			Console.WriteLine("Guess my word!! : {0} with {1} extra lives left",spots, lives);
            while (spots.ToString().Contains("_") && lives >= 0)
            {            
				var pressedLetter = "";
				while(true)//defense against more than one char pressed
				{
					Console.WriteLine("Please pick a letter.");
                    pressedLetter = Console.ReadLine().ToLower();//todo check if pressed before//cannot do this as it will 
                                                                //clash with duplicate characters method below
                    if (pressedLetter.Length != 1 )
                    {
                        Console.WriteLine("Error. Please enter only one character. Try again!");
                    }else if ((Convert.ToChar(pressedLetter)) < 'a' ||  (Convert.ToChar(pressedLetter)) > 'z')//only allow a-z
                    {
                        Console.WriteLine("Error. Please enter only alphabetical character. Do it again!");
                    }else
                    {
						break;
                    }
				}

				if (word.ToString().Contains(pressedLetter))
				{
                    Console.WriteLine("You got one!");
                    var tempIndex = word.ToString().IndexOf(pressedLetter, StringComparison.Ordinal);
                    word[tempIndex] = '0';
                    spots[tempIndex] = Convert.ToChar(pressedLetter);

                }else {
                    lives--;
                    if (lives < 0) break;
					Console.WriteLine("oops. That's not right... You have {0} extra lives left",lives);
                    continue;
				}
                Console.WriteLine("So far you got : {0} with {1} extra lives left",spots,lives);
            }
            if (lives > 0)
            {
				Console.WriteLine("Congrats you beat this game!");
            }else
            {
                Console.WriteLine("Bad game? Try again. Reopen app");
            }


        }
    }
}
