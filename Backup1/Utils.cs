using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;
using System.IO;

/// <summary>
/// DataBase Compare & Synchronize
/// </summary>
namespace DaBCoS {	
	/// <summary>
	/// Utilities container
	/// </summary>
	public class Utils {
		/// <summary>
		/// Remove from text any invisible character and any space
		/// </summary>
		/// <param name="sCode">Code fragment to purge</param>
		/// <returns>Purged string</returns>
		static internal string PureText(string sCode) {
			sCode = sCode.Replace("\r", string.Empty);
			sCode = sCode.Replace("\n", string.Empty);
			sCode = sCode.Replace("\t", string.Empty);
			sCode = sCode.Replace(" ", string.Empty);

			return sCode;
		}		

		/// <summary>
		/// Compare two ArrayList to check if they contains the same values
		/// and thus are equivalent
		/// </summary>
		/// <param name="alFirst">First ArrayList to compare</param>
		/// <param name="alSecond">Second ArrayList to compare</param>
		/// <returns>true or false</returns>
		static internal bool ListAreEqual(ArrayList alFirst, ArrayList alSecond) {
			if (alFirst.Count != alSecond.Count) return false;

			bool bResult = true;
			for(int i=0; i<alFirst.Count; i++) {
				bResult &= (alFirst[i].ToString() == alSecond[i].ToString()); 
			}

			return bResult;
		}
		
		/// <summary>
		/// Make form display data (Size, Position, and WindowState) persistent
		/// </summary>
		/// <param name="form">Form to be set persistent</param>
		static internal void WritePersistentFormData(System.Windows.Forms.Form form) {
			try {
				XmlTextWriter xmlWriter = new XmlTextWriter(Application.ExecutablePath + ".formdata.xml", Encoding.UTF8);
				xmlWriter.Formatting = Formatting.Indented;				
				try {
					xmlWriter.WriteStartDocument();
					xmlWriter.WriteStartElement("Forms");
					xmlWriter.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
					xmlWriter.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
					xmlWriter.WriteStartElement(form.Name);
					xmlWriter.WriteStartElement("PersistentData");			
					xmlWriter.WriteAttributeString("WindowState",	form.WindowState.ToString());
					if (form.WindowState == FormWindowState.Normal) {
						xmlWriter.WriteAttributeString("Top",			form.Top.ToString());
						xmlWriter.WriteAttributeString("Left",			form.Left.ToString());
						xmlWriter.WriteAttributeString("Width",			form.Width.ToString());
						xmlWriter.WriteAttributeString("Height",		form.Height.ToString());
					}
					xmlWriter.WriteEndDocument();
				}
				catch (Exception ex2) {
					MessageBox.Show (ex2.Message);
				}
				finally {
					xmlWriter.Close();
				}
			}
			catch (Exception ex1) {
				MessageBox.Show (ex1.Message);
			}
		}

		/// <summary>
		/// Read and apply persistent form display data (Size, Position, and WindowState)
		/// </summary>
		/// <param name="form">Form to be set</param>
		static internal void ReadPersistentFormData(System.Windows.Forms.Form form) {
			try {
				StreamReader reader = new StreamReader(Application.ExecutablePath + ".formdata.xml", Encoding.UTF8);								
				XPathDocument doc = new XPathDocument(reader);
				XPathNavigator nav = doc.CreateNavigator();				
				try {
					XPathNodeIterator iterator = nav.Select(String.Format("//Forms/{0}/PersistentData", form.Name));					
					iterator.MoveNext();					
					form.WindowState = (FormWindowState)Enum.Parse(form.WindowState.GetType(), iterator.Current.GetAttribute("WindowState",	""), false);
					if (form.WindowState == FormWindowState.Normal) {
						form.Top	= Convert.ToInt16(iterator.Current.GetAttribute("Top",		"").ToString());
						form.Left	= Convert.ToInt16(iterator.Current.GetAttribute("Left",		"").ToString());
						form.Width	= Convert.ToInt16(iterator.Current.GetAttribute("Width",	"").ToString());
						form.Height	= Convert.ToInt16(iterator.Current.GetAttribute("Height",	"").ToString());
					}
				}
				catch {
				}
				finally {
					reader.Close();					
				}
			}
			catch {
			}
		}
	}
}
