using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mayinTarlasi
{
    // Tahta.cs
    using System;

    public class Tahta
    {
        public int Satir { get; }
        public int Sutun { get; }
        public int MayinSayisi { get; }
        public Hucre[,] Hucreler { get; }

        public Tahta(int satir, int sutun, int mayinSayisi)
        {
            Satir = satir;
            Sutun = sutun;
            MayinSayisi = mayinSayisi;
            Hucreler = new Hucre[satir, sutun];
            for (int i = 0; i < satir; i++)
                for (int j = 0; j < sutun; j++)
                    Hucreler[i, j] = new Hucre();

            MayinlariYerlestir();
            EtrafMayinlariHesapla();
        }

        private void MayinlariYerlestir()
        {
            Random rnd = new Random();
            int yerlestirilen = 0;
            while (yerlestirilen < MayinSayisi)
            {
                int x = rnd.Next(Satir);
                int y = rnd.Next(Sutun);
                if (!Hucreler[x, y].MayinVarMi)
                {
                    Hucreler[x, y].MayinVarMi = true;
                    yerlestirilen++;
                }
            }
        }

        private void EtrafMayinlariHesapla()
        {
            for (int i = 0; i < Satir; i++)
            {
                for (int j = 0; j < Sutun; j++)
                {
                    if (Hucreler[i, j].MayinVarMi)
                    {
                        Hucreler[i, j].EtrafindakiMayinSayisi = -1;
                        continue;
                    }
                    int sayac = 0;
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            int nx = i + dx, ny = j + dy;
                            if (nx >= 0 && nx < Satir && ny >= 0 && ny < Sutun)
                                if (Hucreler[nx, ny].MayinVarMi)
                                    sayac++;
                        }
                    }
                    Hucreler[i, j].EtrafindakiMayinSayisi = sayac;
                }
            }
        }
    }
}
