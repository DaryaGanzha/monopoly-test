using Microsoft.EntityFrameworkCore;
using MonopolyTest.EF;
using MonopolyTest.Interfaces;
using MonopolyTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyTest.Repositories
{
    internal class PalletRepository : IRepository<Pallet>
    {
        private ApplicationContext _context;
        public PalletRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Pallet pallet)
        {
            try
            {
                _context.Pallets.Add(pallet);
                _context.SaveChanges();
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("Pallet not found.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Database error.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Order is not created.", ex);
            }
        }

        public IEnumerable<Pallet> GetAll()
        {
            return _context.Pallets.ToList();
        }
        public void Update(Pallet pallet)
        {
            _context.Entry(pallet).State = EntityState.Modified;
        }
    }
}
