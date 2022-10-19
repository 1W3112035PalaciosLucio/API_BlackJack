using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack_Api.Models
{
    public partial class Cartas
    {
        public Cartas()
        {
            Detallepartida = new HashSet<Detallepartida>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public string Palo { get; set; }
        public ulong? Disponible { get; set; }

        public virtual ICollection<Detallepartida> Detallepartida { get; set; }
    }
}
