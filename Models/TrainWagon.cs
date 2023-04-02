using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class TrainWagon
{
    public long? IdTrainwagon { get; set; }

    public long? FkWagon { get; set; }

    public virtual Wagon? FkWagonNavigation { get; set; }
}
