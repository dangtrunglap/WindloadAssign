namespace WindloadAssign
{
    partial class WindAssign
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
            this.Label4 = new System.Windows.Forms.Label();
            this.TextBox5 = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.ComboBox5 = new System.Windows.Forms.ComboBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Define_Direction_Cbb = new System.Windows.Forms.ComboBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.RadioButton3 = new System.Windows.Forms.RadioButton();
            this.RadioButton4 = new System.Windows.Forms.RadioButton();
            this.RadioButton7 = new System.Windows.Forms.RadioButton();
            this.RadioButton6 = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBox5 = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CheckBox6 = new System.Windows.Forms.CheckBox();
            this.ComboBox4 = new System.Windows.Forms.ComboBox();
            this.CheckBox7 = new System.Windows.Forms.CheckBox();
            this.ComboBox3 = new System.Windows.Forms.ComboBox();
            this.CheckBox8 = new System.Windows.Forms.CheckBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CheckBox4 = new System.Windows.Forms.CheckBox();
            this.CheckBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.AssignLoadBtn = new System.Windows.Forms.Button();
            this.Del_Load_Btn = new System.Windows.Forms.Button();
            this.Assign_Sv_Data_Btn = new System.Windows.Forms.Button();
            this.Del_sv_Btn = new System.Windows.Forms.Button();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(22, 20);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 13);
            this.Label4.TabIndex = 61;
            this.Label4.Text = "Đang kết nối với mô hình";
            // 
            // TextBox5
            // 
            this.TextBox5.BackColor = System.Drawing.SystemColors.Control;
            this.TextBox5.Enabled = false;
            this.TextBox5.Location = new System.Drawing.Point(25, 36);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Size = new System.Drawing.Size(482, 20);
            this.TextBox5.TabIndex = 60;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Label3);
            this.GroupBox4.Controls.Add(this.ComboBox5);
            this.GroupBox4.Location = new System.Drawing.Point(296, 154);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(211, 58);
            this.GroupBox4.TabIndex = 59;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Delete Save Data";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(5, 22);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(56, 13);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "Chọn tầng";
            // 
            // ComboBox5
            // 
            this.ComboBox5.FormattingEnabled = true;
            this.ComboBox5.Location = new System.Drawing.Point(72, 19);
            this.ComboBox5.Name = "ComboBox5";
            this.ComboBox5.Size = new System.Drawing.Size(100, 21);
            this.ComboBox5.TabIndex = 4;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Define_Direction_Cbb);
            this.GroupBox2.Location = new System.Drawing.Point(296, 62);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(211, 55);
            this.GroupBox2.TabIndex = 58;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Define Direction";
            // 
            // Define_Direction_Cbb
            // 
            this.Define_Direction_Cbb.FormattingEnabled = true;
            this.Define_Direction_Cbb.Items.AddRange(new object[] {
            "1. Local 1 axis",
            "2. Local 2 axis",
            "3. Local 3 axis",
            "4. X direction",
            "5. Y direction",
            "6. Z direction",
            "7. Gravity direction"});
            this.Define_Direction_Cbb.Location = new System.Drawing.Point(10, 19);
            this.Define_Direction_Cbb.Name = "Define_Direction_Cbb";
            this.Define_Direction_Cbb.Size = new System.Drawing.Size(187, 21);
            this.Define_Direction_Cbb.TabIndex = 0;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.RadioButton3);
            this.GroupBox5.Controls.Add(this.RadioButton4);
            this.GroupBox5.Controls.Add(this.RadioButton7);
            this.GroupBox5.Controls.Add(this.RadioButton6);
            this.GroupBox5.Location = new System.Drawing.Point(190, 62);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(100, 150);
            this.GroupBox5.TabIndex = 57;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Xác định hướng gió";
            // 
            // RadioButton3
            // 
            this.RadioButton3.AutoSize = true;
            this.RadioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton3.Location = new System.Drawing.Point(17, 112);
            this.RadioButton3.Name = "RadioButton3";
            this.RadioButton3.Size = new System.Drawing.Size(80, 17);
            this.RadioButton3.TabIndex = 3;
            this.RadioButton3.TabStop = true;
            this.RadioButton3.Text = "Khuất gió Y";
            this.RadioButton3.UseVisualStyleBackColor = true;
            this.RadioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // RadioButton4
            // 
            this.RadioButton4.AutoSize = true;
            this.RadioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton4.Location = new System.Drawing.Point(17, 60);
            this.RadioButton4.Name = "RadioButton4";
            this.RadioButton4.Size = new System.Drawing.Size(72, 17);
            this.RadioButton4.TabIndex = 2;
            this.RadioButton4.TabStop = true;
            this.RadioButton4.Text = "Đón gió Y";
            this.RadioButton4.UseVisualStyleBackColor = true;
            this.RadioButton4.CheckedChanged += new System.EventHandler(this.RadioButton4_CheckedChanged);
            // 
            // RadioButton7
            // 
            this.RadioButton7.AutoSize = true;
            this.RadioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton7.Location = new System.Drawing.Point(17, 86);
            this.RadioButton7.Name = "RadioButton7";
            this.RadioButton7.Size = new System.Drawing.Size(80, 17);
            this.RadioButton7.TabIndex = 1;
            this.RadioButton7.TabStop = true;
            this.RadioButton7.Text = "Khuất gió X";
            this.RadioButton7.UseVisualStyleBackColor = true;
            this.RadioButton7.CheckedChanged += new System.EventHandler(this.RadioButton7_CheckedChanged);
            // 
            // RadioButton6
            // 
            this.RadioButton6.AutoSize = true;
            this.RadioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButton6.Location = new System.Drawing.Point(17, 34);
            this.RadioButton6.Name = "RadioButton6";
            this.RadioButton6.Size = new System.Drawing.Size(72, 17);
            this.RadioButton6.TabIndex = 0;
            this.RadioButton6.TabStop = true;
            this.RadioButton6.Text = "Đón gió X";
            this.RadioButton6.UseVisualStyleBackColor = true;
            this.RadioButton6.CheckedChanged += new System.EventHandler(this.RadioButton6_CheckedChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CheckBox5);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.CheckBox6);
            this.GroupBox1.Controls.Add(this.ComboBox4);
            this.GroupBox1.Controls.Add(this.CheckBox7);
            this.GroupBox1.Controls.Add(this.ComboBox3);
            this.GroupBox1.Controls.Add(this.CheckBox8);
            this.GroupBox1.Controls.Add(this.ComboBox2);
            this.GroupBox1.Controls.Add(this.ComboBox1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.CheckBox4);
            this.GroupBox1.Controls.Add(this.CheckBox3);
            this.GroupBox1.Controls.Add(this.CheckBox2);
            this.GroupBox1.Controls.Add(this.CheckBox1);
            this.GroupBox1.Location = new System.Drawing.Point(25, 62);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(159, 151);
            this.GroupBox1.TabIndex = 56;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Assign Load Patterns";
            // 
            // CheckBox5
            // 
            this.CheckBox5.AutoSize = true;
            this.CheckBox5.Location = new System.Drawing.Point(137, 114);
            this.CheckBox5.Name = "CheckBox5";
            this.CheckBox5.Size = new System.Drawing.Size(15, 14);
            this.CheckBox5.TabIndex = 43;
            this.CheckBox5.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(84, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "Name";
            // 
            // CheckBox6
            // 
            this.CheckBox6.AutoSize = true;
            this.CheckBox6.Location = new System.Drawing.Point(137, 88);
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Size = new System.Drawing.Size(15, 14);
            this.CheckBox6.TabIndex = 42;
            this.CheckBox6.UseVisualStyleBackColor = true;
            // 
            // ComboBox4
            // 
            this.ComboBox4.FormattingEnabled = true;
            this.ComboBox4.Location = new System.Drawing.Point(69, 110);
            this.ComboBox4.Name = "ComboBox4";
            this.ComboBox4.Size = new System.Drawing.Size(62, 21);
            this.ComboBox4.TabIndex = 28;
            // 
            // CheckBox7
            // 
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.Location = new System.Drawing.Point(137, 62);
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Size = new System.Drawing.Size(15, 14);
            this.CheckBox7.TabIndex = 41;
            this.CheckBox7.UseVisualStyleBackColor = true;
            // 
            // ComboBox3
            // 
            this.ComboBox3.FormattingEnabled = true;
            this.ComboBox3.Location = new System.Drawing.Point(69, 84);
            this.ComboBox3.Name = "ComboBox3";
            this.ComboBox3.Size = new System.Drawing.Size(62, 21);
            this.ComboBox3.TabIndex = 27;
            // 
            // CheckBox8
            // 
            this.CheckBox8.AutoSize = true;
            this.CheckBox8.Location = new System.Drawing.Point(137, 36);
            this.CheckBox8.Name = "CheckBox8";
            this.CheckBox8.Size = new System.Drawing.Size(15, 14);
            this.CheckBox8.TabIndex = 40;
            this.CheckBox8.UseVisualStyleBackColor = true;
            // 
            // ComboBox2
            // 
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Location = new System.Drawing.Point(69, 58);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(62, 21);
            this.ComboBox2.TabIndex = 26;
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(69, 32);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(62, 21);
            this.ComboBox1.TabIndex = 25;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(18, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(49, 13);
            this.Label2.TabIndex = 20;
            this.Label2.Text = "Negative";
            // 
            // CheckBox4
            // 
            this.CheckBox4.AutoSize = true;
            this.CheckBox4.Location = new System.Drawing.Point(38, 114);
            this.CheckBox4.Name = "CheckBox4";
            this.CheckBox4.Size = new System.Drawing.Size(15, 14);
            this.CheckBox4.TabIndex = 7;
            this.CheckBox4.UseVisualStyleBackColor = true;
            // 
            // CheckBox3
            // 
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.Location = new System.Drawing.Point(38, 87);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new System.Drawing.Size(15, 14);
            this.CheckBox3.TabIndex = 6;
            this.CheckBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Location = new System.Drawing.Point(38, 61);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(15, 14);
            this.CheckBox2.TabIndex = 5;
            this.CheckBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(38, 36);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(15, 14);
            this.CheckBox1.TabIndex = 4;
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // AssignLoadBtn
            // 
            this.AssignLoadBtn.Location = new System.Drawing.Point(375, 245);
            this.AssignLoadBtn.Name = "AssignLoadBtn";
            this.AssignLoadBtn.Size = new System.Drawing.Size(93, 41);
            this.AssignLoadBtn.TabIndex = 55;
            this.AssignLoadBtn.Text = "Assign ETABS";
            this.AssignLoadBtn.UseVisualStyleBackColor = true;
            this.AssignLoadBtn.Click += new System.EventHandler(this.AssignLoadBtn_Click);
            // 
            // Del_Load_Btn
            // 
            this.Del_Load_Btn.Location = new System.Drawing.Point(263, 245);
            this.Del_Load_Btn.Name = "Del_Load_Btn";
            this.Del_Load_Btn.Size = new System.Drawing.Size(93, 41);
            this.Del_Load_Btn.TabIndex = 54;
            this.Del_Load_Btn.Text = "Delete Load";
            this.Del_Load_Btn.UseVisualStyleBackColor = true;
            this.Del_Load_Btn.Click += new System.EventHandler(this.Del_Load_Btn_Click);
            // 
            // Assign_Sv_Data_Btn
            // 
            this.Assign_Sv_Data_Btn.Location = new System.Drawing.Point(137, 245);
            this.Assign_Sv_Data_Btn.Name = "Assign_Sv_Data_Btn";
            this.Assign_Sv_Data_Btn.Size = new System.Drawing.Size(93, 41);
            this.Assign_Sv_Data_Btn.TabIndex = 53;
            this.Assign_Sv_Data_Btn.Text = "Assign ETABS With Saved";
            this.Assign_Sv_Data_Btn.UseVisualStyleBackColor = true;
            this.Assign_Sv_Data_Btn.Click += new System.EventHandler(this.Assign_Sv_Data_Btn_Click);
            // 
            // Del_sv_Btn
            // 
            this.Del_sv_Btn.Location = new System.Drawing.Point(25, 245);
            this.Del_sv_Btn.Name = "Del_sv_Btn";
            this.Del_sv_Btn.Size = new System.Drawing.Size(93, 41);
            this.Del_sv_Btn.TabIndex = 52;
            this.Del_sv_Btn.Text = "Delete Saved";
            this.Del_sv_Btn.UseVisualStyleBackColor = true;
            this.Del_sv_Btn.Click += new System.EventHandler(this.Del_sv_Btn_Click);
            // 
            // WindAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 316);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.TextBox5);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.AssignLoadBtn);
            this.Controls.Add(this.Del_Load_Btn);
            this.Controls.Add(this.Assign_Sv_Data_Btn);
            this.Controls.Add(this.Del_sv_Btn);
            this.Name = "WindAssign";
            this.Text = "Gán tải gió";
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox TextBox5;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox ComboBox5;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ComboBox Define_Direction_Cbb;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton RadioButton3;
        internal System.Windows.Forms.RadioButton RadioButton4;
        internal System.Windows.Forms.RadioButton RadioButton7;
        internal System.Windows.Forms.RadioButton RadioButton6;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox CheckBox5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox CheckBox6;
        internal System.Windows.Forms.ComboBox ComboBox4;
        internal System.Windows.Forms.CheckBox CheckBox7;
        internal System.Windows.Forms.ComboBox ComboBox3;
        internal System.Windows.Forms.CheckBox CheckBox8;
        internal System.Windows.Forms.ComboBox ComboBox2;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.CheckBox CheckBox4;
        internal System.Windows.Forms.CheckBox CheckBox3;
        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.Button AssignLoadBtn;
        internal System.Windows.Forms.Button Del_Load_Btn;
        internal System.Windows.Forms.Button Assign_Sv_Data_Btn;
        internal System.Windows.Forms.Button Del_sv_Btn;
    }
}