using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public List<Client> Clients { get; set; }

    public Stylist(string stylistName, int id = 0)
    {
      Name = stylistName;
      Id = id;
      Clients = new List<Client>{};
    }

  }
