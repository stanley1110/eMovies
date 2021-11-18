using eMovies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.NewFolder
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;
       

        public ActorService(AppDbContext context)
        {
            _context = context;
           
        }

        public  void Add(Actor actor)
        {
            if(actor != null)
            {
                 _context.Actors.Add(actor);
                 _context.SaveChanges();

            }
            
        }

        public  void Delete(int id)
        {
            
            
              var actor =  _context.Actors.Where(c => c.Id == id).FirstOrDefault();
              if (actor != null)
                {
                    _context.Actors.Remove(actor);
                     _context.SaveChangesAsync();

                }

            
        }

       

        public  IEnumerable<Actor> GetAll()
        {
            var actors =  _context.Actors.ToList();
            return actors;
            
        }

        public async Task<Actor> GetById(int Id)
        {
            var actor = await _context.Actors.Where(c => c.Id == Id).FirstOrDefaultAsync();
            return actor;
        }

        public async Task<Actor> Update(int id, Actor actor)
        {
            var actors = await _context.Actors.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (actors != null)
            {
                actors.Bio = actor.Bio;
                actors.FullName = actor.FullName;
                actors.ProfilePictureURL = actor.ProfilePictureURL;
                 
                await _context.SaveChangesAsync();
                
            }
            return actor;
        }
    }
}
