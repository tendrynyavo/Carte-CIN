using Microsoft.AspNetCore.Mvc;
using sante_service.Models;

namespace sante_service.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SanteController : ControllerBase {

    [HttpGet]
    [Route("{id}")]
    public IEnumerable<Maladie> GetMaladie(string id) {
        return Maladie.GetMaladie(id);
    }
    
    [HttpGet]
    [Route("{id}")]
    public Personne? GetPersonne(string id) {
        return Personne.GetByCIN(id);
    }
    
    [HttpGet]
    [Route("{id}")]
    public bool Verifier(string id) {
        return Personne.verifier(id);
    }

}
