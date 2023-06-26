using MonopolyTest.DTO;
using MonopolyTest.Models;
using System.Collections.Generic;

namespace MonopolyTest.Interfaces
{
    public interface IPalletService
    {
        void CreatePallet(PalletDTO pallet);
        IEnumerable<Pallet> GetPallets();
        void CreateBox(BoxDTO box, Pallet pallet);
        IEnumerable<dynamic> GroupPallets();
        IEnumerable<dynamic> TopThreePallets();
        void Dispose();
    }
}
