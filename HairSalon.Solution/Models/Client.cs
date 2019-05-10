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
  }
}
