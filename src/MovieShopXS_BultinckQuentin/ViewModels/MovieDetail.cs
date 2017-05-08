using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopXS_BultinckQuentin.ViewModels
{
    public class MovieDetail
    {
        public MovieDetail()
        {
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public IList<Actor> Actors { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }
    }
}
