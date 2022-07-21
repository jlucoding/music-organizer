using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using System.Collections.Generic;

namespace MusicLibrary.Controllers
{
  public class AlbumsController : Controller
  {

    [HttpGet("/categories/{categoryId}/albums/new")]
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }

    [HttpPost("/categories/{categoryId}/albums/delete")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }

    [HttpGet("/categories/{categoryId}/albums/{albumId}")]
    public ActionResult Show(int categoryId, int albumId)
    {
      Album album = Album.Find(albumId);
      Category category = Category.Find(categoryId);
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("category", category);
      return View(model);
    }

    [HttpPost("/categories/{categoryId}/albums/{albumId}/delete")]
    public ActionResult Delete(int albumId)
    {
      Album.Delete(albumId);
      return View("Delete");
    }
  }
}