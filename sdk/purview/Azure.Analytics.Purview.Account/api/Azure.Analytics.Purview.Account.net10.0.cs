namespace Azure.Analytics.Purview.Account
{
    public partial class PurviewAccountClient
    {
        protected PurviewAccountClient() { }
        public PurviewAccountClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public PurviewAccountClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAccessKeys(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccessKeysAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetAccountProperties(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccountPropertiesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCollections(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCollectionsAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Analytics.Purview.Account.PurviewCollection GetPurviewCollectionClient(string collectionName) { throw null; }
        public virtual Azure.Analytics.Purview.Account.PurviewResourceSetRule GetPurviewResourceSetRuleClient() { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetResourceSetRules(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetResourceSetRulesAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response RegenerateAccessKey(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateAccessKeyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateAccountProperties(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAccountPropertiesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewAccountClientOptions : Azure.Core.ClientOptions
    {
        public PurviewAccountClientOptions(Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion version = Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion.V2019_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2019_11_01_Preview = 1,
        }
    }
    public partial class PurviewCollection
    {
        protected PurviewCollection() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateCollection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateCollectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteCollection(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCollectionAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetChildCollectionNames(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetChildCollectionNamesAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetCollection(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetCollectionPath(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionPathAsync(Azure.RequestContext context) { throw null; }
    }
    public partial class PurviewResourceSetRule
    {
        protected PurviewResourceSetRule() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateResourceSetRule(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateResourceSetRuleAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteResourceSetRule(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteResourceSetRuleAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetResourceSetRule(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceSetRuleAsync(Azure.RequestContext context) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsPurviewAccountClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Account.PurviewAccountClient, Azure.Analytics.Purview.Account.PurviewAccountClientOptions> AddPurviewAccountClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Purview.Account.PurviewAccountClient, Azure.Analytics.Purview.Account.PurviewAccountClientOptions> AddPurviewAccountClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
