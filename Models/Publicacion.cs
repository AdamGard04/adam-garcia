using System;
using System.Collections.Generic;

namespace prueba3_Adam_Garcia.Models;

public partial class Publicacion
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime DatePublished { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    public virtual Usuario User { get; set; } = null!;
}
