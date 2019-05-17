using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Specialty
  {
    public int Id { get; set; }
    public string Technique { get; set; }

    public Patron(string technique, int id = 0)
    {
      Technique = technique;
      Id = id;
    }
