using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Bilet
{
    public long Id { get; set; }

    public long? FkPassenger { get; set; }

    public long? FkWagon { get; set; }

    public long? FkTrain { get; set; }

    public long Mesto { get; set; }

    public double? Summ { get; set; }

    public virtual Passenger? FkPassengerNavigation { get; set; }

    public virtual Wagon? FkWagonNavigation { get; set; }

    public virtual ICollection<ZakazBilet> ZakazBilets { get; } = new List<ZakazBilet>();
}
