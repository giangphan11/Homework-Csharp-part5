namespace HocDataGridView
{
    partial class Form1
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
            this.gvContact = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).BeginInit();
            this.SuspendLayout();
            // 
            // gvContact
            // 
            this.gvContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvContact.Location = new System.Drawing.Point(85, 55);
            this.gvContact.Name = "gvContact";
            this.gvContact.RowHeadersWidth = 51;
            this.gvContact.RowTemplate.Height = 24;
            this.gvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvContact.Size = new System.Drawing.Size(598, 324);
            this.gvContact.TabIndex = 0;
            this.gvContact.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvContact_CellClick);
            this.gvContact.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvContact_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gvContact);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvContact;
    }
}

