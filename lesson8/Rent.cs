using System;
using System.Collections.Generic;

namespace lesson8;

public partial class Rent
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ApartmentId { get; set; }

    public virtual Apartment? Apartment { get; set; }

    public virtual User? User { get; set; }
}
