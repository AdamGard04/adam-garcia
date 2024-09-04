using System;
using System.Collections.Generic;

namespace prueba3_Adam_Garcia.Models;

public partial class Notificacion
{
    public int NotificationId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime DateSent { get; set; }

    public int UserId { get; set; }

    public int? RelatedPostId { get; set; }

    public int? RelatedCommentId { get; set; }

    public virtual Comentario? RelatedComment { get; set; }

    public virtual Publicacion? RelatedPost { get; set; }

    public virtual Usuario User { get; set; } = null!;
}
