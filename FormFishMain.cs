// Decompiled with JetBrains decompiler
// Type: gta_rp.FormFishMain
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using gta_rp.Properties;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace gta_rp
{
  public class FormFishMain : Form
  {
    private FormFishPrice formFishPrice = new FormFishPrice();
    private bool start;
    private IContainer components;
    private Button buttonClose;
    private Panel panel1;
    private Panel panel2;
    private Label labelFish;
    private Label label3;
    public Label pricetime2;
    public Label pricetime1;
    public Label price2;
    public Label price1;
    public Label labelFishPriceTitle2;
    public Label labelFishPriceTitle1;
    public Button updatePrice1;
    public ComboBox cbServer;
    public Timer timerFishPrice;

    public bool Start
    {
      get => this.start;
      set
      {
        if (value)
          this.timerFishPrice_Tick((object) null, (EventArgs) null);
        this.timerFishPrice.Enabled = value;
        this.start = value;
      }
    }

    public FormFishMain() => this.InitializeComponent();

    private void FormFishMain_MouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.panel1.Capture = false;
      this.panel2.Capture = false;
      this.label3.Capture = false;
      this.labelFish.Capture = false;
      this.labelFishPriceTitle1.Capture = false;
      this.labelFishPriceTitle2.Capture = false;
      this.price1.Capture = false;
      this.price2.Capture = false;
      this.pricetime1.Capture = false;
      this.pricetime2.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    private void buttonClose_Click(object sender, EventArgs e) => this.Close();

    private void FormFishMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }

    private void updatePrice1_Click(object sender, EventArgs e) => this.formFishPrice.Execute(this.cbServer.Text, this);

    private void timerFishPrice_Tick(object sender, EventArgs e)
    {
      try
      {
        if (this.cbServer.SelectedIndex == -1)
          return;
        FishPrice fishPrice1 = new FishPrice();
        FishPrice fishPrice2 = JsonConvert.DeserializeObject<FishPrice>(Engine.GET(string.Format("http://radiopribori.ru/gta5rp/fish_price_script.php?getserver={0}", (object) this.cbServer.Text)));
        Label price1 = this.price1;
        int num = fishPrice2.val1;
        string str1 = num.ToString() + "$";
        price1.Text = str1;
        Label price2 = this.price2;
        num = fishPrice2.val2;
        string str2 = num.ToString() + "$";
        price2.Text = str2;
        DateTime? nullable1;
        try
        {
          nullable1 = new DateTime?(new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double) fishPrice2.val1Time));
        }
        catch (Exception ex)
        {
          nullable1 = new DateTime?();
        }
        this.pricetime1.Text = nullable1.HasValue ? nullable1.Value.ToString("d.dd HH:mm") : "нет";
        DateTime? nullable2;
        try
        {
          nullable2 = new DateTime?(new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double) fishPrice2.val2Time));
        }
        catch (Exception ex)
        {
          nullable2 = new DateTime?(new DateTime(1970, 1, 1, 0, 0, 0, 0));
        }
        this.pricetime2.Text = nullable2.HasValue ? nullable2.Value.ToString("d.dd HH:mm") : "нет";
      }
      catch (Exception ex)
      {
      }
    }

    private void cbServer_SelectedIndexChanged(object sender, EventArgs e) => this.Start = this.Start;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.buttonClose = new Button();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.updatePrice1 = new Button();
      this.pricetime2 = new Label();
      this.pricetime1 = new Label();
      this.price2 = new Label();
      this.price1 = new Label();
      this.labelFish = new Label();
      this.labelFishPriceTitle2 = new Label();
      this.labelFishPriceTitle1 = new Label();
      this.cbServer = new ComboBox();
      this.label3 = new Label();
      this.timerFishPrice = new Timer(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.buttonClose.BackColor = Color.FromArgb(74, 74, 74);
      this.buttonClose.FlatAppearance.BorderSize = 0;
      this.buttonClose.FlatStyle = FlatStyle.Flat;
      this.buttonClose.ForeColor = Color.Silver;
      this.buttonClose.Location = new Point(195, 123);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new Size(79, 25);
      this.buttonClose.TabIndex = 27;
      this.buttonClose.Text = "Закрыть";
      this.buttonClose.UseVisualStyleBackColor = false;
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.buttonClose);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(284, 159);
      this.panel1.TabIndex = 28;
      this.panel1.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.panel2.Controls.Add((Control) this.updatePrice1);
      this.panel2.Controls.Add((Control) this.pricetime2);
      this.panel2.Controls.Add((Control) this.pricetime1);
      this.panel2.Controls.Add((Control) this.price2);
      this.panel2.Controls.Add((Control) this.price1);
      this.panel2.Controls.Add((Control) this.labelFish);
      this.panel2.Controls.Add((Control) this.labelFishPriceTitle2);
      this.panel2.Controls.Add((Control) this.labelFishPriceTitle1);
      this.panel2.Controls.Add((Control) this.cbServer);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Location = new Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(271, 114);
      this.panel2.TabIndex = 47;
      this.panel2.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.updatePrice1.BackColor = Color.FromArgb(74, 74, 74);
      this.updatePrice1.BackgroundImageLayout = ImageLayout.Center;
      this.updatePrice1.FlatAppearance.BorderSize = 0;
      this.updatePrice1.FlatStyle = FlatStyle.Flat;
      this.updatePrice1.Image = (Image) Resources.ref45;
      this.updatePrice1.Location = new Point(10, 52);
      this.updatePrice1.Name = "updatePrice1";
      this.updatePrice1.Size = new Size(58, 55);
      this.updatePrice1.TabIndex = 54;
      this.updatePrice1.UseVisualStyleBackColor = false;
      this.updatePrice1.Click += new EventHandler(this.updatePrice1_Click);
      this.pricetime2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.pricetime2.ForeColor = Color.Yellow;
      this.pricetime2.Location = new Point(167, 92);
      this.pricetime2.Name = "pricetime2";
      this.pricetime2.Size = new Size(80, 15);
      this.pricetime2.TabIndex = 53;
      this.pricetime2.TextAlign = ContentAlignment.TopCenter;
      this.pricetime2.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.pricetime1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.pricetime1.ForeColor = Color.Yellow;
      this.pricetime1.Location = new Point(74, 92);
      this.pricetime1.Name = "pricetime1";
      this.pricetime1.Size = new Size(80, 15);
      this.pricetime1.TabIndex = 52;
      this.pricetime1.TextAlign = ContentAlignment.TopCenter;
      this.pricetime1.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.price2.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.price2.ForeColor = Color.Yellow;
      this.price2.Location = new Point(167, 72);
      this.price2.Name = "price2";
      this.price2.Size = new Size(80, 20);
      this.price2.TabIndex = 51;
      this.price2.TextAlign = ContentAlignment.MiddleCenter;
      this.price2.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.price1.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.price1.ForeColor = Color.Yellow;
      this.price1.Location = new Point(74, 72);
      this.price1.Name = "price1";
      this.price1.Size = new Size(80, 20);
      this.price1.TabIndex = 50;
      this.price1.TextAlign = ContentAlignment.MiddleCenter;
      this.price1.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.labelFish.AutoSize = true;
      this.labelFish.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Italic, GraphicsUnit.Point, (byte) 204);
      this.labelFish.ForeColor = Color.MediumSeaGreen;
      this.labelFish.Location = new Point(7, 31);
      this.labelFish.Name = "labelFish";
      this.labelFish.Size = new Size(111, 18);
      this.labelFish.TabIndex = 45;
      this.labelFish.Text = "Цена на осетр:";
      this.labelFish.TextAlign = ContentAlignment.MiddleRight;
      this.labelFish.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.labelFishPriceTitle2.AutoSize = true;
      this.labelFishPriceTitle2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.labelFishPriceTitle2.ForeColor = Color.LightGreen;
      this.labelFishPriceTitle2.Location = new Point(164, 52);
      this.labelFishPriceTitle2.Name = "labelFishPriceTitle2";
      this.labelFishPriceTitle2.Size = new Size(79, 15);
      this.labelFishPriceTitle2.TabIndex = 49;
      this.labelFishPriceTitle2.Text = "Скупщик 2, К";
      this.labelFishPriceTitle2.TextAlign = ContentAlignment.MiddleRight;
      this.labelFishPriceTitle2.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.labelFishPriceTitle1.AutoSize = true;
      this.labelFishPriceTitle1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.labelFishPriceTitle1.ForeColor = Color.LightGreen;
      this.labelFishPriceTitle1.Location = new Point(74, 52);
      this.labelFishPriceTitle1.Name = "labelFishPriceTitle1";
      this.labelFishPriceTitle1.Size = new Size(82, 15);
      this.labelFishPriceTitle1.TabIndex = 46;
      this.labelFishPriceTitle1.Text = "Скупщик 1, Ф";
      this.labelFishPriceTitle1.TextAlign = ContentAlignment.MiddleRight;
      this.labelFishPriceTitle1.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.cbServer.BackColor = Color.FromArgb(74, 74, 74);
      this.cbServer.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbServer.FlatStyle = FlatStyle.Flat;
      this.cbServer.ForeColor = Color.Silver;
      this.cbServer.FormattingEnabled = true;
      this.cbServer.Items.AddRange(new object[9]
      {
        (object) "BlackBerry",
        (object) "DownTown",
        (object) "Eclipse",
        (object) "Insquad",
        (object) "RainBow",
        (object) "Richman",
        (object) "StrawBerry",
        (object) "Sunrise",
        (object) "VineWood"
      });
      this.cbServer.Location = new Point(77, 6);
      this.cbServer.Name = "cbServer";
      this.cbServer.Size = new Size(186, 21);
      this.cbServer.Sorted = true;
      this.cbServer.TabIndex = 48;
      this.cbServer.SelectedIndexChanged += new EventHandler(this.cbServer_SelectedIndexChanged);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label3.ForeColor = Color.DeepSkyBlue;
      this.label3.Location = new Point(6, 7);
      this.label3.Name = "label3";
      this.label3.Size = new Size(65, 20);
      this.label3.TabIndex = 47;
      this.label3.Text = "Сервер";
      this.label3.TextAlign = ContentAlignment.MiddleRight;
      this.label3.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.timerFishPrice.Interval = 15000;
      this.timerFishPrice.Tick += new EventHandler(this.timerFishPrice_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(64, 64, 64);
      this.ClientSize = new Size(284, 159);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (FormFishMain);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Диагностика";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.FormFishMain_FormClosing);
      this.MouseDown += new MouseEventHandler(this.FormFishMain_MouseDown);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
