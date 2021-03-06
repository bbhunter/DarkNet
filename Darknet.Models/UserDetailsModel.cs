﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Darknet.Models
{
    public class UserDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public List<Friend> Friends { get; set; }
    }

    public class Friend {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivacyLevel { get; set; }
    }
}