﻿using System;
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
                ParticlesPerTick = 5,
                ColorFrom = Color.Blue,
                ColorTo = Color.FromArgb(0, Color.Purple),
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2 - 65,
            };
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            emitter.impactPoints.Add(point1);
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
        private void trackBar1Speed_Scroll(object sender, EventArgs e)
        {
            emitter.Speed = trackBar1Speed.Value;
            trackBar1Speed.Text = $"{trackBar1Speed.Value}°";
        }
        private void trackBar2Value_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = trackBar2Value.Value;
            trackBar2Value.Text = $"{trackBar2Value.Value}°";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            var g = Graphics.FromImage(picDisplay.Image);
            var f = colorDialog1.Color;
            g.Clear(f);
            emitter.Render(g);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
            }
        }
    }
}

