using System.Collections.Generic;

namespace CdOrganizer.Models
{
  public class Artist
  {
    private string _name;
    private int _id;
    private static List<Artist> _instances = new List<Artist> {};

    public Artist(string artistName)
    {
      _name = artistName;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }












  }
}
