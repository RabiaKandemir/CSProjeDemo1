

using CSProjeDemo1.Entities.Abstract;
using CSProjeDemo1.Entities.BaseClass;
using CSProjeDemo1.Entities.Enums;

namespace CSProjeDemo1.BaseClass
{
    public class Uye :IUye
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Kitap> KitapListesi { get; set; }
        public Uye(List<Kitap> _KitapListesi)
        {
            KitapListesi = _KitapListesi;
        }
        public void KitapOduncAl(Kitap kitap)
        {
            if (kitap.KitapDurumu == Durum.Mevcut)
            {
                KitapListesi.Add(kitap);
                kitap.KitapDurumu = Durum.OduncVerildi;
                Console.WriteLine($"{Ad}, {kitap.Baslik} adlı kitabı ödünç aldı.");
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} adlı kitap ödünç alınamaz.");
            }
        }

        public void KitapIadeEt(Kitap kitap)
        {
            if (KitapListesi.Contains(kitap))
            {
                KitapListesi.Remove(kitap);
                kitap.KitapDurumu = Durum.Mevcut;
                Console.WriteLine($"{Ad}, {kitap.Baslik} adlı kitabı iade etti.");
            }
            else
            {
                Console.WriteLine($"{Ad}, {kitap.Baslik} adlı kitabı ödünç almamış.");
            }
        }

        public void OduncAlinanKitapListesi()
        {
            Console.WriteLine($"{Ad} adlı uyenin ödünç aldığı kitaplar:");
            foreach (var kitap in KitapListesi)
            {
                Console.WriteLine($"{kitap.Baslik} ({kitap.KitapDurumu})");
            }
        }
    }
}
