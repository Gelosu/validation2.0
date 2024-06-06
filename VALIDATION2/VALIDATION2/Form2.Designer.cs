namespace VALIDATION2
{
    partial class Form2
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
            comboBox1 = new ComboBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            comboBox2 = new ComboBox();
            button5 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            button6 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(477, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(36, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(249, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(36, 45);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "UPLOAD";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.Black;
            checkBox1.Location = new Point(481, 44);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(74, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Validated";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(557, 45);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(97, 19);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "Not Validated";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(618, 280);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(35, 389);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Log Out";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(502, 389);
            button3.Name = "button3";
            button3.Size = new Size(151, 23);
            button3.TabIndex = 7;
            button3.Text = "NEW SEMESTER";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(421, 389);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 8;
            button4.Text = "LOGS";
            button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(291, 19);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 9;
            label1.Text = "COURSE";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(348, 15);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(123, 23);
            comboBox2.TabIndex = 10;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Location = new Point(36, 77);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 11;
            button5.Text = "REFRESH";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 77);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 12;
            label2.Text = "VALIDATED:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(393, 74);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(78, 23);
            textBox2.TabIndex = 13;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button6
            // 
            button6.Location = new Point(267, 389);
            button6.Name = "button6";
            button6.Size = new Size(148, 23);
            button6.TabIndex = 14;
            button6.Text = "COURSE MANAGEMENT";
            button6.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(477, 77);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 15;
            label3.Text = "NOT VALIDATED:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(575, 74);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(78, 23);
            textBox3.TabIndex = 16;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 424);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(button6);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private ComboBox comboBox2;
        private Button button5;
        private Label label2;
        private TextBox textBox2;
        private Button button6;
        private Label label3;
        private TextBox textBox3;
    }
}