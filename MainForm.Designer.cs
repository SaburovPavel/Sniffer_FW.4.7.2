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
            this.labelCountPacket = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 585);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewCap);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 89);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1252, 496);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewCap
            // 
            this.dataGridViewCap.AllowUserToAddRows = false;
            this.dataGridViewCap.AllowUserToDeleteRows = false;
            this.dataGridViewCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCap.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewCap.MultiSelect = false;
            this.dataGridViewCap.Name = "dataGridViewCap";
            this.dataGridViewCap.ReadOnly = true;
            this.dataGridViewCap.RowHeadersWidth = 51;
            this.dataGridViewCap.RowTemplate.Height = 24;
            this.dataGridViewCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCap.Size = new System.Drawing.Size(1252, 440);
            this.dataGridViewCap.TabIndex = 1;
            this.dataGridViewCap.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewCap_DataBindingComplete);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonRefresh);
            this.panel4.Controls.Add(this.buttonStop);
            this.panel4.Controls.Add(this.buttonStart);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 440);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1252, 56);
            this.panel4.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(289, 4);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(112, 38);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(133, 4);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(111, 38);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(15, 4);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(111, 38);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labelCountPacket);
            this.panel2.Controls.Add(this.radioButton2View);
            this.panel2.Controls.Add(this.radioButton1View);
            this.panel2.Controls.Add(this.comboBoxDevices);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1252, 89);
            this.panel2.TabIndex = 0;
            // 
            // radioButton2View
            // 
            this.radioButton2View.AutoSize = true;
            this.radioButton2View.Location = new System.Drawing.Point(223, 44);
            this.radioButton2View.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton2View.Name = "radioButton2View";
            this.radioButton2View.Size = new System.Drawing.Size(238, 24);
            this.radioButton2View.TabIndex = 2;
            this.radioButton2View.TabStop = true;
            this.radioButton2View.Text = "Time+Source+Dest+Protocol";
            this.radioButton2View.UseVisualStyleBackColor = true;
            this.radioButton2View.CheckedChanged += new System.EventHandler(this.radioButton2View_CheckedChanged);
            // 
            // radioButton1View
            // 
            this.radioButton1View.AutoSize = true;
            this.radioButton1View.Location = new System.Drawing.Point(15, 44);
            this.radioButton1View.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1View.Name = "radioButton1View";
            this.radioButton1View.Size = new System.Drawing.Size(187, 24);
            this.radioButton1View.TabIndex = 1;
            this.radioButton1View.TabStop = true;
            this.radioButton1View.Text = "Time+Len+rawPacket";
            this.radioButton1View.UseVisualStyleBackColor = true;
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(15, 5);
            this.comboBoxDevices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(786, 28);
            this.comboBoxDevices.TabIndex = 0;
            // 
            // labelCountPacket
            // 
            this.labelCountPacket.AutoSize = true;
            this.labelCountPacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountPacket.Location = new System.Drawing.Point(750, 46);
            this.labelCountPacket.Name = "labelCountPacket";
            this.labelCountPacket.Size = new System.Drawing.Size(41, 29);
            this.labelCountPacket.TabIndex = 3;
            this.labelCountPacket.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Всего получено пакетов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 585);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCountPacket;
    }
}

