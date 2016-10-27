using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SAPQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string quit = "t";
            while (quit != "q")
            {

                //Stores the winner of each round as a 0 or 1.
                string binary = "";

                //Reads the results text file.
                FileStream fileStream = new FileStream(@"roundWinners.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    //Stores the current line as a string.
                    string line;

                    //Loops through each line of the text file.
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //Store's each player's half of the result line.
                        string player1 = "", player2 = "";
                        int lineIndex = 0;

                        //Checks each char of the line string. All characters before colon
                        //are concatinated onto player1 string.
                        while (line[lineIndex] != ':')
                        {
                            player1 = player1 + line[lineIndex];
                            lineIndex++;
                        }

                        //Skips past the colon.
                        lineIndex++;

                        //All characters after the colon are concatinated onto player2 string.
                        while (lineIndex < line.Length)
                        {
                            player2 = player2 + line[lineIndex];
                            lineIndex++;
                        }

                        int roundWinner = 0;
                        int ruleToCheck = 1;

                        //Loops through each rule passing in each of the player's results strings.
                        //Quits if there is a winner.
                        while (roundWinner < 1)
                        {
                            roundWinner = checkRuleWinner(player1, player2, ruleToCheck);
                            ruleToCheck++;
                        }

                        //Player 1 win concaticates a '0' onto the binary string.
                        if (roundWinner == 1)
                        {

                            binary = binary + "0";
                        }
                        //Player 2 win concatinates a '1' onto the binary string.
                        else if (roundWinner == 2)
                        {
                            binary = binary + "1";
                        }
                    }
                }

                //Stores the resulting ASCII text string.
                string result = "";

                //Loops through binary string.
                while (binary.Length > 0)
                {
                    //Gets the first 8 characters of binary string.
                    string first8 = binary.Substring(0, 8);

                    //Cuts the first 8 charachters from binary string.
                    binary = binary.Substring(8);

                    //Converts the binary number to int.
                    int number = Convert.ToInt32(first8, 2);

                    //Casts the interger and uses its value as the decimal ASCII code for the character.
                    //The character is concatinated onto the result string.
                    result += (char)number;
                }

                //The secret message is printed to the console
                Console.Write(result + "\n\nTo quit type 'q' and press return: ");

                quit = Console.ReadLine();
            }
        }


        //Checks each player's results string against the rule number (Passed in at the call point).
        private static int checkRuleWinner(string p1, string p2, int ruleToCheck)
        {
            //Stores the round winner, 0 means no winner.
            int winner = 0;

            //Stores each player's round score
            int p1Score, p2Score;
            stringSeparator teststring = new stringSeparator();
            rules rule = new rules();

            switch (ruleToCheck)
            {
                //Separates the player's string into color letters and checks the 
                //resulting array against rule 1.
                case 1:
                    p1Score = rule.rule1(teststring.colors(p1));
                    p2Score = rule.rule1(teststring.colors(p2));
                    break;

                //Separates the player's string into token numbers and checks the 
                //resulting array against rule 2.   
                case 2:
                    p1Score = rule.rule2(teststring.numbers(p1));
                    p2Score = rule.rule2(teststring.numbers(p2));
                    break;

                //Separates the player's string into color letters and token numbers then 
                //checks the resulting 2 arrays against rule 3.
                default:
                    p1Score = rule.rule3(teststring.numbers(p1), teststring.colors(p1));
                    p2Score = rule.rule3(teststring.numbers(p2), teststring.colors(p2));
                    break;
            }

            //The player with the highest round score is stored.
            if (p1Score > p2Score)
            {
                winner = 1;
            }
            else if (p2Score > p1Score)
            {
                winner = 2;
            }

            return winner;
        }
    }


}

