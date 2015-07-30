using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using DaBCoS.Engine;

namespace DaBCoS
{
	
	/// <summary>
	/// Summary description for frmLoginInfo.
	/// </summary>
	public class FormLogin : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.RadioButton rbAuthSQL;
		private System.Windows.Forms.RadioButton rbAuthNT;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ComboBox cbServer;
		
		private string sConnectionsFile = Application.StartupPath + @"\SqlLogins.xml";

		public string Server {
			get {
				return cbServer.Text;
			}
		}

		public string Login {
			get {
				return txtLogin.Text;
			}
		}

		public string Password {
			get {
				return txtPassword.Text;
			}
		}

		public SqlAuthentication AuthMode {
			get {
				if (rbAuthNT.Checked) return SqlAuthentication.NT;
				else return SqlAuthentication.SQLSever;
			}
		}

		public FormLogin()
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
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.rbAuthSQL = new System.Windows.Forms.RadioButton();
            this.rbAuthNT = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(123, 97);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(258, 24);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            this.txtLogin.Enter += new System.EventHandler(this.txtLogin_Enter);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(123, 136);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(258, 24);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // rbAuthSQL
            // 
            this.rbAuthSQL.Location = new System.Drawing.Point(11, 68);
            this.rbAuthSQL.Name = "rbAuthSQL";
            this.rbAuthSQL.Size = new System.Drawing.Size(179, 29);
            this.rbAuthSQL.TabIndex = 1;
            this.rbAuthSQL.Text = "SQL Authentication";
            // 
            // rbAuthNT
            // 
            this.rbAuthNT.Checked = true;
            this.rbAuthNT.Location = new System.Drawing.Point(11, 175);
            this.rbAuthNT.Name = "rbAuthNT";
            this.rbAuthNT.Size = new System.Drawing.Size(201, 29);
            this.rbAuthNT.TabIndex = 4;
            this.rbAuthNT.TabStop = true;
            this.rbAuthNT.Text = "Windows authentication";
            this.rbAuthNT.CheckedChanged += new System.EventHandler(this.rbAuthNT_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(34, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(224, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(78, 214);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 28);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            // 
            // cbServer
            // 
            this.cbServer.Location = new System.Drawing.Point(34, 29);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(347, 25);
            this.cbServer.TabIndex = 7;
            this.cbServer.SelectedIndexChanged += new System.EventHandler(this.cbServer_SelectedIndexChanged);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(422, 207);
            this.Controls.Add(this.cbServer);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbAuthNT);
            this.Controls.Add(this.rbAuthSQL);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login Info";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLoginInfo_Closing);
            this.Load += new System.EventHandler(this.frmLoginInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmLoginInfo_Load(object sender, System.EventArgs e) {
			/*
			 * Deserialize Logins
			 */
			FileStream fsXML = null;
			try {
				fsXML = new FileStream(sConnectionsFile, FileMode.Open);			
			
				((FormMain)this.Owner).ShowInfoMessage("Deserializing connection preferences...");

				XmlSerializer xsLogins = new XmlSerializer(typeof(SqlLoginPool));

				SqlLoginPool slpLogins = (SqlLoginPool)xsLogins.Deserialize(fsXML);
				foreach(SqlLogin slItem in slpLogins.LoginPool) {
					if (slItem != null) {
						cbServer.Items.Add(slItem);
						if (slItem.IsLastUsed) {
							cbServer.SelectedItem = slItem;
						}
						slItem.IsLastUsed = false;
					}
				}
			} 
			catch (FileNotFoundException) {
				((FormMain)this.Owner).ShowInfoMessage("Nothing to deserialize.");
			}
			finally {			
				if (fsXML != null) fsXML.Close();
			}

			cbServer_SelectedIndexChanged(null, null);
		}

		private void frmLoginInfo_Closing(object sender, System.ComponentModel.CancelEventArgs e) {			
			/*
			 * Serialize Logins
			 */
			if (this.DialogResult == DialogResult.OK) {
				TextWriter twXML = new StreamWriter(sConnectionsFile);
			
				((FormMain)this.Owner).ShowInfoMessage("Serializing connection preferences...");

				SqlLogin slLastConnection = new SqlLogin();
				slLastConnection.Address	= cbServer.Text;
				slLastConnection.Login		= txtLogin.Text;			
				slLastConnection.IsLastUsed = true;

				if (!cbServer.Items.Contains(slLastConnection)) {
					cbServer.Items.Insert(0, slLastConnection);
				} else {
					SqlLogin slFound;
					slFound = cbServer.Items[cbServer.Items.IndexOf(slLastConnection)] as SqlLogin;
					slFound.IsLastUsed = true;
				}

				while (cbServer.Items.Count > SqlLoginPool.MAXLOGINS) {
					cbServer.Items.RemoveAt(cbServer.Items.Count-1);
				}

				SqlLoginPool slpLogins = new SqlLoginPool();				
				cbServer.Items.CopyTo(slpLogins.LoginPool, 0);

				XmlSerializer xsLogins = new XmlSerializer(typeof(SqlLoginPool));
				xsLogins.Serialize(twXML, slpLogins);

				twXML.Close();
			}
		}

		private void cbServer_SelectedIndexChanged(object sender, System.EventArgs e) {
			string sLogin = string.Empty;

			if (cbServer.SelectedItem != null) 
				sLogin = ((SqlLogin)cbServer.SelectedItem).Login;

			if (sLogin == string.Empty) {
				rbAuthNT.Checked = true;
				txtLogin.Clear();
				txtPassword.Clear();
				rbAuthNT.Focus();
			} else {
				rbAuthSQL.Checked = true;
				txtLogin.Text = sLogin;
				txtPassword.Clear();
				rbAuthSQL.Focus();
			}
		}

		private void txtLogin_Enter(object sender, System.EventArgs e) {
			
		}

		private void txtPassword_Enter(object sender, System.EventArgs e) {
			
		}

		private void rbAuthNT_CheckedChanged(object sender, System.EventArgs e) {
			if (rbAuthNT.Checked) {
				txtLogin.Text		= string.Empty;
				txtPassword.Text	= string.Empty;			
			}
		}

		private void txtLogin_TextChanged(object sender, System.EventArgs e) {
			if (txtLogin.Text != string.Empty) rbAuthSQL.Checked = true;
		}

		private void txtPassword_TextChanged(object sender, System.EventArgs e) {
			if (txtLogin.Text != string.Empty) rbAuthSQL.Checked = true;
		}
	}
    /// <summary>
    /// SQL Server Login class
    /// </summary>
    public class SqlLogin
    {
        public string Address;
        public string Login;
        public bool IsLastUsed;

        /// <summary>
        /// Implementation of ToString
        /// </summary>
        /// <returns>The address of the SQL Server database that this login will connect to</returns>
        override public string ToString()
        {
            return Address;
        }

        /// <summary>
        /// Implementation of GetHashCode
        /// </summary>
        /// <returns>Return the hash code for the login</returns>
        override public int GetHashCode()
        {
            return (Address.GetHashCode() | Login.GetHashCode());
        }

        /// <summary>
        /// Implementation of Equals
        /// </summary>
        /// <param name="obj">Object to compare for equality</param>
        /// <returns></returns>
        override public bool Equals(object obj)
        {
            SqlLogin sl = obj as SqlLogin;
            if (sl == null) return false;
            if ((sl.Address == Address) && (sl.Login == Login)) return true;
            return false;
        }
    }

    /// <summary>
    /// This class contains all the logins used in a session.
    /// This class is also serialized so that login can be reloaded next time	
    /// </summary>
    [XmlRootAttribute("SqlLoginPool")]
    public class SqlLoginPool
    {
        /// <summary>
        /// Maximum number of logins serialized.
        /// </summary>
        public const int MAXLOGINS = 4;

        public SqlLoginPool()
        {
            LoginPool = new SqlLogin[MAXLOGINS];
        }

        /// <summary>
        /// Array of logins
        /// </summary>
        [XmlArrayItem("SqlLogin", typeof(SqlLogin))]
        public SqlLogin[] LoginPool;
    }

}
