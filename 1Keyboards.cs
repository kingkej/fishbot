// Decompiled with JetBrains decompiler
// Type: gta_rp.KeyPressedEventArgs
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.Windows.Forms;

namespace gta_rp
{
  public class KeyPressedEventArgs : EventArgs
  {
    private ModifierKeys _modifier;
    private Keys _key;

    internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
    {
      this._modifier = modifier;
      this._key = key;
    }

    public ModifierKeys Modifier => this._modifier;

    public Keys Key => this._key;
  }
}
