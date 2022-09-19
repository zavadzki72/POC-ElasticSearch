using AutoMapper;
using ElasticSearch.WebApi.Interfaces;
using ElasticSearch.WebApi.Models;

namespace ElasticSearch.WebApi.Queries
{
    public class TeamQuery : ElasticConfiguration<Team, TeamQueryModel>, ITeamQuery
    {

        public TeamQuery(IMapper mapper, IConfiguration configuration) : base(mapper, configuration) { }

        public async Task<Team> GetById(Guid id)
        {

            var resultLazy = new LazyAsync<TeamQueryModel?>(async () => {

                var qResult = await GetClient().SearchAsync<TeamQueryModel>(
                    x => x.Query(m => m.Match(mc => mc.Field("id").Query(id.ToString())))
                );

                if (!qResult.IsValid || qResult.Documents == null || !qResult.Documents.Any())
                {
                    return null;
                }

                var teamQueryModel = qResult.Documents.FirstOrDefault();

                return teamQueryModel;
            });

            var responseMapped = _mapper.Map<Team>(await resultLazy.Value);

            return responseMapped;
        }

        public async Task<List<Team>> GetAll()
        {

            var resultLazy = new LazyAsync<List<TeamQueryModel>?>(async () => {

                var qResult = await GetClient().SearchAsync<TeamQueryModel>();

                if (!qResult.IsValid || qResult.Documents == null || !qResult.Documents.Any())
                {
                    return null;
                }

                var teamQueryModel = qResult.Documents.ToList();

                return teamQueryModel;
            });

            var responseMapped = _mapper.Map<List<Team>>(await resultLazy.Value);

            return responseMapped;
        }

    }
}
