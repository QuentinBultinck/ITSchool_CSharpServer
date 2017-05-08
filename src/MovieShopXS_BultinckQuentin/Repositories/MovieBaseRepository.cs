using Microsoft.EntityFrameworkCore;
using MovieShopXS_BultinckQuentin.Entities;
using MovieShopXS_BultinckQuentin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopXS_BultinckQuentin.Repositories
{
    public class MovieBaseRepository
    {

        private MovieBaseContext db;

        public MovieBaseRepository(MovieBaseContext context)
        {
            db = context;
        }

        public IList<Movie> getMovieDetails()
        {
            return db.Movie.Include(m => m.Director).Include(m => m.MovieActor)
            .Select(m => new MovieDetail()
            {
                Title = m.Title,
                Director = m.Director.FirstName + " " + m.Director.LastName,
                Rating = m.Stars,
                Description = m.Description,
                Year = m.Year,
                Actors = m.MovieActor.Select(a => new Actor()
                    {
                        Name = a.Actor.FirstName + " " + a.Actor.LastName
                    }).ToList()
                }
            ).ToList();
        }

    }
}
