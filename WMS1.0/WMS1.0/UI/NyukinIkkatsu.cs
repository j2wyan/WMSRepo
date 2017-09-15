using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS_V1.UI
{
    public partial class NyukinIkkatsu : Form
    {
        public NyukinIkkatsu()
        {
            InitializeComponent();
        }

        private void NyukinIkkatsu_Load(object sender, EventArgs e)
        {
            gcMultiRow1.RowCount = 90;
        }
    }
}
