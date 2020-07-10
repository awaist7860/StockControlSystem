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
    public partial class TablesMenu : Form
    {
        public TablesMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create_Tables create_Tables = new Create_Tables();
            create_Tables.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_or_Edit_Tables view_Or_Edit_Tables = new View_or_Edit_Tables();
            view_Or_Edit_Tables.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Tables delete_Tables = new Delete_Tables();
            delete_Tables.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }

        private void btnImportForm_Click(object sender, EventArgs e)
        {
            ImportingData importingData = new ImportingData();
            importingData.Show();
            this.Close();
        }

        private void TablesMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
