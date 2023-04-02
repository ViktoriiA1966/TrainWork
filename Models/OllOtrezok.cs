using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class OllOtrezok
{
    public long Id { get; set; }

    public long? FkMarshrut { get; set; }

    public long? FkOtrezok { get; set; }

    public virtual Marshrut? FkMarshrutNavigation { get; set; }

    public virtual Otrezok? FkOtrezokNavigation { get; set; }
}
