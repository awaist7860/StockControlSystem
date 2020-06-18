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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                string selectedName = "";
                //selectedName = listBox1.SelectedItem.ToString();
                selectedName = listBox1.GetItemText(listBox1.SelectedItem);

                //var selected = new List<string>();
                //selectedName = listBox1.SelectedItems.Cast<string>().ToString();
                //label1.Text = selectedName;
                //txtTableDeleteName.Text = selectedName; //label1.;
                txtViewTableName.Text = selectedName;
            }
        }


        //Printing works
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
        //This method call works
        private void button2_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1_Load(sender, e);

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
                //printPreviewDialog1_Load(sender, e);
            }
            /*
            Note: In case you want to show the Print Preview Dialog instead of 
            Print Dialog then comment the above code and uncomment the following code
            */

            //Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = printDocument1;
            //objPPdialog.ShowDialog();

        }




        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            //printDocument1.Print();
        }
    }
}
