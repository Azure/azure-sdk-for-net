namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewClassificationRuleClient
    {
        protected PurviewClassificationRuleClient() { }
        public PurviewClassificationRuleClient(System.Uri endpoint, string classificationRuleName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response TagVersion(int classificationRuleVersion, string action, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TagVersionAsync(int classificationRuleVersion, string action, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewDataSourceClient
    {
        protected PurviewDataSourceClient() { }
        public PurviewDataSourceClient(System.Uri endpoint, string dataSourceName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Analytics.Purview.Scanning.PurviewScanClient GetScanClient(string scanName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetScans(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetScansAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewScanClient
    {
        protected PurviewScanClient() { }
        public PurviewScanClient(System.Uri endpoint, string dataSourceName, string scanName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelScan(string runId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelScanAsync(string runId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateFilter(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateFilterAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTrigger(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTriggerAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTrigger(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTriggerAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetFilter(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFilterAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRuns(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRunsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTrigger(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTriggerAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RunScan(string runId, string scanLevel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunScanAsync(string runId, string scanLevel = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewScanningServiceClient
    {
        protected PurviewScanningServiceClient() { }
        public PurviewScanningServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateKeyVaultReference(string keyVaultName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateKeyVaultReferenceAsync(string keyVaultName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateScanRuleset(string scanRulesetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateScanRulesetAsync(string scanRulesetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteKeyVaultReference(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKeyVaultReferenceAsync(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteScanRuleset(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteScanRulesetAsync(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Analytics.Purview.Scanning.PurviewClassificationRuleClient GetClassificationRuleClient(string classificationRuleName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetClassificationRules(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetClassificationRulesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Analytics.Purview.Scanning.PurviewDataSourceClient GetDataSourceClient(string dataSourceName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDataSources(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDataSourcesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetKeyVaultReference(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetKeyVaultReferenceAsync(string keyVaultName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetKeyVaultReferences(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetKeyVaultReferencesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLatestSystemRulesets(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLatestSystemRulesetsAsync(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetScanRuleset(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScanRulesetAsync(string scanRulesetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetScanRulesets(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetScanRulesetsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSystemRulesets(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSystemRulesetsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSystemRulesetsForDataSource(string dataSourceType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsForDataSourceAsync(string dataSourceType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSystemRulesetsForVersion(int version, string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsForVersionAsync(int version, string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSystemRulesetsVersions(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSystemRulesetsVersionsAsync(string dataSourceType = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class PurviewScanningServiceClientOptions : Azure.Core.ClientOptions
    {
        public PurviewScanningServiceClientOptions(Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions.ServiceVersion version = Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions.ServiceVersion.V2018_12_01_preview) { }
        public enum ServiceVersion
        {
            V2018_12_01_preview = 1,
        }
    }
}
