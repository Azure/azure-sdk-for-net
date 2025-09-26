namespace Azure.Developer.DevCenter
{
    public partial class AzureDeveloperDevCenterContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureDeveloperDevCenterContext() { }
        public static Azure.Developer.DevCenter.AzureDeveloperDevCenterContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeploymentEnvironmentsClient
    {
        protected DeploymentEnvironmentsClient() { }
        public DeploymentEnvironmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DeploymentEnvironmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<Azure.Developer.DevCenter.Models.DevCenterEnvironment> CreateOrUpdateEnvironment(Azure.WaitUntil waitUntil, string projectName, string userId, Azure.Developer.DevCenter.Models.DevCenterEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateEnvironment(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Developer.DevCenter.Models.DevCenterEnvironment>> CreateOrUpdateEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string userId, Azure.Developer.DevCenter.Models.DevCenterEnvironment environment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteEnvironment(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllEnvironments(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetAllEnvironments(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllEnvironmentsAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetAllEnvironmentsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCatalog(string projectName, string catalogName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevCenterCatalog> GetCatalog(string projectName, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCatalogAsync(string projectName, string catalogName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevCenterCatalog>> GetCatalogAsync(string projectName, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCatalogs(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterCatalog> GetCatalogs(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCatalogsAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterCatalog> GetCatalogsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnvironment(string projectName, string userId, string environmentName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetEnvironment(string projectName, string userId, string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentAsync(string projectName, string userId, string environmentName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevCenterEnvironment>> GetEnvironmentAsync(string projectName, string userId, string environmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEnvironmentDefinition(string projectName, string catalogName, string definitionName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinition(string projectName, string catalogName, string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentDefinitionAsync(string projectName, string catalogName, string definitionName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.EnvironmentDefinition>> GetEnvironmentDefinitionAsync(string projectName, string catalogName, string definitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentDefinitions(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitions(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentDefinitionsAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitionsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentDefinitionsByCatalog(string projectName, string catalogName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitionsByCatalog(string projectName, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentDefinitionsByCatalogAsync(string projectName, string catalogName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.EnvironmentDefinition> GetEnvironmentDefinitionsByCatalogAsync(string projectName, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironments(string projectName, string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetEnvironments(string projectName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentsAsync(string projectName, string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterEnvironment> GetEnvironmentsAsync(string projectName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentTypes(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType> GetEnvironmentTypes(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentTypesAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType> GetEnvironmentTypesAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxes(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxesByUser(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxesByUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesByUserAsync(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBox> GetAllDevBoxesByUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetDevBoxes(string projectName, string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBox> GetDevBoxes(string projectName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevBoxesAsync(string projectName, string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBox> GetDevBoxesAsync(string projectName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPool(string projectName, string poolName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevBoxPool> GetPool(string projectName, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPoolAsync(string projectName, string poolName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevBoxPool>> GetPoolAsync(string projectName, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPools(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBoxPool> GetPools(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolsAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBoxPool> GetPoolsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRemoteConnection(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.RemoteConnection> GetRemoteConnection(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRemoteConnectionAsync(string projectName, string userId, string devBoxName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.RemoteConnection>> GetRemoteConnectionAsync(string projectName, string userId, string devBoxName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSchedule(string projectName, string poolName, string scheduleName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.DevCenter.Models.DevBoxSchedule> GetSchedule(string projectName, string poolName, string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleAsync(string projectName, string poolName, string scheduleName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.DevCenter.Models.DevBoxSchedule>> GetScheduleAsync(string projectName, string poolName, string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedules(string projectName, string poolName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevBoxSchedule> GetSchedules(string projectName, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesAsync(string projectName, string poolName, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevBoxSchedule> GetSchedulesAsync(string projectName, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<System.BinaryData> GetProjects(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.DevCenter.Models.DevCenterProject> GetProjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.DevCenter.Models.DevCenterProject> GetProjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DevBox : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBox>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBox>
    {
        public DevBox(string name, string poolName) { }
        public string ActionState { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxHardwareProfile HardwareProfile { get { throw null; } }
        public Azure.Developer.DevCenter.Models.HibernateSupport? HibernateSupport { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxImageReference ImageReference { get { throw null; } }
        public Azure.Developer.DevCenter.Models.LocalAdministratorStatus? LocalAdministratorStatus { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxOSType? OSType { get { throw null; } }
        public string PoolName { get { throw null; } set { } }
        public Azure.Developer.DevCenter.Models.PowerState? PowerState { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxStorageProfile StorageProfile { get { throw null; } }
        public System.Guid? UniqueId { get { throw null; } }
        public System.Guid? UserId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBox System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBox System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxAction : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxAction>
    {
        internal DevBoxAction() { }
        public Azure.Developer.DevCenter.Models.DevBoxActionType ActionType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxNextAction NextAction { get { throw null; } }
        public string SourceId { get { throw null; } }
        public System.DateTimeOffset? SuspendedUntil { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxAction System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxAction System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxActionDelayResult : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult>
    {
        internal DevBoxActionDelayResult() { }
        public Azure.Developer.DevCenter.Models.DevBoxAction Action { get { throw null; } }
        public string ActionName { get { throw null; } }
        public Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus DelayStatus { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxActionDelayResult System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxActionDelayResult System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxActionDelayResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DevBoxHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxHardwareProfile>
    {
        public DevBoxHardwareProfile() { }
        public int? MemoryGB { get { throw null; } }
        public Azure.Developer.DevCenter.Models.SkuName? SkuName { get { throw null; } }
        public int? VCPUs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxImageReference : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxImageReference>
    {
        public DevBoxImageReference() { }
        public string Name { get { throw null; } }
        public string OperatingSystem { get { throw null; } }
        public string OSBuildNumber { get { throw null; } }
        public System.DateTimeOffset? PublishedDate { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxImageReference System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxImageReference System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxNextAction : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxNextAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxNextAction>
    {
        internal DevBoxNextAction() { }
        public System.DateTimeOffset ScheduledTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxNextAction System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxNextAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxNextAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxNextAction System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxNextAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxNextAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxNextAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DevBoxPool : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxPool>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxPool>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxPool System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxPool System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DevBoxSchedule : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxSchedule>
    {
        internal DevBoxSchedule() { }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.ScheduleFrequency ScheduleFrequency { get { throw null; } }
        public Azure.Developer.DevCenter.Models.ScheduleType ScheduleType { get { throw null; } }
        public string Time { get { throw null; } }
        public string TimeZone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxSchedule System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxSchedule System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevBoxStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxStorageProfile>
    {
        public DevBoxStorageProfile() { }
        public Azure.Developer.DevCenter.Models.OSDisk OSDisk { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevBoxStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevBoxStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevBoxStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterCatalog : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterCatalog>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterCatalog>
    {
        internal DevCenterCatalog() { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterCatalog System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterCatalog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterCatalog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterCatalog System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterCatalog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterCatalog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterCatalog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEnvironment : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironment>
    {
        public DevCenterEnvironment(string environmentName, string environmentTypeName, string catalogName, string environmentDefinitionName) { }
        public string CatalogName { get { throw null; } set { } }
        public string EnvironmentDefinitionName { get { throw null; } set { } }
        public string EnvironmentTypeName { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public Azure.Developer.DevCenter.Models.EnvironmentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } }
        public System.Guid? UserId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterEnvironment System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevCenterEnvironmentType : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType>
    {
        internal DevCenterEnvironmentType() { }
        public Azure.Core.ResourceIdentifier DeploymentTargetId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.EnvironmentTypeStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterEnvironmentType System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterEnvironmentType System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterEnvironmentType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DevCenterModelFactory
    {
        public static Azure.Developer.DevCenter.Models.DevBox DevBox(string name = null, string projectName = null, string poolName = null, Azure.Developer.DevCenter.Models.HibernateSupport? hibernateSupport = default(Azure.Developer.DevCenter.Models.HibernateSupport?), Azure.Developer.DevCenter.Models.DevBoxProvisioningState? provisioningState = default(Azure.Developer.DevCenter.Models.DevBoxProvisioningState?), string actionState = null, Azure.Developer.DevCenter.Models.PowerState? powerState = default(Azure.Developer.DevCenter.Models.PowerState?), System.Guid? uniqueId = default(System.Guid?), Azure.ResponseError error = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Developer.DevCenter.Models.DevBoxOSType? osType = default(Azure.Developer.DevCenter.Models.DevBoxOSType?), System.Guid? userId = default(System.Guid?), Azure.Developer.DevCenter.Models.DevBoxHardwareProfile hardwareProfile = null, Azure.Developer.DevCenter.Models.DevBoxStorageProfile storageProfile = null, Azure.Developer.DevCenter.Models.DevBoxImageReference imageReference = null, System.DateTimeOffset? createdTime = default(System.DateTimeOffset?), Azure.Developer.DevCenter.Models.LocalAdministratorStatus? localAdministratorStatus = default(Azure.Developer.DevCenter.Models.LocalAdministratorStatus?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxAction DevBoxAction(string name = null, Azure.Developer.DevCenter.Models.DevBoxActionType actionType = default(Azure.Developer.DevCenter.Models.DevBoxActionType), string sourceId = null, System.DateTimeOffset? suspendedUntil = default(System.DateTimeOffset?), Azure.Developer.DevCenter.Models.DevBoxNextAction nextAction = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxActionDelayResult DevBoxActionDelayResult(string actionName = null, Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus delayStatus = default(Azure.Developer.DevCenter.Models.DevBoxActionDelayStatus), Azure.Developer.DevCenter.Models.DevBoxAction action = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxHardwareProfile DevBoxHardwareProfile(Azure.Developer.DevCenter.Models.SkuName? skuName = default(Azure.Developer.DevCenter.Models.SkuName?), int? vcpUs = default(int?), int? memoryGB = default(int?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxImageReference DevBoxImageReference(string name = null, string version = null, string operatingSystem = null, string osBuildNumber = null, System.DateTimeOffset? publishedDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxNextAction DevBoxNextAction(System.DateTimeOffset scheduledTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxPool DevBoxPool(string name = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Developer.DevCenter.Models.DevBoxOSType? osType = default(Azure.Developer.DevCenter.Models.DevBoxOSType?), Azure.Developer.DevCenter.Models.DevBoxHardwareProfile hardwareProfile = null, Azure.Developer.DevCenter.Models.HibernateSupport? hibernateSupport = default(Azure.Developer.DevCenter.Models.HibernateSupport?), Azure.Developer.DevCenter.Models.DevBoxStorageProfile storageProfile = null, Azure.Developer.DevCenter.Models.DevBoxImageReference imageReference = null, Azure.Developer.DevCenter.Models.LocalAdministratorStatus? localAdministratorStatus = default(Azure.Developer.DevCenter.Models.LocalAdministratorStatus?), Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect = null, Azure.Developer.DevCenter.Models.PoolHealthStatus healthStatus = default(Azure.Developer.DevCenter.Models.PoolHealthStatus)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxSchedule DevBoxSchedule(string name = null, Azure.Developer.DevCenter.Models.ScheduleType scheduleType = default(Azure.Developer.DevCenter.Models.ScheduleType), Azure.Developer.DevCenter.Models.ScheduleFrequency scheduleFrequency = default(Azure.Developer.DevCenter.Models.ScheduleFrequency), string time = null, string timeZone = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevBoxStorageProfile DevBoxStorageProfile(Azure.Developer.DevCenter.Models.OSDisk osDisk = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterCatalog DevCenterCatalog(string name = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterEnvironment DevCenterEnvironment(System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null, string name = null, string environmentTypeName = null, System.Guid? userId = default(System.Guid?), Azure.Developer.DevCenter.Models.EnvironmentProvisioningState? provisioningState = default(Azure.Developer.DevCenter.Models.EnvironmentProvisioningState?), Azure.Core.ResourceIdentifier resourceGroupId = null, string catalogName = null, string environmentDefinitionName = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterEnvironmentType DevCenterEnvironmentType(string name = null, Azure.Core.ResourceIdentifier deploymentTargetId = null, Azure.Developer.DevCenter.Models.EnvironmentTypeStatus status = default(Azure.Developer.DevCenter.Models.EnvironmentTypeStatus)) { throw null; }
        public static Azure.Developer.DevCenter.Models.DevCenterProject DevCenterProject(string name = null, string description = null, int? maxDevBoxesPerUser = default(int?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinition EnvironmentDefinition(string id = null, string name = null, string catalogName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter> parameters = null, string parametersSchema = null, string templatePath = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter EnvironmentDefinitionParameter(string id = null, string name = null, string description = null, string defaultValue = null, Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType parameterType = default(Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType), bool? readOnly = default(bool?), bool required = false, System.Collections.Generic.IEnumerable<string> allowed = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.OSDisk OSDisk(int? diskSizeGB = default(int?)) { throw null; }
        public static Azure.Developer.DevCenter.Models.RemoteConnection RemoteConnection(System.Uri webUri = null, System.Uri rdpConnectionUri = null) { throw null; }
        public static Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnectConfiguration(Azure.Developer.DevCenter.Models.StopOnDisconnectStatus status = default(Azure.Developer.DevCenter.Models.StopOnDisconnectStatus), int? gracePeriodMinutes = default(int?)) { throw null; }
    }
    public partial class DevCenterProject : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterProject>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterProject>
    {
        internal DevCenterProject() { }
        public string Description { get { throw null; } }
        public int? MaxDevBoxesPerUser { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterProject System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.DevCenterProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.DevCenterProject System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.DevCenterProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.EnvironmentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinition>
    {
        internal EnvironmentDefinition() { }
        public string CatalogName { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter> Parameters { get { throw null; } }
        public string ParametersSchema { get { throw null; } }
        public string TemplatePath { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.EnvironmentDefinition System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.EnvironmentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.EnvironmentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.EnvironmentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnvironmentDefinitionParameter : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter>
    {
        internal EnvironmentDefinitionParameter() { }
        public System.Collections.Generic.IReadOnlyList<string> Allowed { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameterType ParameterType { get { throw null; } }
        public bool? ReadOnly { get { throw null; } }
        public bool Required { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.EnvironmentDefinitionParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OSDisk : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.OSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.OSDisk>
    {
        public OSDisk() { }
        public int? DiskSizeGB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.OSDisk System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.OSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.OSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.OSDisk System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.OSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.OSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.OSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RemoteConnection : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.RemoteConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.RemoteConnection>
    {
        internal RemoteConnection() { }
        public System.Uri RdpConnectionUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.RemoteConnection System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.RemoteConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.RemoteConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.RemoteConnection System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.RemoteConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.RemoteConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.RemoteConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct ScheduleType : System.IEquatable<Azure.Developer.DevCenter.Models.ScheduleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleType(string value) { throw null; }
        public static Azure.Developer.DevCenter.Models.ScheduleType StopDevBox { get { throw null; } }
        public bool Equals(Azure.Developer.DevCenter.Models.ScheduleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.DevCenter.Models.ScheduleType left, Azure.Developer.DevCenter.Models.ScheduleType right) { throw null; }
        public static implicit operator Azure.Developer.DevCenter.Models.ScheduleType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.DevCenter.Models.ScheduleType left, Azure.Developer.DevCenter.Models.ScheduleType right) { throw null; }
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
    public partial class StopOnDisconnectConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration>
    {
        internal StopOnDisconnectConfiguration() { }
        public int? GracePeriodMinutes { get { throw null; } }
        public Azure.Developer.DevCenter.Models.StopOnDisconnectStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.DevCenter.Models.StopOnDisconnectConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
