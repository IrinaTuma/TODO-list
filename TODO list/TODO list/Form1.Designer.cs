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
            this.label1 = new System.Windows.Forms.Label();
            this.lbUrgent = new System.Windows.Forms.Label();
            this.lbImportant = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNotImportant = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eisenhowerin Matriisi (Tehtävien lista)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbUrgent
            // 
            this.lbUrgent.BackColor = System.Drawing.Color.Transparent;
            this.lbUrgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUrgent.Location = new System.Drawing.Point(173, 97);
            this.lbUrgent.Name = "lbUrgent";
            this.lbUrgent.Size = new System.Drawing.Size(190, 32);
            this.lbUrgent.TabIndex = 1;
            this.lbUrgent.Text = "kiirellistä";
            this.lbUrgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbImportant
            // 
            this.lbImportant.BackColor = System.Drawing.Color.Transparent;
            this.lbImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImportant.Location = new System.Drawing.Point(115, 97);
            this.lbImportant.Name = "lbImportant";
            this.lbImportant.Size = new System.Drawing.Size(72, 175);
            this.lbImportant.TabIndex = 2;
            this.lbImportant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbImportant.Paint += new System.Windows.Forms.PaintEventHandler(this.lbImportant_Paint);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "ei kiirellistä";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNotImportant
            // 
            this.lbNotImportant.BackColor = System.Drawing.Color.Transparent;
            this.lbNotImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotImportant.Location = new System.Drawing.Point(115, 302);
            this.lbNotImportant.Name = "lbNotImportant";
            this.lbNotImportant.Size = new System.Drawing.Size(72, 178);
            this.lbNotImportant.TabIndex = 4;
            this.lbNotImportant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNotImportant.Paint += new System.Windows.Forms.PaintEventHandler(this.lbNotImportant_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.Controls.Add(this.lbImportant);
            this.Controls.Add(this.lbNotImportant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbUrgent);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ToDo list";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbUrgent;
        private System.Windows.Forms.Label lbImportant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNotImportant;
    }
}

