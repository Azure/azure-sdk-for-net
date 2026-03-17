namespace Azure.ResourceManager.RedHatOpenShift
{
    public partial class AzureResourceManagerRedHatOpenShiftContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRedHatOpenShiftContext() { }
        public static Azure.ResourceManager.RedHatOpenShift.AzureResourceManagerRedHatOpenShiftContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class OpenShiftClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>, System.Collections.IEnumerable
    {
        protected OpenShiftClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OpenShiftClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>
    {
        public OpenShiftClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile ApiserverProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ConsoleUrl { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile> IngressProfiles { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile MasterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile PlatformWorkloadIdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> WorkerProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> WorkerProfilesStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OpenShiftClusterResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig> GetAdminCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>> GetAdminCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenShiftVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>, System.Collections.IEnumerable
    {
        protected OpenShiftVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> Get(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetAsync(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetIfExists(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetIfExistsAsync(string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OpenShiftVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>
    {
        public OpenShiftVersionData() { }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OpenShiftVersionResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string openShiftVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformWorkloadIdentityRoleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>, System.Collections.IEnumerable
    {
        protected PlatformWorkloadIdentityRoleSetCollection() { }
        public virtual Azure.Response<bool> Exists(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> Get(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetAsync(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetIfExists(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetIfExistsAsync(string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlatformWorkloadIdentityRoleSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>
    {
        public PlatformWorkloadIdentityRoleSetData() { }
        public string OpenShiftVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole> PlatformWorkloadIdentityRoles { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlatformWorkloadIdentityRoleSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlatformWorkloadIdentityRoleSetResource() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string openShiftMinorVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class RedHatOpenShiftExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetOpenShiftClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource GetOpenShiftClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterCollection GetOpenShiftClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetOpenShiftVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetOpenShiftVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource GetOpenShiftVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionCollection GetOpenShiftVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetPlatformWorkloadIdentityRoleSet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetPlatformWorkloadIdentityRoleSetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource GetPlatformWorkloadIdentityRoleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetCollection GetPlatformWorkloadIdentityRoleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location) { throw null; }
    }
}
namespace Azure.ResourceManager.RedHatOpenShift.Mocking
{
    public partial class MockableRedHatOpenShiftArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftArmClient() { }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource GetOpenShiftClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource GetOpenShiftVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource GetPlatformWorkloadIdentityRoleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRedHatOpenShiftResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftCluster(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource>> GetOpenShiftClusterAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterCollection GetOpenShiftClusters() { throw null; }
    }
    public partial class MockableRedHatOpenShiftSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedHatOpenShiftSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterResource> GetOpenShiftClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource> GetOpenShiftVersion(string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionResource>> GetOpenShiftVersionAsync(string location, string openShiftVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionCollection GetOpenShiftVersions(string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource> GetPlatformWorkloadIdentityRoleSet(string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetResource>> GetPlatformWorkloadIdentityRoleSetAsync(string location, string openShiftMinorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetCollection GetPlatformWorkloadIdentityRoleSets(string location) { throw null; }
    }
}
namespace Azure.ResourceManager.RedHatOpenShift.Models
{
    public static partial class ArmRedHatOpenShiftModelFactory
    {
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile OpenShiftApiServerProfile(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility? visibility = default(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility?), string url = null, string ip = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig OpenShiftClusterAdminKubeconfig(string kubeconfig = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials OpenShiftClusterCredentials(string kubeadminUsername = null, string kubeadminPassword = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftClusterData OpenShiftClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState?), Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile clusterProfile = null, string consoleUrl = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile servicePrincipalProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile platformWorkloadIdentityProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile networkProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile masterProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> workerProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> workerProfilesStatus = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile apiserverProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile> ingressProfiles = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch OpenShiftClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState? provisioningState = default(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState?), Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile clusterProfile = null, string consoleUrl = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile servicePrincipalProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile platformWorkloadIdentityProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile networkProfile = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile masterProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> workerProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> workerProfilesStatus = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile apiserverProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile> ingressProfiles = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile OpenShiftClusterProfile(string pullSecret = null, string domain = null, string version = null, Azure.Core.ResourceIdentifier resourceGroupId = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule? fipsValidatedModules = default(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule?), string oidcIssuer = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile OpenShiftIngressProfile(string name = null, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility? visibility = default(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility?), string ip = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile OpenShiftLoadBalancerProfile(int? managedOutboundIPsCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> effectiveOutboundIPs = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity OpenShiftPlatformWorkloadIdentity(Azure.Core.ResourceIdentifier resourceId = null, string clientId = null, string objectId = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.OpenShiftVersionData OpenShiftVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string version = null) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.PlatformWorkloadIdentityRoleSetData PlatformWorkloadIdentityRoleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string openShiftVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole> platformWorkloadIdentityRoles = null) { throw null; }
    }
    public partial class OpenShiftApiServerProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile>
    {
        public OpenShiftApiServerProfile() { }
        public string Ip { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility? Visibility { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftClusterAdminKubeconfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>
    {
        internal OpenShiftClusterAdminKubeconfig() { }
        public string Kubeconfig { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterAdminKubeconfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftClusterCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>
    {
        internal OpenShiftClusterCredentials() { }
        public string KubeadminPassword { get { throw null; } }
        public string KubeadminUsername { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch>
    {
        public OpenShiftClusterPatch() { }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftApiServerProfile ApiserverProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ConsoleUrl { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile> IngressProfiles { get { throw null; } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile MasterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile PlatformWorkloadIdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> WorkerProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile> WorkerProfilesStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftClusterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile>
    {
        public OpenShiftClusterProfile() { }
        public string Domain { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule? FipsValidatedModules { get { throw null; } set { } }
        public string OidcIssuer { get { throw null; } }
        public string PullSecret { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenShiftClusterProvisioningState : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenShiftClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState AdminUpdating { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenShiftEncryptionAtHost : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenShiftEncryptionAtHost(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenShiftFipsValidatedModule : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenShiftFipsValidatedModule(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftFipsValidatedModule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenShiftIngressProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile>
    {
        public OpenShiftIngressProfile() { }
        public string Ip { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility? Visibility { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftIngressProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftLoadBalancerProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile>
    {
        public OpenShiftLoadBalancerProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> EffectiveOutboundIps { get { throw null; } }
        public int? ManagedOutboundIpsCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftMasterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile>
    {
        public OpenShiftMasterProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost? EncryptionAtHost { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftMasterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile>
    {
        public OpenShiftNetworkProfile() { }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftLoadBalancerProfile LoadBalancerProfile { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType? OutboundType { get { throw null; } set { } }
        public string PodCidr { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg? PreconfiguredNSG { get { throw null; } set { } }
        public string ServiceCidr { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenShiftOutboundType : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenShiftOutboundType(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType Loadbalancer { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType UserDefinedRouting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftOutboundType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenShiftPlatformWorkloadIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity>
    {
        public OpenShiftPlatformWorkloadIdentity() { }
        public string ClientId { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftPlatformWorkloadIdentityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile>
    {
        public OpenShiftPlatformWorkloadIdentityProfile() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentity> PlatformWorkloadIdentities { get { throw null; } }
        public string UpgradeableTo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenShiftPlatformWorkloadIdentityRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole>
    {
        public OpenShiftPlatformWorkloadIdentityRole() { }
        public string OperatorName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string RoleDefinitionName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPlatformWorkloadIdentityRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenShiftPreconfiguredNsg : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenShiftPreconfiguredNsg(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg Disabled { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftPreconfiguredNsg right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenShiftServicePrincipalProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile>
    {
        public OpenShiftServicePrincipalProfile() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftServicePrincipalProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenShiftVisibility : System.IEquatable<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenShiftVisibility(string value) { throw null; }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility Private { get { throw null; } }
        public static Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility left, Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenShiftWorkerProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile>
    {
        public OpenShiftWorkerProfile() { }
        public int? Count { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftEncryptionAtHost? EncryptionAtHost { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RedHatOpenShift.Models.OpenShiftWorkerProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
