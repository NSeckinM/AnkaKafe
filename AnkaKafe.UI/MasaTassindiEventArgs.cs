﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkaKafe.UI
{
    //EVENT OLUŞTURMADA 1. ADIM
    //
    public class MasaTasindiEventArgs: EventArgs
    {
        public int EskiMasaNo { get; private set; }
        public int YeniMasaNo { get; private set; }
        public MasaTasindiEventArgs(int eskiMasaNo, int yeniMasaNo)
        {
            EskiMasaNo = eskiMasaNo;
            YeniMasaNo = yeniMasaNo;
        }

    }
}
