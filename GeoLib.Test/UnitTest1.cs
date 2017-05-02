using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeoLib.Data;
using GeoLib.Contracts;
using GeoLib.Services;

namespace GeoLib.Test
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void TestZipCodeRetrieval()
        {
            Mock<IZipCodeRepository> mockZipCodeRepo = new Mock<IZipCodeRepository>();
            ZipCode zipCode = new ZipCode()
            {
                City = "Lincoln Park",
                State = new State() { Abbreviation = "NJ" },
                Zip = "07035"
            };
            mockZipCodeRepo.Setup(obj => obj.GetByZip("07035")).Returns(zipCode);
            IGeoService geoService = new GeoManager(mockZipCodeRepo.Object);
            ZipCodeData data = geoService.GetZipInfo("07035");

            Assert.IsTrue(data.City.ToUpper() == "LINCOLN PARK");
            Assert.IsTrue(data.State == "NJ");

        }
    }
}
