namespace Data
{
    public class RecruiterDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Link { get; set; }
        public bool MessageSend { get; set; }
        public bool Answered { get; set; }
    }
}
