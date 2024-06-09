namespace VALIDATION2
{
    partial class Form3
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
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 21);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 0;
            label1.Text = "NEW SEMESTER";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(281, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(138, 120);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "NEW SEM";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F);
            label2.Location = new Point(36, 43);
            label2.Name = "label2";
            label2.Size = new Size(0, 12);
            label2.TabIndex = 3;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 162);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VALIDATION";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
    }
}