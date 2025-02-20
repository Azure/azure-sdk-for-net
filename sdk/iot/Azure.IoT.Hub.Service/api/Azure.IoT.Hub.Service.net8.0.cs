namespace Azure.IoT.Hub.Service
{
    public enum BulkIfMatchPrecondition
    {
        Unconditional = 0,
        IfMatch = 1,
    }
    public partial class CloudToDeviceMessagesClient
    {
        public CloudToDeviceMessagesClient() { }
    }
    public partial class ConfigurationsClient
    {
        protected ConfigurationsClient() { }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.TwinConfiguration> CreateOrUpdateConfiguration(Azure.IoT.Hub.Service.Models.TwinConfiguration configuration, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.TwinConfiguration>> CreateOrUpdateConfigurationAsync(Azure.IoT.Hub.Service.Models.TwinConfiguration configuration, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfiguration(Azure.IoT.Hub.Service.Models.TwinConfiguration configuration, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationAsync(Azure.IoT.Hub.Service.Models.TwinConfiguration configuration, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.TwinConfiguration> GetConfiguration(string configurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.TwinConfiguration>> GetConfigurationAsync(string configurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.TwinConfiguration>> GetConfigurations(int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.TwinConfiguration>>> GetConfigurationsAsync(int? count = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.ConfigurationQueriesTestResponse>> TestQueries(Azure.IoT.Hub.Service.Models.ConfigurationQueriesTestInput configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.ConfigurationQueriesTestResponse> TestQueriesAsync(Azure.IoT.Hub.Service.Models.ConfigurationQueriesTestInput configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevicesClient
    {
        protected DevicesClient() { }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> CreateIdentities(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceIdentity> deviceIdentities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> CreateIdentitiesAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceIdentity> deviceIdentities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> CreateIdentitiesWithTwin(System.Collections.Generic.IDictionary<Azure.IoT.Hub.Service.Models.DeviceIdentity, Azure.IoT.Hub.Service.Models.TwinData> devices, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> CreateIdentitiesWithTwinAsync(System.Collections.Generic.IDictionary<Azure.IoT.Hub.Service.Models.DeviceIdentity, Azure.IoT.Hub.Service.Models.TwinData> devices, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.DeviceIdentity> CreateOrUpdateIdentity(Azure.IoT.Hub.Service.Models.DeviceIdentity deviceIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.DeviceIdentity>> CreateOrUpdateIdentityAsync(Azure.IoT.Hub.Service.Models.DeviceIdentity deviceIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> DeleteIdentities(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceIdentity> deviceIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> DeleteIdentitiesAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceIdentity> deviceIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIdentity(Azure.IoT.Hub.Service.Models.DeviceIdentity deviceIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIdentityAsync(Azure.IoT.Hub.Service.Models.DeviceIdentity deviceIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.DeviceIdentity> GetIdentity(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.DeviceIdentity>> GetIdentityAsync(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.TwinData> GetTwin(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.TwinData>> GetTwinAsync(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.Hub.Service.Models.TwinData> GetTwins(int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.Hub.Service.Models.TwinData> GetTwinsAsync(int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.CloudToDeviceMethodResponse> InvokeMethod(string deviceId, Azure.IoT.Hub.Service.Models.CloudToDeviceMethodRequest directMethodRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.CloudToDeviceMethodResponse>> InvokeMethodAsync(string deviceId, Azure.IoT.Hub.Service.Models.CloudToDeviceMethodRequest directMethodRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> UpdateIdentities(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceIdentity> deviceIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> UpdateIdentitiesAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceIdentity> deviceIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.TwinData> UpdateTwin(Azure.IoT.Hub.Service.Models.TwinData twinUpdate, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.TwinData>> UpdateTwinAsync(Azure.IoT.Hub.Service.Models.TwinData twinUpdate, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> UpdateTwins(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.TwinData> twinUpdates, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> UpdateTwinsAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.TwinData> twinUpdates, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FilesClient
    {
        public FilesClient() { }
    }
    public enum IfMatchPrecondition
    {
        UnconditionalIfMatch = 0,
        IfMatch = 1,
    }
    public partial class IotHubServiceClient
    {
        protected IotHubServiceClient() { }
        public IotHubServiceClient(string connectionString) { }
        public IotHubServiceClient(string connectionString, Azure.IoT.Hub.Service.IotHubServiceClientOptions options) { }
        public IotHubServiceClient(System.Uri endpoint, Azure.IoT.Hub.Service.Authentication.IotHubSasCredential credential, Azure.IoT.Hub.Service.IotHubServiceClientOptions options = null) { }
        public virtual Azure.IoT.Hub.Service.ConfigurationsClient Configurations { get { throw null; } }
        public virtual Azure.IoT.Hub.Service.DevicesClient Devices { get { throw null; } }
        public virtual Azure.IoT.Hub.Service.FilesClient Files { get { throw null; } }
        public virtual Azure.IoT.Hub.Service.JobsClient Jobs { get { throw null; } }
        public virtual Azure.IoT.Hub.Service.CloudToDeviceMessagesClient Messages { get { throw null; } }
        public virtual Azure.IoT.Hub.Service.ModulesClient Modules { get { throw null; } }
        public virtual Azure.IoT.Hub.Service.QueryClient Query { get { throw null; } }
        public virtual Azure.IoT.Hub.Service.StatisticsClient Statistics { get { throw null; } }
    }
    public partial class IotHubServiceClientOptions : Azure.Core.ClientOptions
    {
        public IotHubServiceClientOptions(Azure.IoT.Hub.Service.IotHubServiceClientOptions.ServiceVersion version = Azure.IoT.Hub.Service.IotHubServiceClientOptions.ServiceVersion.V2020_03_13) { }
        public Azure.IoT.Hub.Service.IotHubServiceClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2020_03_13 = 1,
        }
    }
    public partial class JobsClient
    {
        protected JobsClient() { }
        public virtual Azure.Response<string> CancelImportExportJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> CancelImportExportJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.JobProperties> CreateExportDevicesJob(System.Uri outputBlobContainerUri, bool excludeKeys, Azure.IoT.Hub.Service.Models.ExportJobRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.JobProperties>> CreateExportDevicesJobAsync(System.Uri outputBlobContainerUri, bool excludeKeys, Azure.IoT.Hub.Service.Models.ExportJobRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.JobProperties> CreateImportDevicesJob(System.Uri importBlobContainerUri, System.Uri outputBlobContainerUri, Azure.IoT.Hub.Service.Models.ImportJobRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.JobProperties>> CreateImportDevicesJobAsync(System.Uri importBlobContainerUri, System.Uri outputBlobContainerUri, Azure.IoT.Hub.Service.Models.ImportJobRequestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.JobProperties> GetImportExportJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.JobProperties>> GetImportExportJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.JobProperties>> GetImportExportJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.JobProperties>>> GetImportExportJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModulesClient
    {
        protected ModulesClient() { }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> CreateIdentities(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.ModuleIdentity> moduleIdentities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> CreateIdentitiesAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.ModuleIdentity> moduleIdentities, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> CreateIdentitiesWithTwin(System.Collections.Generic.IDictionary<Azure.IoT.Hub.Service.Models.ModuleIdentity, Azure.IoT.Hub.Service.Models.TwinData> modules, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> CreateIdentitiesWithTwinAsync(System.Collections.Generic.IDictionary<Azure.IoT.Hub.Service.Models.ModuleIdentity, Azure.IoT.Hub.Service.Models.TwinData> modules, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.ModuleIdentity> CreateOrUpdateIdentity(Azure.IoT.Hub.Service.Models.ModuleIdentity moduleIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.ModuleIdentity>> CreateOrUpdateIdentityAsync(Azure.IoT.Hub.Service.Models.ModuleIdentity moduleIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> DeleteIdentities(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.ModuleIdentity> moduleIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> DeleteIdentitiesAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.ModuleIdentity> moduleIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIdentity(Azure.IoT.Hub.Service.Models.ModuleIdentity moduleIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIdentityAsync(Azure.IoT.Hub.Service.Models.ModuleIdentity moduleIdentity, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.ModuleIdentity>> GetIdentities(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.ModuleIdentity>>> GetIdentitiesAsync(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.ModuleIdentity> GetIdentity(string deviceId, string moduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.ModuleIdentity>> GetIdentityAsync(string deviceId, string moduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.TwinData> GetTwin(string deviceId, string moduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.TwinData>> GetTwinAsync(string deviceId, string moduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.IoT.Hub.Service.Models.TwinData> GetTwins(int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.Hub.Service.Models.TwinData> GetTwinsAsync(int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.CloudToDeviceMethodResponse> InvokeMethod(string deviceId, string moduleId, Azure.IoT.Hub.Service.Models.CloudToDeviceMethodRequest directMethodRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.CloudToDeviceMethodResponse>> InvokeMethodAsync(string deviceId, string moduleId, Azure.IoT.Hub.Service.Models.CloudToDeviceMethodRequest directMethodRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> UpdateIdentities(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.ModuleIdentity> moduleIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> UpdateIdentitiesAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.ModuleIdentity> moduleIdentities, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.TwinData> UpdateTwin(Azure.IoT.Hub.Service.Models.TwinData twinUpdate, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.TwinData>> UpdateTwinAsync(Azure.IoT.Hub.Service.Models.TwinData twinUpdate, Azure.IoT.Hub.Service.IfMatchPrecondition precondition = Azure.IoT.Hub.Service.IfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse> UpdateTwins(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.TwinData> twinUpdates, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse>> UpdateTwinsAsync(System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.TwinData> twinUpdates, Azure.IoT.Hub.Service.BulkIfMatchPrecondition precondition = Azure.IoT.Hub.Service.BulkIfMatchPrecondition.IfMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueryClient
    {
        protected QueryClient() { }
        public virtual Azure.Pageable<Azure.IoT.Hub.Service.Models.TwinData> Query(string query, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.IoT.Hub.Service.Models.TwinData> QueryAsync(string query, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StatisticsClient
    {
        protected StatisticsClient() { }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.DevicesStatistics> GetDevicesStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.DevicesStatistics>> GetDevicesStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.IoT.Hub.Service.Models.ServiceStatistics> GetServiceStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.IoT.Hub.Service.Models.ServiceStatistics>> GetServiceStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.IoT.Hub.Service.Authentication
{
    public partial class IotHubSasCredential : Azure.Core.TokenCredential
    {
        public IotHubSasCredential(string sharedAccessPolicy, string sharedAccessKey, System.TimeSpan timeToLive = default(System.TimeSpan)) { }
        public System.Uri Endpoint { get { throw null; } }
        public System.TimeSpan SasTokenTimeToLive { get { throw null; } }
        public string SharedAccessKey { get { throw null; } }
        public string SharedAccessPolicy { get { throw null; } }
        public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Azure.IoT.Hub.Service.Models
{
    public partial class AuthenticationMechanism
    {
        public AuthenticationMechanism() { }
        public Azure.IoT.Hub.Service.Models.SymmetricKey SymmetricKey { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.AuthenticationMechanismType? Type { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.X509Thumbprint X509Thumbprint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationMechanismType : System.IEquatable<Azure.IoT.Hub.Service.Models.AuthenticationMechanismType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationMechanismType(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.AuthenticationMechanismType CertificateAuthority { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.AuthenticationMechanismType None { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.AuthenticationMechanismType Sas { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.AuthenticationMechanismType SelfSigned { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.AuthenticationMechanismType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.AuthenticationMechanismType left, Azure.IoT.Hub.Service.Models.AuthenticationMechanismType right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.AuthenticationMechanismType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.AuthenticationMechanismType left, Azure.IoT.Hub.Service.Models.AuthenticationMechanismType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BulkRegistryOperationResponse
    {
        internal BulkRegistryOperationResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.DeviceRegistryOperationError> Errors { get { throw null; } }
        public bool? IsSuccessful { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarning> Warnings { get { throw null; } }
    }
    public partial class CloudToDeviceMethodRequest
    {
        public CloudToDeviceMethodRequest() { }
        public int? ConnectTimeoutInSeconds { get { throw null; } set { } }
        public string MethodName { get { throw null; } set { } }
        public object Payload { get { throw null; } set { } }
        public int? ResponseTimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class CloudToDeviceMethodResponse
    {
        internal CloudToDeviceMethodResponse() { }
        public object Payload { get { throw null; } }
        public int? Status { get { throw null; } }
    }
    public partial class ConfigurationContent
    {
        public ConfigurationContent() { }
        public System.Collections.Generic.IDictionary<string, object> DeviceContent { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> ModuleContent { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, object>> ModulesContent { get { throw null; } }
    }
    public partial class ConfigurationMetrics
    {
        public ConfigurationMetrics() { }
        public System.Collections.Generic.IDictionary<string, string> Queries { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, long> Results { get { throw null; } }
    }
    public partial class ConfigurationQueriesTestInput
    {
        public ConfigurationQueriesTestInput() { }
        public System.Collections.Generic.IDictionary<string, string> CustomMetricQueries { get { throw null; } }
        public string TargetCondition { get { throw null; } set { } }
    }
    public partial class ConfigurationQueriesTestResponse
    {
        internal ConfigurationQueriesTestResponse() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomMetricQueryErrors { get { throw null; } }
        public string TargetConditionError { get { throw null; } }
    }
    public partial class DeviceCapabilities
    {
        public DeviceCapabilities() { }
        public bool? IsIotEdgeDevice { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceConnectionState : System.IEquatable<Azure.IoT.Hub.Service.Models.DeviceConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceConnectionState(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DeviceConnectionState Connected { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceConnectionState Disconnected { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.DeviceConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.DeviceConnectionState left, Azure.IoT.Hub.Service.Models.DeviceConnectionState right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.DeviceConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.DeviceConnectionState left, Azure.IoT.Hub.Service.Models.DeviceConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceIdentity
    {
        public DeviceIdentity() { }
        public Azure.IoT.Hub.Service.Models.AuthenticationMechanism Authentication { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.DeviceCapabilities Capabilities { get { throw null; } set { } }
        public int? CloudToDeviceMessageCount { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.DeviceConnectionState? ConnectionState { get { throw null; } set { } }
        public System.DateTimeOffset? ConnectionStateUpdatedTime { get { throw null; } set { } }
        public string DeviceId { get { throw null; } set { } }
        public string DeviceScope { get { throw null; } set { } }
        public string Etag { get { throw null; } set { } }
        public string GenerationId { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivityTime { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.DeviceStatus? Status { get { throw null; } set { } }
        public string StatusReason { get { throw null; } set { } }
        public System.DateTimeOffset? StatusUpdatedTime { get { throw null; } set { } }
    }
    public partial class DeviceJobStatistics
    {
        internal DeviceJobStatistics() { }
        public int? DeviceCount { get { throw null; } }
        public int? FailedCount { get { throw null; } }
        public int? PendingCount { get { throw null; } }
        public int? RunningCount { get { throw null; } }
        public int? SucceededCount { get { throw null; } }
    }
    public partial class DeviceRegistryOperationError
    {
        internal DeviceRegistryOperationError() { }
        public string DeviceId { get { throw null; } }
        public Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode? ErrorCode { get { throw null; } }
        public string ErrorStatus { get { throw null; } }
        public string ModuleId { get { throw null; } }
        public string Operation { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceRegistryOperationErrorCode : System.IEquatable<Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceRegistryOperationErrorCode(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode AmqpAddressNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ApplyConfigurationAlreadyInProgressOnDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ArgumentInvalid { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ArgumentNull { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode AsyncOperationNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode AzureStorageTimeout { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode AzureTableStoreError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode AzureTableStoreNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode BackupTimedOut { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode BlobContainerValidationError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode BulkAddDevicesNotSupported { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode BulkRegistryOperationFailure { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CallbackSubscriptionConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CannotModifyImmutableConfigurationContent { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CannotRegisterModuleToModule { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CertificateAuthorityConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CertificateAuthorityNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CertificateNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CheckpointStoreNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ClientClosedRequest { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConfigReadFailed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConfigurationAlreadyExists { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConfigurationCountLimitExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConfigurationNotAvailable { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConfigurationNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConnectionForcefullyClosed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConnectionForcefullyClosedOnFaultInjection { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConnectionForcefullyClosedOnNewConnection { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConnectionRejectedOnFaultInjection { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ConnectionUnavailable { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CustomAllocationFailed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CustomAllocationIotHubNotSpecified { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode CustomAllocationUnauthorizedAccess { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DefaultStorageEndpointNotConfigured { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeserializationError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceAlreadyExists { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceConnectionClosedRemotely { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceDefinedMultipleTimes { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceGroupConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceGroupNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceInvalidResultCount { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceJobAlreadyExists { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceLocked { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceMaximumActiveFileUploadLimitExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceMaximumQueueDepthExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceMaximumQueueSizeExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceMessageLockLost { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceModelMaxIndexablePropertiesExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceModelMaxPropertiesExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceNotOnline { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceRecordConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceRecordNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceRegistrationNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceStorageEntitySerializationError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceThrottlingLimitExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DeviceUnavailable { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DigitalTwinInterfaceNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DigitalTwinModelAlreadyExists { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DigitalTwinModelCountLimitExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DigitalTwinModelExistsWithOtherModelType { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DigitalTwinModelNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode DocumentDbInvalidReturnValue { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ElasticPoolNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ElasticPoolTenantHubNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode EnrollmentConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode EnrollmentGroupConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode EnrollmentGroupNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode EnrollmentNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode EtagDoesNotMatch { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode EventHubLinkAlreadyClosed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ExpiredFileUploadCorrelationId { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode FeatureNotSupported { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GatewayTimeout { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericBadGateway { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericBadRequest { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericForbidden { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericGatewayTimeout { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericMethodNotAllowed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericPreconditionFailed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericRequestEntityTooLarge { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericServerError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericServiceUnavailable { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericTimeout { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericTooManyRequests { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericUnauthorized { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GenericUnsupportedMediaType { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GroupNotAvailable { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GroupNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GroupRecordConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode GroupRecordNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode HostingServiceNotAvailable { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ImportDevicesNotSupported { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ImportWarningExistsError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IncompatibleDataType { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InflightMessagesInLink { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InterfaceNameCompressionModelCountLimitExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InterfaceNameModelAlreadyExists { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InterfaceNameModelNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidBlobState { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidConfigurationContent { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidConfigurationCustomMetricsQuery { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidConfigurationTargetCondition { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidContainerReceiveLink { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidContentEncodingOrType { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidDeviceScope { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidDigitalTwinJsonPatch { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidDigitalTwinPatch { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidDigitalTwinPatchPath { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidDigitalTwinPayload { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidEndorsementKey { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidEndpointAuthenticationType { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidEnrollmentGroupId { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidErrorCode { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidFileUploadCompletionStatus { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidFileUploadCorrelationId { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidMessageExpiryTime { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidMessagingEndpoint { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidOperation { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidPartitionEpoch { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidPnPDesiredProperties { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidPnPInterfaceDefinition { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidPnPReportedProperties { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidPnPWritableReportedProperties { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidProtocolVersion { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidRegistrationId { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidResponseWhileProxying { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidRouteTestInput { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidSchemaVersion { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidSourceOnRoute { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidStorageEndpoint { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidStorageEndpointOrBlob { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidStorageEndpointProperty { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidStorageRootKey { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode InvalidThrottleParameter { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotDpsSuspended { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotDpsSuspending { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubActivationFailed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubFailingOver { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubFormatError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubMaxCbsTokenExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubQuotaExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubRestoring { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubSuspended { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubUnauthorized { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode IotHubUnauthorizedAccess { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode JobAlreadyExists { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode JobCancelled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode JobNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode JobQuotaExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode JobRunPreconditionFailed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode KeyEncryptionKeyRevoked { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode LinkCreationConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode LinkedHubConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode LinkedHubNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ManagedIdentityNotEnabled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode MessageTooLarge { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ModelAlreadyExists { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ModelRepoEndpointError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ModuleAlreadyExistsOnDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ModuleNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode NullMessage { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode OperationNotAllowedInCurrentState { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode OperationNotAvailableInCurrentTier { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode OrchestrationOperationFailed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode OrphanDiscoveryDocument { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode PartitionNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode PreconditionFailed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ProvisioningRecordConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ProvisioningRecordNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ProvisioningSettingsConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ProvisioningSettingsNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode QueryStoreClusterNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode QuotaMetricNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ReceiveLinkOpensThrottled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RegistrationIdDefinedMultipleTimes { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RegistrationStatusConflict { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ReliableBlobStoreError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ReliableBlobStoreTimeoutError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ReliableDocDbStoreStoreError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RequestCanceled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RequestTimedOut { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ResolutionError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RestoreTimedOut { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RetryAttemptsExhausted { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RoutingEndpointResponseForbidden { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RoutingEndpointResponseNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode RoutingNotEnabled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode SerializationError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ServerBusy { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ServerError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode StatisticsRetrievalError { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode StreamReservationFailure { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode SystemModuleModifyUnauthorizedAccess { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode SystemPropertyNotFound { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode TenantHubRoutingNotEnabled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ThrottleBacklogLimitExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ThrottlingBacklogTimeout { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ThrottlingException { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode ThrottlingMaxActiveJobCountExceeded { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode TooManyDevices { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode TooManyEnrollments { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode TooManyModulesOnDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnableToCompressComponentInfo { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnableToCompressDiscoveryInfo { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnableToExpandComponentInfo { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnableToExpandDiscoveryInfo { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnableToFetchCredentials { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnableToFetchTenantInfo { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnableToShareIdentity { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnexpectedPropertyValue { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode UnsupportedOperationOnReplica { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode left, Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode left, Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceRegistryOperationWarning
    {
        internal DeviceRegistryOperationWarning() { }
        public string DeviceId { get { throw null; } }
        public Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode? WarningCode { get { throw null; } }
        public string WarningStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceRegistryOperationWarningCode : System.IEquatable<Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceRegistryOperationWarningCode(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode DeviceRegisteredWithoutTwin { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode left, Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode left, Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevicesStatistics
    {
        internal DevicesStatistics() { }
        public long? DisabledDeviceCount { get { throw null; } }
        public long? EnabledDeviceCount { get { throw null; } }
        public long? TotalDeviceCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceStatus : System.IEquatable<Azure.IoT.Hub.Service.Models.DeviceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceStatus(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DeviceStatus Disabled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.DeviceStatus Enabled { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.DeviceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.DeviceStatus left, Azure.IoT.Hub.Service.Models.DeviceStatus right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.DeviceStatus (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.DeviceStatus left, Azure.IoT.Hub.Service.Models.DeviceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportImportDevice
    {
        public ExportImportDevice() { }
        public Azure.IoT.Hub.Service.Models.AuthenticationMechanism Authentication { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.DeviceCapabilities Capabilities { get { throw null; } set { } }
        public string DeviceScope { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode? ImportMode { get { throw null; } set { } }
        public string ModuleId { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.PropertyContainer Properties { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus? Status { get { throw null; } set { } }
        public string StatusReason { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Tags { get { throw null; } }
        public string TwinETag { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportImportDeviceImportMode : System.IEquatable<Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportImportDeviceImportMode(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode Create { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode Delete { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode DeleteIfMatchETag { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode Update { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode UpdateIfMatchETag { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode UpdateTwin { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode UpdateTwinIfMatchETag { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode left, Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode left, Azure.IoT.Hub.Service.Models.ExportImportDeviceImportMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportImportDeviceStatus : System.IEquatable<Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportImportDeviceStatus(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus Disabled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus Enabled { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus left, Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus left, Azure.IoT.Hub.Service.Models.ExportImportDeviceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportJobRequestOptions : Azure.IoT.Hub.Service.Models.JobRequestOptions
    {
        public ExportJobRequestOptions() { }
        public string OutputBlobName { get { throw null; } set { } }
    }
    public partial class ImportJobRequestOptions : Azure.IoT.Hub.Service.Models.JobRequestOptions
    {
        public ImportJobRequestOptions() { }
        public string InputBlobName { get { throw null; } set { } }
        public string OutputBlobName { get { throw null; } set { } }
    }
    public static partial class IoTHubServiceModelFactory
    {
        public static Azure.IoT.Hub.Service.Models.BulkRegistryOperationResponse BulkRegistryOperationResponse(bool? isSuccessful = default(bool?), System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceRegistryOperationError> errors = null, System.Collections.Generic.IEnumerable<Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarning> warnings = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.CloudToDeviceMethodResponse CloudToDeviceMethodResponse(int? status = default(int?), object payload = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.ConfigurationQueriesTestResponse ConfigurationQueriesTestResponse(string targetConditionError = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customMetricQueryErrors = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DeviceJobStatistics DeviceJobStatistics(int? deviceCount = default(int?), int? failedCount = default(int?), int? succeededCount = default(int?), int? runningCount = default(int?), int? pendingCount = default(int?)) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationError DeviceRegistryOperationError(string deviceId = null, Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode? errorCode = default(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationErrorCode?), string errorStatus = null, string moduleId = null, string operation = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarning DeviceRegistryOperationWarning(string deviceId = null, Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode? warningCode = default(Azure.IoT.Hub.Service.Models.DeviceRegistryOperationWarningCode?), string warningStatus = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.DevicesStatistics DevicesStatistics(long? totalDeviceCount = default(long?), long? enabledDeviceCount = default(long?), long? disabledDeviceCount = default(long?)) { throw null; }
        public static Azure.IoT.Hub.Service.Models.JobResponse JobResponse(string jobId = null, string queryCondition = null, System.DateTimeOffset? createdTime = default(System.DateTimeOffset?), System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), long? maxExecutionTimeInSeconds = default(long?), Azure.IoT.Hub.Service.Models.JobResponseType? type = default(Azure.IoT.Hub.Service.Models.JobResponseType?), Azure.IoT.Hub.Service.Models.CloudToDeviceMethodRequest cloudToDeviceMethod = null, Azure.IoT.Hub.Service.Models.TwinData updateTwin = null, Azure.IoT.Hub.Service.Models.JobResponseStatus? status = default(Azure.IoT.Hub.Service.Models.JobResponseStatus?), string failureReason = null, string statusMessage = null, Azure.IoT.Hub.Service.Models.DeviceJobStatistics deviceJobStatistics = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.PurgeMessageQueueResult PurgeMessageQueueResult(int? totalMessagesPurged = default(int?), string deviceId = null, string moduleId = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.QueryResult QueryResult(Azure.IoT.Hub.Service.Models.QueryResultType? type = default(Azure.IoT.Hub.Service.Models.QueryResultType?), System.Collections.Generic.IEnumerable<object> items = null, string continuationToken = null) { throw null; }
        public static Azure.IoT.Hub.Service.Models.ServiceStatistics ServiceStatistics(long? connectedDeviceCount = default(long?)) { throw null; }
    }
    public partial class JobProperties
    {
        public JobProperties() { }
        public string ConfigurationsBlobName { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public bool? ExcludeKeysInExport { get { throw null; } set { } }
        public string FailureReason { get { throw null; } set { } }
        public bool? IncludeConfigurations { get { throw null; } set { } }
        public string InputBlobContainerUri { get { throw null; } set { } }
        public string InputBlobName { get { throw null; } set { } }
        public string JobId { get { throw null; } set { } }
        public string OutputBlobContainerUri { get { throw null; } set { } }
        public string OutputBlobName { get { throw null; } set { } }
        public int? Progress { get { throw null; } set { } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.JobPropertiesStatus? Status { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType? StorageAuthenticationType { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.JobPropertiesType? Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobPropertiesStatus : System.IEquatable<Azure.IoT.Hub.Service.Models.JobPropertiesStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobPropertiesStatus(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Cancelled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Completed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Enqueued { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Failed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Queued { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Running { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Scheduled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStatus Unknown { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.JobPropertiesStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.JobPropertiesStatus left, Azure.IoT.Hub.Service.Models.JobPropertiesStatus right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.JobPropertiesStatus (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.JobPropertiesStatus left, Azure.IoT.Hub.Service.Models.JobPropertiesStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobPropertiesStorageAuthenticationType : System.IEquatable<Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobPropertiesStorageAuthenticationType(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType IdentityBased { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType left, Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType left, Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobPropertiesType : System.IEquatable<Azure.IoT.Hub.Service.Models.JobPropertiesType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobPropertiesType(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType Backup { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType Export { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType FactoryResetDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType FailoverDataCopy { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType FirmwareUpdate { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType Import { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType ReadDeviceProperties { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType RebootDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType RestoreFromBackup { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType ScheduleDeviceMethod { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType ScheduleUpdateTwin { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType Unknown { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType UpdateDeviceConfiguration { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobPropertiesType WriteDeviceProperties { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.JobPropertiesType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.JobPropertiesType left, Azure.IoT.Hub.Service.Models.JobPropertiesType right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.JobPropertiesType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.JobPropertiesType left, Azure.IoT.Hub.Service.Models.JobPropertiesType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobRequest
    {
        public JobRequest() { }
        public Azure.IoT.Hub.Service.Models.CloudToDeviceMethodRequest CloudToDeviceMethod { get { throw null; } set { } }
        public string JobId { get { throw null; } set { } }
        public long? MaxExecutionTimeInSeconds { get { throw null; } set { } }
        public string QueryCondition { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.JobRequestType? Type { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.TwinData UpdateTwin { get { throw null; } set { } }
    }
    public partial class JobRequestOptions
    {
        public JobRequestOptions() { }
        public Azure.IoT.Hub.Service.Models.JobPropertiesStorageAuthenticationType AuthenticationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobRequestType : System.IEquatable<Azure.IoT.Hub.Service.Models.JobRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRequestType(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.JobRequestType Backup { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType Export { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType FactoryResetDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType FailoverDataCopy { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType FirmwareUpdate { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType Import { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType ReadDeviceProperties { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType RebootDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType RestoreFromBackup { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType ScheduleDeviceMethod { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType ScheduleUpdateTwin { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType Unknown { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType UpdateDeviceConfiguration { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobRequestType WriteDeviceProperties { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.JobRequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.JobRequestType left, Azure.IoT.Hub.Service.Models.JobRequestType right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.JobRequestType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.JobRequestType left, Azure.IoT.Hub.Service.Models.JobRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobResponse
    {
        internal JobResponse() { }
        public Azure.IoT.Hub.Service.Models.CloudToDeviceMethodRequest CloudToDeviceMethod { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public Azure.IoT.Hub.Service.Models.DeviceJobStatistics DeviceJobStatistics { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string JobId { get { throw null; } }
        public long? MaxExecutionTimeInSeconds { get { throw null; } }
        public string QueryCondition { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.IoT.Hub.Service.Models.JobResponseStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public Azure.IoT.Hub.Service.Models.JobResponseType? Type { get { throw null; } }
        public Azure.IoT.Hub.Service.Models.TwinData UpdateTwin { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobResponseStatus : System.IEquatable<Azure.IoT.Hub.Service.Models.JobResponseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobResponseStatus(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Cancelled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Completed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Enqueued { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Failed { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Queued { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Running { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Scheduled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseStatus Unknown { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.JobResponseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.JobResponseStatus left, Azure.IoT.Hub.Service.Models.JobResponseStatus right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.JobResponseStatus (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.JobResponseStatus left, Azure.IoT.Hub.Service.Models.JobResponseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobResponseType : System.IEquatable<Azure.IoT.Hub.Service.Models.JobResponseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobResponseType(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.JobResponseType Backup { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType Export { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType FactoryResetDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType FailoverDataCopy { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType FirmwareUpdate { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType Import { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType ReadDeviceProperties { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType RebootDevice { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType RestoreFromBackup { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType ScheduleDeviceMethod { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType ScheduleUpdateTwin { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType Unknown { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType UpdateDeviceConfiguration { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.JobResponseType WriteDeviceProperties { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.JobResponseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.JobResponseType left, Azure.IoT.Hub.Service.Models.JobResponseType right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.JobResponseType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.JobResponseType left, Azure.IoT.Hub.Service.Models.JobResponseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModuleConnectionState : System.IEquatable<Azure.IoT.Hub.Service.Models.ModuleConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModuleConnectionState(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.ModuleConnectionState Connected { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.ModuleConnectionState Disconnected { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.ModuleConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.ModuleConnectionState left, Azure.IoT.Hub.Service.Models.ModuleConnectionState right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.ModuleConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.ModuleConnectionState left, Azure.IoT.Hub.Service.Models.ModuleConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModuleIdentity
    {
        public ModuleIdentity() { }
        public Azure.IoT.Hub.Service.Models.AuthenticationMechanism Authentication { get { throw null; } set { } }
        public int? CloudToDeviceMessageCount { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.ModuleConnectionState? ConnectionState { get { throw null; } set { } }
        public System.DateTimeOffset? ConnectionStateUpdatedTime { get { throw null; } set { } }
        public string DeviceId { get { throw null; } set { } }
        public string Etag { get { throw null; } set { } }
        public string GenerationId { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivityTime { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public string ModuleId { get { throw null; } set { } }
    }
    public partial class PropertyContainer
    {
        public PropertyContainer() { }
        public System.Collections.Generic.IDictionary<string, object> Desired { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Reported { get { throw null; } }
    }
    public partial class PurgeMessageQueueResult
    {
        internal PurgeMessageQueueResult() { }
        public string DeviceId { get { throw null; } }
        public string ModuleId { get { throw null; } }
        public int? TotalMessagesPurged { get { throw null; } }
    }
    public partial class QueryResult
    {
        internal QueryResult() { }
        public string ContinuationToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> Items { get { throw null; } }
        public Azure.IoT.Hub.Service.Models.QueryResultType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryResultType : System.IEquatable<Azure.IoT.Hub.Service.Models.QueryResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryResultType(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.QueryResultType DeviceJob { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.QueryResultType DeviceRegistration { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.QueryResultType Enrollment { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.QueryResultType EnrollmentGroup { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.QueryResultType JobResponse { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.QueryResultType Raw { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.QueryResultType Twin { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.QueryResultType Unknown { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.QueryResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.QueryResultType left, Azure.IoT.Hub.Service.Models.QueryResultType right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.QueryResultType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.QueryResultType left, Azure.IoT.Hub.Service.Models.QueryResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuerySpecification
    {
        public QuerySpecification() { }
        public string Query { get { throw null; } set { } }
    }
    public partial class ServiceStatistics
    {
        internal ServiceStatistics() { }
        public long? ConnectedDeviceCount { get { throw null; } }
    }
    public partial class SymmetricKey
    {
        public SymmetricKey() { }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TwinAuthenticationType : System.IEquatable<Azure.IoT.Hub.Service.Models.TwinAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TwinAuthenticationType(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.TwinAuthenticationType CertificateAuthority { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.TwinAuthenticationType None { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.TwinAuthenticationType Sas { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.TwinAuthenticationType SelfSigned { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.TwinAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.TwinAuthenticationType left, Azure.IoT.Hub.Service.Models.TwinAuthenticationType right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.TwinAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.TwinAuthenticationType left, Azure.IoT.Hub.Service.Models.TwinAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TwinConfiguration
    {
        public TwinConfiguration() { }
        public Azure.IoT.Hub.Service.Models.ConfigurationContent Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } set { } }
        public string Etag { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.ConfigurationMetrics Metrics { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.ConfigurationMetrics SystemMetrics { get { throw null; } set { } }
        public string TargetCondition { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TwinConnectionState : System.IEquatable<Azure.IoT.Hub.Service.Models.TwinConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TwinConnectionState(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.TwinConnectionState Connected { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.TwinConnectionState Disconnected { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.TwinConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.TwinConnectionState left, Azure.IoT.Hub.Service.Models.TwinConnectionState right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.TwinConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.TwinConnectionState left, Azure.IoT.Hub.Service.Models.TwinConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TwinData
    {
        public TwinData() { }
        public Azure.IoT.Hub.Service.Models.TwinAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.DeviceCapabilities Capabilities { get { throw null; } set { } }
        public int? CloudToDeviceMessageCount { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.TwinConnectionState? ConnectionState { get { throw null; } set { } }
        public string DeviceEtag { get { throw null; } set { } }
        public string DeviceId { get { throw null; } set { } }
        public string DeviceScope { get { throw null; } set { } }
        public string Etag { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivityTime { get { throw null; } set { } }
        public string ModuleId { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.TwinProperties Properties { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.TwinStatus? Status { get { throw null; } set { } }
        public string StatusReason { get { throw null; } set { } }
        public System.DateTimeOffset? StatusUpdateTime { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Tags { get { throw null; } }
        public long? Version { get { throw null; } set { } }
        public Azure.IoT.Hub.Service.Models.X509Thumbprint X509Thumbprint { get { throw null; } set { } }
    }
    public partial class TwinProperties
    {
        public TwinProperties() { }
        public System.Collections.Generic.IDictionary<string, object> Desired { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Reported { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TwinStatus : System.IEquatable<Azure.IoT.Hub.Service.Models.TwinStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TwinStatus(string value) { throw null; }
        public static Azure.IoT.Hub.Service.Models.TwinStatus Disabled { get { throw null; } }
        public static Azure.IoT.Hub.Service.Models.TwinStatus Enabled { get { throw null; } }
        public bool Equals(Azure.IoT.Hub.Service.Models.TwinStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.IoT.Hub.Service.Models.TwinStatus left, Azure.IoT.Hub.Service.Models.TwinStatus right) { throw null; }
        public static implicit operator Azure.IoT.Hub.Service.Models.TwinStatus (string value) { throw null; }
        public static bool operator !=(Azure.IoT.Hub.Service.Models.TwinStatus left, Azure.IoT.Hub.Service.Models.TwinStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X509Thumbprint
    {
        public X509Thumbprint() { }
        public string PrimaryThumbprint { get { throw null; } set { } }
        public string SecondaryThumbprint { get { throw null; } set { } }
    }
}
