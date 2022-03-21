/*
 * Created by SharpDevelop.
 * User: arpanp
 * Date: 08/06/2017
 * Time: 03:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using BLRO;

namespace image_ViewerEditor
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new MainForm());
		//	Application.Run(new frm_enhance("D:\\Jyoti\\New folder\\Split\\00000004_0.jpg"));
			Application.Run(new frm_enhance());
		//Application.Run(new frm_enhance("D:\\Jyoti\\AutoSave\\CATALOGUE_OF_MEDALS_00001.jpg"));
		}
		
	}
}
