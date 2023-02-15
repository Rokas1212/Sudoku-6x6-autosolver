using System;
using System.IO;
using Laboras1.Classes;

namespace Laboras1
{
    public partial class Forma : System.Web.UI.Page
    {
        SudokuSheet Sheet = new SudokuSheet();
        private string inputPath = @"Includes/Data2.txt";
        private string outputPath = @"Includes/Results.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(outputPath)))
            { File.Delete(Server.MapPath(outputPath)); }

            InOutUtils.In(Server.MapPath(inputPath), Sheet);
            InOutUtils.Out(Server.MapPath(outputPath), "Pradinė sudoku lentelė", Sheet);


            TaskUtils.InsertTable(Sheet, DataTable);

        }


        protected void Results_Click(object sender, EventArgs e)
        {
            TaskUtils.Solver(Sheet);
            TaskUtils.InsertTable(Sheet, ResultsTable);
            InOutUtils.Out(Server.MapPath(outputPath), "Rezultatai", Sheet);
        }
    }
}