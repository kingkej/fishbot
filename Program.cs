// Decompiled with JetBrains decompiler
// Type: gta_rp.Program
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.Threading;
using System.Windows.Forms;

namespace gta_rp
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      bool createdNew;
      Mutex mutex = new Mutex(true, "MyApplication123", out createdNew);
      if (!createdNew)
      {
        int num = (int) MessageBox.Show("Бот уже запущен, поищите в трее или нажмите F5 чтобы показать");
      }
      else
      {
        Application.Run((Form) new MainForm());
        GC.KeepAlive((object) mutex);
      }
    }
  }
}
