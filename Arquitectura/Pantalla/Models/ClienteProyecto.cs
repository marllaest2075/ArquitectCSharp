using System;
using System.Collections.Generic;

namespace Pantalla.Models
{
    public partial class ClienteProyecto
    {
        public int IdCliente { get; set; }
        public int IdProyecto { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
