using System;
using System.Collections.Generic;

namespace DAL.Modelo;

public partial class DlkCatAccEmpleado
{
    public string MdUuid { get; set; } = null!;

    public DateTime? MdDate { get; set; }

    public long CodEmpleado { get; set; }

    public string ClaveEmpleado { get; set; } = null!;

    public short NivelAccesoEmpleado { get; set; }
}
