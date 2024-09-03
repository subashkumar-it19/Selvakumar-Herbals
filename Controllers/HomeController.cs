using Microsoft.AspNetCore.Mvc;
using skh.Data;
using skh.Models;
using System.Diagnostics;

namespace skh.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ContactDbContext _db;

    public HomeController(ILogger<HomeController> logger, ContactDbContext db)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(ContactModel contactDetails)
    {
        if (ModelState.IsValid)
        {
            _db.Contacts.Add(contactDetails);
            _db.SaveChanges();
            return RedirectToAction("ThankYou");
        }
        return View(contactDetails);
    }

    public IActionResult ThankYou()
    {
        return View();
    }

    public IActionResult Edit(int? id)
    {
        var contactDetails = _db.Contacts.Find(id);
        if (contactDetails == null)
        {
            return NotFound();
        }
        return View(contactDetails);
    }

    [HttpPost]
    public IActionResult Edit(ContactModel contactDetails)
    {
        if (ModelState.IsValid)
        {
            _db.Contacts.Update(contactDetails);
            _db.SaveChanges();
            return RedirectToAction("Admin");
        }
        return View(contactDetails);
    }

    public IActionResult Delete(int? id)
    {
        var contactDetails = _db.Contacts.Find(id);
        if (contactDetails == null)
        {
            return NotFound();
        }
        return View(contactDetails);
    }

    [HttpPost]
    public IActionResult DeleteContact(int? id)
    {
        var contactDetails = _db.Contacts.Find(id);
        if (contactDetails == null)
        {
            return NotFound();
        }
        _db.Contacts.Remove(contactDetails);
        _db.SaveChanges();
        return RedirectToAction("Admin");
    }

    public IActionResult Admin()
    {
        var contacts = _db.Contacts.ToList();
        return View(contacts);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
