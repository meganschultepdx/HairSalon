using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialty")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialty/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialty")]
    public ActionResult Create(string technique)
    {
      Specialty newSpecialty = new Specialty(technique);
      newSpecialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpGet("/specialty/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("selectedSpecialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);;
      return View(model);
    }

    [HttpPost("/specialties/{patronId}/stylist/new")]
    public ActionResult AddStylist(int specialtyId, int stylistId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      Stylist stylist = Stylist.Find(stylistId);
      specialty.AddStylist(stylist);
      return RedirectToAction("Show",  new { id = specialtyId });
    }

        // [HttpPost("/specialty/{stylistId}/stylists")]
        // public ActionResult Create(int stylistId, string stylistStylistName)
        // {
        //   Dictionary<string, object> model = new Dictionary<string, object>();
        //   Specialty foundSpecialty = Specialty.Find(stylistId);
        //   Stylist newStylist = new Stylist(stylistStylistName, stylistId);
        //   newStylist.Save();
        //   List<Stylist> stylistStylists = foundSpecialty.GetStylists();
        //   model.Add("stylists", stylistStylists);
        //   model.Add("stylist", foundSpecialty);
        //   return View("Show", model);
        // }

  }
}
