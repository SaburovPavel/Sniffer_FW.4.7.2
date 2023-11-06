namespace Sniffer_FW._4._7._2
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewCap = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton2View = new System.Windows.Forms.RadioButton();
            this.radioButton1View = new System.Windows.Forms.RadioButton();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCap)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 468);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewCap);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1113, 397);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewCap
            // 
            this.dataGridViewCap.AllowUserToAddRows = false;
            this.dataGridViewCap.AllowUserToDeleteRows = false;
            this.dataGridViewCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCap.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCap.MultiSelect = false;
            this.dataGridViewCap.Name = "dataGridViewCap";
            this.dataGridViewCap.ReadOnly = true;
            this.dataGridViewCap.RowHeadersWidth = 51;
            this.dataGridViewCap.RowTemplate.Height = 24;
            this.dataGridViewCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCap.Size = new System.Drawing.Size(1113, 352);
            this.dataGridViewCap.TabIndex = 1;
            this.dataGridViewCap.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewCap_DataBindingComplete);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonRefresh);
            this.panel4.Controls.Add(this.buttonStop);
            this.panel4.Controls.Add(this.buttonStart);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 352);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1113, 45);
            this.panel4.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(257, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 30);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(118, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(99, 30);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(13, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(99, 30);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton2View);
            this.panel2.Controls.Add(this.radioButton1View);
            this.panel2.Controls.Add(this.comboBoxDevices);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 71);
            this.panel2.TabIndex = 0;
            // 
            // radioButton2View
            // 
            this.radioButton2View.AutoSize = true;
            this.radioButton2View.Location = new System.Drawing.Point(198, 35);
            this.radioButton2View.Name = "radioButton2View";
            this.radioButton2View.Size = new System.Drawing.Size(201, 20);
            this.radioButton2View.TabIndex = 2;
            this.radioButton2View.TabStop = true;
            this.radioButton2View.Text = "Time+Source+Dest+Protocol";
            this.radioButton2View.UseVisualStyleBackColor = true;
            this.radioButton2View.CheckedChanged += new System.EventHandler(this.radioButton2View_CheckedChanged);
            // 
            // radioButton1View
            // 
            this.radioButton1View.AutoSize = true;
            this.radioButton1View.Location = new System.Drawing.Point(13, 35);
            this.radioButton1View.Name = "radioButton1View";
            this.radioButton1View.Size = new System.Drawing.Size(158, 20);
            this.radioButton1View.TabIndex = 1;
            this.radioButton1View.TabStop = true;
            this.radioButton1View.Text = "Time+Len+rawPacket";
            this.radioButton1View.UseVisualStyleBackColor = true;
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(13, 4);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(699, 24);
            this.comboBoxDevices.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 468);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCap)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewCap;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.RadioButton radioButton2View;
        private System.Windows.Forms.RadioButton radioButton1View;
    }
}

