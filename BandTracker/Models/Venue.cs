using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BandTracker.Models
{
  public class Venue
  {
    private string _name;
    private string _address;
    private int _id;
    private int _bandId;

    public Venue(string name, string address, int Id = 0, int bandId = 0)
    {
      _name = name;
      _address = address;
      _id = Id;
      _bandId = bandId;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetAddress()
    {
      return _address;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetBandId()
    {
      return _bandId;
    }

    public void SetBandId(int id)
    {
      _bandId = id;
    }

    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM venues;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        string venueAddress = rdr.GetString(2);
        int bandId = rdr.GetInt32(3);
        Venue newVenue = new Venue(venueName, venueAddress, venueId, bandId);
        allVenues.Add(newVenue);
      }
      conn.Close();
      if  (conn != null)
      {
        conn.Dispose();
      }
      return allVenues;
    }

    public override bool Equals(System.Object otherThing)
    {
      if (!(otherThing is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherThing;
        return this.GetId().Equals(newVenue.GetId());
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `venues` (`name`, `address`, `bandId`) VALUES (@VenueName, @VenueAddress, @BandId);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@VenueName";
      name.Value = this._name;

      MySqlParameter address = new MySqlParameter();
      address.ParameterName = "@VenueAddress";
      address.Value = this._address;

      MySqlParameter bandId = new MySqlParameter();
      bandId.ParameterName = "@BandId";
      bandId.Value = this._bandId;

      cmd.Parameters.Add(name);
      cmd.Parameters.Add(address);
      cmd.Parameters.Add(bandId);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM venues;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    // public static Venue Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM `venues` WHERE id = @thisId;";
    //
    //   MySqlParameter thisId = new MySqlParameter();
    //   thisId.ParameterName = "@thisId";
    //   thisId.Value = id;
    //   cmd.Parameters.Add(thisId);
    //
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int venueId = 0;
    //   string venueName = "";
    //   string venueAddress = "";
    //   int venueBandId = 0;
    //
    //   while (rdr.Read())
    //   {
    //     venueId = rdr.GetInt32(0);
    //     venueName = rdr.GetString(1);
    //     venueAddress = rdr.GetString(2);
    //     venueBandId = rdr.GetInt32(3);
    //   }
    //
    //   Venue foundVenue = new Venue(venueName, venueAddress, venueId, venueBandId);
    //
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return foundVenue;
    // }
  }
}
