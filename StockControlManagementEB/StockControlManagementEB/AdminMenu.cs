﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace StockControlManagementEB
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void btnTestForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homepage = new HomePage();
            homepage.Show();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnUsersForm_Click(object sender, EventArgs e)
        {
            UsersFormAdmin usersFormAdmin = new UsersFormAdmin();
            usersFormAdmin.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            TablesMenu tablesMenu = new TablesMenu();
            tablesMenu.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
            this.Close();
        }
    }
}
