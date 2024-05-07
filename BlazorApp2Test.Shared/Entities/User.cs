using System;
using System.Collections.Generic;

namespace BlazorApp2Test.Shared.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
