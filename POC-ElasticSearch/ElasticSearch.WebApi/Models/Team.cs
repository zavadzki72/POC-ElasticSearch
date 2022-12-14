namespace ElasticSearch.WebApi.Models
{
    public class Team
    {
        public static readonly Team Empty = new();

        private Team() { }

        public Team(Guid id, string name, string initials, string city, string state, string nickName, string logoImage)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;

            Name = name;
            Initials = initials;
            City = city;
            State = state;
            NickName = nickName;
            LogoImage = logoImage;
        }

        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public string Name { get; private set; }
        public string Initials { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string NickName { get; private set; }
        public string LogoImage { get; private set; }

        public void Update(Team team)
        {
            Name = team.Name;
            Initials = team.Initials;
            City = team.City;
            State = team.State;
            NickName = team.NickName;
            LogoImage = team.LogoImage;

            UpdateDate = DateTime.Now;
        }
    }
}
