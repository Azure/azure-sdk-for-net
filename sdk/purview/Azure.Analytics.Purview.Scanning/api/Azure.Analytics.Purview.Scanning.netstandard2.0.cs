namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewClassificationRuleClient
    {
        protected PurviewClassificationRuleClient() { }
        public PurviewClassificationRuleClient(System.Uri endpoint, string classificationRuleName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response TagVersion(int classificationRuleVersion, string action, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TagVersionAsync(int classificationRuleVersion, string action, Azure.RequestOptions options) { throw null; }
    }
    public partial class PurviewDataSourceClient
    {
        protected PurviewDataSourceClient() { }
        public PurviewDataSourceClient(System.Uri endpoint, string dataSourceName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetChildren(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetChildrenAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestOptions options) { throw null; }
        public Azure.Analytics.Purview.Scanning.PurviewScanClient GetScanClient(string scanName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetScans(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetScansAsync(Azure.RequestOptions options) { throw null; }
    }
    public partial class PurviewScanClient
    {
        protected PurviewScanClient() { }
        public PurviewScanClient(System.Uri endpoint, string dataSourceName, string scanName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelScan(string runId, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelScanAsync(string runId, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateFilter(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateFilterAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTrigger(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTriggerAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteTrigger(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTriggerAsync(Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetFilter(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFilterAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRuns(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRunsAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetTrigger(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTriggerAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response RunScan(string runId, Azure.RequestOptions options, string scanLevel = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunScanAsync(string runId, Azure.RequestOptions options, string scanLevel = null) { throw null; }
    }
    public partial class PurviewScanningServiceClient
    {
        protected PurviewScanningServiceClient() { }
        public PurviewScanningServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateKeyVaultReference(string azureKeyVaultName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateKeyVaultReferenceAsync(string azureKeyVaultName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateScanRuelset(string scanRulesetName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateScanRuelsetAsync(string scanRulesetName, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteKeyVaultReference(string azureKeyVaultName, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKeyVaultReferenceAsync(string azureKeyVaultName, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteScanRuleset(string scanRulesetName, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteScanRulesetAsync(string scanRulesetName, Azure.RequestOptions options = null) { throw null; }
        public Azure.Analytics.Purview.Scanning.PurviewClassificationRuleClient GetClassificationRuleClient(string classificationRuleName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetClassificationRules(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetClassificationRulesAsync(Azure.RequestOptions options) { throw null; }
        public Azure.Analytics.Purview.Scanning.PurviewDataSourceClient GetDataSourceClient(string dataSourceName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDataSources(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDataSourcesAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetKeyVaultReference(string azureKeyVaultName, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetKeyVaultReferenceAsync(string azureKeyVaultName, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetKeyVaultReferences(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetKeyVaultReferencesAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetLatestSystemRulestes(Azure.RequestOptions options, string dataSourceType = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLatestSystemRulestesAsync(Azure.RequestOptions options, string dataSourceType = null) { throw null; }
        public virtual Azure.Response GetScanRuleset(string scanRulesetName, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScanRulesetAsync(string scanRulesetName, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetScanRulesets(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetScanRulesetsAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSystemRulesets(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSystemRulesetsAsync(Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetSystemRulesetsForDataSource(string dataSourceType, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsForDataSourceAsync(string dataSourceType, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response GetSystemRulesetsForVersion(int version, Azure.RequestOptions options, string dataSourceType = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsForVersionAsync(int version, Azure.RequestOptions options, string dataSourceType = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSystemRulesetsVersions(Azure.RequestOptions options, string dataSourceType = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSystemRulesetsVersionsAsync(Azure.RequestOptions options, string dataSourceType = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUnparentedDataSources(Azure.RequestOptions options) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUnparentedDataSourcesAsync(Azure.RequestOptions options) { throw null; }
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
