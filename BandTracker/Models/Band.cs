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
      _bandDescription = bandDescription;
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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `bands` (`name`, `description`, id) VALUES (@BandName, @BandDescription, @BandId);";

      MySqlParameter bandName = new MySqlParameter();
      bandName.ParameterName = "@BandName";
      bandName.Value = this._bandName;

      MySqlParameter bandDescription = new MySqlParameter();
      bandDescription.ParameterName = "@BandDescription";
      bandDescription.Value = this._bandDescription;

      MySqlParameter bandId = new MySqlParameter();
      bandId.ParameterName = "@BandId";
      bandId.Value = this._id;

      cmd.Parameters.Add(bandName);
      cmd.Parameters.Add(bandDescription);
      cmd.Parameters.Add(bandId);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Venue> GetVenues()
    {
      List<Venue> allBandVenues = new List<Venue> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `venues` WHERE `bandId` = @BandId;";

      MySqlParameter bandId = new MySqlParameter();
      bandId.ParameterName = "@BandId";
      bandId.Value = this._id;
      cmd.Parameters.Add(bandId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        string venueAddress = rdr.GetString(2);
        int bandVenueId = rdr.GetInt32(3);
        Venue newVenue = new Venue(venueName, venueAddress, venueId, bandVenueId);
        allBandVenues.Add(newVenue);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allBandVenues;
    }
  }
}
