using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Zakaz
{
    public long Id { get; set; }

    public long? FkStatus { get; set; }

    public long? FkUser { get; set; }

    public virtual Status? FkStatusNavigation { get; set; }

    public virtual User? FkUserNavigation { get; set; }

    public virtual ICollection<ZakazBilet> ZakazBilets { get; } = new List<ZakazBilet>();
}
