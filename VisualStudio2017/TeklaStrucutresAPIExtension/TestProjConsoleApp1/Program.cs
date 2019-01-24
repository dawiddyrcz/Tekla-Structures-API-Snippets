using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProjConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            Test01();

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        static void Test01()
        {

            //Tekla.Structures.Model.Operations.Operation2.AutoSaveModel();
            //Tekla.Structures.Model.Operations.Operation2.SaveModel();
            //Tekla.Structures.Model.Operations.Operation2.ReopenModel();

            //Tekla.Structures.Drawing.Automation.DrawingCreator2.CreateMultiDrawing();
            // Tekla.Structures.Drawing.Automation.DrawingCreator2.CreateAssemblyDrawingsFromSelection();
            // Tekla.Structures.Drawing.Automation.DrawingCreator2.CreateSinglePartDrawingsFromSelection();

            Tekla.Structures.Drawing.DrawingList.ShowDrawingListWindow();
            
            //Tekla.Structures.Drawing.DrawingList.SelectDrawingOnTheList(1);
            //Tekla.Structures.Drawing.DrawingList.SelectDrawingOnTheList(2);
            //Tekla.Structures.Drawing.DrawingList.SelectAllDrawings();
            //Tekla.Structures.Drawing.DrawingList.UnselectAllDrawings();
            Tekla.Structures.Drawing.DrawingList.SelectDrawingOnTheList(2,5);
            System.Threading.Thread.Sleep(1000);
            Tekla.Structures.Drawing.DrawingList.CloseDrawingListWindow();
        }

    }
}
