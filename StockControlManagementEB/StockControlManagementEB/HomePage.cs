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
    public partial class HomePage : Form
    {
        private int childFormNumber = 0;
        //SqlConnection con = new SqlConnection("Data Source=86.19.74.48\\AWAISSQLEXPRESS;Initial Catalog=ImperialBeddingStockDatabase;Persist Security Info=True;User ID=SA;Password=Hamzah8378");     //Public adapter
        SqlConnection con = new SqlConnection("Data Source=192.168.0.104\\AWAISSQLEXPRESS;Initial Catalog=ImperialBeddingStockDatabase;Persist Security Info=True;User ID=SA;Password=Hamzah8378");


        public HomePage()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            //SqlDataAdapter sda = new SqlDataAdapter("CREATE TABLE '" + txtInput.Text + "'" , con);

            

            string tableName = txtInput.Text;
            //t arraySize = Convert.ToInt32(txtFieldsAmount.Text);
            //t[] array = new int[arraySize];
            //r (int i = 0; i < array.Length; i++) 
            //
                //Need to take user input from here
                //array[i] = 
            //


            try
            {
                //User can create their own table with their own table name
                SqlCommand sda = new SqlCommand("CREATE TABLE " + tableName + " (ProductID INTEGER PRIMARY KEY, ProductName varchar(50), ProductSize varchar(50), ProductColour varchar(50), ProductStyle varchar(50))", con); //This works
                con.Open();
                //sda.ExecuteNonQuery();
                sda.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception a) 
            {
                MessageBox.Show("exception occured while creating table:" + a.Message + "\t" + a.GetType());
            }
            
            // = ("CREATE TABLE TestInput (myId INTEGER PRIMARY KEY, myName CHAR(50))", con);
            MessageBox.Show("Table Created");
            //if (conn.State == ConnectionState.Open)
                //conn.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnViewAllTables_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlDataAdapter sda = new SqlDataAdapter("SELECT table_name FROM information_schema.tables WHERE table_type = 'base table'", con);
                //SqlDataAdapter sda = new SqlDataAdapter("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", con);
                //using (SqlDataAdapter reader = con.)
                //con.Open();
                //sda.ExecuteNonQuery();
                //DataTable dt = new DataTable();
                //DataTable t = con.GetSchema("Tables");
                //string table = dt.ToString();
                //sda.Fill(dt);
                //listBox1.Items.Add(t);
                //MessageBox.Show(table);
                //con.Close();

                //Boolean flag = true;

                con.Open();

                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Connection = con;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select table_name from information_schema.tables";

                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                listBox1.Items.Clear();
                //if (flag == true)
                //{
                    //listBox1.DataSource = dtRecord;
                    //flag = false;
                //}
                //else if(flag == false)
                //{
                    //listBox1.DataSource = null;
                    //listBox1.Items.Clear();
                    //flag = true;
                //}
                listBox1.DataSource = dtRecord;
                listBox1.DisplayMember = "TABLE_NAME";
                //listBox1.DataSource = null;
                con.Close();

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
        }

        

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {

            string tableName = txtTableDeleteName.Text;

            try
            {
                 //= txtTableDeleteName.Text;

                //if (listBox1.SelectedItems != null) 
                //{
                    //tableName = listBox1.SelectedItems.ToString();
                //}
                //else if(txtTableDeleteName.Text != "") 
                //{
                    //tableName = txtTableDeleteName.Text;
                //}
                

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                string selectedName = "";
                //selectedName = listBox1.SelectedItem.ToString();
                selectedName = listBox1.GetItemText(listBox1.SelectedItem);

                //var selected = new List<string>();
                //selectedName = listBox1.SelectedItems.Cast<string>().ToString();
                //label1.Text = selectedName;
                txtTableDeleteName.Text = selectedName; //label1.;
                txtViewTableName.Text = selectedName;
            }
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {

            string tableName2 = txtViewTableName.Text;

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM " + tableName2, con); //This works
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

        private void txtViewTableName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
