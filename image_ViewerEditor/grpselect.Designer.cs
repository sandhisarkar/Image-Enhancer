/*
 * Created by SharpDevelop.
 * User: Jyotipriyar
 * Date: 29-06-2017
 * Time: 18:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace image_ViewerEditor
{
	partial class grpselect
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox grptxt;
		private System.Windows.Forms.Label grpname;
		private System.Windows.Forms.ListBox cmdname;
		private System.Windows.Forms.ListView grplist;
		private System.Windows.Forms.Button sendtolistview;
		private System.Windows.Forms.Button shortcut;
		private System.Windows.Forms.Button savegrp;
		private System.Windows.Forms.Button cancelgrp;
		
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
			this.grptxt = new System.Windows.Forms.TextBox();
			this.grpname = new System.Windows.Forms.Label();
			this.cmdname = new System.Windows.Forms.ListBox();
			this.grplist = new System.Windows.Forms.ListView();
			this.sendtolistview = new System.Windows.Forms.Button();
			this.shortcut = new System.Windows.Forms.Button();
			this.savegrp = new System.Windows.Forms.Button();
			this.cancelgrp = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// grptxt
			// 
			this.grptxt.Location = new System.Drawing.Point(146, 21);
			this.grptxt.Name = "grptxt";
			this.grptxt.Size = new System.Drawing.Size(166, 20);
			this.grptxt.TabIndex = 0;
			// 
			// grpname
			// 
			this.grpname.Location = new System.Drawing.Point(40, 21);
			this.grpname.Name = "grpname";
			this.grpname.Size = new System.Drawing.Size(100, 23);
			this.grpname.TabIndex = 1;
			this.grpname.Text = "Group Name";
			// 
			// cmdname
			// 
			this.cmdname.FormattingEnabled = true;
			this.cmdname.Location = new System.Drawing.Point(40, 79);
			this.cmdname.Name = "cmdname";
			this.cmdname.Size = new System.Drawing.Size(130, 277);
			this.cmdname.TabIndex = 2;
			// 
			// grplist
			// 
			this.grplist.Location = new System.Drawing.Point(247, 79);
			this.grplist.Name = "grplist";
			this.grplist.Size = new System.Drawing.Size(179, 277);
			this.grplist.TabIndex = 3;
			this.grplist.UseCompatibleStateImageBehavior = false;
			// 
			// sendtolistview
			// 
			this.sendtolistview.Location = new System.Drawing.Point(188, 201);
			this.sendtolistview.Name = "sendtolistview";
			this.sendtolistview.Size = new System.Drawing.Size(44, 23);
			this.sendtolistview.TabIndex = 4;
			this.sendtolistview.Text = ">>";
			this.sendtolistview.UseVisualStyleBackColor = true;
			this.sendtolistview.Click += new System.EventHandler(this.SendtolistviewClick);
			// 
			// shortcut
			// 
			this.shortcut.Location = new System.Drawing.Point(40, 398);
			this.shortcut.Name = "shortcut";
			this.shortcut.Size = new System.Drawing.Size(75, 23);
			this.shortcut.TabIndex = 5;
			this.shortcut.Text = "ShortCut";
			this.shortcut.UseVisualStyleBackColor = true;
			// 
			// savegrp
			// 
			this.savegrp.Location = new System.Drawing.Point(188, 398);
			this.savegrp.Name = "savegrp";
			this.savegrp.Size = new System.Drawing.Size(75, 23);
			this.savegrp.TabIndex = 6;
			this.savegrp.Text = "Save";
			this.savegrp.UseVisualStyleBackColor = true;
			this.savegrp.Click += new System.EventHandler(this.SavegrpClick);
			// 
			// cancelgrp
			// 
			this.cancelgrp.Location = new System.Drawing.Point(313, 398);
			this.cancelgrp.Name = "cancelgrp";
			this.cancelgrp.Size = new System.Drawing.Size(75, 23);
			this.cancelgrp.TabIndex = 7;
			this.cancelgrp.Text = "Cancel";
			this.cancelgrp.UseVisualStyleBackColor = true;
			this.cancelgrp.Click += new System.EventHandler(this.CancelgrpClick);
			// 
			// grpselect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 517);
			this.Controls.Add(this.cancelgrp);
			this.Controls.Add(this.savegrp);
			this.Controls.Add(this.shortcut);
			this.Controls.Add(this.sendtolistview);
			this.Controls.Add(this.grplist);
			this.Controls.Add(this.cmdname);
			this.Controls.Add(this.grpname);
			this.Controls.Add(this.grptxt);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "grpselect";
			this.Text = "grpselect";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
