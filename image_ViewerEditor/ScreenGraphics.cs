/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 10/03/2017
 * Time: 1:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BLRO
{
	/// <summary>
	/// Description of ScreenGraphics.
	/// </summary>
	public class ScreenGraphics
	{
		//public ImageOrientation Orientation {get; private set;}
		
		public static Point GetScreenDimension() {
			return new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
		}
		public static double GetRatio() {
			Point rt = GetScreenDimension();
			return ComputeRatio(rt.X, rt.Y);
		}
		public static double ComputeRatio(int x, int y) {
			return Convert.ToDouble(x)/Convert.ToDouble(y);
		}
		public static ImageOrientation GetOrientation() {
			return GetRatio() < 1 ? ImageOrientation.Portrait : ImageOrientation.Landscape;
		}
		public static Point Scale(Point pt, double factor) {
			return new Point(Convert.ToInt32(pt.X*factor), Convert.ToInt32(pt.Y*factor));
		}
		public static Point GetMaxScaleWithAspectRatio(int width, int height, Point scRt) {
			//double imgRatio = ComputeRatio(width, height);
			double rat_scr_to_img_width = ComputeRatio(scRt.X, width);
			double rat_scr_to_img_height = ComputeRatio(scRt.Y, height);
			Point dimension = new Point(width, height);
			if (dimension.X > scRt.X) {
				dimension = Scale(dimension, ComputeRatio(scRt.X, dimension.X));
			}
			if (dimension.Y > scRt.Y) {
				dimension = Scale(dimension, ComputeRatio(scRt.Y, dimension.Y));
			}
			return dimension;
		}
		public static Point GetMaxScreenSize(int width, int height) {
			//double imgRatio = ComputeRatio(width, height);
			Point scRt = new Point(GetScreenDimension().X, GetScreenDimension().Y);
			return GetMaxScaleWithAspectRatio(width, height, scRt);
		}
		
		//Constants
		public static string STORAGE_FOLDER = "/";
		//End: Constants
		
		public ScreenGraphics()
		{
		}
	}
}
