//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cotisation
    {
        public System.Guid Id { get; set; }
        public string Amount { get; set; }
        public string Year { get; set; }
        public string PaymentDate { get; set; }
        public System.Guid LicenceId { get; set; }
    
        public virtual Licence Licence { get; set; }
    }
}
