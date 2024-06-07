namespace VALIDATION2
{
    partial class Form5
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
            textBox1 = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(190, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 23);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(419, 25);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "SEARCH";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(28, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(156, 23);
            comboBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(466, 303);
            dataGridView1.TabIndex = 3;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 380);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
    }
}