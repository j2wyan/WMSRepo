namespace OkhenTest.UI
{
    partial class TantoshaSearch
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
            this.ListView = new System.Windows.Forms.ListView();
            this.TextSearch = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.BackColor = System.Drawing.SystemColors.Window;
            this.ListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListView.FullRowSelect = true;
            this.ListView.LabelEdit = true;
            this.ListView.Location = new System.Drawing.Point(24, 85);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(854, 360);
            this.ListView.TabIndex = 38;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.DoubleClick += new System.EventHandler(this.ListView_DoubleClick);
            // 
            // TextSearch
            // 
            this.TextSearch.AcceptsReturn = true;
            this.TextSearch.BackColor = System.Drawing.SystemColors.Window;
            this.TextSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TextSearch.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.TextSearch.Location = new System.Drawing.Point(277, 22);
            this.TextSearch.MaxLength = 0;
            this.TextSearch.Name = "TextSearch";
            this.TextSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextSearch.Size = new System.Drawing.Size(233, 20);
            this.TextSearch.TabIndex = 37;
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxSearch.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comboBoxSearch.Location = new System.Drawing.Point(72, 21);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxSearch.Size = new System.Drawing.Size(178, 21);
            this.comboBoxSearch.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "検索";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(756, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 35);
            this.button1.TabIndex = 34;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(761, 451);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 34);
            this.button2.TabIndex = 32;
            this.button2.Text = "キャンセル";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(621, 451);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 34);
            this.button3.TabIndex = 33;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TantoshaSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 500);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.TextSearch);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Name = "TantoshaSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TantoshaSearch";
            this.Load += new System.EventHandler(this.TantoshaSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListView ListView;
        public System.Windows.Forms.TextBox TextSearch;
        public System.Windows.Forms.ComboBox comboBoxSearch;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}