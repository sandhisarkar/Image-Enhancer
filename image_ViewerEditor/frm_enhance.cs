/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 10/03/2017
 * Time: 12:59 PM
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Linq;
using NovaNet.Utils;
using System.Windows.Media.Imaging;
using BitMiracle.LibTiff.Classic;
using TiffManager;
using GotoShowHelp;
using testlist;
using System.Reflection;
//using CustomCodeAttributes;
using ImgCacher;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;


namespace BLRO
{
	/// <summary>
	/// Description of frm_enhance.
	/// </summary>
	
	public partial class frm_enhance : Form
	{
		ImgCache imc;
		ImgProcessor imf;
		const int padding=20;
		const int leftPanel=130;
		//Point StartingPoint;
		bool drawing;
		Bitmap orig,org1;
		//string Id=null;
		string image_Path;
		const int STEP_COUNT = 2;
		//Action<Bitmap, string> CallBack=null;
		decimal lastBrightness;
		decimal lastContrast;
		//float lastSaturation;
		bool bDrawing = false;
		private int[] mask = new int[20];
		Rectangle topRect = new Rectangle(0,0,0,0);
		//Point lastPos;      // mouse-down position
		Point startPos;      // mouse-down position
		Point currentPos;    // current mouse position
		List<string> img_FullPath = new List<string>();
		List<string> img_FullPath1 = new List<string>();
		int x0=0,y0=0,j=0;
		Int16 var=0;
		tm x=null;
		private string IsSelecting = null;
		Bitmap bmp;
		PixelFormat pfmt;
		private string StoragePath = string.Empty;
		private string StorageFile = string.Empty;
		int count=0;
		string targetPath = null;
		
		int c=0;
		string s=null;
		List<string> lst=new List<string>();
		Rectangle frame = new Rectangle(0,0,0,0);
		ImageCodecInfo myImageCodecInfo;
		EncoderParameters myEncoderParameters;
		DtImgCache dt;
		int currentIndex ;
		
		GotoShow gs;
		Bitmap retVal=null;
		string configpath=null;
		
		Dictionary<string, Dictionary<string,List<string>>> dir=new Dictionary<string, Dictionary<string, List<string>>>();
		Dictionary<string, Dictionary<string,List<string>>> dir1=new Dictionary<string, Dictionary<string, List<string>>>();
		public frm_enhance()
		{
			InitializeComponent();
			this.Text ="Image Enhancer ";
			this.Text += " - v5.4.0";
			Debug.Print("Memory use- " + Convert.ToString(System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024)));
			tkBrightness.Maximum = 100;
			tkContrast.Maximum = 100;
			tkBrightness.Minimum =-100;
			tkContrast.Minimum = -100;
			tkContrast.Value = 0;
			tkBrightness.Value = 0;
			
			configpath=Application.StartupPath + "\\" + "Config.txt";
			if(!File.Exists(configpath)){
				File.CreateText(configpath);
			}
			showdata();
		}
		
		void configure(string imgPATH)
		{
			imf = new ImgProcessor(imgPATH);
			orig = imf.img;
			image_Path = imgPATH;
			imf = new ImgProcessor(image_Path);
			//iml = new ImgProcessor(image_Path);
			org1=new Bitmap(imf.img);
			//System.Drawing.Image imx = new Bitmap(image_Path);
		}
		
		void init(Bitmap pImg) {
			
		}
		
		Point GetDispArea() {
			return new Point(this.ClientRectangle.Width, this.ClientRectangle.Height-stsSplit.Height);
		}
		
		void Frm_enhanceResize(object sender, EventArgs e)
		{
			resz(org1);
		}
		
		void PcbMainMouseDown(object sender, MouseEventArgs e)
		{
			if (!bDrawing) {
				bDrawing = true;
				topRect.X = e.X;
				topRect.Y = e.Y;
				topRect.Width = 0;
				topRect.Height = 0;
			}
			else {
				topRect.Width += e.X-topRect.X;
				topRect.Height += e.Y-topRect.Y;
			}
			currentPos = startPos = e.Location;
			drawing = true;
		}
		
		void PcbMainMouseUp(object sender, MouseEventArgs e)
		{
			if (drawing) {
				drawing = false;
				
				if(IsSelecting=="clear_image"){
					FxWithBox(imf.Clear);
					
					lvwFiles.Focus();
					IsSelecting="clear_image";
				}
				else
					if(IsSelecting=="cmdcrop"){
					FxWithBox(imf.Crop);
					lvwFiles.Focus();
					//cmdCrop.Focus();
					IsSelecting="cmdcrop";
					//retVal=null;
				}
			}
			bDrawing = false;
		}
		
