using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack_Api.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Juegos = new HashSet<Juegos>();
            Partida = new HashSet<Partida>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public byte[] Clave { get; set; }

        public virtual ICollection<Juegos> Juegos { get; set; }
        public virtual ICollection<Partida> Partida { get; set; }
    }
}
