using ClubManagementApp.Domain.Aggregates;
using System;
using System.Collections.Generic;

namespace ClubManagementApp.Domain.Model
{    
    public class Committee : Entity<Guid>
    {   
        public IList<Club> Club { get; set; }
        public League League { get; set; }
    }
}
