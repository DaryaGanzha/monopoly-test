using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyTest.Models
{
    public class Pallet
    {
        [Key]
        public Guid Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; } = 30;
        public double Volume { get; set; }
        public DateTime? Expiration_date { get; set; }
        public List<Box> Boxes { get; set; }
        public Pallet()
        {
            this.Expiration_date = DateTime.Now;
            this.Volume = Width * Height * Depth;
        }
        public void Update()
        {
            if (Boxes != null)
            {
                this.Weight = Weight + Boxes.Sum(b => b.Weight);
                this.Expiration_date = Boxes.Max(b => b.Expiration_date);
                this.Volume = Volume + Boxes.Sum(b => b.Value);
            }
        }
    }
}
