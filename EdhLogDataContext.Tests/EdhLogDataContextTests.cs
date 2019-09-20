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
            DateTime toDt = DateTime.Parse("2019-09-20 04:00:00");
            DateTime fromDt = DateTime.Parse("2019-09-20 03:00:00");

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
            string processName = "1000 CRD Order ID Load";

            // Act
            var ProcessList = EdhLogDataContext.NameStartsWithQuery(processName);
            var count = ProcessList.Count;

            // Assert
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void Dc_RunsCombinedQuery()
        {
            // Arrange
            var queryParams = new QueryParams();
            queryParams.ProcessName = "Update CRD Fill ConfigBatchDate";
            queryParams.StartDate = DateTime.Parse("2019-09-20 03:15:00");
            queryParams.EndDate = DateTime.Parse("2019-09-20 03:16:00");

            // Act
            var ProcessList = EdhLogDataContext.ParamsQuery(queryParams);
            var count = ProcessList.Count;

            // Assert
            Assert.IsTrue(count > 0);
        }



    }
}
