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
    public partial class ItakuPrint : Form
    {
        public ItakuPrint()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ItakuPrint_Load(object sender, EventArgs e)
        {
            gcMultiRow1.RowCount = 100;
        }
    }
}
