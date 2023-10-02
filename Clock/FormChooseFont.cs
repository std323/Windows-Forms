﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clock
{
	public partial class FormChooseFont : Form
	{
		PrivateFontCollection pfc;
		private Font  oldFont;
		private Font newFont;
		private string fontDirectory;

		public string FontDirectory
		{
			get { return fontDirectory; }
			set { fontDirectory = value; }
		}


		public Font NewFont
		{
			get { return newFont; }
			set { newFont = value; }
		}


		public Font OldFont
		{
			get { return   oldFont; }
			set {   oldFont = value; }
		}


		public FormChooseFont(Font font, string fontDirectory)
		{
			InitializeComponent();
			//SetFontDirectory();
			//pfc = new PrivateFontCollection();
			LoadFonts();
			OldFont = font;
			lblExample.Font = OldFont;
			FontDirectory = fontDirectory;
		}
		void SetFontDirectory()
		{
			string currentDirectory = System.IO.Directory.GetCurrentDirectory();
			if (currentDirectory == FontDirectory) return;
			//MessageBox.Show(this, currentDirectory, "Current directory", MessageBoxButtons.OK);
			string[] currentDirectoryItems = currentDirectory.Split('\\');
			Array.Resize(ref currentDirectoryItems, currentDirectoryItems.Length - 2);
			string newCurrentDirectory = "";
			foreach (string i in currentDirectoryItems)
			{
				newCurrentDirectory += i;
				newCurrentDirectory += "\\";
			}
			newCurrentDirectory += "Fonts";
			FontDirectory = newCurrentDirectory;
			//MessageBox.Show(this, $"{currentDirectory}\n{newCurrentDirectory}", "Current directory", MessageBoxButtons.OK);
			//this.fontDirectory = newCurrentDirectory;
			/*Directory.SetCurrentDirectory(FontDirectory);
			string[] fonts = Directory.GetFiles(newCurrentDirectory, "*.ttf");
			for (int i = 0; i < fonts.Length; i++)
			{
				string[] items = fonts[i].Split('\\');
				fonts[i] = items[items.Length - 1];
			}
			this.cbFont.Items.AddRange(fonts);
			//FontDirectory = newCurrentDirectory;*/
			LoadFonts();
		}

		public void LoadFonts()
		{
			Directory.SetCurrentDirectory(FontDirectory);
			Directory.SetCurrentDirectory(FontDirectory);
			string[] fonts = Directory.GetFiles(FontDirectory, "*.ttf");
			for (int i = 0; i < fonts.Length; i++)
			{
				string[] items = fonts[i].Split('\\');
				fonts[i] = items[items.Length - 1];
			}
			this.cbFont.Items.AddRange(fonts);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cbFont_SelectionChangeCommitted(object sender, EventArgs e)
		{
			//string currentDirectory = System.IO.Directory.GetCurrentDirectory();
			//MessageBox.Show(this, currentDirectory, "Current directory", MessageBoxButtons.OK);
			//string selectedFont = cbFont.SelectedItem.ToString();
			PrivateFontCollection pfc = new PrivateFontCollection();
			//pfc.AddFontFile(selectedFont);
			pfc.AddFontFile(cbFont.SelectedItem.ToString());
			//Font font = new Font(pfc.Families[0], lblExample.Font.Size);
			this.NewFont = new Font(pfc.Families[0], lblExample.Font.Size);
			//lblExample.Font = font;
			lblExample.Font = this.NewFont;
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			OldFont = NewFont;
			this.Close();
		}
	}
}
