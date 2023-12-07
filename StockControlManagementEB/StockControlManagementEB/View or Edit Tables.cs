using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using PagedList;
using System.Drawing.Printing;

namespace StockControlManagementEB
{
    public partial class View_or_Edit_Tables : Form
    {

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String


        public View_or_Edit_Tables()
        {
            InitializeComponent();
        }

        private void btnViewAllTables_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            try
            {

                con.Open();

                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = con;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select table_name from information_schema.tables"; // WHERE table_name <> User";

                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                listBox1.Items.Clear();

                listBox1.DataSource = dtRecord;

                listBox1.DisplayMember = "TABLE_NAME";

                con.Close();

            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            dataGridView1.DataSource = null;
            btnViewAllTables_Click(sender, e);


        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            string tableName2 = txtViewTableName.Text;

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM " + tableName2, con); //This works
                con.Open();

                //Method 1
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                lblTableName.Text = selectedName;


            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TablesMenu tablesMenu = new TablesMenu();
            tablesMenu.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string selectedName = "";

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {

                //selectedName = listBox1.SelectedItem.ToString();
                selectedName = listBox1.GetItemText(listBox1.SelectedItem);

                //var selected = new List<string>();
                //selectedName = listBox1.SelectedItems.Cast<string>().ToString();
                //label1.Text = selectedName;
                //txtTableDeleteName.Text = selectedName; //label1.;
                txtViewTableName.Text = selectedName;
                label2.Text = selectedName;
            }
        }

        //Bitmap bm;

        //Printing works
        Bitmap bmp;

        //This method call works
        private void button2_Click(object sender, EventArgs e)
        {

            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            //printPreviewDialog1.ShowDialog();

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
                printPreviewDialog1_Load(sender, e);
            }





            //Printing printing = new Printing();
            //printing.PrintingExcelMethod(txtViewTableName.Text);

            //printPreviewDialog1_Load(sender, e);

            //Open the print dialog
            //PrintDialog printDialog = new PrintDialog();
            //printDialog.Document = printDocument1;
            //printDialog.UseEXDialog = true;

            //if (DialogResult.OK == printDialog.ShowDialog())
            //{
            //printDocument1.DocumentName = "Test Page Print";
            //printDocument1.Print();
            //printPreviewDialog1_Load(sender, e);
            //}
            /*
            Note: In case you want to show the Print Preview Dialog instead of 
            Print Dialog then comment the above code and uncomment the following code
            */

            //Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();  //Uncomment these 3 line later
            //objPPdialog.Document = printDocument1;
            //objPPdialog.ShowDialog();

            //This opens up excel and copys the datafrom the datagrid to the excel sheet
            //copyAlltoClipboard();
            //Microsoft.Office.Interop.Excel.Application xlexcel;
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;
            //xlexcel = new Microsoft.Office.Interop.Excel.Application();
            //xlexcel.Visible = true;
            //xlWorkBook = xlexcel.Workbooks.Add(misValue);
            //xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            //CR.Select();
            //xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //Comment this back in when testing


            //Make a class that exports data from a datagrid view box to an excel file
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Excel Documents (*.xls)|*.xls";
            //sfd.FileName = "Inventory_Adjustment_Export.xls";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    // Copy DataGridView results to clipboard
            //    copyAlltoClipboard();

            //    object misValue = System.Reflection.Missing.Value;
            //    Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

            //    xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
            //    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
            //    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //    // Format column D as text before pasting results, this was required for my data
            //    Microsoft.Office.Interop.Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
            //    rng.NumberFormat = "@";

            //    // Paste clipboard results to worksheet range
            //    Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            //    CR.Select();
            //    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            //    // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
            //    // Delete blank column A and select cell A1
            //    Microsoft.Office.Interop.Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
            //    delRng.Delete(Type.Missing);
            //    xlWorkSheet.get_Range("A1").Select();

            //    // Save the excel file under the captured location from the SaveFileDialog
            //    xlWorkBook.SaveAs(sfd.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //    xlexcel.DisplayAlerts = true;
            //    xlWorkBook.Close(true, misValue, misValue);
            //    xlexcel.Quit();

