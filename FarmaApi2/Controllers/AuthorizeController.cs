using FarmaApi2.DTOs;
using FarmaApi2.Services;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;

namespace FarmaApi2.Controllers;

[ApiController]
[Route("[Controller]")]
public class AuthorizeController : ControllerBase
{
    private AuthorizeService _authorizeService;

    public AuthorizeController(AuthorizeService authorizeService)
    {
        _authorizeService = authorizeService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostTokenDTO dto)
    {
        var retorno = await _authorizeService.PostToken((dto));
        
        return Ok(retorno);
    }
}