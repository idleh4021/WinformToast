using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toast
{
    public partial class Form1 : Form
    {
        int PositionX = 0;
        int PositionY = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnToastInCenter_Click(object sender, EventArgs e)
        {
            Toast tst = new Toast(this);
            tst.LocationX = this.Size.Width/2-tst.SIZE_X/2;
            tst.LocationY = this.Size.Height - 200;
            tst.Show("test");
        }

        private void btnToastAtMousePointer_Click(object sender, EventArgs e)
        {
            Toast tst = new Toast(this);
            tst.Show("zz", this,PositionX,PositionY,3000);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            PositionX = e.Location.X;
            PositionY = e.Location.Y;
        }
    }
}
