namespace GenericGraph
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cursorRB = new System.Windows.Forms.RadioButton();
            this.cityRB = new System.Windows.Forms.RadioButton();
            this.roadRB = new System.Windows.Forms.RadioButton();
            this.labelTip = new System.Windows.Forms.Label();
            this.tB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roadRB);
            this.groupBox1.Controls.Add(this.cityRB);
            this.groupBox1.Controls.Add(this.cursorRB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим";
            // 
            // cursorRB
            // 
            this.cursorRB.AutoSize = true;
            this.cursorRB.Location = new System.Drawing.Point(7, 20);
            this.cursorRB.Name = "cursorRB";
            this.cursorRB.Size = new System.Drawing.Size(61, 17);
            this.cursorRB.TabIndex = 0;
            this.cursorRB.TabStop = true;
            this.cursorRB.Tag = "0";
            this.cursorRB.Text = "Курсор";
            this.cursorRB.UseVisualStyleBackColor = true;
            this.cursorRB.Click += new System.EventHandler(this.cursorRB_Click);
            // 
            // cityRB
            // 
            this.cityRB.AutoSize = true;
            this.cityRB.Location = new System.Drawing.Point(7, 44);
            this.cityRB.Name = "cityRB";
            this.cityRB.Size = new System.Drawing.Size(126, 17);
            this.cityRB.TabIndex = 1;
            this.cityRB.TabStop = true;
            this.cityRB.Tag = "1";
            this.cityRB.Text = "Добавление города";
            this.cityRB.UseVisualStyleBackColor = true;
            this.cityRB.Click += new System.EventHandler(this.cityRB_Click);
            // 
            // roadRB
            // 
            this.roadRB.AutoSize = true;
            this.roadRB.Location = new System.Drawing.Point(7, 68);
            this.roadRB.Name = "roadRB";
            this.roadRB.Size = new System.Drawing.Size(129, 17);
            this.roadRB.TabIndex = 2;
            this.roadRB.TabStop = true;
            this.roadRB.Tag = "2";
            this.roadRB.Text = "Добавление Дороги";
            this.roadRB.UseVisualStyleBackColor = true;
            this.roadRB.Click += new System.EventHandler(this.roadRB_Click);
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(12, 119);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(95, 13);
            this.labelTip.TabIndex = 1;
            this.labelTip.Text = "Название города";
            // 
            // tB
            // 
            this.tB.Location = new System.Drawing.Point(12, 135);
            this.tB.Name = "tB";
            this.tB.Size = new System.Drawing.Size(141, 20);
            this.tB.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 427);
            this.Controls.Add(this.tB);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton roadRB;
        private System.Windows.Forms.RadioButton cityRB;
        private System.Windows.Forms.RadioButton cursorRB;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.TextBox tB;
    }
}

