using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelNew;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InfoPlaceTest()
        {
            //arrange
            int selectedid = 31;
            //act
            ShowQuery sq = new ShowQuery();
            sq.ShowPlace(selectedid);
            //assert
            Assert.Fail(); 
        }

    }
}
