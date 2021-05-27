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
        private readonly BindingList<SiparisDetay> _blSiparisDetaylar;
        public SiparislerForm(KafeVeri kafeVeri, Siparis siparis)
        {
            _db = kafeVeri;
            _siparis = siparis;
            _blSiparisDetaylar = new BindingList<SiparisDetay>(siparis.SiparisDetaylar);
            InitializeComponent();
            dgvSiparisDetay.AutoGenerateColumns = false;//Otomatik sütün oluşturmayı kapat.
            UrunleriGoster();
            EkleFormSifirla();
            MasaNoGuncelle();
            FiyatGuncelle();
            DetaylarıListele();
            _blSiparisDetaylar.ListChanged += _blSiparisDetaylar_ListChanged;


        }

        private void _blSiparisDetaylar_ListChanged(object sender, ListChangedEventArgs e)
        {
            FiyatGuncelle();
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
            if (cboUrun.SelectedIndex == -1|| nudAdet.Value<1) return; //seçili ürün yoksa bu satır.
            Urun urun = (Urun)cboUrun.SelectedItem;


            SiparisDetay siparisDetay = new SiparisDetay()
            {
                UrunAdi = urun.UrunAd,
                BirimFiyat = urun.BirimFiyat,
                Adet = (int)nudAdet.Value

            };
            _blSiparisDetaylar.Add(siparisDetay);
            EkleFormSifirla();

        }

        private void EkleFormSifirla()
        {
            cboUrun.SelectedIndex = -1;
            nudAdet.Value = 1;
        }

        private void DetaylarıListele()
        {
            dgvSiparisDetay.DataSource = _blSiparisDetaylar;
        }

        private void dgvSiparisDetay_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {//9.overloadı kullandı.

            DialogResult dr = MessageBox.Show(
                text:"Seçili sipariş detayları Silinecektir. Onaylıyor musun ?",
                caption:"Silme Onayı",
                buttons:MessageBoxButtons.YesNo,
                icon:MessageBoxIcon.Exclamation,
                defaultButton:MessageBoxDefaultButton.Button2

                );
            //True atamanız sonucunda silme işlemine geçmiş oluyor.
            e.Cancel = dr == DialogResult.No;
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            SiparisKapat(SiparisDurum.Odendi, _siparis.ToplamTutar());
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            SiparisKapat(SiparisDurum.Iptal, 0);
        }
        private void SiparisKapat(SiparisDurum siparisDurum,decimal odenenTutar)
        {
            _siparis.Durum = siparisDurum;
            _siparis.KapanisZamani = DateTime.Now;
            _db.AktifSiparisler.Remove(_siparis);
            _db.GecmisSiparisler.Add(_siparis);
            Close();
        }

    }
}
