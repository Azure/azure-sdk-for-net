namespace Azure.Analytics.Purview.Account
{
    public partial class AccountsClient
    {
        protected AccountsClient() { }
        public AccountsClient(Azure.Core.TokenCredential credential, System.Uri endpoint = null, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Get(Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListKeys(Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> ListKeysAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response RegenerateKeys(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateKeysAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Update(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class CollectionsClient
    {
        protected CollectionsClient() { }
        public CollectionsClient(Azure.Core.TokenCredential credential, System.Uri endpoint = null, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(string collectionName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(string collectionName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Delete(string collectionName, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Get(string collectionName, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string collectionName, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetChildCollectionNames(string collectionName, string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetChildCollectionNamesAsync(string collectionName, string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetCollectionPath(string collectionName, string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCollectionPathAsync(string collectionName, string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListByAccount(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> ListByAccountAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
    }
    public partial class PurviewAccountClientOptions : Azure.Core.ClientOptions
    {
        public PurviewAccountClientOptions(Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion version = Azure.Analytics.Purview.Account.PurviewAccountClientOptions.ServiceVersion.V2019_11_01_preview) { }
        public enum ServiceVersion
        {
            V2019_11_01_preview = 1,
        }
    }
    public partial class ResourceSetRuleConfigsClient
    {
        protected ResourceSetRuleConfigsClient() { }
        public ResourceSetRuleConfigsClient(Azure.Core.TokenCredential credential, System.Uri endpoint = null, Azure.Analytics.Purview.Account.PurviewAccountClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Get(Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListByAccount(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response> ListByAccountAsync(string skipToken = null, Azure.RequestOptions options = null) { throw null; }
    }
}
