using TestConsole;
namespace TestWarehouseObject
{    
    public class TestConsoleTest
    {
        Warehouse warehouse = new Warehouse()
        {
            Pallets = new List<Pallet>()
                {
                    new Pallet(1,100,100,100)
                    {
                        Boxes = new List<Box>()
                        {
                            new Box(10, 50, 50, 40, 10) {ProductionDate = new DateTime(2023, 7, 1) },
                            new Box(10, 50, 50, 40, 7) {ProductionDate = new DateTime(2023, 7, 17) }
                        },
                    },
                    new Pallet(2,100,100,100)
                    {
                        Boxes = new List<Box>()
                        {
                            new Box(20, 50, 50, 40, 1) {ProductionDate = new DateTime(2023, 1, 1) }
                        },
                    },
                    new Pallet(3,100,100,100)
                    {
                        Boxes = new List<Box>()
                        {
                            new Box(30, 50, 50, 40, 8) {ProductionDate = new DateTime(2023, 5, 7) }
                        },
                    },
                }
        };

        [Fact]
        public void ExpirationDate()
        {
            var testing = warehouse.Pallets[0].ExpirationDate;

            
           
        }
    }
}