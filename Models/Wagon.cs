using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Wagon
{
    public long Id { get; set; }

    public string ClassWagon { get; set; } = null!;

    public long? Mesto { get; set; }

    public virtual ICollection<Bilet> Bilets { get; } = new List<Bilet>();
}
