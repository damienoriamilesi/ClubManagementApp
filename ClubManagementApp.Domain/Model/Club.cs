namespace ClubManagementApp.Domain.Model
{
    using ClubManagementApp.Domain.Aggregates;
    using System;
    using System.Collections.Generic;
    
    public class Club : Entity<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Committee Committee { get; set; }
        public IList<Licence> Licences { get; set; }

        public void AddLicence(Licence licence)
        {
            Licences.Add(licence);
        }
    }
}
