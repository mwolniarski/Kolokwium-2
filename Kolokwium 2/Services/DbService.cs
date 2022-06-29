using Kolokwium_2.Models;
using Kolokwium_2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamDto>> GetTeams()
        {
            var teams = await _dbContext.Teams
                 .Select(x => new TeamDto
                 {
                     TeamId = x.TeamId,
                     TeamName = x.TeamName,
                     OrganizationDto = new OrganizationDto
                     {
                         OrganizationName = x.Organization.OrganizationName,
                         Members = x.MemberShips.Select(x => new MemberDto
                         {
                             MemberName = x.Member.MemberName,
                             MemberNickName = x.Member.MemberNickName,
                             MemberSurname = x.Member.MemberSurname

                         }).ToList()
                     },
                     TeamDescription = x.TeamDescription
                 }).ToListAsync();
            return teams;
        }
        public async Task<TeamDto> GetTeamById(int id)
        {
            var result = await GetTeams();
            var team = result.Where(x => x.TeamId == id).SingleOrDefault();
            return team;
        }
    }
}
