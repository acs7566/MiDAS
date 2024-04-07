namespace Midas.Interface;

public class Mission
{
    public uint Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime LastModifiedTime { get; set; }
    public bool Finished { get; set; }
    public string? Mode { get; set; }
    public bool Deletable { get; set; }
}