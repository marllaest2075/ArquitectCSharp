using System;
using System.Collections.Generic;

namespace Pantalla.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteProyecto = new HashSet<ClienteProyecto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public bool? IsPerson { get; set; }
        public string Correo { get; set; }
        public bool? TieneAporte { get; set; }
        public decimal? Aporte { get; set; }

        public virtual ICollection<ClienteProyecto> ClienteProyecto { get; set; }
    }
}
