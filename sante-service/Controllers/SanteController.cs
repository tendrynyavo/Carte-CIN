using Microsoft.AspNetCore.Mvc;
using sante_service.Models;

namespace sante_service.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SanteController : ControllerBase {

    [HttpGet]
    public Maladie[] GetMaladie() {
        return new Maladie[] {
            new("1", "Diabète", new DateTime(2015, 12, 25)),
            new("2", "Asthme", new DateTime(2019, 10, 20)),
            new("3", "Allergie", new DateTime(2021, 5, 23))
        };
    }

}
