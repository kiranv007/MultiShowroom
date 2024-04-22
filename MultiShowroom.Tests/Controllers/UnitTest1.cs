using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiShowroom.Controllers;
using System;
using System.Web.Mvc;

namespace MultiShowroom.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            xunittestController controller = new xunittestController();

            // Act 
            ViewResult result = controller.Index() as ViewResult;

            //Assert 
            Assert.AreEqual("Yash", result.ViewBag.Sample);
        }
    }
}
