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
        //2. adım
        // eventhandler delegesi ile event oluşturulur.
        // eger event ile ilgili argümanlar varsa generik olan kullanılır.
        public event EventHandler<MasaTasindiEventArgs> MasaTasindi;

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
            MasaNolariDoldur();
            _blSiparisDetaylar.ListChanged += _blSiparisDetaylar_ListChanged;


        }

        private void MasaNolariDoldur()
        {
            //List<int> bosMasaNolar = new List<int>();
            //for (int i = 1; i < _db.MasaAdet; i++)
            //{
            //    // aktif siparişlerde i masa nosuna sahip sipariş var değilse / yoksa
            //    if (!_db.AktifSiparisler.Any(x => x.MasaNo == i))
            //    {
            //        bosMasaNolar.Add(i);
            //    }
            //}
            //cboMasaNo.DataSource = bosMasaNolar;

            cboMasaNo.DataSource = Enumerable
                .Range(1, 20)
                .Where(i =>! _db.AktifSiparisler
                .Any(s => s.MasaNo == i))
                .ToList();

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

        private void BtnTasi_Click(object sender, EventArgs e)
        {
            if (cboMasaNo.SelectedIndex == -1) return;
            int eskiMasaNo = _siparis.MasaNo;
            int yeniMasaNo = (int)cboMasaNo.SelectedItem;
            _siparis.MasaNo = yeniMasaNo;

            MasaNolariDoldur();// dolu masalar değişti.

            // 3. Adım
            // event e atanmış bir metot var ise uygun noktada uygun argümanlarla metot çağırılır.

            if (MasaTasindi != null)
            {
                MasaTasindi(this, new MasaTasindiEventArgs(eskiMasaNo, yeniMasaNo));
            }
            MasaNoGuncelle();

        }
    }
}
