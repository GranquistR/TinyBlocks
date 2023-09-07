﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace MyGameTest
{
    public partial class Game1 : Form
    {
        Graphics g;
        List<Vector3> world = new List<Vector3> { };
        Vector3 cursor = new Vector3(0, 0, 0);

        private void TimerCallback(object sender, EventArgs e)
        {
            this.Invalidate();
            return;
        }
        public Game1()
        {
            var timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 100;  /* 100 millisec */
            timer.Tick += new EventHandler(TimerCallback);
            timer.Start();

            InitializeComponent();
        }

        private void Game1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Brush b = new SolidBrush(Color.Red);


            

            world.Add(new Vector3(4, 10, 1));
            world.Add(new Vector3(4, 11, 1));
            world.Add(new Vector3(5, 10, 1));
            world.Add(new Vector3(5, 11, 1));
            world.Add(new Vector3(4, 10, 2));
            world.Add(new Vector3(4, 11, 2));
            world.Add(new Vector3(5, 10, 2));

            for(int i = 0; i < 10; i++)
            {
                for(int j = 5; j< 15; j++)
                {
                    world.Add(new Vector3(i, j, 0));
                }
            }


            foreach (var coord in world.Append(cursor).OrderBy(coor => coor.z).ThenBy(coor => coor.y).ThenBy(coor => coor.x).ToList())
            {
                drawBox(coord);
            }
        }

        private void drawBox(Vector3 coord)
        {
            Pen p = new Pen(Color.White);
            Brush bTop = new SolidBrush(Color.LightGray);
            Brush bLeft = new SolidBrush(Color.DarkGray);
            Brush bRight = new SolidBrush(Color.DimGray);

            int screenX = coord.y * 43 + -coord.x * 43;
            int screenY = coord.y * 25 + -coord.x * -25 + coord.z * -50;

            //left face
            //Top
            g.FillPolygon(bLeft, new PointF[] { new PointF(screenX, screenY), new PointF(screenX - 43, screenY + 25), new PointF(screenX - 43, screenY - 25) });
            //Bottom
            g.FillPolygon(bLeft, new PointF[] { new PointF(screenX, screenY), new PointF(screenX - 43, screenY + 25), new PointF(screenX, screenY + 50) });

            //right face
            //top
            g.FillPolygon(bRight, new PointF[] { new PointF(screenX, screenY), new PointF(screenX + 43, screenY - 25), new PointF(screenX + 43, screenY + 25) });
            //bottom
            g.FillPolygon(bRight, new PointF[] { new PointF(screenX, screenY), new PointF(screenX + 43, screenY + 25), new PointF(screenX, screenY + 50) });

            //top face
            //right
            g.FillPolygon(bTop, new PointF[] { new PointF(screenX, screenY), new PointF(screenX, screenY - 50), new PointF(screenX + 43, screenY - 25) });
            //left
            g.FillPolygon(bTop, new PointF[] { new PointF(screenX, screenY), new PointF(screenX, screenY - 50), new PointF(screenX - 43, screenY - 25) });

        }

        private void Game1_KeyDown(object sender, KeyEventArgs e)
        {
            //w
            if(e.KeyValue == 87)
            {
                cursor.x -= 1;
            }
            //s
            else if (e.KeyValue == 83)
            {
                cursor.x += 1;
            }
            //a
            else if (e.KeyValue == 65)
            {
                cursor.y -= 1;
            }
            //d
            else if (e.KeyValue == 68)
            {
                cursor.y += 1;
            }
            //q
            else if (e.KeyValue == 81)
            {
                cursor.z += 1;
            }
            //e
            else if (e.KeyValue == 69)
            {
                cursor.z -= 1;
            }
        }
    }
}