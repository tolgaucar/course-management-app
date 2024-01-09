// dershane/Services/IOgrenciService.cs
using dershane.Data;
using dershane.Models;
using System.Collections.Generic;

namespace dershane.Services
{
    public interface IOgrenciService
    {
        List<Ogrenci> GetOgrenciler();
        void AddOgrenci(Ogrenci ogrenci);
        void UpdateOgrenci(Ogrenci ogrenci);
        void DeleteOgrenci(int ogrenciId);
        Ogrenci GetOgrenciById(int ogrenciId);
    }

    public class OgrenciService : IOgrenciService
    {
        private readonly ApplicationDbContext _context;

        public OgrenciService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ogrenci> GetOgrenciler()
        {
            return _context.Ogrencis.ToList();
        }

        public void AddOgrenci(Ogrenci ogrenci)
        {
            _context.Ogrencis.Add(ogrenci);
            _context.SaveChanges();
        }

        public void UpdateOgrenci(Ogrenci ogrenci)
        {
            var existingOgrenci = _context.Ogrencis.Find(ogrenci.Id);
            if (existingOgrenci != null)
            {
                existingOgrenci.OgrenciAdiSoyadi = ogrenci.OgrenciAdiSoyadi;
                existingOgrenci.TelefonNo = ogrenci.TelefonNo;
                existingOgrenci.OgrenciMailAdresi = ogrenci.OgrenciMailAdresi;

                _context.SaveChanges();
            }
        }

        public void DeleteOgrenci(int ogrenciId)
        {
            var ogrenci = _context.Ogrencis.Find(ogrenciId);
            if (ogrenci != null)
            {
                _context.Ogrencis.Remove(ogrenci);
                _context.SaveChanges();
            }
        }

        public Ogrenci GetOgrenciById(int ogrenciId)
        {
            return _context.Ogrencis.Find(ogrenciId);
        }
    }
}


