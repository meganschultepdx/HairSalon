using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=megan_schulte_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("test", 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetClientName_ReturnsClientName_String()
    {
      //Arrange
      string clientName = "Steve Buscemi";
      Client newClient = new Client(clientName, 1);

      //Act
      string result = newClient.ClientName;

      //Assert
      Assert.AreEqual(clientName, result);
    }


    [TestMethod]
    public void Equals_ReturnsTrueIfClinetNamesAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("Steve Buscemi", 1);
      Client secondClient = new Client("Steve Buscemi", 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
    {
      //Arrange
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      string clientName01 = "Steve Buscemi";
      string clientName02 = "Daniel Stern";
      Client newClient1 = new Client(clientName01, 1);
      newClient1.Save();
      Client newClient2 = new Client(clientName02, 1);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Steve Buscemi", 1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Steve Buscemi", 1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.Id);

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("Daniel Stern", 1);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.Id;
      int testId = testClient.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      //Arrange
      Client testClient = new Client("Steve Buscemi", 1);
      testClient.Save();
      string secondClientName = "Steve Martin";

      //Act
      testClient.Edit(secondClientName);
      string result = Client.Find(testClient.Id).ClientName;

      //Assert
      Assert.AreEqual(secondClientName, result);
    }

    [TestMethod]
    public void DeleteClient_DeletesClientFromDatabase_Id()
    {
      //Arrange
      string item01 = "Steve Buscemi";
      string item02 = "Daniel Stern";

      Client testClient = new Client(item01, 1);
      Client testClient2 = new Client(item02, 1);

      //Act
      testClient.Save();
      testClient2.Save();

      testClient.DeleteClient(testClient.Id);

      int testId = testClient2.Id;


      //Assert
      Assert.AreEqual(testId, Client.GetAll()[0].Id);
    }

  }
}
