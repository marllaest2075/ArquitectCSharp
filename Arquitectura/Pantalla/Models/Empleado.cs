using System;
using System.Collections.Generic;

namespace Pantalla.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string Nomina { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool? IsBoss { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
