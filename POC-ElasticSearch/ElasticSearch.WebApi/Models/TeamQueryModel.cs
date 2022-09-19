using ElasticSearch.WebApi.Interfaces;
using Nest;

namespace ElasticSearch.WebApi.Models
{
    [ElasticsearchType(RelationName = "team")]
    public class TeamQueryModel : IElasticSearchQueryModel
    {

        public string GetIndexName
        {
            get
            {
                return "idx-team";
            }
        }

        [Keyword]
        public string? Name { get; set; }
        [Keyword]
        public string? Initials { get; set; }
        [Keyword]
        public string? NickName { get; set; }

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? LogoImage { get; set; }

    }
}
