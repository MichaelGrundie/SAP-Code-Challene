using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPQuiz
{
    class rules
    {
        private char[] availableColors = { 'y', 'g', 'b', 'r' };
        private int[] ygbrQuantity = { 0, 0, 0, 0 };


        //Implements rule 1.
        public int rule1(char[] playerColors)
        {
            //Resets ygbrQuantity.
            for (int i = 0; i < 4; i++)
            {
                ygbrQuantity[i] = 0;
            }

            separateColors(playerColors);
            return getScore();

        }


        //Counts the number or red, green, yellow, and blue tokens.
        private void separateColors(char[] playerColors)
        {
            //Loops through letters to compare.
            for (int i = 0; i < availableColors.Length; i++)
            {
                //Loops through the players colors.
                for (int j = 0; j < playerColors.Length; j++)
                {
                    // Compares the chars.
                    if (playerColors[j].Equals(availableColors[i]))
                    {
                        ygbrQuantity[i]++;
                    }
                }
            }


        }


        //Returns a points value for each match combination.
        private int getScore()
        {
            //Score will represent the value of the players color match combination.
            int score = 0;

            //Loops through the ygbtQuantity array. Assigns a score for each combination.
            for (int j = 0; j < ygbrQuantity.Length; j++)
            {
                //3 of a kind gets 3 points.
                if (ygbrQuantity[j] == 3)
                {
                    score = 3;
                    break;
                }

                //2 of a kind gets 1 point unless there is another pair.
                else if (ygbrQuantity[j] == 2)
                {
                    score = 1;

                    //Checks the remaining tokens for a pair.
                    for (int k = j + 1; k < ygbrQuantity.Length; k++)
                    {
                        //2 pairs gets 2 points.
                        if (ygbrQuantity[k] == 2)//
                        {
                            score = 2;

                        }
                    }
                    break;
                }
                //4 of a kind gets 4 points.
                else if (ygbrQuantity[j] == 4)
                {
                    score = 4;
                    break;
                }
            }
            return score;
        }


        //returns the produt of the player's drawn numbers.
        public int rule2(int[] playerNumbers)
        {
            int product = 1;

            //Loops through the player's token numbers.
            for (int i = 0; i < playerNumbers.Length; i++)
            {
                //Multiplys the current product value by the value of the current token.
                product = product * playerNumbers[i];
            }
            return product;
        }


        //Checks each of the player's tokens and assigns a pints value.
        public int rule3(int[] playerNumbers, char[] playerColors)
        {
            //Stores the highest points value.
            int score = 0;

            //Loops through both arrays
            for (int i = 0; i < 4; i++)
            {
                //Stores the points value of the current token.
                int tokenNumber = 0;

                //Checks the current tokens color and number and uses them to assign points.
                switch (playerColors[i])
                {
                    case 'r':
                        tokenNumber = playerNumbers[i];
                        break;
                    case 'g':
                        tokenNumber = 16 + playerNumbers[i];
                        break;
                    case 'b':
                        tokenNumber = 32 + playerNumbers[i];
                        break;
                    case 'y':
                        tokenNumber = 48 + playerNumbers[i];
                        break;
                }

                //If the current token's points value is more than the current round's
                //highest value, the new highest points value is stored.
                if (tokenNumber > score)
                {
                    score = tokenNumber;
                }
            }

            return score;
        }
    }

}
