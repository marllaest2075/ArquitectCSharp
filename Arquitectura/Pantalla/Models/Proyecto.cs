using System;
using System.Collections.Generic;

namespace Pantalla.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            ClienteProyecto = new HashSet<ClienteProyecto>();
            Empleado = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool? IsPresupuesto { get; set; }
        public decimal? Presup { get; set; }
        public string Residen { get; set; }
        public int Tipo { get; set; }
        public int IdJefe { get; set; }

        public virtual Empleado IdJefeNavigation { get; set; }
        public virtual TipoProyecto TipoNavigation { get; set; }
        public virtual ICollection<ClienteProyecto> ClienteProyecto { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
