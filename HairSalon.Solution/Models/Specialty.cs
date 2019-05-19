using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Specialty
  {
    public int Id { get; set; }
    public string Technique { get; set; }

    public Specialty(string technique, int id = 0)
    {
      Technique = technique;
      Id = id;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = this.Id == newSpecialty.Id;
        bool techniqueEquality = this.Technique == newSpecialty.Technique;
        return (idEquality && techniqueEquality);
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (technique) VALUES (@technique);";
      MySqlParameter technique = new MySqlParameter();
      technique.ParameterName = "@technique";
      technique.Value = this.Technique;
      cmd.Parameters.Add(technique);

      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string specialtyTechnique = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(specialtyTechnique, specialtyId);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int SpecialtyId = 0;
      string SpecialtyTechnique = "";
      while(rdr.Read())
      {
        SpecialtyId = rdr.GetInt32(0);
        SpecialtyTechnique = rdr.GetString(1);
      }
      Specialty newSpecialty = new Specialty(SpecialtyTechnique, SpecialtyId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSpecialty;
    }

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist_skills (specialties_id, stylist_id) VALUES (@SpecialtyId, @StylistId);";
      cmd.Parameters.AddWithValue("@SpecialtyId", Id);
      cmd.Parameters.AddWithValue("@StylistId", newStylist.Id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
      JOIN stylist_skills ON (specialties.id = stylist_skills.specialties_id)
      JOIN stylists ON (stylist_skills.stylist_id = stylists.id)
      WHERE specialties.id = @SpecialtyId;";
      MySqlParameter specialtyIdParameter = new MySqlParameter();
      specialtyIdParameter.ParameterName = "@SpecialtyId";
      specialtyIdParameter.Value = Id;
      cmd.Parameters.Add(specialtyIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        stylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return stylists;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = new MySqlCommand("DELETE FROM specialties WHERE id = @SpecialtyId; DELETE FROM stylist_skills WHERE specialties_id = @SpecialtyId;", conn);
      MySqlParameter specialtyIdParameter = new MySqlParameter();
      specialtyIdParameter.ParameterName = "@SpecialtyId";
      specialtyIdParameter.Value = this.Id;
      cmd.Parameters.Add(specialtyIdParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

  }
}
