namespace Test
{
    partial class FormTechnician
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
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(726, 586);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(150, 50);
            this.button_Refresh.TabIndex = 10;
            this.button_Refresh.Text = "Обновить";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(1038, 586);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(150, 50);
            this.button_Exit.TabIndex = 9;
            this.button_Exit.Text = "Выйти";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(882, 586);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(150, 50);
            this.button_Save.TabIndex = 7;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1176, 568);
            this.dataGridView1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 596);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(308, 33);
            this.comboBox1.TabIndex = 11;
            // 
            // FormTechnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 650);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(1231, 721);
            this.MinimumSize = new System.Drawing.Size(1231, 721);
            this.Name = "FormTechnician";
            this.Text = "FormTechnician";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTechnician_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}