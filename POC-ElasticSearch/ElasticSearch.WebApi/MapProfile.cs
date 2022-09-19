using AutoMapper;
using ElasticSearch.WebApi.Models;

namespace ElasticSearch.WebApi
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Team, TeamQueryModel>().ReverseMap();
            CreateMap<Team, RegisterTeamViewModel>().ReverseMap();
        }
    }
}
