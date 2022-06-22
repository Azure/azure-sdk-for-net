namespace Azure.Template
{
    public partial class AnalyzeClient
    {
        protected AnalyzeClient() { }
        public AnalyzeClient(Azure.Core.TokenCredential credential) { }
        public AnalyzeClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetStatus(string jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatusAsync(string jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Submit(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EntitiesClient
    {
        protected EntitiesClient() { }
        public EntitiesClient(Azure.Core.TokenCredential credential) { }
        public EntitiesClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Recognize(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RecognizeAsync(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class EntityLinkingClient
    {
        protected EntityLinkingClient() { }
        public EntityLinkingClient(Azure.Core.TokenCredential credential) { }
        public EntityLinkingClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Recognize(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RecognizeAsync(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class HealthClient
    {
        protected HealthClient() { }
        public HealthClient(Azure.Core.TokenCredential credential) { }
        public HealthClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Cancel(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetStatus(string jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatusAsync(string jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Submit(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), bool? showStats = default(bool?), string stringIndexType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitAsync(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), bool? showStats = default(bool?), string stringIndexType = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class KeyPhrasesClient
    {
        protected KeyPhrasesClient() { }
        public KeyPhrasesClient(Azure.Core.TokenCredential credential) { }
        public KeyPhrasesClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response IdentifyKeyPhrases(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> IdentifyKeyPhrasesAsync(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class LanguagesClient
    {
        protected LanguagesClient() { }
        public LanguagesClient(Azure.Core.TokenCredential credential) { }
        public LanguagesClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Detect(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectAsync(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class PiiClient
    {
        protected PiiClient() { }
        public PiiClient(Azure.Core.TokenCredential credential) { }
        public PiiClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Recognize(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, string domain = null, System.Collections.Generic.IEnumerable<string> piiCategories = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RecognizeAsync(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, string domain = null, System.Collections.Generic.IEnumerable<string> piiCategories = null, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class SentimentClient
    {
        protected SentimentClient() { }
        public SentimentClient(Azure.Core.TokenCredential credential) { }
        public SentimentClient(Azure.Core.TokenCredential credential, System.Uri endpoint, Azure.Template.TextAnalyticsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Analyze(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? opinionMining = default(bool?), bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeAsync(Azure.Core.RequestContent content, string modelVersion = null, bool? loggingOptOut = default(bool?), string stringIndexType = null, bool? opinionMining = default(bool?), bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class TextAnalyticsClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalyticsClientOptions(Azure.Template.TextAnalyticsClientOptions.ServiceVersion version = Azure.Template.TextAnalyticsClientOptions.ServiceVersion.Vv3_1) { }
        public enum ServiceVersion
        {
            Vv3_1 = 1,
        }
    }
}
namespace Azure.Template.Models
{
    public partial class SecretBundle
    {
        internal SecretBundle() { }
        public string ContentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kid { get { throw null; } }
        public bool? Managed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } }
    }
}
