﻿
namespace AnkaKafe.UI
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TsmiUrunler = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiGecmissiparisler = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwMasalar = new System.Windows.Forms.ListView();
            this.masalarImagelist = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiUrunler,
            this.TsmiGecmissiparisler});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // TsmiUrunler
            // 
            this.TsmiUrunler.Name = "TsmiUrunler";
            this.TsmiUrunler.Size = new System.Drawing.Size(71, 24);
            this.TsmiUrunler.Text = "Ürünler";
            // 
            // TsmiGecmissiparisler
            // 
            this.TsmiGecmissiparisler.Name = "TsmiGecmissiparisler";
            this.TsmiGecmissiparisler.Size = new System.Drawing.Size(136, 24);
            this.TsmiGecmissiparisler.Text = "Geçmiş Siparişler";
            // 
            // lvwMasalar
            // 
            this.lvwMasalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMasalar.HideSelection = false;
            this.lvwMasalar.LargeImageList = this.masalarImagelist;
            this.lvwMasalar.Location = new System.Drawing.Point(0, 28);
            this.lvwMasalar.Name = "lvwMasalar";
            this.lvwMasalar.Size = new System.Drawing.Size(800, 422);
            this.lvwMasalar.TabIndex = 1;
            this.lvwMasalar.UseCompatibleStateImageBehavior = false;
            this.lvwMasalar.DoubleClick += new System.EventHandler(this.lvwMasalar_DoubleClick);
            // 
            // masalarImagelist
            // 
            this.masalarImagelist.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.masalarImagelist.ImageSize = new System.Drawing.Size(64, 64);
            this.masalarImagelist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwMasalar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaForm";
            this.Text = "Anka Cafe Siparis Takip Otomasyonu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView lvwMasalar;
        private System.Windows.Forms.ToolStripMenuItem TsmiUrunler;
        private System.Windows.Forms.ToolStripMenuItem MsToolGecmissiparisler;
        private System.Windows.Forms.ToolStripMenuItem TsmiGecmissiparisler;
        private System.Windows.Forms.ImageList masalarImagelist;
    }
}