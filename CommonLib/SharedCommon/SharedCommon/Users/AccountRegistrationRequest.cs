using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon.Users
{
    public record AccountRegistrationRequest
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; } // MUST BE SALTED AND HASHED - NOT PLAIN TEXT
        public DateTime AccountCreated { get; init; } = DateTime.UtcNow;
    }
}
