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


namespace StockControlManagementEB
{
    public partial class Login : Form
    {
        //Redo this when making the database on the public network
        //SqlConnection con = new SqlConnection("Data Source=ip\\AWAISSQLEXPRESS;Initial Catalog=ImperialBeddingStockDatabase;Persist Security Info=True;User ID=SA;Password=");         //public addapter
        SqlConnection con = new SqlConnection("Data Source=ip\\AWAISSQLEXPRESS;Initial Catalog=ImperialBeddingStockDatabase;Persist Security Info=True;User ID=SA;Password=");

        public Login()
        {
            InitializeComponent();
        }

        //private string access = "";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            nextPageCheck();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        public void nextPageCheck()
        {
            try
            {
                //startConnection();
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users WHERE Username = '" + txtUserName.Text + "' AND Password = '" + txtPassword.Text + "' AND AdminAccess = 'Yes'", con);
                con.Close();
                con.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * FROM Users WHERE Username = '" + txtUserName.Text + "' AND Password = '" + txtPassword.Text + "' AND AdminAccess = 'No'", con);
                con.Close();
                //SqlDataAdapter sda2 = new SqlDataAdapter("SELECT AdminAccess FROM Users WHERE AdminUsers = 'Yes'", con);

                //string sql = ("SELECT AdminAccess FROM USers WHERE AdminUsers = 'Yes'");



                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                sda.Fill(dt);
                sda2.Fill(dt2);

                //if ()
                //{
                //if (dt.Columns.Equals("AdminAccess"))
                //{
                //AdminMenu admin = new AdminMenu();
                // admin.Show();
                // }
                //   else if (dt.Rows.Equals("No"))
                //   {
                //       NormalUserMenu normal = new NormalUserMenu();
                //     normal.Show();
                //   }

                // }

                //string ColumnName = dt[AdminAccess].toString();

                if (dt.Rows.Count == 1)
                {

                    this.Hide();
                    //HomePage homePage = new HomePage();
                    //homePage.Show();
                    AdminMenu admin = new AdminMenu();
                    admin.Show();
                    
                }
                else if (dt2.Rows.Count == 1)
                {
                    this.Hide();
                    NormalUserMenu normal = new NormalUserMenu();
                    normal.Show();
                }
                else
                {
                    MessageBox.Show("You entered a wrong username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception f) 
            {
                MessageBox.Show("exception occured while accessing the database:" + f.Message + "\t" + f.GetType());
            }
        }

        public void startConnection() 
        {
            //+ access);
        }

    }
}
