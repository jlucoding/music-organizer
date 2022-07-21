using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}