using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMM.Support
{
    class ExportData
    {
        #region Variables & Properties

        #endregion

        #region Form Events

        #endregion

        #region Business Logic
        public void ExportToExcel(DataGridView myGrid)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel file|*.xls";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel 
                for (int i = myGrid.Columns.Count; i > 0; i--)
                {
                    if (myGrid.Columns[i - 1].CellType.ToString() != "System.Windows.Forms.DataGridViewTextBoxCell")
                    {
                        myGrid.Columns.RemoveAt(i - 1);
                    }
                }
                for (int i = 1; i < myGrid.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = myGrid.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < myGrid.Rows.Count; i++)
                {
                    for (int j = 0; j < myGrid.Columns.Count; j++)
                    {
                        if (myGrid.Columns[j].CellType.ToString() == "System.Windows.Forms.DataGridViewTextBoxCell")
                        {
                            if (myGrid.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = myGrid.Rows[i].Cells[j].Value != null ?
                                myGrid.Rows[i].Cells[j].Value.ToString() : "";
                            }
                        }
                    }
                }

                // save the application  
                workbook.SaveAs(dlg.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();

                System.Diagnostics.Process.Start(dlg.FileName);

            }
        }
        #endregion
    }
}
