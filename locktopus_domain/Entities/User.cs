﻿using Microsoft.AspNetCore.Identity;

namespace locktopus_domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}