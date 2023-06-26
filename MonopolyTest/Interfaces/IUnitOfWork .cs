using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyTest.Models;

namespace MonopolyTest.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        IRepository<Box> Boxes { get; }
        IRepository<Pallet> Pallets { get; }
        void Save();
    }
}
