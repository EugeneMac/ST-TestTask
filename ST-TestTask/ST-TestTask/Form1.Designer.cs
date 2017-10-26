namespace ST_TestTask
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
            this.Employees = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Startdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wagerate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Head = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subordinates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Employees)).BeginInit();
            this.SuspendLayout();
            // 
            // Employees
            // 
            this.Employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Employees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Name,
            this.Lastname,
            this.Startdate,
            this.Wagerate,
            this.Wage,
            this.Group,
            this.Head,
            this.Subordinates});
            this.Employees.Location = new System.Drawing.Point(12, 49);
            this.Employees.Name = "Employees";
            this.Employees.Size = new System.Drawing.Size(899, 150);
            this.Employees.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // Name
            // 
            this.Name.HeaderText = "NAME";
            this.Name.Name = "Name";
            // 
            // Lastname
            // 
            this.Lastname.HeaderText = "LASTNAME";
            this.Lastname.Name = "Lastname";
            // 
            // Startdate
            // 
            this.Startdate.HeaderText = "START DATE";
            this.Startdate.Name = "Startdate";
            // 
            // Wagerate
            // 
            this.Wagerate.HeaderText = "WAGE RATE";
            this.Wagerate.Name = "Wagerate";
            // 
            // Wage
            // 
            this.Wage.HeaderText = "WAGE";
            this.Wage.Name = "Wage";
            this.Wage.ReadOnly = true;
            // 
            // Group
            // 
            this.Group.HeaderText = "GROUP";
            this.Group.Name = "Group";
            // 
            // Head
            // 
            this.Head.HeaderText = "HEAD";
            this.Head.Name = "Head";
            // 
            // Subordinates
            // 
            this.Subordinates.HeaderText = "SUBORDINATES";
            this.Subordinates.Name = "Subordinates";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employees:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Employees);
            this.Name = "Form1";
            this.Text = "ST-TestTask";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Employees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Employees;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Startdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wagerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Head;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subordinates;
        private System.Windows.Forms.Label label1;
    }
}

