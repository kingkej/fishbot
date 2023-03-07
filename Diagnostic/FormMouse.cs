// Decompiled with JetBrains decompiler
// Type: gta_rp.FormMouse
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gta_rp
{
  public class FormMouse : Form
  {
    private IContainer components;
    private Label label1;

    public FormMouse() => this.InitializeComponent();

    private void FormClick_MouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.label1.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    private void FormMouse_FormClosing(object sender, FormClosingEventArgs e)
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
      this.label1.Size = new Size(29, 39);
      this.label1.TabIndex = 0;
      this.label1.Text = "Мышь";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.label1.MouseDown += new MouseEventHandler(this.FormClick_MouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb((int) byte.MaxValue, 128, 128);
      this.ClientSize = new Size(29, 39);
      this.ControlBox = false;
      this.Controls.Add((Control) this.label1);
      this.ForeColor = SystemColors.ControlText;
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(1, 1);
      this.Name = nameof (FormMouse);
      this.Opacity = 0.7;
      this.Tag = (object) "mouse";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.FormMouse_FormClosing);
      this.MouseDown += new MouseEventHandler(this.FormClick_MouseDown);
      this.ResumeLayout(false);
    }
  }
}
