using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Box : WarehouseObject 
    {
        private DateTime? _ExpirationDate;
        private DateTime? _ProductionDate;        
        public DateTime? ProductionDate
        {
            get => _ProductionDate;
            set
            {
               if(value == DateTime.MinValue)
                    value = null;
               else
               _ProductionDate = value;
            }
        }
        public DateTime? ExpirationDate
        {
            get => _ProductionDate!=null ? ProductionDate.Value.AddDays(100) :_ExpirationDate ;
            set => _ExpirationDate = value;
        }
        public override float Weight { get; } 
        public override double Volume => Width * Height * Depth;

        public Box(int Id, float Height, float Width, float Depth,float Weight) :base(Id, Height, Width, Depth) 
        {   
            this.Weight = Weight;                    
        }

    }
}
