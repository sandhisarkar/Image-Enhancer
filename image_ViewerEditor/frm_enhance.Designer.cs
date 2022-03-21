/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 10/03/2017
 * Time: 12:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BLRO
{
	partial class frm_enhance
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpTools = new System.Windows.Forms.GroupBox();
			this.SaveAndMoveNext = new System.Windows.Forms.Button();
			this.despeckle_img = new System.Windows.Forms.Button();
			this.right_rotation = new System.Windows.Forms.Button();
			this.left_rotation = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdCrop = new System.Windows.Forms.Button();
			this.clear_image = new System.Windows.Forms.Button();
			this.cmdDeskew = new System.Windows.Forms.Button();
			this.tkContrast = new System.Windows.Forms.NumericUpDown();
			this.lblContrast = new System.Windows.Forms.Label();
			this.tkBrightness = new System.Windows.Forms.NumericUpDown();
			this.lblBrightness = new System.Windows.Forms.Label();
			this.grpImage = new System.Windows.Forms.GroupBox();
			this.pnlImage = new System.Windows.Forms.Panel();
			this.pcbMain = new System.Windows.Forms.PictureBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.stsSplit = new System.Windows.Forms.StatusStrip();
			this.tstLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.tst2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.grpPath = new System.Windows.Forms.GroupBox();
			this.lvwFiles = new System.Windows.Forms.ListView();
			this.File_Name = new System.Windows.Forms.ColumnHeader();
			this.FName = new System.Windows.Forms.ColumnHeader();
			this.grpBrowse = new System.Windows.Forms.GroupBox();
			this.gotohelp = new System.Windows.Forms.Button();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.grouptools = new System.Windows.Forms.GroupBox();
			this.grplist1 = new System.Windows.Forms.ListView();
			this.grpname = new System.Windows.Forms.ColumnHeader();
			this.shrtcut = new System.Windows.Forms.ColumnHeader();
			this.gotocreategroup = new System.Windows.Forms.Button();
			this.groupcrt = new System.Windows.Forms.GroupBox();
			this.deletegrp = new System.Windows.Forms.Button();
			this.editgroup = new System.Windows.Forms.Button();
			this.grpTools.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tkContrast)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tkBrightness)).BeginInit();
			this.grpImage.SuspendLayout();
			this.pnlImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pcbMain)).BeginInit();
			this.stsSplit.SuspendLayout();
			this.grpPath.SuspendLayout();
			this.grpBrowse.SuspendLayout();
			this.grouptools.SuspendLayout();
			this.groupcrt.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpTools
			// 
			this.grpTools.Controls.Add(this.SaveAndMoveNext);
			this.grpTools.Controls.Add(this.despeckle_img);
			this.grpTools.Controls.Add(this.right_rotation);
			this.grpTools.Controls.Add(this.left_rotation);
			this.grpTools.Controls.Add(this.cmdSave);
			this.grpTools.Controls.Add(this.cmdCrop);
			this.grpTools.Controls.Add(this.clear_image);
			this.grpTools.Controls.Add(this.cmdDeskew);
			this.grpTools.Location = new System.Drawing.Point(18, 289);
			this.grpTools.Name = "grpTools";
			this.grpTools.Size = new System.Drawing.Size(106, 251);
			this.grpTools.TabIndex = 0;
			this.grpTools.TabStop = false;
			this.grpTools.Text = "Tools";
			// 
			// SaveAndMoveNext
			// 
			this.SaveAndMoveNext.Location = new System.Drawing.Point(6, 190);
			this.SaveAndMoveNext.Name = "SaveAndMoveNext";
			this.SaveAndMoveNext.Size = new System.Drawing.Size(100, 23);
			this.SaveAndMoveNext.TabIndex = 12;
			this.SaveAndMoveNext.Text = "Save and Next";
			this.SaveAndMoveNext.UseVisualStyleBackColor = true;
			this.SaveAndMoveNext.Click += new System.EventHandler(this.SaveAndMoveNextClick);
			// 
			// despeckle_img
			// 
			this.despeckle_img.Location = new System.Drawing.Point(6, 106);
			this.despeckle_img.Name = "despeckle_img";
			this.despeckle_img.Size = new System.Drawing.Size(100, 23);
			this.despeckle_img.TabIndex = 8;
			this.despeckle_img.Text = "Despeckle";
			this.despeckle_img.UseVisualStyleBackColor = true;
			this.despeckle_img.Click += new System.EventHandler(this.Despeckle_imgClick);
			// 
			// right_rotation
			// 
			this.right_rotation.Location = new System.Drawing.Point(6, 161);
			this.right_rotation.Name = "right_rotation";
			this.right_rotation.Size = new System.Drawing.Size(100, 23);
			this.right_rotation.TabIndex = 10;
			this.right_rotation.Text = "Right Rotate";
			this.right_rotation.UseVisualStyleBackColor = true;
			this.right_rotation.Click += new System.EventHandler(this.Right_rotationClick);
			// 
			// left_rotation
			// 
			this.left_rotation.Location = new System.Drawing.Point(6, 132);
			this.left_rotation.Name = "left_rotation";
			this.left_rotation.Size = new System.Drawing.Size(100, 23);
			this.left_rotation.TabIndex = 9;
			this.left_rotation.Text = "Rotate Left";
			this.left_rotation.UseVisualStyleBackColor = true;
			this.left_rotation.Click += new System.EventHandler(this.Left_rotationClick);
			// 
			// cmdSave
			// 
			this.cmdSave.Location = new System.Drawing.Point(6, 219);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(100, 23);
			this.cmdSave.TabIndex = 14;
			this.cmdSave.Text = "Save and Exit";
			this.cmdSave.UseVisualStyleBackColor = true;
			this.cmdSave.Click += new System.EventHandler(this.CmdSaveClick);
			// 
			// cmdCrop
			// 
			this.cmdCrop.Location = new System.Drawing.Point(6, 48);
			this.cmdCrop.Name = "cmdCrop";
			this.cmdCrop.Size = new System.Drawing.Size(100, 23);
			this.cmdCrop.TabIndex = 6;
			this.cmdCrop.Text = "Crop";
			this.cmdCrop.UseVisualStyleBackColor = true;
			this.cmdCrop.Click += new System.EventHandler(this.CmdCropClick);
			// 
			// clear_image
			// 
			this.clear_image.Location = new System.Drawing.Point(6, 19);
			this.clear_image.Name = "clear_image";
			this.clear_image.Size = new System.Drawing.Size(100, 23);
			this.clear_image.TabIndex = 5;
			this.clear_image.Text = "Clear Image";
			this.clear_image.UseVisualStyleBackColor = true;
			this.clear_image.Click += new System.EventHandler(this.Clear_imageClick);
			// 
			// cmdDeskew
			// 
			this.cmdDeskew.Location = new System.Drawing.Point(6, 77);
			this.cmdDeskew.Name = "cmdDeskew";
			this.cmdDeskew.Size = new System.Drawing.Size(100, 23);
			this.cmdDeskew.TabIndex = 7;
			this.cmdDeskew.Text = "Deskew";
			this.cmdDeskew.UseVisualStyleBackColor = true;
			this.cmdDeskew.Click += new System.EventHandler(this.CmdDeskewClick);
			// 
			// tkContrast
			// 
			this.tkContrast.Increment = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.tkContrast.Location = new System.Drawing.Point(5, 102);
			this.tkContrast.Minimum = new decimal(new int[] {
			100,
			0,
			0,
			0});
			this.tkContrast.Name = "tkContrast";
			this.tkContrast.Size = new System.Drawing.Size(100, 20);
			this.tkContrast.TabIndex = 4;
			this.tkContrast.Value = new decimal(new int[] {
			100,
			0,
			0,
			0});
			this.tkContrast.ValueChanged += new System.EventHandler(this.TkContrastValueChanged);
			// 
			// lblContrast
			// 
			this.lblContrast.Location = new System.Drawing.Point(5, 65);
			this.lblContrast.Name = "lblContrast";
			this.lblContrast.Size = new System.Drawing.Size(46, 13);
			this.lblContrast.TabIndex = 3;
			this.lblContrast.Text = "Contrast";
			// 
			// tkBrightness
			// 
			this.tkBrightness.Increment = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.tkBrightness.Location = new System.Drawing.Point(5, 42);
			this.tkBrightness.Minimum = new decimal(new int[] {
			100,
			0,
			0,
			0});
			this.tkBrightness.Name = "tkBrightness";
			this.tkBrightness.Size = new System.Drawing.Size(100, 20);
			this.tkBrightness.TabIndex = 2;
			this.tkBrightness.Value = new decimal(new int[] {
			100,
			0,
			0,
			0});
			this.tkBrightness.ValueChanged += new System.EventHandler(this.TkBrightnessValueChanged);
			// 
			// lblBrightness
			// 
			this.lblBrightness.Location = new System.Drawing.Point(5, 16);
			this.lblBrightness.Name = "lblBrightness";
			this.lblBrightness.Size = new System.Drawing.Size(56, 13);
			this.lblBrightness.TabIndex = 1;
			this.lblBrightness.Text = "Brightness";
			// 
			// grpImage
			// 
			this.grpImage.Controls.Add(this.pnlImage);
			this.grpImage.Location = new System.Drawing.Point(144, 95);
			this.grpImage.Name = "grpImage";
			this.grpImage.Size = new System.Drawing.Size(512, 411);
			this.grpImage.TabIndex = 1;
			this.grpImage.TabStop = false;
			this.grpImage.Text = "Image";
			// 
			// pnlImage
			// 
			this.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlImage.Controls.Add(this.pcbMain);
			this.pnlImage.Location = new System.Drawing.Point(22, 34);
			this.pnlImage.Name = "pnlImage";
			this.pnlImage.Size = new System.Drawing.Size(477, 358);
			this.pnlImage.TabIndex = 0;
			// 
			// pcbMain
			// 
			this.pcbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pcbMain.Location = new System.Drawing.Point(22, 13);
			this.pcbMain.Name = "pcbMain";
			this.pcbMain.Size = new System.Drawing.Size(426, 315);
			this.pcbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pcbMain.TabIndex = 0;
			this.pcbMain.TabStop = false;
			this.pcbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PcbMainPaint);
			this.pcbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PcbMainMouseDown);
			this.pcbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PcbMainMouseMove);
			this.pcbMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PcbMainMouseUp);
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(121, 97);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// stsSplit
			// 
			this.stsSplit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tstLeft,
			this.tst2});
			this.stsSplit.Location = new System.Drawing.Point(0, 710);
			this.stsSplit.Name = "stsSplit";
			this.stsSplit.Size = new System.Drawing.Size(785, 22);
			this.stsSplit.TabIndex = 2;
			this.stsSplit.Text = "statusStrip1";
			// 
			// tstLeft
			// 
			this.tstLeft.Name = "tstLeft";
			this.tstLeft.Size = new System.Drawing.Size(0, 17);
			// 
			// tst2
			// 
			this.tst2.Name = "tst2";
			this.tst2.Size = new System.Drawing.Size(0, 17);
			// 
			// grpPath
			// 
			this.grpPath.Controls.Add(this.lvwFiles);
			this.grpPath.Location = new System.Drawing.Point(12, 95);
			this.grpPath.Name = "grpPath";
			this.grpPath.Size = new System.Drawing.Size(112, 188);
			this.grpPath.TabIndex = 3;
			this.grpPath.TabStop = false;
			this.grpPath.Text = "Images";
			// 
			// lvwFiles
			// 
			this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.File_Name,
			this.FName});
			this.lvwFiles.Location = new System.Drawing.Point(6, 20);
			this.lvwFiles.Name = "lvwFiles";
			this.lvwFiles.Size = new System.Drawing.Size(100, 162);
			this.lvwFiles.TabIndex = 0;
			this.lvwFiles.UseCompatibleStateImageBehavior = false;
			this.lvwFiles.View = System.Windows.Forms.View.Details;
			this.lvwFiles.SelectedIndexChanged += new System.EventHandler(this.LvwFilesSelectedIndexChanged);
			// 
			// File_Name
			// 
			this.File_Name.Text = "Path";
			this.File_Name.Width = 0;
			// 
			// FName
			// 
			this.FName.Text = "File Name";
			this.FName.Width = 97;
			// 
			// grpBrowse
			// 
			this.grpBrowse.Controls.Add(this.gotohelp);
			this.grpBrowse.Controls.Add(this.btnBrowse);
			this.grpBrowse.Controls.Add(this.txtPath);
			this.grpBrowse.Location = new System.Drawing.Point(18, 12);
			this.grpBrowse.Name = "grpBrowse";
			this.grpBrowse.Size = new System.Drawing.Size(740, 71);
			this.grpBrowse.TabIndex = 4;
			this.grpBrowse.TabStop = false;
			this.grpBrowse.Text = "Browse";
			// 
			// gotohelp
			// 
			this.gotohelp.Location = new System.Drawing.Point(674, 25);
			this.gotohelp.Name = "gotohelp";
			this.gotohelp.Size = new System.Drawing.Size(48, 23);
			this.gotohelp.TabIndex = 1;
			this.gotohelp.Text = "Help";
			this.gotohelp.UseVisualStyleBackColor = true;
			this.gotohelp.Click += new System.EventHandler(this.GotohelpClick);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(534, 25);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 0;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
			// 
			// txtPath
			// 
			this.txtPath.Enabled = false;
			this.txtPath.Location = new System.Drawing.Point(14, 27);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(501, 20);
			this.txtPath.TabIndex = 0;
			// 
			// grouptools
			// 
			this.grouptools.Controls.Add(this.tkBrightness);
			this.grouptools.Controls.Add(this.tkContrast);
			this.grouptools.Controls.Add(this.lblBrightness);
			this.grouptools.Controls.Add(this.lblContrast);
			this.grouptools.Location = new System.Drawing.Point(674, 105);
			this.grouptools.Name = "grouptools";
			this.grouptools.Size = new System.Drawing.Size(99, 128);
			this.grouptools.TabIndex = 5;
			this.grouptools.TabStop = false;
			this.grouptools.Text = "Tools";
			// 
			// grplist1
			// 
			this.grplist1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.grpname,
			this.shrtcut});
			this.grplist1.FullRowSelect = true;
			this.grplist1.Location = new System.Drawing.Point(6, 19);
			this.grplist1.Name = "grplist1";
			this.grplist1.Size = new System.Drawing.Size(97, 91);
			this.grplist1.TabIndex = 6;
			this.grplist1.UseCompatibleStateImageBehavior = false;
			this.grplist1.View = System.Windows.Forms.View.Details;
			// 
			// grpname
			// 
			this.grpname.Text = "Group name";
			// 
			// shrtcut
			// 
			this.shrtcut.Text = "shortcut";
			// 
			// gotocreategroup
			// 
			this.gotocreategroup.Location = new System.Drawing.Point(6, 127);
			this.gotocreategroup.Name = "gotocreategroup";
			this.gotocreategroup.Size = new System.Drawing.Size(97, 23);
			this.gotocreategroup.TabIndex = 7;
			this.gotocreategroup.Text = "Create Group";
			this.gotocreategroup.UseVisualStyleBackColor = true;
			this.gotocreategroup.Click += new System.EventHandler(this.GotocreategroupClick);
			// 
			// groupcrt
			// 
			this.groupcrt.Controls.Add(this.deletegrp);
			this.groupcrt.Controls.Add(this.editgroup);
			this.groupcrt.Controls.Add(this.gotocreategroup);
			this.groupcrt.Controls.Add(this.grplist1);
			this.groupcrt.Location = new System.Drawing.Point(662, 239);
			this.groupcrt.Name = "groupcrt";
			this.groupcrt.Size = new System.Drawing.Size(117, 219);
			this.groupcrt.TabIndex = 8;
			this.groupcrt.TabStop = false;
			this.groupcrt.Text = "group show";
			// 
			// deletegrp
			// 
			this.deletegrp.Location = new System.Drawing.Point(7, 181);
			this.deletegrp.Name = "deletegrp";
			this.deletegrp.Size = new System.Drawing.Size(96, 23);
			this.deletegrp.TabIndex = 8;
			this.deletegrp.Text = "Delete Group";
			this.deletegrp.UseVisualStyleBackColor = true;
			this.deletegrp.Click += new System.EventHandler(this.DeletegrpClick);
			// 
			// editgroup
			// 
			this.editgroup.Location = new System.Drawing.Point(6, 156);
			this.editgroup.Name = "editgroup";
			this.editgroup.Size = new System.Drawing.Size(97, 23);
			this.editgroup.TabIndex = 1;
			this.editgroup.Text = "Edit Group";
			this.editgroup.UseVisualStyleBackColor = true;
			this.editgroup.Click += new System.EventHandler(this.EditgroupClick);
			// 
			// frm_enhance
			// 
			this.ClientSize = new System.Drawing.Size(785, 732);
			this.Controls.Add(this.groupcrt);
			this.Controls.Add(this.grouptools);
			this.Controls.Add(this.grpBrowse);
			this.Controls.Add(this.grpPath);
			this.Controls.Add(this.stsSplit);
			this.Controls.Add(this.grpImage);
			this.Controls.Add(this.grpTools);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_enhance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Image Enhancer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frm_enhanceKeyUp);
			this.Resize += new System.EventHandler(this.Frm_enhanceResize);
			this.grpTools.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tkContrast)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tkBrightness)).EndInit();
			this.grpImage.ResumeLayout(false);
			this.pnlImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pcbMain)).EndInit();
			this.stsSplit.ResumeLayout(false);
			this.stsSplit.PerformLayout();
			this.grpPath.ResumeLayout(false);
			this.grpBrowse.ResumeLayout(false);
			this.grpBrowse.PerformLayout();
			this.grouptools.ResumeLayout(false);
			this.groupcrt.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

			this.grpImage.ResumeLayout(false);
			this.pnlImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pcbMain)).EndInit();
			this.stsSplit.ResumeLayout(false);
			this.stsSplit.PerformLayout();
			this.grpPath.ResumeLayout(false);
			this.grpBrowse.ResumeLayout(false);
			this.grpBrowse.PerformLayout();
			this.grouptools.ResumeLayout(false);
			this.groupcrt.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.GroupBox grpBrowse;
		private System.Windows.Forms.GroupBox grpPath;
		private System.Windows.Forms.Label lblBrightness;
		private System.Windows.Forms.Label lblContrast;
		private System.Windows.Forms.NumericUpDown tkBrightness;
		private System.Windows.Forms.NumericUpDown tkContrast;
		private System.Windows.Forms.Button cmdCrop;
		private System.Windows.Forms.ToolStripStatusLabel tst2;
		private System.Windows.Forms.ToolStripStatusLabel tstLeft;
		private System.Windows.Forms.StatusStrip stsSplit;
		private System.Windows.Forms.PictureBox pcbMain;
		private System.Windows.Forms.Panel pnlImage;
		private System.Windows.Forms.Button cmdDeskew;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.GroupBox grpImage;
		private System.Windows.Forms.GroupBox grpTools;
		private System.Windows.Forms.Button clear_image;
		private System.Windows.Forms.ListView grplist1;
		private System.Windows.Forms.Button gotocreategroup;
		private System.Windows.Forms.Button despeckle_img;
		private System.Windows.Forms.Button deletegrp;
		private System.Windows.Forms.Button right_rotation;
		private System.Windows.Forms.Button left_rotation;
		private System.Windows.Forms.Button SaveAndMoveNext;
		private System.Windows.Forms.ColumnHeader File_Name;
		private System.Windows.Forms.ListView lvwFiles;
		private System.Windows.Forms.ColumnHeader FName;
		private System.Windows.Forms.GroupBox grouptools;
		private System.Windows.Forms.Button gotohelp;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.GroupBox groupcrt;
		private System.Windows.Forms.ColumnHeader grpname;
		private System.Windows.Forms.ColumnHeader shrtcut;
		private System.Windows.Forms.Button editgroup;
		//private System.Windows.Forms.Button deletegrp;
		//private System.Windows.Forms.ListView grplist1;
	}
}
