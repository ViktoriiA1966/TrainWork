using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Status
{
    public long Id { get; set; }

    public string? NameStatus { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; } = new List<Zakaz>();
}
