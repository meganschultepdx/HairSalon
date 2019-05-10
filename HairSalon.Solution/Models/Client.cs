using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public string ClientName { get; set; }
    public int Id { get; set; }
    public int StylistId { get; set; }

    public Client (string clientName, int stylistId, int id = 0)
    {
      ClientName = clientName;
      StylistId = StylistId;
      Id = id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.Id == newClient.Id;
        bool clientNameEquality = this.ClientName == newClient.ClientName;
        bool categoryEquality = this.StylistId == newClient.StylistId;
        return (idEquality && clientNameEquality && categoryEquality);
      }
    }


  }
}
