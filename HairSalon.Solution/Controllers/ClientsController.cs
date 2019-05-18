using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      List<Specialty> allSpecialties = Specialty.GetAll();
      model.Add("client", client);
      model.Add("stylist", stylist);
      model.Add("allSpecialties", allSpecialties);
      return View(model);
    }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
    public ActionResult Delete(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      client.DeleteClient(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistId);
      List<Client> stylistClients = foundStylist.GetClients();
      model.Add("clients", stylistClients);
      model.Add("stylist", foundStylist);
      return RedirectToAction("Show", "Stylists");
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
    public ActionResult Edit(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("stylist", stylist);
      Client client = Client.Find(clientId);
      model.Add("client", client);
      return View(model);
    }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Update(int stylistId, int clientId, string newClientName)
    {
      Client client = Client.Find(clientId);
      client.Edit(newClientName);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("stylist", stylist);
      model.Add("client", client);
      return View("Show", model);
    }
  }
}
