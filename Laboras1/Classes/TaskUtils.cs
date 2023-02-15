using System;
using System.Web.UI.WebControls;

namespace Laboras1.Classes
{
    public class TaskUtils
    {
        /// <summary>
        /// A method that solves the 6x6 sudoku sheet by using backtracking
        /// </summary>
        /// <param name="Sheet"></param>
        /// <returns>true if there are no 0's left in the sudoku sheet</returns>
        public static bool Solver(SudokuSheet Sheet)
        {

            for (int i = 0; i < Sheet.GetLength(0); i++)
            {
                for (int j = 0; j < Sheet.GetLength(1); j++)
                {
                    if (Sheet.TakeValue(i, j) == 0)
                    {
                        for (int k = 1; k <= 6; k++)
                        {
                            if (ValidHorizontally(Sheet, i, k) 
                                && ValidVertically(Sheet, j, k) 
                                && ValidBox(Sheet, i, j, k))
                            {
                                Sheet.Put(i, j, k);
                                if(Solver(Sheet))
                                    return true;
                                else
                                    Sheet.Put(i, j, 0);
                            }
                            
                        }
                        return false;
                    }
                }
                
            }
            return true;
        }
        /// <summary>
        /// checks if there are no instances of given number n in the sheet 
        /// which are in the same row as n 
        /// </summary>
        /// <param name="Sheet">The sheet</param>
        /// <param name="i">The row</param>
        /// <param name="n">The given number n</param>
        /// <returns>True if n is valid false if it is invalid</returns>
        public static bool ValidHorizontally(SudokuSheet Sheet, int i, int n)
        {
            for (int index = 0; index < Sheet.GetLength(0); index++)
                if (n == Sheet.TakeValue(i, index))
                    return false;
            return true;
        }

        /// <summary>
        /// checks if there are no instances of given number n in the sheet
        /// which are in the same column as n
        /// </summary>
        /// <param name="Sheet">The sheet</param>
        /// <param name="j">The column</param>
        /// <param name="n">The given number</param>
        /// <returns>true if n is valid, false otherwise</returns>
        public static bool ValidVertically(SudokuSheet Sheet, int j, int n) 
        {
            for (int index = 0; index < Sheet.GetLength(1); index++)
                if (n == Sheet.TakeValue(index, j))
                    return false;
            return true;
        }

        /// <summary>
        /// Checks if there are no instances of the number n in the same 3x2 box
        /// of values in the sudoku sheet
        /// </summary>
        /// <param name="Sheet">The sheet</param>
        /// <param name="i">The row of number n</param>
        /// <param name="j">The column of number n</param>
        /// <param name="n">The given number</param>
        /// <returns>True if there are no duplicates of number n in the box,
        /// false if there are instances of the same number</returns>
        public static bool ValidBox(SudokuSheet Sheet, int i, int j, int n)
        {
            int sqrt = (int)Math.Sqrt(Sheet.GetLength(0));
            int boxRowStart = i - i % sqrt;
            int boxColStart = j - j % sqrt;
            for (int x = boxRowStart + 1; x < boxRowStart + sqrt; x++)
            {
                for (int y = boxColStart + 1; y < boxColStart + sqrt; y++)
                {
                    if (Sheet.TakeValue(x, y) == n)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Inserts a sheet values in to a table on the web form
        /// </summary>
        /// <param name="Sheet">The sheet</param>
        /// <param name="Table">The table</param>
        public static void InsertTable(SudokuSheet Sheet, Table Table)
        {
            int check = 0, checkB = 0;
            for (int i = 0; i < Sheet.GetLength(0); i++)
            {
                check++;
                TableCell one = new TableCell();
                one.Text = (Sheet.TakeValue(i, 0)).ToString();
                CheckIfZero(one);

                TableCell two = new TableCell();
                two.Text = (Sheet.TakeValue(i, 1)).ToString();
                CheckIfZero(two);

                TableCell three = new TableCell();
                three.Text = (Sheet.TakeValue(i, 2)).ToString();
                three.Attributes.Add("style", "border-right: solid Black 3px");
                CheckIfZero(three);

                TableCell four = new TableCell();
                four.Text = (Sheet.TakeValue(i, 3)).ToString();
                four.Attributes.Add("style", "border-left: solid Black 3px");
                CheckIfZero(four);

                TableCell five = new TableCell();
                five.Text = (Sheet.TakeValue(i, 4)).ToString();
                CheckIfZero(five);

                TableCell six = new TableCell();
                six.Text = (Sheet.TakeValue(i, 5)).ToString();
                CheckIfZero(six);

                TableRow row = new TableRow();
                row.Cells.Add(one);
                row.Cells.Add(two);
                row.Cells.Add(three);
                row.Cells.Add(four);
                row.Cells.Add(five);
                row.Cells.Add(six);

                if (check == 2 && checkB != 2)
                {
                    row.Attributes.Add("style", "border-bottom: solid Black 3px");
                    check = 0;
                    checkB++;
                }

                Table.Rows.Add(row);
            }
        }

        public static void CheckIfZero(TableCell cell)
        {
            if (cell.Text == "0")
            {
                cell.Attributes.Add("style", "background-color: khaki");
            }
        }
    }
}