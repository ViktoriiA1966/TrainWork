using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class ZakazBilet
{
    public long Id { get; set; }

    public long? FkZakaz { get; set; }

    public long? FkBilet { get; set; }

    public virtual Bilet? FkBiletNavigation { get; set; }

    public virtual Zakaz? FkZakazNavigation { get; set; }
}
