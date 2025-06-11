using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mayinTarlasi
{
    public class Hucre
    {
        public bool MayinVarMi { get; set; }
        public bool AcildiMi { get; set; }
        public int EtrafindakiMayinSayisi { get; set; }
        public bool Isaretli { get; set; }

        public Hucre()
        {
            MayinVarMi = false;
            AcildiMi = false;
            EtrafindakiMayinSayisi = 0;
            Isaretli = false;
        }
    }

}
