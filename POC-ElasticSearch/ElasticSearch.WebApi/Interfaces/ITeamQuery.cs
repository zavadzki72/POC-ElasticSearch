using ElasticSearch.WebApi.Models;

namespace ElasticSearch.WebApi.Interfaces
{
    public interface ITeamQuery : IElasticSearchBaseQuery<Team, TeamQueryModel>
    {
        Task<Team> GetById(Guid id);
        Task<List<Team>> GetAll();

    }
}
