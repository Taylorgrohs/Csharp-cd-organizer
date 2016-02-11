using Nancy;
using System.Collections.Generic;
using CdList;

namespace Cdlist
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Cd> allCds = Cd.GetAll();
        return View["index.cshtml", allCds];
      };
      Get["/cds"] = _ => {
        List<Cd> allCds = Cd.GetAll();
        return View["index.cshtml", allCds];
      };
      Get["/cds/new"] = _ => {
        return View["cd_form.cshtml"];
      };
      Post["/"] = _ => {
        Cd newCd = new Cd(Request.Form["new-title"], Request.Form["new-artist"]);
        List<Cd> allCds = Cd.GetAll();
        return View["index.cshtml", allCds];
      };
      Get["/cds/{id}"] = parameters => {
        Cd cd = Cd.Find(parameters.id);
        return View["/cd.cshtml", cd];
      };
      Get["/search_cds"] = _ => View["search_cds.cshtml"];
      Post["/view_result"] = _ =>
      {
        string artist = Request.Form["artist"];
        List<Cd> results = Cd.SearchCd(artist);
        return View["view_result.cshtml", results];
      };
    }
  }
}