		void PcbMainMouseMove(object sender, MouseEventArgs e)
		{
			currentPos = e.Location;
			if (drawing) {
				pcbMain.Invalidate();
			}
		}
		
		private void resz(Bitmap _img) {
			grpBrowse.Location = new Point(padding, padding + 10);
			grpBrowse.Top =  padding - 18;
			grpBrowse.Height =padding*3;
			grpBrowse.Width = GetDispArea().X- Convert.ToInt32( padding*1.5);
			
			grpImage.Left = Convert.ToInt32(grpBrowse.Width*.2);
			grpImage.Top = padding + padding * 2;
			grpImage.Height = GetDispArea().Y - (padding*2) - 50;
			grpImage.Width = Convert.ToInt32(GetDispArea().X*.65);
			
			grpPath.Location = new Point(padding, padding + 10);
			grpPath.Top =  padding + padding * 2;
			grpPath.Height =  Convert.ToInt32(grpImage.Height/2.5)-10;
			grpPath.Width = Convert.ToInt32(grpBrowse.Width * .2)-padding*2;
			
			grouptools .Location = new Point(padding, padding + 10);
			grouptools.Top = grpPath.Height+ padding*3 ;
			grouptools.Height = Convert.ToInt32(grpImage.Height/3.6)-padding;
			grouptools.Width = Convert.ToInt32(grpBrowse.Width * .2)-padding*2;
			
			grpTools.Location = new Point(padding, padding + 10);
			grpTools.Top = grpPath.Height+grouptools.Height+ padding*3 ;
			grpTools.Height = Convert.ToInt32(grpImage.Height/3)+padding;
			grpTools.Width = Convert.ToInt32(grpBrowse.Width * .2)-padding*2;
			
			groupcrt.Left=grpImage.Right+padding/2;
			groupcrt.Width=Convert.ToInt32(GetDispArea().X*.15)-padding/2;
			groupcrt.Height=grpImage.Height/2;
			groupcrt.Top=Convert.ToInt32(padding + padding * 2.5);
			
			grplist1.Width=groupcrt.Width-padding;
			grplist1.Height=Convert.ToInt32(groupcrt.Height*.85)-padding*2;
			
			//gotocreategroup.Left=grpImage.Right+padding/2;
			gotocreategroup.Top=grplist1.Height+padding;
			gotocreategroup.Width=groupcrt.Width-padding;
			//gotocreategroup.Height=Convert.ToInt32(groupcrt.Height*.1)-padding*2;
			
			editgroup.Top=grplist1.Height+gotocreategroup.Height+padding;
			editgroup.Width=groupcrt.Width-padding;
			
			deletegrp.Top=grplist1.Height+gotocreategroup.Height+editgroup.Height+padding;
			deletegrp.Width=groupcrt.Width-padding;
			//gotocreategroup.Height=Convert.ToInt32(groupcrt.Height*.1)-padding*2;
			lvwFiles.Width = grpPath.Width-10;
			lvwFiles.Height = grpPath.Height-Convert.ToInt32( padding*1.5);
			
			pcbMain.Left = grpImage.Left+grpImage.Width - padding - 5;
			pcbMain.Top = 3;
			
			pnlImage.Location = new Point(padding, padding);
			pnlImage.Height = grpImage.Height-(padding * 2);
			pnlImage.Width = grpImage.Width-2*padding;
			
			txtPath.Top=grpBrowse.Top+padding;
			txtPath.Height=20;
			txtPath.Width=grpBrowse.Width/2;
			
			btnBrowse.Top=txtPath.Top;
			btnBrowse.Height=20;
			btnBrowse.Width=60;
			btnBrowse.Left=txtPath.Right+padding/2;
			
			gotohelp.Top= txtPath.Top;
			gotohelp.Height=20;
			gotohelp.Width=60;
			gotohelp.Left=btnBrowse.Right+padding/2;
			
			List<Control> lstControls1 = new List<Control>();
			foreach (Control con in grouptools.Controls) {
				lstControls1.Add(con);
			}
			int i=0;
			lstControls1.ToList().OrderBy(x => x.TabIndex)
				.ToList()
				.ForEach(y => {
				         	y.Top = i * ((grouptools.Height - 13) / grouptools.Controls.Count)+12;
				         	Graphics g = this.CreateGraphics();
				         	//Debug.Print(Convert.ToString(y.Height*72.0f/g.DpiY));
				         	
				         	y.Width=grouptools.Width-5;
				         	y.Height=(grouptools.Height/grouptools.Controls.Count)-5;
				         	float divisor = 1.0f;
				         	if (y.GetType() == typeof(System.Windows.Forms.Label)) {
				         		divisor = 2.5f;
				         	}
				         	else {
				         		divisor = 1.2f;
				         	}
				         	float ht = (y.Height*72.0f/g.DpiY) / divisor;
				         	
				         	if(y.Height-5>0) {
				         		Font f= new Font(y.Font.FontFamily,ht,y.Font.Style,GraphicsUnit.Pixel);
				         		y.Font=f;
				         	}
				         	
				         	i++;
				         });
			
			List<Control> lstControls = new List<Control>();
			foreach (Control con in grpTools.Controls) {
				lstControls.Add(con);
			}
			i=0;
			lstControls.ToList().OrderBy(x => x.TabIndex)
				.ToList()
				.ForEach(y => {y.Top = i * ((grpTools.Height - 15) / grpTools.Controls.Count)+12;
				         	Graphics g = this.CreateGraphics();
				         	//Debug.Print(Convert.ToString(y.Height*72.0f/g.DpiY));
				         	
				         	y.Width=grpTools.Width-10;
				         	y.Height=grpTools.Height/grpTools.Controls.Count;
				         	float ht = (y.Height*72.0f/g.DpiY) / 2.0f ;
				         	if(y.Height-5>0) {
				         		Font f= new Font(y.Font.FontFamily,ht,y.Font.Style,GraphicsUnit.Pixel);
				         		y.Font=f;
				         	}
				         	i++;
				         });
			
			
			if(imf != null)
			{
				Point pt = ScreenGraphics.GetMaxScaleWithAspectRatio(_img.Width, _img.Height, new Point(pnlImage.Width, pnlImage.Height));
				pcbMain.Left=0;
				pcbMain.Top=0;
				pcbMain.Width = pt.X;
				pcbMain.Height = pt.Y;
				pcbMain.Image = _img;
				tst2.Text = "Width-" + Convert.ToString(_img.Width) + ", Height-"+ Convert.ToString(_img.Height);
			}
		}
		
