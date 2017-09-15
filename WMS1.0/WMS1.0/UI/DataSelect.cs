using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS_V1.UI;

namespace WMS_V1
{
    public partial class DataSelect : Form
    {
        public DataSelect()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<DBSetting>().Any())
            {
                DBSetting DB = new DBSetting();
                DB.MdiParent = this.MdiParent;
                DB.Show();
            }
        }
    }
}
