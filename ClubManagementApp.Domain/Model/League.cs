using System;
using System.Collections.Generic;

namespace ClubManagementApp.Domain.Model
{    
    public partial class League
    {   
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Committee> Committee { get; set; }
    }
}
