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
    public partial class Zaikoichiran : Form
    {
        public Zaikoichiran()
        {
            InitializeComponent();
        }

        private void Zaikoichiran_Load(object sender, EventArgs e)
        {
            gcMultiRow1.RowCount = 30;
        }
    }
}
