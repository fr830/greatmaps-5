﻿
namespace Demo.WindowsForms
{
   using System.Windows.Forms;
   using GMap.NET.WindowsForms;
   using System.Drawing;

   /// <summary>
   /// custom map of GMapControl
   /// </summary>
   public class Map : GMapControl
   {
      public long ElapsedMilliseconds;

#if DEBUG
      private int counter;
      readonly Font DebugFont = new Font(FontFamily.GenericSansSerif, 36, FontStyle.Regular);
      readonly Font DebugFontSmall = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);

#endif

      /// <summary>
      /// any custom drawing here
      /// </summary>
      /// <param name="drawingContext"></param>
      protected override void OnPaintEtc(System.Drawing.Graphics g)
      {
         base.OnPaintEtc(g);

         g.ResetTransform();

#if DEBUG
         g.DrawString(Zoom + "z, " + MapType + ", render: " + counter++ + ", load: " + ElapsedMilliseconds + "ms", DebugFont, Brushes.Blue, DebugFont.Height, DebugFont.Height);

         g.DrawString(ViewAreaPixel.Location.ToString(), DebugFontSmall, Brushes.Blue, DebugFontSmall.Height, DebugFontSmall.Height);

         string lb = ViewAreaPixel.LeftBottom.ToString();
         var lbs = g.MeasureString(lb, DebugFontSmall);
         g.DrawString(lb, DebugFontSmall, Brushes.Blue, DebugFontSmall.Height, Height - DebugFontSmall.Height*2);

         string rb = ViewAreaPixel.RightBottom.ToString();
         var rbs = g.MeasureString(rb, DebugFontSmall);
         g.DrawString(rb, DebugFontSmall, Brushes.Blue, Width - rbs.Width - DebugFontSmall.Height, Height - DebugFontSmall.Height*2);

         string rt = ViewAreaPixel.RightTop.ToString();
         var rts = g.MeasureString(rb, DebugFontSmall);
         g.DrawString(rt, DebugFontSmall, Brushes.Blue, Width - rts.Width - DebugFontSmall.Height, DebugFontSmall.Height);
#endif
      }
   }
}
