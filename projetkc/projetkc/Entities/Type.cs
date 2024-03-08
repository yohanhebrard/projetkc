using System;
using System.Collections.Generic;

namespace projetkc.Entities;

public partial class Type
{
    public int IdType { get; set; }

    public string? NomType { get; set; }

    public int IdPlante { get; set; }

    public virtual Plante IdPlanteNavigation { get; set; } = null!;
}
