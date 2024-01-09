public class Sinav
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public string Tarih { get; set; }
}

public class OgrenciNot
{
    public int Id { get; set; }
    public int OgrenciId { get; set; }
    public int SinavId { get; set; }
    public string OgrenciAdiSoyadi { get; set; }
    public string Not { get; set; }
}
