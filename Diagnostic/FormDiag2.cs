// Decompiled with JetBrains decompiler
// Type: gta_rp.FormDiag2
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace gta_rp
{
  public class FormDiag2 : Form
  {
    private Process myProcess;
    private FormMouse formMouse = new FormMouse();
    private FormMsgOk formMsgOk = new FormMsgOk();
    private FormFishIcon formFishIcon = new FormFishIcon();
    private FormFullBox formFullBox = new FormFullBox();
    private FormFishrod formFishrod = new FormFishrod();
    private FormFishrodWithBox formFishrodWithBox = new FormFishrodWithBox();
    private FormFishLure formFishLure = new FormFishLure();
    private FormFishLureWithBox formFishLureWithBox = new FormFishLureWithBox();
    private FormGetRectNoBox formGetRectNoBox = new FormGetRectNoBox();
    private FormCapcha formCapcha = new FormCapcha();
    private FormPrimankaWithBox formPrimankaWithBox = new FormPrimankaWithBox();
    private FormPrimankaWithNoBox formPrimankaWithNoBox = new FormPrimankaWithNoBox();
    private List<GtaStruct> gta = new List<GtaStruct>();
    private IContainer components;
    private ComboBox comboDiagVideoSize;
    private Button button1;
    private Button button2;
    private Button buttonClose;
    private Panel panel1;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool GetWindowRect(IntPtr hwnd, out FormDiag2.RECT lpRect);

    public FormDiag2() => this.InitializeComponent();

    public void SetFormParams(Form form)
    {
      form.MinimumSize = new Size(1, 1);
      form.FormBorderStyle = FormBorderStyle.None;
      form.TopMost = true;
      form.ControlBox = false;
      form.ShowInTaskbar = false;
    }

    private void GetSizes()
    {
      if (!File.Exists("config3.json"))
      {
        int num1 = (int) MessageBox.Show("Конфигурация не найдена, будет создана новая.");
        File.WriteAllText("config3.json", Engine.GET("http://radiopribori.ru/gta5rp/config3.json"));
        if (!File.Exists("config3.json"))
        {
          int num2 = (int) MessageBox.Show("Не удалось получить или создать файл конфигурации. Возможно требуется запуск от администратора, или выставить права для записи.");
          return;
        }
      }
      this.gta = JsonConvert.DeserializeObject<List<GtaStruct>>(File.ReadAllText("config3.json"));
      this.comboDiagVideoSize.DataSource = (object) this.gta;
      this.comboDiagVideoSize.DisplayMember = "VideoSizeTitle";
      Engine.GetMyProcess();
      int out_width = 0;
      int out_heigth = 0;
      Engine.GetWindowSize(Engine.MyProcess.MainWindowHandle, ref out_width, ref out_heigth);
      for (int index = 0; index < this.comboDiagVideoSize.Items.Count; ++index)
      {
        if (((GtaStruct) this.comboDiagVideoSize.Items[index]).videoSizeTitle == string.Format("{0}x{1}", (object) out_width, (object) out_heigth))
        {
          this.comboDiagVideoSize.SelectedIndex = index;
          break;
        }
      }
    }

    private void FormDiag2_Load(object sender, EventArgs e)
    {
      this.GetSizes();
      this.SetFormParams((Form) this.formMouse);
      this.SetFormParams((Form) this.formMsgOk);
      this.SetFormParams((Form) this.formFishIcon);
      this.SetFormParams((Form) this.formFullBox);
      this.SetFormParams((Form) this.formFishrod);
      this.SetFormParams((Form) this.formFishrodWithBox);
      this.SetFormParams((Form) this.formFishLure);
      this.SetFormParams((Form) this.formFishLureWithBox);
      this.SetFormParams((Form) this.formGetRectNoBox);
      this.SetFormParams((Form) this.formCapcha);
      this.SetFormParams((Form) this.formPrimankaWithBox);
      this.SetFormParams((Form) this.formPrimankaWithNoBox);
      this.myProcess = Engine.GetMyProcess();
    }

    public void GetLocationForms(ref GtaStruct gtaItem)
    {
      FormDiag2.RECT lpRect;
      FormDiag2.GetWindowRect(this.myProcess.MainWindowHandle, out lpRect);
      this.formMouse.Show();
      this.formMsgOk.Show();
      this.formFishIcon.Show();
      this.formFullBox.Show();
      this.formFishrod.Show();
      this.formFishrodWithBox.Show();
      this.formFishLure.Show();
      this.formFishLureWithBox.Show();
      this.formGetRectNoBox.Show();
      this.formCapcha.Show();
      this.formPrimankaWithNoBox.Show();
      this.formPrimankaWithBox.Show();
      this.formMouse.Left = gtaItem.mouseStartX + lpRect.Left;
      this.formMouse.Top = gtaItem.mouseStartY + lpRect.Top;
      this.formMsgOk.Left = gtaItem.msgOkStartX + lpRect.Left;
      this.formMsgOk.Top = gtaItem.msgOkStartY + lpRect.Top;
      this.formFishIcon.Left = gtaItem.iconStartX + lpRect.Left;
      this.formFishIcon.Top = gtaItem.iconStartY + lpRect.Top;
      this.formFullBox.Left = gtaItem.fullBoxLeft + lpRect.Left;
      this.formFullBox.Top = gtaItem.fullBoxTop + lpRect.Top;
      this.formFishrod.Left = gtaItem.fishrodLeft + lpRect.Left;
      this.formFishrod.Top = gtaItem.fishrodTop + lpRect.Top;
      this.formFishrodWithBox.Left = gtaItem.fishrodWithBoxLeft + lpRect.Left;
      this.formFishrodWithBox.Top = gtaItem.fishrodWithBoxTop + lpRect.Top;
      this.formFishLure.Left = gtaItem.fishLureLeft + lpRect.Left;
      this.formFishLure.Top = gtaItem.fishLureTop + lpRect.Top;
      this.formFishLureWithBox.Left = gtaItem.fishLureWithBoxLeft + lpRect.Left;
      this.formFishLureWithBox.Top = gtaItem.fishLureWithBoxTop + lpRect.Top;
      this.formGetRectNoBox.Left = gtaItem.getRectNoBoxStartX + lpRect.Left;
      this.formGetRectNoBox.Top = gtaItem.getRectNoBoxStartY + lpRect.Top;
      this.formCapcha.Left = gtaItem.capchaStartX + lpRect.Left;
      this.formCapcha.Top = gtaItem.capchaStartY + lpRect.Top;
      this.formPrimankaWithNoBox.Left = gtaItem.primankaWithNoBoxStartX + lpRect.Left;
      this.formPrimankaWithNoBox.Top = gtaItem.primankaWithNoBoxStartY + lpRect.Top;
      this.formPrimankaWithBox.Left = gtaItem.primankaWithBoxStartX + lpRect.Left;
      this.formPrimankaWithBox.Top = gtaItem.primankaWithBoxStartY + lpRect.Top;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      GtaStruct selectedItem = (GtaStruct) this.comboDiagVideoSize.SelectedItem;
      this.GetLocationForms(ref selectedItem);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      FormDiag2.RECT lpRect;
      FormDiag2.GetWindowRect(this.myProcess.MainWindowHandle, out lpRect);
      GtaStruct selectedItem = (GtaStruct) this.comboDiagVideoSize.SelectedItem;
      selectedItem.mouseStartX = this.formMouse.Left - lpRect.Left;
      selectedItem.mouseStartY = this.formMouse.Top - lpRect.Top;
      selectedItem.mouseEndX = selectedItem.mouseStartX + this.formMouse.Width;
      selectedItem.mouseEndY = selectedItem.mouseStartY + this.formMouse.Height;
      selectedItem.msgOkStartX = this.formMsgOk.Left - lpRect.Left;
      selectedItem.msgOkStartY = this.formMsgOk.Top - lpRect.Top;
      selectedItem.msgOkEndX = selectedItem.msgOkStartX + this.formMsgOk.Width;
      selectedItem.msgOkEndY = selectedItem.msgOkStartY + this.formMsgOk.Height;
      selectedItem.fullBoxLeft = this.formFullBox.Left - lpRect.Left;
      selectedItem.fullBoxTop = this.formFullBox.Top - lpRect.Top;
      selectedItem.fullBoxStartX = selectedItem.fullBoxLeft + this.formFullBox.Width - 14;
      selectedItem.fullBoxStartY = selectedItem.fullBoxTop;
      selectedItem.fullBoxEndX = selectedItem.fullBoxLeft + this.formFullBox.Width;
      selectedItem.fullBoxEndY = selectedItem.fullBoxTop + this.formFullBox.Height;
      selectedItem.fishrodLeft = this.formFishrod.Left - lpRect.Left;
      selectedItem.fishrodTop = this.formFishrod.Top - lpRect.Top;
      selectedItem.fishrodX = selectedItem.fishrodLeft + this.formFishrod.Width / 2;
      selectedItem.fishrodY = selectedItem.fishrodTop + this.formFishrod.Height / 2;
      selectedItem.fishLureLeft = this.formFishLure.Left - lpRect.Left;
      selectedItem.fishLureTop = this.formFishLure.Top - lpRect.Top;
      selectedItem.fishLureX = selectedItem.fishLureLeft + this.formFishLure.Width / 2;
      selectedItem.fishLureY = selectedItem.fishLureTop + this.formFishLure.Height / 2;
      selectedItem.capchaStartX = this.formCapcha.Left - lpRect.Left;
      selectedItem.capchaStartY = this.formCapcha.Top - lpRect.Top;
      selectedItem.capchaEndX = selectedItem.capchaStartX + this.formCapcha.Width;
      selectedItem.capchaEndY = selectedItem.capchaStartY + this.formCapcha.Height;
      selectedItem.iconStartX = this.formFishIcon.Left - lpRect.Left;
      selectedItem.iconStartY = this.formFishIcon.Top - lpRect.Top;
      selectedItem.iconEndX += this.formFishIcon.Width;
      selectedItem.iconEndY = selectedItem.iconStartY + this.formFishIcon.Height;
      selectedItem.getRectNoBoxStartX = this.formGetRectNoBox.Left - lpRect.Left;
      selectedItem.getRectNoBoxStartY = this.formGetRectNoBox.Top - lpRect.Top;
      selectedItem.getRectNoBoxEndX = this.formGetRectNoBox.Left + this.formGetRectNoBox.Width - lpRect.Left;
      selectedItem.getRectNoBoxEndY = this.formGetRectNoBox.Top + this.formGetRectNoBox.Height - lpRect.Top;
      selectedItem.fishrodWithBoxLeft = this.formFishrodWithBox.Left - lpRect.Left;
      selectedItem.fishrodWithBoxTop = this.formFishrodWithBox.Top - lpRect.Top;
      selectedItem.fishrodWithBoxX = selectedItem.fishrodWithBoxLeft + this.formFishrodWithBox.Width / 2;
      selectedItem.fishrodWithBoxY = selectedItem.fishrodWithBoxTop + this.formFishrodWithBox.Height / 2;
      selectedItem.fishLureWithBoxLeft = this.formFishLureWithBox.Left - lpRect.Left;
      selectedItem.fishLureWithBoxTop = this.formFishLureWithBox.Top - lpRect.Top;
      selectedItem.fishLureWithBoxX = selectedItem.fishLureWithBoxLeft + this.formFishLureWithBox.Width / 2;
      selectedItem.fishLureWithBoxY = selectedItem.fishLureWithBoxTop + this.formFishLureWithBox.Height / 2;
      selectedItem.primankaWithNoBoxLeft = this.formPrimankaWithNoBox.Left - lpRect.Left;
      selectedItem.primankaWithNoBoxTop = this.formPrimankaWithNoBox.Top - lpRect.Top;
      selectedItem.primankaWithNoBoxStartX = selectedItem.primankaWithNoBoxLeft;
      selectedItem.primankaWithNoBoxEndX = selectedItem.primankaWithNoBoxLeft + this.formPrimankaWithNoBox.Width;
      selectedItem.primankaWithNoBoxStartY = selectedItem.primankaWithNoBoxTop;
      selectedItem.primankaWithNoBoxEndY = selectedItem.primankaWithNoBoxTop + this.formPrimankaWithNoBox.Height;
      selectedItem.primankaWithBoxLeft = this.formPrimankaWithBox.Left - lpRect.Left;
      selectedItem.primankaWithBoxTop = this.formPrimankaWithBox.Top - lpRect.Top;
      selectedItem.primankaWithBoxStartX = selectedItem.primankaWithBoxLeft;
      selectedItem.primankaWithBoxEndX = selectedItem.primankaWithBoxLeft + this.formPrimankaWithBox.Width;
      selectedItem.primankaWithBoxStartY = selectedItem.primankaWithBoxTop;
      selectedItem.primankaWithBoxEndY = selectedItem.primankaWithBoxTop + this.formPrimankaWithBox.Height;
      File.WriteAllText("config3.json", JsonConvert.SerializeObject((object) this.gta, Formatting.Indented));
    }

    private void button3_Click(object sender, EventArgs e)
    {
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
    }

    private void FormDiag2_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void FormDiag2_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.formMouse.Close();
      this.formMsgOk.Close();
      this.formFishIcon.Close();
      this.formFullBox.Close();
      this.formFishrod.Close();
      this.formFishrodWithBox.Close();
      this.formFishLure.Close();
      this.formFishLureWithBox.Close();
      this.formGetRectNoBox.Close();
      this.formCapcha.Close();
      this.formPrimankaWithNoBox.Close();
      this.formPrimankaWithBox.Close();
      e.Cancel = true;
      this.Hide();
    }

    private void FormDiag2_MouseMove(object sender, MouseEventArgs e)
    {
    }

    private void buttonClose_Click(object sender, EventArgs e) => this.Close();

    private void FormDiag2_MouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.panel1.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.comboDiagVideoSize = new ComboBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.buttonClose = new Button();
      this.panel1 = new Panel();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.comboDiagVideoSize.BackColor = Color.FromArgb(64, 64, 64);
      this.comboDiagVideoSize.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboDiagVideoSize.FlatStyle = FlatStyle.Flat;
      this.comboDiagVideoSize.ForeColor = Color.Silver;
      this.comboDiagVideoSize.FormattingEnabled = true;
      this.comboDiagVideoSize.Location = new Point(17, 13);
      this.comboDiagVideoSize.Name = "comboDiagVideoSize";
      this.comboDiagVideoSize.Size = new Size(281, 21);
      this.comboDiagVideoSize.TabIndex = 28;
      this.button1.BackColor = Color.FromArgb(64, 64, 64);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = Color.Silver;
      this.button1.Location = new Point(17, 40);
      this.button1.Name = "button1";
      this.button1.Size = new Size(172, 37);
      this.button1.TabIndex = 30;
      this.button1.Text = "Настроить расположение";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.BackColor = Color.FromArgb(64, 64, 64);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.ForeColor = Color.Silver;
      this.button2.Location = new Point(17, 83);
      this.button2.Name = "button2";
      this.button2.Size = new Size(172, 37);
      this.button2.TabIndex = 31;
      this.button2.Text = "Сохранить расположение";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.buttonClose.BackColor = Color.FromArgb(64, 64, 64);
      this.buttonClose.FlatStyle = FlatStyle.Flat;
      this.buttonClose.ForeColor = Color.Silver;
      this.buttonClose.Location = new Point(195, 40);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new Size(103, 80);
      this.buttonClose.TabIndex = 32;
      this.buttonClose.Text = "Закрыть";
      this.buttonClose.UseVisualStyleBackColor = false;
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.button2);
      this.panel1.Controls.Add((Control) this.buttonClose);
      this.panel1.Controls.Add((Control) this.comboDiagVideoSize);
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(315, 137);
      this.panel1.TabIndex = 33;
      this.panel1.MouseDown += new MouseEventHandler(this.FormDiag2_MouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(64, 64, 64);
      this.ClientSize = new Size(315, 137);
      this.ControlBox = false;
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormDiag2);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Настройка конфигурации";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.FormDiag2_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.FormDiag2_FormClosed);
      this.Load += new EventHandler(this.FormDiag2_Load);
      this.MouseDown += new MouseEventHandler(this.FormDiag2_MouseDown);
      this.MouseMove += new MouseEventHandler(this.FormDiag2_MouseMove);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public struct RECT
    {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;
    }
  }
}
