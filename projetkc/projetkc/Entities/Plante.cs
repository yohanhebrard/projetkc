using System;
using System.Collections.Generic;

namespace projetkc.Entities;

public partial class Plante
{
    public int IdPlante { get; set; }

    public string? NomPlante { get; set; }

    public int IdInformation { get; set; }

    public virtual Information IdInformationNavigation { get; set; } = null!;

    public virtual ICollection<Type> Types { get; } = new List<Type>();
}
