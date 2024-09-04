using prueba3_Adam_Garcia.Models;

namespace prueba3_Adam_Garcia.Dto
{
    public class SeguidorDTO
    {
        public int FollowerId { get; set; }

        public int UserId { get; set; }

        public int FollowedUserId { get; set; }

        public virtual Usuario FollowedUser { get; set; } = null!;

        public virtual Usuario User { get; set; } = null!;
    }
}
