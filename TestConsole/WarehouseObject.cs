using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public abstract class WarehouseObject
    {
        public int Id { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }      
        public abstract float Weight { get; }
        public abstract double Volume { get;}

        public WarehouseObject(int Id, float Height, float Width, float Depth)
        {
            this.Id = Id;
            this.Height = Height;
            this.Width = Width;
            this.Depth = Depth;
        }

    }
}
