using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };

            Console.WriteLine("This is supposed to validate! It's a good sudoku! " + ValidateSudoku(goodSudoku1));
            Console.WriteLine("This is supposed to validate! It's a good sudoku! " + ValidateSudoku(goodSudoku2));
            Console.WriteLine("This isn't supposed to validate! It's a bad sudoku! " + !ValidateSudoku(badSudoku1));
            Console.WriteLine("This isn't supposed to validate! It's a bad sudoku! " + !ValidateSudoku(badSudoku2));

            Console.ReadKey();
        }

        public static bool ValidateSudoku(int[][] puzzle)
        {
            int n = puzzle.Length;
            int sum = 0;
            int sum2 = 0;
            int sum3 = 0;
            int[] list1 = new int[n];
            int[] list2 = new int[n];
            for (int x = 0; x < n; x++)
            {
                sum2 = 0;
                sum = 0;
                sum3 += x + 1;
                for (int y = 0; y < n; y++)
                {
                    list1[y] = puzzle[x][y];
                    list2[y] = puzzle[y][x];
                    sum += puzzle[x][y];
                    sum2 += puzzle[y][x];                  
                }

                if (list1.GroupBy(d => d).Any(c => c.Count() > 1) || list2.GroupBy(d => d).Any(c => c.Count() > 1))
                    return false;
                if (sum == sum3 || sum2 == sum3)
                    return true;


            }
            
            return false;

        }

    }
}



