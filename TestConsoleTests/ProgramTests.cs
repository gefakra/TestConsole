using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void PalletWeightTest()
        {
            var pallet = new Pallet(1, 100, 100, 10)
            {
                Boxes = new List<Box>() { new Box(1, 40, 40, 40, 20) { ProductionDate = new DateTime(2023, 1, 1) } }
            };
            var expected = 50f;
            Assert.AreEqual(expected, pallet.Weight);
        }

        [TestMethod()]
        public void PalleExpirationDateTest()
        {
            var pallet = new Pallet(1, 100, 100, 10)
            {
                Boxes = new List<Box>() 
                { 
                    new Box(1, 40, 40, 40, 20) { ProductionDate = new DateTime(2023, 1, 1) } ,
                    new Box(1, 40, 40, 40, 10) { ProductionDate = new DateTime(2023, 10, 1) } ,
                    new Box(1, 40, 40, 40, 2) { ProductionDate = new DateTime(2022, 1, 1) } ,
                }
            };
            var expected = new DateTime(2022,4,11);
            Assert.AreEqual(expected, pallet.ExpirationDate);
        }
        [TestMethod]
        public void OutputSortedGroupsTest()
        {
           var pallets = new List<Pallet>()
           {
                new Pallet(1,100,100,10)
                {
                    Boxes = new List<Box>(){
                        new Box(10, 40, 40, 40, 20) { ProductionDate = new DateTime(2023, 1, 1) }
                    }
                },
                new Pallet(2,100,100,10)
                {
                    Boxes = new List<Box>(){
                        new Box(20, 40, 50, 40, 10) { ProductionDate = new DateTime(2023, 1, 1) }
                    }
                },
                new Pallet(3,100,100,10)
                {
                    Boxes = new List<Box>(){
                        new Box(30, 40, 40, 40, 20) { ProductionDate = new DateTime(2023, 10, 1) }
                    }
                }
           };
            var expected = pallets.ElementAt(1);

            var testingGroup = pallets
                .GroupBy(p => p.ExpirationDate)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    ExpirationDate = g.Key,
                    SortedPallets = g.OrderBy(p => p.Weight)
                });

            Assert.AreEqual(expected, testingGroup.FirstOrDefault().SortedPallets.FirstOrDefault());
        }
    }
}