// Decompiled with JetBrains decompiler
// Type: gta_rp.Properties.Settings
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace gta_rp.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool chekBoxAuto
    {
      get => (bool) this[nameof (chekBoxAuto)];
      set => this[nameof (chekBoxAuto)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool chekBoxUse
    {
      get => (bool) this[nameof (chekBoxUse)];
      set => this[nameof (chekBoxUse)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool configAuto
    {
      get => (bool) this[nameof (configAuto)];
      set => this[nameof (configAuto)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool robotClick
    {
      get => (bool) this[nameof (robotClick)];
      set => this[nameof (robotClick)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int speedClick
    {
      get => (int) this[nameof (speedClick)];
      set => this[nameof (speedClick)] = (object) value;
    }
  }
}
