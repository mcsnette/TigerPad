﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TigerPadG4.Data
{
    public class UserClass 
    {
       
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool Access { get; set; }





        

    }
}
