using NUnit.Framework;
using MonopolyTest.Services;
using MonopolyTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyTest.DTO;
using MonopolyTest.Models;
using Assert = NUnit.Framework.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTesting
{
    [TestFixture]
    public class PalletTests
    {
        private IPalletService _palletService;
        [SetUp]
        public void SetUp()
        {
            _palletService = new PalletService();
        }

        [Test]
        [TestMethod]
        public void AddLargeBox_ThrowException()
        {
            var pallet = new PalletDTO { Width = 100, Height = 110, Depth = 120};
            _palletService.CreatePallet(pallet);

            List<Pallet> pallets = (List<Pallet>)_palletService.GetPallets();
            var littlePallet = pallets.FirstOrDefault(p => p.Width < 200 || p.Depth < 200);

            var box = new BoxDTO { Width = 110, Height = 10, Depth = 20, PalletId = littlePallet.Id, Weight = 9, Production_date = new DateTime(2022, 5, 20) };

            Assert.Catch<Exception>(() =>
            {
                _palletService.CreateBox(box, littlePallet);
            });
        }
    }
}
