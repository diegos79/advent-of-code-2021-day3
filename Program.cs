using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aocd4p1
{
    internal class Program
    {
        /* ------------------------------------------------------------- */
        /* Read input file and convert to array string                   */

        static public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
        /* ------------------------------------------------------------- */
        /* Calculate the most common bit in position n                   */
        static public char GetMostCommonBit (string[] array, int position)
        {

            return ' ';
        }
        /* ------------------------------------------------------------- */
        /* Count bit 1 in a single column of the array of bit            */
        static public int CountBitOneInAColumn (string[] array, int column)
        {
            int count = 0;
            foreach (var item in array) //loop for return total of 1 bit in a column 
            {
                if (item[column] == '1')
                {
                    count++;
                }
            }
            return count;
        }
        
        /* ------------------------------------------------------------- */
        /* Count bit 0 in a single column of the array of bit            */
        static public int CountBitZeroInAColumn(string[] array, int column)
        {
            int count = 0;
            foreach (var item in array) //loop for return total of 1 bit in a column 
            {
                if (item[column] == '0')
                {
                    count++;
                }
            }
            return count;
        }

        /* ------------------------------------------------------------- */
        /* Get common bit a column                                       */
        static public byte GetCommonBitInAColumn (string[] array, int column)
        {

            if (CountBitOneInAColumn(array, column) > CountBitZeroInAColumn(array, column))
                return 1;
            else
                return 0; 
        }

        /* ------------------------------------------------------------- */
        /*  Get Gamma Rate                                               */
        static public byte[] GetGammaRate (string[] array, int numberOfBits)
        {
            int cont = 0;
            byte[]res = new byte[numberOfBits];
            for (int column = 0; column < numberOfBits; column++)
            {
                res[cont] = GetCommonBitInAColumn(array, column);
                cont++;
            }
            return res;
        }

        /* ------------------------------------------------------------- */
        /* Print an array of byte                                        */
        static public void PrintByteArray (byte[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
            }
        }

        /* ------------------------------------------------------------- */
        /* Invert array of byte for calculate Epsilon Rate               */
        static public byte[] InvertArrayOfByte (byte[] array)
        {
            byte[] res = new byte[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 1)
                    res[i] = 0;
                else res[i] = 1;
            }
            return res;
        }

        /* ------------------------------------------------------------- */
        /* Get Epsilon by calculate opposite of gamma                    */
        static public byte[] GetEpsilonRate(byte[] gamma) => 
            InvertArrayOfByte(gamma);

        /* ------------------------------------------------------------- */
        /*  Convert byte array to decimal                                */

        static int ConvertByteArrayToDecimal (byte[] array)
        {
            int res = 0;
            int j = 1;
            for (int i = array.Length-1; i >= 0 ; i--)
            {
                res += array[i] * j;
                j *= 2;
            }
            return res;
        }


        /* -------------------------  MAIN ----------------------------  */
        static void Main()
        {
            // read input data file and convert to string array
            string[] inputArrayString = ReadFile("input-day3.txt"); 
            // calculate gamma rate
            var gamma = GetGammaRate(inputArrayString, 12);
            Console.Write($"From your input data, this is Gamma Rate: ");PrintByteArray(gamma);
            var epsilon = GetEpsilonRate(gamma);
            Console.WriteLine("");
            Console.Write($"From yout input data, this is Epsilon Rate: "); PrintByteArray(epsilon);
            Console.WriteLine("");
            var gammaDec = ConvertByteArrayToDecimal(gamma);
            var epsilonDec = ConvertByteArrayToDecimal(epsilon);
            Console.WriteLine("\nThis is Gamma converted to decimal = " + gammaDec);
            Console.WriteLine("\nThis is Epsilon converted to decimal = " + epsilonDec);
            var power = gammaDec * epsilonDec;
            Console.WriteLine("\nThis is Power consumption= " + power);

            Console.ReadKey();
        }
    }


}
