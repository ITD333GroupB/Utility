using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon.Users
{
    /// <summary>
    /// Sent from the client to the backend server to attempt a login.
    /// </summary>
    /// <remarks>Password must be salted and hashed. Upon sending login request, server should respond with a <see cref="LoginResponse"/></remarks>
    public record AccountLoginRequest
    {
        public string Username { get; init; }
        public string Password { get; init; } // this should be salted and hashed - NOT PLAIN TEXT
    }
}
