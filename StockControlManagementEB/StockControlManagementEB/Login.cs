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
using System.Windows.Input;

namespace StockControlManagementEB
{
    public partial class Login : Form
    {


        //Need to use using tags instead of just if statments to make sure the connection is closed afterwards.
        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String


        public Login()
        {
            InitializeComponent();
        }



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

            SqlConnection con = new SqlConnection(AccessString);
            //SqlConnection con = new SqlConnection("Data Source=192.168.0.202;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Hamzah_8378");
            //startConnection();

            try
            {
                //startConnection();
                //This now talks to the new micrsoft sql server on docker and talks with the SecurityLogins Database for sqcurity reasons
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SecurityLogins.dbo.UserLogIns WHERE userName = '" + txtUserName.Text + "' AND password = '" + txtPassword.Text + "' AND adminAccess = 'Yes'", con);
                con.Close();
                con.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * FROM SecurityLogins.dbo.UserLogIns WHERE userName = '" + txtUserName.Text + "' AND password = '" + txtPassword.Text + "' AND adminAccess = 'No'", con);
                con.Close();

                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                sda.Fill(dt);
                sda2.Fill(dt2);

                if (dt.Rows.Count == 1) //Checks if the user exists in the table and is a normal user or not
                {

                    this.Hide();
                    //HomePage homePage = new HomePage();
                    //homePage.Show();
                    AdminMenu admin = new AdminMenu();
                    admin.Show(); 
                    
                }
                else if (dt2.Rows.Count == 1)   //Checks if the user is in the table and is an admin or not
                {
                    this.Hide();
                    NormalUserMenu normal = new NormalUserMenu();
                    normal.Show();
                }
                else
                {
                    MessageBox.Show("You entered a wrong username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  //Tells the user if they ahgve entered a wrong username or password
                }
            }
            catch (Exception f) 
            {
                MessageBox.Show("exception occured while accessing the database:" + f.Message + "\t" + f.GetType());    //Tells the user what error has occured
            }
        }

        public void startConnection() 
        {
            //+ access);
            //SqlConnection con = new SqlConnection(AccessString);
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nextPageCheck();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nextPageCheck();
            }
        }
    }
}
