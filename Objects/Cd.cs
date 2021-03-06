using System;
using System.Collections.Generic;

namespace CdList
{
  public class Cd
  {
    private string _title;
    private string _artist;
    private int Id;
    private static List<Cd> _instances= new List<Cd> {};

    public Cd(string title, string artist)
    {
      _title = title;
      _artist = artist;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public string GetTitle()
    {
      return _title;
    }

    public string GetArtist()
    {
      return _artist;
    }

    public int GetId()
    {
      return Id;
    }
    public static List<Cd> GetAll()
    {
      return _instances;
    }
    public static Cd Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static List<Cd> SearchCd(string artist)
    {
      List<Cd> results= new List<Cd> {};

      foreach(Cd matchingArtist in _instances)
      {
        
        if (matchingArtist.GetArtist().ToLower().Contains(artist.ToLower()))
        {
          results.Add(matchingArtist);
        }
      }
      return results;
    }
  }
}
