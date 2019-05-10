using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public string ClientName { get; set; }
    public int Id { get; set; }
    public int CategoryId { get; set; }

    public Client (string clientName, int categoryId, int id = 0)
    {
      ClientName = clientName;
      CategoryId = categoryId;
      Id = id;
    }
  }
