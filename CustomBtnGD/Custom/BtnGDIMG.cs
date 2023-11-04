using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MUnlockedCustomButttonGradient
{
    public partial class BtnGDIMG : UserControl
    {
        private int wh = 20;
        private float ang = 45;
        private Color cl0 = Color.DarkTurquoise;
        private Color cl1 = Color.Magenta;
        private Timer t = new Timer();
        private string buttonText = "Ingresa tu texto";
        private Font buttonTextFont = DefaultFont;
        private Point buttonImageLocation = new Point(0, 0);


        public BtnGDIMG()
        {
            DoubleBuffered = true;
            t.Interval = 1;
            t.Start();
            t.Tick += (s, e) => { Angle = Angle % 360 + 1; };
            ForeColor = Color.White;
            ImageWidth = 150;
            ImageHeight = 150;
        }

        public int TextX { get; set; }
        public int TextY { get; set; }

        public Image ButtonImage { get; set; }

        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }

        public int ImageX
        {
            get { return buttonImageLocation.X; }
            set { buttonImageLocation.X = value; Invalidate(); }
        }

        public int ImageY
        {
            get { return buttonImageLocation.Y; }
            set { buttonImageLocation.Y = value; Invalidate(); }
        }

        public int BorderRadius
        {
            get { return wh; }
            set { wh = value; Invalidate(); }
        }

        public float Angle
        {
            get { return ang; }
            set { ang = value; Invalidate(); }
        }

        public Color Color0
        {
            get { return cl0; }
            set { cl0 = value; Invalidate(); }
        }

        public Color Color1
        {
            get { return cl1; }
            set { cl1 = value; Invalidate(); }
        }

        public string ButtonText
        {
            get { return buttonText; }
            set { buttonText = value; Invalidate(); }
        }

        public Font ButtonTextFont
        {
            get { return buttonTextFont; }
            set { buttonTextFont = value; Invalidate(); }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(new Rectangle(0, 0, wh, wh), 180, 90);
            gp.AddArc(new Rectangle(Width - wh, 0, wh, wh), -90, 90);
            gp.AddArc(new Rectangle(Width - wh, Height - wh, wh, wh), 0, 90);
            gp.AddArc(new Rectangle(0, Height - wh, wh, wh), 90, 90);

            e.Graphics.FillPath(new LinearGradientBrush(ClientRectangle, cl0, cl1, ang), gp);

            if (ButtonText != null)
            {
                SizeF textSize = e.Graphics.MeasureString(buttonText, Font);
                float textX = (Width - textSize.Width) / 2 + TextX;
                float textY = Height - textSize.Height - 10 + TextY;
                e.Graphics.DrawString(buttonText, Font, new SolidBrush(ForeColor), textX, textY);
            }


            if (ButtonImage != null)
            {
                int imageWidth = ButtonImage.Width;
                int imageHeight = ButtonImage.Height;
                int imageX = buttonImageLocation.X;
                int imageY = buttonImageLocation.Y;

                e.Graphics.DrawImage(ButtonImage, imageX, imageY, ImageWidth, ImageHeight);
            }
        }
    }
}
    
