using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelNew;

namespace UnitTesting
{
    [TestClass]
    public class ShowQueryUnitTest
    {
        [TestMethod]
        public void ShowQuery_CapitalTest()
        {
            //arrange
            int selectedid = 5;
            string capitalexpect = "Канберра";
            //act
            ShowQuery sq = new ShowQuery();
            sq.ShowPlace(selectedid);
            string capitalresult = InfoPlace.capital;
            bool actual = capitalexpect.Equals(capitalresult);
            bool expected = true;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShowQuery_CountryTest()
        {
            //arrange
            int selectedid = 5;
            string countryexpect = "Австрали";

            //act
            ShowQuery sq = new ShowQuery();
            sq.ShowPlace(selectedid);
            string countryresult = InfoPlace.country;
            bool actual = countryexpect.Equals(countryresult);
            bool expected = false;
            //assert
            Assert.AreEqual(expected, actual);
        }

       [TestMethod]
        public void ShowQuery_PlaceNameTest()
        {
            //arrange
            int selectedid = 5;
            string placenameexpect = "Сидней";

            //act
            ShowQuery sq = new ShowQuery();
            sq.ShowPlace(selectedid);
            string placenameresult = InfoPlace.placename;

            //assert
            Assert.AreEqual(placenameexpect, placenameresult);
        }

       [TestMethod]
       public void ShowQuery_IdCountryTest()
       {
           //arrange
           int selectedid = 5;
           int idcountry = 2;

           //act
           ShowQuery sq = new ShowQuery();
           sq.ShowPlace(selectedid);
           int idcountry_result= InfoPlace.idcountry;

           //assert
           Assert.AreEqual(idcountry, idcountry_result);
       }

       [TestMethod]
       public void ShowQuery_IdCityTest()
       {
           //arrange
           int selectedid = 5;
           string city = "Sidney";

           //act
           ShowQuery sq = new ShowQuery();
           sq.ShowPlace(selectedid);
           string city_result = InfoPlace.city;

           //assert
           Assert.AreEqual(city, city_result);
       }

       [TestMethod]
       public void ShowQuery_Currency_code_Test()
       {
           //arrange
           int selectedid = 5;
           string currency_code = "AUD";

           //act
           ShowQuery sq = new ShowQuery();
           sq.ShowPlace(selectedid);
           string currency_code_result = InfoPlace.currency_foreign_code;

           //assert
           Assert.AreEqual(currency_code, currency_code_result);
       }

       
    }
}
