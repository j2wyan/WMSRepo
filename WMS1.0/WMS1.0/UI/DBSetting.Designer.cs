namespace WMS_V1.UI
{
    partial class DBSetting
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
            this.gcTabControl1 = new GrapeCity.Win.Containers.GcTabControl();
            this.gcTabPage1 = new GrapeCity.Win.Containers.GcTabPage();
            this.btnyok = new System.Windows.Forms.Button();
            this.btnycancle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboyloginuser = new System.Windows.Forms.ComboBox();
            this.txtyloginpw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboydb = new System.Windows.Forms.ComboBox();
            this.cboyserver = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtypassword = new System.Windows.Forms.TextBox();
            this.txtyuser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gcTabPage2 = new GrapeCity.Win.Containers.GcTabPage();
            this.btnsok = new System.Windows.Forms.Button();
            this.btnscancle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbosdb = new System.Windows.Forms.ComboBox();
            this.cbosserver = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtspw = new System.Windows.Forms.TextBox();
            this.txtsuser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.gcTabControl1)).BeginInit();
            this.gcTabControl1.SuspendLayout();
            this.gcTabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gcTabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTabControl1
            // 
            this.gcTabControl1.Location = new System.Drawing.Point(4, 12);
            this.gcTabControl1.Name = "gcTabControl1";
            this.gcTabControl1.Size = new System.Drawing.Size(473, 460);
            this.gcTabControl1.TabIndex = 0;
            this.gcTabControl1.TabPages.Add(this.gcTabPage1);
            this.gcTabControl1.TabPages.Add(this.gcTabPage2);
            this.gcTabControl1.SelectedIndexChanged += new System.EventHandler(this.gcTabControl1_SelectedIndexChanged);
            // 
            // gcTabPage1
            // 
            this.gcTabPage1.Controls.Add(this.btnyok);
            this.gcTabPage1.Controls.Add(this.btnycancle);
            this.gcTabPage1.Controls.Add(this.groupBox1);
            this.gcTabPage1.Controls.Add(this.groupBox2);
            this.gcTabPage1.Location = new System.Drawing.Point(4, 24);
            this.gcTabPage1.Name = "gcTabPage1";
            this.gcTabPage1.Size = new System.Drawing.Size(465, 432);
            this.gcTabPage1.TabIndex = 0;
            this.gcTabPage1.Text = "弥生データベース";
            this.gcTabPage1.UseVisualStyleBackColor = true;
            // 
            // btnyok
            // 
            this.btnyok.Location = new System.Drawing.Point(162, 391);
            this.btnyok.Name = "btnyok";
            this.btnyok.Size = new System.Drawing.Size(91, 30);
            this.btnyok.TabIndex = 7;
            this.btnyok.Text = "OK";
            this.btnyok.UseVisualStyleBackColor = true;
            this.btnyok.Click += new System.EventHandler(this.btnyok_Click);
            // 
            // btnycancle
            // 
            this.btnycancle.Location = new System.Drawing.Point(259, 391);
            this.btnycancle.Name = "btnycancle";
            this.btnycancle.Size = new System.Drawing.Size(91, 30);
            this.btnycancle.TabIndex = 8;
            this.btnycancle.Text = "キャンセル";
            this.btnycancle.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboyloginuser);
            this.groupBox1.Controls.Add(this.txtyloginpw);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 122);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "弥生ログイン指定";
            // 
            // cboyloginuser
            // 
            this.cboyloginuser.FormattingEnabled = true;
            this.cboyloginuser.Location = new System.Drawing.Point(124, 32);
            this.cboyloginuser.Name = "cboyloginuser";
            this.cboyloginuser.Size = new System.Drawing.Size(223, 20);
            this.cboyloginuser.TabIndex = 5;
            this.cboyloginuser.Click += new System.EventHandler(this.cboyloginuser_Click);
            // 
            // txtyloginpw
            // 
            this.txtyloginpw.Location = new System.Drawing.Point(124, 67);
            this.txtyloginpw.Name = "txtyloginpw";
            this.txtyloginpw.PasswordChar = '＊';
            this.txtyloginpw.Size = new System.Drawing.Size(223, 19);
            this.txtyloginpw.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "弥生ユーザー名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "弥生パスワード：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboydb);
            this.groupBox2.Controls.Add(this.cboyserver);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtypassword);
            this.groupBox2.Controls.Add(this.txtyuser);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 224);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "弥生サーバー情報";
            // 
            // cboydb
            // 
            this.cboydb.BackColor = System.Drawing.Color.White;
            this.cboydb.FormattingEnabled = true;
            this.cboydb.Location = new System.Drawing.Point(124, 129);
            this.cboydb.Name = "cboydb";
            this.cboydb.Size = new System.Drawing.Size(223, 20);
            this.cboydb.TabIndex = 44;
            this.cboydb.Click += new System.EventHandler(this.cboydb_Click);
            // 
            // cboyserver
            // 
            this.cboyserver.BackColor = System.Drawing.Color.White;
            this.cboyserver.FormattingEnabled = true;
            this.cboyserver.Location = new System.Drawing.Point(124, 50);
            this.cboyserver.Name = "cboyserver";
            this.cboyserver.Size = new System.Drawing.Size(223, 20);
            this.cboyserver.TabIndex = 45;
            this.cboyserver.Click += new System.EventHandler(this.cboyserver_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(47, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "サーバー名：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtypassword
            // 
            this.txtypassword.BackColor = System.Drawing.Color.White;
            this.txtypassword.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtypassword.Location = new System.Drawing.Point(124, 104);
            this.txtypassword.Name = "txtypassword";
            this.txtypassword.PasswordChar = '＊';
            this.txtypassword.Size = new System.Drawing.Size(223, 19);
            this.txtypassword.TabIndex = 42;
            // 
            // txtyuser
            // 
            this.txtyuser.BackColor = System.Drawing.Color.White;
            this.txtyuser.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtyuser.Location = new System.Drawing.Point(124, 76);
            this.txtyuser.Name = "txtyuser";
            this.txtyuser.Size = new System.Drawing.Size(223, 19);
            this.txtyuser.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(47, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "ユーザー名：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(52, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "パスワード：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(59, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 43;
            this.label7.Text = "データ名：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(122, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 11);
            this.label6.TabIndex = 1;
            this.label6.Text = "※弥生会計サーバー情報を入力します。";
            // 
            // gcTabPage2
            // 
            this.gcTabPage2.Controls.Add(this.btnsok);
            this.gcTabPage2.Controls.Add(this.btnscancle);
            this.gcTabPage2.Controls.Add(this.groupBox3);
            this.gcTabPage2.Location = new System.Drawing.Point(4, 24);
            this.gcTabPage2.Name = "gcTabPage2";
            this.gcTabPage2.Size = new System.Drawing.Size(465, 432);
            this.gcTabPage2.TabIndex = 1;
            this.gcTabPage2.Text = "システムデータベース";
            this.gcTabPage2.UseVisualStyleBackColor = true;
            // 
            // btnsok
            // 
            this.btnsok.Location = new System.Drawing.Point(164, 388);
            this.btnsok.Name = "btnsok";
            this.btnsok.Size = new System.Drawing.Size(91, 30);
            this.btnsok.TabIndex = 11;
            this.btnsok.Text = "OK";
            this.btnsok.UseVisualStyleBackColor = true;
            this.btnsok.Click += new System.EventHandler(this.btnsok_Click);
            // 
            // btnscancle
            // 
            this.btnscancle.Location = new System.Drawing.Point(261, 388);
            this.btnscancle.Name = "btnscancle";
            this.btnscancle.Size = new System.Drawing.Size(91, 30);
            this.btnscancle.TabIndex = 10;
            this.btnscancle.Text = "キャンセル";
            this.btnscancle.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbosdb);
            this.groupBox3.Controls.Add(this.cbosserver);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtspw);
            this.groupBox3.Controls.Add(this.txtsuser);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(17, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 363);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "システムDB情報";
            // 
            // cbosdb
            // 
            this.cbosdb.BackColor = System.Drawing.Color.White;
            this.cbosdb.FormattingEnabled = true;
            this.cbosdb.Location = new System.Drawing.Point(112, 116);
            this.cbosdb.Name = "cbosdb";
            this.cbosdb.Size = new System.Drawing.Size(223, 20);
            this.cbosdb.TabIndex = 37;
            this.cbosdb.Click += new System.EventHandler(this.cbosdb_Click);
            // 
            // cbosserver
            // 
            this.cbosserver.BackColor = System.Drawing.Color.White;
            this.cbosserver.FormattingEnabled = true;
            this.cbosserver.Location = new System.Drawing.Point(112, 37);
            this.cbosserver.Name = "cbosserver";
            this.cbosserver.Size = new System.Drawing.Size(223, 20);
            this.cbosserver.TabIndex = 37;
            this.cbosserver.Click += new System.EventHandler(this.cbosserver_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(35, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "サーバー名：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtspw
            // 
            this.txtspw.BackColor = System.Drawing.Color.White;
            this.txtspw.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtspw.Location = new System.Drawing.Point(112, 91);
            this.txtspw.Name = "txtspw";
            this.txtspw.PasswordChar = '＊';
            this.txtspw.Size = new System.Drawing.Size(223, 19);
            this.txtspw.TabIndex = 34;
            // 
            // txtsuser
            // 
            this.txtsuser.BackColor = System.Drawing.Color.White;
            this.txtsuser.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtsuser.Location = new System.Drawing.Point(112, 63);
            this.txtsuser.Name = "txtsuser";
            this.txtsuser.Size = new System.Drawing.Size(223, 19);
            this.txtsuser.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(35, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "ユーザー名：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(40, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "パスワード：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(47, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 35;
            this.label11.Text = "データ名：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(110, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(186, 11);
            this.label12.TabIndex = 1;
            this.label12.Text = "※システムデータベース情報を入力します。";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // DBSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 476);
            this.Controls.Add(this.gcTabControl1);
            this.Name = "DBSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            this.Load += new System.EventHandler(this.DBSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTabControl1)).EndInit();
            this.gcTabControl1.ResumeLayout(false);
            this.gcTabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gcTabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GrapeCity.Win.Containers.GcTabControl gcTabControl1;
        private GrapeCity.Win.Containers.GcTabPage gcTabPage1;
        private System.Windows.Forms.Button btnyok;
        private System.Windows.Forms.Button btnycancle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboyloginuser;
        private System.Windows.Forms.TextBox txtyloginpw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboydb;
        private System.Windows.Forms.ComboBox cboyserver;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtypassword;
        internal System.Windows.Forms.TextBox txtyuser;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private GrapeCity.Win.Containers.GcTabPage gcTabPage2;
        private System.Windows.Forms.Button btnsok;
        private System.Windows.Forms.Button btnscancle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbosdb;
        private System.Windows.Forms.ComboBox cbosserver;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtspw;
        internal System.Windows.Forms.TextBox txtsuser;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}