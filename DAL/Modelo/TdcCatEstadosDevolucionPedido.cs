using System;
using System.Collections.Generic;

namespace DAL.Modelo;

public partial class TdcCatEstadosDevolucionPedido
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public long Id { get; set; }

    public string CodEstadoDevolucion { get; set; } = null!;

    public string? DesEstadoDevolucion { get; set; }

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
