namespace WMS_V1.UI
{
    partial class Item_DetailList
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
            this.gcMultiRow1 = new GrapeCity.Win.MultiRow.GcMultiRow();
            this.item_DeatilListTemplate1 = new WMS_V1.UI.Item_DeatilListTemplate();
            ((System.ComponentModel.ISupportInitialize)(this.gcMultiRow1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMultiRow1
            // 
            this.gcMultiRow1.Location = new System.Drawing.Point(-2, -2);
            this.gcMultiRow1.Name = "gcMultiRow1";
            this.gcMultiRow1.Size = new System.Drawing.Size(478, 361);
            this.gcMultiRow1.TabIndex = 0;
            this.gcMultiRow1.Template = this.item_DeatilListTemplate1;
            this.gcMultiRow1.Text = "gcMultiRow1";
            this.gcMultiRow1.CellContentDoubleClick += new System.EventHandler<GrapeCity.Win.MultiRow.CellEventArgs>(this.gcMultiRow1_CellContentDoubleClick);
            // 
            // Item_DetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 347);
            this.Controls.Add(this.gcMultiRow1);
            this.Name = "Item_DetailList";
            this.Text = "Item_DetailList";
            this.Load += new System.EventHandler(this.Item_DetailList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMultiRow1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GrapeCity.Win.MultiRow.GcMultiRow gcMultiRow1;
        private Item_DeatilListTemplate item_DeatilListTemplate1;
    }
}