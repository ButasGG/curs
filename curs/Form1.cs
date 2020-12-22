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
            picDisplay.MouseWheel += picDisplay_MouseWheel;
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter
            {
                Direction = 90,
                SpeedMin = 11,
                SpeedMax = 15,
                ColorFrom = Color.Blue,
                ColorTo = Color.FromArgb(0, Color.Purple),
                ParticlesPerTick = 30,
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
            List<Particle> particles = new List<Particle>();
            public int R = 100;
            public int m = 0;
            public int s = 0;
            public int b = 0;

            public override void ImpactParticle(Particle particle)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;

                double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
                if (r + particle.Radius < R / 2) // если частица оказалось внутри окружности
                {
                    particles.Add(particle);
                    if (particle.Radius < 4)
                    {
                        m++;
                    }
                    else
                    {
                        if (particle.Radius < 8)
                        {
                            s++;
                        }
                        else
                        {
                            b++;
                        }
                    }
                }
            }
            public override void Render(Graphics g)
            {
                
                g.DrawEllipse(
               new Pen(Color.Red),
               X - 50,
               Y - 50,
               R,
               R
           );

                foreach (var particle in particles)
                {
                    var b = new SolidBrush(Color.Red);

                    g.FillEllipse(b, particle.X - particle.Radius, particle.Y - particle.Radius, particle.Radius * 2, particle.Radius * 2);
                    
                }
                particles.Clear();
                g.DrawString(
            $"Маленьких:{m},средних:{s},больших:{b}",
            new Font("Verdana", 10), // шрифт и его размер
            new SolidBrush(Color.White), // цвет шрифта
            X - 20, // расположение в пространстве
            Y - 31
        );
                m = 0;
                s = 0;
                b = 0;

            }
        }
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && point1.R > 5)
            {
                point1.R -= 5;
            }
            else if (e.Delta > 0 && point1.R < 300)
            {
                point1.R += 5;
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
