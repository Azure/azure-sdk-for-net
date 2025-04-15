namespace Azure.ResourceManager.NeonPostgres
{
    public partial class BranchCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.BranchResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.BranchResource>, System.Collections.IEnumerable
    {
        protected BranchCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.BranchResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string branchName, Azure.ResourceManager.NeonPostgres.BranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.BranchResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string branchName, Azure.ResourceManager.NeonPostgres.BranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.BranchResource> Get(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.BranchResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.BranchResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.BranchResource>> GetAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.BranchResource> GetIfExists(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.BranchResource>> GetIfExistsAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.BranchResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.BranchResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.BranchResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.BranchResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BranchData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.BranchData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>
    {
        public BranchData() { }
        public Azure.ResourceManager.NeonPostgres.Models.BranchProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.BranchData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.BranchData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.BranchData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.BranchData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BranchResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.BranchData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BranchResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.BranchData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName, string branchName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.BranchResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.BranchResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.ComputeResource> GetCompute(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.ComputeResource>> GetComputeAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.ComputeCollection GetComputes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.EndpointResource> GetEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.EndpointResource>> GetEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.EndpointCollection GetEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> GetNeonDatabase(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>> GetNeonDatabaseAsync(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonDatabaseCollection GetNeonDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonRoleResource> GetNeonRole(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonRoleResource>> GetNeonRoleAsync(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonRoleCollection GetNeonRoles() { throw null; }
        Azure.ResourceManager.NeonPostgres.BranchData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.BranchData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.BranchData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.BranchData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.BranchData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.BranchResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.BranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.BranchResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.BranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.ComputeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.ComputeResource>, System.Collections.IEnumerable
    {
        protected ComputeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ComputeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.NeonPostgres.ComputeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ComputeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string computeName, Azure.ResourceManager.NeonPostgres.ComputeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.ComputeResource> Get(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.ComputeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.ComputeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.ComputeResource>> GetAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.ComputeResource> GetIfExists(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.ComputeResource>> GetIfExistsAsync(string computeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.ComputeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.ComputeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.ComputeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.ComputeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ComputeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>
    {
        public ComputeData() { }
        public Azure.ResourceManager.NeonPostgres.Models.ComputeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.ComputeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.ComputeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ComputeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.ComputeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName, string branchName, string computeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.ComputeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.ComputeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.ComputeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.ComputeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ComputeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ComputeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.ComputeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ComputeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.ComputeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.EndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.EndpointResource>, System.Collections.IEnumerable
    {
        protected EndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.EndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.NeonPostgres.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.EndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.NeonPostgres.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.EndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.EndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.EndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.EndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.EndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.EndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.EndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.EndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.EndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.EndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.EndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>
    {
        public EndpointData() { }
        public Azure.ResourceManager.NeonPostgres.Models.EndpointProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.EndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.EndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.EndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EndpointResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.EndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName, string branchName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.EndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.EndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.EndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.EndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.EndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.EndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.EndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeonDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>, System.Collections.IEnumerable
    {
        protected NeonDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string neonDatabaseName, Azure.ResourceManager.NeonPostgres.NeonDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string neonDatabaseName, Azure.ResourceManager.NeonPostgres.NeonDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> Get(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>> GetAsync(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> GetIfExists(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>> GetIfExistsAsync(string neonDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeonDatabaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>
    {
        public NeonDatabaseData() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeonDatabaseResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName, string branchName, string neonDatabaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.NeonDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeonOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>, System.Collections.IEnumerable
    {
        protected NeonOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeonOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>
    {
        public NeonOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeonOrganizationResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.ProjectResource> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.ProjectResource>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.ProjectCollection GetProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NeonPostgresExtensions
    {
        public static Azure.ResourceManager.NeonPostgres.BranchResource GetBranchResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.ComputeResource GetComputeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.EndpointResource GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonDatabaseResource GetNeonDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetNeonOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationResource GetNeonOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationCollection GetNeonOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonRoleResource GetNeonRoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult> GetOrganizationPostgresVersions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>> GetOrganizationPostgresVersionsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.ProjectResource GetProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NeonRoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonRoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonRoleResource>, System.Collections.IEnumerable
    {
        protected NeonRoleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonRoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string neonRoleName, Azure.ResourceManager.NeonPostgres.NeonRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonRoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string neonRoleName, Azure.ResourceManager.NeonPostgres.NeonRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonRoleResource> Get(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonRoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonRoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonRoleResource>> GetAsync(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonRoleResource> GetIfExists(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonRoleResource>> GetIfExistsAsync(string neonRoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.NeonRoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonRoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.NeonRoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonRoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeonRoleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>
    {
        public NeonRoleData() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonRoleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonRoleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonRoleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeonRoleResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonRoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName, string branchName, string neonRoleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonRoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonRoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.NeonRoleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonRoleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonRoleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonRoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonRoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.ProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.ProjectResource>, System.Collections.IEnumerable
    {
        protected ProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.NeonPostgres.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.NeonPostgres.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.ProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.ProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.ProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.ProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.ProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.ProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>
    {
        public ProjectData() { }
        public Azure.ResourceManager.NeonPostgres.Models.ProjectProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.ProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.ProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.ProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.ProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.ProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.BranchResource> GetBranch(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.BranchResource>> GetBranchAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.BranchCollection GetBranches() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties> GetConnectionUri(Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties connectionUriParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>> GetConnectionUriAsync(Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties connectionUriParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.ProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.ProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.ProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.ProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Mocking
{
    public partial class MockableNeonPostgresArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresArmClient() { }
        public virtual Azure.ResourceManager.NeonPostgres.BranchResource GetBranchResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.ComputeResource GetComputeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.EndpointResource GetEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonDatabaseResource GetNeonDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationResource GetNeonOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonRoleResource GetNeonRoleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.ProjectResource GetProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNeonPostgresResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetNeonOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationCollection GetNeonOrganizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult> GetOrganizationPostgresVersions(Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>> GetOrganizationPostgresVersionsAsync(Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableNeonPostgresSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Models
{
    public static partial class ArmNeonPostgresModelFactory
    {
        public static Azure.ResourceManager.NeonPostgres.BranchData BranchData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.BranchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.BranchProperties BranchProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string projectId = null, string parentId = null, string roleName = null, string databaseName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> roles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> databases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties> endpoints = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.ComputeData ComputeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.ComputeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.ComputeProperties ComputeProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string region = null, int? cpuCores = default(int?), int? memory = default(int?), string status = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties ConnectionUriProperties(string projectId = null, string branchId = null, string databaseName = null, string roleName = null, string endpointId = null, bool? isPooled = default(bool?), string connectionStringUri = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.EndpointData EndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.EndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.EndpointProperties EndpointProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string projectId = null, string branchId = null, Azure.ResourceManager.NeonPostgres.Models.EndpointType? endpointType = default(Azure.ResourceManager.NeonPostgres.Models.EndpointType?)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonDatabaseData NeonDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties NeonDatabaseProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string branchId = null, string ownerName = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationData NeonOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties NeonOrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails userDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails companyDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties partnerOrganizationProperties = null, Azure.ResourceManager.NeonPostgres.Models.ProjectProperties projectProperties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonRoleData NeonRoleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties NeonRoleProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string branchId = null, System.Collections.Generic.IEnumerable<string> permissions = null, bool? isSuperUser = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult PgVersionsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.PgVersion> versions = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.ProjectData ProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.ProjectProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.ProjectProperties ProjectProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string regionId = null, long? storage = default(long?), int? pgVersion = default(int?), int? historyRetention = default(int?), Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings defaultEndpointSettings = null, Azure.ResourceManager.NeonPostgres.Models.BranchProperties branch = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> roles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> databases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties> endpoints = null) { throw null; }
    }
    public partial class Attributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>
    {
        public Attributes(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.Attributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.Attributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BranchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.BranchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.BranchProperties>
    {
        public BranchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string CreatedAt { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> Databases { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties> Endpoints { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public string ParentId { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> Roles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.BranchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.BranchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.BranchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.BranchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.BranchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.BranchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.BranchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ComputeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ComputeProperties>
    {
        public ComputeProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public int? CpuCores { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public int? Memory { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ComputeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ComputeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ComputeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ComputeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ComputeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ComputeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ComputeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionUriProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>
    {
        public ConnectionUriProperties() { }
        public string BranchId { get { throw null; } set { } }
        public string ConnectionStringUri { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
        public string EndpointId { get { throw null; } set { } }
        public bool? IsPooled { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>
    {
        public DefaultEndpointSettings(float autoscalingLimitMinCu, float autoscalingLimitMaxCu) { }
        public float AutoscalingLimitMaxCu { get { throw null; } set { } }
        public float AutoscalingLimitMinCu { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties>
    {
        public EndpointProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string BranchId { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.EndpointType? EndpointType { get { throw null; } set { } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.EndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.EndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.EndpointType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.EndpointType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.EndpointType left, Azure.ResourceManager.NeonPostgres.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.EndpointType left, Azure.ResourceManager.NeonPostgres.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>
    {
        public NeonCompanyDetails() { }
        public string BusinessPhone { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public long? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonDatabaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>
    {
        public NeonDatabaseProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string BranchId { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public string OwnerName { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>
    {
        public NeonMarketplaceDetails(Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails offerDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>
    {
        public NeonOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>
    {
        public NeonOrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails marketplaceDetails, Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails userDetails, Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails companyDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.ProjectProperties ProjectProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails UserDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeonResourceProvisioningState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeonResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonRoleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>
    {
        public NeonRoleProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string BranchId { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public bool? IsSuperUser { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Permissions { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>
    {
        public NeonSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public string SingleSignOnUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeonSingleSignOnState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeonSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>
    {
        public NeonUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>
    {
        public PartnerOrganizationProperties(string organizationName) { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PgVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>
    {
        public PgVersion() { }
        public int? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PgVersionsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>
    {
        internal PgVersionsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NeonPostgres.Models.PgVersion> Versions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ProjectProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ProjectProperties>
    {
        public ProjectProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.BranchProperties Branch { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> Databases { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings DefaultEndpointSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.EndpointProperties> Endpoints { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public int? HistoryRetention { get { throw null; } set { } }
        public int? PgVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string RegionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> Roles { get { throw null; } }
        public long? Storage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ProjectProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ProjectProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ProjectProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ProjectProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ProjectProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ProjectProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ProjectProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
