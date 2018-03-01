using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BandTracker.Models
{
  public class Band
  {

    private string _bandName;
    private string _bandDescription;
    private int _id;

    public Band(string bandName, string bandDescription, int Id = 0)
    {
      _bandName = bandName;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetBandName()
    {
      return _bandName;
    }

    public string GetBandDescription()
    {
      return _bandDescription;
    }

    public static List<Band> GetAll()
    {
      List<Band> allBands = new List<Band>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM bands;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        string bandDescription = rdr.GetString(2);
        Band newBand = new Band(bandName, bandDescription, bandId);
        allBands.Add(newBand);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allBands;
    }
    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        return this.GetId().Equals(newBand.GetId());
      }
    }
  }
}
