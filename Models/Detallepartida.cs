using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack_Api.Models
{
    public partial class Detallepartida
    {
        public int Id { get; set; }
        public int IdPartida { get; set; }
        public int IdCarta { get; set; }

        public virtual Cartas IdCartaNavigation { get; set; }
        public virtual Juegos IdPartidaNavigation { get; set; }
    }
}
