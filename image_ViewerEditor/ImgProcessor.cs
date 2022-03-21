/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 10/03/2017
 * Time: 1:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.IO;
using System.Windows.Forms;
using AForge.Math;

//using ImageProcessor;

namespace BLRO
{
	/// <summary>
	/// Description of ImageProcessor.
	/// </summary>
	public enum ImageOrientation {
		Portrait, Landscape
	};
	public class ImgProcessor
	{
		public Bitmap imgP {get; private set;}
		public Bitmap img
		{
			get {
				return imgP;
			}
			private set {
				imgP = value;
			}
		}
		public double ratio_hbyw {get; private set;}
		public ImageOrientation Orientation {get; private set;}
		public ImageFormat StorageFormat {get; private set;}
		public PixelFormat pixelformat{get;private set;}
		public string SourcePath {get; private set;}
		public ImgProcessor(string pImg)
		{
			if (null == pImg) {
				throw new Exception("Not a valid image");
			}
			else {
				SourcePath = pImg;
				Reload();
				//imgP = pImg;
			}
		}
		
		public ImgProcessor(Bitmap pImg, ImageFormat pFmt,PixelFormat pfmt)
		{
			if (null == pImg) {
				throw new Exception("Not a valid image");
			}
			else {
				imgP = pImg;
				StorageFormat = pFmt;
				pixelformat=pfmt;
			}
		}

		private int ValidateGrayLevel(int graylevel)
		{
			if (graylevel < 0) return 0;
			if (graylevel > 1) return 1;
			return graylevel;
		}

		private void init() {
			ratio_hbyw = Convert.ToDouble(img.Height)/Convert.ToDouble(img.Width);
			Orientation = ratio_hbyw < 1 ? ImageOrientation.Landscape : ImageOrientation.Portrait;
		}
		
		public bool Reload() {
			imgP = (Bitmap)AForge.Imaging.Image.FromFile(SourcePath);
			StorageFormat = AForge.Imaging.Image.FromFile(SourcePath).RawFormat;
			return true;
		}
		
		public Bitmap Despackle(int c) {
			float hr = img.HorizontalResolution;
			float vr = img.VerticalResolution;
			if(c==0){
				Dilatation filter=new Dilatation();
				//img= img.Clone(new Rectangle(0, 0, img.Width, img.Height),System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
				img=clon(PixelFormat.Format8bppIndexed);
				filter.ApplyInPlace( img);
				//img=clon(PixelFormat.Format8bppIndexed);
				Sharpen filter1 = new Sharpen( );
				// apply the filter
				filter1.ApplyInPlace( img );
			}
			else{
				Closing filter1 = new Closing( );
				// apply the filter
				filter1.ApplyInPlace( img );
			}
			return img;
		}
		
		public Bitmap clon(System.Drawing.Imaging.PixelFormat pFormat){
			img = img.Clone(new Rectangle(0, 0, img.Width, img.Height),pFormat);
			return img;
		}
		
		public Bitmap rr(){
			img.RotateFlip( RotateFlipType.Rotate90FlipNone);
			return img;
		}
		
		public Bitmap lr(){
			img.RotateFlip( RotateFlipType.Rotate270FlipNone);
			return img;
		}
		
//		public double GetSkew() {
//			Grayscale filter = new Grayscale( 0.2125, 0.7154, 0.0721 );
//			Bitmap grayImage;
//			float hr = img.HorizontalResolution;
//			float vr = img.VerticalResolution;
//			try {
//				grayImage = filter.Apply(img);
//			}
//			catch (AForge.Imaging.UnsupportedImageFormatException ex) {
//				//PixelFormat pfmt = img.PixelFormat;
//				img=clon(PixelFormat.Format24bppRgb);
//				grayImage = filter.Apply(img);
////				  img = img.Clone(new Rectangle(0, 0, img.Width, img.Height), PixelFormat.Format24bppRgb);
////				  img = grayImage.Clone(new Rectangle(0, 0, img.Width, img.Height), pfmt);
////				  img.SetResolution(hr, vr);
////				  Debug.Print(ex.ToString());
//			}
//			DocumentSkewChecker skewChecker = new DocumentSkewChecker();
//			return skewChecker.GetSkewAngle(grayImage);
//		}
//		
//		public Bitmap CorrectSkew() {
//			
//			float hr = img.HorizontalResolution;
//			float vr = img.VerticalResolution;
//			//PixelFormat pfmt = img.PixelFormat;
//			double skewAngle = GetSkew();
//			Grayscale filter = new Grayscale( 0.2125, 0.7154, 0.0721 );
//			img=clon(PixelFormat.Format24bppRgb);
//			img = filter.Apply(img);
//			RotateBilinear rotationFilter = new RotateBilinear(-1*skewAngle);
//			rotationFilter.FillColor = Color.White;
//			img = rotationFilter.Apply(img);
////			img = img.Clone(new Rectangle(0, 0, img.Width, img.Height), PixelFormat.Format8bppIndexed);
////			//img=clon(pixelformat);
////			img.SetResolution(hr, vr);
////			Sharpen filter1 = new Sharpen( );
////			// apply the filter
////			filter1.ApplyInPlace( img );
//			return img;
//		}
		
