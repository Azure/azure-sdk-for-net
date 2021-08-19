namespace Azure.Analytics.Purview.Account
{
    public partial class AccountsClient
    {
        protected AccountsClient() { }
        public AccountsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAccessKeys(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccessKeysAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetAccountProperties(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccountPropertiesAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RegenerateAccessKey(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateAccessKeyAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateAccountProperties(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAccountPropertiesAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class CollectionsClient
    {
        protected CollectionsClient() { }
        public CollectionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateCollection(string collectionName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateCollectionAsync(string collectionName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteCollection(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCollectionAsync(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCollection(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAsync(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCollectionPath(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionPathAsync(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListChildCollectionNames(string collectionName, string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListChildCollectionNamesAsync(string collectionName, string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListCollections(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListCollectionsAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewAccountClientOptions : Azure.Core.ClientOptions
    {
        public PurviewAccountClientOptions(Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion version = Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion.V2019_11_01_preview) { }
        public enum ServiceVersion
        {
            V2019_11_01_preview = 1,
        }
    }
    public partial class ResourceSetRulesClient
    {
        protected ResourceSetRulesClient() { }
        public ResourceSetRulesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateResourceSetRule(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateResourceSetRuleAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteResourceSetRule(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteResourceSetRuleAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetResourceSetRule(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceSetRuleAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListResourceSetRules(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListResourceSetRulesAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
    }
}
