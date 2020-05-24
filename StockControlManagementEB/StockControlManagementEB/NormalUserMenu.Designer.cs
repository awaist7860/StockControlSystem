namespace StockControlManagementEB
{
    partial class NormalUserMenu
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
            this.SuspendLayout();
            // 
            // btnTestForm
            // 
            this.btnTestForm.Location = new System.Drawing.Point(93, 209);
            this.btnTestForm.Name = "btnTestForm";
            this.btnTestForm.Size = new System.Drawing.Size(75, 23);
            this.btnTestForm.TabIndex = 0;
            this.btnTestForm.Text = "Test form";
            this.btnTestForm.UseVisualStyleBackColor = true;
            this.btnTestForm.Click += new System.EventHandler(this.btnTestForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Normal User Menu";
            // 
            // NormalUserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestForm);
            this.Name = "NormalUserMenu";
            this.Text = "NormalUserMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestForm;
        private System.Windows.Forms.Label label1;
    }
}