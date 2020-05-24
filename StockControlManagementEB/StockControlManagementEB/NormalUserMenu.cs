using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockControlManagementEB
{
    public partial class NormalUserMenu : Form
    {
        public NormalUserMenu()
        {
            InitializeComponent();
        }

        private void btnTestForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }
    }
}
