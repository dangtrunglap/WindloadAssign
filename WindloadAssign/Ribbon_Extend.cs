using System;
using System.Runtime.InteropServices;
using ExcelDna.Integration.CustomUI;
using Microsoft.Office.Interop.Excel;
using ExcelDna.Integration;

using System.Windows;
using WindloadAssign;


[ComVisible(true)]
public class X_Ribbon : ExcelRibbon
{
   
    public void WINDLOAD_ASSIGN2(IRibbonControl control)
    {
        WindAssign Windload3 = new WindAssign();
        Windload3.Show();
    }

    public void Open_WindLoad_shXL(IRibbonControl control)
    {
        Microsoft.Office.Interop.Excel.Application appXL;
        Range rngXL;
        Microsoft.Office.Interop.Excel.Workbook wbXL;
        appXL = (Application)ExcelDnaUtil.Application;
        appXL.Visible = true;
        string filepath;
        filepath = @"C:\WindAddin2024\excelfile\WindLoad_2023.xlsm";
        wbXL = appXL.Workbooks.Open(filepath);
        //Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = wbXL.Worksheets[1];
        //xlWorksheet.Activate();
    }



}

