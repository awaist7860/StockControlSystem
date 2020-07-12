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
    public partial class Delete_Tables : Form
    {

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String

        public Delete_Tables()
        {
            InitializeComponent();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            string tableName = txtTableDeleteName.Text;
            SqlConnection con = new SqlConnection(AccessString);

            try
            {


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
        }

        private void txtTableDeleteName_TextChanged(object sender, EventArgs e)
        {

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

        private void Delete_Tables_Load(object sender, EventArgs e)
        {

        }

        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTables.SelectedItems != null)
            {
                string selectedName = "";
                //selectedName = listBox1.SelectedItem.ToString();
                selectedName = lstTables.GetItemText(lstTables.SelectedItem);

                //var selected = new List<string>();
                //selectedName = listBox1.SelectedItems.Cast<string>().ToString();
                //label1.Text = selectedName;
                txtTableDeleteName.Text = selectedName; //label1.;
                label2.Text = selectedName;
            }
        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            con.Open();

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select table_name from information_schema.tables";

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            lstTables.Items.Clear();

            lstTables.DataSource = dtRecord;
            lstTables.DisplayMember = "TABLE_NAME";
            con.Close();
        }

        private void btnViewTableData_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            string tableName2 = txtTableDeleteName.Text;

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM " + tableName2, con); //This works
                con.Open();

                //Method 1
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                //label2.Text = selectedName;


            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void lstTables_DoubleClick(object sender, EventArgs e)
        {
            btnViewTableData_Click(sender, e);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            lstTables.DataSource = null;
            lstTables.Items.Clear();
        }
    }
}
