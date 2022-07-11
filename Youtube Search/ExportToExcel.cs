using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_Search
{
    public partial class ExportToExcel : Form
    {
        DataGridView dg;
        string fileName;

        public ExportToExcel()
        {
            InitializeComponent();
        }

        public ExportToExcel(DataGridView dg, string fileName)
        {
            InitializeComponent();
            this.dg = dg;
            this.fileName = fileName;

            pgExportToExcel.Minimum = 0;
            pgExportToExcel.Maximum = dg.Rows.Count;

            bgWorkerExportToExcel.RunWorkerAsync();

        }




        private void ExportToExcel_Load(object sender, EventArgs e)
        {





        }

        private void bgWorkerExportToExcel_DoWork(object sender, DoWorkEventArgs e)
        {

            //export to excel
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);

            ExcelApp.Columns.ColumnWidth = 20;

            for (int i = 1; i < dg.Columns.Count + 1; i++)
            {
                ExcelApp.Cells[1, i] = dg.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dg.Rows.Count ; i++)
            {
                for (int j = 0; j < dg.Columns.Count; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                }
                //bgWorkerExportToExcel.ReportProgress(i);

            }


            ExcelApp.ActiveWorkbook.SaveCopyAs(fileName);
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
            //export to excel


        }

        private void bgWorkerExportToExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgExportToExcel.Value = e.ProgressPercentage;
        }

        private void bgWorkerExportToExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Excel file was created on " + fileName, "Excel was created. Do you want to open file?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {

                System.Diagnostics.Process.Start(fileName);

            }

            this.Close();
        }
    }
}
