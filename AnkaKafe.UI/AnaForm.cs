﻿using AnkaKafe.Data;
using AnkaKafe.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnkaKafe.UI
{
    public partial class AnaForm : Form
    {
        KafeVeri db = new KafeVeri();
        public AnaForm()
        {
            InitializeComponent();
            OrnekUrunleriEkle();
            masalarImagelist.Images.Add("bos", Resource.bos);
            masalarImagelist.Images.Add("dolu", Resource.dolu);
            MasalariOlustur();
        }

        private void OrnekUrunleriEkle()
        {
            db.Urunler.Add(new Urun() { UrunAd = "Çay", BirimFiyat = 4.00m });
            db.Urunler.Add(new Urun() { UrunAd = "Simit", BirimFiyat = 5.00m });

        }

        private void MasalariOlustur()
        {

            ListViewItem lvi;
            for (int i = 1; i <= db.MasaAdet; i++)
            {
                lvi = new ListViewItem();
                lvi.Tag = i; // masa no sunu her bir öğenin Tag property'sinde sakladık.
                lvi.Text = "Masa" + i;
                lvi.ImageKey = "bos";
                lvwMasalar.Items.Add(lvi);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == TsmiUrunler)
            {
                new UrunlerForm().ShowDialog();
            }
            else if (e.ClickedItem == TsmiGecmissiparisler)
            {
                new GecmisSiparislerForm().ShowDialog();
            }
        }

        private void lvwMasalar_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwMasalar.SelectedItems[0];
            int masaNo = (int)lvi.Tag; // unboxing
            lvi.ImageKey = "dolu";

            Siparis siparis = SiparisBul(masaNo);

            if (siparis == null)
            {
                siparis = new Siparis() { MasaNo = masaNo };
                db.AktifSiparisler.Add(siparis);
            }
            
            SiparislerForm siparislerForm = new SiparislerForm(db,siparis);
            siparislerForm.Show();

        }
        private Siparis SiparisBul(int masaNo)
        {
           // return db.AktifSiparisler.FirstOrDefault(s => s.MasaNo == masaNo);

            foreach (Siparis siparis in db.AktifSiparisler)
            {
                if (siparis.MasaNo == masaNo)
                {
                    return siparis;
                }
            }
            return null;
        }
    }
}