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
            this.deleteRB = new System.Windows.Forms.RadioButton();
            this.roadRB = new System.Windows.Forms.RadioButton();
            this.cityRB = new System.Windows.Forms.RadioButton();
            this.cursorRB = new System.Windows.Forms.RadioButton();
            this.labelTip = new System.Windows.Forms.Label();
            this.tB = new System.Windows.Forms.TextBox();
            this.deepB = new System.Windows.Forms.Button();
            this.wideB = new System.Windows.Forms.Button();
            this.dijkstrB = new System.Windows.Forms.Button();
            this.cruskalB = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
            this.begTB = new System.Windows.Forms.TextBox();
            this.endTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drawBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startWalkTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteRB);
            this.groupBox1.Controls.Add(this.roadRB);
            this.groupBox1.Controls.Add(this.cityRB);
            this.groupBox1.Controls.Add(this.cursorRB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим";
            // 
            // deleteRB
            // 
            this.deleteRB.AutoSize = true;
            this.deleteRB.Location = new System.Drawing.Point(7, 91);
            this.deleteRB.Name = "deleteRB";
            this.deleteRB.Size = new System.Drawing.Size(113, 17);
            this.deleteRB.TabIndex = 3;
            this.deleteRB.TabStop = true;
            this.deleteRB.Tag = "2";
            this.deleteRB.Text = "Удаление города";
            this.deleteRB.UseVisualStyleBackColor = true;
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
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(12, 148);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(95, 13);
            this.labelTip.TabIndex = 1;
            this.labelTip.Text = "Название города";
            // 
            // tB
            // 
            this.tB.Location = new System.Drawing.Point(12, 164);
            this.tB.Name = "tB";
            this.tB.Size = new System.Drawing.Size(141, 20);
            this.tB.TabIndex = 2;
            // 
            // deepB
            // 
            this.deepB.Location = new System.Drawing.Point(12, 200);
            this.deepB.Name = "deepB";
            this.deepB.Size = new System.Drawing.Size(106, 23);
            this.deepB.TabIndex = 3;
            this.deepB.Text = "Обход в глубину";
            this.deepB.UseVisualStyleBackColor = true;
            this.deepB.Click += new System.EventHandler(this.deepB_Click);
            // 
            // wideB
            // 
            this.wideB.Location = new System.Drawing.Point(12, 226);
            this.wideB.Name = "wideB";
            this.wideB.Size = new System.Drawing.Size(106, 23);
            this.wideB.TabIndex = 4;
            this.wideB.Text = "Обход в ширину";
            this.wideB.UseVisualStyleBackColor = true;
            this.wideB.Click += new System.EventHandler(this.wideB_Click);
            // 
            // dijkstrB
            // 
            this.dijkstrB.Location = new System.Drawing.Point(12, 268);
            this.dijkstrB.Name = "dijkstrB";
            this.dijkstrB.Size = new System.Drawing.Size(106, 23);
            this.dijkstrB.TabIndex = 5;
            this.dijkstrB.Text = "Путь Дейкстры";
            this.dijkstrB.UseVisualStyleBackColor = true;
            this.dijkstrB.Click += new System.EventHandler(this.dijkstrB_Click);
            // 
            // cruskalB
            // 
            this.cruskalB.Location = new System.Drawing.Point(127, 268);
            this.cruskalB.Name = "cruskalB";
            this.cruskalB.Size = new System.Drawing.Size(106, 23);
            this.cruskalB.TabIndex = 6;
            this.cruskalB.Text = "Дерево Краскала";
            this.cruskalB.UseVisualStyleBackColor = true;
            this.cruskalB.Click += new System.EventHandler(this.cruskalB_Click);
            // 
            // clearB
            // 
            this.clearB.Location = new System.Drawing.Point(12, 356);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(221, 23);
            this.clearB.TabIndex = 7;
            this.clearB.Text = "Очистить посещение";
            this.clearB.UseVisualStyleBackColor = true;
            this.clearB.Click += new System.EventHandler(this.clearB_Click);
            // 
            // begTB
            // 
            this.begTB.Location = new System.Drawing.Point(15, 310);
            this.begTB.Name = "begTB";
            this.begTB.Size = new System.Drawing.Size(29, 20);
            this.begTB.TabIndex = 8;
            // 
            // endTB
            // 
            this.endTB.Location = new System.Drawing.Point(83, 310);
            this.endTB.Name = "endTB";
            this.endTB.Size = new System.Drawing.Size(29, 20);
            this.endTB.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Начало";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Конец";
            // 
            // drawBox
            // 
            this.drawBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawBox.Location = new System.Drawing.Point(247, 12);
            this.drawBox.Name = "drawBox";
            this.drawBox.Size = new System.Drawing.Size(604, 381);
            this.drawBox.TabIndex = 12;
            this.drawBox.TabStop = false;
            this.drawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawBox_MouseDown);
            this.drawBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawBox_MouseMove);
            this.drawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawBox_MouseUp);
            this.drawBox.Resize += new System.EventHandler(this.drawBox_Resize);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(124, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "Начальная вершина:";
            // 
            // startWalkTB
            // 
            this.startWalkTB.Location = new System.Drawing.Point(197, 211);
            this.startWalkTB.Name = "startWalkTB";
            this.startWalkTB.Size = new System.Drawing.Size(29, 20);
            this.startWalkTB.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 406);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.begTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startWalkTB);
            this.Controls.Add(this.drawBox);
            this.Controls.Add(this.clearB);
            this.Controls.Add(this.cruskalB);
            this.Controls.Add(this.dijkstrB);
            this.Controls.Add(this.wideB);
            this.Controls.Add(this.deepB);
            this.Controls.Add(this.tB);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Карта городов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).EndInit();
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
        private System.Windows.Forms.Button deepB;
        private System.Windows.Forms.Button wideB;
        private System.Windows.Forms.Button dijkstrB;
        private System.Windows.Forms.Button cruskalB;
        private System.Windows.Forms.Button clearB;
        private System.Windows.Forms.TextBox begTB;
        private System.Windows.Forms.TextBox endTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton deleteRB;
        private System.Windows.Forms.PictureBox drawBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startWalkTB;
    }
}

