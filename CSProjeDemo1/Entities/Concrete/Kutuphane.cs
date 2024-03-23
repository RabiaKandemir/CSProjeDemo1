

using CSProjeDemo1.Entities.Abstract;
using CSProjeDemo1.Entities.BaseClass;
using CSProjeDemo1.Entities.Concrete;
using CSProjeDemo1.Entities.Enums;

namespace CSProjeDemo1.Entities.Entities
{
    public class Kutuphane
    {
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public List<IUye> Uyeler { get; set; } = new List<IUye>();

        private Dictionary<Type, List<Kitap>> kitapTurleri = new Dictionary<Type, List<Kitap>>();

        public Kutuphane()
        {
            kitapTurleri[typeof(KitapBilim)] = new List<Kitap>();
            kitapTurleri[typeof(KitapRoman)] = new List<Kitap>();
            kitapTurleri[typeof(KitapTarih)] = new List<Kitap>();
        }
        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            Type kitapTuru = kitap.GetType();
            if (kitapTurleri.ContainsKey(kitapTuru))
            {
                kitapTurleri[kitapTuru].Add(kitap);
            }
            else
            {
                Console.WriteLine("Geçersiz kitap türü.");
            }
            Console.WriteLine($"{kitap.Baslik} adlı kitap kütüphaneye eklendi.");
        }

        public void KitapKaldir(Kitap kitap)
        {
            if (Kitaplar.Contains(kitap))
            {
                Kitaplar.Remove(kitap);
                Console.WriteLine($"{kitap.Baslik} adlı kitap kütüphaneden kaldırıldı.");
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} adlı kitap kütüphanede bulunamadı.");
            }
        }
        public void KitapOduncVer(IUye uye, Kitap kitap)
        {
            if (Kitaplar.Contains(kitap) && kitap.KitapDurumu == Durum.Mevcut)
            {
                uye.KitapOduncAl(kitap);
                kitap.KitapDurumu = Durum.OduncVerildi;
            }
            else
            {
                Console.WriteLine($"Ödünç verilecek kitap mevcut değil veya ödünç alınamaz durumda.");
            }
        }
        public void KitapIadeAl(IUye uye, Kitap kitap)
        {
            if (uye.KitapListesi.Contains(kitap))
            {
                uye.KitapIadeEt(kitap);
                kitap.KitapDurumu = Durum.Mevcut;
            }
            else
            {
                Console.WriteLine($"İade edilecek kitap üyenin ödünç aldığı kitaplar arasında bulunamadı.");
            }
        }

        public void OduncAlinanKitaplariListele()
        {
            Console.WriteLine("Ödünç Alınan Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                if (kitap.KitapDurumu == Durum.OduncVerildi)
                {
                    foreach (var uye in Uyeler)
                    {
                        if (uye.KitapListesi.Contains(kitap))
                        {
                            Console.WriteLine($"Kitap: {kitap.Baslik}, Ödünç Alan Üye: {uye.Ad}");
                            break; 
                        }
                    }
                }
            }
        }

        public void UyeListesiniGoruntule()
        {
            Console.WriteLine("Kütüphane Üyeleri:");
            foreach (var uye in Uyeler)
            {
                Console.WriteLine($"Ad: {uye.Ad}");
            }
        }

        public void MevcutKitaplariGoruntule()
        {
            Console.WriteLine("Mevcut Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                if (kitap.KitapDurumu == Durum.Mevcut)
                {
                    Console.WriteLine($"{kitap.Baslik}");
                }
            }
        }
    }
}
