// dershane/Services/ISinavService.cs
using dershane.Data;
using dershane.Models;
using System.Collections.Generic;

namespace dershane.Services
{
    public interface ISinavService
    {
        List<Sinav> GetSinavler();
        void AddSinav(Sinav sinav);
        void UpdateSinav(Sinav sinav);
        void DeleteSinav(int Id);
        Sinav GetSinavById(int Id);
    }

    public class SinavService : ISinavService
    {
        private readonly ApplicationDbContext _context;

        public SinavService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sinav> GetSinavler()
        {
            return _context.Sinavs.ToList();
        }

        public void AddSinav(Sinav sinav)
        {
            _context.Sinavs.Add(sinav);
            _context.SaveChanges();
        }

        public void UpdateSinav(Sinav sinav)
        {
            var existingSinav = _context.Sinavs.Find(sinav.Id);
            if (existingSinav != null)
            {
                existingSinav.Adi = sinav.Adi;
                existingSinav.Tarih = sinav.Tarih;

                _context.SaveChanges();
            }
        }

        public void DeleteSinav(int Id)
        {
            var sinav = _context.Sinavs.Find(Id);
            if (sinav != null)
            {
                _context.Sinavs.Remove(sinav);
                _context.SaveChanges();
            }
        }

        public Sinav GetSinavById(int Id)
        {
            return _context.Sinavs.Find(Id);
        }
    }
}


