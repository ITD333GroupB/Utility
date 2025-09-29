using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedCommon.Users
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string UserID { get; set; } // unique identifier for the user, we may want to just set this to an Int or use GUIDs but string is ok for now
        public string Email { get; set; }
        public string JwtToken { get; set; } // used for auth, should be retrieved upon login
        public DateTime AccountCreated { get; set; }

        [JsonConstructor]
        public UserProfile() { }

    }
}