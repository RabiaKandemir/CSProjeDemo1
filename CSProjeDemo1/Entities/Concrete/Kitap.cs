

using CSProjeDemo1.Entities.Enums;

namespace CSProjeDemo1.Entities.BaseClass
{
    public abstract class Kitap
    {
        public string ISBN { get; set; }
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public int YayinYili { get; set; }
        public Durum KitapDurumu { get; set; }
    }
}
