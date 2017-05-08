using MovieShopXS_BultinckQuentin.Entities;
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

    }
}
