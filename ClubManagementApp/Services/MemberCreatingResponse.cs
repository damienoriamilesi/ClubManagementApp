﻿using System;

namespace ClubManagementApp.Services
{
    internal class MemberCreatingResponse
    {
        public string Firstname { get; internal set; }
        public string Lastname { get; internal set; }
        public string Email { get; internal set; }
        public DateTime Date { get; internal set; }

    }
}