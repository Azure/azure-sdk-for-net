namespace Azure.ResourceManager.IoTFirmwareDefense
{
    public partial class DryrunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>, System.Collections.IEnumerable
    {
        protected DryrunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.IoTFirmwareDefense.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.IoTFirmwareDefense.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> Get(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>> GetAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DryrunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DryrunResource() { }
        public virtual Azure.ResourceManager.IoTFirmwareDefense.DryrunResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string dryrunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DryrunResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DryrunResourceData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunOperationPreview> OperationPreviews { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunParameters Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPrerequisiteResult> PrerequisiteResults { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public static partial class IoTFirmwareDefenseExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationNameItem> GetConfigurationNames(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationNameItem> GetConfigurationNamesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource> GetDryrun(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.DryrunResource>> GetDryrunAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.DryrunResource GetDryrunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.DryrunCollection GetDryruns(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> GetLinker(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>> GetLinkerAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.LinkerResource GetLinkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.LinkerCollection GetLinkers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> GetLocationConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>> GetLocationConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource GetLocationConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorCollection GetLocationConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> GetLocationDryrun(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>> GetLocationDryrunAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource GetLocationDryrunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunCollection GetLocationDryruns(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class LinkerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>, System.Collections.IEnumerable
    {
        protected LinkerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.IoTFirmwareDefense.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.IoTFirmwareDefense.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> Get(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>> GetAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkerResource() { }
        public virtual Azure.ResourceManager.IoTFirmwareDefense.LinkerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string linkerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationResult> GenerateConfigurations(Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationResult>> GenerateConfigurationsAsync(Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationResult> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationResult>> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LinkerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.Models.ValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.Models.ValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkerResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LinkerResourceData() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.PublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.SecretStore SecretStore { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase TargetService { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolution VNetSolution { get { throw null; } set { } }
    }
    public partial class LocationConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>, System.Collections.IEnumerable
    {
        protected LocationConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.IoTFirmwareDefense.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.IoTFirmwareDefense.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationConnectorResource() { }
        public virtual Azure.ResourceManager.IoTFirmwareDefense.LinkerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationResult> GenerateConfigurations(Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationResult>> GenerateConfigurationsAsync(Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.LinkerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.Models.ValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.Models.ValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationDryrunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>, System.Collections.IEnumerable
    {
        protected LocationDryrunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.IoTFirmwareDefense.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dryrunName, Azure.ResourceManager.IoTFirmwareDefense.DryrunResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> Get(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>> GetAsync(string dryrunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocationDryrunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationDryrunResource() { }
        public virtual Azure.ResourceManager.IoTFirmwareDefense.DryrunResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string dryrunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.LocationDryrunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IoTFirmwareDefense.Models
{
    public partial class AccessKeyInfoBase : Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase
    {
        public AccessKeyInfoBase() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission> Permissions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessKeyPermission : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessKeyPermission(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission Listen { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission Manage { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission Read { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission Send { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission left, Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission left, Azure.ResourceManager.IoTFirmwareDefense.Models.AccessKeyPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType Enable { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType Internal { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType OptOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType left, Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType left, Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowType : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowType(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType left, Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType left, Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmIoTFirmwareDefenseModelFactory
    {
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.BasicErrorDryrunPrerequisiteResult BasicErrorDryrunPrerequisiteResult(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationName ConfigurationName(string value = null, string description = null, bool? required = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationNameItem ConfigurationNameItem(string targetService = null, Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType? clientType = default(Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType?), Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType? authType = default(Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType?), Azure.ResourceManager.IoTFirmwareDefense.Models.DaprProperties daprProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationName> names = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationResult ConfigurationResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.Models.SourceConfiguration> configurations = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CreateOrUpdateDryrunParameters CreateOrUpdateDryrunParameters(Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase targetService = null, Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase authInfo = null, Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType? clientType = default(Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType?), string provisioningState = null, Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolution vNetSolution = null, Azure.ResourceManager.IoTFirmwareDefense.Models.SecretStore secretStore = null, string scope = null, Azure.ResourceManager.IoTFirmwareDefense.Models.PublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo configurationInfo = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunOperationPreview DryrunOperationPreview(string name = null, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType? operationType = default(Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType?), string description = null, string action = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.DryrunResourceData DryrunResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunParameters parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPrerequisiteResult> prerequisiteResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunOperationPreview> operationPreviews = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.LinkerResourceData LinkerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase targetService = null, Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase authInfo = null, Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType? clientType = default(Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType?), string provisioningState = null, Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolution vNetSolution = null, Azure.ResourceManager.IoTFirmwareDefense.Models.SecretStore secretStore = null, string scope = null, Azure.ResourceManager.IoTFirmwareDefense.Models.PublicNetworkSolution publicNetworkSolution = null, Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo configurationInfo = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.PermissionsMissingDryrunPrerequisiteResult PermissionsMissingDryrunPrerequisiteResult(string scope = null, System.Collections.Generic.IEnumerable<string> permissions = null, string recommendedRole = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.SourceConfiguration SourceConfiguration(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ValidateOperationResult ValidateOperationResult(string resourceId = null, string status = null, string linkerName = null, bool? isConnectionAvailable = default(bool?), System.DateTimeOffset? reportStartTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? reportEndTimeUtc = default(System.DateTimeOffset?), string sourceId = null, string targetId = null, Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType? authType = default(Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultItem> validationDetail = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultItem ValidationResultItem(string name = null, string description = null, Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus? result = default(Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus?), string errorMessage = null, string errorCode = null) { throw null; }
    }
    public abstract partial class AuthInfoBase
    {
        protected AuthInfoBase() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthType : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthType(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType AccessKey { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType Secret { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType ServicePrincipalCertificate { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType ServicePrincipalSecret { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType UserAccount { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType left, Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType left, Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureKeyVaultProperties : Azure.ResourceManager.IoTFirmwareDefense.Models.AzureResourcePropertiesBase
    {
        public AzureKeyVaultProperties() { }
        public bool? ConnectAsKubernetesCsiDriver { get { throw null; } set { } }
    }
    public partial class AzureResource : Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase
    {
        public AzureResource() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AzureResourcePropertiesBase ResourceProperties { get { throw null; } set { } }
    }
    public abstract partial class AzureResourcePropertiesBase
    {
        protected AzureResourcePropertiesBase() { }
    }
    public partial class BasicErrorDryrunPrerequisiteResult : Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPrerequisiteResult
    {
        internal BasicErrorDryrunPrerequisiteResult() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientType : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientType(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Dapr { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Django { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Dotnet { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Go { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Java { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType KafkaSpringBoot { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Nodejs { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType None { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Php { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Python { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType Ruby { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType SpringBoot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType left, Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType left, Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationInfo
    {
        public ConfigurationInfo() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType? Action { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> AdditionalConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomizedKeys { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DaprProperties DaprProperties { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
    }
    public partial class ConfigurationName
    {
        internal ConfigurationName() { }
        public string Description { get { throw null; } }
        public bool? Required { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ConfigurationNameItem
    {
        internal ConfigurationNameItem() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType? AuthType { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType? ClientType { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DaprProperties DaprProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationName> Names { get { throw null; } }
        public string TargetService { get { throw null; } }
    }
    public partial class ConfigurationResult
    {
        internal ConfigurationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.SourceConfiguration> Configurations { get { throw null; } }
    }
    public partial class ConfluentBootstrapServer : Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase
    {
        public ConfluentBootstrapServer() { }
        public string Endpoint { get { throw null; } set { } }
    }
    public partial class ConfluentSchemaRegistry : Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase
    {
        public ConfluentSchemaRegistry() { }
        public string Endpoint { get { throw null; } set { } }
    }
    public partial class CreateOrUpdateDryrunParameters : Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunParameters
    {
        public CreateOrUpdateDryrunParameters() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.PublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.SecretStore SecretStore { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase TargetService { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolution VNetSolution { get { throw null; } set { } }
    }
    public partial class DaprMetadata
    {
        public DaprMetadata() { }
        public string Name { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class DaprProperties
    {
        public DaprProperties() { }
        public string ComponentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTFirmwareDefense.Models.DaprMetadata> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public string SecretStoreComponent { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteOrUpdateBehavior : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteOrUpdateBehavior(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior Default { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior ForcedCleanup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior left, Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior left, Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DryrunOperationPreview
    {
        internal DryrunOperationPreview() { }
        public string Action { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType? OperationType { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public abstract partial class DryrunParameters
    {
        protected DryrunParameters() { }
    }
    public partial class DryrunPatch
    {
        public DryrunPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunOperationPreview> OperationPreviews { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunParameters Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPrerequisiteResult> PrerequisiteResults { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public abstract partial class DryrunPrerequisiteResult
    {
        protected DryrunPrerequisiteResult() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DryrunPreviewOperationType : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DryrunPreviewOperationType(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType ConfigAuth { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType ConfigConnection { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType ConfigNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType left, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType left, Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPreviewOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallRules
    {
        public FirewallRules() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType? AzureServices { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AllowType? CallerClientIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPRanges { get { throw null; } }
    }
    public partial class KeyVaultSecretReferenceSecretInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.SecretInfoBase
    {
        public KeyVaultSecretReferenceSecretInfo() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretUriSecretInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.SecretInfoBase
    {
        public KeyVaultSecretUriSecretInfo() { }
        public string Value { get { throw null; } set { } }
    }
    public partial class LinkerPatch
    {
        public LinkerPatch() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ClientType? ClientType { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ConfigurationInfo ConfigurationInfo { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.PublicNetworkSolution PublicNetworkSolution { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.SecretStore SecretStore { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase TargetService { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolution VNetSolution { get { throw null; } set { } }
    }
    public partial class PermissionsMissingDryrunPrerequisiteResult : Azure.ResourceManager.IoTFirmwareDefense.Models.DryrunPrerequisiteResult
    {
        internal PermissionsMissingDryrunPrerequisiteResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Permissions { get { throw null; } }
        public string RecommendedRole { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class PublicNetworkSolution
    {
        public PublicNetworkSolution() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.FirewallRules FirewallRules { get { throw null; } set { } }
    }
    public partial class SecretAuthInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase
    {
        public SecretAuthInfo() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.SecretInfoBase SecretInfo { get { throw null; } set { } }
    }
    public abstract partial class SecretInfoBase
    {
        protected SecretInfoBase() { }
    }
    public partial class SecretStore
    {
        public SecretStore() { }
        public string KeyVaultId { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
    }
    public partial class SelfHostedServer : Azure.ResourceManager.IoTFirmwareDefense.Models.TargetServiceBase
    {
        public SelfHostedServer() { }
        public string Endpoint { get { throw null; } set { } }
    }
    public partial class ServicePrincipalCertificateAuthInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase
    {
        public ServicePrincipalCertificateAuthInfo(string clientId, string principalId, string certificate) { }
        public string Certificate { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
    }
    public partial class ServicePrincipalSecretAuthInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase
    {
        public ServicePrincipalSecretAuthInfo(string clientId, string principalId, string secret) { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string Secret { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class SourceConfiguration
    {
        internal SourceConfiguration() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SystemAssignedIdentityAuthInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase
    {
        public SystemAssignedIdentityAuthInfo() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
    }
    public abstract partial class TargetServiceBase
    {
        protected TargetServiceBase() { }
    }
    public partial class UserAccountAuthInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase
    {
        public UserAccountAuthInfo() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class UserAssignedIdentityAuthInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.AuthInfoBase
    {
        public UserAssignedIdentityAuthInfo() { }
        public string ClientId { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string SubscriptionId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class ValidateOperationResult
    {
        internal ValidateOperationResult() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.AuthType? AuthType { get { throw null; } }
        public bool? IsConnectionAvailable { get { throw null; } }
        public string LinkerName { get { throw null; } }
        public System.DateTimeOffset? ReportEndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? ReportStartTimeUtc { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public string TargetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultItem> ValidationDetail { get { throw null; } }
    }
    public partial class ValidationResultItem
    {
        internal ValidationResultItem() { }
        public string Description { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus? Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationResultStatus : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus Success { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus left, Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus left, Azure.ResourceManager.IoTFirmwareDefense.Models.ValidationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValueSecretInfo : Azure.ResourceManager.IoTFirmwareDefense.Models.SecretInfoBase
    {
        public ValueSecretInfo() { }
        public string Value { get { throw null; } set { } }
    }
    public partial class VNetSolution
    {
        public VNetSolution() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.DeleteOrUpdateBehavior? DeleteOrUpdateBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType? SolutionType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VNetSolutionType : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VNetSolutionType(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType PrivateLink { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType ServiceEndpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType left, Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType left, Azure.ResourceManager.IoTFirmwareDefense.Models.VNetSolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
