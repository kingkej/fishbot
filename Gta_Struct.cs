// Decompiled with JetBrains decompiler
// Type: gta_rp.GtaStruct
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System.Drawing;

namespace gta_rp
{
  public class GtaStruct
  {
    public GtaStruct.VideoSize videoSize { get; set; }

    public string videoSizeTitle
    {
      get => string.Format("{0}x{1}", (object) this.videoSize.width, (object) this.videoSize.height);
      set
      {
      }
    }

    public Color mouseColor { get; set; }

    public int mouseColorDist { get; set; }

    public int mouseStartX { get; set; }

    public int mouseEndX { get; set; }

    public int mouseStartY { get; set; }

    public int mouseEndY { get; set; }

    public int mouseAfterSleep { get; set; }

    public Color msgOkColor { get; set; }

    public int msgOkColorDist { get; set; }

    public int msgOkStartX { get; set; }

    public int msgOkEndX { get; set; }

    public int msgOkStartY { get; set; }

    public int msgOkEndY { get; set; }

    public int msgOkAfterSleep { get; set; }

    public Color fullBoxColor { get; set; }

    public int fullBoxColorDist { get; set; }

    public int fullBoxLeft { get; set; }

    public int fullBoxTop { get; set; }

    public int fullBoxStartX { get; set; }

    public int fullBoxEndX { get; set; }

    public int fullBoxStartY { get; set; }

    public int fullBoxEndY { get; set; }

    public int fullBoxAfterSleep { get; set; }

    public int fishrodLeft { get; set; }

    public int fishrodTop { get; set; }

    public int fishrodX { get; set; }

    public int fishrodY { get; set; }

    public int fishLureLeft { get; set; }

    public int fishLureTop { get; set; }

    public int fishLureX { get; set; }

    public int fishLureY { get; set; }

    public Color capchaColor { get; set; }

    public int capchaColorDist { get; set; }

    public int capchaStartX { get; set; }

    public int capchaEndX { get; set; }

    public int capchaStartY { get; set; }

    public int capchaEndY { get; set; }

    public int capchaAfterSleep { get; set; }

    public Color iconColor { get; set; }

    public int iconColorDist { get; set; }

    public int iconStartX { get; set; }

    public int iconEndX { get; set; }

    public int iconStartY { get; set; }

    public int iconEndY { get; set; }

    public Color getRectNoBoxPixelColor { get; set; }

    public int getRectNoBoxPixelColorDist { get; set; }

    public int getRectNoBoxCount { get; set; }

    public int getRectNoBoxStartX { get; set; }

    public int getRectNoBoxEndX { get; set; }

    public int getRectNoBoxStartY { get; set; }

    public int getRectNoBoxEndY { get; set; }

    public int fishrodWithBoxLeft { get; set; }

    public int fishrodWithBoxTop { get; set; }

    public int fishrodWithBoxX { get; set; }

    public int fishrodWithBoxY { get; set; }

    public int fishLureWithBoxLeft { get; set; }

    public int fishLureWithBoxTop { get; set; }

    public int fishLureWithBoxX { get; set; }

    public int fishLureWithBoxY { get; set; }

    public Color primankaColor { get; set; }

    public int primankaColorDist { get; set; }

    public int primankaWithNoBoxLeft { get; set; }

    public int primankaWithNoBoxTop { get; set; }

    public int primankaWithNoBoxStartX { get; set; }

    public int primankaWithNoBoxEndX { get; set; }

    public int primankaWithNoBoxStartY { get; set; }

    public int primankaWithNoBoxEndY { get; set; }

    public int primankaWithBoxLeft { get; set; }

    public int primankaWithBoxTop { get; set; }

    public int primankaWithBoxStartX { get; set; }

    public int primankaWithBoxEndX { get; set; }

    public int primankaWithBoxStartY { get; set; }

    public int primankaWithBoxEndY { get; set; }

    public class VideoSize
    {
      public int width { get; set; }

      public int height { get; set; }
    }
  }
}
