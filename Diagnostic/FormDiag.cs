// Decompiled with JetBrains decompiler
// Type: gta_rp.FormDiag
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gta_rp
{
  public class FormDiag : Form
  {
    private FormDiag2 formDiag2 = new FormDiag2();
    private ThreadDiag threadDiag;
    private IContainer components;
    private Label activatelabel;
    private Button stopButton;
    private Button start;
    private Button button1;
    private Button buttonClose;
    private Panel panel1;
    private Label sizelabel;
    public Label holstlabel;
    private PictureBox pictureBox1;

    public FormDiag() => this.InitializeComponent();

    private void startButton_Click(object sender, EventArgs e)
    {
      if (this.threadDiag != null)
        this.stopButton.PerformClick();
      this.threadDiag = new ThreadDiag(Engine.MyProcess.MainWindowHandle);
      this.threadDiag.picture = this.pictureBox1;
      this.threadDiag.holstlabel = this.holstlabel;
      this.threadDiag.Start();
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
      if (this.threadDiag == null)
        return;
      this.stop();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int num = (int) this.formDiag2.ShowDialog();
    }

    private void FormDiag_MouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.panel1.Capture = false;
      this.activatelabel.Capture = false;
      this.sizelabel.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    private void buttonClose_Click(object sender, EventArgs e) => this.Close();

    private void FormDiag_Load(object sender, EventArgs e)
    {
      if (Engine.MyProcess == null)
      {
        this.sizelabel.Text = "Окно не найдено";
      }
      else
      {
        int out_width = 0;
        int out_heigth = 0;
        Engine.GetWindowSize(Engine.MyProcess.MainWindowHandle, ref out_width, ref out_heigth);
        this.sizelabel.Text = string.Format("Размер окна (разрешение) {0}x{1}", (object) out_width, (object) out_heigth);
      }
    }

    private void FormDiag_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
      if (this.threadDiag == null)
        return;
      this.stop();
    }

    private void stop()
    {
      this.threadDiag.thread.Abort();
      Graphics.FromImage(this.pictureBox1.Image).Clear(Color.Black);
      this.holstlabel.Text = "";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.activatelabel = new Label();
      this.stopButton = new Button();
      this.start = new Button();
      this.button1 = new Button();
      this.buttonClose = new Button();
      this.panel1 = new Panel();
      this.sizelabel = new Label();
      this.holstlabel = new Label();
      this.pictureBox1 = new PictureBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.activatelabel.FlatStyle = FlatStyle.Flat;
      this.activatelabel.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.activatelabel.ForeColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.activatelabel.Location = new Point(12, 11);
      this.activatelabel.Name = "activatelabel";
      this.activatelabel.Size = new Size(506, 37);
      this.activatelabel.TabIndex = 22;
      this.activatelabel.Text = "Режим диагностики нужен для проверки видит ли бот окно с игрой\r\nпри нажатии Старт, в игре должен открываться инвертарь, а затем закрываться.";
      this.activatelabel.MouseDown += new MouseEventHandler(this.FormDiag_MouseDown);
      this.stopButton.BackColor = Color.FromArgb(74, 74, 74);
      this.stopButton.FlatAppearance.BorderSize = 0;
      this.stopButton.FlatStyle = FlatStyle.Flat;
      this.stopButton.ForeColor = Color.Silver;
      this.stopButton.Location = new Point(140, 81);
      this.stopButton.Name = "stopButton";
      this.stopButton.Size = new Size(122, 61);
      this.stopButton.TabIndex = 25;
      this.stopButton.Text = "Стоп";
      this.stopButton.UseVisualStyleBackColor = false;
      this.stopButton.Click += new EventHandler(this.stopButton_Click);
      this.start.BackColor = Color.FromArgb(74, 74, 74);
      this.start.FlatAppearance.BorderSize = 0;
      this.start.FlatStyle = FlatStyle.Flat;
      this.start.ForeColor = Color.Silver;
      this.start.Location = new Point(12, 81);
      this.start.Name = "start";
      this.start.Size = new Size(122, 61);
      this.start.TabIndex = 24;
      this.start.Text = "Старт";
      this.start.UseVisualStyleBackColor = false;
      this.start.Click += new EventHandler(this.startButton_Click);
      this.button1.BackColor = Color.FromArgb(74, 74, 74);
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = Color.Silver;
      this.button1.Location = new Point(268, 81);
      this.button1.Name = "button1";
      this.button1.Size = new Size(122, 61);
      this.button1.TabIndex = 26;
      this.button1.Text = "Настройка конфигурации";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.buttonClose.BackColor = Color.FromArgb(74, 74, 74);
      this.buttonClose.FlatAppearance.BorderSize = 0;
      this.buttonClose.FlatStyle = FlatStyle.Flat;
      this.buttonClose.ForeColor = Color.Silver;
      this.buttonClose.Location = new Point(396, 81);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new Size(122, 61);
      this.buttonClose.TabIndex = 27;
      this.buttonClose.Text = "Закрыть";
      this.buttonClose.UseVisualStyleBackColor = false;
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.holstlabel);
      this.panel1.Controls.Add((Control) this.sizelabel);
      this.panel1.Controls.Add((Control) this.activatelabel);
      this.panel1.Controls.Add((Control) this.buttonClose);
      this.panel1.Controls.Add((Control) this.start);
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Controls.Add((Control) this.stopButton);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(532, 448);
      this.panel1.TabIndex = 28;
      this.panel1.MouseMove += new MouseEventHandler(this.FormDiag_MouseDown);
      this.sizelabel.FlatStyle = FlatStyle.Flat;
      this.sizelabel.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.sizelabel.ForeColor = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.sizelabel.Location = new Point(12, 48);
      this.sizelabel.Name = "sizelabel";
      this.sizelabel.Size = new Size(506, 19);
      this.sizelabel.TabIndex = 28;
      this.sizelabel.Text = "Размер экрана ГТА";
      this.sizelabel.MouseDown += new MouseEventHandler(this.FormDiag_MouseDown);
      this.holstlabel.FlatStyle = FlatStyle.Flat;
      this.holstlabel.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.holstlabel.ForeColor = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.holstlabel.Location = new Point(12, 154);
      this.holstlabel.Name = "holstlabel";
      this.holstlabel.Size = new Size(506, 19);
      this.holstlabel.TabIndex = 29;
      this.holstlabel.Text = "Размер холста";
      this.pictureBox1.Location = new Point(15, 176);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(503, 259);
      this.pictureBox1.TabIndex = 30;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(64, 64, 64);
      this.ClientSize = new Size(532, 448);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormDiag);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Диагностика";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.FormDiag_FormClosing);
      this.Load += new EventHandler(this.FormDiag_Load);
      this.MouseDown += new MouseEventHandler(this.FormDiag_MouseDown);
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
