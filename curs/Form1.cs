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
        List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            for (var i = 0; i < 500; ++i)
            {
                var particle = new Particle();
                particle.X = picDisplay.Image.Width / 2;
                particle.Y = picDisplay.Image.Height / 2;
                particles.Add(particle);
            }
        }

        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.DrawString(
                    counter.ToString(),
                    new Font("Arial", 12),
                    new SolidBrush(Color.Black),
                    new PointF
                    {
                        X = picDisplay.Image.Width / 2,
                        Y = picDisplay.Image.Height / 2
                    });
            }
            picDisplay.Invalidate();
        }
    }
}
