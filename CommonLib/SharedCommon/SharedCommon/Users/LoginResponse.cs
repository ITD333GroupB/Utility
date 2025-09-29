﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedCommon.Users
{
    /// <summary>
    /// Sent from the backend server to the client after a login attempt.
    /// If succecssful, the Token property will contain a JWT token for authenticated requests.
    /// If unsuccessful, the Token property will be empty.
    /// </summary>
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; } // this will be a JWT token used for authenticated requests and should be set in UserProfile.JwtToken

        [JsonConstructor]
        public LoginResponse() { }
    }
}
