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
    }
}
