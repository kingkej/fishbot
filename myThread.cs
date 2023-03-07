// Decompiled with JetBrains decompiler
// Type: gta_rp.MyThread
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace gta_rp
{
  public class MyThread
  {
    public Thread thread;
    private Bitmap bmp;
    private Graphics graphics;
    private IntPtr dstPtr;
    private IntPtr srcPtr;
    private int scr_w;
    private int scr_h;
    public bool threadStop;

    public IntPtr procHandle { get; set; }

    public Form MainForm { get; set; }

    public GtaStruct gtaItem { get; set; }

    public Label labelWorkStatus { get; set; }

    public Label Test { get; set; }

    private bool checkAutoBox { get; set; }

    private bool checkBoxUse { get; set; }

    public bool robotClick { get; set; }

    public int speedClick { get; set; }

    public MyThread(
      GtaStruct gtaItem,
      IntPtr mainWindowHandle,
      bool checkAutoBox,
      bool checkBoxUse,
      int speedClick)
    {
      this.srcPtr = Engine.GetWindowDC(mainWindowHandle);
      this.procHandle = mainWindowHandle;
      this.checkAutoBox = checkAutoBox;
      this.checkBoxUse = checkBoxUse;
      this.speedClick = speedClick;
      this.threadStop = false;
      this.MainForm = this.MainForm;
      Engine.GetWindowSize(mainWindowHandle, ref this.scr_w, ref this.scr_h);
      this.bmp = new Bitmap(this.scr_w, this.scr_h);
      this.graphics = Graphics.FromImage((Image) this.bmp);
      this.gtaItem = gtaItem;
      this.thread = new Thread(new ParameterizedThreadStart(this.thread_Work));
    }

    public void Start() => this.thread.Start();

    private bool WithBox { get; set; }

    public void thread_Work(object obj)
    {
      bool flag1 = false;
      bool flag2 = false;
      int num = 0;
      bool flag3 = false;
      while (!this.threadStop)
      {
        this.Screenshot();
        Bitmap bmp1 = this.bmp;
        Color color = this.gtaItem.mouseColor;
        Color colorBase1 = Color.FromArgb(color.ToArgb());
        int mouseStartX = this.gtaItem.mouseStartX;
        int mouseEndX = this.gtaItem.mouseEndX;
        int mouseStartY = this.gtaItem.mouseStartY;
        int mouseEndY = this.gtaItem.mouseEndY;
        int mouseColorDist = this.gtaItem.mouseColorDist;
        if (Engine.ColorDistance(bmp1, colorBase1, mouseStartX, mouseEndX, mouseStartY, mouseEndY, mouseColorDist))
        {
          Engine.ClickToCoordinateRandom(this.procHandle, 300, 305);
          Thread.Sleep(this.speedClick);
          this.setStatus("Вытаскиваю рыбину");
          if (flag3 && num > 1)
          {
            num = 0;
            flag3 = false;
          }
        }
        else if (Engine.ColorDistance(this.bmp, this.gtaItem.capchaColor, this.gtaItem.capchaStartX, this.gtaItem.capchaEndX, this.gtaItem.capchaStartY, this.gtaItem.capchaEndY, this.gtaItem.capchaColorDist))
        {
          if (!flag1)
          {
            flag1 = true;
            Engine.PlayAlarm("capcha.wav");
            if (this.robotClick)
            {
              this.setStatus("Я робот! Жду 5 минут...");
              Engine.ClickToCoordinate(this.procHandle, (this.gtaItem.capchaStartX + this.gtaItem.capchaEndX) / 2, (this.gtaItem.capchaStartY + this.gtaItem.capchaEndY) / 2);
              Thread.Sleep(300000);
              Thread.Sleep(5000);
              flag2 = true;
            }
            else
              this.setStatus("Капча, нужно разобраться");
            Thread.Sleep(this.gtaItem.capchaAfterSleep);
          }
          else
            continue;
        }
        else if (Engine.ColorDistance(this.bmp, this.gtaItem.msgOkColor, this.gtaItem.msgOkStartX, this.gtaItem.msgOkEndX, this.gtaItem.msgOkStartY, this.gtaItem.msgOkEndY, this.gtaItem.msgOkColorDist) | flag2)
        {
          flag2 = false;
          if (Engine.ColorDistance(this.bmp, this.gtaItem.iconColor, this.gtaItem.iconStartX, this.gtaItem.iconEndX, this.gtaItem.iconStartY, this.gtaItem.iconEndY, this.gtaItem.iconColorDist))
          {
            flag1 = false;
            Engine.Key_Press(this.procHandle, 73);
            this.setStatus("Открыл инвертарь.");
            Thread.Sleep(1500);
            this.Screenshot();
            Bitmap bmp2 = this.bmp;
            color = this.gtaItem.fullBoxColor;
            Color colorBase2 = Color.FromArgb(color.ToArgb());
            int fullBoxStartX = this.gtaItem.fullBoxStartX;
            int fullBoxEndX = this.gtaItem.fullBoxEndX;
            int fullBoxStartY = this.gtaItem.fullBoxStartY;
            int fullBoxEndY = this.gtaItem.fullBoxEndY;
            int fullBoxColorDist = this.gtaItem.fullBoxColorDist;
            if (Engine.ColorDistance(bmp2, colorBase2, fullBoxStartX, fullBoxEndX, fullBoxStartY, fullBoxEndY, fullBoxColorDist))
            {
              this.setStatus("Заполнен");
              ++num;
            }
            this.WithBox = !this.checkAutoBox ? this.checkBoxUse : Engine.ColorDistanceCount(this.bmp, this.gtaItem.getRectNoBoxPixelColor, this.gtaItem.getRectNoBoxStartX, this.gtaItem.getRectNoBoxEndX, this.gtaItem.getRectNoBoxStartY, this.gtaItem.getRectNoBoxEndY, this.gtaItem.getRectNoBoxPixelColorDist, this.gtaItem.getRectNoBoxCount) < this.gtaItem.getRectNoBoxCount;
            if (this.WithBox)
            {
              Bitmap bmp3 = this.bmp;
              color = this.gtaItem.primankaColor;
              Color colorBase3 = Color.FromArgb(color.ToArgb());
              int primankaWithBoxStartX = this.gtaItem.primankaWithBoxStartX;
              int primankaWithBoxEndX = this.gtaItem.primankaWithBoxEndX;
              int primankaWithBoxStartY = this.gtaItem.primankaWithBoxStartY;
              int primankaWithBoxEndY = this.gtaItem.primankaWithBoxEndY;
              int primankaColorDist = this.gtaItem.primankaColorDist;
              if (!Engine.ColorDistance(bmp3, colorBase3, primankaWithBoxStartX, primankaWithBoxEndX, primankaWithBoxStartY, primankaWithBoxEndY, primankaColorDist))
              {
                this.setStatus("Кончилась приманка");
                Engine.PlayAlarm("noprimanka.wav");
              }
              else
              {
                switch (num)
                {
                  case 0:
                    this.clickFishroadWithBox();
                    break;
                  case 1:
                    if (!flag3)
                    {
                      this.MoveToBox();
                      flag3 = true;
                    }
                    this.clickFishroadWithBox();
                    break;
                  default:
                    Engine.PlayAlarm("fullbox.wav");
                    this.setStatus("Заполнен");
                    break;
                }
              }
            }
            else
            {
              Bitmap bmp3 = this.bmp;
              color = this.gtaItem.primankaColor;
              Color colorBase3 = Color.FromArgb(color.ToArgb());
              int primankaWithNoBoxStartX = this.gtaItem.primankaWithNoBoxStartX;
              int primankaWithNoBoxEndX = this.gtaItem.primankaWithNoBoxEndX;
              int primankaWithNoBoxStartY = this.gtaItem.primankaWithNoBoxStartY;
              int primankaWithNoBoxEndY = this.gtaItem.primankaWithNoBoxEndY;
              int primankaColorDist = this.gtaItem.primankaColorDist;
              if (!Engine.ColorDistance(bmp3, colorBase3, primankaWithNoBoxStartX, primankaWithNoBoxEndX, primankaWithNoBoxStartY, primankaWithNoBoxEndY, primankaColorDist))
              {
                this.setStatus("Кончилась приманка");
                Engine.PlayAlarm("noprimanka.wav");
              }
              else if (num == 0)
              {
                this.clickFishroad();
              }
              else
              {
                Engine.PlayAlarm("fullbox.wav");
                this.setStatus("Заполнен");
              }
            }
          }
          else
            Thread.Sleep(20);
        }
        Thread.Sleep(this.gtaItem.msgOkAfterSleep);
      }
    }

    private void MoveToBox()
    {
      int primankaWithBoxStartX = this.gtaItem.primankaWithBoxStartX;
      int primankaWithBoxStartY = this.gtaItem.primankaWithBoxStartY;
      Engine.MoveTo(this.procHandle, primankaWithBoxStartX + 140, primankaWithBoxStartY + 39, primankaWithBoxStartX - 50, primankaWithBoxStartY + 465, 300);
      Engine.MoveTo(this.procHandle, primankaWithBoxStartX + 230, primankaWithBoxStartY + 39, primankaWithBoxStartX + 40, primankaWithBoxStartY + 460, 400);
      Engine.MoveTo(this.procHandle, primankaWithBoxStartX + 315, primankaWithBoxStartY + 39, primankaWithBoxStartX + 140, primankaWithBoxStartY + 465, 400);
      Engine.MoveTo(this.procHandle, primankaWithBoxStartX - 46, primankaWithBoxStartY + 125, primankaWithBoxStartX + 230, primankaWithBoxStartY + 465, 400);
      Engine.MoveTo(this.procHandle, primankaWithBoxStartX + 40, primankaWithBoxStartY + 125, primankaWithBoxStartX + 320, primankaWithBoxStartY + 465, 400);
      Engine.MoveTo(this.procHandle, primankaWithBoxStartX + 140, primankaWithBoxStartY + 125, primankaWithBoxStartX - 50, primankaWithBoxStartY + 560, 400);
      Engine.MoveTo(this.procHandle, primankaWithBoxStartX + 220, primankaWithBoxStartY + 125, primankaWithBoxStartX + 40, primankaWithBoxStartY + 560, 400);
    }

    public void clickFishroad()
    {
      this.setStatus("Сумки нет, достал удочку");
      Engine.ClickToCoordinate(this.procHandle, this.gtaItem.fishrodX, this.gtaItem.fishrodY);
      Thread.Sleep(800);
      this.setStatus("Закинул удочку");
      Engine.ClickToCoordinate(this.procHandle, this.gtaItem.fishLureX, this.gtaItem.fishLureY);
      Thread.Sleep(4000);
    }

    public void clickFishroadWithBox()
    {
      this.setStatus("Сумка есть, достал удочку");
      Engine.ClickToCoordinate(this.procHandle, this.gtaItem.fishrodWithBoxX, this.gtaItem.fishrodWithBoxY);
      Thread.Sleep(800);
      this.setStatus("Закинул удочку");
      Engine.ClickToCoordinate(this.procHandle, this.gtaItem.fishLureWithBoxX, this.gtaItem.fishLureWithBoxY);
      Thread.Sleep(4000);
    }

    public void Screenshot()
    {
      this.dstPtr = this.graphics.GetHdc();
      long num = (long) Engine.BitBlt(this.dstPtr, 0, 0, this.scr_w, this.scr_h, this.srcPtr, 0, 0, 13369376);
      this.graphics.ReleaseHdc(this.dstPtr);
    }

    public void setStatus(string status_str) => this.labelWorkStatus.Invoke((Action) (() => labelWorkStatus.Text = status_str.ToString()));


    public void Calc(Image image)
    {
    }
  }
}
