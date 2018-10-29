/*
 * Given an array of integers write a method that will return the smallest possible products of any two integers in the array. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMaxProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Write("\nInput an array of integer\n\n>>> ");
                    string[] input = Console.ReadLine().Split(',');
                    int[] intArr = new int[input.Length];
                    for (int i = 0; i < input.Length; i++)
                    {
                        intArr[i] = Convert.ToInt32(input[i]);
                    }
                    Console.WriteLine($"\nMaxProduct: {MinProduct(intArr)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}");
                }
                Console.Write("\nPress Enter to try another string...");
                Console.ReadLine();
                Console.Clear();
            } while (true);
        }

        static int MinProduct(int[] arr)
        {
            int min1 = arr[0] < arr[1] ? arr[0] : arr[1];
            int min2 = arr[0] < arr[1] ? arr[1] : arr[0];
            int max1 = min2;
            int max2 = min1;

            // iterrate through the array and find the two biggest and the two smallest integers
            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] < min1)
                {
                    min2 = min1;
                    min1 = arr[i];
                }
                else if (arr[i] < min2)
                {
                    min2 = arr[i];
                }
                else if (arr[i] > max1)
                {
                    max2 = max1;
                    max1 = arr[i];
                }
                else if (arr[i] > max2)
                {
                    max2 = arr[i];
                }
            }

            // if there are negative numbers only in the array return the product of the largest two
            if (max1 < 0)
            {
                return max1 * max2;
            }
            // if there is at least one non-negative number return the product of the smallest number and the largest non-negative number
            else if (min1 < 0 && max1 >=0)
            {
                return min1 * max1;
            }
            // otherwise always return the product of the smallest two numbers
            else 
            {
                return min1 * min2;
            }
        }
    }
}
