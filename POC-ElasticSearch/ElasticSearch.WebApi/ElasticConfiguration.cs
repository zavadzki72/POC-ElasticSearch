using AutoMapper;
using Elasticsearch.Net;
using ElasticSearch.WebApi.Interfaces;
using Nest;

namespace ElasticSearch.WebApi
{
    public abstract class ElasticConfiguration<TModel, TIndexModel> 
        where TModel : class 
        where TIndexModel : class
    {
        protected readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        private ElasticClient? _client;

        internal ElasticClient Client
        {
            get
            {
                _client ??= GetClient();
                return _client;
            }
        }

        private static string DefaultIndex
        {
            get
            {
                IElasticSearchQueryModel? instance = (IElasticSearchQueryModel?)Activator.CreateInstance(typeof(TIndexModel), true);
                return instance?.GetIndexName ?? string.Empty;
            }
        }

        protected ElasticConfiguration(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        internal ElasticClient GetClient()
        {

            if (_client != null)
            {
                return _client;
            }

            var url = _configuration["Elasticsearch:Url"];
            var uris = new[] { new Uri(url) };

            var connectionPool = new SniffingConnectionPool(uris);
            var connection = new HttpConnection();
            var connectionSettings = new ConnectionSettings(connectionPool, connection).DefaultIndex(DefaultIndex);

#if DEBUG
            connectionSettings.EnableDebugMode().PrettyJson();
#endif

            connectionSettings.DisablePing();
            connectionSettings.SniffOnStartup(false);

            _client = new ElasticClient(connectionSettings);

            return _client;
        }


        public async Task<bool> IndexAsync(TModel document)
        {

            var indexModel = _mapper.Map<TIndexModel>(document);

            var indexName = indexModel.GetType().GetProperty("GetIndexName")?.GetValue(indexModel, null);

            var request = new IndexRequest<TIndexModel>(index: indexName?.ToString())
            {
                Document = indexModel
            };

            await Client.IndexAsync(request);

            return true;
        }

        public async Task<bool> RemoveAllAsync()
        {
            await Client.DeleteByQueryAsync<TIndexModel>(d => d.MatchAll());
            return true;
        }
    }

    internal class LazyAsync<T> : Lazy<Task<T>>
    {
        public LazyAsync(Func<Task<T>> taskFactory) : base(
            () => Task.Factory.StartNew(taskFactory).Unwrap())
        { }
    }
}
