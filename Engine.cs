// Decompiled with JetBrains decompiler
// Type: gta_rp.Engine
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using xNet;

namespace gta_rp
{
  public static class Engine
  {
    private const int WM_LBUTTONDOWN = 513;
    private const int WM_LBUTTONUP = 514;
    private const int WM_LBUTTONDBLCLK = 515;
    public const string serverScript = "http://radiopribori.ru/gta5rp/activate.php";
    public const string serverConfig = "http://radiopribori.ru/gta5rp/config3.json";
    public const string localConfig = "config3.json";
    public const string fishPriceScript = "http://radiopribori.ru/gta5rp/fish_price_script.php";
    public const string SavedkeyFileName = "Key.gtakey";
    private const int WM_ACTIVATE = 6;

    public static Process MyProcess { get; set; } = new Process();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool GetWindowRect(IntPtr hwnd, out Engine.RECT lpRect);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowInfo(IntPtr hwnd, ref Engine.WINDOWINFO pwi);

    [DllImport("gdi32.dll")]
    public static extern ulong BitBlt(
      IntPtr hDestDC,
      int x,
      int y,
      int nWidth,
      int nHeight,
      IntPtr hSrcDC,
      int xSrc,
      int ySrc,
      int dwRop);

    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr h);

    [DllImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteObject([In] IntPtr ho);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

    [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hwnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetActiveWindow(IntPtr hWnd);

    public static string fishPriceFile(string server) => string.Format("http://radiopribori.ru/gta5rp/fish_price_{0}.json", (object) server);

    public static string GetSerialNum()
    {
      ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE NOT InterfaceType LIKE 'USB%'");
      try
      {
        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
        {
          if (enumerator.MoveNext())
            return enumerator.Current["SerialNumber"].ToString();
        }
      }
      catch (Exception ex)
      {
        return "";
      }
      return "";
    }

    public static string GET(string Url)
    {
      //StreamReader streamReader = new StreamReader(WebRequest.Create(Url).GetResponse().GetResponseStream());
      //string end = streamReader.ReadToEnd();
     //streamReader.Close();
      return "";
    }

    public static string POST(string strData, string url)
    {
      using (HttpRequest httpRequest = new HttpRequest())
        return httpRequest.Post(url, strData, "application/json").ToString();
    }

    private static bool isGTAProcess(string processName)
    {
      processName = processName.Replace(" ", "");
      return processName.Length == 15 && processName[0] == 'R' && (processName[2] == 'G' && processName[5] == 'u') && processName[7] == 't';
    }

    public static async Task<Process> GetMyProcessAsync() => await Task.Run<Process>((Func<Process>) (() => Engine.GetMyProcess()));

    public static Process GetMyProcess()
    {
      try
      {
        foreach (Process process in Process.GetProcesses())
        {
          if (process.MainWindowTitle != string.Empty && Engine.isGTAProcess(process.MainWindowTitle))
          {
            Engine.MyProcess = process;
            return process;
          }
        }
        Engine.MyProcess = (Process) null;
        return (Process) null;
      }
      catch
      {
        Engine.MyProcess = (Process) null;
        return (Process) null;
      }
    }

    public static bool GetWindowSize(IntPtr hWnd, ref int out_width, ref int out_heigth)
    {
      Engine.WINDOWINFO pwi = new Engine.WINDOWINFO();
      try
      {
        pwi.cbSize = (uint) Marshal.SizeOf((object) pwi);
        Engine.GetWindowInfo(hWnd, ref pwi);
      }
      catch (Exception ex)
      {
        return false;
      }
      out_width = pwi.rcClient.Right - pwi.rcClient.Left;
      out_heigth = pwi.rcClient.Bottom - pwi.rcClient.Top;
      return true;
    }

    public static void ActivateWnd(IntPtr handle) => Engine.PostMessage(handle, 6U, IntPtr.Zero, IntPtr.Zero);

    public static void Key_Press(IntPtr handle, int keyCode)
    {
      Engine.ActivateWnd(handle);
      Engine.SendMessage(handle, 256, (IntPtr) keyCode, IntPtr.Zero);
      Engine.SendMessage(handle, 257, (IntPtr) keyCode, IntPtr.Zero);
    }

    public static void ClickToCoordinate(IntPtr handle, int x, int y)
    {
      Engine.ActivateWnd(handle);
      Engine.SendMessage(handle, 513, IntPtr.Zero, new IntPtr(y * 65536 + x));
      Engine.SendMessage(handle, 514, IntPtr.Zero, new IntPtr(y * 65536 + x));
    }

    public static void ClickToCoordinate2(IntPtr handle, int x, int y)
    {
      Engine.ActivateWnd(handle);
      Engine.PostMessage(handle, 513U, IntPtr.Zero, new IntPtr(y * 65536 + x));
      Engine.PostMessage(handle, 514U, IntPtr.Zero, new IntPtr(y * 65536 + x));
    }

    public static void ClickToCoordinateRandom(IntPtr handle, int xStart, int yStart)
    {
      Engine.ActivateWnd(handle);
      Random random = new Random();
      Engine.PostMessage(handle, 513U, IntPtr.Zero, new IntPtr(random.Next(yStart, yStart + 300) * 65536 + random.Next(xStart, xStart + 300)));
      Engine.PostMessage(handle, 514U, IntPtr.Zero, new IntPtr(random.Next(yStart, yStart + 300) * 65536 + random.Next(xStart, xStart + 300)));
    }

    public static void MoveTo(IntPtr handle, int x1, int y1, int x2, int y2, int waitSec)
    {
      Engine.ActivateWnd(handle);
      Engine.SendMessage(handle, 513, IntPtr.Zero, new IntPtr(y1 * 65536 + x1));
      Thread.Sleep(waitSec);
      Engine.SendMessage(handle, 514, IntPtr.Zero, new IntPtr(y2 * 65536 + x2));
      Thread.Sleep(waitSec);
    }

    public static void PlayAlarm(string fileName)
    {
        try
        {
            using (SoundPlayer soundPlayer = new SoundPlayer(fileName))
                soundPlayer.Play();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public static bool SearchPixel(
      Bitmap bitmap,
      Color searchColor,
      int xStart,
      int xEnd,
      int yStart,
      int yEnd)
    {
      try
      {
        for (int y = yStart; y < yEnd; ++y)
        {
          for (int x = xStart; x < xEnd; ++x)
          {
            if (searchColor == bitmap.GetPixel(x, y))
              return true;
          }
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      return false;
    }

    public static int SearchPixelCount(
      Bitmap bitmap,
      Color searchColor,
      int xStart,
      int xEnd,
      int yStart,
      int yEnd)
    {
      int num = 0;
      for (int y = yStart; y < yEnd; ++y)
      {
        for (int x = xStart; x < xEnd; ++x)
        {
          if (searchColor == bitmap.GetPixel(x, y))
            ++num;
        }
      }
      return num;
    }

    public static double ColorDistanceEx(Color search_color, Color colorBase)
    {
      double x1 = (double) Math.Abs((int) colorBase.R - (int) search_color.R);
      double x2 = (double) Math.Abs((int) colorBase.G - (int) search_color.G);
      double x3 = (double) Math.Abs((int) colorBase.B - (int) search_color.B);
      return (Math.Sqrt(Math.Pow(x1, 2.0) + Math.Pow(x2, 2.0)) + Math.Sqrt(Math.Pow(x2, 2.0) + Math.Pow(x3, 2.0)) + Math.Sqrt(Math.Pow(x3, 2.0) + Math.Pow(x1, 2.0))) / 3.0;
    }

    public static int ColorDistanceCount(
      Bitmap bitmap,
      Color colorBase,
      int xStart,
      int xEnd,
      int yStart,
      int yEnd,
      int dist,
      int minCount)
    {
      int num = 0;
      for (int y = yStart; y < yEnd; ++y)
      {
        for (int x = xStart; x < xEnd; ++x)
        {
          if (Engine.ColorDistanceEx(bitmap.GetPixel(x, y), colorBase) <= (double) dist)
          {
            ++num;
            if (num >= minCount)
              return num;
          }
        }
      }
      return num;
    }

    public static bool ColorDistance(
      Bitmap bitmap,
      Color colorBase,
      int xStart,
      int xEnd,
      int yStart,
      int yEnd,
      int dist)
    {
      for (int y = yStart; y < yEnd; ++y)
      {
        for (int x = xStart; x < xEnd; ++x)
        {
          if (Engine.ColorDistanceEx(bitmap.GetPixel(x, y), colorBase) <= (double) dist)
            return true;
        }
      }
      return false;
    }

    public struct RECT
    {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;
    }

    private struct WINDOWINFO
    {
      public uint cbSize;
      public Engine.RECT rcWindow;
      public Engine.RECT rcClient;
      public uint dwStyle;
      public uint dwExStyle;
      public uint dwWindowStatus;
      public uint cxWindowBorders;
      public uint cyWindowBorders;
      public ushort atomWindowType;
      public ushort wCreatorVersion;

      public WINDOWINFO(bool? filler)
        : this()
        => this.cbSize = (uint) Marshal.SizeOf(typeof (Engine.WINDOWINFO));
    }
  }
}
