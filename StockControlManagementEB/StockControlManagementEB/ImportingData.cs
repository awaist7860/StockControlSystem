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
using System.IO;
using System.Data.OleDb;
using ExcelDataReader;

namespace StockControlManagementEB
{
    public partial class ImportingData : Form
    {

        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String

        public ImportingData()
        {
            InitializeComponent();
        }

        private void ImportingData_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TablesMenu tablesMenu = new TablesMenu();
            tablesMenu.Show();
            this.Close();
        }

        DataTableCollection tableCollection;

        private void button1_Click(object sender, EventArgs e)
        {
            //Log file
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"C:\Log\";

            ImportDataFromExcel();
            SqlConnection con = new SqlConnection(AccessString);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())//{ Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls "})
            {
                try
                {



                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = openFileDialog.FileName;
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true
                                    }
                                });
                                tableCollection = result.Tables;
                                comboBox1.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    comboBox1.Items.Add(table.TableName);
                            }

                            //string FolderPath = textBox1.Text;

                            string FolderPath = @"C:\Users\awais\OneDrive\Desktop";

                            var directory = new DirectoryInfo(FolderPath);
                            FileInfo[] files = directory.GetFiles();


                            string fileFullPath = "";

                            foreach (FileInfo file in files)
                            {
                                string filename = "";
                                fileFullPath = FolderPath + "\\" + file.Name;
                                filename = file.Name.Replace(".xlsx", "");

                                //Create excel connection
                                string ConStr;
                                string HDR;
                                HDR = "YES";
                                //ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileFullPath
                                //+ ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";

                                //ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;";
                                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename+ "; Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
                                OleDbConnection cnn = new OleDbConnection(ConStr);

                                cnn.Open();
                                DataTable dtSheet = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetname;
                                sheetname = "";
                                foreach (DataRow drSheet in dtSheet.Rows)
                                {
                                    if (drSheet["Table_Name"].ToString().Contains("$"))
                                    {
                                        sheetname = drSheet["Table_Name"].ToString();

                                        OleDbCommand oconn = new OleDbCommand("SELECT * FROM [" + sheetname + "]", cnn);
                                        OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                                        DataTable dt = new DataTable();
                                        adp.Fill(dt);

                                        sheetname = sheetname.Replace("$", ""); //I can replace it with any value, currently it is no value

                                        string tableDDL = "";
                                        tableDDL += "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = ";
                                        tableDDL += "OBJECT_ID(N'[dbo].[" + filename + "_" + sheetname + "]') AND type in (N'U'))";
                                        tableDDL += "Drop Table [dbo].[" + filename + "_" + sheetname + "]";
                                        tableDDL += "Create table [" + filename + "_" + sheetname + "]";
                                        tableDDL += "(";

                                        for (int i = 0; i < dt.Columns.Count; i++)
                                        {
                                            if (i != dt.Columns.Count - 1)
                                            {
                                                tableDDL += "[" + dt.Columns[i].ColumnName + "] " + "NVarchar(max)" + ",";
                                            }
                                            else
                                            {
                                                tableDDL += "[" + dt.Columns[i].ColumnName + "] " + "NVarchar(max)";
                                            }
                                        }
                                        tableDDL += ")";

                                        con.Open();
                                        SqlCommand sqlCMD = new SqlCommand(tableDDL, con);
                                        sqlCMD.ExecuteNonQuery();

                                        SqlBulkCopy blk = new SqlBulkCopy(con);
                                        blk.DestinationTableName = "[" + fileFullPath + "_" + sheetname + "]";
                                        blk.WriteToServer(dt);
                                        con.Close();

                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    // Create Log File for Errors
                    using (StreamWriter sw = File.CreateText(LogFolder
                    + "\\" + "ErrorLog_" + datetime + ".log"))
                    {
                    sw.WriteLine(exception.ToString());

                    }
                    MessageBox.Show("Problem is " + exception.ToString());
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[comboBox1.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
        }


        public void ImportDataFromExcel()//string excelFilePath) 
        {
            //string ssqltble = "table1";
            //string myExcelDirataQuery = 

            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string LogFolder = @"C:\Log\";
            try
            {
                //Provide the Source Folder path where excel files are present
                String FolderPath = @"C:\Users\awais\OneDrive\Desktop\ExcelTest\";
                
                //Provide the Database Name 
                //string DatabaseName = "TechbrothersIT";
                //Provide the SQL Server Name 
                //string SQLServerName = "(local)";


                //Create Connection to SQL Server Database 
                SqlConnection con = new SqlConnection(AccessString);

                var directory = new DirectoryInfo(FolderPath);
                FileInfo[] files = directory.GetFiles();

                //Declare and initilize variables
                string fileFullPath = "";

                //Get one Book(Excel file at a time)
                foreach (FileInfo file in files)
                {
                    string filename = "";
                    fileFullPath = FolderPath + "\\" + file.Name;
                    filename = file.Name.Replace(".xlsx", "");

                    //Create Excel Connection
                    string ConStr;
                    string HDR;
                    HDR = "YES";
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileFullPath
                        + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";
                    OleDbConnection cnn = new OleDbConnection(ConStr);


                    //Get Sheet Name
                    cnn.Open();
                    DataTable dtSheet = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetname;
                    sheetname = "";
                    foreach (DataRow drSheet in dtSheet.Rows)
                    {
                        if (drSheet["TABLE_NAME"].ToString().Contains("$"))
                        {
                            sheetname = drSheet["TABLE_NAME"].ToString();

                            //Load the DataTable with Sheet Data
                            OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", cnn);
                            OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);

                            //remove "$" from sheet name
                            sheetname = sheetname.Replace("$", "");

                            // Generate Create Table Script by using Header Column,
                            //It will drop the table if Exists and Recreate                  
                            string tableDDL = "";
                            tableDDL += "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = ";
                            tableDDL += "OBJECT_ID(N'[dbo].[" + filename + "_" + sheetname + "]') AND type in (N'U'))";
                            tableDDL += "Drop Table [dbo].[" + filename + "_" + sheetname + "]";
                            tableDDL += "Create table [" + filename + "_" + sheetname + "]";
                            tableDDL += "(";
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (i != dt.Columns.Count - 1)
                                    tableDDL += "[" + dt.Columns[i].ColumnName + "] " + "NVarchar(max)" + ",";
                                else
                                    tableDDL += "[" + dt.Columns[i].ColumnName + "] " + "NVarchar(max)";
                            }
                            tableDDL += ")";

                            con.Open();
                            SqlCommand SQLCmd = new SqlCommand(tableDDL, con);
                            SQLCmd.ExecuteNonQuery();

                            //Load the data from DataTable to SQL Server Table.
                            SqlBulkCopy blk = new SqlBulkCopy(con);
                            blk.DestinationTableName = "[" + filename + "_" + sheetname + "]";
                            blk.WriteToServer(dt);
                            con.Close();
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                // Create Log File for Errors
                //using (StreamWriter sw = File.CreateText(LogFolder
                //+ "\\" + "ErrorLog_" + datetime + ".log"))
                //{
                //sw.WriteLine(exception.ToString());

                //}
                MessageBox.Show("Problem is " + exception.ToString());
            }
        }

        
    }
}
