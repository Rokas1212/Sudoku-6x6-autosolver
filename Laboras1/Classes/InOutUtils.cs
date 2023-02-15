using System.IO;

namespace Laboras1.Classes
{
    /// <summary>
    /// Methods for inputing the data from a file and outputting it back in to a file
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// takes data from a given file and inputs it in to a SudokuSheet class object
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="Sheet">SudokuSheet class object</param>
        public static void In(string filename, SudokuSheet Sheet)
        {
            string line;
            using (StreamReader read = new StreamReader(filename))
            {
                for (int i = 0; i < 6; i++)
                {
                    line = read.ReadLine();
                    
                    string[] parts = line.Split(' ');
                    Sheet.Put(i, 0, int.Parse(parts[0]));
                    Sheet.Put(i, 1, int.Parse(parts[1]));
                    Sheet.Put(i, 2, int.Parse(parts[2]));
                    Sheet.Put(i, 3, int.Parse(parts[3]));
                    Sheet.Put(i, 4, int.Parse(parts[4]));
                    Sheet.Put(i, 5, int.Parse(parts[5]));
                }
            }
        }

        /// <summary>
        /// Takes data from the SudokuSheet class object and outputs it in to a file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="title">Title of the data</param>
        /// <param name="Sheet">The SudokuSheet class object</param>
        public static void Out(string filename, string title, SudokuSheet Sheet)
        {
            using (var f = File.AppendText(filename))
            {
                f.WriteLine(title);
                for (int i = 0; i < Sheet.GetLength(0); i++)
                {
                    f.Write("\n| ");
                    for (int j = 0; j < Sheet.GetLength(1); j++)
                    {
                        f.Write(Sheet.TakeValue(i, j) + " | ");
                    }
                    f.Write("\n-------------------------");
                }
                f.Write('\n');
                f.Close();
            }
        }
    }
}