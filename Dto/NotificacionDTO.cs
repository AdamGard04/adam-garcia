namespace prueba3_Adam_Garcia.Dto
{
    public class NotificacionDTO
    {
        public int NotificationId { get; set; }

        public string Text { get; set; } = null!;

        public DateTime DateSent { get; set; }

        public int UserId { get; set; }

        public int? RelatedPostId { get; set; }

        public int? RelatedCommentId { get; set; }
    }
}
