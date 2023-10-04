using System;
using System.Collections.Generic;

namespace Api;

public partial class Ticket
{
    public int Ticketid { get; set; }

    public int Productoid { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
