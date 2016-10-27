using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPQuiz
{
    class stringSeparator
    {

        /*Strips the numbers out of the string and returns a char array containing the strings letters*/
        public char[] colors(string processString)
        {
            //Stores the color of each token.
            char[] playerColors = new char[4];
            int loop = 0;
            int arrayPos = 0;

            //loops through the player results string. (processString)
            while (loop < processString.Length)
            {
                //Checks that each char is neither an integer or a space.
                if (char.GetNumericValue(processString[loop]) < 0 && processString[loop] != ' ')                                                                               
                {
                    //Stores the letter at the correct index.
                    playerColors[arrayPos] = processString[loop];
                    arrayPos++;
                }
                loop++;
            }
            return playerColors;
        }


        //Removes spaces and non-numerical characters. Stores intigers in an array.
        public int[] numbers(string processString)
        {
            //Stores the token numbers.
            int[] playerNumbers = new int[4];
            int arrayIndex = 0;

            //Loops through player results string.
            for (int i = 0; i < processString.Length; i++)
            {
                //Checks each char is an intiger.
                if (Char.GetNumericValue(processString[i]) >= 0)
                {
                    //temporarily stores the intiger as a string.
                    string number = processString[i].ToString();

                    //Stops out of bounds exception.
                    if (i < processString.Length - 1)
                    {
                        //Moves to the next index of processString (To check for double digits.)
                        i++;

                        //Checks if the next char is a number and concatinates it onto number sting.
                        if (Char.GetNumericValue(processString[i]) >= 0)
                        {                                               
                            number = number + processString[i].ToString();
                        }
                    }

                    //Converts number string to in and stores it at the correct array index.
                    playerNumbers[arrayIndex] = Convert.ToInt32(number);
                    arrayIndex++;
                }
            }
            return playerNumbers;
        }

    }
}
