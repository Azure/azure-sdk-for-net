namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewClassificationRuleClient
    {
        protected PurviewClassificationRuleClient() { }
        public PurviewClassificationRuleClient(System.Uri endpoint, string classificationRuleName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetVersions(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVersionsAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response TagVersion(int classificationRuleVersion, string action, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TagVersionAsync(int classificationRuleVersion, string action, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class PurviewDataSourceClient
    {
        protected PurviewDataSourceClient() { }
        public PurviewDataSourceClient(System.Uri endpoint, string dataSourceName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetChildren(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetChildrenAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public Azure.Analytics.Purview.Scanning.PurviewScanClient GetScanClient(string scanName) { throw null; }
        public virtual Azure.Response GetScans(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScansAsync(Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class PurviewScanClient
    {
        protected PurviewScanClient() { }
        public PurviewScanClient(System.Uri endpoint, string dataSourceName, string scanName, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelScan(string runId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelScanAsync(string runId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateOrUpdate(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateFilter(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateFilterAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTrigger(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTriggerAsync(Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteTrigger(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTriggerAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetFilter(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFilterAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetRuns(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunsAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetTrigger(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTriggerAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response RunScan(string runId, string scanLevel = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunScanAsync(string runId, string scanLevel = null, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class PurviewScanningServiceClient
    {
        protected PurviewScanningServiceClient() { }
        public PurviewScanningServiceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Purview.Scanning.PurviewScanningServiceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateKeyVaultReference(string azureKeyVaultName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateKeyVaultReferenceAsync(string azureKeyVaultName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateScanRuelset(string scanRulesetName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateScanRuelsetAsync(string scanRulesetName, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteKeyVaultReference(string azureKeyVaultName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteKeyVaultReferenceAsync(string azureKeyVaultName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response DeleteScanRuleset(string scanRulesetName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteScanRulesetAsync(string scanRulesetName, Azure.RequestOptions requestOptions = null) { throw null; }
        public Azure.Analytics.Purview.Scanning.PurviewClassificationRuleClient GetClassificationRuleClient(string classificationRuleName) { throw null; }
        public virtual Azure.Response GetClassificationRules(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationRulesAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public Azure.Analytics.Purview.Scanning.PurviewDataSourceClient GetDataSourceClient(string dataSourceName) { throw null; }
        public virtual Azure.Response GetDataSources(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDataSourcesAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetKeyVaultReference(string azureKeyVaultName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetKeyVaultReferenceAsync(string azureKeyVaultName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetKeyVaultReferences(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetKeyVaultReferencesAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetLatestSystemRulestes(string dataSourceType = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLatestSystemRulestesAsync(string dataSourceType = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetScanRuleset(string scanRulesetName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScanRulesetAsync(string scanRulesetName, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetScanRulesets(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScanRulesetsAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSystemRulesets(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSystemRulesetsForDataSource(string dataSourceType, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsForDataSourceAsync(string dataSourceType, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSystemRulesetsForVersion(int version, string dataSourceType = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsForVersionAsync(int version, string dataSourceType = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSystemRulesetsVersions(string dataSourceType = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSystemRulesetsVersionsAsync(string dataSourceType = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetUnparentedDataSources(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnparentedDataSourcesAsync(Azure.RequestOptions requestOptions = null) { throw null; }
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
