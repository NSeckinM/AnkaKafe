using AnkaKafe.Data;
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
    public partial class SiparislerForm : Form
    {
        private readonly KafeVeri _db;
        private readonly Siparis _siparis;
        public SiparislerForm(KafeVeri kafeVeri, Siparis siparis)
        {
            _db = kafeVeri;
            _siparis = siparis;
            InitializeComponent();
            FiyatGuncelle();
            MasaNoGuncelle();
            UrunleriGoster();
            DetaylarıListele();
           

        }


        private void UrunleriGoster()
        {
            cboUrun.DataSource = _db.Urunler;
        }

        private void FiyatGuncelle()
        {
            lblOdemeTutar.Text = _siparis.ToplamTutarTl;
        }

        private void MasaNoGuncelle()
        {
            Text = $"Masa {_siparis.MasaNo} siparis bilgileri";
            lblMasaNo.Text = _siparis.MasaNo.ToString("00");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urun urun = (Urun)cboUrun.SelectedItem;
            SiparisDetay siparisDetay = new SiparisDetay()
            {
                UrunAdi = urun.UrunAd,
                BirimFiyat = urun.BirimFiyat,
                Adet = (int)nudAdet.Value

            };
            _siparis.SiparisDetaylar.Add(siparisDetay);
            DetaylarıListele();
            FiyatGuncelle();
        }
        private void DetaylarıListele()
        {
            dgvSiparisDetay.DataSource = null;
            dgvSiparisDetay.DataSource = _siparis.SiparisDetaylar;
        }
        

    }
}
