using System;

namespace ClubManagementApp.Domain.Model.Members
{
    public class MemberCreatingRequest
    {

        public MemberCreatingRequest(string firstname, string lastname, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Date = DateTime.UtcNow;
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public DateTime Date { get; private set; }
    }
}