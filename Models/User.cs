using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class User
{
    public long Id { get; set; }

    public string? FU { get; set; }

    public string? IU { get; set; }

    public string? OU { get; set; }

    public string Password { get; set; } = null!;

    public string Login { get; set; } = null!;

    public long? FkRole { get; set; }

    public virtual Role? FkRoleNavigation { get; set; }

    public virtual ICollection<Zakaz> Zakazs { get; } = new List<Zakaz>();
}
