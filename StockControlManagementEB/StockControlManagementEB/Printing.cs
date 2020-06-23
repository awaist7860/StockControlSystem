using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace StockControlManagementEB
{
    class Printing
    {
        public void PrintingExcelMethod(string filename)
        {
            Application ExcelApp = new Application();
            ExcelApp.Visible = false;
            ExcelApp.DisplayAlerts = false;

            string filename1 = "@" + filename;

            Workbook WBook = ExcelApp.Workbooks.Open
            //(@"C:\Users\awais\OneDrive\Desktop\ExcelTest\Test$Data1.xlsx", Missing.Value,
            (filename, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value);

            WBook.PrintOut(Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value);

            WBook.Close(false, Missing.Value, Missing.Value);

            ExcelApp.Quit();
        }
    }
}
