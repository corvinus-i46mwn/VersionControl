using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;

namespace week08.Entitites
{
    class Present:Toy
    {
        public SolidBrush RibbonColor { get; private set; }
        public SolidBrush BoxColor { get; private set; }
        public Present(Color ribbon, Color box)
        {
            RibbonColor = new SolidBrush(ribbon);
            BoxColor = new SolidBrush(box);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(BoxColor, 0, 0, Width, Height);
            
            g.FillRectangle(RibbonColor, Width/2, 0, Width / 5, Height);
            g.FillRectangle(RibbonColor, 0, Height/2, Width, Height / 5);
        }
    }
}
