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
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            


            SqlConnection con = new SqlConnection("Data Source=86.19.74.48\\AWAISSQLEXPRESS;Initial Catalog=ImperialBeddingStockDatabase;Persist Security Info=True;User ID=SA;Password=Hamzah8378");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Login WHERE Username = '"+txtUserName.Text+"' AND Password = '"+txtPassword.Text+"'", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                HomePage homePage = new HomePage();
                homePage.Show();
            }
            else 
            {
                MessageBox.Show("You entered a wrong username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