		public Bitmap deskew1(){
			
			float hr = img.HorizontalResolution;
			float vr = img.VerticalResolution;
			//Bitmap bmp=new Bitmap(img);
			// create grayscale filter (BT709)
			Grayscale filter = new Grayscale( 0.2125, 0.7154, 0.0721 );
			img=clon(PixelFormat.Format24bppRgb);
			// apply the filter
			img = filter.Apply( img );
			// create instance of skew checker
			DocumentSkewChecker skewChecker = new DocumentSkewChecker( );
			// get documents skew angle
			double angle = skewChecker.GetSkewAngle( img );
			// create rotation filter
//			img=clon(PixelFormat.Format8bppIndexed);
			RotateBilinear rotationFilter = new RotateBilinear( -angle );
			rotationFilter.FillColor = Color.White;
			// rotate image applying the filter
			img = rotationFilter.Apply( img );
			
			
			//img=RotateImage(img,(float)angle);
			//img=clon(PixelFormat.Format8bppIndexed);
			img.SetResolution(hr, vr);
//			//img=clon( PixelFormat.Format8bppIndexed);
			return img;
		}
		
//		private Bitmap RotateImage( Bitmap bmp, float angle ) {
//			Bitmap rotatedImage = new Bitmap( bmp.Width, bmp.Height );
//			using ( Graphics g = Graphics.FromImage( rotatedImage ) ) {
//				g.TranslateTransform( bmp.Width / 2, bmp.Height / 2 ); //set the rotation point as the center into the matrix
//				g.RotateTransform( angle ); //rotate
//				g.TranslateTransform( -bmp.Width / 2, -bmp.Height / 2 ); //restore rotation point into the matrix
//				g.DrawImage( bmp, new Point( 0, 0 ) ); //draw the image on the new bitmap
//			}
//
//			return rotatedImage;
//		}
		
		//[Description("Crop")]
		public Bitmap Crop(Rectangle pRect)
		{
			PixelFormat p=img.PixelFormat;
			if(pRect.Width==0 && pRect.Height==0){
				return img;
			}
			int imgStartCoordX=pRect.X, imgStartCoordY=pRect.Y,imgWidth,imgHeight;
			if(pRect.X <0 ){
				imgStartCoordX=0;
				imgWidth=pRect.Width+pRect.X;
			}
			else{
				imgStartCoordX=pRect.X;
				imgWidth=pRect.Width;
			}
			if(pRect.Y<0){
				imgStartCoordY=0;
				imgHeight=pRect.Height+pRect.Y;
			}
			else{
				imgStartCoordY=pRect.Y;
				imgHeight=pRect.Height;
			}
			
			if(pRect.X+pRect.Width>img.Width){
				imgStartCoordX=pRect.X;
				imgWidth=img.Width-pRect.X;
			}
			if(pRect.Y+pRect.Height>img.Height){
				imgStartCoordY=pRect.Y;
				imgHeight=img.Height-pRect.Y;
			}
			GC.Collect();
			float hr = img.HorizontalResolution;
			float vr = img.VerticalResolution;
			PixelFormat pfmt = img.PixelFormat;
			img = img.Clone(new Rectangle(imgStartCoordX,imgStartCoordY, imgWidth, imgHeight),PixelFormat.Format8bppIndexed);
			//	img = (Bitmap)imgN.Clone(new Rectangle(0, 0, imgN.Width, imgN.Height), pixelformat);
			//img = (Bitmap)imgN.Clone();
			img.SetResolution(hr, vr);
			pRect.Width=0;
			pRect.Height=0;
			return img;
		}

		public Bitmap Clear(Rectangle pRect) {
			if(pRect.Width==0 && pRect.Height==0){
				return img;
			}
			GC.Collect();
			float hr = img.HorizontalResolution;
			float vr = img.VerticalResolution;
			PixelFormat pfmt = img.PixelFormat;
			Bitmap imgN = img.Clone(new Rectangle(0,0,img.Width,img.Height), PixelFormat.Format24bppRgb);
			using (Graphics graphics = Graphics.FromImage(imgN)) {
				using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White)) {
					graphics.FillRectangle(myBrush, pRect);
				}
			}
			img = (Bitmap)imgN.Clone(new Rectangle(0, 0, imgN.Width, imgN.Height), PixelFormat.Format8bppIndexed);
			img.SetResolution(hr, vr);
			return img;
		}
		
		public void clear_memory()
		{
			img.Dispose();
		}
	}
}
