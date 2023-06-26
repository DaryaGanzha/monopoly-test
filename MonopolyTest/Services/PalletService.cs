using Microsoft.EntityFrameworkCore;
using MonopolyTest.DTO;
using MonopolyTest.Interfaces;
using MonopolyTest.Models;
using MonopolyTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonopolyTest.Services
{
    public class PalletService : IPalletService
    {
        private IUnitOfWork database;
        public PalletService()
        {
            this.database = new EFUnitOfWork();
        }

        public void CreatePallet(PalletDTO palletDTO)
        {
            var pallet = new Pallet()
            {
                Width = palletDTO.Width,
                Height = palletDTO.Height,
                Depth = palletDTO.Depth,
            };
            database.Pallets.Create(pallet);
            database.Save();
        }

        public IEnumerable<Pallet> GetPallets()
        {
            return database.Pallets.GetAll();
        }

        public void CreateBox(BoxDTO boxDTO, Pallet pallet)
        {
            if (pallet.Width < boxDTO.Width || pallet.Depth < boxDTO.Depth)
            {
                throw new Exception("The box is too big.");
            }
            else
            {
                var box = new Box() { 
                    Width = boxDTO.Width, 
                    Height = boxDTO.Height,
                    Depth = boxDTO.Depth,
                    Weight = boxDTO.Weight,
                    Production_date = boxDTO.Production_date,
                    PalletId = boxDTO.PalletId,
                };
                database.Boxes.Create(box);
                pallet.Update();
                database.Save();
            }
        }

        public IEnumerable<dynamic> GroupPallets()
        {
            var sortedPallets = from pallet in database.Pallets.GetAll()
                                orderby pallet.Expiration_date
                                group pallet by pallet.Expiration_date into groupedPallets
                                select new
                                {
                                    ExpirationDate = groupedPallets.Key,
                                    Pallets = from pallet in groupedPallets
                                              orderby pallet.Weight
                                              select pallet
                                };
            return sortedPallets;
        }

        public IEnumerable<dynamic> TopThreePallets()
        {
            var pallets = database.Pallets.GetAll()
                .Where(p => p.Boxes != null && p.Boxes.Any())
                .OrderBy(p => p.Volume)
                .Select(p => new
                {
                    Pallet = p,
                    MaxExpirationDate = p.Boxes.Max(b => b.Expiration_date)
                })
                .OrderByDescending(p => p.MaxExpirationDate)
                .Take(3)
                .Select(p => p.Pallet)
                .ToList();
            return pallets;
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
