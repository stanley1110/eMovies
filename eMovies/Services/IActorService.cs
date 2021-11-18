using eMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovies.NewFolder
{
    public interface IActorService
    {
        IEnumerable<Actor> GetAll();
        Task<Actor> GetById(int Id);

        void Add(Actor actor);
        Task<Actor> Update(int id, Actor actor);
        void Delete(int id);

    }
}
