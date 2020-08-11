using ClubManagementApp.Domain.Model;
using System.Collections.Generic;

namespace ClubManagementApp.Domain.Contracts
{
    internal interface IClubManagementRepository
    {
        IList<User> GetUsers();
        IList<Licence> GetLicences();
    }
}
