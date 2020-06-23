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
                sqlCmd.CommandText = "Select table_name from information_schema.tables";

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
            }
        }

        //Bitmap bm;

        //Printing works
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            //printPreviewDialog1.ShowDialog();

        }
        //This method call works
        private void button2_Click(object sender, EventArgs e)
        {
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
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

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




        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void TableName_Click(object sender, EventArgs e)
        {

        }

        private void txtViewTableName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