            //    releaseObject(xlWorkSheet);
            //    releaseObject(xlWorkBook);
            //    releaseObject(xlexcel);

            //    // Clear Clipboard and DataGridView selection
            //    Clipboard.Clear();
            //    dataGridView1.ClearSelection();

            //    // Open the newly saved excel file
            //    if (System.IO.File.Exists(sfd.FileName))
            //        System.Diagnostics.Process.Start(sfd.FileName);

            //    // now to print it
            //    Printing printing = new Printing();
            //    printing.PrintingExcelMethod(sfd.FileName);
            //}

            //Something else
            //int height = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;

            //bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            //printPreviewDialog1.ShowDialog();
            //printDocument1();
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }


        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }



        

        private void TableName_Click(object sender, EventArgs e)
        {

        }

        private void txtViewTableName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            btnViewData_Click(sender, e);
        }

        private void View_or_Edit_Tables_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            string query;
            query = richTextBox1.Text;
            SqlConnection con = new SqlConnection(AccessString);

            try 
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con); //This works

                //sda.();
                con.Close();

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dataGridView1.DataSource = dt;

                MessageBox.Show("The query ran is: \n" + query + "\n The query ran succesfully");
            }
            catch(Exception f)
            {
                MessageBox.Show("exception occured: " + f.Message + "\t" + f.GetType());
            }
            

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string CreateTableSQL1;
            string CreateTableSQL2;
            string tableName;
            tableName = label2.Text;
            //string dropTableQuery;

            SqlConnection con = new SqlConnection(AccessString);

            try
            {
                //This is stupid
                SqlCommand sda = new SqlCommand("DROP TABLE " + tableName, con); //This works
                con.Open();
                sda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Table deleted: " + tableName);
            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }



            //string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string LogFolder = @"C:\Log\";  //Log file
            
            //string strPath;

            CreateTable createTable = new CreateTable();    //Creates a createTable Object from the class
            DataTable data = (DataTable)(dataGridView1.DataSource); //Gives the datatable the data from the datagridViews

            //strPath = label2.Text;
            //string filename = Path.GetFileNameWithoutExtension(strPath);
            //tableName = filename.ToString();

            //MessageBox.Show("Filename is: " + filename);
            //This is a long work around to get a proper string, need to make it smaller
            //label1.Text = filename;
            //tableName = label1.Text;
            //tableName = tableName.Replace(" ", "_");
            //tableName = tableName + "_" + comboBox1.Text;
            // + "TestEdit";
            MessageBox.Show("Table is: " + tableName);



            //MessageBox.Show(createTable.CreateTABLE(tableName, data));   //Calls the CreateTable method from the class and gives it the 2 parameters, first one is a string for the name and the second one is a datatable with the data
            MessageBox.Show(createTable.GetCreateTableSql(data, tableName));   //Calls the GetCreateTableSql method from the class and gives it a parameter, which is a datatable with the data

            //Giving the varaibles the sql command to be later run
            //CreateTableSQL1 = createTable.CreateTABLE(tableName, data);
            CreateTableSQL2 = createTable.GetCreateTableSql(data, tableName);

            //This is the log file being created
            //using (StreamWriter sw = File.CreateText(LogFolder + "\\" + "ErrorLog_" + datetime + ".log"))
            //{
                //sw.WriteLine("This is sql query with no primary keys or datatypes: " + CreateTableSQL1);
                //sw.WriteLine("This is sql query with primary keys and datatypes: " + CreateTableSQL2);
            //}

            //Sql command that is being run
            //This command creates  a table
            //SqlConnection con = new SqlConnection(AccessString);
            con.Open();
            SqlCommand cmd = new SqlCommand(CreateTableSQL2, con);
            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            //I assume you have created the table previously
            //Someone else here already showed how  
            bulkcopy.DestinationTableName = tableName.ToString();
            try
            {
                bulkcopy.WriteToServer(data);
            }
            catch (Exception f)
            {
                MessageBox.Show("Error is: " + f);
            }
            con.Close();

            dataGridView1.Refresh();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Printing again a different way



    }
}
