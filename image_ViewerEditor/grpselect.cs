/*
 * Created by SharpDevelop.
 * User: Jyotipriyar
 * Date: 29-06-2017
 * Time: 18:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace image_ViewerEditor
{
	/// <summary>
	/// Description of grpselect.
	/// </summary>
	///
	public partial class grpselect : Form
	{
		
		int i=0,j=0;
		List<string> list=new List<string>();
		List<Tuple<string,int>> list1=new List<Tuple<string,int>>();
		List<Tuple<string,List<string>>> inlist=new List<Tuple<string,List<string>>>();
		public grpselect()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
				
		}
		
		void selct(List<string> lst){
			foreach (string aa in lst) {
				cmdname.Items.Add(aa);
			}
		}
		void SendtolistviewClick(object sender, EventArgs e)
		{
			//if(cmdname.SelectedItems[0].ToString()==true){
				grplist.Items.Add(cmdname.SelectedItems[i].ToString());
				i++;
			//}
		}
		void SavegrpClick(object sender, EventArgs e)
		{
			//inlist.Add(grptxt.Text,list);
			inlist.Add(new Tuple<string,List<string>>(grptxt.Text, list));
			list1.Add(new Tuple<string, int>( grptxt.Text,j));
			j++;
			grplist.Clear();
		}
		void CancelgrpClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		
	}
}
