using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;

namespace CdOrganizer.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/addArtist")]
    public ActionResult AddArtist()
    {
      return View();
    }

    [HttpPost("/allArtists")]
    public ActionResult AddAllArtists()
    {
      Artist newArtist = new Artist(Request.Form["art-name"]);
      List<Artist> allTheArtists = Artist.GetAll();
      return View("AllArtists", allTheArtists);
    }

    [HttpGet("/allArtists")]
    public ActionResult AllArtists()
    {
      List<Artist> allTheArtists = Artist.GetAll();
      return View(allTheArtists);
    }

    [HttpGet("/allArtists/{id}")]
    public ActionResult ArtistDetails(int id)
    {
      Artist selectedArtist = Artist.Find(id);
      return View(selectedArtist);
    }

    [HttpPost("/clearAllArtists")]
    public ActionResult ClearAllArtists()
    {
      Artist.ClearAll();
      return View();
    }
























  }
}
