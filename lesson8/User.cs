using System;
using System.Collections.Generic;

namespace lesson8;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNunber { get; set; }

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
