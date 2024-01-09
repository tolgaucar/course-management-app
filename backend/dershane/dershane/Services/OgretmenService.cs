// dershane/Services/IOgretmenService.cs
using dershane.Data;
using dershane.Models;
using System.Collections.Generic;

namespace dershane.Services
{
    public interface IOgretmenService
    {
        List<Ogretmen> GetOgretmenler();
        void AddOgretmen(Ogretmen ogretmen);
        void UpdateOgretmen(Ogretmen ogretmen);
        void DeleteOgretmen(int ogretmenId);
        Ogretmen GetOgretmenById(int ogretmenId);
    }

    public class OgretmenService : IOgretmenService
    {
        private readonly ApplicationDbContext _context;

        public OgretmenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ogretmen> GetOgretmenler()
        {
            return _context.Ogretmens.ToList();
        }

        public void AddOgretmen(Ogretmen ogretmen)
        {
            _context.Ogretmens.Add(ogretmen);
            _context.SaveChanges();
        }

        public void UpdateOgretmen(Ogretmen ogretmen)
        {
            var existingOgretmen = _context.Ogretmens.Find(ogretmen.Id);
            if (existingOgretmen != null)
            {
                existingOgretmen.OgretmenAdiSoyadi = ogretmen.OgretmenAdiSoyadi;
                existingOgretmen.TelefonNo = ogretmen.TelefonNo;
                existingOgretmen.OgretmenMailAdresi = ogretmen.OgretmenMailAdresi;

                _context.SaveChanges();
            }
        }

        public void DeleteOgretmen(int ogretmenId)
        {
            var ogretmen = _context.Ogretmens.Find(ogretmenId);
            if (ogretmen != null)
            {
                _context.Ogretmens.Remove(ogretmen);
                _context.SaveChanges();
            }
        }

        public Ogretmen GetOgretmenById(int ogretmenId)
        {
            return _context.Ogretmens.Find(ogretmenId);
        }
    }
}


