using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Kurichev_Lab5
{
    public partial class Form1 : Form
    {
        Ball b1;
        Ball b2;
        Ball b3;
        Ball b4;

        public Form1()
        {
            InitializeComponent();

            b1 = new Ball(this, 0);



            b2 = new Ball(this, 1);
            b3 = new Ball(this, 2);
            b4 = new Ball(this, 3);
        }

    }
}
