using System;
using System.Text;
using System.Collections.Generic;

namespace Hangman
{
    class MainClass
    {
        static List<String> list = new List<String> {
            "happy", "tired", "bear", "tiger",
            "beautiful", "bottle",  "charger",
            "emotion", "drawers", "pillow",
            "queen", "eat", "schedule", "avocado",
            "durian", "lychee"
        };

        public static void Main(string[] args)
        {
            do {
                GameLoop();
            } while (true);
        }

        public static void GameLoop()
        {
            // Get random words
            var random = new Random();
            var index = random.Next(0, list.Count);
            var word = new StringBuilder(list[index]);
            var spots = new StringBuilder(new string('_', word.Length));

            var lives = GetLive();
            Console.WriteLine("Guess my word!! : {0} with {1} extra lives left", spots, lives);

            while (--lives >= 0) {
                var guessed = GetGuessedLetter();
                var count = ReplaceGuessedLetter(spots, word, guessed);

                // Does the user guess it right or wrong?
                if (count > 0)  {
                    Console.WriteLine("You got one!");
                } else {
                    Console.WriteLine("oops. That's not right... You have {0} extra lives left", lives);
                }

                // User has guess all the letters!
                if (word.ToString() == spots.ToString()) break;

                Console.WriteLine("So far you got : {0} with {1} extra lives left", spots, lives);
            }

            if (word.ToString() == spots.ToString()) {
                Console.WriteLine("Congrats you beat this game!");
            }  else {
                Console.WriteLine("Bad game? Try again. Reopen app");
            }
        }

        public static char GetGuessedLetter()
        {
            var x = " ";
            while (true) {
                Console.WriteLine("Please pick a letter.");
                x = Console.ReadLine().ToLower();
                if (x.Length != 1)
                    Console.WriteLine("Error. Please enter only one character. Try again!");
                else if ((Convert.ToChar(x)) < 'a' || (Convert.ToChar(x)) > 'z')
                    Console.WriteLine("Error. Please enter only alphabetical character. Do it again!");
                else break;
            }
            return x[0];
        }

        public static int GetLive(int def = 3)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Please choose how many extra lives you want(default is 3): ");

            if (int.TryParse(Console.ReadLine(), out int tempLivesInteger)) {
                if (tempLivesInteger == 0) Console.WriteLine("So Daring!! You can't make any mistake!");
                return tempLivesInteger;
            } else {
                Console.WriteLine("You entered an invalid value. Lives set to default.");
            }

            return def;
        }

        public static int ReplaceGuessedLetter(StringBuilder chars, StringBuilder word, char guessed)
        {
            int count = 0;
            for (int i = 0; i < chars.Length; i++) {
                if (word[i] == guessed) {
                    chars[i] = word[i]; count++;
                }
            }

            return count;
        }
    }
}
