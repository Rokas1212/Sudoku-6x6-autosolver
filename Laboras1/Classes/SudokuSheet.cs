namespace Laboras1.Classes
{
    /// <summary>
    /// A 2d sheet used for sudoku
    /// </summary>
    public class SudokuSheet
    {
        // constant for max rows the sheet can have
        const int CMaxRows = 6;
        // constant for max columns the sheet can have
        const int CMaxCol = 6;
        // grid (matrix) of the sheet
        private int[,] SheetTable;

        // constructor with no parameters
        public SudokuSheet()
        {
            SheetTable = new int[CMaxRows, CMaxCol];
        }

        //public int this[int i, int j]
        //{
        //    get { return SheetTable[i, j]; }
        //
        //    set { SheetTable[i, j]= value; }
        //}

        /// <summary>
        /// allows to edit the numbers of the sheet
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <param name="number">number to be inserted</param>
        public void Put(int i, int j, int number)
        {
            SheetTable[i, j] = number;
        }

        /// <summary>
        /// allows to check a specific value on the sheet
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column/param>
        /// <returns>the value in Sheet[i,j]</returns>
        public int TakeValue(int i, int j)
        {
            return SheetTable[i, j];
        }

        /// <summary>
        /// gives the length of the sheet horizontally or vertically
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns>horizontal length if rotation is 0, vertical if it is 1</returns>
        public int GetLength(int rotation)
        {
            return SheetTable.GetLength(rotation);
        }

    }
}