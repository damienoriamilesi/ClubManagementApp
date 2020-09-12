namespace ClubManagementApp.Services
{
    internal class MemberCreatingRequestService
    {
        internal MemberCreatingResponse CreateNewMember(MemberCreatingRequest memberCreatingRequest)
        {
            return new MemberCreatingResponse
            {
                Date = memberCreatingRequest.Date,
                Email = memberCreatingRequest.Email,
                Lastname = memberCreatingRequest.Lastname,
                Firstname = memberCreatingRequest.Firstname
            };
        }
    }
}