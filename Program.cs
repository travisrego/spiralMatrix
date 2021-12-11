using System;

namespace spiralMatrix
{
    internal static class Program
    {
        private static int _row;
        private static int _col;
        
        private static int _n ;
        private static int[,] _array;
        private static string _direction = "right";
        private static int _totalRotations;

        private static void Main()
        {
            //  1  2  3  4... 
            //  9  8  7  6...
            // 10 11 12 13...     

            Console.Write("Type a number: ");

            _n = Convert.ToInt32(Console.ReadLine());
            _array = new int[_n, _n];
            _totalRotations = _n * _n;

            Console.WriteLine(new string(' ', 10));
            
            // Not here

            for (int i = 1; i <= _totalRotations; i++)
            {
                CanOccupy(); 
                _array[_row, _col] = i;
                SwitchDirection();
            }

            for (int i = 0; i < _n; i++)  
            {  
                for (int j = 0; j < _n; j++)  
                {  
                    Console.Write("{0, 4}", _array[i, j]);  
                }  
                Console.WriteLine();  
            }  
        }

        private static void CanOccupy()
        {
            if (_direction == "right" && (_col > _n - 1 || _array[_row, _col] != 0))
            {
                _direction = "down";
                _row++; // Increase Row to go down
                _col--; // To make it return back in the array  
            }

            if (_direction == "down" && (_row > _n - 1 || _array[_row, _col] != 0))
            {
                _direction = "left";
                _col--; 
                _row--; 
            }

            if (_direction == "left" && (_col < 0 || _array[_row, _col] != 0))
            {
                _direction = "top";
                _col++;
                _row--; 
            }

            if (_direction == "top" && (_row < 0 || _array[_row, _col] != 0))
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