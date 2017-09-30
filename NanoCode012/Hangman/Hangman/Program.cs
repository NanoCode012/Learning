using System;
using System.Text;
using System.Collections.Generic;

namespace Hangman
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region list
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
            #endregion

            //Declaraction
            var index = new Random().Next(0, list.Count);
            var word = new StringBuilder(list[index]);
            var spots = new StringBuilder("");
            var lives = 3;
            var nonDuplicateList = new List<string>();
			ChangeCharsToHyphens(word, spots);

            Console.WriteLine("==========================================");

            //Lives control
            Console.WriteLine("Please choose how many one-digit extra lives you want(default is 3): ");
            var tempLivesString = Console.ReadLine();
            lives = ValidateSetLives(lives, tempLivesString);

            //MainGame
            Console.WriteLine("Guess my word!! : {0} with {1} extra lives left", spots, lives);
            while (spots.ToString().Contains("_") && lives >= 0)
            {
                string pressedLetter = GetGuessedLetter(nonDuplicateList);
                if (word.ToString().Contains(pressedLetter))
                {
                    Console.WriteLine("You got one!");
                    ReplaceWordWithZero(word, spots, pressedLetter);
                    AddNonDupeToList(word, nonDuplicateList, pressedLetter);
                }
                else
                {
                    nonDuplicateList.Add(pressedLetter);
                    lives--;
                    if (lives < 0) break;
					Console.WriteLine("Oops. That's not right... You have {0} extra lives left", lives);
					continue;
                }
                Console.WriteLine("So far you've got : {0} with {1} extra lives left", spots, lives);
            }
            LastWords(spots, lives);
        }

        static void ReplaceWordWithZero(StringBuilder word, StringBuilder spots, string pressedLetter)
        {
            var tempIndex = word.ToString().IndexOf(pressedLetter, StringComparison.Ordinal);
            word[tempIndex] = '0';
            spots[tempIndex] = Convert.ToChar(pressedLetter);
        }

        static void AddNonDupeToList(StringBuilder word, List<string> nonDuplicateList, string pressedLetter)
        {
            if (!word.ToString().Contains(pressedLetter))
            {
                nonDuplicateList.Add(pressedLetter);
            }
        }

        static string GetGuessedLetter(List<string> nonDuplicateList)
        {
            var pressedLetter = "";
            while (true)//defense against more than one char pressed
            {
                Console.WriteLine("Please pick a letter.");
                pressedLetter = Console.ReadLine().ToLower();//defense against CAPS
                if (ValidateInput(pressedLetter, nonDuplicateList)) break;
            }

            return pressedLetter;
        }

        static bool ValidateInput(string pressedLetter, List<string> nonDupeList)
		{
			var check = false;
			if (pressedLetter.Length != 1)
			{
				Console.WriteLine("Error. Please enter only one character. Try again!");
			}
			else if ((Convert.ToChar(pressedLetter)) < 'a' || (Convert.ToChar(pressedLetter)) > 'z')//only allow a-z
			{
				Console.WriteLine("Error. Please enter only alphabetical character. Do it again!");
			}
			else if (nonDupeList.Contains(pressedLetter))
			{
				Console.WriteLine("You've already picked that number. Pick another instead!");
			}
			else
			{
				check = true;
			}
			return check;
		}

        static int ValidateSetLives(int lives, string tempLivesString)
        {
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

            return lives;
        }

        static void ChangeCharsToHyphens(StringBuilder word, StringBuilder spots)
        {
            for (var i = 0; i < word.Length; i++)
            {
                spots.Append("_");
            }
        }

        static void LastWords(StringBuilder spots, int lives)
        {
            Console.WriteLine();
            if (lives >= 0)
            {
                Console.WriteLine("Congrats you beat this game! The word was {0}! Hurray!", spots);
            }
            else
            {
                Console.WriteLine("Bad game? Try again. Reopen app");
            }
        }
    }
}
