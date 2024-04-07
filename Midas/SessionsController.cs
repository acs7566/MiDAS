using Microsoft.AspNetCore.Mvc;
using Midas.Interface;
using Newtonsoft.Json;

namespace Midas;

[ApiController]
[Route("[controller]")]
public class SessionsController : ControllerBase<Session>
{
    public SessionsController(ILogger<SessionsController> logger) : base(logger)
    {
    }


    public override IEnumerable<Session> Get()
    {
        return Enumerable.Range(1, 30).Select(index => new Session
            {
                Name = $"Session {index}",
                Creator = $"User {index}",
                CreationTime = DateTime.Now.AddDays(index),
                LastModifiedTime = DateTime.Now.AddDays(index + 1),
                Comment = Comments[Random.Shared.Next(Comments.Length)],
                Id = (uint) index
            })
            .ToArray();
    }

    public override IEnumerable<Column>? GetColumns()
    {
        var columns = System.IO.File.ReadAllText("Columns/sessions.json");
        return JsonConvert.DeserializeObject<IEnumerable<Column>>(columns);
    }

    [HttpPost(nameof(AddClustersToSession))]
    public void AddClustersToSession(int? sessionId, string? clustersJson)
    {
        if (clustersJson == null) return;
        var clusters = JsonConvert.DeserializeObject<IEnumerable<Cluster>>(clustersJson);

        if (sessionId == null || clusters == null) return;

        Console.WriteLine($"Add {clusters.Count()} clusters to session {sessionId}");
    }

    [HttpGet("GetClusters")]
    public IEnumerable<Cluster>? GetClusters(int? sessionId)
    {
        return Enumerable.Range(1, 5).Select(index => new Cluster
            {
                Name = $"Cluster {index}",
                Creator = $"User {index}",
                CreationTime = DateTime.Now.AddDays(index),
                Comment = Comments[Random.Shared.Next(Comments.Length)],
                Id = index
            })
            .ToArray();
    }
}