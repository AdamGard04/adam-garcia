namespace prueba3_Adam_Garcia.Dto
{
    public class ComentarioDTO
    {
        public int CommentId { get; set; }

        public string Text { get; set; } = null!;

        public DateTime DatePosted { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}
