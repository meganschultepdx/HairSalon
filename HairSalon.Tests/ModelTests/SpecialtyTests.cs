using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public void Dispose()
    {
      Specialty.ClearAll();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=megan_schulte_test;";
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("Ombre");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsAllSpecialtyObjects_SpecialtyList()
    {
      //Arrange
      Specialty newSpecialty1 = new Specialty("Ombre");
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty("Perm");
      newSpecialty2.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };

      //Act
      List<Specialty> result = Specialty.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Jonathan Van Ness");

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   //Arrange
    //   Stylist testStylist = new Stylist("Jonathan Van Ness");
    //   testStylist.Save();
    //
    //   //Act
    //   Stylist savedStylist = Stylist.GetAll()[0];
    //
    //   int result = savedStylist.Id;
    //   int testId = testStylist.Id;
    //
    //   //Assert
    //   Assert.AreEqual(testId, result);
    // }

    [TestMethod]
    public void Find_ReturnsSpecialtyInDatabase_Specialty()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Perm");
      testSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(testSpecialty.Id);

      //Assert
      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void GetStylists_ReturnsAllSpecialtyStylists_StylistList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("perm");
      testSpecialty.Save();
      Stylist testStylist1 = new Stylist("Jonathan Van Ness");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("bort");
      testStylist2.Save();

      //Act
      testSpecialty.AddStylist(testStylist1);
      List<Stylist> result = testSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist> {testStylist1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void AddStylist_AddsStylistToSpecialty_StylistList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("perm");
      testSpecialty.Save();
      Stylist testStylist = new Stylist("Jonathan Van Ness");
      testStylist.Save();

      //Act
      testSpecialty.AddStylist(testStylist);

      List<Stylist> result = testSpecialty.GetStylists();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetSpecialties_ReturnsAllStylistSpecialties_SpecialtyList()
    {
      //Arrange
      Stylist testStylist = new Stylist("borg");
      testStylist.Save();
      Specialty testSpecialty1 = new Specialty("trim");
      testSpecialty1.Save();
      Specialty testSpecialty2 = new Specialty("bowl cut");
      testSpecialty2.Save();

      //Act
      testStylist.AddSpecialty(testSpecialty1);
      List<Specialty> result = testStylist.GetSpecialties();
      List<Specialty> testList = new List<Specialty> {testSpecialty1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void AddSpecialty_AddsSpecialtyToStylist_SpecialtyList()
    {
      //Arrange
      Stylist testStylist = new Stylist("borg");
      testStylist.Save();
      Specialty testSpecialty = new Specialty("steps");
      testSpecialty.Save();

      //Act
      testStylist.AddSpecialty(testSpecialty);

      List<Specialty> result = testStylist.GetSpecialties();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesSpecialtyAssociationsFromDatabase_SpecialtyList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Jonathan Van Ness");
      testStylist.Save();
      Specialty testSpecialty = new Specialty("perm");
      testSpecialty.Save();

      //Act
      testSpecialty.AddStylist(testStylist);
      testSpecialty.Delete();
      List<Specialty> resultStylistSpecialties = testStylist.GetSpecialties();
      List<Specialty> testStylistSpecialties = new List<Specialty> {};

      //Assert
      CollectionAssert.AreEqual(testStylistSpecialties, resultStylistSpecialties);
    }



  }
}
