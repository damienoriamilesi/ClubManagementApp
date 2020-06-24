using System;

namespace ClubManagementApp.Controllers
{
    public interface IEntityInformation
    {
        public DateTime Date { get; set; }
        public string Summary { get; set; }
    }
}