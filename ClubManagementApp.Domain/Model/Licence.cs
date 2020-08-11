namespace ClubManagementApp.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Licence
    {    
        public Guid Id { get; set; }
    
        public LicenceType LicenceType { get; set; }
        public User User { get; set; }
        public Club Club { get; set; }
        public IList<Cotisation> Cotisations { get; set; }
    }
}