		void Frm_enhanceKeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.H){
				gohelp();
				lvwFiles.Focus();
			}
			if(imf!=null){
				if (e.KeyCode == Keys.R) {
					
					setpath(img_FullPath1,targetPath);
					
					string s=null;
					s=img_FullPath1.ElementAt(count).ToString();
					imf = new ImgProcessor(s);
					tkBrightness.Value = 0;
					tkContrast.Value = 0;
					//imf.Reload();
					resz(imf.img);
					lvwFiles.Items[count].Selected = true;
					lvwFiles.Select();
					lvwFiles.Focus();
				}
			}
			if(pfmt.ToString()=="Format1bppIndexed"){
				if ((e.KeyCode == Keys.B) && e.Shift == false) {
					tkBrightness.Value += STEP_COUNT;
				}
				
				if ((e.KeyCode == Keys.B) && e.Shift == true) {
					tkBrightness.Value -= STEP_COUNT;
				}
				
				if ((e.KeyCode == Keys.V) && e.Shift == false) {
					tkContrast.Value += STEP_COUNT;
				}
				
				if ((e.KeyCode == Keys.V) && e.Shift == true) {
					tkContrast.Value -= STEP_COUNT;
				}
			}
			if(e.KeyCode== Keys.A){
				if(imf!=null){
					imf.Despackle(c);
					progressing(true);
					//pcbMain.Image = imf.img;
					resz(imf.img);
					//lvwFiles.Focus();
					progressing(false);
					lvwFiles.Focus();
					c=0;
				}
			}
			
			if (e.KeyCode == Keys.F5) {
				save();
				this.Close();
			}
			
			if (e.KeyCode == Keys.L) {
				imf.lr();
				resz(imf.img);
				lvwFiles.Focus();
			}
			
			if (e.KeyCode == Keys.T) {
				imf.rr();
				resz(imf.img);
				lvwFiles.Focus();
			}
			
			if (e.KeyCode == Keys.X){
				if (frame.Height > 0 && frame.Width > 0) {
					FxWithBox(imf.Crop);
					lvwFiles.Focus();
					IsSelecting="cmdcrop";
				}
				else{
					IsSelecting="cmdcrop";
					lvwFiles.Focus();
				}
				
			}
			
			if ((e.KeyCode == Keys.Q)) {
				if (frame.Height > 0 && frame.Width > 0) {
					FxWithBox(imf.Clear);
					lvwFiles.Focus();
					IsSelecting="clear_image";
				}
				else
				{
					IsSelecting="clear_image";
					lvwFiles.Focus();
				}
			}
			
			if(e.KeyCode==Keys.Z){
				deskew();
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad1 || e.KeyCode== Keys.D1){
				listdata(1.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad2 || e.KeyCode== Keys.D2){
				listdata(2.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.Space){
				if(imf!=null){
					//SaveMove();
					if(count<lvwFiles.Items.Count-1){
						SaveMove();
					}
					else{
						save();
						MessageBox.Show("No more image are there, choose save and exit option");
					}
				}
			}
			
			if(e.KeyCode==Keys.NumPad3 || e.KeyCode== Keys.D3){
				listdata(3.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad4 || e.KeyCode== Keys.D4){
				listdata(4.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad5 || e.KeyCode== Keys.D5){
				listdata(5.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad6 || e.KeyCode== Keys.D6){
				listdata(6.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad7 || e.KeyCode== Keys.D7){
				listdata(7.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad8 || e.KeyCode== Keys.D8){
				listdata(8.ToString());
				lvwFiles.Focus();
			}
			
			if(e.KeyCode==Keys.NumPad9 || e.KeyCode== Keys.D9){
				listdata(9.ToString());
				lvwFiles.Focus();
			}
			if(e.KeyCode==Keys.Delete){
				string str=grplist1.SelectedItems[0].SubItems[0].Text;
				s=null;
				int i=0;
				foreach (var outerEntry in dir) {
					if(str!=outerEntry.Key){
						s=s+outerEntry.Key+";";
						var innerEntry=new Dictionary<string, List<string>>();
						innerEntry=outerEntry.Value;
						s=s+innerEntry.Keys.ElementAt(0).ToString()+";";
						j=0;
						foreach(var element in innerEntry.Values.ElementAt(0)){
							s=s+element+";";
							j++;
						}
						s=s.Substring(0,s.Length-1);
						s=s+Environment.NewLine;
						i++;
					}
					File.WriteAllText(configpath,s);
				}
				grplist1.SelectedItems[0].Remove();
				grplist1.Items.Clear();
				showdata();
				lvwFiles.Focus();
			}
		}
		
		void CmdSaveClick(object sender, EventArgs e)
		{
			if(imf!=null){
				save();
				this.Close();
			}
		}
		
//		void CmdCancelClick(object sender, EventArgs e)
//		{
//			if(imf!=null){
//				this.Close();
//			}
//		}
		
		void CmdDeskewClick(object sender, EventArgs e)
		{
			 if(imf!=null){
				deskew();
				lvwFiles.Focus();
			
			}
		}
		
		
		
		void CmdCropClick(object sender, EventArgs e)
		{
			IsSelecting="cmdcrop";
			if(imf!=null ){
				FxWithBox(imf.Crop);
				lvwFiles.Focus();
				IsSelecting="cmdcrop";
				//cmdCrop.Focus();
				//retVal=null;
			}
		}
		
		void PcbMainPaint(object sender, PaintEventArgs e)
		{	if (drawing) {
				e.Graphics.DrawRectangle(Pens.Red, getRectangle());
				frame = getRectangle();
			}
		}
		
		private Rectangle getRectangle() {
			return new Rectangle(
				Math.Min(startPos.X, currentPos.X),
				Math.Min(startPos.Y, currentPos.Y),
				Math.Abs(startPos.X - currentPos.X),
				Math.Abs(startPos.Y - currentPos.Y));
		}
		
		void TkBrightnessValueChanged(object sender, EventArgs e)
		{
			GC.Collect();
			if (imf != null && imf.img != null) {
				//Debug.Print(imf.img.PixelFormat.ToString());
				imf.clon(System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				BrightnessCorrection bright_Corr = new BrightnessCorrection(Convert.ToInt32(tkBrightness.Value-lastBrightness));
				bright_Corr.ApplyInPlace(imf.img);
				
				pcbMain.Image = imf.img;
				GC.Collect();
				//imf.clon(System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
				lastBrightness = tkBrightness.Value;
				//ControlPaint.Light(
			}
			//Debug.Print("Memory use after changing brightness- " + Convert.ToString(System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024)));
		}
		
		void TkContrastValueChanged(object sender, EventArgs e)
		{
			GC.Collect();
			if (imf != null && imf.img != null) {
				imf.clon(System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				ContrastCorrection cont_Corr = new ContrastCorrection(Convert.ToInt32(tkContrast.Value)-Convert.ToInt32(lastContrast));
				cont_Corr.ApplyInPlace(imf.img);
				pcbMain.Image = imf.img;
				GC.Collect();
				lastContrast = tkContrast.Value;
			}
			//Debug.Print("Memory use after changing contrast- " + Convert.ToString(System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024)));
		}
		
		float GetSourceToDisplayRatio(int im, int PB) {
			return (float)im/(float)PB;
		}

		Bitmap FxWithBox(Func<Rectangle, Bitmap> fx)
		{
			if (frame.Height > 0 && frame.Width > 0) {
				progressing(true);
				int imgStartCoordX, imgStartCoordY,imgWidth,imgHeight;
				Rectangle r = frame;
				float htRatio = GetSourceToDisplayRatio(imf.img.Height,pcbMain.Height);
				float wdRatio = GetSourceToDisplayRatio(imf.img.Width,pcbMain.Width);
				imgStartCoordX=Convert.ToInt32(((float)r.Left/(float)pcbMain.Width)*(imf.img.Width));
				imgStartCoordY=Convert.ToInt32(((float)r.Top/(float)pcbMain.Height)*(imf.img.Height));
				imgWidth=Convert.ToInt32(((float)r.Width)*wdRatio);
				imgHeight=Convert.ToInt32(((float)r.Height)*htRatio);
				retVal = fx(new Rectangle(imgStartCoordX, imgStartCoordY, imgWidth, imgHeight));
				pcbMain.Image = imf.img;
				resz(imf.img);
				topRect = new Rectangle(0,0,0,0);
				frame.Height=0;
				frame.Width=0;
				progressing(false);
			}
			else if(frame.Width==0 && frame.Height==0){
				Debug.Print("it is just a click");
			}
			else
				feedbackOfselectArea();
			return retVal;
		}
		
		void feedbackOfselectArea(string methodName=""){
			MessageBox.Show("Required to select some area for " + methodName);
		}
		void Clear_imageClick(object sender, EventArgs e)
		{
			//clear_image.Focus();
			//cmdCrop.Focused=false;
			IsSelecting="clear_image";
			if(imf!=null){
				progressing(true);
				FxWithBox(imf.Clear);
				
				lvwFiles.Focus();
				//clear_image.Focus();
				IsSelecting="clear_image";
				progressing(false);
			}
		}
		
		void save(){
			if (!Directory.Exists(StoragePath)) {
				Directory.CreateDirectory(StoragePath);
			}
			if(orig!=null){
				if(orig.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff) ){
					int compressionTagIndex = Array.IndexOf(orig.PropertyIdList, 0x103);
					PropertyItem compressionTag = orig.PropertyItems[compressionTagIndex];
					var= BitConverter.ToInt16(compressionTag.Value, 0);
					
					if(var==7){
						x=new tm24rgb(BitMiracle.LibTiff.Classic.Compression.JPEG);
					}
					else if(var==4){
						x=new tm1bw(BitMiracle.LibTiff.Classic.Compression.CCITTFAX4);
					}
					else if(var==5){
						x=new tm24rgb(BitMiracle.LibTiff.Classic.Compression.LZW);
					}
					else if(var==2){
						x=new tm1bw(BitMiracle.LibTiff.Classic.Compression.CCITTRLE);
					}
					else if(var==3){
						x=new tm1bw(BitMiracle.LibTiff.Classic.Compression.CCITTFAX3);
					}
					else if(var==1){
						x=new tm1bw(BitMiracle.LibTiff.Classic.Compression.NONE);
					}
					else if(var==6){
						x=new tm24rgb(BitMiracle.LibTiff.Classic.Compression.OJPEG);
					}
					GC.Collect();
					orig=null;
					dt.img=imf.img;
					org1=null;
					x.BitmapToTiff(imf.img,StoragePath + StorageFile );
					imc.setImage(dt,(int)count);				
				}
				else if(orig.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) ){
					myImageCodecInfo = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
					myEncoderParameters = new EncoderParameters() { Param = new[] { new EncoderParameter(Encoder.Quality, 100L) } };
					imf.img.Save(StoragePath + StorageFile, myImageCodecInfo, myEncoderParameters);
				}
			}
		}
		
		void Left_rotationClick(object sender, EventArgs e)
		{
			if(imf!=null){
				progressing(true);
				imf.lr();
				resz(imf.img);
				lvwFiles.Focus();
				progressing(false);
			}
		}
		
		void Right_rotationClick(object sender, EventArgs e)
		{
			if(imf!=null){
				progressing(true);
				imf.rr();
				resz(imf.img);
				lvwFiles.Focus();
				progressing(false);
			}
		}
		
		void Despeckle_imgClick(object sender, EventArgs e)
		{
			if(imf!=null){
					progressing(true);
					imf.Despackle(c);
					pcbMain.Image = imf.img;
					resz(imf.img);
					lvwFiles.Focus();
					progressing(false);
					c=0;
				
			}
		}
		
		void deskew(){
			progressing(true);
//			x0=imf.img.Width;
//			y0=imf.img.Height;
			imf.deskew1();
			c++;
			//imf.CorrectSkew();
			pcbMain.Image = imf.img;
			//Debug.Print("Memory use after diskew- " + Convert.ToString(System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024)));
			
//			int x1=imf.img.Width;
//			int y1=imf.img.Height;
//			int dx=x1-x0;
//			int dy=y1-y0;
//			float imgStartCoordX, imgStartCoordY,imgStartCoordX1,imgStartCoordY1;
//			imgStartCoordX=(float)x0/(float)pcbMain.Width;
//			imgStartCoordY=(float)y0/(float)pcbMain.Height;
//			imgStartCoordX1=(float)x1/(float)pcbMain.Width;
//			imgStartCoordY1=(float)y1/(float)pcbMain.Height;
//			imf.Crop(new Rectangle(0+dx/2,0+dy/2,Convert.ToInt32(imf.img.Width-dx/2),Convert.ToInt32(imf.img.Height-dy/2)));
//			resz(imf.img);
			
			lvwFiles.Focus();
			resz(imf.img);
			progressing(false);
		}
		
		public bool StringCompare(string a, string b) {
			return Path.GetFileName(a).Equals(Path.GetFileName(b));
		}
		
		void BtnBrowseClick(object sender, EventArgs e)
		{
			//fbd.SelectedPath = @"D:\BSP IMAGES\raw2";
			Func<string, string, bool> fx = StringCompare;
			
			//fbd.SelectedPath = @"D:\BSP IMAGES\raw2";
			if(fbd.ShowDialog() == DialogResult.OK)
			{
				if(lvwFiles.Items.Count > 0 )
				{
					if(img_FullPath.Count>0)
						img_FullPath.Clear();
					lvwFiles.Items.Clear();
					lvwFiles.Update();
					lvwFiles.Refresh();
				}
				targetPath = fbd.SelectedPath ;
				fbd.SelectedPath=targetPath + "\\" + "Export";
				if (!Directory.Exists(fbd.SelectedPath))
				{
					Directory.CreateDirectory(fbd.SelectedPath);
					foreach (var srcPath in Directory.GetFiles(targetPath))
					{
						File.Copy(srcPath, srcPath.Replace(targetPath, fbd.SelectedPath), true);
					}
				}
				else{
					Directory.GetFiles(targetPath).ToList()
						.Where(l => !Directory.GetFiles(fbd.SelectedPath)
						       .Select(Path.GetFileName)
						       .Contains(Path.GetFileName(l)))
						.ToList()
						.ForEach(x => File.Copy(x, x.Replace(targetPath, fbd.SelectedPath), true));
				}
				
				DirectoryInfo dInfo = new DirectoryInfo(fbd.SelectedPath);
				DirectorySecurity dSecurity = dInfo.GetAccessControl();
				dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
				dInfo.SetAccessControl(dSecurity);
				txtPath.Text = fbd.SelectedPath;
				setpath(img_FullPath,txtPath.Text);
				lvwFiles.Items.Clear();
				foreach(string aa in img_FullPath)
				{
					ListViewItem lv1= new ListViewItem(aa);
					lv1.SubItems.Add(Path.GetFileName(aa));
					lvwFiles.Items.Add(lv1);
				}
				imc=new ImgCache(img_FullPath, lvwFiles.Items.Count);
				if (lvwFiles.Items.Count > 0) {
					lvwFiles.Items[0].Selected=true;
					lvwFiles.FullRowSelect=true;
					lvwFiles.Select();
					lvwFiles.Focus();
					currentIndex=lvwFiles.SelectedItems[0].Index;
				}
			}
		}
		
		void setpath(List<string> imPath,string folder){
			Directory.GetFiles(folder, "*.*")
				.ToList()
				.Where(m => (m.ToLower().EndsWith(".tif") ||(m.ToLower().EndsWith(".tiff"))))
				.ToList()
				.ForEach(x => imPath.Add(x));
		}
		
		private static ImageCodecInfo GetEncoderInfo(String mimeType)
		{
			int j;
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for (j = 0; j < encoders.Length; ++j)
			{
				if (encoders[j].MimeType == mimeType)
					return encoders[j];
			}
			return null;
		}
		
		void LvwFilesSelectedIndexChanged(object sender, EventArgs e)
		{
			ChangeListItem();
		}
		
		void ChangeListItem(){
			if (lvwFiles.SelectedItems.Count > 0)
			{
				c=0;
				lvwFiles.EnsureVisible(lvwFiles.SelectedItems[0].Index);
				//lvwFiles.sc
				progressing(true);
				StoragePath = Path.GetDirectoryName(lvwFiles.SelectedItems[0].Text) + ScreenGraphics.STORAGE_FOLDER;
				StorageFile = Path.GetFileName(lvwFiles.SelectedItems[0].Text);
				bmp=new Bitmap(lvwFiles.SelectedItems[0].Text);
				
				dt=imc.GetImage(lvwFiles.SelectedItems[0].Text);
				
				//dt.img=System.Drawing.Image.FromFile( lvwFiles.SelectedItems[0].Text);
				imf = new ImgProcessor((Bitmap)dt.img,dt.imfmt,dt.pfmt);
				GC.Collect();
				orig=bmp;
				tkBrightness.Value = 0;
				tkContrast.Value = 0;
				
				pcbMain.Image = imf.img;
				//orig=imf.img;
				pcbMain.Top=0;
				pcbMain.Left=0;
				Point pt = ScreenGraphics.GetMaxScaleWithAspectRatio(imf.img.Width, imf.img.Height,new Point(pnlImage.Width, pnlImage.Height));
				pcbMain.Width = pt.X;
				pcbMain.Height = pt.Y;
				//var1=lvwFiles.SelectedIndices[0];
				count=lvwFiles.SelectedItems[0].Index;
				//if(dt.imfmt.
				
				pfmt=dt.pfmt;
				if(dt.pfmt.ToString()=="Format1bppIndexed"){
					grouptools.Enabled=false;
				}
				bmp=null;
				dt.flPath=null;
			}
			progressing(false);
		}
		
		void SaveAndMoveNextClick(object sender, EventArgs e)
		{
			if(imf!=null){
				if(count<lvwFiles.Items.Count-1){
					SaveMove();
				}
				else{
					save();
					MessageBox.Show("No more images are there.");
					lvwFiles.Focus();
				}
			}
		}
		
		void SaveMove(){
			c=0;
			save();
			
			currentIndex = lvwFiles.SelectedItems[0].Index;
			
			if(currentIndex < lvwFiles.Items.Count - 1)
			{
				lvwFiles.Items[currentIndex].Selected=false;
				lvwFiles.Items[currentIndex + 1].Selected=true;
				lvwFiles.Items[currentIndex + 1].Focused = true;
				lvwFiles.Focus();
			}
			if(currentIndex==(lvwFiles.Items.Count-1)){
				
				lvwFiles.Items[currentIndex].Selected=true;
				lvwFiles.Items[currentIndex].Focused = true;
				lvwFiles.Focus();
			}
			//ChangeListItem();
		}
		
		void GotohelpClick(object sender, EventArgs e)
		{
			gohelp();
		}
		
		void gohelp(){
			List <string> lst=new List<string>();
			lst.Add("1. Z = Deskew ");
			lst.Add("2. B = Increase Brightnaess ");
			lst.Add("3. H = help");
			lst.Add("4. Q = Clear Image ");
			lst.Add("5. L = Rotate Left ");
			lst.Add("6. X = Selected area Crop ");
			lst.Add("7. R = Reload  ");
			lst.Add("8. F5 = Save and Exit ");
			lst.Add("9. Shift + B = Increase Contrast  ");
			lst.Add("10.Shift + V = Decrease Contrast ");
			lst.Add("11.Space = Save and Next ");
			lst.Add("12.T = Rotate Right ");
			lst.Add("13.A = Despeckle ");
			gs = new GotoShow(this.Text, lst);
			gs.ShowDialog();
			lvwFiles.Focus();
		}
		
		void GotocreategroupClick(object sender, EventArgs e)
		{
			lst.Clear();
			lst.Add("deskew");
			lst.Add("crop");
			lst.Add("clear image");
			lst.Add("Despeckle");
			lst.Add("Rotate Left");
			lst.Add("Rotate Right");
			
			if(File.Exists(configpath))
				showdata();
			MainForm mp=new MainForm(lst,dir);
			mp.ShowDialog();
			int i=0;
			s=null;
			foreach (var outerEntry in dir) {
				i=0;
				s=s+outerEntry.Key+";";
				var innerEntry=new Dictionary<string, List<string>>();
				innerEntry=outerEntry.Value;
				s=s+innerEntry.Keys.ElementAt(i).ToString()+";";
				j=0;
				foreach(var element in innerEntry.Values.ElementAt(i)){
					s=s+element+";";
					j++;
				}
				s=s.Substring(0,s.Length-1);
				s=s+Environment.NewLine;
				i++;
			}
			File.WriteAllText(configpath,s);
			grplist1.Items.Clear();
			showdata();
			lvwFiles.Focus();
		}
		
		void showdata()
		{
			dir1.Clear();
			System.IO.StreamReader sr = new System.IO.StreamReader(configpath);
			while(!sr.EndOfStream)
			{
				var line = sr.ReadLine();
				string[]s = line.Split(';');
				ListViewItem lst1=new ListViewItem(s[0]);
				lst1.SubItems.Add(s[1]);
				grplist1.Items.Add(lst1);
				List<string> l=new List<string>();
				for(int k=2;k<s.Length;k++){
					l.Add(s[k]);
				}
				Dictionary<string,List<string>> d=new Dictionary<string, List<string>>();
				d.Add(s[1],l);
				dir1.Add(s[0],d);
				dir=dir1;
			}
			sr.Dispose();
		}
		
		void Grplist1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void listdata(string data){
			foreach (var outerEntry in dir) {
				Dictionary<string, List<string>> tst = new Dictionary<string, List<string>>();
				tst = outerEntry.Value;
				for(int i = 0; i < tst.Count; i++)
				{
					if(tst.Keys.ElementAt(i).ToString()==data){
						List<string> keyList = tst.Values.ElementAt(i).ToList();
						datahandle(keyList);
					}
				}
			}
		}
		
		void datahandle(List<string> lst){
			foreach (string element in lst) {
				switch(element){
					case "deskew":
						if(imf!=null){
							deskew();
						}
						break;
					case "crop":
						if(imf!=null){
							FxWithBox(imf.Crop);
						}
						break;
					case "clear image":
						if(imf!=null){
							FxWithBox(imf.Clear);
						}
						break;
					case "Rotate Left":
						imf.lr();
						resz(imf.img);
						break;
					case "Rotate Right":
						imf.rr();
						resz(imf.img);
						break;
					case "Despeckle":
						if(imf!=null){
							imf.Despackle(c);
							//pcbMain.Image = imf.img;
							resz(imf.img);
							lvwFiles.Focus();
							c=0;
						}
						break;
				}
			}
		}
		
		void Frm_enhanceLoad(object sender, EventArgs e)
		{
			if(File.Exists(configpath))
				showdata();
		}
		
		void EditgroupClick(object sender, EventArgs e)
		{
			lst.Clear();
			lst.Add("deskew");
			lst.Add("crop");
			lst.Add("clear image");
			lst.Add("Despeckle");
			lst.Add("Rotate Left");
			lst.Add("Rotate Right");
			string data=grplist1.SelectedItems[0].SubItems[0].Text;
			string data1=grplist1.SelectedItems[0].SubItems[1].Text;
			listView1.Refresh();
			
			dir.Clear();
			
			showdata();
			grplist1.Items.Clear();
			MainForm mp=new MainForm(lst,dir);
			mp.editdata(data,data1,dir);
			mp.ShowDialog();
			
			int i=0;
			s=null;
			foreach (var outerEntry in dir) {
				s=s+outerEntry.Key+";";
				var innerEntry=new Dictionary<string, List<string>>();
				innerEntry=outerEntry.Value;
				s=s+innerEntry.Keys.ElementAt(0).ToString()+";";
				j=0;
				foreach(var element in innerEntry.Values.ElementAt(0)){
					s=s+element+";";
					j++;
				}
				s=s.Substring(0,s.Length-1);
				s=s+Environment.NewLine;
				i++;
			}
			File.WriteAllText(configpath,s);
			showdata();
			lvwFiles.Focus();
		}
		
		void progressing(bool busy){
			if(busy){
				Cursor.Current = Cursors.WaitCursor;
			}
			else
				Cursor.Current = Cursors.Default;
		}
		
		void DeletegrpClick(object sender, EventArgs e)
		{
			string data=grplist1.SelectedItems[0].SubItems[0].Text;
			MainForm mp=new MainForm(lst,dir);
			mp.deletedata(data,dir);
			grplist1.Items.Clear();
			int i=0;
			s=null;
			foreach (var outerEntry in dir) {
				s=s+outerEntry.Key+";";
				var innerEntry=new Dictionary<string, List<string>>();
				innerEntry=outerEntry.Value;
				s=s+innerEntry.Keys.ElementAt(0).ToString()+";";
				j=0;
				foreach(var element in innerEntry.Values.ElementAt(0)){
					s=s+element+";";
					j++;
				}
				s=s.Substring(0,s.Length-1);
				s=s+Environment.NewLine;
				i++;
			}
			File.WriteAllText(configpath,s);
			showdata();
			lvwFiles.Focus();
		}
	}
}

