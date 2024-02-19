namespace typingspeedtest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Targetword = new System.Windows.Forms.Label();
            wordamount = new System.Windows.Forms.NumericUpDown();
            examplebutton = new System.Windows.Forms.Button();
            trueOrfalse = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            Titlelabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            randomwordmode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)wordamount).BeginInit();
            SuspendLayout();
            // 
            // Targetword
            // 
            Targetword.AutoSize = true;
            Targetword.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Targetword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            Targetword.Location = new System.Drawing.Point(12, 38);
            Targetword.Name = "Targetword";
            Targetword.Size = new System.Drawing.Size(535, 28);
            Targetword.TabIndex = 0;
            Targetword.Text = "Your sentence will generate here after you press the button...";
            // 
            // wordamount
            // 
            wordamount.Location = new System.Drawing.Point(566, 9);
            wordamount.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            wordamount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            wordamount.Name = "wordamount";
            wordamount.Size = new System.Drawing.Size(33, 23);
            wordamount.TabIndex = 1;
            wordamount.ThousandsSeparator = true;
            wordamount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            wordamount.Visible = false;
            // 
            // examplebutton
            // 
            examplebutton.Location = new System.Drawing.Point(99, 5);
            examplebutton.Name = "examplebutton";
            examplebutton.Size = new System.Drawing.Size(133, 23);
            examplebutton.TabIndex = 2;
            examplebutton.Text = "Generate sentence";
            examplebutton.UseVisualStyleBackColor = true;
            examplebutton.Click += examplebutton_Click;
            // 
            // trueOrfalse
            // 
            trueOrfalse.AutoSize = true;
            trueOrfalse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            trueOrfalse.Location = new System.Drawing.Point(12, 258);
            trueOrfalse.Name = "trueOrfalse";
            trueOrfalse.Size = new System.Drawing.Size(0, 19);
            trueOrfalse.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            textBox1.Location = new System.Drawing.Point(12, 203);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(587, 23);
            textBox1.TabIndex = 5;
            textBox1.WordWrap = false;
            textBox1.KeyDown += Form1_KeyDown;
            // 
            // Titlelabel
            // 
            Titlelabel.AutoSize = true;
            Titlelabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            Titlelabel.Location = new System.Drawing.Point(12, 9);
            Titlelabel.Name = "Titlelabel";
            Titlelabel.Size = new System.Drawing.Size(81, 15);
            Titlelabel.TabIndex = 6;
            Titlelabel.Text = "Target words";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 229);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(207, 19);
            label1.TabIndex = 7;
            label1.Text = "Press ENTER to check answer...";
            // 
            // randomwordmode
            // 
            randomwordmode.AutoSize = true;
            randomwordmode.Location = new System.Drawing.Point(484, 9);
            randomwordmode.Name = "randomwordmode";
            randomwordmode.Size = new System.Drawing.Size(76, 19);
            randomwordmode.TabIndex = 8;
            randomwordmode.Text = "Gibberish";
            randomwordmode.UseVisualStyleBackColor = true;
            randomwordmode.CheckedChanged += randomwordmode_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(634, 321);
            Controls.Add(randomwordmode);
            Controls.Add(label1);
            Controls.Add(Titlelabel);
            Controls.Add(textBox1);
            Controls.Add(trueOrfalse);
            Controls.Add(examplebutton);
            Controls.Add(wordamount);
            Controls.Add(Targetword);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "AS typingspeedtest";
            ((System.ComponentModel.ISupportInitialize)wordamount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label Targetword;
        private System.Windows.Forms.NumericUpDown wordamount;
        private System.Windows.Forms.Button examplebutton;
        private System.Windows.Forms.Label trueOrfalse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Titlelabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox randomwordmode;
    }
}
