namespace Azure.Analytics.Purview.Account
{
    public partial class PurviewAccountClient
    {
        protected PurviewAccountClient() { }
        public PurviewAccountClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAccessKeys(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccessKeysAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetAccountProperties(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccountPropertiesAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Analytics.Purview.Account.PurviewCollection GetCollectionClient(string collectionName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCollections(Azure.RequestOptions options, string skipToken = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCollectionsAsync(Azure.RequestOptions options, string skipToken = null) { throw null; }
        public virtual Azure.Analytics.Purview.Account.PurviewResourceSetRule GetResourceSetRuleClient() { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetResourceSetRules(Azure.RequestOptions options, string skipToken = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetResourceSetRulesAsync(Azure.RequestOptions options, string skipToken = null) { throw null; }
        public virtual Azure.Response RegenerateAccessKey(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateAccessKeyAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateAccountProperties(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAccountPropertiesAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewAccountClientOptions : Azure.Core.ClientOptions
    {
        public PurviewAccountClientOptions(Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion version = Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion.V2019_11_01_preview) { }
        public enum ServiceVersion
        {
            V2019_11_01_preview = 1,
        }
    }
    public partial class PurviewCollection
    {
        protected PurviewCollection() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateCollection(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateCollectionAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteCollection(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCollectionAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCollection(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetCollectionPath(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionPathAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> ListChildCollectionNames(Azure.RequestOptions options, string skipToken = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> ListChildCollectionNamesAsync(Azure.RequestOptions options, string skipToken = null) { throw null; }
    }
    public partial class PurviewResourceSetRule
    {
        protected PurviewResourceSetRule() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateResourceSetRule(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateResourceSetRuleAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteResourceSetRule(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteResourceSetRuleAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetResourceSetRule(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceSetRuleAsync(Azure.RequestOptions options) { throw null; }
    }
}
