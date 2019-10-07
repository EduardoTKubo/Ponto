using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Xls;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ponto.Classes
{
    class clsPlanilha
    {

        // gerando e salvando planilha excel via FreeSpire
        public static async Task<Boolean> GeraSpireXLSAsync(DataTable _dt, string _path)
        {
            // via nuget  FreeSpire.XLS
            // gerando arquivo xlsc  com  2 planilhas !
            try
            {
                // criando planilha 1 - _dt1
                Workbook workbook = new Workbook();
                Worksheet sheet = workbook.Worksheets[0];

                // populando a planilha 1 com o DataTable _dt
                await Task.Run(() =>
                {
                    sheet.InsertDataTable(_dt, true, 1, 1);

                    // definindo altura da linha = 15
                    for (int i = sheet.LastRow - 1; i >= 0; i--)
                    {
                        sheet.SetRowHeight(i + 1, 15);
                    }

                    workbook.Worksheets[0].Name = "Plan1";
                    workbook.Worksheets[1].Name = "Plan2";
                    workbook.Worksheets[2].Name = "Plan3";
                    // workbook.Worksheets[2].Remove();

                    // salvando arquivo em .... _path
                    workbook.SaveToFile(_path, ExcelVersion.Version2013);
                    workbook.Dispose();
                });

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gera XLSX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        // gerando planilha via Interop
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        public static async Task<bool> ExportarXLSAsync(DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            
            wb.Sheets.Add();
            Microsoft.Office.Interop.Excel.Worksheet ws1 = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            ws1.Name = "Horas";
            ws1.Cells.NumberFormat = "@";
            try
            {
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    ws1.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }
                
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (j != 2)
                        {
                            ws1.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            string cel = dgv.Rows[i].Cells[j].Value.ToString().Replace(" 00:00:00","");
                            ws1.Cells[i + 2, j + 1] = cel;
                        }
                    }
                }
                ws1.Columns.AutoFit();
                
                //MessageBox.Show("Exportação finalizada", "Relatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                app.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlNormal;
                app.Visible = true;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
                return false;
            }
            finally
            {
                //GetExcelProcessAndKill(app);
                app = null;
                wb = null;
                ws1 = null;
            }
        }



        // abrindo planilha via interop
        public static void OpenXLS(string _path)
        {
            try
            {
                var excelApp = new Excel.Application
                {
                    Visible = true
                };

                Excel.Workbooks books = excelApp.Workbooks;
                Excel.Workbook sheet = books.Open(_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Open XLSX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
