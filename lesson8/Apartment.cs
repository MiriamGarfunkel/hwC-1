using System;
using System.Collections.Generic;

namespace lesson8;

public partial class Apartment
{
    public int Id { get; set; }

    public int? Rooms { get; set; }

    public int? Floor { get; set; }

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
