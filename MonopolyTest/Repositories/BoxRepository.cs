using Microsoft.EntityFrameworkCore;
using MonopolyTest.EF;
using MonopolyTest.Interfaces;
using MonopolyTest.Models;
using System;
using System.Collections.Generic;

namespace MonopolyTest.Repositories
{
    internal class BoxRepository : IRepository<Box>
    {
        private ApplicationContext _context;
        public BoxRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Box entity)
        {
            try
            {
                _context.Boxes.Add(entity);
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

        public IEnumerable<Box> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Box box)
        {
            throw new NotImplementedException();
        }
    }
}
