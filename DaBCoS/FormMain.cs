using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.IO;
using DaBCoS.Engine;

namespace DaBCoS 
{
	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form 
	{

		#region Windows Form Variables

		private System.Windows.Forms.ToolBar tbMain;
		private System.Windows.Forms.ToolBarButton tbbConnect;
		private System.Windows.Forms.ImageList ilToolbar;
		private System.Windows.Forms.ToolBarButton tbbSeparator1;
		private System.Windows.Forms.StatusBar sbMain;
		private System.Windows.Forms.Timer tmrCleanStatusBar;
		private System.Windows.Forms.ToolBarButton tbbDisconnect;
		private System.Windows.Forms.StatusBarPanel sbpMessages;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton tbbConnect2;
		private System.Windows.Forms.ToolBarButton tbbDisconnect2;
		private System.Windows.Forms.ToolBarButton tbbSeparator2;
		private System.Windows.Forms.ToolBarButton tbbCompare;
		private System.Windows.Forms.ToolBarButton tbbDatabase;
		private System.Windows.Forms.ToolBarButton tbbDatabase2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.ToolBarButton tbbSynchronize;
		private System.Windows.Forms.ImageList ilMisc;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpTables;
		private System.Windows.Forms.ListView lvTables;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage tpFunctions;
		private System.Windows.Forms.ListView lvFunctions;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tpViews;
		private System.Windows.Forms.ListView lvViews;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabPage tpStoredProcs;
		private System.Windows.Forms.ListView lvProcedures;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ColumnHeader chDatabaseA;
		private System.Windows.Forms.ColumnHeader chState;
		private System.Windows.Forms.ColumnHeader chAction;
		private System.Windows.Forms.ColumnHeader chDatabaseB;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.PictureBox pbUser1;
		private System.Windows.Forms.PictureBox pbTable1;
		private System.Windows.Forms.PictureBox pbTable2;
		private System.Windows.Forms.PictureBox pbUser2;
		private System.Windows.Forms.PictureBox pbDB2;
		private System.Windows.Forms.PictureBox pbDB1;
		private System.Windows.Forms.Label lblUserSecond;
		private System.Windows.Forms.Label lblUserFirst;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar pbState;
		private System.Windows.Forms.Label lblDBSecond;
		private System.Windows.Forms.Label lblServerSecond;
		private System.Windows.Forms.Label lblDBFirst;
		private System.Windows.Forms.Label lblServerFirst;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox lbLog;
		private System.Windows.Forms.Label lblSource2;
		private System.Windows.Forms.Label lblSource1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MainMenu mmMain;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

		private FormAbout wndAbout = null;
		private FormDetail wndDatabaseInfo = null;
		private FormSelectDatabase wndDatabaseSelection = null;
		private FormLogin wndLoginInfo = null;

		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem itemHelpAbout;
		private System.Windows.Forms.MenuItem itemIncludeTables;
		private System.Windows.Forms.MenuItem itemIncludeFunctions;
		private System.Windows.Forms.MenuItem itemIncludeViews;
		private System.Windows.Forms.MenuItem itemIncludeProcs;
		private System.Windows.Forms.MenuItem menuInclude;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.TabPage tpTriggers;
		private System.Windows.Forms.ListView lvTriggers;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.Label labelTriggers;
		private System.Windows.Forms.StatusBarPanel sbpProgress;
		private System.Windows.Forms.TabPage tpConstraints;
		private System.Windows.Forms.ListView lvConstraints;
		private System.Windows.Forms.ColumnHeader columnHeader21;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuItem itemIncludeTriggers;
		private System.Windows.Forms.MenuItem itemIncludeConstraints;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem itemIncludeAll;
		private System.Windows.Forms.MenuItem itemIncludeNone;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem itemHelpHomePage;
		private System.Windows.Forms.MenuItem menuCompare;
		private System.Windows.Forms.MenuItem itemCompareStart;
		private System.Windows.Forms.MenuItem itemFileExportResults;

		#endregion Windows Forms Variables

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tbMain = new System.Windows.Forms.ToolBar();
            this.tbbConnect = new System.Windows.Forms.ToolBarButton();
            this.tbbDisconnect = new System.Windows.Forms.ToolBarButton();
            this.tbbDatabase = new System.Windows.Forms.ToolBarButton();
            this.tbbSeparator1 = new System.Windows.Forms.ToolBarButton();
            this.tbbConnect2 = new System.Windows.Forms.ToolBarButton();
            this.tbbDisconnect2 = new System.Windows.Forms.ToolBarButton();
            this.tbbDatabase2 = new System.Windows.Forms.ToolBarButton();
            this.tbbSeparator2 = new System.Windows.Forms.ToolBarButton();
            this.tbbCompare = new System.Windows.Forms.ToolBarButton();
            this.tbbSynchronize = new System.Windows.Forms.ToolBarButton();
            this.ilToolbar = new System.Windows.Forms.ImageList(this.components);
            this.sbMain = new System.Windows.Forms.StatusBar();
            this.sbpMessages = new System.Windows.Forms.StatusBarPanel();
            this.sbpProgress = new System.Windows.Forms.StatusBarPanel();
            this.tmrCleanStatusBar = new System.Windows.Forms.Timer(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pbUser1 = new System.Windows.Forms.PictureBox();
            this.pbTable1 = new System.Windows.Forms.PictureBox();
            this.pbTable2 = new System.Windows.Forms.PictureBox();
            this.pbUser2 = new System.Windows.Forms.PictureBox();
            this.pbDB2 = new System.Windows.Forms.PictureBox();
            this.pbDB1 = new System.Windows.Forms.PictureBox();
            this.lblUserSecond = new System.Windows.Forms.Label();
            this.lblUserFirst = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbState = new System.Windows.Forms.ProgressBar();
            this.lblDBSecond = new System.Windows.Forms.Label();
            this.lblServerSecond = new System.Windows.Forms.Label();
            this.lblSource2 = new System.Windows.Forms.Label();
            this.lblDBFirst = new System.Windows.Forms.Label();
            this.lblServerFirst = new System.Windows.Forms.Label();
            this.lblSource1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.ilMisc = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpTables = new System.Windows.Forms.TabPage();
            this.lvTables = new System.Windows.Forms.ListView();
            this.chDatabaseA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDatabaseB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.tpFunctions = new System.Windows.Forms.TabPage();
            this.lvFunctions = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.tpViews = new System.Windows.Forms.TabPage();
            this.lvViews = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.tpStoredProcs = new System.Windows.Forms.TabPage();
            this.lvProcedures = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.tpTriggers = new System.Windows.Forms.TabPage();
            this.lvTriggers = new System.Windows.Forms.ListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTriggers = new System.Windows.Forms.Label();
            this.tpConstraints = new System.Windows.Forms.TabPage();
            this.lvConstraints = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.itemFileExportResults = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.itemHelpAbout = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.itemHelpHomePage = new System.Windows.Forms.MenuItem();
            this.mmMain = new System.Windows.Forms.MainMenu(this.components);
            this.menuInclude = new System.Windows.Forms.MenuItem();
            this.itemIncludeTables = new System.Windows.Forms.MenuItem();
            this.itemIncludeFunctions = new System.Windows.Forms.MenuItem();
            this.itemIncludeViews = new System.Windows.Forms.MenuItem();
            this.itemIncludeProcs = new System.Windows.Forms.MenuItem();
            this.itemIncludeTriggers = new System.Windows.Forms.MenuItem();
            this.itemIncludeConstraints = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.itemIncludeAll = new System.Windows.Forms.MenuItem();
            this.itemIncludeNone = new System.Windows.Forms.MenuItem();
            this.menuCompare = new System.Windows.Forms.MenuItem();
            this.itemCompareStart = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpProgress)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDB1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpTables.SuspendLayout();
            this.tpFunctions.SuspendLayout();
            this.tpViews.SuspendLayout();
            this.tpStoredProcs.SuspendLayout();
            this.tpTriggers.SuspendLayout();
            this.tpConstraints.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tbMain.AutoSize = false;
            this.tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbConnect,
            this.tbbDisconnect,
            this.tbbDatabase,
            this.tbbSeparator1,
            this.tbbConnect2,
            this.tbbDisconnect2,
            this.tbbDatabase2,
            this.tbbSeparator2,
            this.tbbCompare,
            this.tbbSynchronize});
            this.tbMain.ButtonSize = new System.Drawing.Size(65, 36);
            this.tbMain.DropDownArrows = true;
            this.tbMain.ImageList = this.ilToolbar;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.ShowToolTips = true;
            this.tbMain.Size = new System.Drawing.Size(990, 47);
            this.tbMain.TabIndex = 0;
            this.tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbMain_ButtonClick);
            // 
            // tbbConnect
            // 
            this.tbbConnect.ImageIndex = 0;
            this.tbbConnect.Name = "tbbConnect";
            this.tbbConnect.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbbConnect.Text = "Connect";
            // 
            // tbbDisconnect
            // 
            this.tbbDisconnect.Enabled = false;
            this.tbbDisconnect.ImageIndex = 1;
            this.tbbDisconnect.Name = "tbbDisconnect";
            this.tbbDisconnect.Text = "Disconnect";
            // 
            // tbbDatabase
            // 
            this.tbbDatabase.Enabled = false;
            this.tbbDatabase.ImageIndex = 2;
            this.tbbDatabase.Name = "tbbDatabase";
            this.tbbDatabase.Text = "Database";
            // 
            // tbbSeparator1
            // 
            this.tbbSeparator1.Name = "tbbSeparator1";
            this.tbbSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbConnect2
            // 
            this.tbbConnect2.ImageIndex = 3;
            this.tbbConnect2.Name = "tbbConnect2";
            this.tbbConnect2.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbbConnect2.Text = "Connect";
            // 
            // tbbDisconnect2
            // 
            this.tbbDisconnect2.Enabled = false;
            this.tbbDisconnect2.ImageIndex = 4;
            this.tbbDisconnect2.Name = "tbbDisconnect2";
            this.tbbDisconnect2.Text = "Disconnect";
            // 
            // tbbDatabase2
            // 
            this.tbbDatabase2.Enabled = false;
            this.tbbDatabase2.ImageIndex = 5;
            this.tbbDatabase2.Name = "tbbDatabase2";
            this.tbbDatabase2.Text = "Database";
            // 
            // tbbSeparator2
            // 
            this.tbbSeparator2.Name = "tbbSeparator2";
            this.tbbSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbCompare
            // 
            this.tbbCompare.Enabled = false;
            this.tbbCompare.ImageIndex = 6;
            this.tbbCompare.Name = "tbbCompare";
            this.tbbCompare.Text = "Compare";
            // 
            // tbbSynchronize
            // 
            this.tbbSynchronize.Enabled = false;
            this.tbbSynchronize.ImageIndex = 7;
            this.tbbSynchronize.Name = "tbbSynchronize";
            this.tbbSynchronize.Text = "Synchronize";
            // 
            // ilToolbar
            // 
            this.ilToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbar.ImageStream")));
            this.ilToolbar.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(234)))));
            this.ilToolbar.Images.SetKeyName(0, "");
            this.ilToolbar.Images.SetKeyName(1, "");
            this.ilToolbar.Images.SetKeyName(2, "");
            this.ilToolbar.Images.SetKeyName(3, "");
            this.ilToolbar.Images.SetKeyName(4, "");
            this.ilToolbar.Images.SetKeyName(5, "");
            this.ilToolbar.Images.SetKeyName(6, "");
            this.ilToolbar.Images.SetKeyName(7, "");
            // 
            // sbMain
            // 
            this.sbMain.Location = new System.Drawing.Point(0, 580);
            this.sbMain.Name = "sbMain";
            this.sbMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpMessages,
            this.sbpProgress});
            this.sbMain.ShowPanels = true;
            this.sbMain.Size = new System.Drawing.Size(990, 19);
            this.sbMain.TabIndex = 2;
            // 
            // sbpMessages
            // 
            this.sbpMessages.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpMessages.Name = "sbpMessages";
            this.sbpMessages.Width = 869;
            // 
            // sbpProgress
            // 
            this.sbpProgress.Name = "sbpProgress";
            // 
            // tmrCleanStatusBar
            // 
            this.tmrCleanStatusBar.Interval = 1000;
            this.tmrCleanStatusBar.Tick += new System.EventHandler(this.tmrCleanStatusBar_Tick);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 454);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(990, 5);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.pbUser1);
            this.groupBox2.Controls.Add(this.pbTable1);
            this.groupBox2.Controls.Add(this.pbTable2);
            this.groupBox2.Controls.Add(this.pbUser2);
            this.groupBox2.Controls.Add(this.pbDB2);
            this.groupBox2.Controls.Add(this.pbDB1);
            this.groupBox2.Controls.Add(this.lblUserSecond);
            this.groupBox2.Controls.Add(this.lblUserFirst);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pbState);
            this.groupBox2.Controls.Add(this.lblDBSecond);
            this.groupBox2.Controls.Add(this.lblServerSecond);
            this.groupBox2.Controls.Add(this.lblSource2);
            this.groupBox2.Controls.Add(this.lblDBFirst);
            this.groupBox2.Controls.Add(this.lblServerFirst);
            this.groupBox2.Controls.Add(this.lblSource1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(743, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 407);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connections";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(64, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 28);
            this.button2.TabIndex = 33;
            this.button2.Text = "Save Session";
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(64, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 28);
            this.button1.TabIndex = 32;
            this.button1.Text = "Save Session";
            this.button1.Visible = false;
            // 
            // pbUser1
            // 
            this.pbUser1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbUser1.Location = new System.Drawing.Point(4, 78);
            this.pbUser1.Name = "pbUser1";
            this.pbUser1.Size = new System.Drawing.Size(23, 19);
            this.pbUser1.TabIndex = 31;
            this.pbUser1.TabStop = false;
            // 
            // pbTable1
            // 
            this.pbTable1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbTable1.Location = new System.Drawing.Point(4, 107);
            this.pbTable1.Name = "pbTable1";
            this.pbTable1.Size = new System.Drawing.Size(23, 19);
            this.pbTable1.TabIndex = 30;
            this.pbTable1.TabStop = false;
            // 
            // pbTable2
            // 
            this.pbTable2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbTable2.Location = new System.Drawing.Point(4, 257);
            this.pbTable2.Name = "pbTable2";
            this.pbTable2.Size = new System.Drawing.Size(23, 20);
            this.pbTable2.TabIndex = 29;
            this.pbTable2.TabStop = false;
            // 
            // pbUser2
            // 
            this.pbUser2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbUser2.Location = new System.Drawing.Point(4, 287);
            this.pbUser2.Name = "pbUser2";
            this.pbUser2.Size = new System.Drawing.Size(23, 19);
            this.pbUser2.TabIndex = 28;
            this.pbUser2.TabStop = false;
            // 
            // pbDB2
            // 
            this.pbDB2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbDB2.Location = new System.Drawing.Point(4, 228);
            this.pbDB2.Name = "pbDB2";
            this.pbDB2.Size = new System.Drawing.Size(23, 20);
            this.pbDB2.TabIndex = 27;
            this.pbDB2.TabStop = false;
            // 
            // pbDB1
            // 
            this.pbDB1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbDB1.Location = new System.Drawing.Point(4, 49);
            this.pbDB1.Name = "pbDB1";
            this.pbDB1.Size = new System.Drawing.Size(23, 19);
            this.pbDB1.TabIndex = 26;
            this.pbDB1.TabStop = false;
            // 
            // lblUserSecond
            // 
            this.lblUserSecond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserSecond.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserSecond.Location = new System.Drawing.Point(28, 286);
            this.lblUserSecond.Name = "lblUserSecond";
            this.lblUserSecond.Size = new System.Drawing.Size(213, 20);
            this.lblUserSecond.TabIndex = 25;
            // 
            // lblUserFirst
            // 
            this.lblUserFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserFirst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserFirst.Location = new System.Drawing.Point(28, 107);
            this.lblUserFirst.Name = "lblUserFirst";
            this.lblUserFirst.Size = new System.Drawing.Size(213, 19);
            this.lblUserFirst.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "Current operation:";
            // 
            // pbState
            // 
            this.pbState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbState.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbState.Location = new System.Drawing.Point(3, 384);
            this.pbState.Name = "pbState";
            this.pbState.Size = new System.Drawing.Size(241, 20);
            this.pbState.Step = 1;
            this.pbState.TabIndex = 22;
            // 
            // lblDBSecond
            // 
            this.lblDBSecond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDBSecond.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBSecond.Location = new System.Drawing.Point(28, 303);
            this.lblDBSecond.Name = "lblDBSecond";
            this.lblDBSecond.Size = new System.Drawing.Size(213, 20);
            this.lblDBSecond.TabIndex = 21;
            // 
            // lblServerSecond
            // 
            this.lblServerSecond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerSecond.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerSecond.Location = new System.Drawing.Point(28, 244);
            this.lblServerSecond.Name = "lblServerSecond";
            this.lblServerSecond.Size = new System.Drawing.Size(213, 20);
            this.lblServerSecond.TabIndex = 20;
            // 
            // lblSource2
            // 
            this.lblSource2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSource2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSource2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource2.Location = new System.Drawing.Point(1, 195);
            this.lblSource2.Name = "lblSource2";
            this.lblSource2.Size = new System.Drawing.Size(235, 19);
            this.lblSource2.TabIndex = 19;
            this.lblSource2.Text = "Source 2";
            // 
            // lblDBFirst
            // 
            this.lblDBFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDBFirst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBFirst.Location = new System.Drawing.Point(28, 129);
            this.lblDBFirst.Name = "lblDBFirst";
            this.lblDBFirst.Size = new System.Drawing.Size(213, 19);
            this.lblDBFirst.TabIndex = 18;
            // 
            // lblServerFirst
            // 
            this.lblServerFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerFirst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerFirst.Location = new System.Drawing.Point(28, 70);
            this.lblServerFirst.Name = "lblServerFirst";
            this.lblServerFirst.Size = new System.Drawing.Size(213, 20);
            this.lblServerFirst.TabIndex = 17;
            // 
            // lblSource1
            // 
            this.lblSource1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSource1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource1.Location = new System.Drawing.Point(4, 19);
            this.lblSource1.Name = "lblSource1";
            this.lblSource1.Size = new System.Drawing.Size(235, 20);
            this.lblSource1.TabIndex = 16;
            this.lblSource1.Text = "Source 1";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(738, 47);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 407);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // ilMisc
            // 
            this.ilMisc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMisc.ImageStream")));
            this.ilMisc.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(234)))));
            this.ilMisc.Images.SetKeyName(0, "");
            this.ilMisc.Images.SetKeyName(1, "");
            this.ilMisc.Images.SetKeyName(2, "");
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Database 1";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "State";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Action";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Database 2";
            this.columnHeader4.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 407);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // tcMain
            // 
            this.tcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcMain.Controls.Add(this.tpTables);
            this.tcMain.Controls.Add(this.tpFunctions);
            this.tcMain.Controls.Add(this.tpViews);
            this.tcMain.Controls.Add(this.tpStoredProcs);
            this.tcMain.Controls.Add(this.tpTriggers);
            this.tcMain.Controls.Add(this.tpConstraints);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.HotTrack = true;
            this.tcMain.Location = new System.Drawing.Point(3, 20);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(732, 384);
            this.tcMain.TabIndex = 14;
            // 
            // tpTables
            // 
            this.tpTables.Controls.Add(this.lvTables);
            this.tpTables.Controls.Add(this.label8);
            this.tpTables.Location = new System.Drawing.Point(4, 29);
            this.tpTables.Name = "tpTables";
            this.tpTables.Size = new System.Drawing.Size(724, 351);
            this.tpTables.TabIndex = 0;
            this.tpTables.Text = "Tables";
            // 
            // lvTables
            // 
            this.lvTables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDatabaseA,
            this.chState,
            this.chAction,
            this.chDatabaseB});
            this.lvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTables.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lvTables.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvTables.FullRowSelect = true;
            this.lvTables.GridLines = true;
            this.lvTables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTables.Location = new System.Drawing.Point(0, 19);
            this.lvTables.MultiSelect = false;
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(724, 332);
            this.lvTables.TabIndex = 2;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            this.lvTables.DoubleClick += new System.EventHandler(this.lvTables_DoubleClick);
            this.lvTables.Resize += new System.EventHandler(this.lvAll_Resize);
            // 
            // chDatabaseA
            // 
            this.chDatabaseA.Text = "Database 1";
            this.chDatabaseA.Width = 200;
            // 
            // chState
            // 
            this.chState.Text = "State";
            this.chState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chAction
            // 
            this.chAction.Text = "Action";
            this.chAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chDatabaseB
            // 
            this.chDatabaseB.Text = "Database 2";
            this.chDatabaseB.Width = 200;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(724, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Tables";
            // 
            // tpFunctions
            // 
            this.tpFunctions.Controls.Add(this.lvFunctions);
            this.tpFunctions.Controls.Add(this.label4);
            this.tpFunctions.Location = new System.Drawing.Point(4, 28);
            this.tpFunctions.Name = "tpFunctions";
            this.tpFunctions.Size = new System.Drawing.Size(724, 354);
            this.tpFunctions.TabIndex = 3;
            this.tpFunctions.Text = "Functions";
            this.tpFunctions.Visible = false;
            // 
            // lvFunctions
            // 
            this.lvFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvFunctions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lvFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFunctions.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lvFunctions.FullRowSelect = true;
            this.lvFunctions.GridLines = true;
            this.lvFunctions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFunctions.Location = new System.Drawing.Point(0, 19);
            this.lvFunctions.MultiSelect = false;
            this.lvFunctions.Name = "lvFunctions";
            this.lvFunctions.Size = new System.Drawing.Size(724, 335);
            this.lvFunctions.TabIndex = 4;
            this.lvFunctions.UseCompatibleStateImageBehavior = false;
            this.lvFunctions.View = System.Windows.Forms.View.Details;
            this.lvFunctions.DoubleClick += new System.EventHandler(this.lvFunctions_DoubleClick);
            this.lvFunctions.Resize += new System.EventHandler(this.lvAll_Resize);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Database 1";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "State";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Action";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Database 2";
            this.columnHeader12.Width = 200;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(724, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Functions";
            // 
            // tpViews
            // 
            this.tpViews.Controls.Add(this.lvViews);
            this.tpViews.Controls.Add(this.label6);
            this.tpViews.Location = new System.Drawing.Point(4, 28);
            this.tpViews.Name = "tpViews";
            this.tpViews.Size = new System.Drawing.Size(724, 354);
            this.tpViews.TabIndex = 1;
            this.tpViews.Text = "Views";
            this.tpViews.Visible = false;
            // 
            // lvViews
            // 
            this.lvViews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvViews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvViews.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lvViews.FullRowSelect = true;
            this.lvViews.GridLines = true;
            this.lvViews.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvViews.Location = new System.Drawing.Point(0, 19);
            this.lvViews.MultiSelect = false;
            this.lvViews.Name = "lvViews";
            this.lvViews.Size = new System.Drawing.Size(724, 335);
            this.lvViews.TabIndex = 3;
            this.lvViews.UseCompatibleStateImageBehavior = false;
            this.lvViews.View = System.Windows.Forms.View.Details;
            this.lvViews.DoubleClick += new System.EventHandler(this.lvViews_DoubleClick);
            this.lvViews.Resize += new System.EventHandler(this.lvAll_Resize);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Database 1";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "State";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Action";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Database 2";
            this.columnHeader8.Width = 200;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(724, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Views";
            // 
            // tpStoredProcs
            // 
            this.tpStoredProcs.Controls.Add(this.lvProcedures);
            this.tpStoredProcs.Controls.Add(this.label5);
            this.tpStoredProcs.Location = new System.Drawing.Point(4, 28);
            this.tpStoredProcs.Name = "tpStoredProcs";
            this.tpStoredProcs.Size = new System.Drawing.Size(724, 354);
            this.tpStoredProcs.TabIndex = 2;
            this.tpStoredProcs.Text = "Stored Procedures";
            this.tpStoredProcs.Visible = false;
            // 
            // lvProcedures
            // 
            this.lvProcedures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvProcedures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.lvProcedures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcedures.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lvProcedures.FullRowSelect = true;
            this.lvProcedures.GridLines = true;
            this.lvProcedures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProcedures.Location = new System.Drawing.Point(0, 19);
            this.lvProcedures.MultiSelect = false;
            this.lvProcedures.Name = "lvProcedures";
            this.lvProcedures.Size = new System.Drawing.Size(724, 335);
            this.lvProcedures.TabIndex = 4;
            this.lvProcedures.UseCompatibleStateImageBehavior = false;
            this.lvProcedures.View = System.Windows.Forms.View.Details;
            this.lvProcedures.DoubleClick += new System.EventHandler(this.lvProcedures_DoubleClick);
            this.lvProcedures.Resize += new System.EventHandler(this.lvAll_Resize);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Database 1";
            this.columnHeader13.Width = 200;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "State";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Action";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Database 2";
            this.columnHeader16.Width = 200;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(724, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Stored Procedures";
            // 
            // tpTriggers
            // 
            this.tpTriggers.Controls.Add(this.lvTriggers);
            this.tpTriggers.Controls.Add(this.labelTriggers);
            this.tpTriggers.Location = new System.Drawing.Point(4, 28);
            this.tpTriggers.Name = "tpTriggers";
            this.tpTriggers.Size = new System.Drawing.Size(724, 354);
            this.tpTriggers.TabIndex = 4;
            this.tpTriggers.Text = "Triggers";
            // 
            // lvTriggers
            // 
            this.lvTriggers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTriggers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.lvTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTriggers.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lvTriggers.FullRowSelect = true;
            this.lvTriggers.GridLines = true;
            this.lvTriggers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTriggers.Location = new System.Drawing.Point(0, 19);
            this.lvTriggers.MultiSelect = false;
            this.lvTriggers.Name = "lvTriggers";
            this.lvTriggers.Size = new System.Drawing.Size(724, 335);
            this.lvTriggers.TabIndex = 6;
            this.lvTriggers.UseCompatibleStateImageBehavior = false;
            this.lvTriggers.View = System.Windows.Forms.View.Details;
            this.lvTriggers.DoubleClick += new System.EventHandler(this.lvTriggers_DoubleClick);
            this.lvTriggers.Resize += new System.EventHandler(this.lvAll_Resize);
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Database 1";
            this.columnHeader17.Width = 200;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "State";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Action";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Database 2";
            this.columnHeader20.Width = 200;
            // 
            // labelTriggers
            // 
            this.labelTriggers.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelTriggers.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTriggers.Location = new System.Drawing.Point(0, 0);
            this.labelTriggers.Name = "labelTriggers";
            this.labelTriggers.Size = new System.Drawing.Size(724, 19);
            this.labelTriggers.TabIndex = 7;
            this.labelTriggers.Text = "Triggers";
            // 
            // tpConstraints
            // 
            this.tpConstraints.Controls.Add(this.lvConstraints);
            this.tpConstraints.Controls.Add(this.label1);
            this.tpConstraints.Location = new System.Drawing.Point(4, 28);
            this.tpConstraints.Name = "tpConstraints";
            this.tpConstraints.Size = new System.Drawing.Size(724, 354);
            this.tpConstraints.TabIndex = 5;
            this.tpConstraints.Text = "Constraints";
            // 
            // lvConstraints
            // 
            this.lvConstraints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvConstraints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.lvConstraints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConstraints.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lvConstraints.FullRowSelect = true;
            this.lvConstraints.GridLines = true;
            this.lvConstraints.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvConstraints.Location = new System.Drawing.Point(0, 19);
            this.lvConstraints.MultiSelect = false;
            this.lvConstraints.Name = "lvConstraints";
            this.lvConstraints.Size = new System.Drawing.Size(724, 335);
            this.lvConstraints.TabIndex = 8;
            this.lvConstraints.UseCompatibleStateImageBehavior = false;
            this.lvConstraints.View = System.Windows.Forms.View.Details;
            this.lvConstraints.DoubleClick += new System.EventHandler(this.lvConstraints_DoubleClick);
            this.lvConstraints.Resize += new System.EventHandler(this.lvAll_Resize);
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Database 1";
            this.columnHeader21.Width = 200;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "State";
            this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Action";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Database 2";
            this.columnHeader24.Width = 200;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Constraints";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbLog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 459);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(990, 121);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.IntegralHeight = false;
            this.lbLog.ItemHeight = 17;
            this.lbLog.Location = new System.Drawing.Point(3, 20);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(984, 98);
            this.lbLog.TabIndex = 2;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itemFileExportResults,
            this.menuItem8,
            this.menuItem5});
            this.menuItem1.Text = "&File";
            // 
            // itemFileExportResults
            // 
            this.itemFileExportResults.Index = 0;
            this.itemFileExportResults.Text = "&Save Results...";
            this.itemFileExportResults.Click += new System.EventHandler(this.itemFileExportResults_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "E&xit";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 3;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itemHelpAbout,
            this.menuItem7,
            this.itemHelpHomePage});
            this.menuHelp.Text = "&Help";
            // 
            // itemHelpAbout
            // 
            this.itemHelpAbout.Index = 0;
            this.itemHelpAbout.Text = "&About...";
            this.itemHelpAbout.Click += new System.EventHandler(this.itemHelpAbout_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "-";
            // 
            // itemHelpHomePage
            // 
            this.itemHelpHomePage.Index = 2;
            this.itemHelpHomePage.Text = "Visit DaBCoS Homepage...";
            this.itemHelpHomePage.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // mmMain
            // 
            this.mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuInclude,
            this.menuCompare,
            this.menuHelp});
            // 
            // menuInclude
            // 
            this.menuInclude.Index = 1;
            this.menuInclude.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itemIncludeTables,
            this.itemIncludeFunctions,
            this.itemIncludeViews,
            this.itemIncludeProcs,
            this.itemIncludeTriggers,
            this.itemIncludeConstraints,
            this.menuItem9,
            this.itemIncludeAll,
            this.itemIncludeNone});
            this.menuInclude.Text = "&Include";
            // 
            // itemIncludeTables
            // 
            this.itemIncludeTables.Checked = true;
            this.itemIncludeTables.Index = 0;
            this.itemIncludeTables.Text = "&Tables";
            this.itemIncludeTables.Click += new System.EventHandler(this.itemIncludeMenu_Click);
            // 
            // itemIncludeFunctions
            // 
            this.itemIncludeFunctions.Checked = true;
            this.itemIncludeFunctions.Index = 1;
            this.itemIncludeFunctions.Text = "&Functions";
            this.itemIncludeFunctions.Click += new System.EventHandler(this.itemIncludeMenu_Click);
            // 
            // itemIncludeViews
            // 
            this.itemIncludeViews.Checked = true;
            this.itemIncludeViews.Index = 2;
            this.itemIncludeViews.Text = "&Views";
            this.itemIncludeViews.Click += new System.EventHandler(this.itemIncludeMenu_Click);
            // 
            // itemIncludeProcs
            // 
            this.itemIncludeProcs.Checked = true;
            this.itemIncludeProcs.Index = 3;
            this.itemIncludeProcs.Text = "&Stored Procs";
            this.itemIncludeProcs.Click += new System.EventHandler(this.itemIncludeMenu_Click);
            // 
            // itemIncludeTriggers
            // 
            this.itemIncludeTriggers.Checked = true;
            this.itemIncludeTriggers.Index = 4;
            this.itemIncludeTriggers.Text = "&Triggers";
            this.itemIncludeTriggers.Click += new System.EventHandler(this.itemIncludeMenu_Click);
            // 
            // itemIncludeConstraints
            // 
            this.itemIncludeConstraints.Checked = true;
            this.itemIncludeConstraints.Index = 5;
            this.itemIncludeConstraints.Text = "&Constraints";
            this.itemIncludeConstraints.Click += new System.EventHandler(this.itemIncludeMenu_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 6;
            this.menuItem9.Text = "-";
            // 
            // itemIncludeAll
            // 
            this.itemIncludeAll.Index = 7;
            this.itemIncludeAll.Text = "Select &All";
            this.itemIncludeAll.Click += new System.EventHandler(this.itemIncludeAll_Click);
            // 
            // itemIncludeNone
            // 
            this.itemIncludeNone.Index = 8;
            this.itemIncludeNone.Text = "&Unselect All";
            this.itemIncludeNone.Click += new System.EventHandler(this.itemIncludeNone_Click);
            // 
            // menuCompare
            // 
            this.menuCompare.Index = 2;
            this.menuCompare.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itemCompareStart});
            this.menuCompare.Text = "&Compare";
            // 
            // itemCompareStart
            // 
            this.itemCompareStart.Enabled = false;
            this.itemCompareStart.Index = 0;
            this.itemCompareStart.Text = "&Start compare";
            this.itemCompareStart.Click += new System.EventHandler(this.itemCompareStart_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.ClientSize = new System.Drawing.Size(990, 599);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.sbMain);
            this.Controls.Add(this.tbMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mmMain;
            this.MinimumSize = new System.Drawing.Size(1008, 644);
            this.Name = "FormMain";
            this.Text = "DaBCoS";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbpMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpProgress)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUser1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDB1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpTables.ResumeLayout(false);
            this.tpFunctions.ResumeLayout(false);
            this.tpViews.ResumeLayout(false);
            this.tpStoredProcs.ResumeLayout(false);
            this.tpTriggers.ResumeLayout(false);
            this.tpConstraints.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Instance Members

		private Engine.DatabaseDifferences _dbDifferences;

		private bool _includeConstraints = true;
		private bool _includeFunctions = true;
		private bool _includeStoredProcedures = true;
		private bool _includeTables = true;
		private bool _includeTriggers = true;
		private bool _includeViews = true;

		private SqlServer _databaseLeft;
		private SqlServer _databaseRight;

		#endregion Instance Members

		#region Constructor / Destructor

		public FormMain() 
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();						
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) 
		{
			if( disposing ) 
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion Constructor / Destructor

		#region Event Handlers

		private void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) 
		{
			if (e.Button == tbbConnect)	
			{ 
				ClearDisplay();
				ConnectSQLServer(_databaseLeft);
				if (_databaseLeft.Connected) ListDatabase(_databaseLeft);
			}
			if (e.Button == tbbConnect2) 
			{
				ClearDisplay();
				ConnectSQLServer(_databaseRight);			
				if (_databaseRight.Connected) ListDatabase(_databaseRight);
			}
			if (e.Button == tbbDisconnect) 
			{ 
				DisconnectSQLServer(_databaseLeft.Connection);
			}
			if (e.Button == tbbDisconnect2) 
			{
				DisconnectSQLServer(_databaseRight.Connection);
			}
			if (e.Button == tbbDatabase) 
			{
				ClearDisplay();
				ListDatabase(_databaseLeft);
			}
			if (e.Button == tbbDatabase2) 
			{
				ClearDisplay();
				ListDatabase(_databaseRight);
			}
			if (e.Button == tbbCompare)	
			{
				Compare();
			}
		}


		private void tmrCleanStatusBar_Tick(object sender, System.EventArgs e) 
		{
			sbpMessages.Text = null;
		}

		/// <summary>
		/// Handles Double-Click event on the Tables ListView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvTables_DoubleClick(object sender, System.EventArgs e) 
		{
			if (lvTables.SelectedItems != null) 
			{				
				ListViewItem lviDummy;
				string sLeftTable = lvTables.SelectedItems[0].SubItems[0].Text;
				string sRightTable = lvTables.SelectedItems[0].SubItems[3].Text;

				ArrayList alLeft = _databaseLeft.GetColumns(sLeftTable);
				ArrayList alRight = _databaseRight.GetColumns(sRightTable);

				wndDatabaseInfo = new FormDetail();
				wndDatabaseInfo.Text = String.Format("Details on table {0}", sLeftTable);
				wndDatabaseInfo.lvDetails.Columns[0].Text = String.Format("{0}.{1}..{2}", _databaseLeft.Connection.DataSource, _databaseLeft.Connection.Database, sLeftTable);
				wndDatabaseInfo.lvDetails.Columns[1].Text = String.Format("{0}.{1}..{2}", _databaseRight.Connection.DataSource, _databaseRight.Connection.Database, sRightTable);

				wndDatabaseInfo.tpSource1.Text = "not available";
				wndDatabaseInfo.tpSource2.Text = "not available";

				int iMaxCol = alLeft.Count;
				if (alRight.Count > iMaxCol) iMaxCol = alRight.Count;

				for (int i=0; i<iMaxCol; i++) 
				{
					if (i<alLeft.Count) 
					{
						lviDummy = new ListViewItem(alLeft[i].ToString());
					} 
					else 
					{
						lviDummy = new ListViewItem(string.Empty);
					}
					wndDatabaseInfo.lvDetails.Items.Add(lviDummy);
				}

				for (int i=0; i<iMaxCol; i++) 
				{				
					lviDummy = wndDatabaseInfo.lvDetails.Items[i];
					if (i<alRight.Count) 
					{
						lviDummy.SubItems.Add(alRight[i].ToString());
					} 
					else 
					{
						lviDummy.SubItems.Add(string.Empty);
					}
					if (lviDummy.SubItems[0].ToString() != lviDummy.SubItems[1].ToString()) 
					{
						lviDummy.BackColor = Color.Orange;
					}
				}

				wndDatabaseInfo.ShowDialog(this);
				wndDatabaseInfo.Dispose();
			}
		}


		/// <summary>
		/// Initialize Main Form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_Load(object sender, System.EventArgs e) 
		{
			Text = Application.ProductName + " v " + Application.ProductVersion;
			
			pbDB1.Image		= pbDB2.Image		= ilMisc.Images[0];
			pbUser1.Image	= pbUser2.Image		= ilMisc.Images[1];
			pbTable1.Image	= pbTable2.Image	= ilMisc.Images[2];

			Utils.ReadPersistentFormData(this);
			
			ResizeColumns(lvTables);
			ResizeColumns(lvViews);
			ResizeColumns(lvProcedures);
			ResizeColumns(lvFunctions);
			ResizeColumns(lvTriggers);

			_databaseLeft = new SqlServer();
			_databaseLeft.SetLogger(new DaBCoS.Engine.LogFunction(ShowInfoMessage));

			_databaseRight = new SqlServer();
			_databaseRight.SetLogger(new DaBCoS.Engine.LogFunction(ShowInfoMessage));

			ShowInfoMessage(Application.ProductName + " v " + Application.ProductVersion + " (c) 2002 " + Application.CompanyName);
			ShowInfoMessage("This application is released under the GNU GPL license.");
			//ShowInfoMessage("Visit http://sourceforge.net/projects/dabcos to have more info and support.");
		}

		/// <summary>
		/// Handles Double-Click event on the Views ListView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvViews_DoubleClick(object sender, System.EventArgs e) 
		{			
			if (lvViews.SelectedItems != null) 
			{								
				// Get view name
				string viewName = lvViews.SelectedItems[0].SubItems[0].Text;

				// Find the Difference object
				foreach(Difference diff in _dbDifferences.ViewDifferences)
				{
					if (diff.Name==viewName)
					{
						ShowSourceCode(diff);
						return;
					}
				}
			}				
		}
		
		private void lvProcedures_DoubleClick(object sender, System.EventArgs e) 
		{
			if (lvProcedures.SelectedItems != null) 
			{								
				// Get procedure name
				string procName = lvProcedures.SelectedItems[0].SubItems[0].Text;

				// Find the Difference object
				foreach(Difference diff in _dbDifferences.StoredProcDifferences)
				{
					if (diff.Name==procName)
					{
						ShowSourceCode(diff);
						return;
					}
				}
			}				
		}

		private void lvFunctions_DoubleClick(object sender, System.EventArgs e) 
		{
			if (lvFunctions.SelectedItems != null) 
			{								
				// Get the function name
				string functionName = lvFunctions.SelectedItems[0].SubItems[0].Text;

				// Find the Difference object
				foreach(Difference diff in _dbDifferences.FunctionDifferences)
				{
					if (diff.Name==functionName)
					{
						ShowSourceCode(diff);
						return;
					}
				}
			}				
		}

		private void lvConstraints_DoubleClick(object sender, System.EventArgs e) 
		{
			if (lvConstraints.SelectedItems != null) 
			{								
				// Get the function name
				string constraintName = lvConstraints.SelectedItems[0].SubItems[0].Text;

				// Find the Difference object
				foreach(Difference diff in _dbDifferences.ConstraintDifferences)
				{
					if (diff.Name==constraintName)
					{
						ShowSourceCode(diff);
						return;
					}
				}
			}				
		}

		private void lvTriggers_DoubleClick(object sender, System.EventArgs e)
		{
			if (lvTriggers.SelectedItems != null) 
			{								
				// Get the function name
				string triggerName = lvTriggers.SelectedItems[0].SubItems[0].Text;

				// Find the Difference object
				foreach(Difference diff in _dbDifferences.TriggerDifferences)
				{
					if (diff.Name==triggerName)
					{
						ShowSourceCode(diff);
						return;
					}
				}
			}				
		}

		private void lvAll_Resize(object sender, System.EventArgs e) 
		{
			ResizeColumns(sender as ListView);
		}

		private void sc_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e) 
		{
			string sConnectionName = "";
			SqlConnection scDummy;

			if (sender is SqlConnection) 
			{
				scDummy = (SqlConnection)sender; 
				if (scDummy == _databaseLeft.Connection) 
				{
					sConnectionName = "Source 1";
				} 
				else 
				{
					sConnectionName = "Source 2";
				}
			}
			
			ShowInfoMessage(String.Format("[{0}: " + e.Message + "].", sConnectionName));
		}

		private void sc_StateChange(object sender, System.Data.StateChangeEventArgs e) 
		{
			string sConnectionName = "";
			SqlConnection scDummy;

			if (sender is SqlConnection) 
			{
				scDummy = (SqlConnection)sender; 
				if (scDummy == _databaseLeft.Connection) 
				{
					sConnectionName = "Source 1";
				} 
				else 
				{
					sConnectionName = "Source 2";
				}
			}

			ShowInfoMessage(String.Format("[{0}: " + e.CurrentState.ToString() + "].", sConnectionName));
		}

		private void menuItem6_Click(object sender, System.EventArgs e) 
		{
			System.Diagnostics.Process.Start("http://www.davidemauri.it/dabcos");
		}

		private void menuItem5_Click(object sender, System.EventArgs e) 
		{
			Application.Exit();
		}

		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
		{
			Utils.WritePersistentFormData(this);
		}

		private void itemIncludeMenu_Click(object sender, System.EventArgs e)
		{
			// Switch the status
			System.Windows.Forms.MenuItem itemClicked = (System.Windows.Forms.MenuItem)sender;
			itemClicked.Checked = !itemClicked.Checked;
			// Set all included items
			SetIncludeStatus();
		}

		private void itemIncludeAll_Click(object sender, System.EventArgs e)
		{
			SetIncludeMenuItemsStatus(true);
		}

		private void itemIncludeNone_Click(object sender, System.EventArgs e)
		{
			SetIncludeMenuItemsStatus(false);
		}

		private void SetIncludeMenuItemsStatus(bool checkedStatus)
		{
			// Set the checked status for all include menu items
			itemIncludeConstraints.Checked = checkedStatus;
			itemIncludeFunctions.Checked = checkedStatus;
			itemIncludeProcs.Checked = checkedStatus;
			itemIncludeTables.Checked = checkedStatus;
			itemIncludeTriggers.Checked = checkedStatus;
			itemIncludeViews.Checked = checkedStatus;

			// Update the included vars
			SetIncludeStatus();
		}

		private void SetIncludeStatus()
		{
			_includeConstraints = itemIncludeConstraints.Checked;
			_includeStoredProcedures = itemIncludeProcs.Checked;
			_includeFunctions = itemIncludeFunctions.Checked;
			_includeTables = itemIncludeTables.Checked;
			_includeTriggers = itemIncludeTriggers.Checked;
			_includeViews = itemIncludeViews.Checked;
		}

		private void itemFileExportResults_Click(object sender, System.EventArgs e)
		{
			// Check that there is data to save
			if (_dbDifferences==null)
			{
				MessageBox.Show(this, "No results to save", "No Results To Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// Save the data
			string fileName = SelectSaveFile();
			if (fileName.Length!=0)
			{
				SaveResults(fileName);
			}
		}

		private void dbCompare_CompareSchemaStarted(object sender, CompareSchemaEventArgs e)
		{
			ShowInfoMessage("Starting schema comparison for " + e.DatabaseObjectType.ToString() + " objects...");
		}

		private void dbCompare_CompareSchemaFinished(object sender, Difference.DatabaseObjectType databaseObjectType)
		{
			ShowInfoMessage(databaseObjectType.ToString() + " comparison complete.");
		}

		private void itemHelpAbout_Click(object sender, System.EventArgs e)
		{
			wndAbout = new FormAbout();
			wndAbout.ShowDialog(this);
			wndAbout.Close();
			wndAbout.Dispose();
		}

		private void itemCompareStart_Click(object sender, System.EventArgs e)
		{
			Compare();
		}

		#endregion Event Handlers

		#region Methods

		/// <summary>
		/// Clear ListViews
		/// </summary>
		public void ClearDisplay() 
		{			
			foreach (TabPage tp in tcMain.TabPages) 
			{
				foreach (Object c in tp.Controls) 
				{
					if (c is ListView) 
					{
						(c as ListView).Items.Clear();
						(c as ListView).Update();
					}
				}
			}
		}

		private void ShowSourceCode(Difference difference)
		{
			Results dlg = new Results(difference);
			dlg.ShowDialog();
			dlg.Dispose();
		}

		private void ResetLists()
		{
			lvConstraints.Items.Clear();
			lvFunctions.Items.Clear();
			lvProcedures.Items.Clear();
			lvTables.Items.Clear();
			lvViews.Items.Clear();
			lvTriggers.Items.Clear();
		}

		private string SelectSaveFile()
		{
			string fileName = string.Empty;

			// Create the saveFileDialog object
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			// Set the appropriate properties
			saveFileDialog.CheckFileExists = true;
			saveFileDialog.Filter = "Xml Files | *.xml";
			saveFileDialog.DefaultExt = "xml";
			saveFileDialog.CheckFileExists = false;

			// Use the saveFileDialog and retrieve the path and name of the
			// selected package
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				fileName = saveFileDialog.FileName;
			}

			return fileName;

		}

		private void SaveResults(string fileName)
		{
			try
			{
				// Create a difference serializer and save
				DatabaseDifferences diffReport = new DatabaseDifferences(_dbDifferences.TableDifferences, _dbDifferences.ConstraintDifferences, _dbDifferences.ViewDifferences, _dbDifferences.StoredProcDifferences, _dbDifferences.FunctionDifferences, _dbDifferences.TriggerDifferences);
				diffReport.Save(fileName);
			}
			catch(Exception ex)
			{
				ShowInfoMessage("ERROR: " + ex.Message);	
			}
		}

		/// <summary>
		/// Resize the columns of ListView accordingly to the form size
		/// </summary>
		/// <param name="lvSource">ListView which has columns to be resized</param>
		private void ResizeColumns(ListView lvSource) 
		{
			// Make sure there are columns to resize
			if (lvSource.Columns.Count==0)
			{
				return;
			}

			int iTotWidth = lvSource.Width;
			
			lvSource.BeginUpdate();
			lvSource.Columns[0].Width = (iTotWidth * 40 / 100);
			lvSource.Columns[1].Width = (iTotWidth * 10 / 100);
			lvSource.Columns[2].Width = (iTotWidth * 10 / 100);
			lvSource.Columns[3].Width = (iTotWidth * 40 / 100);		
			lvSource.EndUpdate();			
		}

		/// <summary>
		/// Write a message to the status bar. The message will remain for 3 secs
		/// or until another message should appear
		/// </summary>
		/// <param name="sText">Message body</param>
		public void ShowInfoMessage(string sText) 
		{
			tmrCleanStatusBar.Stop();
			tmrCleanStatusBar.Interval = 3000;
			sbpMessages.Text = sText;			
			lbLog.SelectedIndex = lbLog.Items.Add(DateTime.Now.ToLongTimeString() + ": " + sText);			
			tmrCleanStatusBar.Start();		
		}


		/// <summary>
		/// Connect to SQL Server. 
		/// </summary>
		/// <remarks>A login window dialog will appear automatically</remarks>
		/// <returns></returns>
		private bool ConnectSQLServer(SqlServer dbTarget) 
		{
			bool bResult = false;

			try 
			{
				wndLoginInfo = new FormLogin();								
				if (wndLoginInfo.ShowDialog(this) == DialogResult.OK) 
				{
					wndLoginInfo.Hide();				
					this.Refresh();

					dbTarget.Server	= wndLoginInfo.Server;
					dbTarget.Login	= wndLoginInfo.Login;
					dbTarget.Password = wndLoginInfo.Password;
					dbTarget.AuthenticationType = wndLoginInfo.AuthMode;

					dbTarget.Connect();

					if (dbTarget.Connected) 
					{						
						UpdateToolbarButtons(dbTarget.Connection);
						if (dbTarget == _databaseLeft) 
						{
							lblServerFirst.Text = dbTarget.Server; 							
							lblUserFirst.Text = dbTarget.Login;
							lblDBFirst.Text = dbTarget.Connection.Database.ToString();
							lblSource1.Text = String.Format("Source 1: {0}", dbTarget.VersionName);
						} 
						else 
						{
							lblServerSecond.Text = dbTarget.Server; 
							lblUserSecond.Text = dbTarget.Login;
							lblDBSecond.Text = dbTarget.Connection.Database.ToString();
							lblSource2.Text = String.Format("Source 2: {0}", dbTarget.VersionName);
						}
						bResult = true;
					} 
					else 
					{
						UpdateToolbarButtons(dbTarget.Connection);
						ShowInfoMessage("Connection failed.");
					}
				} 
			}			
			catch (Exception eGeneral) 
			{
				UpdateToolbarButtons(dbTarget.Connection);
				ShowInfoMessage("Connection failed");
				MessageBox.Show(this, eGeneral.Message, "General error during connection", MessageBoxButtons.OK, MessageBoxIcon.Error);			
			} 
			finally 
			{
				wndLoginInfo.Dispose();
			}

			return bResult;
		}


		/// <summary>
		/// Disconnect from a SQL Server
		/// </summary>
		private void DisconnectSQLServer(SqlConnection scdbTarget) 
		{
			scdbTarget.Close();
			scdbTarget.ConnectionString = string.Empty;
			UpdateToolbarButtons(scdbTarget);
			ShowInfoMessage("Disconnected.");
		}


		/// <summary>
		/// Update the toolbar buttons
		/// </summary>
		/// <param name="scSource">SQL Connection to use to determine the buttons' state</param>
		private void UpdateToolbarButtons(SqlConnection scSource) 
		{
			bool bOpen = (scSource.State == ConnectionState.Open);

			if (scSource == _databaseLeft.Connection) 
			{
				tbbConnect.Enabled = !bOpen;
				tbbDisconnect.Enabled = bOpen;
				tbbDatabase.Enabled = bOpen;
			}

			if (scSource == _databaseRight.Connection) 
			{
				tbbConnect2.Enabled = !bOpen;
				tbbDisconnect2.Enabled = bOpen;
				tbbDatabase2.Enabled = bOpen;
			}

			tbbCompare.Enabled = (tbbDisconnect.Enabled & tbbDisconnect2.Enabled);
			itemCompareStart.Enabled = (tbbDisconnect.Enabled & tbbDisconnect2.Enabled);
		}


		/// <summary>
		/// List a let select a database
		/// </summary>
		/// <param name="scSource">Source connection</param>
		private void ListDatabase(SqlServer sdSource) 
		{			
			ShowInfoMessage(String.Format("Reading available databases on {0}...", sdSource.Connection.DataSource));
			
			if (sdSource.Connection.State != ConnectionState.Open) sdSource.Connection.Open();			
			try 
			{
				wndDatabaseSelection = new FormSelectDatabase(sdSource);			
						
				if (wndDatabaseSelection.ShowDialog(this) == DialogResult.OK) 
				{				
					ShowInfoMessage(string.Format("Selected database {0} on {1}.", sdSource.Connection.Database, sdSource.Connection.DataSource));				
					if (sdSource == _databaseLeft) 
					{
						lblDBFirst.Text = sdSource.Connection.Database.ToString(); 
						foreach (TabPage tp in tcMain.TabPages) 
						{
							foreach (Object c in tp.Controls) 
							{
								if (c is ListView) 
								{
									(c as ListView).Columns[0].Text = sdSource.Connection.Database.ToString();
								}
							}
						}
					} 
					else 
					{
						lblDBSecond.Text = sdSource.Connection.Database.ToString(); 
						foreach (TabPage tp in tcMain.TabPages) 
						{
							foreach (Object c in tp.Controls) 
							{
								if (c is ListView) 
								{
									(c as ListView).Columns[3].Text = sdSource.Connection.Database.ToString();
								}
							}
						}
					}
				} 
				else 
				{
					ShowInfoMessage("Action cancelled.");					
				}
			} 
			finally 
			{
				if (wndDatabaseSelection != null)
					wndDatabaseSelection.Dispose();
			}
		}

		/// <summary>
		/// Compare two databases and show the differences
		/// </summary>
		private void Compare() 
		{								
			string infoMessage = string.Empty;

			ClearDisplay();
			
			_dbDifferences = new DatabaseDifferences ();
			Engine.Compare dbCompare = new Compare();
			dbCompare.CompareSchemaStarted+=new DaBCoS.Engine.Compare.CompareSchemaStartedDelegate(this.dbCompare_CompareSchemaStarted);
			dbCompare.CompareSchemaFinished+=new DaBCoS.Engine.Compare.CompareSchemaFinishedDelegate(this.dbCompare_CompareSchemaFinished);

			ShowInfoMessage("Starting compare...");	
			
			ResetLists();

			// Get the constraint differences
			if (_includeConstraints)
			{
				_dbDifferences.ConstraintDifferences = dbCompare.CompareSchemaObjects(_databaseLeft, _databaseRight, Difference.DatabaseObjectType.Constraint);
				ShowDifferences(lvConstraints, _dbDifferences.ConstraintDifferences);
				infoMessage += "Constraints (" + (_dbDifferences.ConstraintDifferences.Count-_dbDifferences.ConstraintDifferences.CountByOutcome(Difference.DifferenceOutcome.Same)).ToString() + " of " + _dbDifferences.ConstraintDifferences.Count.ToString() + " diff)";
			}

			// Get the table differences
			if (_includeTables)
			{
				_dbDifferences.TableDifferences = dbCompare.CompareTables(_databaseLeft, _databaseRight);
				ShowDifferences(lvTables, _dbDifferences.TableDifferences);
				infoMessage += "Tables (" + (_dbDifferences.TableDifferences.Count-_dbDifferences.TableDifferences.CountByOutcome(Difference.DifferenceOutcome.Same)).ToString() + " of " + _dbDifferences.TableDifferences.Count.ToString() + " diff)";
			}

			// Get the stored proc differences
			if (_includeStoredProcedures)
			{
				_dbDifferences.StoredProcDifferences = dbCompare.CompareSchemaObjects(_databaseLeft, _databaseRight, Difference.DatabaseObjectType.StoredProcedure);
				ShowDifferences(lvProcedures, _dbDifferences.StoredProcDifferences);
				infoMessage += " Procs (" + (_dbDifferences.StoredProcDifferences.Count-_dbDifferences.StoredProcDifferences.CountByOutcome(Difference.DifferenceOutcome.Same)).ToString() + " of " + _dbDifferences.StoredProcDifferences.Count.ToString() + " diff)";
			}

			// Get the function differences
			if (_includeFunctions)
			{
				_dbDifferences.FunctionDifferences = dbCompare.CompareSchemaObjects(_databaseLeft, _databaseRight, Difference.DatabaseObjectType.Function);
				ShowDifferences(lvFunctions, _dbDifferences.FunctionDifferences);
				infoMessage += " Functions (" + (_dbDifferences.FunctionDifferences.Count-_dbDifferences.FunctionDifferences.CountByOutcome(Difference.DifferenceOutcome.Same)).ToString() + " of " + _dbDifferences.FunctionDifferences.Count.ToString() + " diff)";
			}
			
			// Get the view differences
			if (_includeViews)
			{
				_dbDifferences.ViewDifferences = dbCompare.CompareSchemaObjects(_databaseLeft, _databaseRight, Difference.DatabaseObjectType.View);
				ShowDifferences(lvViews, _dbDifferences.ViewDifferences);
				infoMessage += " Views (" + (_dbDifferences.ViewDifferences.Count-_dbDifferences.ViewDifferences.CountByOutcome(Difference.DifferenceOutcome.Same)).ToString() + " of " + _dbDifferences.ViewDifferences.Count.ToString() + " diff)";
			}

			// Get the trigger differences
			if (_includeTriggers)
			{
				_dbDifferences.TriggerDifferences = dbCompare.CompareSchemaObjects(_databaseLeft, _databaseRight, Difference.DatabaseObjectType.Trigger);
				ShowDifferences(lvTriggers, _dbDifferences.TriggerDifferences);
				infoMessage += " Triggers (" + (_dbDifferences.TriggerDifferences.Count-_dbDifferences.TriggerDifferences.CountByOutcome(Difference.DifferenceOutcome.Same)).ToString() + " of " + _dbDifferences.TriggerDifferences.Count.ToString() + " diff)";
			}

			infoMessage = "Complete: " + infoMessage;
			ShowInfoMessage(infoMessage);	
			pbState.Value = 0;
		}

		private void ShowDifferences(ListView list, Engine.DifferenceCollection differences)
		{
			ListViewItem lviDummy;

			// Check if any differences
			if (differences.Count==0)
			{
				return;
			}

			// Loop through the table differences
			list.BeginUpdate();
			foreach(Difference difference in differences)
			{
				lviDummy = new ListViewItem(difference.Name);
				if (difference.Outcome!=Difference.DifferenceOutcome.Same)
				{
					lviDummy.BackColor = Color.Orange;
					if (difference.IsLeftDifferent)
					{
						// Left table different
						lviDummy.SubItems.Add(">");
						lviDummy.SubItems.Add("?");
						lviDummy.SubItems.Add(difference.Name);
					}
					else
					{
						// Right table different
						lviDummy.SubItems.Add("<");
						lviDummy.SubItems.Add("?");
						lviDummy.SubItems.Add(difference.Name);
					}
				}
				else
				{
					// Table the same
					lviDummy.SubItems.Add("=");
					lviDummy.SubItems.Add("=");
					lviDummy.SubItems.Add(difference.Name);
				}
				// Add the item
				list.Items.Add(lviDummy);
			}
			list.EndUpdate();
		}

		#endregion Methods

	}
}
