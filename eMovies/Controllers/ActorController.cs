using eMovies.Models;
using eMovies.NewFolder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.Controllers
{
    public class ActorController:Controller
    {
        // private readonly AppDbContext _context;
        private readonly IActorService  _actorService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ActorController(IActorService  actorService, IWebHostEnvironment webHostEnvironment)
        {
            _actorService = actorService;
            _webHostEnvironment = webHostEnvironment;
        }

        public  IActionResult  Index()
        {
            var actors = _actorService.GetAll();
            return View(actors );
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _actorService.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(actor);
            }
            
            
        }
        //Get/edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var actordetail = await _actorService.GetById(id);
            if (actordetail == null) { return View("Empty  "); }
            return View(actordetail);
         
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
               await _actorService.Update(id,actor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(actor);
            }



        }
        public async Task<IActionResult> Delete(int id)
        {
            var actordetail = await _actorService.GetById(id);
            if (actordetail == null) { return View("NotFound  "); }
            return View(actordetail);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteMethod(int id)
        {
            var actordetail = await _actorService.GetById(id);
            if (actordetail == null) { return View("NotFound  "); }
            
                await _actorService.Delete(id);
                return RedirectToAction(nameof(Index));
            
           

        }

    }
}
