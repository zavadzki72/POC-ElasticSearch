using AutoMapper;
using ElasticSearch.WebApi.Interfaces;
using ElasticSearch.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamQuery _teamQuery;
        private readonly IMapper _mapper;

        public TeamController(ITeamQuery teamQuery, IMapper mapper)
        {
            _teamQuery = teamQuery;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid? id)
        {
            var result = new List<Team>();

            if (id == null)
            {
                var teams = await _teamQuery.GetAll();
                return Ok(teams);
            }
            
            var team = await _teamQuery.GetById(id.Value);
            result.Add(team);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterTeamViewModel registerTeamViewModel)
        {
            var team = _mapper.Map<Team>(registerTeamViewModel);
            await _teamQuery.IndexAsync(team);
            
            return Ok(team.Id);
        }
    }
}