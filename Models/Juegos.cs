using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack_Api.Models
{
    public partial class Juegos
    {
        public Juegos()
        {
            Detallepartida = new HashSet<Detallepartida>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public ulong Activo { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Detallepartida> Detallepartida { get; set; }
    }
}
