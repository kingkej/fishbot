// Decompiled with JetBrains decompiler
// Type: gta_rp.FormFishLure
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gta_rp
{
  public class FormFishLure : Form
  {
    private IContainer components;
    private Label label1;

    public FormFishLure() => this.InitializeComponent();

    private void FormClick_FishLureMouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.label1.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    private void FormFishLure_FormClosing(object sender, FormClosingEventArgs e)
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
      this.label1.BackColor = Color.Aqua;
      this.label1.Dock = DockStyle.Fill;
      this.label1.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label1.Location = new Point(0, 0);
      this.label1.Margin = new Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(94, 28);
      this.label1.TabIndex = 0;
      this.label1.Text = "лов. на прим\r\nбез сумки";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.label1.MouseDown += new MouseEventHandler(this.FormClick_FishLureMouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.ClientSize = new Size(94, 28);
      this.ControlBox = false;
      this.Controls.Add((Control) this.label1);
      this.ForeColor = SystemColors.ControlText;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(2, 3, 2, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(1, 1);
      this.Name = nameof (FormFishLure);
      this.Opacity = 0.7;
      this.Tag = (object) "fishLure";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.FormFishLure_FormClosing);
      this.MouseDown += new MouseEventHandler(this.FormClick_FishLureMouseDown);
      this.ResumeLayout(false);
    }
  }
}
