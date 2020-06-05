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
    public partial class UsersFormAdmin : Form
    {

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String

        public UsersFormAdmin()
        {
            InitializeComponent();
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users", con); //This works
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string adminAccess = cmbAdmin.Text;

            try
            {
                if (username == "" || password == "" || adminAccess == "")
                {
                    MessageBox.Show("Please enter a username and a password and select admin access");
                }
                else 
                {
                    SqlCommand sda = new SqlCommand("INSERT INTO Users VALUES ('" + username + "','" + password + "','" + adminAccess + "')", con); //This works
                    con.Open();

                    sda.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User " + username + " has been created");
                    btnViewUsers_Click(sender, e);
                    txtPassword.Clear();
                    txtUsername.Clear();
                    cmbAdmin.Text = "";
                }
            }
            catch (Exception f) 
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(AccessString);

            string username = txtDelUserName.Text;


            try
            {
                if (username == "" || username == null)
                {
                    MessageBox.Show("Please enter a valid username");
                }
                else 
                {
                    SqlCommand sda = new SqlCommand("DELETE FROM Users WHERE Username = '" + username + "'", con); //This works
                    con.Open();

                    sda.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User " + username + " has been deleted");
                    btnViewUsers_Click(sender, e);
                    txtDelUserName.Clear();
                }
                   
            }
            catch (Exception f)
            {
                MessageBox.Show("exception occured while creating table:" + f.Message + "\t" + f.GetType());
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
