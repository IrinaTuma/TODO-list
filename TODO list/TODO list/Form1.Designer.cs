namespace TODO_list
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUrgent = new System.Windows.Forms.Label();
            this.lbImportant = new System.Windows.Forms.Label();
            this.lbNotUrgent = new System.Windows.Forms.Label();
            this.lbNotImportant = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridImportantUrgent = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImportantUrgent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1164, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eisenhowerin Matriisi (Tehtävien lista)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbUrgent
            // 
            this.lbUrgent.BackColor = System.Drawing.Color.Transparent;
            this.lbUrgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUrgent.Location = new System.Drawing.Point(260, 149);
            this.lbUrgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUrgent.Name = "lbUrgent";
            this.lbUrgent.Size = new System.Drawing.Size(285, 49);
            this.lbUrgent.TabIndex = 1;
            this.lbUrgent.Text = "kiirellistä";
            this.lbUrgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbImportant
            // 
            this.lbImportant.BackColor = System.Drawing.Color.Transparent;
            this.lbImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImportant.Location = new System.Drawing.Point(172, 149);
            this.lbImportant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbImportant.Name = "lbImportant";
            this.lbImportant.Size = new System.Drawing.Size(108, 269);
            this.lbImportant.TabIndex = 2;
            this.lbImportant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbImportant.Paint += new System.Windows.Forms.PaintEventHandler(this.lbImportant_Paint);
            // 
            // lbNotUrgent
            // 
            this.lbNotUrgent.BackColor = System.Drawing.Color.Transparent;
            this.lbNotUrgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotUrgent.Location = new System.Drawing.Point(618, 149);
            this.lbNotUrgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNotUrgent.Name = "lbNotUrgent";
            this.lbNotUrgent.Size = new System.Drawing.Size(285, 49);
            this.lbNotUrgent.TabIndex = 3;
            this.lbNotUrgent.Text = "ei kiirellistä";
            this.lbNotUrgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNotImportant
            // 
            this.lbNotImportant.BackColor = System.Drawing.Color.Transparent;
            this.lbNotImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotImportant.Location = new System.Drawing.Point(172, 465);
            this.lbNotImportant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNotImportant.Name = "lbNotImportant";
            this.lbNotImportant.Size = new System.Drawing.Size(108, 274);
            this.lbNotImportant.TabIndex = 4;
            this.lbNotImportant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNotImportant.Paint += new System.Windows.Forms.PaintEventHandler(this.lbNotImportant_Paint);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(267, 611);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(312, 26);
            this.textBoxTitle.TabIndex = 5;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(269, 558);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(297, 50);
            this.lbTitle.TabIndex = 8;
            this.lbTitle.Text = "otsikko";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Transparent;
            this.btnDelete.Location = new System.Drawing.Point(809, 597);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 49);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "poistaa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Transparent;
            this.btnAdd.Location = new System.Drawing.Point(625, 597);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 49);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "lisätä";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // dataGridImportantUrgent
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridImportantUrgent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridImportantUrgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridImportantUrgent.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dataGridImportantUrgent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridImportantUrgent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridImportantUrgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridImportantUrgent.ColumnHeadersVisible = false;
            this.dataGridImportantUrgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridImportantUrgent.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridImportantUrgent.EnableHeadersVisualStyles = false;
            this.dataGridImportantUrgent.GridColor = System.Drawing.Color.White;
            this.dataGridImportantUrgent.Location = new System.Drawing.Point(298, 227);
            this.dataGridImportantUrgent.Name = "dataGridImportantUrgent";
            this.dataGridImportantUrgent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridImportantUrgent.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridImportantUrgent.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridImportantUrgent.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridImportantUrgent.RowTemplate.Height = 28;
            this.dataGridImportantUrgent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridImportantUrgent.Size = new System.Drawing.Size(299, 236);
            this.dataGridImportantUrgent.TabIndex = 13;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            // 
            // title
            // 
            this.title.HeaderText = "Title";
            this.title.MinimumWidth = 8;
            this.title.Name = "title";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1200, 886);
            this.Controls.Add(this.dataGridImportantUrgent);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.lbImportant);
            this.Controls.Add(this.lbNotImportant);
            this.Controls.Add(this.lbNotUrgent);
            this.Controls.Add(this.lbUrgent);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "ToDo list";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImportantUrgent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbUrgent;
        private System.Windows.Forms.Label lbImportant;
        private System.Windows.Forms.Label lbNotUrgent;
        private System.Windows.Forms.Label lbNotImportant;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridImportantUrgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
    }
}

