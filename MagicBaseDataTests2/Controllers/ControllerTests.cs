using System.Collections.Generic;
using System.Linq;
using MagicBaseData.Controllers;
using MagicBaseData.Enums;
using MagicBaseData.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicBaseDataTests2.Controllers
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void SearchTest_ReturnValidData()
        {
            var controller = Controller.GetInstance();
            controller.Create(new Magician
            {
                Id = 1,
                KindOfMagic = KindOfMagic.Air,
                HitPoints = 200,
                Name = "Black Overlord",
                Power = 1000,
                Speed = 50
            });
            controller.Create(new Magician
            {
                Id = 2,
                KindOfMagic = KindOfMagic.Fire,
                HitPoints = 400,
                Name = "Negativ",
                Power = 2000,
                Speed = 100
            });
            var expectedResult = new List<Magician>
            {
                new Magician
                {
                    Id = 1,
                    KindOfMagic = KindOfMagic.Air,
                    HitPoints = 200,
                    Name = "Black Overlord",
                    Power = 1000,
                    Speed = 50
                }
            };
            var actualResult = controller.Search("Air").ToList();


            Assert.AreEqual(expectedResult[0], actualResult[0]);
        }

        [TestMethod]
        public void CheekTheSamePersonTest_NoSamePersons()
        {
            var controller = Controller.GetInstance();
            controller.Create(new Magician
            {
                Id = 1,
                KindOfMagic = KindOfMagic.Air,
                HitPoints = 200,
                Name = "Black Overlord",
                Power = 1000,
                Speed = 50
            });
            controller.Create(new Magician
            {
                Id = 2,
                KindOfMagic = KindOfMagic.Fire,
                HitPoints = 400,
                Name = "Negativ",
                Power = 2000,
                Speed = 100
            });
            controller.Create(new Magician
            {
                Id = 2,
                KindOfMagic = KindOfMagic.Fire,
                HitPoints = 400,
                Name = "Negativ",
                Power = 2000,
                Speed = 100
            });
            var expectedResult = new List<Magician>
            {
                new Magician
                {
                    Id = 1,
                    KindOfMagic = KindOfMagic.Air,
                    HitPoints = 200,
                    Name = "Black Overlord",
                    Power = 1000,
                    Speed = 50
                },
                new Magician
                {
                    Id = 2,
                    KindOfMagic = KindOfMagic.Fire,
                    HitPoints = 400,
                    Name = "Negativ",
                    Power = 2000,
                    Speed = 100
                }
            };
            
            controller.CheekTheSamePerson();
            var actualResult = controller.GetAll().ToList();

            for (var i = 0; i < actualResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i]);
            }
        }

        [TestMethod]
        public void IndexSearchTest_FindMagician()
        {
            var controller = Controller.GetInstance();
            controller.Create(new Magician
            {
                Id = 1,
                KindOfMagic = KindOfMagic.Air,
                HitPoints = 200,
                Name = "Black Overlord",
                Power = 1000,
                Speed = 50
            });
            controller.Create(new Magician
            {
                Id = 2,
                KindOfMagic = KindOfMagic.Fire,
                HitPoints = 400,
                Name = "Negativ",
                Power = 2000,
                Speed = 100
            });
            var expectedResult = new List<Magician>
            {
                new Magician
                {
                    Id = 1,
                    KindOfMagic = KindOfMagic.Air,
                    HitPoints = 200,
                    Name = "Black Overlord",
                    Power = 1000,
                    Speed = 50
                },
            };

            var actualResult = controller.indexSearch(1);

            for (var i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ToString(), actualResult);
            }
        }

        [TestMethod]
        public void IndexSearchTest_MagicianNotFound()
        {
            var controller = Controller.GetInstance();
            controller.Create(new Magician
            {
                Id = 1,
                KindOfMagic = KindOfMagic.Air,
                HitPoints = 200,
                Name = "Black Overlord",
                Power = 1000,
                Speed = 50
            });
            controller.Create(new Magician
            {
                Id = 2,
                KindOfMagic = KindOfMagic.Fire,
                HitPoints = 400,
                Name = "Negativ",
                Power = 2000,
                Speed = 100
            });
            var expectedResult = "Magician not found";

            var actualResult = controller.indexSearch(3);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IndexSearchTest_NoMagicianInDatabase()
        {
            var controller = Controller.GetInstance();
            var expectedResult = " ";

            var actualResult = controller.indexSearch(3);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}