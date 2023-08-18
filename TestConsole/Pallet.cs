using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Pallet : WarehouseObject
    {
        private float _Weight;     
        public List<Box> Boxes { get; set; }

        public DateTime ExpirationDate => Convert.ToDateTime(Boxes.Min(box => box.ExpirationDate)).Date;              
        
        public override float Weight => Boxes.Sum(box => box.Weight) + 30; 
        public override double Volume  => Boxes.Sum(box => box.Volume) + (Width * Height * Depth);
        public Pallet(int Id, float Height, float Width, float Depth) : base(Id, Height, Width, Depth)
        {
            
        }      
    }
}
