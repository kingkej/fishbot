// Decompiled with JetBrains decompiler
// Type: gta_rp.MainForm
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using AutoUpdaterDotNET;
using gta_rp.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace gta_rp
{
  public class MainForm : Form
  {
    private Process procGta = new Process();
    private ActivateForm activateForm = new ActivateForm();
    private FormFishMain formFishMain = new FormFishMain();
    private FormDiag formDiag = new FormDiag();
    private List<GtaStruct> gta = new List<GtaStruct>();
    private KeyboardHook hookF4 = new KeyboardHook();
    private KeyboardHook hookF5 = new KeyboardHook();
    private MyThread myThread;
    private bool boxAuto;
    private bool boxUse;
    private MainForm.workStateEnum workState = MainForm.workStateEnum.stateStopped;
    private IContainer components;
    private System.Windows.Forms.Timer licenseTimer;
    private Label activatelabel;
    private Label labelStatus;
    private LinkLabel linkLabel1;
    private Label labelWorkSatus;
    private NotifyIcon notifyIcon1;
    private ImageList imageList1;
    private PictureBox pictureBox1;
    private ContextMenuStrip contextMenu;
    private ToolStripMenuItem boxMenuItem;
    private ToolStripMenuItem boxAutoMenuItem;
    private ToolStripMenuItem boxUseMenuItem;
    public System.Windows.Forms.Timer timerGetMyProcess;
    private ToolStripMenuItem startstopMenuItem;
    private ToolStripMenuItem CloseMenuItem;
    private Panel panel1;
    private ToolStripMenuItem activateMenuItem;
    private ToolStripMenuItem fishPriceMainMenuItem;
    private ToolStripMenuItem showHideMenuItem;
    private ToolStripMenuItem configSelMenuItem;
    private ToolStripMenuItem configAutoMenuItem;
    private ToolStripMenuItem configManualMenuItem;
    private ToolStripMenuItem diagMenuItem;
    private Label labelVer;
    private RichTextBox richTextBox1;
    private ToolStripMenuItem настройкаToolStripMenuItem;
    private ToolStripMenuItem robotClickMenuItem;
    private ToolStripComboBox speedComboMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem скоростьToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;

    public bool BoxAuto
    {
      get => this.boxAuto;
      set
      {
        this.boxAutoMenuItem.Checked = value;
        this.boxUseMenuItem.Enabled = !value;
        this.boxAuto = value;
      }
    }

    public bool BoxUse
    {
      get => this.boxUse;
      set
      {
        this.boxUseMenuItem.Checked = value;
        this.boxUse = value;
      }
    }

    public bool ConfigAuto
    {
      get => this.configAutoMenuItem.Checked;
      set
      {
        this.configAutoMenuItem.Checked = value;
        this.configManualMenuItem.Checked = !value;
      }
    }

    public MainForm()
    {
      this.InitializeComponent();
      this.hookF4.KeyPressed += new EventHandler<KeyPressedEventArgs>(this.hookF4_KeyPressed);
      this.hookF4.RegisterHotKey((ModifierKeys) 0, Keys.F4);
      this.hookF5.KeyPressed += new EventHandler<KeyPressedEventArgs>(this.hookF5_KeyPressed);
      this.hookF5.RegisterHotKey((ModifierKeys) 0, Keys.F5);
      this.activateForm.mainForm = this;
    }

    private void hookF4_KeyPressed(object sender, KeyPressedEventArgs e) => this.StartStop();

    private void hookF5_KeyPressed(object sender, KeyPressedEventArgs e) => this.ShowHide();

    public MainForm.workStateEnum WorkState
    {
      get => this.workState;
      set
      {
        this.workState = value;
        if (value == MainForm.workStateEnum.stateStarted)
        {
          this.licenseTimer.Enabled = true;
          this.labelStatus.ForeColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
          this.labelStatus.Text = "Работаю";
          this.boxAutoMenuItem.Enabled = false;
          this.boxUseMenuItem.Enabled = false;
          this.formFishMain.updatePrice1.Enabled = true;
        }
        else
        {
          this.licenseTimer.Enabled = false;
          this.labelStatus.ForeColor = Color.FromArgb((int) byte.MaxValue, 94, 94);
          this.labelStatus.Text = "Остановлен";
          this.labelWorkSatus.Text = "Статус работы";
          this.boxAutoMenuItem.Enabled = true;
          this.boxUseMenuItem.Enabled = !this.BoxAuto;
          this.formFishMain.updatePrice1.Enabled = false;
          this.formFishMain.price1.Text = "";
          this.formFishMain.price2.Text = "";
          this.formFishMain.pricetime1.Text = "";
          this.formFishMain.pricetime2.Text = "";
        }
      }
    }

    public void ShowHide()
    {
      if (!this.Visible)
      {
        this.Visible = true;
      }
      else
      {
        if (!this.Visible)
          return;
        this.Visible = false;
      }
    }

    public void StartStop()
    {
      if (this.workState == MainForm.workStateEnum.stateStarted)
        this.stop();
      else
        this.start();
    }

    public void ActivateText(MainForm.ActivateTextEnum activateEnum, string daysExp = "")
    {
      if (activateEnum != MainForm.ActivateTextEnum.activateOk)
      {
        if (activateEnum != MainForm.ActivateTextEnum.activateNo)
          return;
        this.activatelabel.Text = "Требуется активация";
        this.activatelabel.ForeColor = Color.FromArgb((int) byte.MaxValue, 94, 94);
        this.diagMenuItem.Visible = false;
        this.startstopMenuItem.Visible = false;
        this.boxMenuItem.Visible = false;
      }
      else
      {
        this.activatelabel.Text = "" + daysExp;
        this.activatelabel.ForeColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
        this.diagMenuItem.Visible = true;
        this.startstopMenuItem.Visible = true;
        this.boxMenuItem.Visible = true;
      }
    }

    public bool IsActivate(string code = "")
    {
        this.ActivateText(MainForm.ActivateTextEnum.activateOk, daysExp: "1337HackbySHAMBOT");
            return true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.labelVer.Text = "версия:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
      try
      {
        AutoUpdater.Start("http://radiopribori.ru/gta5rp/AutoUpdater.xml");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Ошибка проверки обновления. Используйте ручной режим обновления. " + ex.Message);
      }
      this.LoadContinue();
      this.stop();
      this.IsActivate();
      this.BoxAuto = Settings.Default.chekBoxAuto;
      this.BoxUse = Settings.Default.chekBoxUse;
      this.ConfigAuto = Settings.Default.configAuto;
      this.robotClickMenuItem.Checked = Settings.Default.robotClick;
      this.speedComboMenuItem.SelectedIndex = Settings.Default.speedClick;
    }

    private void LoadContinue()
    {
      string str;
      if (this.ConfigAuto)
      {
        str = Engine.GET("http://radiopribori.ru/gta5rp/config3.json");
      }
      else
      {
        if (!File.Exists("config3.json"))
        {
          int num = (int) MessageBox.Show("Выбрана ручная конфигурация, но файла конфигурации нет. Необходимо сменить её на автоматическую или создать эту конфигурацию в меню 'Выбор конфигурации>Диагностика и ручная конфигурация'");
          return;
        }
        str = File.ReadAllText("config3.json");
      }
      this.gta = JsonConvert.DeserializeObject<List<GtaStruct>>(str);
      this.licenseTimer.Enabled = true;
    }

    private void licenseTimer_Tick(object sender, EventArgs e)
    {
      if (this.IsActivate())
        return;
      this.stop();
    }

    private void enterKeyButton_Click(object sender, EventArgs e)
    {
    }

    public void start()
    {
      this.timerGetMyProcess.Enabled = true;
      if (this.workState == MainForm.workStateEnum.stateStarted)
        return;
      if (!this.IsActivate())
      {
        this.stop();
      }
      else
      {
        try
        {
          this.LoadContinue();
          Engine.GetMyProcess();
          if (Engine.MyProcess == null)
          {
            this.labelStatus.Text = "Окно не найдено";
          }
          else
          {
            int out_width = 0;
            int out_heigth = 0;
            Engine.GetWindowSize(Engine.MyProcess.MainWindowHandle, ref out_width, ref out_heigth);
            GtaStruct gtaItem = new GtaStruct();
            bool flag = false;
            foreach (GtaStruct gtaStruct in this.gta)
            {
              if (gtaStruct.videoSize.width == out_width && gtaStruct.videoSize.height == out_heigth)
              {
                flag = true;
                gtaItem = gtaStruct;
                break;
              }
            }
            if (!flag)
            {
              this.labelStatus.Text = string.Format("Размер экрана не поддерживается {0}x{1}", (object) out_width, (object) out_heigth);
              int num = (int) MessageBox.Show("Разрешение экрана не поддерживается или Вы не загрузили игру полностью.");
            }
            else
            {
              this.myThread = new MyThread(gtaItem, Engine.MyProcess.MainWindowHandle, this.boxAutoMenuItem.Checked, this.boxUseMenuItem.Checked, Convert.ToInt32(this.speedComboMenuItem.Text));
              this.myThread.MainForm = Form.ActiveForm;
              this.myThread.robotClick = this.robotClickMenuItem.Checked;
              this.myThread.labelWorkStatus = this.labelWorkSatus;
              this.myThread.Start();
              if (this.myThread.thread.ThreadState != System.Threading.ThreadState.Running)
                return;
              this.WorkState = MainForm.workStateEnum.stateStarted;
              if (!this.licenseTimer.Enabled)
                this.licenseTimer.Enabled = true;
              this.formFishMain.Start = true;
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
    }

    public async void timer1_Tick_1(object sender, EventArgs e)
    {
      Engine.MyProcess = await Engine.GetMyProcessAsync();
      if (Engine.MyProcess != null)
        return;
      this.stop();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://vk.com/gta5rpfishbot");

    public void stop()
    {
      this.timerGetMyProcess.Enabled = false;
      if (this.myThread != null)
      {
        this.myThread.threadStop = true;
        this.myThread.thread.Abort();
      }
      this.formFishMain.Start = false;
      this.WorkState = MainForm.workStateEnum.stateStopped;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => this.stop();

    private void checkBoxAuto_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Settings.Default.chekBoxAuto = this.boxAutoMenuItem.Checked;
      Settings.Default.chekBoxUse = this.boxUseMenuItem.Checked;
      Settings.Default.configAuto = this.ConfigAuto;
      Settings.Default.robotClick = this.robotClickMenuItem.Checked;
      Settings.Default.speedClick = this.speedComboMenuItem.SelectedIndex;
      Settings.Default.Save();
    }

    private void button1_Click_3(object sender, EventArgs e)
    {
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
      this.Capture = false;
      this.panel1.Capture = false;
      this.activatelabel.Capture = false;
      this.labelStatus.Capture = false;
      this.labelWorkSatus.Capture = false;
      this.pictureBox1.Capture = false;
      Message m = Message.Create(this.Handle, 161, new IntPtr(2), IntPtr.Zero);
      this.WndProc(ref m);
    }

    private void button1_Click_2(object sender, EventArgs e)
    {
    }

    private void button1_Click_4(object sender, EventArgs e) => this.Close();

    private void updatePrice1_Click(object sender, EventArgs e)
    {
    }

    private void updatePrice2_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.ShowHide();
    }

    private void button2_Click(object sender, EventArgs e)
    {
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
    }

    private void boxAutoMenuItem_Click(object sender, EventArgs e) => this.BoxAuto = !this.BoxAuto;

    private void checkBoxUse_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void startstopMenuItem_Click(object sender, EventArgs e) => this.StartStop();

    private void CloseMenuItem_Click(object sender, EventArgs e) => this.Close();

    private void startstopMenuItem_Click_1(object sender, EventArgs e) => this.StartStop();

    private void fishPriceMainMenuItem_Click(object sender, EventArgs e) => this.formFishMain.Show();

    private void showHideMenuItem_Click(object sender, EventArgs e) => this.ShowHide();

    private void configAutoMenuItem_Click(object sender, EventArgs e) => this.ConfigAuto = true;

    private void configManualMenuItem_Click(object sender, EventArgs e) => this.ConfigAuto = false;

    private void activateMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) this.activateForm.ShowDialog();
    }

    private void diagMenuItem_Click(object sender, EventArgs e)
    {
      Engine.GetMyProcess();
      if (Engine.MyProcess == null)
      {
        int num1 = (int) MessageBox.Show("Для начала войдите в игру");
      }
      else
      {
        int num2 = (int) this.formDiag.ShowDialog();
      }
    }

    private void boxUseMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void robotClickMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void speedComboMenuItem_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.myThread == null)
        return;
      this.myThread.speedClick = Convert.ToInt32(this.speedComboMenuItem.Text);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.licenseTimer = new System.Windows.Forms.Timer(this.components);
      this.activatelabel = new Label();
      this.labelStatus = new Label();
      this.linkLabel1 = new LinkLabel();
      this.labelWorkSatus = new Label();
      this.notifyIcon1 = new NotifyIcon(this.components);
      this.contextMenu = new ContextMenuStrip(this.components);
      this.startstopMenuItem = new ToolStripMenuItem();
      this.showHideMenuItem = new ToolStripMenuItem();
      this.настройкаToolStripMenuItem = new ToolStripMenuItem();
      this.robotClickMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.скоростьToolStripMenuItem = new ToolStripMenuItem();
      this.speedComboMenuItem = new ToolStripComboBox();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.boxMenuItem = new ToolStripMenuItem();
      this.boxAutoMenuItem = new ToolStripMenuItem();
      this.boxUseMenuItem = new ToolStripMenuItem();
      this.fishPriceMainMenuItem = new ToolStripMenuItem();
      this.configSelMenuItem = new ToolStripMenuItem();
      this.configAutoMenuItem = new ToolStripMenuItem();
      this.configManualMenuItem = new ToolStripMenuItem();
      this.diagMenuItem = new ToolStripMenuItem();
      this.activateMenuItem = new ToolStripMenuItem();
      this.CloseMenuItem = new ToolStripMenuItem();
      this.imageList1 = new ImageList(this.components);
      this.timerGetMyProcess = new System.Windows.Forms.Timer(this.components);
      this.panel1 = new Panel();
      this.richTextBox1 = new RichTextBox();
      this.labelVer = new Label();
      this.pictureBox1 = new PictureBox();
      this.contextMenu.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.licenseTimer.Interval = 900000;
      this.licenseTimer.Tick += new EventHandler(this.licenseTimer_Tick);
      this.activatelabel.AutoSize = true;
      this.activatelabel.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.activatelabel.ForeColor = Color.FromArgb((int) byte.MaxValue, 94, 94);
      this.activatelabel.Location = new Point(64, 37);
      this.activatelabel.Name = "activatelabel";
      this.activatelabel.Size = new Size(75, 15);
      this.activatelabel.TabIndex = 21;
      this.activatelabel.Text = "activatelabel";
      this.activatelabel.TextAlign = ContentAlignment.MiddleRight;
      this.activatelabel.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.labelStatus.AutoSize = true;
      this.labelStatus.BackColor = Color.FromArgb(64, 64, 64);
      this.labelStatus.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.labelStatus.ForeColor = Color.FromArgb((int) byte.MaxValue, 94, 94);
      this.labelStatus.Location = new Point(64, 7);
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new Size(47, 15);
      this.labelStatus.TabIndex = 22;
      this.labelStatus.Text = "Статус";
      this.labelStatus.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
      this.linkLabel1.LinkColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.linkLabel1.Location = new Point(4, 62);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(144, 13);
      this.linkLabel1.TabIndex = 25;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "https://vk.com/gta5rpfishbot";
      this.linkLabel1.TextAlign = ContentAlignment.MiddleRight;
      this.linkLabel1.VisitedLinkColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.labelWorkSatus.BackColor = Color.FromArgb(64, 64, 64);
      this.labelWorkSatus.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.labelWorkSatus.ForeColor = Color.RoyalBlue;
      this.labelWorkSatus.Location = new Point(64, 22);
      this.labelWorkSatus.Name = "labelWorkSatus";
      this.labelWorkSatus.Size = new Size(243, 15);
      this.labelWorkSatus.TabIndex = 29;
      this.labelWorkSatus.Text = "Статус работы";
      this.labelWorkSatus.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.notifyIcon1.ContextMenuStrip = this.contextMenu;
      this.notifyIcon1.Icon = (Icon) componentResourceManager.GetObject("notifyIcon1.Icon");
      this.notifyIcon1.Text = "GTA 5 RP Рыбалка";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseClick += new MouseEventHandler(this.notifyIcon1_MouseClick);
      this.contextMenu.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.startstopMenuItem,
        (ToolStripItem) this.showHideMenuItem,
        (ToolStripItem) this.настройкаToolStripMenuItem,
        (ToolStripItem) this.boxMenuItem,
        (ToolStripItem) this.fishPriceMainMenuItem,
        (ToolStripItem) this.configSelMenuItem,
        (ToolStripItem) this.activateMenuItem,
        (ToolStripItem) this.CloseMenuItem
      });
      this.contextMenu.LayoutStyle = ToolStripLayoutStyle.Table;
      this.contextMenu.Name = "contextMenuStrip1";
      this.contextMenu.Size = new Size(201, 234);
      this.contextMenu.Opening += new CancelEventHandler(this.contextMenuStrip1_Opening);
      this.startstopMenuItem.Image = (Image) Resources.start_stop20;
      this.startstopMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.startstopMenuItem.Name = "startstopMenuItem";
      this.startstopMenuItem.ShortcutKeys = Keys.F4;
      this.startstopMenuItem.Size = new Size(200, 26);
      this.startstopMenuItem.Text = "Старт/Стоп";
      this.startstopMenuItem.Click += new EventHandler(this.startstopMenuItem_Click_1);
      this.showHideMenuItem.Image = (Image) Resources.hide_show20;
      this.showHideMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.showHideMenuItem.Name = "showHideMenuItem";
      this.showHideMenuItem.ShortcutKeys = Keys.F5;
      this.showHideMenuItem.Size = new Size(200, 26);
      this.showHideMenuItem.Text = "Показать/Скрыть";
      this.showHideMenuItem.Click += new EventHandler(this.showHideMenuItem_Click);
      this.настройкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.robotClickMenuItem,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.скоростьToolStripMenuItem,
        (ToolStripItem) this.speedComboMenuItem,
        (ToolStripItem) this.toolStripSeparator1
      });
      this.настройкаToolStripMenuItem.Image = (Image) Resources.diag20;
      this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
      this.настройкаToolStripMenuItem.Size = new Size(200, 26);
      this.настройкаToolStripMenuItem.Text = "Настройка";
      this.robotClickMenuItem.CheckOnClick = true;
      this.robotClickMenuItem.Image = (Image) Resources.robot20;
      this.robotClickMenuItem.Name = "robotClickMenuItem";
      this.robotClickMenuItem.Size = new Size(187, 22);
      this.robotClickMenuItem.Text = "Нажимать \"Я робот\"";
      this.robotClickMenuItem.Click += new EventHandler(this.robotClickMenuItem_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(184, 6);
      this.скоростьToolStripMenuItem.Enabled = false;
      this.скоростьToolStripMenuItem.Name = "скоростьToolStripMenuItem";
      this.скоростьToolStripMenuItem.Size = new Size(187, 22);
      this.скоростьToolStripMenuItem.Text = "Скорость, мс";
      this.speedComboMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
      this.speedComboMenuItem.Items.AddRange(new object[9]
      {
        (object) "5",
        (object) "25",
        (object) "50",
        (object) "100",
        (object) "150",
        (object) "200",
        (object) "250",
        (object) "300",
        (object) "350"
      });
      this.speedComboMenuItem.Name = "speedComboMenuItem";
      this.speedComboMenuItem.Size = new Size(121, 23);
      this.speedComboMenuItem.SelectedIndexChanged += new EventHandler(this.speedComboMenuItem_SelectedIndexChanged);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(184, 6);
      this.boxMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.boxAutoMenuItem,
        (ToolStripItem) this.boxUseMenuItem
      });
      this.boxMenuItem.Image = (Image) Resources.box20;
      this.boxMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.boxMenuItem.Name = "boxMenuItem";
      this.boxMenuItem.Size = new Size(200, 26);
      this.boxMenuItem.Text = "Сумка";
      this.boxAutoMenuItem.Checked = true;
      this.boxAutoMenuItem.CheckOnClick = true;
      this.boxAutoMenuItem.CheckState = CheckState.Checked;
      this.boxAutoMenuItem.Name = "boxAutoMenuItem";
      this.boxAutoMenuItem.Size = new Size(261, 22);
      this.boxAutoMenuItem.Text = "Определять сумку автоматически";
      this.boxAutoMenuItem.Click += new EventHandler(this.boxAutoMenuItem_Click);
      this.boxUseMenuItem.CheckOnClick = true;
      this.boxUseMenuItem.Name = "boxUseMenuItem";
      this.boxUseMenuItem.Size = new Size(261, 22);
      this.boxUseMenuItem.Text = "Сумка надета";
      this.boxUseMenuItem.Click += new EventHandler(this.boxUseMenuItem_Click);
      this.fishPriceMainMenuItem.Image = (Image) Resources.ref20;
      this.fishPriceMainMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.fishPriceMainMenuItem.Name = "fishPriceMainMenuItem";
      this.fishPriceMainMenuItem.Size = new Size(200, 26);
      this.fishPriceMainMenuItem.Text = "Цены скупщиков";
      this.fishPriceMainMenuItem.Click += new EventHandler(this.fishPriceMainMenuItem_Click);
      this.configSelMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.configAutoMenuItem,
        (ToolStripItem) this.configManualMenuItem,
        (ToolStripItem) this.diagMenuItem
      });
      this.configSelMenuItem.Image = (Image) Resources.diag20;
      this.configSelMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.configSelMenuItem.Name = "configSelMenuItem";
      this.configSelMenuItem.Size = new Size(200, 26);
      this.configSelMenuItem.Text = "Выбор конфигурации";
      this.configAutoMenuItem.Checked = true;
      this.configAutoMenuItem.CheckState = CheckState.Checked;
      this.configAutoMenuItem.Name = "configAutoMenuItem";
      this.configAutoMenuItem.Size = new Size(284, 26);
      this.configAutoMenuItem.Text = "Автоматический";
      this.configAutoMenuItem.Click += new EventHandler(this.configAutoMenuItem_Click);
      this.configManualMenuItem.Name = "configManualMenuItem";
      this.configManualMenuItem.Size = new Size(284, 26);
      this.configManualMenuItem.Text = "Ручной";
      this.configManualMenuItem.Click += new EventHandler(this.configManualMenuItem_Click);
      this.diagMenuItem.Image = (Image) Resources.diag20;
      this.diagMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.diagMenuItem.Name = "diagMenuItem";
      this.diagMenuItem.Size = new Size(284, 26);
      this.diagMenuItem.Text = "Диагностика и ручная конфигурации";
      this.diagMenuItem.Click += new EventHandler(this.diagMenuItem_Click);
      this.activateMenuItem.Image = (Image) Resources.activate20;
      this.activateMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.activateMenuItem.Name = "activateMenuItem";
      this.activateMenuItem.Size = new Size(200, 26);
      this.activateMenuItem.Text = "Ввод ключа";
      this.activateMenuItem.Click += new EventHandler(this.activateMenuItem_Click);
      this.CloseMenuItem.Image = (Image) Resources.close20;
      this.CloseMenuItem.ImageScaling = ToolStripItemImageScaling.None;
      this.CloseMenuItem.Name = "CloseMenuItem";
      this.CloseMenuItem.Size = new Size(200, 26);
      this.CloseMenuItem.Text = "Выйти";
      this.CloseMenuItem.Click += new EventHandler(this.CloseMenuItem_Click);
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "upd.png");
      this.timerGetMyProcess.Interval = 2000;
      this.timerGetMyProcess.Tick += new EventHandler(this.timer1_Tick_1);
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.richTextBox1);
      this.panel1.Controls.Add((Control) this.labelVer);
      this.panel1.Controls.Add((Control) this.labelStatus);
      this.panel1.Controls.Add((Control) this.activatelabel);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.linkLabel1);
      this.panel1.Controls.Add((Control) this.labelWorkSatus);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(347, 79);
      this.panel1.TabIndex = 46;
      this.panel1.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.richTextBox1.Location = new Point(3, 78);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(339, 108);
      this.richTextBox1.TabIndex = 48;
      this.richTextBox1.Text = "";
      this.richTextBox1.Visible = false;
      this.labelVer.ForeColor = Color.Gray;
      this.labelVer.Location = new Point(200, 62);
      this.labelVer.Name = "labelVer";
      this.labelVer.Size = new Size(142, 13);
      this.labelVer.TabIndex = 47;
      this.labelVer.Text = "Версия";
      this.labelVer.TextAlign = ContentAlignment.MiddleRight;
      this.labelVer.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.pictureBox1.Image = (Image) Resources.icon_no_bg55;
      this.pictureBox1.Location = new Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(55, 55);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 45;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(64, 64, 64);
      this.ClientSize = new Size(347, 79);
      this.ContextMenuStrip = this.contextMenu;
      this.Controls.Add((Control) this.panel1);
      this.ForeColor = SystemColors.ControlText;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (MainForm);
      this.Opacity = 0.92;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "GТA 5 RР Рыбaлкa";
      this.TopMost = true;
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new EventHandler(this.Form1_Load);
      this.MouseDown += new MouseEventHandler(this.MainForm_MouseDown);
      this.contextMenu.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }

    public enum workStateEnum
    {
      stateStarted,
      stateStopped,
    }

    public enum ActivateTextEnum
    {
      activateOk,
      activateNo,
    }
  }
}
