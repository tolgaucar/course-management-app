// Services/FinansalService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using dershane.Data;


namespace dershane.Services
{
    public interface IFinansalService
    {
        List<Finansal> GetFinansalIslemler();
        void AddFinansalIslem(Finansal finansal);
        void DeleteFinansalIslem(int id);
    }

    public class FinansalService : IFinansalService
    {
        private readonly ApplicationDbContext _dbContext;

        public FinansalService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Finansal> GetFinansalIslemler()
        {
            return _dbContext.Finansals.ToList();
        }

        public void AddFinansalIslem(Finansal finansal)
        {
            _dbContext.Finansals.Add(finansal);
            _dbContext.SaveChanges();
        }

        public void DeleteFinansalIslem(int id)
        {
            var finansal = _dbContext.Finansals.Find(id);

            if (finansal != null)
            {
                _dbContext.Finansals.Remove(finansal);
                _dbContext.SaveChanges();
            }
        }
    }
}