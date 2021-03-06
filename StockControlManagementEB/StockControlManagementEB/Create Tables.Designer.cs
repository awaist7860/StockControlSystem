﻿namespace StockControlManagementEB
{
    partial class Create_Tables
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnViewAllTables = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnConfirmName = new System.Windows.Forms.Button();
            this.rtxtColumns = new System.Windows.Forms.RichTextBox();
            this.btnCol = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(625, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Table name";
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateTable.Location = new System.Drawing.Point(578, 164);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(90, 23);
            this.btnCreateTable.TabIndex = 20;
            this.btnCreateTable.Text = "Create Table";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 31);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 19;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(138, 354);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Reload";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnViewAllTables
            // 
            this.btnViewAllTables.Location = new System.Drawing.Point(12, 354);
            this.btnViewAllTables.Name = "btnViewAllTables";
            this.btnViewAllTables.Size = new System.Drawing.Size(120, 23);
            this.btnViewAllTables.TabIndex = 25;
            this.btnViewAllTables.Text = "View All Tables";
            this.btnViewAllTables.UseVisualStyleBackColor = true;
            this.btnViewAllTables.Click += new System.EventHandler(this.btnViewAllTables_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 206);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(560, 134);
            this.listBox1.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirmName
            // 
            this.btnConfirmName.Location = new System.Drawing.Point(118, 31);
            this.btnConfirmName.Name = "btnConfirmName";
            this.btnConfirmName.Size = new System.Drawing.Size(97, 23);
            this.btnConfirmName.TabIndex = 40;
            this.btnConfirmName.Text = "Confirm Name";
            this.btnConfirmName.UseVisualStyleBackColor = true;
            this.btnConfirmName.Click += new System.EventHandler(this.btnConfirmName_Click);
            // 
            // rtxtColumns
            // 
            this.rtxtColumns.Location = new System.Drawing.Point(12, 73);
            this.rtxtColumns.Name = "rtxtColumns";
            this.rtxtColumns.Size = new System.Drawing.Size(560, 114);
            this.rtxtColumns.TabIndex = 41;
            this.rtxtColumns.Text = "";
            // 
            // btnCol
            // 
            this.btnCol.Location = new System.Drawing.Point(578, 73);
            this.btnCol.Name = "btnCol";
            this.btnCol.Size = new System.Drawing.Size(90, 23);
            this.btnCol.TabIndex = 43;
            this.btnCol.Text = "Save Columns";
            this.btnCol.UseVisualStyleBackColor = true;
            this.btnCol.Click += new System.EventHandler(this.btnCol_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "View Other Tables";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Input Columns";
            // 
            // Create_Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 683);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCol);
            this.Controls.Add(this.rtxtColumns);
            this.Controls.Add(this.btnConfirmName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnViewAllTables);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnClose);
            this.Name = "Create_Tables";
            this.Text = "Create_Tables";
            this.Load += new System.EventHandler(this.Create_Tables_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnViewAllTables;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConfirmName;
        private System.Windows.Forms.RichTextBox rtxtColumns;
        private System.Windows.Forms.Button btnCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}