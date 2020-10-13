using System;

namespace ClubManagementApp.Domain.Model
{    
    public partial class Cotisation
    {
        public Guid Id { get; set; }
        public string Amount { get; set; }
        public string Year { get; set; }
        public string PaymentDate { get; set; }
        public Guid LicenceId { get; set; }
    
        public Licence Licence { get; set; }

        public Guid UserId { get; set; }
        public User Player { get; set; }
    }
}
