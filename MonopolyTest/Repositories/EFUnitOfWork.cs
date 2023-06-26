using MonopolyTest.EF;
using MonopolyTest.Interfaces;
using MonopolyTest.Models;
using System;

namespace MonopolyTest.Repositories
{
    internal class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        private BoxRepository _boxRepository;
        private PalletRepository _palletRepository;
        public EFUnitOfWork()
        {
            _context = new ApplicationContext();
        }
        public IRepository<Box> Boxes
        {
            get
            {
                if (_boxRepository == null)
                {
                    _boxRepository = new BoxRepository(_context);
                }
                return _boxRepository;
            }
        }

        public IRepository<Pallet> Pallets
        {
            get
            {
                if (_palletRepository == null)
                {
                    _palletRepository = new PalletRepository(_context);
                }
                return _palletRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
