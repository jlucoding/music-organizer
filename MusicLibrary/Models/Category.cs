using System.Collections.Generic;

namespace MusicLibrary.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    public string Name { get; set; }
    public int Id { get; set; }
    public List<Album> Albums { get; set; }

    public Category(string category)
    {
      Name = category;
      _instances.Add(this);
      Id = _instances.Count;
      Albums = new List<Album>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Category> GetAll()
    {
      return _instances;
    }

    public static Category Find(int id)
    {
      return _instances[id-1];
    }

    public void AddAlbum(Album album)
    {
      Albums.Add(album);
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