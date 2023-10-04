using System;
using System.Collections.Generic;

namespace Api;

public partial class Empleado
{
    public int Empleadoid { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string Funcion { get; set; } = null!;

    public decimal Basico { get; set; }

    public int Horas { get; set; }

    public int Antiguedad { get; set; }
}
