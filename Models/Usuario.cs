using System;
using System.Collections.Generic;

namespace prueba3_Adam_Garcia.Models;

public partial class Usuario
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    public virtual ICollection<Publicacion> Publicacions { get; set; } = new List<Publicacion>();

    public virtual ICollection<Seguidor> SeguidorFollowedUsers { get; set; } = new List<Seguidor>();

    public virtual ICollection<Seguidor> SeguidorUsers { get; set; } = new List<Seguidor>();
}
