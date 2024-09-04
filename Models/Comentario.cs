using System;
using System.Collections.Generic;

namespace prueba3_Adam_Garcia.Models;

public partial class Comentario
{
    public int CommentId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime DatePosted { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    public virtual Publicacion Post { get; set; } = null!;

    public virtual Usuario User { get; set; } = null!;
}
