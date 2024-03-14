using System;
using System.Collections.Generic;

namespace WpfApp2.Entities;

public partial class Usuarios
{
    public int Id { get; set; }

    public string? Usuario { get; set; }

    public string? Pass { get; set; }

    public int? Sucursal { get; set; }

    public bool? Activo { get; set; }

    public bool? Usuariobloqueado { get; set; }
}
