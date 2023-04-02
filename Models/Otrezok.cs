using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Otrezok
{
    public long Id { get; set; }

    public string NameA { get; set; } = null!;

    public string NameB { get; set; } = null!;

    public string DateO { get; set; } = null!;

    public string DateP { get; set; } = null!;

    public double Summ { get; set; }

    public virtual ICollection<OllOtrezok> OllOtrezoks { get; } = new List<OllOtrezok>();
}
