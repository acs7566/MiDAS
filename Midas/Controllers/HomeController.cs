using Microsoft.AspNetCore.Mvc;
using Midas.Interface;
using System.Xml.Linq;

namespace Midas.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
}