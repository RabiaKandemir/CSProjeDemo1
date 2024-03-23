

using CSProjeDemo1.Entities.BaseClass;

namespace CSProjeDemo1.Entities.Abstract
{
    public interface IUye
    {
        public int Id { get; set; }
        string Ad { get; set; }
        List<Kitap> KitapListesi { get; set; }

        void KitapOduncAl(Kitap kitap);
        void KitapIadeEt(Kitap kitap);
        void OduncAlinanKitapListesi();
    }
}
