﻿namespace ClubManagementApp.Domain.Model.Members

{
    public class MemberCreatingRequestService
    {
        public MemberCreatingResponse CreateNewMember(MemberCreatingRequest memberCreatingRequest)
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