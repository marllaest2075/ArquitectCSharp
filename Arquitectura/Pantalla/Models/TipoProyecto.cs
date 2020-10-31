using System;
using System.Collections.Generic;

namespace Pantalla.Models
{
    public partial class TipoProyecto
    {
        public TipoProyecto()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
