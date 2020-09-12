using Xunit;
using ClubManagementApp.Domain.Model.Members;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubManagementApp.Tests
{
    public class MemberCreatingRequestServiceTest
    {
        [Theory]
        [InlineData("john", "doe", "john.doe@yopmail.com")]
        [InlineData("jane", "doe", "john.doe@yopmail.com")]
        public void ShouldCheckMemberCreatingRequestData(string firstname, string lastname, string email)
        {
            // Arrange
            var processor = new MemberCreatingRequestService();
            MemberCreatingRequest memberCreatingRequest = CreateNewMemberCreatingRequest(firstname, lastname, email);

            // Act
            MemberCreatingResponse response = processor.CreateNewMember(memberCreatingRequest);

            // Assert
            Assert.NotNull(response);

            //Assert.Equal(memberCreatingRequest.Firstname, response.Firstname);
            memberCreatingRequest.Firstname.Should().Be(response.Firstname);
            memberCreatingRequest.Lastname.Should().Be(response.Lastname);
            memberCreatingRequest.Email.Should().Be(response.Email);
            memberCreatingRequest.Date.Should().Be(response.Date);
        }

        private static MemberCreatingRequest CreateNewMemberCreatingRequest(string firstname, string lastname, string email)
        {
            return new MemberCreatingRequest(firstname, lastname, email);
        }

        [Fact]
        public void ShouldFailIfFirstOrDefaultIsNull()
        {
            var items = new List<MemberCreatingRequest> { new MemberCreatingRequest("toto1", "", "") };

            var result = items.FirstOrDefault(x => x.Firstname == "toto") is MemberCreatingRequest request;

            result.Should().BeFalse();
        }
    }
} 
