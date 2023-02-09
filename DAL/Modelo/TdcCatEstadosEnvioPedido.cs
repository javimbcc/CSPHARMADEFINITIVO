using System;
using System.Collections.Generic;

namespace DAL.Modelo;

public partial class TdcCatEstadosEnvioPedido
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string CodEstadoEnvio { get; set; } = null!;

    public string? DesEstadoEnvio { get; set; }

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
