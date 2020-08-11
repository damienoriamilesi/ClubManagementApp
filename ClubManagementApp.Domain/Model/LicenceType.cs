namespace ClubManagementApp.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LicenceType
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public IList<Licence> Licence { get; set; }
    }
}
