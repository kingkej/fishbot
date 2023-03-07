// Decompiled with JetBrains decompiler
// Type: gta_rp.FormCapcha
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gta_rp
{
  public class FormCapcha : Form
  {
    private IContainer components;
    private Label label1;

    public FormCapcha() => this.InitializeComponent();

    private void FormClick_CapchaMouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.label1.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    private void FormCapcha_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.SuspendLayout();
      this.label1.Dock = DockStyle.Fill;
      this.label1.Location = new Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(69, 30);
      this.label1.TabIndex = 0;
      this.label1.Text = "я робот";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.label1.MouseDown += new MouseEventHandler(this.FormClick_CapchaMouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb((int) byte.MaxValue, 128, 128);
      this.ClientSize = new Size(69, 30);
      this.ControlBox = false;
      this.Controls.Add((Control) this.label1);
      this.ForeColor = SystemColors.ControlText;
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(1, 1);
      this.Name = nameof (FormCapcha);
      this.Opacity = 0.7;
      this.Tag = (object) "capcha";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.FormCapcha_FormClosing);
      this.MouseDown += new MouseEventHandler(this.FormClick_CapchaMouseDown);
      this.ResumeLayout(false);
    }
  }
}
