
namespace StoreCheck
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_net_test = new System.Windows.Forms.Button();
            this.btn_machine_test = new System.Windows.Forms.Button();
            this.btn_pdisk_test = new System.Windows.Forms.Button();
            this.btn_prinrinvoice_test = new System.Windows.Forms.Button();
            this.btn_net_solve = new System.Windows.Forms.Button();
            this.btn_machine_solve = new System.Windows.Forms.Button();
            this.btn_pdisk_solve = new System.Windows.Forms.Button();
            this.btn_printinvoice_solve = new System.Windows.Forms.Button();
            this.btn_for_test = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.res_label = new System.Windows.Forms.RichTextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_for_repair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_testify = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.version_labe = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_net_test
            // 
            this.btn_net_test.Location = new System.Drawing.Point(598, 169);
            this.btn_net_test.Name = "btn_net_test";
            this.btn_net_test.Size = new System.Drawing.Size(10, 10);
            this.btn_net_test.TabIndex = 0;
            this.btn_net_test.Text = "網路測試";
            this.btn_net_test.UseVisualStyleBackColor = true;
            this.btn_net_test.Click += new System.EventHandler(this.btn_net_test_Click);
            // 
            // btn_machine_test
            // 
            this.btn_machine_test.Location = new System.Drawing.Point(598, 227);
            this.btn_machine_test.Name = "btn_machine_test";
            this.btn_machine_test.Size = new System.Drawing.Size(10, 10);
            this.btn_machine_test.TabIndex = 1;
            this.btn_machine_test.Text = "發票機測試";
            this.btn_machine_test.UseVisualStyleBackColor = true;
            this.btn_machine_test.Click += new System.EventHandler(this.btn_machine_test_Click);
            // 
            // btn_pdisk_test
            // 
            this.btn_pdisk_test.Location = new System.Drawing.Point(598, 296);
            this.btn_pdisk_test.Name = "btn_pdisk_test";
            this.btn_pdisk_test.Size = new System.Drawing.Size(10, 10);
            this.btn_pdisk_test.TabIndex = 2;
            this.btn_pdisk_test.Text = "P槽測試";
            this.btn_pdisk_test.UseVisualStyleBackColor = true;
            this.btn_pdisk_test.Click += new System.EventHandler(this.btn_pdisk_test_Click);
            // 
            // btn_prinrinvoice_test
            // 
            this.btn_prinrinvoice_test.Location = new System.Drawing.Point(598, 361);
            this.btn_prinrinvoice_test.Name = "btn_prinrinvoice_test";
            this.btn_prinrinvoice_test.Size = new System.Drawing.Size(10, 10);
            this.btn_prinrinvoice_test.TabIndex = 3;
            this.btn_prinrinvoice_test.Text = "金財通測試";
            this.btn_prinrinvoice_test.UseVisualStyleBackColor = true;
            this.btn_prinrinvoice_test.Click += new System.EventHandler(this.btn_prinrinvoice_test_Click);
            // 
            // btn_net_solve
            // 
            this.btn_net_solve.Enabled = false;
            this.btn_net_solve.Location = new System.Drawing.Point(751, 169);
            this.btn_net_solve.Name = "btn_net_solve";
            this.btn_net_solve.Size = new System.Drawing.Size(10, 10);
            this.btn_net_solve.TabIndex = 4;
            this.btn_net_solve.Text = "網路問題處理";
            this.btn_net_solve.UseVisualStyleBackColor = true;
            this.btn_net_solve.Click += new System.EventHandler(this.btn_net_solve_Click);
            // 
            // btn_machine_solve
            // 
            this.btn_machine_solve.Location = new System.Drawing.Point(751, 227);
            this.btn_machine_solve.Name = "btn_machine_solve";
            this.btn_machine_solve.Size = new System.Drawing.Size(10, 10);
            this.btn_machine_solve.TabIndex = 5;
            this.btn_machine_solve.Text = "發票機問題處理";
            this.btn_machine_solve.UseVisualStyleBackColor = true;
            this.btn_machine_solve.Click += new System.EventHandler(this.btn_machine_solve_Click);
            // 
            // btn_pdisk_solve
            // 
            this.btn_pdisk_solve.Location = new System.Drawing.Point(751, 296);
            this.btn_pdisk_solve.Name = "btn_pdisk_solve";
            this.btn_pdisk_solve.Size = new System.Drawing.Size(10, 10);
            this.btn_pdisk_solve.TabIndex = 6;
            this.btn_pdisk_solve.Text = "P槽問題處理";
            this.btn_pdisk_solve.UseVisualStyleBackColor = true;
            this.btn_pdisk_solve.Click += new System.EventHandler(this.btn_pdisk_solve_Click);
            // 
            // btn_printinvoice_solve
            // 
            this.btn_printinvoice_solve.Location = new System.Drawing.Point(751, 361);
            this.btn_printinvoice_solve.Name = "btn_printinvoice_solve";
            this.btn_printinvoice_solve.Size = new System.Drawing.Size(10, 10);
            this.btn_printinvoice_solve.TabIndex = 7;
            this.btn_printinvoice_solve.Text = "金財通問題處理";
            this.btn_printinvoice_solve.UseVisualStyleBackColor = true;
            this.btn_printinvoice_solve.Click += new System.EventHandler(this.btn_printinvoice_solve_Click);
            // 
            // btn_for_test
            // 
            this.btn_for_test.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_for_test.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_for_test.Location = new System.Drawing.Point(68, 175);
            this.btn_for_test.Name = "btn_for_test";
            this.btn_for_test.Size = new System.Drawing.Size(135, 108);
            this.btn_for_test.TabIndex = 9;
            this.btn_for_test.Text = "開始測試";
            this.btn_for_test.UseVisualStyleBackColor = true;
            this.btn_for_test.Click += new System.EventHandler(this.btn_for_all_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_clear.Location = new System.Drawing.Point(68, 483);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(312, 39);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "清除文字";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // res_label
            // 
            this.res_label.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(120)));
            this.res_label.Location = new System.Drawing.Point(450, 36);
            this.res_label.Name = "res_label";
            this.res_label.Size = new System.Drawing.Size(475, 486);
            this.res_label.TabIndex = 12;
            this.res_label.Text = "";
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(511, 411);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(299, 39);
            this.btn_test.TabIndex = 13;
            this.btn_test.Text = "test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Visible = false;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_for_repair
            // 
            this.btn_for_repair.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_for_repair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_for_repair.Location = new System.Drawing.Point(245, 175);
            this.btn_for_repair.Name = "btn_for_repair";
            this.btn_for_repair.Size = new System.Drawing.Size(135, 108);
            this.btn_for_repair.TabIndex = 14;
            this.btn_for_repair.Text = "修復測試";
            this.btn_for_repair.UseVisualStyleBackColor = true;
            this.btn_for_repair.Click += new System.EventHandler(this.btn_repair_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(68, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 119);
            this.label1.TabIndex = 15;
            this.label1.Text = "測試後仍有問題，請聯繫窗口\r\n網路 : 0809-000-365      (台固)\r\n發票機 : (02) 2298-2456 (新曜)\r\nP槽、金財通 : 資" +
    "訊室";
            // 
            // btn_testify
            // 
            this.btn_testify.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_testify.Location = new System.Drawing.Point(68, 289);
            this.btn_testify.Name = "btn_testify";
            this.btn_testify.Size = new System.Drawing.Size(312, 39);
            this.btn_testify.TabIndex = 16;
            this.btn_testify.Text = "testify";
            this.btn_testify.UseVisualStyleBackColor = true;
            this.btn_testify.Visible = false;
            this.btn_testify.Click += new System.EventHandler(this.btn_testify_click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(68, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 60);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // version_labe
            // 
            this.version_labe.AutoSize = true;
            this.version_labe.ForeColor = System.Drawing.Color.CadetBlue;
            this.version_labe.Location = new System.Drawing.Point(3, 546);
            this.version_labe.Name = "version_labe";
            this.version_labe.Size = new System.Drawing.Size(0, 12);
            this.version_labe.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.version_labe);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_testify);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_for_repair);
            this.Controls.Add(this.res_label);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_for_test);
            this.Controls.Add(this.btn_printinvoice_solve);
            this.Controls.Add(this.btn_pdisk_solve);
            this.Controls.Add(this.btn_machine_solve);
            this.Controls.Add(this.btn_net_solve);
            this.Controls.Add(this.btn_prinrinvoice_test);
            this.Controls.Add(this.btn_pdisk_test);
            this.Controls.Add(this.btn_machine_test);
            this.Controls.Add(this.btn_net_test);
            this.Controls.Add(this.btn_test);
            this.Name = "Form1";
            this.Text = "門市系統測試";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.Button btn_net_test;

        private System.Windows.Forms.Button btn_machine_test;
        private System.Windows.Forms.Button btn_pdisk_test;
        private System.Windows.Forms.Button btn_prinrinvoice_test;
        private System.Windows.Forms.Button btn_net_solve;
        private System.Windows.Forms.Button btn_machine_solve;
        private System.Windows.Forms.Button btn_pdisk_solve;
        private System.Windows.Forms.Button btn_printinvoice_solve;
        private System.Windows.Forms.Button btn_for_test;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.RichTextBox res_label;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_for_repair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_testify;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label version_labe;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

