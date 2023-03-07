// Decompiled with JetBrains decompiler
// Type: gta_rp.ActivateForm
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gta_rp
{
  public class ActivateForm : Form
  {
    private IContainer components;
    private Panel panel1;
    private TextBox codeText;
    private Button buttonCancel;
    private Button buttonActivate;
    private Label label1;

    public MainForm mainForm { get; set; }

    public ActivateForm() => this.InitializeComponent();

    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

    private void activateForm_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void ActivateForm_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void ActivateForm_VisibleChanged(object sender, EventArgs e)
    {
    }

    private void buttonActivate_Click(object sender, EventArgs e)
    {
      if (this.codeText.Text == string.Empty)
      {
        int num = (int) MessageBox.Show("Не введен ключ!");
        this.codeText.Focus();
      }
      else
      {
        this.mainForm.IsActivate(this.codeText.Text);
        this.Close();
      }
    }

    private void ActivateForm_Load(object sender, EventArgs e)
    {
    }

    private void ActivateForm_MouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.label1.Capture = false;
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
      this.panel1 = new Panel();
      this.codeText = new TextBox();
      this.buttonCancel = new Button();
      this.buttonActivate = new Button();
      this.label1 = new Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.codeText);
      this.panel1.Controls.Add((Control) this.buttonCancel);
      this.panel1.Controls.Add((Control) this.buttonActivate);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(807, 123);
      this.panel1.TabIndex = 21;
      this.panel1.MouseDown += new MouseEventHandler(this.ActivateForm_MouseDown);
      this.codeText.BackColor = Color.FromArgb(74, 74, 74);
      this.codeText.BorderStyle = BorderStyle.None;
      this.codeText.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.codeText.ForeColor = Color.Silver;
      this.codeText.Location = new Point(12, 28);
      this.codeText.Multiline = true;
      this.codeText.Name = "codeText";
      this.codeText.Size = new Size(581, 83);
      this.codeText.TabIndex = 24;
      this.buttonCancel.BackColor = Color.FromArgb(74, 74, 74);
      this.buttonCancel.FlatAppearance.BorderSize = 0;
      this.buttonCancel.FlatStyle = FlatStyle.Flat;
      this.buttonCancel.ForeColor = Color.Silver;
      this.buttonCancel.Location = new Point(699, 28);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(96, 83);
      this.buttonCancel.TabIndex = 23;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = false;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.buttonActivate.BackColor = Color.FromArgb(74, 74, 74);
      this.buttonActivate.FlatAppearance.BorderSize = 0;
      this.buttonActivate.FlatStyle = FlatStyle.Flat;
      this.buttonActivate.ForeColor = Color.Silver;
      this.buttonActivate.Location = new Point(599, 28);
      this.buttonActivate.Name = "buttonActivate";
      this.buttonActivate.Size = new Size(94, 83);
      this.buttonActivate.TabIndex = 22;
      this.buttonActivate.Text = "Активировать";
      this.buttonActivate.UseVisualStyleBackColor = false;
      this.buttonActivate.Click += new EventHandler(this.buttonActivate_Click);
      this.label1.AutoSize = true;
      this.label1.ForeColor = Color.Silver;
      this.label1.Location = new Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(126, 13);
      this.label1.TabIndex = 21;
      this.label1.Text = "Введите код активации";
      this.label1.MouseDown += new MouseEventHandler(this.ActivateForm_MouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(64, 64, 64);
      this.ClientSize = new Size(807, 123);
      this.ControlBox = false;
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ActivateForm);
      this.Opacity = 0.92;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Введите код активации";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.ActivateForm_FormClosing);
      this.Load += new EventHandler(this.ActivateForm_Load);
      this.VisibleChanged += new EventHandler(this.ActivateForm_VisibleChanged);
      this.MouseDown += new MouseEventHandler(this.ActivateForm_MouseDown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
