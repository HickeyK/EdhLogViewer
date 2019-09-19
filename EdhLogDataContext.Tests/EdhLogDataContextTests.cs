using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EdhLogViewer.Entities;

namespace DataAccess.Tests
{
    [TestClass]
    public class EdhLogDataContextTests : DatabaseFixture
    {
        [TestMethod]
        public void Ctor_DoesNotReturnNull()
        {
            Assert.IsNotNull(this.EdhLogDataContext);
        }


        [TestMethod]
        public void Dc_RunsTimeQuery()
        {
            // Arrange
            DateTime toDt = DateTime.Now;
            DateTime fromDt = toDt.AddMinutes(-10);

            // Act
            var ProcessList = EdhLogDataContext.TimeQuery(fromDt, toDt);
            var count = ProcessList.Count;

            // Assert
            Assert.IsTrue(count > 0);
        }
        [TestMethod]
        public void Dc_RunsStartsWithQuery()
        {
            // Arrange
            string processName = "Update DHB";

            // Act
            var ProcessList = EdhLogDataContext.NameStartsWithQuery(processName);
            var count = ProcessList.Count;

            // Assert
            Assert.IsTrue(count > 0);
        }

    }
}
