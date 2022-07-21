using System;
using System.Collections.Generic;

namespace MusicLibrary.Models
{
  public class Album
  {
    public string Artist { get; set; }
    public string Title { get; set; }
    public int Id { get; set; }
    private static List<Album> _instances = new List<Album> {};

    public Album(string artist, string title)
    {
      Artist = artist;
      Title = title;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Album> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Album Find(int id)
    {
      return _instances[id-1];
    }

    public static void Delete(int id)
    {
      _instances.RemoveAt(id-1);
      for (int i = id-1; i<_instances.Count; i++) {
        _instances[i].Id--;
      }
    }


  }
}