using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClubManagementApp.Tests
{
    public class MembershipLicencePriceTest
    {
        [Fact]
        public void KidsUnder12PayHalfPrice()
        {
            var member = new Member();
            member.BirthDate = new DateTime(2014, 4, 10);

            //var discount = member.GetDiscount(member.BirthDate);

            //discount.Should().Be(0.5m);
        }

        [Theory]
        [InlineData(2014, 4, 10)]
        [InlineData(1979, 7, 8)]
        public void ShouldComputeAge(int year, int month, int day)
        {
            var birthdate = new DateTime(year, month, day);

            var age = DateTime.UtcNow.Year - birthdate.Year;

            age.Should().BeInRange(6, 41);
        }
    }
}
