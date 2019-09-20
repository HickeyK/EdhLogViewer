using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataAccess;
using ViewModel;
using EdhLogViewer.Entities;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ViewModel.Tests
{
    [TestClass]
    public class ProcessLogViewModelTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dc = new Mock<IEdhLogDataContext>();
            dc.Setup(x => x.NameStartsWithQuery(It.IsAny<string>()))
                .Returns(
                new List<ProcessLog>( new ProcessLog[] { new ProcessLog("1","","","","","","") })
                );


            var vm = new ProcessLogViewModel(dc.Object);
            

            vm.RetrieveByProcessNameCommand.Execute("1000 CRD Order ID Load");

            Assert.IsNotNull(vm);
        }
    }
}
