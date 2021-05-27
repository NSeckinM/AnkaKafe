﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkaKafe.Data
{
    public class SiparisDetay
    {
        public string UrunAdi { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }

        public string TutarTl { get { return string.Format("₺{0:0.00}", Tutar()); } }

        public decimal Tutar()
        {
            return BirimFiyat * Adet;
        }

    }
}
