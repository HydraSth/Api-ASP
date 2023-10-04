using System;
using System.Collections.Generic;

namespace Api;

public partial class Producto
{
    public int Productoid { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
