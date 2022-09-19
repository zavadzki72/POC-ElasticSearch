using System.Text.Json.Serialization;

namespace ElasticSearch.WebApi.Models
{
    public class RegisterTeamViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string? Name { get; set; }
        public string? Initials { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? NickName { get; set; }
        public string? LogoImage { get; set; }
    }
}
