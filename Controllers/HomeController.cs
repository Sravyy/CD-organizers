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

    // Post the CD Form for a artist and view the list of cds.

    [HttpPost("/cds")]
    public ActionResult AddACd()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(int.Parse(Request.Form["artist-id"]));
      List<Cd> listOfCdsByaArtist =  selectedArtist.GetCds();
      string cdContents = Request.Form["add-cd"];
      Cd newCd = new Cd (cdContents);
      listOfCdsByaArtist.Add(newCd);
      model.Add("cds", listOfCdsByaArtist);
      model.Add("artist", selectedArtist);
      return View("ArtistDetails", model);
    }



    //getting the Individual CD

      [HttpGet("/allArtists/{id}/cds/new")]
      public ActionResult CreateCDForm(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(id);
        List<Cd> allCds =  selectedArtist.GetCds();
        model.Add("artist", selectedArtist);
        model.Add("cds", allCds);
        return View(model);
      }


    //We get Cd's for Individual

    [HttpGet("/allArtists/{id}")]
    public ActionResult ArtistDetails(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Cd> listOfCdsByaArtist =  selectedArtist.GetCds();
      model.Add("artist", selectedArtist);
      model.Add("cds", listOfCdsByaArtist);
      return View(model);
    }



    [HttpPost("/clearAllArtists")]
    public ActionResult ClearAllArtists()
    {
      Artist.ClearAll();
      return View();
    }

    [HttpGet("/cds/{id}")]
    public ActionResult CdDetail(int id)
    {
      Cd cd = Cd.Find(id);
      return View(cd);
    }

  }
}
