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
        public as IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (ModelState.IsValid)
            {
                _actorService.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(actor);
            }
            
            
        }

    }
}
