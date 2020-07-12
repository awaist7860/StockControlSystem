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
    public partial class Create_Tables : Form
    {
        public string UserTableName;

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String

        public Create_Tables()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            //string tableName = txtInput.Text;


            try
            {
                //User can create their own table with their own table name
                SqlCommand sda = new SqlCommand("CREATE TABLE " + UserTableName + " (ProductID INTEGER PRIMARY KEY, ProductName varchar(50), ProductSize varchar(50), ProductColour varchar(50), ProductStyle varchar(50))", con); //This works
                con.Open();
                //sda.ExecuteNonQuery();
                sda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Table Created");
                btnViewAllTables_Click(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("exception occured while creating table:" + a.Message + "\t" + a.GetType());
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            TablesMenu tablesMenu = new TablesMenu();
            tablesMenu.Show();
            this.Close();
        }

        private void Create_Tables_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmName_Click(object sender, EventArgs e)
        {
            UserTableName = txtInput.Text;
            UserTableName = UserTableName.Replace(" ", "_");


            SqlConnection con = new SqlConnection(AccessString);

            //string tableName = txtInput.Text;


            try
            {
                //User can create their own table with their own table name
                SqlCommand sda = new SqlCommand("CREATE TABLE " + UserTableName + "(ProductID INTEGER PRIMARY KEY)", con); //This works
                con.Open();
                //sda.ExecuteNonQuery();
                sda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(UserTableName + " table Created");
                //btnViewAllTables_Click(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("exception occured while creating table:" + a.Message + "\t" + a.GetType());
            }
        }

    }
    
}
