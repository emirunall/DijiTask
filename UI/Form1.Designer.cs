namespace UI
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            txtNameSurname = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            button3 = new Button();
            dataGridView2 = new DataGridView();
            btnAddMachine = new Button();
            txtMachineName = new TextBox();
            label2 = new Label();
            tabPage3 = new TabPage();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            cmbMachines = new ComboBox();
            cmbEmployees = new ComboBox();
            label4 = new Label();
            button4 = new Button();
            dataGridView3 = new DataGridView();
            button5 = new Button();
            label3 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1236, 620);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(txtNameSurname);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1228, 592);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Personel İşlemleri";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(141, 50);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Güncelle";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1222, 495);
            dataGridView1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(222, 50);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtNameSurname
            // 
            txtNameSurname.Location = new Point(80, 21);
            txtNameSurname.Name = "txtNameSurname";
            txtNameSurname.Size = new Size(217, 23);
            txtNameSurname.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 24);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Ad Soyad";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(btnAddMachine);
            tabPage2.Controls.Add(txtMachineName);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1228, 592);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Makine İşlemleri";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(143, 46);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 9;
            button3.Text = "Güncelle";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Bottom;
            dataGridView2.Location = new Point(3, 94);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(1222, 495);
            dataGridView2.TabIndex = 8;
            // 
            // btnAddMachine
            // 
            btnAddMachine.Location = new Point(224, 46);
            btnAddMachine.Name = "btnAddMachine";
            btnAddMachine.Size = new Size(75, 23);
            btnAddMachine.TabIndex = 7;
            btnAddMachine.Text = "Ekle";
            btnAddMachine.UseVisualStyleBackColor = true;
            btnAddMachine.Click += btnAddMachine_Click;
            // 
            // txtMachineName
            // 
            txtMachineName.Location = new Point(92, 17);
            txtMachineName.Name = "txtMachineName";
            txtMachineName.Size = new Size(207, 23);
            txtMachineName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 20);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 5;
            label2.Text = "Makine Adı";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dateTimePicker1);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(cmbMachines);
            tabPage3.Controls.Add(cmbEmployees);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(label3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1228, 592);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Mesai İşlemleri";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(776, 27);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(738, 30);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 18;
            label5.Text = "Tarih";
            // 
            // cmbMachines
            // 
            cmbMachines.FormattingEnabled = true;
            cmbMachines.Location = new Point(443, 27);
            cmbMachines.Name = "cmbMachines";
            cmbMachines.Size = new Size(222, 23);
            cmbMachines.TabIndex = 17;
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(80, 27);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(222, 23);
            cmbEmployees.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(391, 30);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 15;
            label4.Text = "Makine";
            // 
            // button4
            // 
            button4.Location = new Point(1119, 27);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 14;
            button4.Text = "Güncelle";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Bottom;
            dataGridView3.Location = new Point(0, 97);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(1228, 495);
            dataGridView3.TabIndex = 13;
            // 
            // button5
            // 
            button5.Location = new Point(1038, 27);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 12;
            button5.Text = "Ekle";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 30);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 10;
            label3.Text = "Personel";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 620);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Mesai EKLE";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private Button button1;
        private TextBox txtNameSurname;
        private Label label1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView2;
        private Button btnAddMachine;
        private TextBox txtMachineName;
        private Label label2;
        private Label label4;
        private Button button4;
        private DataGridView dataGridView3;
        private Button button5;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private ComboBox cmbMachines;
        private ComboBox cmbEmployees;
    }
}