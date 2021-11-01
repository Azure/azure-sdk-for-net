namespace Azure.Analytics.Purview.Administration
{
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
        public virtual Azure.Pageable<System.BinaryData> GetCollections(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCollectionsAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Analytics.Purview.Administration.PurviewResourceSetRule GetResourceSetRuleClient() { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetResourceSetRules(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetResourceSetRulesAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetChildCollectionNames(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetChildCollectionNamesAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCollection(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCollectionPath(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionPathAsync(Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewMetadataClientOptions : Azure.Core.ClientOptions
    {
        public PurviewMetadataClientOptions(Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions.ServiceVersion version = Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions.ServiceVersion.V2021_07_01) { }
        public enum ServiceVersion
        {
            V2021_07_01 = 1,
        }
    }
    public partial class PurviewMetadataPolicyClient
    {
        protected PurviewMetadataPolicyClient() { }
        public PurviewMetadataPolicyClient(System.Uri endpoint, string collectionName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetMetadataPolicies(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetadataPoliciesAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetMetadataPolicy(string policyId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetadataPolicyAsync(string policyId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response UpdateMetadataPolicy(string policyId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMetadataPolicyAsync(string policyId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewMetadataRolesClient
    {
        protected PurviewMetadataRolesClient() { }
        public PurviewMetadataRolesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Administration.PurviewMetadataClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetMetadataRoles(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetadataRolesAsync(Azure.RequestOptions options = null) { throw null; }
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
