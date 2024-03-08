using System;
using System.Collections.Generic;

namespace projetkc.Entities;

public partial class Information
{
    public int IdInformation { get; set; }

    public string? Stades { get; set; }

    public string? Kc { get; set; }

    public string? Periode { get; set; }

    public string? Vergers { get; set; }

    public string? Irrigation { get; set; }

    public virtual ICollection<Plante> Plantes { get; } = new List<Plante>();
}
