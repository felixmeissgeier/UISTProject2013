using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    class PrintObject
    {
        int horizontalDim = 24;
        int verticalDim = 24;
        public string Txt;
        public bool[,] PrintArray;
        public int lastVerticalLine;

        public bool generatePrintArray()
        {
            bool generatingSuccessful = true;
            PrintArray = new bool[horizontalDim, verticalDim];

            char[] letters = Txt.ToCharArray();

            int currentHorizontalPosition = 0;
            int currentVerticalPosition = 0;
            List<char> lineLetters = new List<char>();

            if (Txt.Equals("[HOMER]"))
            {
                bool[,] printArrayToWrite = PrintLetterDictionary.Homer;
                for (int x = 0; x < printArrayToWrite.GetLength(1); x++)
                {
                    for (int y = 0; y < printArrayToWrite.GetLength(0); y++)
                    {
                        PrintArray[x + 2, y] = printArrayToWrite[y, x];
                    }
                }
                lastVerticalLine = 23;
            }
            else
            {
                int textAndImageIndex = Txt.IndexOf("[");
                
                //check for [
                for (int i = 0; i < letters.Length; i++)
                {
                    bool[,] currentPrintPattern = PrintLetterDictionary.getPrintPatternByChar(letters[i]);

                    int horizontalLetterLength = currentPrintPattern.GetLength(1);
                    int verticalLetterLength = currentPrintPattern.GetLength(0);

                    if ((horizontalLetterLength + currentHorizontalPosition - 1) < horizontalDim)
                    {
                        if (i == textAndImageIndex)
                        {
                            break;
                        }
                        currentHorizontalPosition += horizontalLetterLength + 1;
                        lineLetters.Add(letters[i]);
                    }
                    else
                    {
                        if (((verticalLetterLength + currentVerticalPosition + 1) < verticalDim) && textAndImageIndex==-1)
                        {
                            //calculate offset to align in center
                            if (currentHorizontalPosition < horizontalDim)
                            {
                                currentHorizontalPosition = (int)((horizontalDim - (currentHorizontalPosition - 1)) / 2);
                            }
                            else
                            {
                                currentHorizontalPosition = 0;
                            }
                            generateAndWriteLine(lineLetters, currentHorizontalPosition, currentVerticalPosition);

                            lineLetters.Clear();
                            lineLetters.Add(letters[i]);
                            currentHorizontalPosition = horizontalLetterLength;
                            currentVerticalPosition += (verticalLetterLength + 1);
                        }
                        else
                        {
                            generatingSuccessful = false;
                            break;
                        }
                    }
                }
                if (lineLetters.Count() > 0 && generatingSuccessful)
                {
                    if (currentHorizontalPosition < horizontalDim)
                    {
                        currentHorizontalPosition = (int)((horizontalDim - (currentHorizontalPosition - 1)) / 2);
                    }
                    else
                    {
                        currentHorizontalPosition = 0;
                    }
                    generateAndWriteLine(lineLetters, currentHorizontalPosition, currentVerticalPosition);
                }
                if (textAndImageIndex != -1)
                {
                    if (Txt.IndexOf("[SMILEY]") != -1)
                    {
                        bool[,] printArrayToWrite = PrintLetterDictionary.Smilie;
                        for (int x = 0; x < printArrayToWrite.GetLength(1); x++)
                        {
                            for (int y = 0; y < printArrayToWrite.GetLength(0); y++)
                            {
                                PrintArray[x + 3, y + 6] = printArrayToWrite[y, x];
                            }
                        }
                        lastVerticalLine = 23;
                    }
                    else if (Txt.IndexOf("[HEART]") != -1)
                    {
                        bool[,] printArrayToWrite = PrintLetterDictionary.Heart;
                        for (int x = 0; x < printArrayToWrite.GetLength(1); x++)
                        {
                            for (int y = 0; y < printArrayToWrite.GetLength(0); y++)
                            {
                                PrintArray[x + 3, y + 6] = printArrayToWrite[y, x];
                            }
                        }
                        lastVerticalLine = 23;
                    }
                }
            }

            return generatingSuccessful;
        }

        private void generateAndWriteLine(List<char> lineLetters, int currentHorizontalPosition, int currentVerticalPosition)
        {
            foreach (char letter in lineLetters)
            {
                bool[,] printArrayToWrite = PrintLetterDictionary.getPrintPatternByChar(letter);
                for (int x = 0; x < printArrayToWrite.GetLength(1); x++)
                {
                    for (int y = 0; y < printArrayToWrite.GetLength(0); y++)
                    {
                        PrintArray[x + currentHorizontalPosition, y + currentVerticalPosition] = printArrayToWrite[y, x];
                        lastVerticalLine = y + currentVerticalPosition;
                    }
                }
                currentHorizontalPosition += (printArrayToWrite.GetLength(1) + 1);
            }
        }

        public void visualizePrintArray()
        {
            for (int y = 0; y < PrintArray.GetLength(1); y++)
            {
                Console.WriteLine("");
                for (int x = 0; x < PrintArray.GetLength(0); x++)
                {
                    if (PrintArray[x, y] == true)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
        }
    }
}
