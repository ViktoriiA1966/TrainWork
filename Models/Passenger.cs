using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Passenger
{
    public long Id { get; set; }

    public string FName { get; set; } = null!;

    public string IName { get; set; } = null!;

    public string OName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Birthday { get; set; } = null!;

    public string Document { get; set; } = null!;

    public string? Telephone { get; set; }

    public virtual ICollection<Bilet> Bilets { get; } = new List<Bilet>();
}
