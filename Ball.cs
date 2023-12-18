using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Kurichev_Lab5
{
    class Ball
    {
        Image ballimage = Properties.Resources.balltexture;
        Image ballimage1 = Properties.Resources.balltexture1;
        Image ballimage2 = Properties.Resources.balltexture2;
        Image ballimage3 = Properties.Resources.balltexture3;
        PictureBox ballpb = new PictureBox();
        Random rnd = new Random();
        int vx = 35, vy = 35;
        int Xlim = 650;
        int Ylim = 650;
        public delegate void ParameterizedThreadStart(object obj);

        public Ball(Form1 formobj, int colornumber)
        {
            // Текстура взависимости от номера
            switch(colornumber)
            {
                case (0):
                    ballpb.Image = ballimage;
                    break;
                case (1):
                    ballpb.Image = ballimage1;
                    break;
                case (2):
                    ballpb.Image = ballimage2;
                    break;
                case (3):
                    ballpb.Image = ballimage3;
                    break;

            }

            ballpb.Size = new Size(150,150);
            ballpb.Location = new Point(rnd.Next(200, 600), rnd.Next(200, 600)); // Случайная координата
            ballpb.SizeMode = PictureBoxSizeMode.StretchImage;
            ballpb.BackColor = Color.Transparent;

            // Случайны импульс
            vx = rnd.Next(25, 55);
            vy = vx;
            
            //Thread t = new Thread(UpdatePhysics);
            //t.Start(ballpb);

            formobj.Controls.Add(ballpb);

            System.Windows.Forms.Timer ballphysics = new System.Windows.Forms.Timer();
            ballphysics.Enabled = true;
            ballphysics.Interval = 50;
            ballphysics.Tick += new EventHandler(UpdatePhysics);

            System.Windows.Forms.Timer ballphysicsVelocity = new System.Windows.Forms.Timer();
            ballphysicsVelocity.Enabled = true;
            ballphysicsVelocity.Interval = 50;
            ballphysicsVelocity.Tick += new EventHandler(UpdateVelocity);
        }

        public void UpdatePhysics(Object myObject, EventArgs myEventArgs)
        {
                if (ballpb.Left > Xlim || ballpb.Left <= 0) vx *= -1;
                if (ballpb.Top > Ylim || ballpb.Top <= 0) vy *= -1;
                ballpb.Left += vx;
                ballpb.Top += vy;
        }

        public void UpdateVelocity(Object myObject, EventArgs myEventArgs)
        {
                if (vx > 0 && vy > 0)
                {
                    vx = vx - 1;
                    vy = vy - 1;
                }

                if (vx < 0 && vy < 0)
                {
                    vx = vx + 1;
                    vy = vy + 1;
                }
        }
    }
}
