using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DaBCoS
{
	/// <summary>
	/// Summary description for frmDatabaseInfo.
	/// </summary>
	public class FormDetail : System.Windows.Forms.Form
	{
        public System.Windows.Forms.ListView lvDetails;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.RichTextBox rtbSource1;
		public System.Windows.Forms.RichTextBox rtbSource2;
		public System.Windows.Forms.TabControl tcSource;
		private System.Windows.Forms.TabPage tpBoth;
		public System.Windows.Forms.TabPage tpSource1;
		public System.Windows.Forms.TabPage tpSource2;
        public RichTextBox richTextBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormDetail()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tcSource = new System.Windows.Forms.TabControl();
            this.tpBoth = new System.Windows.Forms.TabPage();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpSource1 = new System.Windows.Forms.TabPage();
            this.rtbSource1 = new System.Windows.Forms.RichTextBox();
            this.tpSource2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rtbSource2 = new System.Windows.Forms.RichTextBox();
            this.tcSource.SuspendLayout();
            this.tpBoth.SuspendLayout();
            this.tpSource1.SuspendLayout();
            this.tpSource2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSource
            // 
            this.tcSource.Controls.Add(this.tpBoth);
            this.tcSource.Controls.Add(this.tpSource1);
            this.tcSource.Controls.Add(this.tpSource2);
            this.tcSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSource.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcSource.Location = new System.Drawing.Point(0, 0);
            this.tcSource.Name = "tcSource";
            this.tcSource.SelectedIndex = 0;
            this.tcSource.Size = new System.Drawing.Size(712, 376);
            this.tcSource.TabIndex = 1;
            // 
            // tpBoth
            // 
            this.tpBoth.Controls.Add(this.lvDetails);
            this.tpBoth.Location = new System.Drawing.Point(4, 26);
            this.tpBoth.Name = "tpBoth";
            this.tpBoth.Size = new System.Drawing.Size(704, 346);
            this.tpBoth.TabIndex = 0;
            this.tpBoth.Text = "Both";
            // 
            // lvDetails
            // 
            this.lvDetails.AllowDrop = true;
            this.lvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetails.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDetails.FullRowSelect = true;
            this.lvDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDetails.Location = new System.Drawing.Point(0, 0);
            this.lvDetails.MultiSelect = false;
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(704, 346);
            this.lvDetails.TabIndex = 1;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.View = System.Windows.Forms.View.Details;
            this.lvDetails.Resize += new System.EventHandler(this.lvDetails_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Database 1";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Database 2";
            this.columnHeader2.Width = 200;
            // 
            // tpSource1
            // 
            this.tpSource1.Controls.Add(this.rtbSource1);
            this.tpSource1.Location = new System.Drawing.Point(4, 26);
            this.tpSource1.Name = "tpSource1";
            this.tpSource1.Size = new System.Drawing.Size(704, 346);
            this.tpSource1.TabIndex = 1;
            this.tpSource1.Text = "Database 1";
            // 
            // rtbSource1
            // 
            this.rtbSource1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSource1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSource1.Location = new System.Drawing.Point(0, 0);
            this.rtbSource1.Name = "rtbSource1";
            this.rtbSource1.ReadOnly = true;
            this.rtbSource1.Size = new System.Drawing.Size(704, 346);
            this.rtbSource1.TabIndex = 3;
            this.rtbSource1.Text = "";
            this.rtbSource1.WordWrap = false;
            // 
            // tpSource2
            // 
            this.tpSource2.Controls.Add(this.richTextBox1);
            this.tpSource2.Controls.Add(this.rtbSource2);
            this.tpSource2.Location = new System.Drawing.Point(4, 26);
            this.tpSource2.Name = "tpSource2";
            this.tpSource2.Size = new System.Drawing.Size(704, 346);
            this.tpSource2.TabIndex = 2;
            this.tpSource2.Text = "Database 2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(704, 346);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // rtbSource2
            // 
            this.rtbSource2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSource2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSource2.Location = new System.Drawing.Point(0, 0);
            this.rtbSource2.Name = "rtbSource2";
            this.rtbSource2.ReadOnly = true;
            this.rtbSource2.Size = new System.Drawing.Size(704, 346);
            this.rtbSource2.TabIndex = 4;
            this.rtbSource2.Text = "rrrrrrr";
            this.rtbSource2.WordWrap = false;
            // 
            // FormDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.ClientSize = new System.Drawing.Size(712, 376);
            this.Controls.Add(this.tcSource);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FormDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details";
            this.Load += new System.EventHandler(this.frmDatabaseInfo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormDetail_KeyPress);
            this.tcSource.ResumeLayout(false);
            this.tpBoth.ResumeLayout(false);
            this.tpSource1.ResumeLayout(false);
            this.tpSource2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void lvDetails_SizeChanged(object sender, System.EventArgs e) {		
			ResizeColumns(lvDetails);
		}

		private void ResizeColumns(ListView lvSource) {
			int iTotWidth = lvSource.Width;
			
			lvSource.BeginUpdate();
			lvDetails.Columns[0].Width = lvDetails.Width / 2;
			lvDetails.Columns[1].Width = lvDetails.Width / 2;
			lvSource.EndUpdate();
			lvSource.Update();
		}

		private void frmDatabaseInfo_Load(object sender, System.EventArgs e) {
			ResizeColumns(lvDetails);
		}

		private void lvDetails_Resize(object sender, System.EventArgs e) {
			ResizeColumns(lvDetails);
		}

		private void FormDetail_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case (char)27:
					this.Close();
					break;
			}
		}
	}
}
