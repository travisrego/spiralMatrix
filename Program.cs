using System;

namespace spiralMatrix
{
    internal static class Program
    {
        private static int _row;
        private static int _col;
        private static readonly int N = Convert.ToInt32(Console.ReadLine());
        private static readonly int[,] Array = new int[N , N];
        private static string _direction = "right";
        private static readonly int TotalRotations = N*N;

        private static void Main()
        {
            //  1  2  3  4... 
            //  9  8  7  6...
            // 10 11 12 13...     


            for (int i = 1; i <= TotalRotations; i++)
            {
                CanOccupy(); 
                Array[_row, _col] = i;
                SwitchDirection();
            }

            for (int i = 0; i < N; i++)  
            {  
                for (int j = 0; j < N; j++)  
                {  
                    Console.Write("{0, 4}", Array[i, j]);  
                }  
                Console.WriteLine();  
            }  
        }

        private static void CanOccupy()
        {
            if (_direction == "right" && (_col > N - 1 || Array[_row, _col] != 0))
            {
                _direction = "down";
                _row++; // Increase Row to go down
                _col--; // To make it return back in the array  
            }

            if (_direction == "down" && (_row > N - 1 || Array[_row, _col] != 0))
            {
                _direction = "left";
                _col--; 
                _row--; 
            }

            if (_direction == "left" && (_col < 0 || Array[_row, _col] != 0))
            {
                _direction = "top";
                _col++;
                _row--; 
            }

            if (_direction == "top" && (_row < 0 || Array[_row, _col] != 0))
            {
                _direction = "right";
                _row++; 
                _col++;
            }

        }

        private static void SwitchDirection()
        {
            switch (_direction)
            {
                case "right":
                    _col++;
                    break;
                case "down":
                    _row++;
                    break;
                case "left":
                    _col--;
                    break;
                case "top":
                    _row--;
                    break;
            }
        }
    }
}