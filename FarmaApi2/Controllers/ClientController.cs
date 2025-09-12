using FarmaApi2.DTOs;
using FarmaApi2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmaApi2.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        
        [Authorize]
        [HttpGet(Name = "GetClients")]
        public IActionResult GetClients()
        {
            var clients = _clientService.GetClients();
            return Ok(clients);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost(Name = "CreateClient")]
        public IActionResult CreateClients([FromBody]CreateClientDTO dto)
        {
            var client = _clientService.CreateClient(dto);
            return Ok(client);
        }
    }
}
