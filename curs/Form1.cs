using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curs
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
        GravityPoint point1;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter
            {
                Direction = 90,
                SpeedMin = 11,
                SpeedMax = 15,
                ColorFrom = Color.Blue,
                ColorTo = Color.FromArgb(0, Color.Purple),
                ParticlesPerTick = 60,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 - 65 ,
            };
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            emitter.impactPoints.Add(point1);
        }
        public class GravityPoint : IImpactPoint
        {
            public int Power = 0; // сила притяжения

            // а сюда по сути скопировали с минимальными правками то что было в UpdateState
            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
            public override void Render(Graphics g)
            {
                g.DrawEllipse(
               new Pen(Color.Red),
               X - 50 ,
               Y - 50 ,
               100,
               100
           );
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }
            point1.X = e.X;
            point1.Y = e.Y;
        }

    }

}
