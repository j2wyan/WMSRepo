namespace WMS_V1.UI
{
    partial class SeisanShohin
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
            this.gcFunctionKey1 = new GrapeCity.Win.Bars.GcFunctionKey();
            this.SuspendLayout();
            // 
            // gcFunctionKey1
            // 
            this.gcFunctionKey1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcFunctionKey1.Location = new System.Drawing.Point(0, 0);
            this.gcFunctionKey1.Name = "gcFunctionKey1";
            this.gcFunctionKey1.Size = new System.Drawing.Size(816, 25);
            this.gcFunctionKey1.TabIndex = 0;
            this.gcFunctionKey1.Text = "gcFunctionKey1";
            // 
            // SeisanShohin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 801);
            this.Controls.Add(this.gcFunctionKey1);
            this.Name = "SeisanShohin";
            this.Text = "生産商品管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GrapeCity.Win.Bars.GcFunctionKey gcFunctionKey1;
    }
}