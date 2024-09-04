namespace prueba3_Adam_Garcia.Dto
{
    public class PublicacionDTO
    {
        public int PostId { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime DatePublished { get; set; }

        public int UserId { get; set; }
    }
}
