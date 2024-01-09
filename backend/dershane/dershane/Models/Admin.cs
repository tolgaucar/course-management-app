using System.ComponentModel.DataAnnotations;

public class Admin
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string KullaniciAdi { get; set; }

    [Required]
    public string Sifre { get; set; }
}
