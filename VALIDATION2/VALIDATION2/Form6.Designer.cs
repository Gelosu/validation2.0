namespace VALIDATION2
{
    partial class Form6
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 31);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 0;
            label1.Text = "CREATE COURSE";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(52, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(252, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(52, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(252, 23);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 61);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "COURSE";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 105);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 4;
            label3.Text = "COURSE DESCRIPTION";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(126, 169);
            button1.Name = "button1";
            button1.Size = new Size(113, 23);
            button1.TabIndex = 5;
            button1.Text = "ADD COURSE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 216);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VALIDATION";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}