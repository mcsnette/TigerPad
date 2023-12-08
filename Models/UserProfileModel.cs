using Microsoft.AspNetCore.Mvc;
using System;

namespace TigerPadG4.Models
{
    public enum CicsProgram
    {
        IT,
        IS,
        CS
    }
    public class UserProfileModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public CicsProgram CicsProgram { get; set; }
    }
}
