using Microsoft.AspNetCore.Mvc;
using Midas.Interface;
using Newtonsoft.Json;

namespace Midas;

[ApiController]
[Route("[controller]")]
public class MissionsController : ControllerBase<Mission>
{
    public MissionsController(ILogger<ControllerBase<Mission>> logger) : base(logger)
    {
    }

    public override IEnumerable<Mission> Get()
    {
        return Enumerable.Range(1, 10).Select(index => new Mission
            {
                Id = (uint) index,
                Name = $"Cluster {index}",
                CreationTime = DateTime.Now.AddDays(index),
                LastModifiedTime = DateTime.Now.AddDays(index + 1),
                Finished = index % 2 == 0,
                Mode = "Mission",
                Deletable = index % 2 != 0
            })
            .ToArray();
    }

    public override IEnumerable<Column>? GetColumns()
    {
        var columns = System.IO.File.ReadAllText("Columns/missions.json");
        return JsonConvert.DeserializeObject<IEnumerable<Column>>(columns);
    }
}