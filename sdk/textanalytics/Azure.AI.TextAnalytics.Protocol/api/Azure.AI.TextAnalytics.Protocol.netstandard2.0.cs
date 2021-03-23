namespace Azure.AI.TextAnalytics.Protocol
{
    public partial class TextAnalyticsClient
    {
        protected TextAnalyticsClient() { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TextAnalyticsClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Core.ProtocolClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        protected Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetEntities(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesAsync(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEntitiesPii(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string domain = null, string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEntitiesPiiAsync(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string domain = null, string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual Azure.Core.Request GetEntitiesPiiRequest(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string domain = null, string stringIndexType = null) { throw null; }
        protected virtual Azure.Core.Request GetEntitiesRequest(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string stringIndexType = null) { throw null; }
        public virtual Azure.Response GetKeyPhrases(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetKeyPhrasesAsync(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual Azure.Core.Request GetKeyPhrasesRequest(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?)) { throw null; }
        public virtual Azure.Response GetLanguages(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLanguagesAsync(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual Azure.Core.Request GetLanguagesRequest(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?)) { throw null; }
        public virtual Azure.Response GetLinkedEntities(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLinkedEntitiesAsync(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual Azure.Core.Request GetLinkedEntitiesRequest(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), string stringIndexType = null) { throw null; }
        public virtual Azure.Response GetSentiment(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), bool? opinionMining = false, string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSentimentAsync(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), bool? opinionMining = default(bool?), string stringIndexType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual Azure.Core.Request GetSentimentRequest(Azure.Core.RequestContent body, string modelVersion = null, bool? showStats = default(bool?), bool? opinionMining = false, string stringIndexType = null) { throw null; }
    }
}
