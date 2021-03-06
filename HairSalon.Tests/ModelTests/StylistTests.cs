using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest: IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=megan_schulte_test;";
    }
    public void Dispose()
    {
      Stylist.ClearAll();
      // Client.ClearAll();
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("test stylist");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetStylistName_ReturnsStylistName_String()
    {
      //Arrange
      string stylistName = "Test Stylist";
      Stylist newStylist = new Stylist(stylistName);

      //Act
      string result = newStylist.StylistName;

      //Assert
      Assert.AreEqual(stylistName, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfStylistNamesAreTheSame_Stylist()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Gary Busey");
      Stylist secondStylist = new Stylist("Gary Busey");

      //Assert
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Gary Busey");
      testStylist.Save();

      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
      //Arrange
      Stylist testStylist = new Stylist("Gary Busey");
      testStylist.Save();

      //Act
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.Id;
      int testId = testStylist.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }


    [TestMethod]
    public void GetAll_ReturnsAllStylistObjects_StylistList()
    {
      //Arrange
      string name01 = "Gary Busey";
      string name02 = "Nick Turner";
      Stylist newStylist1 = new Stylist(name01);
      newStylist1.Save();
      Stylist newStylist2 = new Stylist(name02);
      newStylist2.Save();
      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

      //Act
      List<Stylist> result = Stylist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }


    [TestMethod]
    public void Find_ReturnsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Gary Busey");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.Id);

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
    }

    [TestMethod]
    public void GetClients_ReturnsEmptyClientList_ClientList()
    {
      //Arrange
      string stylistName = "gandolf";
      Stylist newStylist = new Stylist(stylistName);
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = newStylist.GetClients();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_StylistsEmptyAtFirst_List()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetClients_RetrievesAllClientsWithStylist_ClientList()
    {
      //Arrange, Act
      Stylist testStylist = new Stylist("Steve Buscemi");
      testStylist.Save();
      Client firstClient = new Client("Daniel Stern", testStylist.Id);
      firstClient.Save();
      Client secondClient = new Client("borg", testStylist.Id);
      secondClient.Save();
      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      //Assert
      CollectionAssert.AreEqual(testClientList, resultClientList);
    }

    [TestMethod]
    public void Delete_DeletesStylistAssociationsFromDatabase_StylistList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("fade");
      testSpecialty.Save();
      Stylist testStylist = new Stylist("Barth Martherson");
      testStylist.Save();

      //Act
      testStylist.AddSpecialty(testSpecialty);
      testStylist.Delete();
      List<Stylist> resultSpecialtyStylists = testSpecialty.GetStylists();
      List<Stylist> testSpecialtyStylists = new List<Stylist> {};

      //Assert
      CollectionAssert.AreEqual(testSpecialtyStylists, resultSpecialtyStylists);
    }

    [TestMethod]
    public void Edit_UpdatesStylistInDatabase_String()
    {
      //Arrange
      Stylist testStylist = new Stylist("Barth Martherson", 1);
      testStylist.Save();
      string secondStylistName = "Marth Martherson";

      //Act
      testStylist.Edit(secondStylistName);
      string result = Stylist.Find(testStylist.Id).StylistName;

      //Assert
      Assert.AreEqual(secondStylistName, result);
    }


  }
}
