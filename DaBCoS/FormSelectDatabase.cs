using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DaBCoS.Engine;

namespace DaBCoS {
	/// <summary>
	/// Select the database context
	/// </summary>
	public class FormSelectDatabase : System.Windows.Forms.Form {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		public System.Windows.Forms.ListBox lbDatabase;

		private SqlServer sdSource;
		private string sOldDatabase;

		public FormSelectDatabase(SqlServer sdSource) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Get Data Connection and Database Context
			this.sdSource = sdSource;
			if (this.sdSource.Connection.State != ConnectionState.Open) throw new Exception("Database connection not yet opened.");
			sOldDatabase = this.sdSource.Connection.Database;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lbDatabase = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(224, 264);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Enabled = false;
			this.btnOk.Location = new System.Drawing.Point(144, 264);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "&OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lbDatabase
			// 
			this.lbDatabase.Location = new System.Drawing.Point(0, 0);
			this.lbDatabase.Name = "lbDatabase";
			this.lbDatabase.Size = new System.Drawing.Size(304, 251);
			this.lbDatabase.TabIndex = 3;
			this.lbDatabase.DoubleClick += new System.EventHandler(this.lbDatabase_DoubleClick);
			this.lbDatabase.SelectedIndexChanged += new System.EventHandler(this.lbDatabase_SelectedIndexChanged);
			// 
			// FormSelectDatabase
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(304, 293);
			this.Controls.Add(this.lbDatabase);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormSelectDatabase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Database";
			this.Load += new System.EventHandler(this.FormSelectDatabase_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void lbDatabase_SelectedIndexChanged(object sender, System.EventArgs e) {
			btnOk.Enabled = true;
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
			ChangeDatabase(lbDatabase.SelectedItem.ToString());
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			ChangeDatabase(sOldDatabase);
		}

		private void FormSelectDatabase_Load(object sender, System.EventArgs e) {
			lbDatabase.Items.AddRange(sdSource.GetDatabases().ToArray());
		}

		private void lbDatabase_DoubleClick(object sender, System.EventArgs e)
		{
			if (ChangeDatabase(lbDatabase.SelectedItem.ToString()))
			{
				this.DialogResult=DialogResult.OK;
				this.Close();
			}
		}

		private bool ChangeDatabase(string databaseName)
		{
			try
			{
				sdSource.Connection.ChangeDatabase(databaseName);
				return true;
			}
			catch(SqlException ex)
			{
				MessageBox.Show(this, "Could not set database to `" + databaseName + "`. Error is: " + ex.Message);
				return false;
			}
		}
	}
}
