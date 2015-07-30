using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace DaBCoS
{
	/// <summary>
	/// Summary description for FormAbout.
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAbout()
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
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(8, 160);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(288, 16);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Visit DaBCoS Homepage";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 56);
			this.label1.TabIndex = 2;
			this.label1.Text = "The purpose of this project is to create an application that allows dbas and deve" +
				"lopers to compare and synchronize the structure of two SQL Server databases. ";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "DaBCoS";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(176, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Database Compare && Synchronize";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(280, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "(c) Davide Mauri && Gavin McKay 2002/2005";
			// 
			// linkLabel2
			// 
			this.linkLabel2.Location = new System.Drawing.Point(8, 176);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(288, 16);
			this.linkLabel2.TabIndex = 6;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Visit SourceForge Project Page (Support and download)";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(112, 200);
			this.button1.Name = "button1";
			this.button1.TabIndex = 7;
			this.button1.Text = "Close";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(298, 226);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.linkLabel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.ResumeLayout(false);

		}
		#endregion

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("http://www.davidemauri.it/dabcos");
		}

		private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("http://www.sourceforge.net/projects/dabcos");
		}

		private void button1_Click(object sender, System.EventArgs e) {
			Close();
		}
	}
}
