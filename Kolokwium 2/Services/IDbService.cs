using Kolokwium_2.Models;
using Kolokwium_2.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kolokwium_2.Services
{
    public interface IDbService
    {
        Task<IEnumerable<TeamDto>> GetTeams();
        Task<TeamDto> GetTeamById(int id);
    }
}
