using Microsoft.AspNetCore.Mvc;
using D7.Models;
using D7.Services;

namespace D7.Controllers;

public class RookiesController : Controller
{
    private readonly IPersonService _personService;
    public RookiesController(IPersonService personService)
    {
        _personService = personService;
    }    
    public IActionResult Index()
    {
        var people = _personService.GetAll();
        return View(people);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Person model)
    {
        if (!ModelState.IsValid) return View();
        _personService.Create(model);
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            ViewBag.PersonIndex = index;
            return View(person);
        }
        catch (System.Exception)
        {
            
            return RedirectToAction("Index");;
        }
    }
    [HttpPost]
    public IActionResult Edit(int index,Person model)
    {
        if (!ModelState.IsValid)
        { 
            ViewBag.PersonIndex = index;
            return View();
        }
        _personService.Update(index, model);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Delete(int index)
    {
        try
        {
            _personService.Delete(index);
        }
        catch (System.Exception)
        {
    
        }
        return RedirectToAction("Index");
    }
    public IActionResult Detail(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            ViewBag.PersonIndex = index;
            return View(person);
        }
        catch (System.Exception)
        {
            
            return RedirectToAction("Index");;
        }
    }
    [HttpPost]
    public IActionResult DeleteWithResult(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            HttpContext.Session.SetString("DELETED_USER_NAME", person.FullName);
            _personService.Delete(index);
        }
        catch (System.Exception)
        {
    
        }
        return RedirectToAction("Result");
    }
    public IActionResult Result()
    {
        var deteledUserName = HttpContext.Session.GetString("DELETED_USER_NAME");
        ViewBag.DeteledUserName = deteledUserName;
        return View();
    }
        

}