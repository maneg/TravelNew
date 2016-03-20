using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelNew;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShowQueryTest()
        {
            //arrange
            int selectedid = 5;
          //  string countryexpect = "Австрали";
         //   string placenameexpect = "Сидней";
            string capitalexpect = "Канберра";
            //act
            ShowQuery sq = new ShowQuery();
            sq.ShowPlace(selectedid);
         //   string countryresult = InfoPlace.country;
         //   string placenameresult = InfoPlace.placename;
            string capitalresult = InfoPlace.capital;

            //assert
       //     Assert.AreEqual(countryexpect, countryresult);
       //     Assert.AreEqual(placenameexpect, countryresult);
            Assert.AreEqual(capitalexpect, capitalresult);
        }

        //[TestMethod]
        //public void MainWindowTest()
        //{
        //    //arrange
        //    int selectedid = 5;
        //    string countryexpect = "Австрали";
        //    string placenameexpect = "Сидней";
        //    string capitalexpect = "Канберра";
        //    //act
        //    ShowQuery sq = new ShowQuery();
        //    sq.ShowPlace(selectedid);
        //    string countryresult = InfoPlace.country;
        //    string placenameresult = InfoPlace.placename;
        //    string capitalresult = InfoPlace.capital;

        //    //assert
        //    Assert.AreEqual(countryexpect, countryresult);
        //    Assert.AreEqual(placenameexpect, countryresult);
        //    Assert.AreEqual(capitalexpect, countryresult);
        //}

    }
}
