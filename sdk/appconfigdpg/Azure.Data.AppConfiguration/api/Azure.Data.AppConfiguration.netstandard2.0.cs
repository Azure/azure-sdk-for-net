namespace Azure.Data.AppConfiguration
{
    public partial class AzureAppConfigurationClient
    {
        protected AzureAppConfigurationClient() { }
        public AzureAppConfigurationClient(string endpoint, string syncToken = null, Azure.Data.AppConfiguration.AzureAppConfigurationClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CheckKeys(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckKeysAsync(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckKeyValue(string key, string label = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckKeyValueAsync(string key, string label = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckKeyValues(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckKeyValuesAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckLabels(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckLabelsAsync(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckRevisions(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckRevisionsAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteKeyValue(string key, string label = null, Azure.ETag? ifMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKeyValueAsync(string key, string label = null, Azure.ETag? ifMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteLock(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLockAsync(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetKeys(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetKeysAsync(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetKeyValue(string key, string label = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetKeyValueAsync(string key, string label = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetKeyValues(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetKeyValuesAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLabels(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLabelsAsync(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRevisions(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRevisionsAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PutKeyValue(string key, Azure.Core.RequestContent content, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutKeyValueAsync(string key, Azure.Core.RequestContent content, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PutLock(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutLockAsync(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AzureAppConfigurationClientOptions : Azure.Core.ClientOptions
    {
        public AzureAppConfigurationClientOptions(Azure.Data.AppConfiguration.AzureAppConfigurationClientOptions.ServiceVersion version = Azure.Data.AppConfiguration.AzureAppConfigurationClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
}
