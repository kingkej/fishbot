// Decompiled with JetBrains decompiler
// Type: gta_rp.FormFishPrice
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gta_rp
{
  public class FormFishPrice : Form
  {
    private string server;
    private IContainer components;
    private Panel panel1;
    private Label label2;
    public NumericUpDown numericUpDown2;
    private Label label1;
    public NumericUpDown numericUpDown1;
    private Label labelServer;
    private Label labelMain;
    private Button buttonCancel;
    private Button buttonOk;

    private FormFishMain formFishMain { get; set; }

    public FormFishPrice()
    {
      this.InitializeComponent();
      this.buttonCancel.BackColor = Color.FromArgb(80, (int) byte.MaxValue, 192, 192);
      this.buttonOk.BackColor = Color.FromArgb(80, 192, (int) byte.MaxValue, 192);
    }

    public void Execute(string server, FormFishMain formFishMain)
    {
      this.server = server;
      this.formFishMain = formFishMain;
      this.labelServer.Text = server;
      int num = (int) this.ShowDialog();
    }

    private void formPriceBuyer_MouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.panel1.Capture = false;
      this.labelServer.Capture = false;
      this.labelMain.Capture = false;
      this.label1.Capture = false;
      this.label2.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    private void buttonCancel_Click(object sender, EventArgs e) => this.Close();

    private void buttonOk_Click(object sender, EventArgs e)
    {
      FishPrice fishPrice = new FishPrice();
      if (this.numericUpDown1.Value > 120M || this.numericUpDown1.Value < 80M && this.numericUpDown1.Value != 0M)
      {
        this.numericUpDown1.Value = 0M;
        int num = (int) MessageBox.Show("Не верно задана цена скупщика 1");
      }
      else if (this.numericUpDown2.Value > 120M || this.numericUpDown2.Value < 80M && this.numericUpDown2.Value != 0M)
      {
        this.numericUpDown2.Value = 0M;
        int num = (int) MessageBox.Show("Не верно задана цена скупщика 2");
      }
      else
      {
        fishPrice.server = this.server;
        fishPrice.isSendVal1 = this.numericUpDown1.Value != 0M;
        fishPrice.isSendVal2 = this.numericUpDown2.Value != 0M;
        fishPrice.val1 = (int) this.numericUpDown1.Value;
        fishPrice.val2 = (int) this.numericUpDown2.Value;
        if (!(Engine.POST(JsonConvert.SerializeObject((object) fishPrice, Formatting.Indented), "http://radiopribori.ru/gta5rp/fish_price_script.php") == "OK"))
          return;
        this.Close();
        this.formFishMain.Start = true;
      }
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
      this.label2 = new Label();
      this.numericUpDown2 = new NumericUpDown();
      this.label1 = new Label();
      this.numericUpDown1 = new NumericUpDown();
      this.labelServer = new Label();
      this.labelMain = new Label();
      this.buttonCancel = new Button();
      this.buttonOk = new Button();
      this.panel1.SuspendLayout();
      this.numericUpDown2.BeginInit();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.numericUpDown2);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.numericUpDown1);
      this.panel1.Controls.Add((Control) this.labelServer);
      this.panel1.Controls.Add((Control) this.labelMain);
      this.panel1.Controls.Add((Control) this.buttonCancel);
      this.panel1.Controls.Add((Control) this.buttonOk);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(301, 146);
      this.panel1.TabIndex = 42;
      this.panel1.MouseDown += new MouseEventHandler(this.formPriceBuyer_MouseDown);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.FromArgb(64, 64, 64);
      this.label2.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label2.ForeColor = Color.MediumSpringGreen;
      this.label2.Location = new Point(155, 37);
      this.label2.Name = "label2";
      this.label2.Size = new Size(99, 18);
      this.label2.TabIndex = 49;
      this.label2.Text = "Скупщик 2, К";
      this.label2.TextAlign = ContentAlignment.MiddleRight;
      this.label2.MouseDown += new MouseEventHandler(this.formPriceBuyer_MouseDown);
      this.numericUpDown2.BackColor = Color.FromArgb(64, 64, 64);
      this.numericUpDown2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.numericUpDown2.ForeColor = Color.MediumSpringGreen;
      this.numericUpDown2.Location = new Point(158, 63);
      this.numericUpDown2.Maximum = new Decimal(new int[4]
      {
        999999,
        0,
        0,
        0
      });
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(131, 26);
      this.numericUpDown2.TabIndex = 48;
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.FromArgb(64, 64, 64);
      this.label1.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label1.ForeColor = Color.MediumSpringGreen;
      this.label1.Location = new Point(9, 37);
      this.label1.Name = "label1";
      this.label1.Size = new Size(102, 18);
      this.label1.TabIndex = 47;
      this.label1.Text = "Скупщик 1, Ф";
      this.label1.TextAlign = ContentAlignment.MiddleRight;
      this.label1.MouseDown += new MouseEventHandler(this.formPriceBuyer_MouseDown);
      this.numericUpDown1.BackColor = Color.FromArgb(64, 64, 64);
      this.numericUpDown1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.numericUpDown1.ForeColor = Color.MediumSpringGreen;
      this.numericUpDown1.Location = new Point(12, 63);
      this.numericUpDown1.Maximum = new Decimal(new int[4]
      {
        999999,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(140, 26);
      this.numericUpDown1.TabIndex = 46;
      this.labelServer.BackColor = Color.FromArgb(64, 64, 64);
      this.labelServer.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.labelServer.ForeColor = Color.FromArgb((int) byte.MaxValue, 128, 128);
      this.labelServer.Location = new Point(122, 10);
      this.labelServer.Name = "labelServer";
      this.labelServer.Size = new Size(168, 18);
      this.labelServer.TabIndex = 45;
      this.labelServer.Text = "DownTown";
      this.labelServer.TextAlign = ContentAlignment.MiddleRight;
      this.labelServer.MouseDown += new MouseEventHandler(this.formPriceBuyer_MouseDown);
      this.labelMain.AutoSize = true;
      this.labelMain.BackColor = Color.FromArgb(64, 64, 64);
      this.labelMain.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.labelMain.ForeColor = Color.MediumSpringGreen;
      this.labelMain.Location = new Point(9, 10);
      this.labelMain.Name = "labelMain";
      this.labelMain.Size = new Size(107, 18);
      this.labelMain.TabIndex = 44;
      this.labelMain.Text = "Цена на осётр";
      this.labelMain.TextAlign = ContentAlignment.MiddleRight;
      this.labelMain.MouseDown += new MouseEventHandler(this.formPriceBuyer_MouseDown);
      this.buttonCancel.BackColor = Color.FromArgb((int) byte.MaxValue, 128, 128);
      this.buttonCancel.FlatStyle = FlatStyle.Flat;
      this.buttonCancel.Location = new Point(12, 104);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(140, 31);
      this.buttonCancel.TabIndex = 43;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = false;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.buttonOk.BackColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.buttonOk.FlatStyle = FlatStyle.Flat;
      this.buttonOk.Location = new Point(159, 104);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new Size(131, 31);
      this.buttonOk.TabIndex = 42;
      this.buttonOk.Text = "Установить";
      this.buttonOk.UseVisualStyleBackColor = false;
      this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoValidate = AutoValidate.EnablePreventFocusChange;
      this.BackColor = Color.FromArgb(64, 64, 64);
      this.BackgroundImageLayout = ImageLayout.None;
      this.ClientSize = new Size(301, 146);
      this.ControlBox = false;
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FormFishPrice);
      this.Opacity = 0.92;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "formFishPrice";
      this.TopMost = true;
      this.MouseDown += new MouseEventHandler(this.formPriceBuyer_MouseDown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.numericUpDown2.EndInit();
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
