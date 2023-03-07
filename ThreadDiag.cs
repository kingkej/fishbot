// Decompiled with JetBrains decompiler
// Type: gta_rp.ThreadDiag
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace gta_rp
{
  internal class ThreadDiag
  {
    private const int SRCCOPY = 13369376;
    public Thread thread;
    private IntPtr mainWindowHandle = IntPtr.Zero;
    private Graphics grDest;
    private Bitmap bmpDest;
    private IntPtr dstPtr;
    private IntPtr srcPtr;
    private int scr_w;
    private int scr_h;

    public PictureBox picture { get; set; }

    public Label holstlabel { get; set; }

    public ThreadDiag(IntPtr mainWindowHandle)
    {
      this.srcPtr = Engine.GetWindowDC(mainWindowHandle);
      Engine.GetWindowSize(mainWindowHandle, ref this.scr_w, ref this.scr_h);
      this.bmpDest = new Bitmap(this.scr_w, this.scr_h);
      this.grDest = Graphics.FromImage((Image) this.bmpDest);
      this.thread = new Thread(new ThreadStart(this.thread_Work));
      this.mainWindowHandle = mainWindowHandle;
    }

    public void Start() => this.thread.Start();

    public void thread_Work()
    {
      while (true)
      {
        Engine.Key_Press(this.mainWindowHandle, 73);
        Thread.Sleep(500);
        this.Screenshot();
        Thread.Sleep(2500);
        Engine.Key_Press(this.mainWindowHandle, 73);
        Thread.Sleep(500);
        this.Screenshot();
        Thread.Sleep(2500);
      }
    }

    public void Screenshot()
    {
      this.dstPtr = this.grDest.GetHdc();
      long num = (long) Engine.BitBlt(this.dstPtr, 0, 0, this.scr_w, this.scr_h, this.srcPtr, 0, 0, 13369376);
      this.picture.Image = (Image) this.bmpDest;
      this.grDest.ReleaseHdc(this.dstPtr);
      this.holstlabel.Invoke((Action) (() => this.holstlabel.Text = string.Format("Размер холста {0}x{1}", (object) this.scr_w, (object) this.scr_h)));
    }
  }
}
