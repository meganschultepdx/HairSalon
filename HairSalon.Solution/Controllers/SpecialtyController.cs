using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create(string technique)
    {
      Specialty newSpecialty = new Specialty(technique);
      newSpecialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> stylistStylists = selectedSpecialty.GetStylists();
      model.Add("stylist", selectedSpecialty);
      model.Add("stylists", stylistStylists);
      return View(model);
    }

        [HttpPost("/specialties/{stylistId}/stylists")]
        public ActionResult Create(int stylistId, string stylistStylistName)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Specialty foundSpecialty = Specialty.Find(stylistId);
          Stylist newStylist = new Stylist(stylistStylistName, stylistId);
          newStylist.Save();
          List<Stylist> stylistStylists = foundSpecialty.GetStylists();
          model.Add("stylists", stylistStylists);
          model.Add("stylist", foundSpecialty);
          return View("Show", model);
        }

  }
}
