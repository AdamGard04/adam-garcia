using System;
using System.Collections.Generic;

namespace prueba3_Adam_Garcia.Models;

public partial class Seguidor
{
    public int FollowerId { get; set; }

    public int UserId { get; set; }

    public int FollowedUserId { get; set; }

}
