using System;
using System.Collections.Generic;

namespace ClubManagementApp.Domain.Model
{    
    public class Committee
    {
        public Guid Id { get; set; }
    
        public IList<Club> Club { get; set; }
        public League League { get; set; }
    }
}
