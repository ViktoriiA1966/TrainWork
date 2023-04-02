using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Marshrut
{
    public long Id { get; set; }

    public string? NameMarshrut { get; set; }

    public long? FkTrain { get; set; }

    public virtual ICollection<OllOtrezok> OllOtrezoks { get; } = new List<OllOtrezok>();
}
