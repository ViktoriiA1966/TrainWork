using System;
using System.Collections.Generic;

namespace TrainWork.Models;

public partial class Role
{
    public long Id { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
