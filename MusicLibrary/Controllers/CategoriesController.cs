using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{categoryId}")]
    public ActionResult Show(int categoryId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(categoryId);
      List<Album> categoryAlbums = selectedCategory.Albums;
      model.Add("category", selectedCategory);
      model.Add("albums", categoryAlbums);
      return View(model);
    }

    [HttpPost("/categories/{categoryId}/albums")]
    public ActionResult Create(int categoryId, string artist, string title)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Album newAlbum = new Album(artist, title);
      foundCategory.AddAlbum(newAlbum);
      List<Album> categoryAlbums = foundCategory.Albums;
      model.Add("albums", categoryAlbums);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

    [HttpPost("/categories/{categoryId}/delete")]
    public ActionResult Delete(int categoryId)
    {
      Category.Delete(categoryId);
      return View("Delete");
    }    
  }
}