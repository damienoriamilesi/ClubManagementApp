using ClubManagementApp.Domain.Model;
using System;

namespace ClubManagementApp.Domain.Aggregates
{
    internal class Club : Entity<Guid>
    {
        protected Club() : base(Guid.NewGuid()) { }
        protected Club(Guid id) : base(id) { }

        //public static Club Create(string name, DateTime createdOn)
        //{
        //    // Validate data 
        //    // name length > 5, CreatedOn

        //    var newClub = new Club();
        //    //newClub.
        //    return newClub;
        //}

        public string CommitteeId { get; set; }

        public User[] Administratives { get; set; }
    }
}
