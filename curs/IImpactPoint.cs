using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace curs
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;


        public abstract void ImpactParticle(Particle particle);


        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }

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
       X - R / 2,
       Y - R / 2,
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
}
