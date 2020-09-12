using ClubManagementApp.Domain.Model;

namespace ClubManagementApp.Domain
{
    public interface IClubRepository
    {
        User[] GetClubBoardMembers();
        //IList<User> GetUsers();
        //IList<Licence> GetLicences();

    }
}
