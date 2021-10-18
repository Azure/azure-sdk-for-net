namespace Azure.Analytics.Purview.Administration
{
    public partial class MetadataPolicyClient
    {
        protected MetadataPolicyClient() { }
        public MetadataPolicyClient(string endpoint, string collectionName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Get(string policyId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string policyId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetMetadataPolicies(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetadataPoliciesAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Update(string policyId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string policyId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class MetadataRolesClient
    {
        protected MetadataRolesClient() { }
        public MetadataRolesClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetMetadataRoles(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetadataRolesAsync(Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewAccountClient
    {
        protected PurviewAccountClient() { }
        public PurviewAccountClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Administration.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAccessKeys(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccessKeysAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetAccountProperties(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAccountPropertiesAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Analytics.Purview.Administration.PurviewCollection GetCollectionClient(string collectionName) { throw null; }
        public virtual Azure.Response GetCollections(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionsAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Analytics.Purview.Administration.PurviewResourceSetRule GetResourceSetRuleClient() { throw null; }
        public virtual Azure.Response GetResourceSetRules(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceSetRulesAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RegenerateAccessKey(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateAccessKeyAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateAccountProperties(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAccountPropertiesAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewAccountClientOptions : Azure.Core.ClientOptions
    {
        public PurviewAccountClientOptions(Azure.Analytics.Purview.Administration.PurviewAccountClientOptions.ServiceVersion version = Azure.Analytics.Purview.Administration.PurviewAccountClientOptions.ServiceVersion.V2019_11_01_preview) { }
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
        public virtual Azure.Response GetCollection(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCollectionPath(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionPathAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListChildCollectionNames(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListChildCollectionNamesAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewMetadataClientOptions : Azure.Core.ClientOptions
    {
        public PurviewMetadataClientOptions(Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions.ServiceVersion version = Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions.ServiceVersion.V2021_07_01) { }
        public enum ServiceVersion
        {
            V2021_07_01 = 1,
        }
    }
    public partial class PurviewResourceSetRule
    {
        protected PurviewResourceSetRule() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateResourceSetRule(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateResourceSetRuleAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteResourceSetRule(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteResourceSetRuleAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetResourceSetRule(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResourceSetRuleAsync(Azure.RequestOptions options = null) { throw null; }
    }
}
