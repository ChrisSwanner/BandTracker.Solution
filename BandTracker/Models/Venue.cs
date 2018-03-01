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
  }
}
