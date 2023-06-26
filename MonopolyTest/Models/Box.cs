using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTest.Models
{
    public class Box
    {
        [Key]
        public Guid Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
        private DateTime production_date;
        public DateTime Production_date
        {
            get { return production_date; }
            set
            {
                production_date = value;
                Expiration_date = production_date.AddDays(100);
            }
        }
        public DateTime Expiration_date { get; set; }
        public Guid PalletId { get; set; }
        public Pallet Pallet { get; set; }
        public Box()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
