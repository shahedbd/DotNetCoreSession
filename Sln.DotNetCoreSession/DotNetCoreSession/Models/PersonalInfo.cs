using System;

namespace DotNetCoreSession.Models
{
    public class PersonalInfo
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public long Savings { get; set; }
        public string Country { get; set; }
    }
}