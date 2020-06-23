namespace StockControlManagementEB
{
    partial class AdminMenu
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
            this.btnTestForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUsersForm = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestForm
            // 
            this.btnTestForm.Location = new System.Drawing.Point(99, 259);
            this.btnTestForm.Name = "btnTestForm";
            this.btnTestForm.Size = new System.Drawing.Size(75, 23);
            this.btnTestForm.TabIndex = 1;
            this.btnTestForm.Text = "Test form";
            this.btnTestForm.UseVisualStyleBackColor = true;
            this.btnTestForm.Click += new System.EventHandler(this.btnTestForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Admin menu";
            // 
            // btnUsersForm
            // 
            this.btnUsersForm.Location = new System.Drawing.Point(99, 64);
            this.btnUsersForm.Name = "btnUsersForm";
            this.btnUsersForm.Size = new System.Drawing.Size(75, 23);
            this.btnUsersForm.TabIndex = 3;
            this.btnUsersForm.Text = "Users";
            this.btnUsersForm.UseVisualStyleBackColor = true;
            this.btnUsersForm.Click += new System.EventHandler(this.btnUsersForm_Click);
            // 
            // btnTables
            // 
            this.btnTables.Location = new System.Drawing.Point(99, 128);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(75, 23);
            this.btnTables.TabIndex = 4;
            this.btnTables.Text = "View Tables";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(242, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 470);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTables);
            this.Controls.Add(this.btnUsersForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestForm);
            this.Name = "AdminMenu";
            this.Text = "AdminMenu";
            this.Load += new System.EventHandler(this.AdminMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUsersForm;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnClose;
    }
}