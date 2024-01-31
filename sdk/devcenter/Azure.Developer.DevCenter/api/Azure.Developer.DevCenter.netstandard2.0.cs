namespace Azure.Developer.DevCenter
{
    public partial class DeploymentEnvironmentsClient
    {
        protected DeploymentEnvironmentsClient() { }
        public DeploymentEnvironmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DeploymentEnvironmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateEnvironment(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Developer.DevCenter.Models.DevCenterEnvironment> CreateOrUpdateEnvironment(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.Developer.DevCenter.Models.DevCenterEnvironment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Developer.DevCenter.Models.DevCenterEnvironment>> CreateOrUpdateEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.Developer.DevCenter.Models.DevCenterEnvironment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteEnvironment(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllEnvironments(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetAllEnvironments(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllEnvironmentsAsync(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetAllEnvironmentsAsync(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCatalog(string projectName, string catalogName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevCenterCatalog> GetCatalog(string projectName, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCatalogAsync(string projectName, string catalogName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevCenterCatalog>> GetCatalogAsync(string projectName, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCatalogs(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterCatalog> GetCatalogs(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCatalogsAsync(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterCatalog> GetCatalogsAsync(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnvironment(string projectName, string userId, string environmentName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetEnvironment(string projectName, string userId, string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentAsync(string projectName, string userId, string environmentName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevCenterEnvironment>> GetEnvironmentAsync(string projectName, string userId, string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnvironmentDefinition(string projectName, string catalogName, string definitionName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinition(string projectName, string catalogName, string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentDefinitionAsync(string projectName, string catalogName, string definitionName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.EnvironmentDefinition>> GetEnvironmentDefinitionAsync(string projectName, string catalogName, string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentDefinitions(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitions(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentDefinitionsAsync(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitionsAsync(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentDefinitionsByCatalog(string projectName, string catalogName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitionsByCatalog(string projectName, string catalogName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentDefinitionsByCatalogAsync(string projectName, string catalogName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitionsByCatalogAsync(string projectName, string catalogName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironments(string projectName, string userId, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetEnvironments(string projectName, string userId, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentsAsync(string projectName, string userId, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetEnvironmentsAsync(string projectName, string userId, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentTypes(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType> GetEnvironmentTypes(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentTypesAsync(string projectName, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType> GetEnvironmentTypesAsync(string projectName, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevBoxesClient
    {
        protected DevBoxesClient() { }
        public DevBoxesClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DevBoxesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<Azure.Developer.DevCenter.Models.DevBox> CreateDevBox(Azure.WaitUntil waitUntil, string projectName, string userId, Azure.Developer.DevCenter.Models.DevBox devBox, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateDevBox(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Developer.DevCenter.Models.DevBox>> CreateDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string userId, Azure.Developer.DevCenter.Models.DevBox devBox, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DelayAction(string projectName, string userId, string devBoxName, string actionName, System.DateTimeOffset delayUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevBoxAction> DelayAction(string projectName, string userId, string devBoxName, string actionName, System.DateTimeOffset delayUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DelayActionAsync(string projectName, string userId, string devBoxName, string actionName, System.DateTimeOffset delayUntil, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevBoxAction>> DelayActionAsync(string projectName, string userId, string devBoxName, string actionName, System.DateTimeOffset delayUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> DelayAllActions(string projectName, string userId, string devBoxName, System.DateTimeOffset delayUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult> DelayAllActions(string projectName, string userId, string devBoxName, System.DateTimeOffset delayUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> DelayAllActionsAsync(string projectName, string userId, string devBoxName, System.DateTimeOffset delayUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult> DelayAllActionsAsync(string projectName, string userId, string devBoxName, System.DateTimeOffset delayUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDevBox(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxes(string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxes(string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesAsync(string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxesAsync(string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxesByUser(string userId, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxesByUser(string userId, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesByUserAsync(string userId, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxesByUserAsync(string userId, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDevBox(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevBox> GetDevBox(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDevBoxAction(string projectName, string userId, string devBoxName, string actionName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevBoxAction> GetDevBoxAction(string projectName, string userId, string devBoxName, string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDevBoxActionAsync(string projectName, string userId, string devBoxName, string actionName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevBoxAction>> GetDevBoxActionAsync(string projectName, string userId, string devBoxName, string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevBoxActions(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBoxAction> GetDevBoxActions(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevBoxActionsAsync(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBoxAction> GetDevBoxActionsAsync(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDevBoxAsync(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevBox>> GetDevBoxAsync(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevBoxes(string projectName, string userId, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBox> GetDevBoxes(string projectName, string userId, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevBoxesAsync(string projectName, string userId, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBox> GetDevBoxesAsync(string projectName, string userId, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPool(string projectName, string poolName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevBoxPool> GetPool(string projectName, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPoolAsync(string projectName, string poolName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevBoxPool>> GetPoolAsync(string projectName, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPools(string projectName, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBoxPool> GetPools(string projectName, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolsAsync(string projectName, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBoxPool> GetPoolsAsync(string projectName, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRemoteConnection(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.RemoteConnection> GetRemoteConnection(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRemoteConnectionAsync(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.RemoteConnection>> GetRemoteConnectionAsync(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSchedule(string projectName, string poolName, string scheduleName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevBoxSchedule> GetSchedule(string projectName, string poolName, string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleAsync(string projectName, string poolName, string scheduleName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevBoxSchedule>> GetScheduleAsync(string projectName, string poolName, string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedules(string projectName, string poolName, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBoxSchedule> GetSchedules(string projectName, string poolName, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesAsync(string projectName, string poolName, string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBoxSchedule> GetSchedulesAsync(string projectName, string poolName, string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation RestartDevBox(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> RestartDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SkipAction(string projectName, string userId, string devBoxName, string actionName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SkipActionAsync(string projectName, string userId, string devBoxName, string actionName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation StartDevBox(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> StartDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation StopDevBox(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, bool? hibernate = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> StopDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string devBoxName, bool? hibernate = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevCenterClient
    {
        protected DevCenterClient() { }
        public DevCenterClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DevCenterClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Developer.DevCenter.DeploymentEnvironmentsClient GetDeploymentEnvironmentsClient() { throw null; }
        public virtual Azure.Developer.DevCenter.DevBoxesClient GetDevBoxesClient() { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevCenterProject> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevCenterProject>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterProject> GetProjects(string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(string filter, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterProject> GetProjectsAsync(string filter = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterClientOptions : Azure.Core.ClientOptions
    {
        public DevCenterClientOptions(Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion version = Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion.V2023_04_01) { }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
        }
    }
}
namespace Azure.Developer.DevCenter.Models
{
    public partial class DevBox
    {
        public DevBox(string name, string poolName) { }
        public string ActionState { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxHardwareProfile HardwareProfile { get { throw null; } }
        public Azure.Developer.DevCenter.Models.HibernateSupport? HibernateSupport { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxImageReference ImageReference { get { throw null; } }
        public Azure.Developer.DevCenter.Models.LocalAdministratorStatus? LocalAdministratorStatus { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Developer.DevCenter.Models.DevBoxOSType? OSType { get { throw null; } }
        public string PoolName { get { throw null; } set { } }
        public Azure.Developer.DevCenter.Models.PowerState PowerState { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxStorageProfile StorageProfile { get { throw null; } }
        public System.Guid? UniqueId { get { throw null; } }
        public System.Guid? UserId { get { throw null; } }
    }
    public partial class DevBoxAction
    {
        internal DevBoxAction() { }
        public Azure.Developer.DevCenter.Models.DevBoxActionType ActionType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxNextAction NextAction { get { throw null; } }
        public string SourceId { get { throw null; } }
        public System.DateTimeOffset? SuspendedUntil { get { throw null; } }
    }
    public partial class DevBoxActionDelayResult
    {
        internal DevBoxActionDelayResult() { }
        public Azure.Developer.DevCenter.Models.DevBoxAction Action { get { throw null; } }
        public string ActionName { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevBoxActionDelayStatus : System.IEquatable<Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevBoxActionDelayStatus(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus Failed { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus left, Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus left, Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevBoxActionType : System.IEquatable<Azure.Developer.DevCenter.Models.DevBoxActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevBoxActionType(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxActionType Stop { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.DevBoxActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.DevBoxActionType left, Azure.Developer.DevCenter.Models.DevBoxActionType right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.DevBoxActionType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.DevBoxActionType left, Azure.Developer.DevCenter.Models.DevBoxActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevBoxHardwareProfile
    {
        internal DevBoxHardwareProfile() { }
        public int? MemoryGB { get { throw null; } }
        public Azure.Developer.DevCenter.Models.SkuName? SkuName { get { throw null; } }
        public int? VCPUs { get { throw null; } }
    }
    public partial class DevBoxImageReference
    {
        internal DevBoxImageReference() { }
        public string Name { get { throw null; } }
        public string OperatingSystem { get { throw null; } }
        public string OSBuildNumber { get { throw null; } }
        public System.DateTimeOffset? PublishedDate { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class DevBoxNextAction
    {
        internal DevBoxNextAction() { }
        public System.DateTimeOffset ScheduledTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevBoxOSType : System.IEquatable<Azure.Developer.DevCenter.Models.DevBoxOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevBoxOSType(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxOSType Windows { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.DevBoxOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.DevBoxOSType left, Azure.Developer.DevCenter.Models.DevBoxOSType right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.DevBoxOSType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.DevBoxOSType left, Azure.Developer.DevCenter.Models.DevBoxOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevBoxPool
    {
        internal DevBoxPool() { }
        public Azure.Developer.DevCenter.Models.DevBoxHardwareProfile HardwareProfile { get { throw null; } }
        public Azure.Developer.DevCenter.Models.PoolHealthStatus HealthStatus { get { throw null; } }
        public Azure.Developer.DevCenter.Models.HibernateSupport? HibernateSupport { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxImageReference ImageReference { get { throw null; } }
        public Azure.Developer.DevCenter.Models.LocalAdministratorStatus? LocalAdministratorStatus { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxOSType? OSType { get { throw null; } }
        public Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnect { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxStorageProfile StorageProfile { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevBoxProvisioningState : System.IEquatable<Azure.Developer.DevCenter.Models.DevBoxProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevBoxProvisioningState(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Canceled { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Creating { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Deleting { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Failed { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState InGracePeriod { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState NotProvisioned { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState ProvisionedWithWarning { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Provisioning { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Starting { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Stopping { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Succeeded { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.DevBoxProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.DevBoxProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.DevBoxProvisioningState left, Azure.Developer.DevCenter.Models.DevBoxProvisioningState right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.DevBoxProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.DevBoxProvisioningState left, Azure.Developer.DevCenter.Models.DevBoxProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevBoxSchedule
    {
        internal DevBoxSchedule() { }
        public Azure.Developer.DevCenter.Models.ScheduleFrequency Frequency { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.ScheduledType ScheduledType { get { throw null; } }
        public System.TimeSpan Time { get { throw null; } }
        public string TimeZone { get { throw null; } }
    }
    public partial class DevBoxStorageProfile
    {
        internal DevBoxStorageProfile() { }
        public Azure.Developer.DevCenter.Models.OSDisk OSDisk { get { throw null; } }
    }
    public partial class DevCenterCatalog
    {
        internal DevCenterCatalog() { }
        public string Name { get { throw null; } }
    }
    public partial class DevCenterEnvironment
    {
        public DevCenterEnvironment(string environmentTypeName, string catalogName, string environmentDefinitionName) { }
        public string CatalogName { get { throw null; } set { } }
        public string EnvironmentDefinitionName { get { throw null; } set { } }
        public string EnvironmentTypeName { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.Developer.DevCenter.Models.EnvironmentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } }
        public System.Guid? UserId { get { throw null; } }
    }
    public partial class DevCenterEnvironmentType
    {
        internal DevCenterEnvironmentType() { }
        public Azure.Core.ResourceIdentifier DeploymentTargetId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.EnvironmentTypeStatus Status { get { throw null; } }
    }
    public static partial class DevCenterModelFactory
    {
        public static Azure.Developer.DevCenter.Models.DevBox DevBox(string name = null, string projectName = null, string poolName = null, Azure.Developer.DevCenter.Models.HibernateSupport? hibernateSupport = default(Azure.Developer.DevCenter.Models.HibernateSupport?), Azure.Developer.DevCenter.Models.DevBoxProvisioningState? provisioningState = default(Azure.Developer.DevCenter.Models.DevBoxProvisioningState?), string actionState = null, Azure.Developer.DevCenter.Models.PowerState powerState = default(Azure.Developer.DevCenter.Models.PowerState), System.Guid? uniqueId = default(System.Guid?), Azure.ResponseError error = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Developer.DevCenter.Models.DevBoxOSType? osType = default(Azure.Developer.DevCenter.Models.DevBoxOSType?), System.Guid? userId = default(System.Guid?), Azure.Developer.DevCenter.Models.DevBoxHardwareProfile hardwareProfile = null, Azure.Developer.DevCenter.Models.DevBoxStorageProfile storageProfile = null, Azure.Developer.DevCenter.Models.DevBoxImageReference imageReference = null, System.DateTimeOffset? createdTime = default(System.DateTimeOffset?), Azure.Developer.DevCenter.Models.LocalAdministratorStatus? localAdministratorStatus = default(Azure.Developer.DevCenter.Models.LocalAdministratorStatus?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxAction DevBoxAction(string name = null, Azure.Developer.DevCenter.Models.DevBoxActionType actionType = default(Azure.Developer.DevCenter.Models.DevBoxActionType), string sourceId = null, System.DateTimeOffset? suspendedUntil = default(System.DateTimeOffset?), Azure.Developer.DevCenter.Models.DevBoxNextAction nextAction = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxActionDelayResult DevBoxActionDelayResult(string actionName = null, Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus result = default(Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus), Azure.Developer.DevCenter.Models.DevBoxAction action = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxHardwareProfile DevBoxHardwareProfile(Azure.Developer.DevCenter.Models.SkuName? skuName = default(Azure.Developer.DevCenter.Models.SkuName?), int? vcpUs = default(int?), int? memoryGB = default(int?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxImageReference DevBoxImageReference(string name = null, string version = null, string operatingSystem = null, string osBuildNumber = null, System.DateTimeOffset? publishedDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxNextAction DevBoxNextAction(System.DateTimeOffset scheduledTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxPool DevBoxPool(string name = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Developer.DevCenter.Models.DevBoxOSType? osType = default(Azure.Developer.DevCenter.Models.DevBoxOSType?), Azure.Developer.DevCenter.Models.DevBoxHardwareProfile hardwareProfile = null, Azure.Developer.DevCenter.Models.HibernateSupport? hibernateSupport = default(Azure.Developer.DevCenter.Models.HibernateSupport?), Azure.Developer.DevCenter.Models.DevBoxStorageProfile storageProfile = null, Azure.Developer.DevCenter.Models.DevBoxImageReference imageReference = null, Azure.Developer.DevCenter.Models.LocalAdministratorStatus? localAdministratorStatus = default(Azure.Developer.DevCenter.Models.LocalAdministratorStatus?), Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect = null, Azure.Developer.DevCenter.Models.PoolHealthStatus healthStatus = default(Azure.Developer.DevCenter.Models.PoolHealthStatus)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxSchedule DevBoxSchedule(string name = null, Azure.Developer.DevCenter.Models.ScheduledType scheduledType = default(Azure.Developer.DevCenter.Models.ScheduledType), Azure.Developer.DevCenter.Models.ScheduleFrequency frequency = default(Azure.Developer.DevCenter.Models.ScheduleFrequency), System.TimeSpan time = default(System.TimeSpan), string timeZone = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxStorageProfile DevBoxStorageProfile(Azure.Developer.DevCenter.Models.OSDisk osDisk = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterCatalog DevCenterCatalog(string name = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterEnvironment DevCenterEnvironment(System.BinaryData parameters = null, string name = null, string environmentTypeName = null, System.Guid? userId = default(System.Guid?), Azure.Developer.DevCenter.Models.EnvironmentProvisioningState? provisioningState = default(Azure.Developer.DevCenter.Models.EnvironmentProvisioningState?), Azure.Core.ResourceIdentifier resourceGroupId = null, string catalogName = null, string environmentDefinitionName = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterEnvironmentType DevCenterEnvironmentType(string name = null, Azure.Core.ResourceIdentifier deploymentTargetId = null, Azure.Developer.DevCenter.Models.EnvironmentTypeStatus status = default(Azure.Developer.DevCenter.Models.EnvironmentTypeStatus)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterProject DevCenterProject(string name = null, string description = null, int? maxDevBoxesPerUser = default(int?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinition EnvironmentDefinition(string id = null, string name = null, string catalogName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter> parameters = null, System.BinaryData parametersSchema = null, string templatePath = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter EnvironmentDefinitionParameter(string id = null, string name = null, string description = null, System.BinaryData defaultValue = null, Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType parameterType = default(Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType), bool? readOnly = default(bool?), bool required = false, System.Collections.Generic.IEnumerable<string> allowed = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.OSDisk OSDisk(int? diskSizeGB = default(int?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.RemoteConnection RemoteConnection(System.Uri webUri = null, System.Uri rdpConnectionUri = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnectConfiguration(Azure.Developer.DevCenter.Models.StopOnDisconnectStatus status = default(Azure.Developer.DevCenter.Models.StopOnDisconnectStatus), int? gracePeriodMinutes = default(int?)) { throw null; }
    }
    public partial class DevCenterProject
    {
        internal DevCenterProject() { }
        public string Description { get { throw null; } }
        public int? MaxDevBoxesPerUser { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class EnvironmentDefinition
    {
        internal EnvironmentDefinition() { }
        public string CatalogName { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter> Parameters { get { throw null; } }
        public System.BinaryData ParametersSchema { get { throw null; } }
        public string TemplatePath { get { throw null; } }
    }
    public partial class EnvironmentDefinitionParameter
    {
        internal EnvironmentDefinitionParameter() { }
        public System.Collections.Generic.IReadOnlyList<string> Allowed { get { throw null; } }
        public System.BinaryData DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType ParameterType { get { throw null; } }
        public bool? ReadOnly { get { throw null; } }
        public bool Required { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentDefinitionParameterType : System.IEquatable<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentDefinitionParameterType(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType Array { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType Boolean { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType Integer { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType Number { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType Object { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType String { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType left, Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType left, Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentProvisioningState : System.IEquatable<Azure.Developer.DevCenter.Models.EnvironmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentProvisioningState(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Accepted { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Canceled { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Creating { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Deleting { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Failed { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState MovingResources { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Preparing { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Running { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState StorageProvisioningFailed { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Syncing { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState TransientFailure { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.EnvironmentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.EnvironmentProvisioningState left, Azure.Developer.DevCenter.Models.EnvironmentProvisioningState right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.EnvironmentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.EnvironmentProvisioningState left, Azure.Developer.DevCenter.Models.EnvironmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentTypeStatus : System.IEquatable<Azure.Developer.DevCenter.Models.EnvironmentTypeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentTypeStatus(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.EnvironmentTypeStatus Disabled { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.EnvironmentTypeStatus Enabled { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.EnvironmentTypeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.EnvironmentTypeStatus left, Azure.Developer.DevCenter.Models.EnvironmentTypeStatus right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.EnvironmentTypeStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.EnvironmentTypeStatus left, Azure.Developer.DevCenter.Models.EnvironmentTypeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HibernateSupport : System.IEquatable<Azure.Developer.DevCenter.Models.HibernateSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HibernateSupport(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.HibernateSupport Disabled { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.HibernateSupport Enabled { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.HibernateSupport OsUnsupported { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.HibernateSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.HibernateSupport left, Azure.Developer.DevCenter.Models.HibernateSupport right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.HibernateSupport (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.HibernateSupport left, Azure.Developer.DevCenter.Models.HibernateSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalAdministratorStatus : System.IEquatable<Azure.Developer.DevCenter.Models.LocalAdministratorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalAdministratorStatus(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.LocalAdministratorStatus Disabled { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.LocalAdministratorStatus Enabled { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.LocalAdministratorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.LocalAdministratorStatus left, Azure.Developer.DevCenter.Models.LocalAdministratorStatus right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.LocalAdministratorStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.LocalAdministratorStatus left, Azure.Developer.DevCenter.Models.LocalAdministratorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSDisk
    {
        internal OSDisk() { }
        public int? DiskSizeGB { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolHealthStatus : System.IEquatable<Azure.Developer.DevCenter.Models.PoolHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolHealthStatus(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.PoolHealthStatus Healthy { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PoolHealthStatus Pending { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PoolHealthStatus Unhealthy { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PoolHealthStatus Unknown { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PoolHealthStatus Warning { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.PoolHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.PoolHealthStatus left, Azure.Developer.DevCenter.Models.PoolHealthStatus right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.PoolHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.PoolHealthStatus left, Azure.Developer.DevCenter.Models.PoolHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerState : System.IEquatable<Azure.Developer.DevCenter.Models.PowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerState(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.PowerState Deallocated { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PowerState Hibernated { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PowerState PoweredOff { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PowerState Running { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.PowerState Unknown { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.PowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.PowerState left, Azure.Developer.DevCenter.Models.PowerState right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.PowerState (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.PowerState left, Azure.Developer.DevCenter.Models.PowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoteConnection
    {
        internal RemoteConnection() { }
        public System.Uri RdpConnectionUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledType : System.IEquatable<Azure.Developer.DevCenter.Models.ScheduledType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledType(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.ScheduledType StopDevBox { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.ScheduledType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.ScheduledType left, Azure.Developer.DevCenter.Models.ScheduledType right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.ScheduledType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.ScheduledType left, Azure.Developer.DevCenter.Models.ScheduledType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleFrequency : System.IEquatable<Azure.Developer.DevCenter.Models.ScheduleFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleFrequency(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.ScheduleFrequency Daily { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.ScheduleFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.ScheduleFrequency left, Azure.Developer.DevCenter.Models.ScheduleFrequency right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.ScheduleFrequency (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.ScheduleFrequency left, Azure.Developer.DevCenter.Models.ScheduleFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuName : System.IEquatable<Azure.Developer.DevCenter.Models.SkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuName(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA16c64gb1024ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA16c64gb2048ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA16c64gb256ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA16c64gb512ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA32c128gb1024ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA32c128gb2048ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA32c128gb512ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA8c32gb1024ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA8c32gb2048ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA8c32gb256ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralA8c32gb512ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI16c64gb1024ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI16c64gb2048ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI16c64gb256ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI16c64gb512ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI32c128gb1024ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI32c128gb2048ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI32c128gb512ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI8c32gb1024ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI8c32gb2048ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI8c32gb256ssdV2 { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.SkuName GeneralI8c32gb512ssdV2 { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.SkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.SkuName left, Azure.Developer.DevCenter.Models.SkuName right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.SkuName (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.SkuName left, Azure.Developer.DevCenter.Models.SkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StopOnDisconnectConfiguration
    {
        internal StopOnDisconnectConfiguration() { }
        public int? GracePeriodMinutes { get { throw null; } }
        public Azure.Developer.DevCenter.Models.StopOnDisconnectStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StopOnDisconnectStatus : System.IEquatable<Azure.Developer.DevCenter.Models.StopOnDisconnectStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StopOnDisconnectStatus(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.StopOnDisconnectStatus Disabled { get { throw null; } }
        public static Azure.Developer.DevCenter.Models.StopOnDisconnectStatus Enabled { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.StopOnDisconnectStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.StopOnDisconnectStatus left, Azure.Developer.DevCenter.Models.StopOnDisconnectStatus right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.StopOnDisconnectStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.StopOnDisconnectStatus left, Azure.Developer.DevCenter.Models.StopOnDisconnectStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class DevCenterClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DeploymentEnvironmentsClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDeploymentEnvironmentsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DeploymentEnvironmentsClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDeploymentEnvironmentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevBoxesClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevBoxesClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevBoxesClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevBoxesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevCenterClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevCenterClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevCenterClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevCenterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
