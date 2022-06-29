using Kolokwium_2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kolokwium_2.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IDbService _dbService;

        public TeamController(IDbService dbService)
        {
            this._dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var result = await _dbService.GetTeams();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeams(int id)
        {
            var team = await _dbService.GetTeamById(id);
            if(team == null)
                return NotFound();
            else return Ok(team);
        }

    }
}
