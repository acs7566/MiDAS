using Microsoft.AspNetCore.Mvc;
using Midas.Interface;

namespace Midas;

public abstract class ControllerBase<T> : Controller
{
    protected static readonly string[] Comments =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    protected readonly ILogger<ControllerBase<T>> _logger;

    protected ControllerBase(ILogger<ControllerBase<T>> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public abstract IEnumerable<T> Get();

    [HttpGet(nameof(GetColumns))]
    public abstract IEnumerable<Column>? GetColumns();
}