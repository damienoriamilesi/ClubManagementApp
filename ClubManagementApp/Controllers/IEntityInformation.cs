using System;

namespace ClubManagementApp.Controllers
{
    public interface IEntityInformation
    {
        public DateTime? Date { get; set; }
        public string Summary { get; set; }
    }

    public class Entity : IEntityInformation
    {
        public DateTime? Date { get; set; }
        public string Summary { get; set; }
    }
}