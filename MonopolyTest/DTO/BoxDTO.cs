using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTest.DTO
{
    public class BoxDTO
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public DateTime Production_date { get; set; }
        public Guid PalletId { get; set; }
    }
}
