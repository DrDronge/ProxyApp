namespace ProxyApp
{
    partial class AddBlockedForm
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
            this.DomainName = new System.Windows.Forms.Label();
            this.domainNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.AddBlockedAdd = new System.Windows.Forms.Button();
            this.AddBlockedCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DomainName
            // 
            this.DomainName.AutoSize = true;
            this.DomainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DomainName.Location = new System.Drawing.Point(12, 36);
            this.DomainName.Name = "DomainName";
            this.DomainName.Size = new System.Drawing.Size(82, 20);
            this.DomainName.TabIndex = 0;
            this.DomainName.Text = "Domæne*";
            // 
            // domainNameTextBox
            // 
            this.domainNameTextBox.Location = new System.Drawing.Point(131, 36);
            this.domainNameTextBox.Name = "domainNameTextBox";
            this.domainNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.domainNameTextBox.TabIndex = 1;
            this.domainNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(254, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(131, 81);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(100, 20);
            this.categoryTextBox.TabIndex = 5;
            // 
            // AddBlockedAdd
            // 
            this.AddBlockedAdd.Location = new System.Drawing.Point(199, 194);
            this.AddBlockedAdd.Name = "AddBlockedAdd";
            this.AddBlockedAdd.Size = new System.Drawing.Size(75, 23);
            this.AddBlockedAdd.TabIndex = 6;
            this.AddBlockedAdd.Text = "Tilføj";
            this.AddBlockedAdd.UseVisualStyleBackColor = true;
            this.AddBlockedAdd.Click += new System.EventHandler(this.AddBlockedAdd_Click);
            // 
            // AddBlockedCancel
            // 
            this.AddBlockedCancel.Location = new System.Drawing.Point(118, 194);
            this.AddBlockedCancel.Name = "AddBlockedCancel";
            this.AddBlockedCancel.Size = new System.Drawing.Size(75, 23);
            this.AddBlockedCancel.TabIndex = 7;
            this.AddBlockedCancel.Text = "Annuller";
            this.AddBlockedCancel.UseVisualStyleBackColor = true;
            this.AddBlockedCancel.Click += new System.EventHandler(this.AddBlockedCancel_Click);
            // 
            // AddBlockedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(286, 229);
            this.Controls.Add(this.AddBlockedCancel);
            this.Controls.Add(this.AddBlockedAdd);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.domainNameTextBox);
            this.Controls.Add(this.DomainName);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddBlockedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddBlockedForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DomainName;
        private System.Windows.Forms.TextBox domainNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Button AddBlockedAdd;
        private System.Windows.Forms.Button AddBlockedCancel;
    }
}