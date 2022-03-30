using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using ConsoleApp3.Notation;

namespace ConsoleApp3.Excel
{
    public class ExcelOutput
    {
        private XLWorkbook _workbook;

        public ExcelOutput()
        {
            _workbook = new XLWorkbook();
        }

        public void AddAlgorithm(string name, InputDate inputDate, List<IterationNotation> iterationNotations)
        {
            IXLWorksheet worksheet = _workbook.AddWorksheet(name);
            
            worksheet.Cell("A1").Value = "№";
            worksheet.Cell("B1").Value = "a";
            worksheet.Cell("C1").Value = "b";
            worksheet.Cell("D1").Value = "Длина";
            worksheet.Cell("E1").Value = "x";
            worksheet.Cell("F1").Value = "f";
            worksheet.Cell("G1").Value = "Отношение длин";
            
            for (int i = 0; i < iterationNotations.Count; i++)
            {
                var iterationReport = iterationNotations[i];

                var rowNumber = i + 2;
                worksheet.Cell($"A{rowNumber}").Value = i + 1;
                
                worksheet.Cell($"B{rowNumber}").Value = iterationReport.LeftLimit;
                worksheet.Cell($"C{rowNumber}").Value = iterationReport.RightLimit;

                var length = Math.Abs(iterationReport.RightLimit - iterationReport.LeftLimit);
                worksheet.Cell($"D{rowNumber}").Value = length;

                worksheet.Cell($"E{rowNumber}").Value = iterationReport.CurrentExtr.X;
                worksheet.Cell($"F{rowNumber}").Value = iterationReport.CurrentExtr.Y;

                
                double prevLength = i == 0
                    ? (inputDate.RightLimit - inputDate.LeftLimit)
                    : Math.Abs(iterationNotations[i - 1].RightLimit - iterationNotations[i - 1].LeftLimit);
                double ration = length / prevLength;
                worksheet.Cell($"G{rowNumber}").Value = ration;
            }
        }

        public void AddFunctionCalculationReport(string algorithmName, List<(double delta, long count)> countReports)
        {
            IXLWorksheet worksheet = _workbook.AddWorksheet(algorithmName);

            worksheet.Cell("A1").Value = "eps";
            worksheet.Cell("A2").Value = "count";

            for (int i = 2; i < countReports.Count + 2; i++)
            {
                var (delta, count) = countReports[i - 2];

                worksheet.Cell(1, i).Value = delta;
                worksheet.Cell(2, i).Value = count;
            }
        }
        
        public void SaveReport(string path)
        {
            using var outStream = new FileStream(path, FileMode.Create);
            _workbook.SaveAs(outStream);
        }
    }
}