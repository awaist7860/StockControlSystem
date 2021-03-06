﻿using System;
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
//using System.Reflection;
//using Microsoft.Office.Interop.Excel;

namespace StockControlManagementEB
{
    public partial class ImportingData : Form
    {


        string AccessString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;  //Connection String

        DataTable dt = new DataTable();
        DataTable newDT = new DataTable();

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

            //ImportDataFromExcel(); //Put back in later if needed
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
                                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + "; Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
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
                                        
                                        adp.Fill(dt);
                                        newDT = dt;

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
                    //MessageBox.Show("Problem is " + exception.ToString());
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[comboBox1.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
            lblFiileName.Text = comboBox1.Text;
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
                string FolderPath = @"C:\Users\awais\OneDrive\Desktop\ExcelTest\";

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

        private void button2_Click(object sender, EventArgs e)
        {
            //Workbook workbook = new Workbook();

            Printing printing = new Printing();
            printing.PrintingExcelMethod(textBox1.Text);
        }

        private void btnTestImport_Click(object sender, EventArgs e)
        {

            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"C:\Log\";

            SqlConnection con = new SqlConnection(AccessString);

            try
            {
                con.Open();
                string ConStr;
                string HDR;
                HDR = "YES";
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Database=C:\\Users\awais\\OneDrive\\Desktop\\ExcelTest.xlsx';Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";
                //OleDbConnection cnn = new OleDbConnection(ConStr);


                //Dynamic sql, with paramets

                string filepath = @"Excel 14.0;Data Source=C:\\Users\\awais\\OneDrive\\Desktop\\ExcelTest\\Test$Data1.xlsx;"; //Remember to change back
                //string filepath = @"Excel 12.0;Data Source=C:\Users\thereTest$Data1.xlsx;";
                string oledbType = "Microsoft.ACE.OLEDB.14.0";
                string querySheet = "SELECT * FROM [Awais1]";
                string query = "SELECT * FROM [Awais1]";

                string exportQuery = @"
                declare @sql nvarchar(max) = '
                    SELECT* INTO Your_Table FROM OPENROWSET(
                    ' + quotename(@oledbType,'''') + '
                    ,' + quotename(@filepath,'''') + '
                    , ' + quotename(@querySheet,'''') + '
                    )' +
                    @query + ';'
                exec (@sql)
                ";

                SqlCommand cmd = new SqlCommand(exportQuery, con);
                cmd.Parameters.AddWithValue("@filepath", filepath);
                cmd.Parameters.AddWithValue("@oledbType", oledbType);
                cmd.Parameters.AddWithValue("@querySheet", querySheet);
                cmd.Parameters.AddWithValue("@query", query);

                cmd.ExecuteNonQuery();
                con.Close();

                //Old
                //SqlCommand sda = new SqlCommand();
                //sda.Connection = con;
                //sda.CommandType = CommandType.Text;
                //sda.CommandText = "SELECT* INTO Your_Table FROM OPENROWSET('Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\awais\\OneDrive\\Desktop\\ExcelTest\\Test$Data1.xlsx;', 'SELECT * FROM [Data$]')";
                //SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sda);

                //SqlCommand sda = new SqlCommand("SELECT * INTO Your_Table FROM OPENROWSET ('Microsoft.ACE.OLEDB.12.0','Excel 12.0;Database=C:\\Users\\awais\\OneDrive\\Desktop\\ExcelTest\\Test$Data1.xlsx')", con); //This works
                //,('SELECT * FROM [Data$]')
                //

                //Old
                //sda.ExecuteNonQuery();
                //con.Close();
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

        private void btnBrowse2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(AccessString);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())//{ Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls "})
            {

                try
                {



                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        textBox2.Text = openFileDialog.FileName;
                        
                            //string constr = "Provider = Microsoft.ACE.OLEDB.$.0; Data Source =" + textBox1.Text + "; Extended Properties =\"Exel 8.0; HDR=Yes;\";";
                            string ConStr;
                            string HDR;
                            HDR = "YES";
                            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";
                            OleDbConnection conn = new OleDbConnection(ConStr);
                            //lblFiileName.Text = textBox2.Text;
                            OleDbDataAdapter sda = new OleDbDataAdapter("Select * from [" + lblFiileName.Text + "$]", conn);

                            

                            //OleDbConnection cnn = new OleDbConnection(ConStr);
                        
                    }
                }
                catch (Exception f) 
                {
                    MessageBox.Show("Error is: " + f);
                }
            }
        }

        private void cmbSheetName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cmbSheetName2.SelectedItem.ToString()];
            dataGridView2.DataSource = dt;
            lblFiileName.Text = cmbSheetName2.Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Log file
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"C:\Log\";

            //ImportDataFromExcel(); //Put back in later if needed
            SqlConnection con = new SqlConnection(AccessString);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())//{ Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls "})
            {
                try
                {



                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        textBox2.Text = openFileDialog.FileName;
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
                                cmbSheetName2.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    cmbSheetName2.Items.Add(table.TableName);
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
                                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + "; Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
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

        private void button4_Click(object sender, EventArgs e)
        {
            //the datetime and Log folder will be used for error log file in case error occured
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"C:\Log\";
            try
            {
                //Provide the folder path where excel files are present
                String FolderPath = @"C:\Source\";
                String TableName = "";
                //Provide the schema for tables in which we want to load Excel files
                String SchemaName = "dbo";
                //Provide the Database Name in which table or view exists
                string DatabaseName = "TechbrothersIT";
                //Provide the SQL Server Name 
                string SQLServerName = "(local)";


                //Create Connection to SQL Server Database to import Excel file's data
                SqlConnection SQLConnection = new SqlConnection();
                SQLConnection.ConnectionString = "Data Source = "
                    + SQLServerName + "; Initial Catalog ="
                    + DatabaseName + "; "
                    + "Integrated Security=true;";

                var directory = new DirectoryInfo(FolderPath);
                FileInfo[] files = directory.GetFiles();

                //Declare and initilize variables
                string fileFullPath = "";

                //Get one Book(Excel file at a time)
                foreach (FileInfo file in files)
                {
                    fileFullPath = FolderPath + "\\" + file.Name;

                    //Create Excel Connection
                    string ConStr;
                    string HDR;
                    HDR = "YES";
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileFullPath
                        + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
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
                            TableName = sheetname.Replace("$", "");

                            //Load the DataTable with Sheet Data so we can get the column header
                            OleDbCommand oconn = new OleDbCommand("select top 1 * from [" + sheetname + "]", cnn);
                            OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            cnn.Close();

                            //Prepare Header columns list so we can run against Database to get matching columns for a table.
                            //If columns does not exists in table, it will ignore and load only matching columns data
                            string ExcelHeaderColumn = "";
                            string SQLQueryToGetMatchingColumn = "";
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (i != dt.Columns.Count - 1)
                                    ExcelHeaderColumn += "'" + dt.Columns[i].ColumnName + "'" + ",";
                                else
                                    ExcelHeaderColumn += "'" + dt.Columns[i].ColumnName + "'";
                            }

                            SQLQueryToGetMatchingColumn = "select STUFF((Select  ',['+Column_Name+']' from Information_schema.Columns where Table_Name='" +
                                TableName + "' and Table_SChema='" + SchemaName + "'" +
                                "and Column_Name in (" + @ExcelHeaderColumn + ") for xml path('')),1,1,'') AS ColumnList";


                            //Get Matching Column List from SQL Server
                            string SQLColumnList = "";
                            SqlCommand cmd = SQLConnection.CreateCommand();
                            cmd.CommandText = SQLQueryToGetMatchingColumn;
                            SQLConnection.Open();
                            SQLColumnList = (string)cmd.ExecuteScalar();
                            SQLConnection.Close();


                            //Use Actual Matching Columns to get data from Excel Sheet
                            OleDbConnection cnn1 = new OleDbConnection(ConStr);
                            cnn1.Open();
                            OleDbCommand oconn1 = new OleDbCommand("select " + SQLColumnList + " from [" + sheetname + "]", cnn1);
                            OleDbDataAdapter adp1 = new OleDbDataAdapter(oconn1);
                            DataTable dt1 = new DataTable();
                            adp1.Fill(dt1);
                            cnn1.Close();


                            //Delete the row if all values are nulll
                            int columnCount = dt1.Columns.Count;
                            for (int i = dt1.Rows.Count - 1; i >= 0; i--)
                            {
                                bool allNull = true;
                                for (int j = 0; j < columnCount; j++)
                                {
                                    if (dt1.Rows[i][j] != DBNull.Value)
                                    {
                                        allNull = false;
                                    }
                                }
                                if (allNull)
                                {
                                    dt1.Rows[i].Delete();
                                }
                            }
                            dt1.AcceptChanges();


                            //Load Data from DataTable to SQL Server Table.
                            SQLConnection.Open();
                            using (SqlBulkCopy BC = new SqlBulkCopy(SQLConnection))
                            {
                                BC.DestinationTableName = SchemaName + "." + TableName;
                                foreach (var column in dt1.Columns)
                                    BC.ColumnMappings.Add(column.ToString(), column.ToString());
                                BC.WriteToServer(dt1);
                            }
                            SQLConnection.Close();

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

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = @"c:\";
            fdlg.FileName = textBox2.Text;
            fdlg.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)//Almost works
            {
                textBox2.Text = fdlg.FileName;
                string ConStr;
                string HDR;
                HDR = "YES";
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox2.Text + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";
                OleDbConnection conn = new OleDbConnection(ConStr);
                //lblFiileName.Text = textBox2.Text;
                OleDbDataAdapter sda = new OleDbDataAdapter("Select * from [" + textBox2.Text + "$]", conn);
                //DataTable dt = tableCollection[cmbSheetName2.SelectedItem.ToString()];
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                lblFiileName.Text = cmbSheetName2.Text;
                //Import();
                //Application.DoEvents();
            }
        }

        private void btnImport2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AccessString);
            SqlCommand cmd = new SqlCommand("CREATE Table ExcelTableColour(Column1, Column2) VALUES (@C1, @C2)", con);
            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@C2", SqlDbType.VarChar));
            con.Open();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    cmd.Parameters["@C1"].Value = row.Cells[0].Value;
                    cmd.Parameters["@C2"].Value = row.Cells[1].Value;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception f)
                    {
                        MessageBox.Show("Problem is " + f.ToString());
                    }
                }
            }
            con.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnFinalTest_Click(object sender, EventArgs e)
        {

            string CreateTableSQL1;
            string CreateTableSQL2;
            //string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string LogFolder = @"C:\Log\";  //Log file
            string tableName;
            string strPath;

            CreateTable createTable = new CreateTable();    //Creates a createTable Object from the class
            DataTable data = (DataTable)(dataGridView1.DataSource); //Gives the datatable the data from the datagridViews

            strPath = textBox1.Text;
            string filename = Path.GetFileNameWithoutExtension(strPath);
            //tableName = filename.ToString();

            //MessageBox.Show("Filename is: " + filename);
            //This is a long work around to get a proper string, need to make it smaller
            label1.Text = filename;
            tableName = label1.Text;
            tableName = tableName.Replace(" ", "_");
            //tableName = tableName + "_" + comboBox1.Text;
            MessageBox.Show("Filename is: " + tableName);



            //MessageBox.Show(createTable.CreateTABLE(tableName, data));   //Calls the CreateTable method from the class and gives it the 2 parameters, first one is a string for the name and the second one is a datatable with the data
            MessageBox.Show(createTable.GetCreateTableSql(data, tableName));   //Calls the GetCreateTableSql method from the class and gives it a parameter, which is a datatable with the data

            //Giving the varaibles the sql command to be later run
            //CreateTableSQL1 = createTable.CreateTABLE(tableName, data);
            CreateTableSQL2 = createTable.GetCreateTableSql(data, tableName);

            //This is the log file being created
            //using (StreamWriter sw = File.CreateText(LogFolder + "\\" + "ErrorLog_" + datetime + ".log"))
            //{
                //sw.WriteLine("This is sql query with no primary keys or datatypes: " + CreateTableSQL1);
                //sw.WriteLine("This is sql query with primary keys and datatypes: " + CreateTableSQL2);
            //}

            //Sql command that is being run
            //This command creates  a table
            SqlConnection con = new SqlConnection(AccessString);
            con.Open();
            SqlCommand cmd = new SqlCommand(CreateTableSQL2, con);
            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            //I assume you have created the table previously
            //Someone else here already showed how  
            bulkcopy.DestinationTableName = tableName.ToString();
            try
            {
                bulkcopy.WriteToServer(data);
            }
            catch (Exception f)
            {
                MessageBox.Show("Error is: " + f);
            }
            con.Close();


        }


       

        
    }
}
