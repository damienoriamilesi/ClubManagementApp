using System;

namespace ClubManagementApp.Domain.Model.Members
{
    public class MemberCreatingResponse
    {
        public string Firstname { get; internal set; }
        public string Lastname { get; internal set; }
        public string Email { get; internal set; }
        public DateTime Date { get; internal set; }

    }
}