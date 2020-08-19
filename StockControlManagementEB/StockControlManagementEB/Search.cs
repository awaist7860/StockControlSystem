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
    public partial class Search : Form
    {

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String
        DataTable dt;

        public Search()
        {
            InitializeComponent();
        }

        void fillCombo()
        {
            SqlConnection con = new SqlConnection(AccessString);
            SqlCommand cmdDataBase = new SqlCommand("SELECT * FROM information_schema.columns WHERE", con);
            SqlDataReader myReader;
            try
            {
                con.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sName = myReader.GetString("TABLE_NAME");

                    comboBox1.Items.add(sName);
                }
                
            }
            catch(Exception f)
            {
                MessageBox.Show("Error is: " + f);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            string searchCriteria = "ImperialBeddingStockDatabase.dbo.";
            searchCriteria = searchCriteria + txtSearchName.Text;

            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from information_schema.columns where table_name = " + searchCriteria, con);// + searchCriteria, con);
                MessageBox.Show(searchCriteria);
                Console.WriteLine(searchCriteria);
                con.Close();

                

                DataTable dt = new DataTable();

                sda.Fill(dt);

                lstResult.DataSource = dt;
                MessageBox.Show("querry ran successfully");
            }
            catch(Exception f)
            {
                MessageBox.Show("Error is: " + f);
            }
        }

        private void btnPullAllColumns_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);

            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TABLE_SCHEMA ,TABLE_NAME,COLUMN_NAME,ORDINAL_POSITION,COLUMN_DEFAULT,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_PRECISION_RADIX,NUMERIC_SCALE,DATETIME_PRECISION FROM INFORMATION_SCHEMA.COLUMNS", con);// + searchCriteria, con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                //MessageBox.Show(searchCriteria);
                //Console.WriteLine(searchCriteria);
                con.Close();

            }
            catch(Exception f)
            {
                MessageBox.Show("Error is: " + f);
            }
        }

        void AutoCompleteText() 
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("TABLE_NAME LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
