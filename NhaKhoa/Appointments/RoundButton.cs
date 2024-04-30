using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoa.Appointments
{
    internal class RoundButton :Button
    {
        public int BorderRadius { get; set; } = 5; // Set the default border radius

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, BorderRadius * 2, BorderRadius * 2, 180, 90); // Top-left corner
            path.AddArc(Width - BorderRadius * 2, 0, BorderRadius * 2, BorderRadius * 2, 270, 90); // Top-right corner
            path.AddArc(Width - BorderRadius * 2, Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 0, 90); // Bottom-right corner
            path.AddArc(0, Height - BorderRadius * 2, BorderRadius * 2, BorderRadius * 2, 90, 90); // Bottom-left corner
            path.CloseFigure();
            this.Region = new Region(path);

            // Optional: You can also customize other properties of the button such as BackColor, ForeColor, etc.
        }
    }
}
