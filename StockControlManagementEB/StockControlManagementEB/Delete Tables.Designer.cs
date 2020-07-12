namespace StockControlManagementEB
{
    partial class Delete_Tables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTableDeleteName = new System.Windows.Forms.TextBox();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.btnViewTable = new System.Windows.Forms.Button();
            this.btnViewTableData = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTableDeleteName
            // 
            this.txtTableDeleteName.Location = new System.Drawing.Point(629, 84);
            this.txtTableDeleteName.Name = "txtTableDeleteName";
            this.txtTableDeleteName.Size = new System.Drawing.Size(159, 20);
            this.txtTableDeleteName.TabIndex = 16;
            this.txtTableDeleteName.TextChanged += new System.EventHandler(this.txtTableDeleteName_TextChanged);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(713, 118);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTable.TabIndex = 15;
            this.btnDeleteTable.Text = "Delete table";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(809, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 23);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(174, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(449, 249);
            this.dataGridView1.TabIndex = 38;
            // 
            // lstTables
            // 
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(12, 57);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(156, 212);
            this.lstTables.TabIndex = 39;
            this.lstTables.SelectedIndexChanged += new System.EventHandler(this.lstTables_SelectedIndexChanged);
            this.lstTables.DoubleClick += new System.EventHandler(this.lstTables_DoubleClick);
            // 
            // btnViewTable
            // 
            this.btnViewTable.Location = new System.Drawing.Point(12, 283);
            this.btnViewTable.Name = "btnViewTable";
            this.btnViewTable.Size = new System.Drawing.Size(75, 23);
            this.btnViewTable.TabIndex = 40;
            this.btnViewTable.Text = "View Tables";
            this.btnViewTable.UseVisualStyleBackColor = true;
            this.btnViewTable.Click += new System.EventHandler(this.btnViewTable_Click);
            // 
            // btnViewTableData
            // 
            this.btnViewTableData.Location = new System.Drawing.Point(629, 118);
            this.btnViewTableData.Name = "btnViewTableData";
            this.btnViewTableData.Size = new System.Drawing.Size(75, 23);
            this.btnViewTableData.TabIndex = 41;
            this.btnViewTableData.Text = "View Table";
            this.btnViewTableData.UseVisualStyleBackColor = true;
            this.btnViewTableData.Click += new System.EventHandler(this.btnViewTableData_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(93, 283);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 42;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Enter Table Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "label2";
            // 
            // Delete_Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnViewTableData);
            this.Controls.Add(this.btnViewTable);
            this.Controls.Add(this.lstTables);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTableDeleteName);
            this.Controls.Add(this.btnDeleteTable);
            this.Name = "Delete_Tables";
            this.Text = "Delete_Tables";
            this.Load += new System.EventHandler(this.Delete_Tables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTableDeleteName;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.Button btnViewTable;
        private System.Windows.Forms.Button btnViewTableData;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}