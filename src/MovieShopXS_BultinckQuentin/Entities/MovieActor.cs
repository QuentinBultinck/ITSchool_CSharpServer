using System;
using System.Collections.Generic;

namespace MovieShopXS_BultinckQuentin.Entities
{
    public partial class MovieActor
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual Person Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
