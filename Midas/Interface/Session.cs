namespace Midas.Interface
{
    public class Session
    {
        public string? Name { get; set; }
        public string? Creator { get; set; }
        public string? Comment { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public uint Id { get; set; }

    }
}