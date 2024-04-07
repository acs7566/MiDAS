using Microsoft.AspNetCore.Mvc;
using Midas.Interface;
using Newtonsoft.Json;

namespace Midas;
[ApiController]
[Route("[controller]")]
public class ClustersController : ControllerBase<Cluster>
{
    public ClustersController(ILogger<ControllerBase<Cluster>> logger) : base(logger)
    {
    }

    public override IEnumerable<Cluster> Get()
    {
        return Enumerable.Range(1, 10).Select(index => new Cluster
            {
                Name = $"Cluster {index}",
                Creator = $"User {index}",
                CreationTime = DateTime.Now.AddDays(index),
                Comment = Comments[Random.Shared.Next(Comments.Length)]
            })
            .ToArray();
    }

    public override IEnumerable<Column>? GetColumns()
    {
        var columns = System.IO.File.ReadAllText("Columns/clusters.json");
        return JsonConvert.DeserializeObject<IEnumerable<Column>>(columns);
    }
}