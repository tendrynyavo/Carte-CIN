using Microsoft.AspNetCore.Mvc;
using sante_service.Models;

namespace sante_service.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SanteController : ControllerBase {

    [HttpGet]
    public Maladie[] GetMaladie() {
        return Maladie.GetMaladie();
    }

}
