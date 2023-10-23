namespace Azure.Template
{
    public partial class TemplateClient
    {
        protected TemplateClient() { }
        public TemplateClient(string vaultBaseUrl, Azure.Core.TokenCredential credential) { }
        public TemplateClient(string vaultBaseUrl, Azure.Core.TokenCredential credential, Azure.Template.TemplateClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetSecret(string secretName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretAsync(string secretName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Template.Models.SecretBundle> GetSecretValue(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Models.SecretBundle>> GetSecretValueAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateClientOptions : Azure.Core.ClientOptions
    {
        public TemplateClientOptions(Azure.Template.TemplateClientOptions.ServiceVersion version = Azure.Template.TemplateClientOptions.ServiceVersion.V7_0) { }
        public enum ServiceVersion
        {
            V7_0 = 1,
        }
    }
}
namespace Azure.Template.Models
{
    public partial class SecretBundle : System.Net.ClientModel.Core.IJsonModel<Azure.Template.Models.SecretBundle>, System.Net.ClientModel.Core.IModel<Azure.Template.Models.SecretBundle>
    {
        internal SecretBundle() { }
        public string ContentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kid { get { throw null; } }
        public bool? Managed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.Template.Models.SecretBundle System.Net.ClientModel.Core.IJsonModel<Azure.Template.Models.SecretBundle>.Read(ref System.Text.Json.Utf8JsonReader reader, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        Azure.Template.Models.SecretBundle System.Net.ClientModel.Core.IModel<Azure.Template.Models.SecretBundle>.Read(System.BinaryData data, System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        public System.BinaryData Write(System.Net.ClientModel.ModelReaderWriterOptions options) { throw null; }
        public void Write(System.Text.Json.Utf8JsonWriter writer, System.Net.ClientModel.ModelReaderWriterOptions options) { }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class TemplateClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Template.TemplateClient, Azure.Template.TemplateClientOptions> AddTemplateClient<TBuilder>(this TBuilder builder, string vaultBaseUrl) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Template.TemplateClient, Azure.Template.TemplateClientOptions> AddTemplateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
