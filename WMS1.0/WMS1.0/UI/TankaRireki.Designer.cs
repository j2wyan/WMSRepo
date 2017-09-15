namespace WMS_V1
{
    partial class TankaRireki
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
            this.gcContainer1 = new GrapeCity.Win.Containers.GcContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gcListBox1 = new GrapeCity.Win.Editors.GcListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gcContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcListBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcContainer1
            // 
            this.gcContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gcContainer1.Controls.Add(this.label2);
            this.gcContainer1.Controls.Add(this.label1);
            this.gcContainer1.Location = new System.Drawing.Point(12, 12);
            this.gcContainer1.Name = "gcContainer1";
            this.gcContainer1.Size = new System.Drawing.Size(433, 62);
            this.gcContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品コード：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "商品名称：";
            // 
            // gcListBox1
            // 
            this.gcListBox1.Location = new System.Drawing.Point(12, 92);
            this.gcListBox1.Name = "gcListBox1";
            this.gcListBox1.Size = new System.Drawing.Size(553, 366);
            this.gcListBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "閉じる";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TankaRireki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 469);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gcListBox1);
            this.Controls.Add(this.gcContainer1);
            this.Name = "TankaRireki";
            this.Text = "単価履歴";
            this.gcContainer1.ResumeLayout(false);
            this.gcContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcListBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GrapeCity.Win.Containers.GcContainer gcContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GrapeCity.Win.Editors.GcListBox gcListBox1;
        private System.Windows.Forms.Button button1;
    }
}