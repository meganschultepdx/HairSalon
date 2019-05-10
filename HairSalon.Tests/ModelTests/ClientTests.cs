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

    // [TestMethod]
    // public void SetClientName_SetClientName_String()
    // {
    //   //Arrange
    //   string clientName = "Steve Buscemi";
    //   Client newClient = new Client(clientName, 1);
    //
    //   //Act
    //   string updatedClientName = "Daniel Stern";
    //   newClient.ClientName;
    //   string result = newClient.ClientName;
    //
    //   //Assert
    //   Assert.AreEqual(updatedClientName, result);
    // }

    [TestMethod]
    public void Equals_ReturnsTrueIfClinetNamesAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("Steve Buscemi", 1);
      Client secondClient = new Client("Steve Buscemi", 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

  }
}
