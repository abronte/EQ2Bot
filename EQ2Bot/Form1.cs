using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EQ2Bot
{
    public partial class Form1 : Form
    {
        private EQmemory eqmem;

        public Form1()
        {
            eqmem = new EQmemory();
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (eqmem.findEQ())
            {
                this.pxLabel.Text = eqmem.getXPos().ToString();
                this.pyLabel.Text = eqmem.getYPos().ToString();
                this.pzLabel.Text = eqmem.getZPos().ToString();
            }
        }
    }
}
