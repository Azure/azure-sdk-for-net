namespace Azure.ResourceManager.ResilienceManagement
{
    public partial class AzureResourceManagerResilienceManagementContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResilienceManagementContext() { }
        public static Azure.ResourceManager.ResilienceManagement.AzureResourceManagerResilienceManagementContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DrillRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunResource>, System.Collections.IEnumerable
    {
        protected DrillRunCollection() { }
        public virtual Azure.Response<bool> Exists(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource> Get(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.DrillRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.DrillRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource>> GetAsync(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.DrillRunResource> GetIfExists(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.DrillRunResource>> GetIfExistsAsync(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.DrillRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.DrillRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DrillRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>
    {
        internal DrillRunData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.DrillRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.DrillRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DrillRunResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddNotes(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddNotesAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string drillName, string drillRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FailOver(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailOverAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> GetDrillRunTarget(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>> GetDrillRunTargetAsync(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunTargetCollection GetDrillRunTargets() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MarkAsComplete(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MarkAsCompleteAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reprotect(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReprotectAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.DrillRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.DrillRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillRunTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>, System.Collections.IEnumerable
    {
        protected DrillRunTargetCollection() { }
        public virtual Azure.Response<bool> Exists(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> Get(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>> GetAsync(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> GetIfExists(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>> GetIfExistsAsync(string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DrillRunTargetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>
    {
        internal DrillRunTargetData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.DrillRunTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.DrillRunTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillRunTargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DrillRunTargetResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string drillName, string drillRunName, string drillRunResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.DrillRunTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.DrillRunTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillRunTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>, System.Collections.IEnumerable
    {
        protected DrillTargetCollection() { }
        public virtual Azure.Response<bool> Exists(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> Get(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> GetAll(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> GetAllAsync(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>> GetAsync(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> GetIfExists(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>> GetIfExistsAsync(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DrillTargetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>
    {
        internal DrillTargetData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.DrillTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.DrillTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillTargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DrillTargetResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string drillName, string drillResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.DrillTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.DrillTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.DrillTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GoalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>, System.Collections.IEnumerable
    {
        protected GoalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string goalAssignmentName, Azure.ResourceManager.ResilienceManagement.GoalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string goalAssignmentName, Azure.ResourceManager.ResilienceManagement.GoalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> Get(string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> GetAll(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> GetAllAsync(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>> GetAsync(string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> GetIfExists(string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>> GetIfExistsAsync(string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GoalAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>
    {
        public GoalAssignmentData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.GoalAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.GoalAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GoalAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GoalAssignmentResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string goalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalMembersCollection GetAllGoalMembers() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> GetGoalMembers(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>> GetGoalMembersAsync(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RecommendCapacity(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RecommendCapacityAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshGoalResources(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshGoalResourcesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.GoalAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.GoalAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.GoalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.GoalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateGoalResources(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateGoalResourcesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GoalMembersCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>, System.Collections.IEnumerable
    {
        protected GoalMembersCollection() { }
        public virtual Azure.Response<bool> Exists(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> Get(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> GetAll(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> GetAllAsync(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>> GetAsync(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> GetIfExists(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>> GetIfExistsAsync(string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GoalMembersData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>
    {
        public GoalMembersData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.GoalMembersData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.GoalMembersData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GoalMembersResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GoalMembersResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalMembersData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string goalAssignmentName, string goalResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.GoalMembersData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.GoalMembersData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalMembersData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GoalTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>, System.Collections.IEnumerable
    {
        protected GoalTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string goalTemplateName, Azure.ResourceManager.ResilienceManagement.GoalTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string goalTemplateName, Azure.ResourceManager.ResilienceManagement.GoalTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> Get(string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> GetAll(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> GetAllAsync(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>> GetAsync(string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> GetIfExists(string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>> GetIfExistsAsync(string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GoalTemplateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>
    {
        public GoalTemplateData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.GoalTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.GoalTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GoalTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GoalTemplateResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string goalTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.GoalTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.GoalTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.GoalTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.GoalTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.GoalTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>, System.Collections.IEnumerable
    {
        protected RecoveryJobCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> Get(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>> GetAsync(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> GetIfExists(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>> GetIfExistsAsync(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>
    {
        internal RecoveryJobData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryJobResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult> Cancel(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>> CancelAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string recoveryPlanName, string recoveryJobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> GetRecoveryJobTarget(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>> GetRecoveryJobTargetAsync(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetCollection GetRecoveryJobTargets() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult> Resume(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>> ResumeAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult> Retry(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>> RetryAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryJobTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>, System.Collections.IEnumerable
    {
        protected RecoveryJobTargetCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> Get(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>> GetAsync(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> GetIfExists(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>> GetIfExistsAsync(string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryJobTargetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>
    {
        internal RecoveryJobTargetData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryJobTargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryJobTargetResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string recoveryPlanName, string recoveryJobName, string recoveryJobResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>, System.Collections.IEnumerable
    {
        protected RecoveryPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string recoveryPlanName, Azure.ResourceManager.ResilienceManagement.RecoveryPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string recoveryPlanName, Azure.ResourceManager.ResilienceManagement.RecoveryPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> Get(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> GetAll(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> GetAllAsync(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>> GetAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> GetIfExists(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>> GetIfExistsAsync(string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryPlanData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>
    {
        public RecoveryPlanData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.RecoveryPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.RecoveryPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryPlanResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CheckReadiness(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CheckReadinessAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string recoveryPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult> Failover(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>> FailoverAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult> FailoverCommit(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>> FailoverCommitAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult> Finalize(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>> FinalizeAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.ResilienceMembersCollection GetAllResilienceMembers() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> GetRecoveryJob(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>> GetRecoveryJobAsync(string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobCollection GetRecoveryJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> GetResilienceMembers(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>> GetResilienceMembersAsync(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult> Reprotect(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>> ReprotectAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.RecoveryPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.RecoveryPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.RecoveryPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult> TestFailover(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>> TestFailoverAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult> TestFailoverCleanup(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>> TestFailoverCleanupAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.RecoveryPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.RecoveryPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult> UpdateResources(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>> UpdateResourcesAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult> ValidateForFailover(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>> ValidateForFailoverAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult> ValidateForFailoverCommit(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>> ValidateForFailoverCommitAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult> ValidateForOperation(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>> ValidateForOperationAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult> ValidateForReprotect(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>> ValidateForReprotectAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult> ValidateForTestFailover(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>> ValidateForTestFailoverAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult> ValidateForTestFailoverCleanup(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>> ValidateForTestFailoverCleanupAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResilienceManagementDrillCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>, System.Collections.IEnumerable
    {
        protected ResilienceManagementDrillCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string drillName, Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string drillName, Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> Get(string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> GetAll(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> GetAllAsync(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>> GetAsync(string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> GetIfExists(string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>> GetIfExistsAsync(string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResilienceManagementDrillData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>
    {
        public ResilienceManagementDrillData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResilienceManagementDrillResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResilienceManagementDrillResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddOrUpdateResources(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddOrUpdateResourcesAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string drillName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation End(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EndAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource> GetDrillRun(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource>> GetDrillRunAsync(string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunCollection GetDrillRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> GetDrillTarget(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>> GetDrillTargetAsync(string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillTargetCollection GetDrillTargets() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncReadinessCheck(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncReadinessCheckAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ValidateForExecution(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ValidateForExecutionAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResilienceManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(this Azure.ResourceManager.Resources.TenantResource tenantResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalMembersCollection GetAllGoalMembers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.ResilienceMembersCollection GetAllResilienceMembers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource> GetDrillRun(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource>> GetDrillRunAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillRunResource GetDrillRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillRunCollection GetDrillRuns(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> GetDrillRunTarget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>> GetDrillRunTargetAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource GetDrillRunTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillRunTargetCollection GetDrillRunTargets(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> GetDrillTarget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>> GetDrillTargetAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillTargetResource GetDrillTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillTargetCollection GetDrillTargets(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> GetGoalAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>> GetGoalAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource GetGoalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalAssignmentCollection GetGoalAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> GetGoalMembers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>> GetGoalMembersAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalMembersResource GetGoalMembersResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> GetGoalTemplate(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>> GetGoalTemplateAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalTemplateResource GetGoalTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalTemplateCollection GetGoalTemplates(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> GetRecoveryJob(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>> GetRecoveryJobAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryJobResource GetRecoveryJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryJobCollection GetRecoveryJobs(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> GetRecoveryJobTarget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>> GetRecoveryJobTargetAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource GetRecoveryJobTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetCollection GetRecoveryJobTargets(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> GetRecoveryPlan(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>> GetRecoveryPlanAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource GetRecoveryPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryPlanCollection GetRecoveryPlans(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> GetResilienceManagementDrill(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>> GetResilienceManagementDrillAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource GetResilienceManagementDrillResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillCollection GetResilienceManagementDrills(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> GetResilienceMembers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>> GetResilienceMembersAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource GetResilienceMembersResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> GetUnifiedResilienceItem(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>> GetUnifiedResilienceItemAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource GetUnifiedResilienceItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemCollection GetUnifiedResilienceItems(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetUsagePlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> GetUsagePlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource GetUsagePlanEnrollmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UsagePlanResource GetUsagePlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UsagePlanCollection GetUsagePlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetUsagePlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetUsagePlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResilienceMembersCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>, System.Collections.IEnumerable
    {
        protected ResilienceMembersCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> Get(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>> GetAsync(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> GetIfExists(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>> GetIfExistsAsync(string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResilienceMembersData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>
    {
        public ResilienceMembersData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.ResilienceMembersData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.ResilienceMembersData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResilienceMembersResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResilienceMembersResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.ResilienceMembersData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string recoveryPlanName, string recoveryResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.ResilienceMembersData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.ResilienceMembersData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnifiedResilienceItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>, System.Collections.IEnumerable
    {
        protected UnifiedResilienceItemCollection() { }
        public virtual Azure.Response<bool> Exists(string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> Get(string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> GetAll(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> GetAllAsync(string skipToken = null, int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>> GetAsync(string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> GetIfExists(string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>> GetIfExistsAsync(string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UnifiedResilienceItemData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>
    {
        internal UnifiedResilienceItemData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnifiedResilienceItemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UnifiedResilienceItemResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string unifiedResilienceItemName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsagePlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>, System.Collections.IEnumerable
    {
        protected UsagePlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string usagePlanName, Azure.ResourceManager.ResilienceManagement.UsagePlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string usagePlanName, Azure.ResourceManager.ResilienceManagement.UsagePlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> Get(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> GetAsync(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetIfExists(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> GetIfExistsAsync(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UsagePlanData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>
    {
        public UsagePlanData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.UsagePlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.UsagePlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsagePlanEnrollmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>, System.Collections.IEnumerable
    {
        protected UsagePlanEnrollmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enrollmentName, Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enrollmentName, Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> Get(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>> GetAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> GetIfExists(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>> GetIfExistsAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UsagePlanEnrollmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>
    {
        public UsagePlanEnrollmentData() { }
        public Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsagePlanEnrollmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UsagePlanEnrollmentResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string usagePlanName, string enrollmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UsagePlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UsagePlanResource() { }
        public virtual Azure.ResourceManager.ResilienceManagement.UsagePlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string usagePlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource> GetUsagePlanEnrollment(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource>> GetUsagePlanEnrollmentAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentCollection GetUsagePlanEnrollments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResilienceManagement.UsagePlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.UsagePlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.UsagePlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResilienceManagement.Mocking
{
    public partial class MockableResilienceManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResilienceManagementArmClient() { }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalMembersCollection GetAllGoalMembers(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.ResilienceMembersCollection GetAllResilienceMembers(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource> GetDrillRun(Azure.Core.ResourceIdentifier scope, string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunResource>> GetDrillRunAsync(Azure.Core.ResourceIdentifier scope, string drillRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunResource GetDrillRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunCollection GetDrillRuns(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource> GetDrillRunTarget(Azure.Core.ResourceIdentifier scope, string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource>> GetDrillRunTargetAsync(Azure.Core.ResourceIdentifier scope, string drillRunResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunTargetResource GetDrillRunTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillRunTargetCollection GetDrillRunTargets(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource> GetDrillTarget(Azure.Core.ResourceIdentifier scope, string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.DrillTargetResource>> GetDrillTargetAsync(Azure.Core.ResourceIdentifier scope, string drillResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillTargetResource GetDrillTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.DrillTargetCollection GetDrillTargets(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource> GetGoalAssignment(Azure.Core.ResourceIdentifier scope, string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource>> GetGoalAssignmentAsync(Azure.Core.ResourceIdentifier scope, string goalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalAssignmentResource GetGoalAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalAssignmentCollection GetGoalAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource> GetGoalMembers(Azure.Core.ResourceIdentifier scope, string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalMembersResource>> GetGoalMembersAsync(Azure.Core.ResourceIdentifier scope, string goalResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalMembersResource GetGoalMembersResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource> GetGoalTemplate(Azure.Core.ResourceIdentifier scope, string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.GoalTemplateResource>> GetGoalTemplateAsync(Azure.Core.ResourceIdentifier scope, string goalTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalTemplateResource GetGoalTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.GoalTemplateCollection GetGoalTemplates(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource> GetRecoveryJob(Azure.Core.ResourceIdentifier scope, string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobResource>> GetRecoveryJobAsync(Azure.Core.ResourceIdentifier scope, string recoveryJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobResource GetRecoveryJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobCollection GetRecoveryJobs(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource> GetRecoveryJobTarget(Azure.Core.ResourceIdentifier scope, string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource>> GetRecoveryJobTargetAsync(Azure.Core.ResourceIdentifier scope, string recoveryJobResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetResource GetRecoveryJobTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetCollection GetRecoveryJobTargets(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource> GetRecoveryPlan(Azure.Core.ResourceIdentifier scope, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource>> GetRecoveryPlanAsync(Azure.Core.ResourceIdentifier scope, string recoveryPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryPlanResource GetRecoveryPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.RecoveryPlanCollection GetRecoveryPlans(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource> GetResilienceManagementDrill(Azure.Core.ResourceIdentifier scope, string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource>> GetResilienceManagementDrillAsync(Azure.Core.ResourceIdentifier scope, string drillName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillResource GetResilienceManagementDrillResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillCollection GetResilienceManagementDrills(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource> GetResilienceMembers(Azure.Core.ResourceIdentifier scope, string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource>> GetResilienceMembersAsync(Azure.Core.ResourceIdentifier scope, string recoveryResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.ResilienceMembersResource GetResilienceMembersResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource> GetUnifiedResilienceItem(Azure.Core.ResourceIdentifier scope, string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource>> GetUnifiedResilienceItemAsync(Azure.Core.ResourceIdentifier scope, string unifiedResilienceItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemResource GetUnifiedResilienceItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemCollection GetUnifiedResilienceItems(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentResource GetUsagePlanEnrollmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.UsagePlanResource GetUsagePlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResilienceManagementResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResilienceManagementResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetUsagePlan(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResilienceManagement.UsagePlanResource>> GetUsagePlanAsync(string usagePlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResilienceManagement.UsagePlanCollection GetUsagePlans() { throw null; }
    }
    public partial class MockableResilienceManagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResilienceManagementSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetUsagePlans(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResilienceManagement.UsagePlanResource> GetUsagePlansAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResilienceManagementTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResilienceManagementTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResilienceManagement.Models
{
    public partial class AddOrUpdateResourcesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent>
    {
        public AddOrUpdateResourcesContent(int faultDurationInMin) { }
        public int FaultDurationInMin { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState? ForceInclusionAndUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList ResourceLists { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResilienceManagementModelFactory
    {
        public static Azure.ResourceManager.ResilienceManagement.Models.AddOrUpdateResourcesContent AddOrUpdateResourcesContent(int faultDurationInMin = 0, Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList resourceLists = null, Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState? forceInclusionAndUpdate = default(Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult ArmResponseErrorResponseResult(Azure.ResponseError bodyError = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill AssetPropertiesOfDrill(string subscription = null, string region = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.AttentionReason AttentionReason(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? drillRbacOnChaosResource = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), System.Collections.Generic.IEnumerable<string> rbacNeededForDrillOnChaosResource = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? drillRbacOnRecoveryPlan = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), System.Collections.Generic.IEnumerable<string> rbacNeededForDrillOnRecoveryPlan = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState? roReadiness = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? rbacOnTargetResources = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? runbookFaultRbacOnTargets = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? chaosResource = default(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState?), System.Collections.Generic.IEnumerable<string> chaosResourceCreationFailureReasons = null, Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState? recoveryPlanAndDrillResourcesState = default(Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState?), Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState? serviceGroupAndDrillResourcesState = default(Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState?), Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? drillUserMsi = default(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState?), Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? chaosResourceUserMsi = default(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState?), Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? includedResourceInDrill = default(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? drillRbacOnMonitoringResources = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail> drillMonitoringErrors = null, Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? drillMonitoringResources = default(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? monitoringRbacOnDrillResources = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), System.Collections.Generic.IEnumerable<string> rbacNeededForDrillOnDrillMonitoringResources = null, System.Collections.Generic.IEnumerable<string> rbacNeededForDrillOnDrillResources = null, System.Collections.Generic.IEnumerable<string> missingRequiredResourceProviders = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill ChaosResourcePropertiesOfDrill(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity identity = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity chaosResourceIdentityForFaults = null, Azure.Core.ResourceIdentifier chaosResourceId = null, int? faultDurationInMin = default(int?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails CustomFaultDetails(string faultName = null, Azure.Core.ResourceIdentifier scriptResourceId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails DiskReprotectInputDetails(Azure.Core.ResourceIdentifier diskResourceId = null, Azure.Core.ResourceIdentifier stagingStorageAccountResourceId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent DrillEndContent(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation attestation = default(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation), string attestationNotes = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillProperties DrillProperties(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.Core.ResourceIdentifier serviceGroupId = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill recoveryPlanProperties = null, Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill drillAssetProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill chaosResourceProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ExecutionState? executionState = default(Azure.ResourceManager.ResilienceManagement.Models.ExecutionState?), Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState? executionReadinessState = default(Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode? rbacSetupMode = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode?), Azure.ResourceManager.ResilienceManagement.Models.AttentionReason attentionReason = null, Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata systemMetadata = null, Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties lastRunProperties = null, System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastResyncReadinessCheckOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget> managedOnBehalfOfMoboBrokerResources = null, string drillType = null, Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill monitoringProperties = null, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason DrillResourceAttentionReason(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? faultRbacOnTargetResource = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? runbookFaultRbacOnTargets = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? monitoringRbacOnTargets = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState> resourceState = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties DrillResourceProperties(Azure.Core.ResourceIdentifier resourceId = null, string resourceType = null, System.Collections.Generic.IEnumerable<string> activeLocations = null, System.Collections.Generic.IEnumerable<string> recoveryLocations = null, System.Collections.Generic.IEnumerable<string> activePhysicalZones = null, System.Collections.Generic.IEnumerable<string> recoveryPhysicalZones = null, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState? inclusionState = default(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState?), Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState? recoveryPlanInclusionState = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState?), Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason? recoveryPlanExclusionReason = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason?), Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? resourceProtectionSolutionType = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType?), Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState? readinessState = default(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState?), Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState? faultState = default(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState?), Azure.ResourceManager.ResilienceManagement.Models.FaultProperties faultProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState? forceInclusionState = default(Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState?), Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus? haStatus = default(Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus?), Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason attentionReason = null, string advisorRecommendationTypeId = null, Azure.Core.ResourceIdentifier advisorHaRecommendationId = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail rbacAssignmentError = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail monitoringRbacAssignmentError = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList DrillResourcesList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent> includeResources = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> excludeResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent> updateResources = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent DrillRunAddNotesContent(string notes = null, System.DateTimeOffset? recordedOn = default(System.DateTimeOffset?), string author = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillRunData DrillRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent DrillRunFailoverContent(Azure.ResourceManager.ResilienceManagement.Models.AutoFailover autoFailover = default(Azure.ResourceManager.ResilienceManagement.Models.AutoFailover), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent failoverProperties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties DrillRunProperties(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, Azure.Core.ResourceIdentifier resourceId = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> retryDetails = null, Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo jobExtendedInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null, Azure.ResourceManager.ResilienceManagement.Models.UserConsent? executionConfigurationsUserConsent = default(Azure.ResourceManager.ResilienceManagement.Models.UserConsent?), Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy? triggeredBy = default(Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy?), Azure.Core.ResourceIdentifier drillId = null, Azure.ResourceManager.ResilienceManagement.Models.DrillMode? drillMode = default(Azure.ResourceManager.ResilienceManagement.Models.DrillMode?), Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation? attestation = default(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation?), System.Collections.Generic.IEnumerable<string> notes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage> supportedVerbsForStage = null, string currentActiveOperationId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties DrillRunResourceProperties(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, Azure.Core.ResourceIdentifier resourceId = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> retryDetails = null, Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo jobExtendedInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null, string jobId = null, string taskId = null, string taskName = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillRunTargetData DrillRunTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent DrillStartContent(Azure.ResourceManager.ResilienceManagement.Models.DrillMode mode = default(Azure.ResourceManager.ResilienceManagement.Models.DrillMode)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata DrillSystemMetadata(Azure.ResourceManager.ResilienceManagement.Models.InitialConfig initialConfig = default(Azure.ResourceManager.ResilienceManagement.Models.InitialConfig), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories> resourceTypeCategories = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.DrillTargetData DrillTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties DrillUpdateProperties(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill recoveryPlanProperties = null, Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill drillAssetProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill chaosResourceProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode? rbacSetupMode = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode?), Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill monitoringProperties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties EnrollmentProperties(Azure.Core.ResourceIdentifier serviceGroupId = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties FailoverRequestProperties(System.Collections.Generic.IEnumerable<string> sourceLocations = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> selectedResourceIds = null, Azure.ResourceManager.ResilienceManagement.Models.UserConsent? executionConfigurationsUserConsent = default(Azure.ResourceManager.ResilienceManagement.Models.UserConsent?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.FaultDetails FaultDetails(string faultUrn = null, string faultName = null, Azure.Core.ResourceIdentifier targetResourceId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.FaultProperties FaultProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails> availableFaults = null, Azure.ResourceManager.ResilienceManagement.Models.FaultDetails defaultFault = null, Azure.ResourceManager.ResilienceManagement.Models.FaultDetails overriddenDefaultFault = null, Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails customFault = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalAssignmentData GoalAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties GoalAssignmentProperties(Azure.Core.ResourceIdentifier goalTemplateId = null, Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType goalAssignmentType = default(Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget> serviceLevelResources = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalMembersData GoalMembersData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties GoalResourceProperties(Azure.Core.ResourceIdentifier resourceArmId = null, Azure.ResourceManager.ResilienceManagement.Models.ExclusionState highAvailabilityGoalParticipation = default(Azure.ResourceManager.ResilienceManagement.Models.ExclusionState), Azure.ResourceManager.ResilienceManagement.Models.AttestationState highAvailabilityAttestationStatus = default(Azure.ResourceManager.ResilienceManagement.Models.AttestationState), Azure.ResourceManager.ResilienceManagement.Models.ExclusionState? disasterRecoveryGoalParticipation = default(Azure.ResourceManager.ResilienceManagement.Models.ExclusionState?), Azure.ResourceManager.ResilienceManagement.Models.AttestationState? disasterRecoveryAttestationStatus = default(Azure.ResourceManager.ResilienceManagement.Models.AttestationState?), Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason? exclusionReasonForHighAvailabilityGoals = default(Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason?), Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason? exclusionReasonForDisasterRecoveryGoals = default(Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem> userConfirmationForHighAvailability = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership> serviceGroupMemberships = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.GoalTemplateData GoalTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties GoalTemplateProperties(Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected? requireHighAvailability = default(Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected?), Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected? requireDisasterRecovery = default(Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected?), string regionalRecoveryPointObjective = null, string regionalRecoveryTimeObjective = null, Azure.ResourceManager.ResilienceManagement.Models.GoalType goalType = default(Azure.ResourceManager.ResilienceManagement.Models.GoalType), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent IncludeOrUpdateContent(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.ResilienceManagement.Models.FaultProperties faultProperties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo JobErrorInfo(string errorCode = null, string errorMessage = null, System.Collections.Generic.IEnumerable<string> recommendations = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo JobExtendedInfo(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail> tasksList = null, string dynamicErrorMessage = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobProperties JobProperties(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, Azure.Core.ResourceIdentifier resourceId = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> retryDetails = null, Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo jobExtendedInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null, string jobType = null, Azure.ResourceManager.ResilienceManagement.Models.UserConsent? executionConfigurationsUserConsent = default(Azure.ResourceManager.ResilienceManagement.Models.UserConsent?), Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy? triggeredBy = default(Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties JobResourceProperties(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, Azure.Core.ResourceIdentifier resourceId = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> retryDetails = null, Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo jobExtendedInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null, string jobId = null, string taskId = null, string taskName = null, string jobResourceType = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails JobRetryDetails(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, int retryAttempt = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail JobTaskDetail(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, string taskId = null, string taskName = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> linkedJobIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail> subTasksList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> retryDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobUserComment JobUserComment(Azure.ResourceManager.ResilienceManagement.Models.CommentType? commentType = default(Azure.ResourceManager.ResilienceManagement.Models.CommentType?), System.DateTimeOffset? commentOn = default(System.DateTimeOffset?), string comments = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties LastRunProperties(System.DateTimeOffset? lastRunOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResilienceManagement.Models.JobStatus? lastRunState = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.TimeSpan? lastRunDuration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation? lastRunAttestation = default(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget ManagedBrokerTarget(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent MarkAsCompleteContent(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks drillRunStage = default(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill MonitoringPropertiesOfDrill(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity identity = null, Azure.Core.ResourceIdentifier logAnalyticsWorkspaceId = null, Azure.Core.ResourceIdentifier rawMetricsDataCollectionRuleId = null, Azure.Core.ResourceIdentifier serviceGroupMetricsDataCollectionRuleId = null, Azure.Core.ResourceIdentifier dataCollectionEndpointId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails OperationQualificationDetails(Azure.ResourceManager.ResilienceManagement.Models.QualificationState qualificationState = default(Azure.ResourceManager.ResilienceManagement.Models.QualificationState), System.Collections.Generic.IEnumerable<string> notQualifiedReasons = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo RecommendationsHighAvailabilityInfo(long? enabledResourceCount = default(long?), long? notEnabledResourceCount = default(long?), long? notEvaluatedResourceCount = default(long?), System.DateTimeOffset? evaluationOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent RecommendCapacityContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent RecoveryActionContent(string description = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup RecoveryGroup(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings RecoveryGroupActionSettings(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask? actionTask = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask?), int? actionSequence = default(int?), Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType? recoveryGroupActionType = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType?), string actionName = null, string actionDescription = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction RecoveryGroupBaseAction(string name = null, string description = null, string type = null, int timeoutInMinutes = 0) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction RecoveryGroupCustomRunbookAction(string name = null, string description = null, int timeoutInMinutes = 0, Azure.Core.ResourceIdentifier actionResourceId = null, System.Collections.Generic.IDictionary<string, string> parameters = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity associatedIdentity = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction RecoveryGroupManualAction(string name = null, string description = null, int timeoutInMinutes = 0) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties RecoveryGroupProperties(string groupUniqueId = null, int orderId = 0, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction> preActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction> postActions = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting RecoveryGroupsSetting(Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup defaultGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup> additionalGroups = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryJobData RecoveryJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties RecoveryJobProperties(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, Azure.Core.ResourceIdentifier resourceId = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> retryDetails = null, Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo jobExtendedInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null, Azure.ResourceManager.ResilienceManagement.Models.UserConsent? executionConfigurationsUserConsent = default(Azure.ResourceManager.ResilienceManagement.Models.UserConsent?), Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy? triggeredBy = default(Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties RecoveryJobResourceProperties(Azure.ResourceManager.ResilienceManagement.Models.JobStatus? status = default(Azure.ResourceManager.ResilienceManagement.Models.JobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo errorDetails = null, Azure.Core.ResourceIdentifier resourceId = null, string operation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> retryDetails = null, Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo jobExtendedInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> userComments = null, string jobId = null, string taskId = null, string taskName = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? protectionSolutionType = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType?), Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings recoveryGroupActionSettings = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryJobTargetData RecoveryJobTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult RecoveryPlanActionBaseResult(string jobId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.RecoveryPlanData RecoveryPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus RecoveryPlanFailoverOperationStatus(System.DateTimeOffset? lastExecutedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus? operationStatus = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus?), Azure.ResponseError errorDetails = null, System.TimeSpan? recoveryTimeActual = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus RecoveryPlanOperationStatus(System.DateTimeOffset? lastExecutedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus? operationStatus = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties RecoveryPlanProperties(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType planType = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType), Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState? planState = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState?), string planDescription = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting recoveryGroupsSetting = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus latestFailoverStatus = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus latestValidationStatus = null, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill RecoveryPlanPropertiesOfDrill(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity identity = null, Azure.Core.ResourceIdentifier recoveryPlanId = null, int? recoveryPlanResourceExcludedCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties RecoveryResourceProperties(string recoveryResourceUniqueId = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> resourcePhysicalZones = null, Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState? inclusionState = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState?), bool? requiresAttention = default(bool?), System.Collections.Generic.IEnumerable<string> attentionReasons = null, Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus? protectionStatus = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings> resourceProtectionSolutions = null, Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? selectedProtectionSolutionType = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType?), Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting selectedProtectionSolutionSetting = null, string recoveryGroupId = null, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity associatedIdentity = null, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification RecoveryResourceQualification(Azure.ResourceManager.ResilienceManagement.ResilienceMembersData recoveryResource = null, Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails operationQualificationDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties RegionalDrillProperties(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.Core.ResourceIdentifier serviceGroupId = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill recoveryPlanProperties = null, Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill drillAssetProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill chaosResourceProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ExecutionState? executionState = default(Azure.ResourceManager.ResilienceManagement.Models.ExecutionState?), Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState? executionReadinessState = default(Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode? rbacSetupMode = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode?), Azure.ResourceManager.ResilienceManagement.Models.AttentionReason attentionReason = null, Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata systemMetadata = null, Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties lastRunProperties = null, System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastResyncReadinessCheckOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget> managedOnBehalfOfMoboBrokerResources = null, Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill monitoringProperties = null, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent ReprotectContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> reprotectRequestSelectedResourceIds = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity ResilienceManagementAssociatedIdentity(Azure.ResourceManager.Models.ManagedServiceIdentityType type = default(Azure.ResourceManager.Models.ManagedServiceIdentityType), Azure.Core.ResourceIdentifier userAssignedIdentity = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.ResilienceManagementDrillData ResilienceManagementDrillData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.DrillProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch ResilienceManagementDrillPatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail ResilienceManagementErrorDetail(string code = null, string message = null, System.Collections.Generic.IEnumerable<string> recommendations = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent ResilienceManagementFailoverContent(Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes failoverDirection = default(Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes), Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties failoverRequestProperties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo ResilienceManagementGoalsInfo(Azure.Core.ResourceIdentifier templateId = null, Azure.Core.ResourceIdentifier assignmentId = null, Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? regionalRecoveryPointObjectiveInMinutes = default(Azure.ResourceManager.ResilienceManagement.Models.IsoDuration?), Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? regionalRecoveryPointEstimatedInMinutes = default(Azure.ResourceManager.ResilienceManagement.Models.IsoDuration?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus regionalRecoveryPointObjectiveStatus = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus), Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? regionalRecoveryTimeObjectiveInMinutes = default(Azure.ResourceManager.ResilienceManagement.Models.IsoDuration?), Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? regionalRecoveryTimeActualInMinutes = default(Azure.ResourceManager.ResilienceManagement.Models.IsoDuration?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus regionalRecoveryTimeObjectiveStatus = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus), Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected? requireHighAvailability = default(Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected?), Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected? requireDisasterRecovery = default(Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.ResilienceMembersData ResilienceMembersData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting ResourceBaseProtectionSolutionSetting(string protectionSolutionType = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting ResourceCustomProtectionSetting(Azure.Core.ResourceIdentifier failoverActionResourceId = null, Azure.Core.ResourceIdentifier failoverCommitActionResourceId = null, Azure.Core.ResourceIdentifier testFailoverActionResourceId = null, Azure.Core.ResourceIdentifier testFailoverCleanupActionResourceId = null, Azure.Core.ResourceIdentifier reprotectActionResourceId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting ResourceNativeProtectionSolutionSetting() { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings ResourceProtectionSolutionSettings(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? protectionSolutionType = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType?), Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus? protectionStatus = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus?), Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.AzureLocation? activeLocation = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> activeLocations = null, System.Collections.Generic.IEnumerable<string> activePhysicalZones = null, System.Collections.Generic.IEnumerable<string> recoveryLocations = null, Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole? replicationRole = default(Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole?), Azure.Core.ResourceIdentifier primaryResource = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> replicaResources = null, bool isAutoFailover = false, Azure.ResourceManager.ResilienceManagement.Models.FailoverState? failoverState = default(Azure.ResourceManager.ResilienceManagement.Models.FailoverState?), Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState? testFailoverState = default(Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting ResourceSiteRecoveryProtectionSetting(Azure.Core.ResourceIdentifier testFailoverParamsNetworkResourceId = null, string testFailoverCleanupParamsComments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails> diskReprotectInputDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership ServiceGroupMembership(Azure.Core.ResourceIdentifier serviceGroupId = null, Azure.ResourceManager.ResilienceManagement.Models.MembershipType membershipType = default(Azure.ResourceManager.ResilienceManagement.Models.MembershipType)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget ServiceLevelTarget(Azure.Core.ResourceIdentifier serviceLevelIndicatorResourceId = null, Azure.Core.ResourceIdentifier serviceLevelObjectiveResourceId = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage SupportedVerbsForStage(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks drillRunStage = default(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs> supportedVerbs = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent TestFailoverCleanupContent(string comments = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UnifiedResilienceItemData UnifiedResilienceItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties UnifiedResilienceItemProperties(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo goals = null, Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo recommendationsHighAvailability = null, System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent UpdateGoalResourceContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalMembersData> resources = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent UpdateRecoveryResourcesContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData> resourcesToUpdate = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourcesToRemove = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult UpdateRecoveryResourcesResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData> failedResources = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UsagePlanData UsagePlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.UsagePlanEnrollmentData UsagePlanEnrollmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch UsagePlanPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties UsagePlanProperties(Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType? planType = default(Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem UserConfirmationForHighAvailabilityItem(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName solutionDisplayName = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName), Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus confirmationStatus = default(Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus), Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation? reasonForRequestingConfirmation = default(Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation?)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent ValidateForExecutionContent(System.Collections.Generic.IEnumerable<string> validateForExecutionSourceLocations = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent ValidateForOperationContent(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames operationName = default(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames)) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult ValidateForRecoveryOperationBaseResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification> recoveryResourceQualifications = null) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties ZonalDrillProperties(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? provisioningState = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState?), Azure.Core.ResourceIdentifier serviceGroupId = null, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill recoveryPlanProperties = null, Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill drillAssetProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill chaosResourceProperties = null, Azure.ResourceManager.ResilienceManagement.Models.ExecutionState? executionState = default(Azure.ResourceManager.ResilienceManagement.Models.ExecutionState?), Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState? executionReadinessState = default(Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState?), Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode? rbacSetupMode = default(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode?), Azure.ResourceManager.ResilienceManagement.Models.AttentionReason attentionReason = null, Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata systemMetadata = null, Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties lastRunProperties = null, System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastResyncReadinessCheckOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget> managedOnBehalfOfMoboBrokerResources = null, Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill monitoringProperties = null, Azure.ResponseError errorDetails = null, Azure.ResourceManager.ResilienceManagement.Models.VmPresent? vmsPresent = default(Azure.ResourceManager.ResilienceManagement.Models.VmPresent?)) { throw null; }
    }
    public partial class ArmResponseErrorResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>
    {
        internal ArmResponseErrorResponseResult() { }
        public Azure.ResponseError BodyError { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetPropertiesOfDrill : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill>
    {
        public AssetPropertiesOfDrill(string subscription, string region) { }
        public string Region { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string Subscription { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttentionReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AttentionReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AttentionReason>
    {
        internal AttentionReason() { }
        public Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? ChaosResource { get { throw null; } }
        public System.Collections.Generic.IList<string> ChaosResourceCreationFailureReasons { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? ChaosResourceUserMsi { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail> DrillMonitoringErrors { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? DrillMonitoringResources { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? DrillRbacOnChaosResource { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? DrillRbacOnMonitoringResources { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? DrillRbacOnRecoveryPlan { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? DrillUserMsi { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? IncludedResourceInDrill { get { throw null; } }
        public System.Collections.Generic.IList<string> MissingRequiredResourceProviders { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? MonitoringRbacOnDrillResources { get { throw null; } }
        public System.Collections.Generic.IList<string> RbacNeededForDrillOnChaosResource { get { throw null; } }
        public System.Collections.Generic.IList<string> RbacNeededForDrillOnDrillMonitoringResources { get { throw null; } }
        public System.Collections.Generic.IList<string> RbacNeededForDrillOnDrillResources { get { throw null; } }
        public System.Collections.Generic.IList<string> RbacNeededForDrillOnRecoveryPlan { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? RbacOnTargetResources { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState? RecoveryPlanAndDrillResourcesState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState? RoReadiness { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? RunbookFaultRbacOnTargets { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState? ServiceGroupAndDrillResourcesState { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.AttentionReason JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.AttentionReason PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.AttentionReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AttentionReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.AttentionReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.AttentionReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AttentionReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AttentionReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.AttentionReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestationState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.AttestationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestationState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.AttestationState ManuallyAttested { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.AttestationState NotAttested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.AttestationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.AttestationState left, Azure.ResourceManager.ResilienceManagement.Models.AttestationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.AttestationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.AttestationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.AttestationState left, Azure.ResourceManager.ResilienceManagement.Models.AttestationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoFailover : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.AutoFailover>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoFailover(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.AutoFailover Disable { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.AutoFailover Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.AutoFailover other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.AutoFailover left, Azure.ResourceManager.ResilienceManagement.Models.AutoFailover right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.AutoFailover (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.AutoFailover? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.AutoFailover left, Azure.ResourceManager.ResilienceManagement.Models.AutoFailover right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChaosResourcePropertiesOfDrill : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill>
    {
        public ChaosResourcePropertiesOfDrill(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity identity, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity chaosResourceIdentityForFaults) { }
        public Azure.Core.ResourceIdentifier ChaosResourceId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity ChaosResourceIdentityForFaults { get { throw null; } set { } }
        public int? FaultDurationInMin { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity Identity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommentType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.CommentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommentType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.CommentType Description { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.CommentType ResumeReason { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.CommentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.CommentType left, Azure.ResourceManager.ResilienceManagement.Models.CommentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.CommentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.CommentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.CommentType left, Azure.ResourceManager.ResilienceManagement.Models.CommentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfirmationStatus : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfirmationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus ApprovalNotNeeded { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus ApprovalPending { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus ApprovedByUser { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus RejectedByUser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus left, Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus left, Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomFaultDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails>
    {
        public CustomFaultDetails(string faultName, Azure.Core.ResourceIdentifier scriptResourceId) { }
        public string FaultName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ScriptResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskReprotectInputDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails>
    {
        public DiskReprotectInputDetails() { }
        public Azure.Core.ResourceIdentifier DiskResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StagingStorageAccountResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillAttestation : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillAttestation(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation AttestedFailed { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation AttestedSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation left, Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation left, Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DrillEndContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent>
    {
        public DrillEndContent(Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation attestation, string attestationNotes) { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation Attestation { get { throw null; } }
        public string AttestationNotes { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillEndContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillMode : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillMode(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillMode Failover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillMode left, Azure.ResourceManager.ResilienceManagement.Models.DrillMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillMode left, Azure.ResourceManager.ResilienceManagement.Models.DrillMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DrillProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillProperties>
    {
        internal DrillProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.AttentionReason AttentionReason { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill ChaosResourceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill DrillAssetProperties { get { throw null; } set { } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState? ExecutionReadinessState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExecutionState? ExecutionState { get { throw null; } }
        public System.DateTimeOffset? LastResyncReadinessCheckOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties LastRunProperties { get { throw null; } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill MonitoringProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode? RbacSetupMode { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill RecoveryPlanProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceGroupId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata SystemMetadata { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillResourceAttentionReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason>
    {
        internal DrillResourceAttentionReason() { }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? FaultRbacOnTargetResource { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? MonitoringRbacOnTargets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState> ResourceState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? RunbookFaultRbacOnTargets { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillResourceFaultState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillResourceFaultState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState CustomScript { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState NotDefined { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState SystemNative { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillResourceInclusionState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillResourceInclusionState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState Excluded { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState Included { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DrillResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties>
    {
        internal DrillResourceProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> ActiveLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ActivePhysicalZones { get { throw null; } }
        public Azure.Core.ResourceIdentifier AdvisorHaRecommendationId { get { throw null; } }
        public string AdvisorRecommendationTypeId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillResourceAttentionReason AttentionReason { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.FaultProperties FaultProperties { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillResourceFaultState? FaultState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState? ForceInclusionState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus? HaStatus { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillResourceInclusionState? InclusionState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail MonitoringRbacAssignmentError { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail RbacAssignmentError { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState? ReadinessState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecoveryLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecoveryPhysicalZones { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason? RecoveryPlanExclusionReason { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState? RecoveryPlanInclusionState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? ResourceProtectionSolutionType { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillResourceReadinessState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillResourceReadinessState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceReadinessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DrillResourcesList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList>
    {
        public DrillResourcesList() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ExcludeResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent> IncludeResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent> UpdateResources { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillResourcesList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillResourceState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillResourceState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState InDrillNotInRecoveryPlan { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState InDrillNotInServiceGroup { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState InRecoveryPlanNotInDrill { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState InServiceGroupNotInDrill { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState ResourceStateIncompatibleWithFault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState left, Azure.ResourceManager.ResilienceManagement.Models.DrillResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DrillRunAddNotesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent>
    {
        public DrillRunAddNotesContent() { }
        public string Author { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public System.DateTimeOffset? RecordedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunAddNotesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillRunFailoverContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent>
    {
        public DrillRunFailoverContent(Azure.ResourceManager.ResilienceManagement.Models.AutoFailover autoFailover, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent failoverProperties) { }
        public Azure.ResourceManager.ResilienceManagement.Models.AutoFailover AutoFailover { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent FailoverProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunFailoverContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillRunOperationVerbs : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillRunOperationVerbs(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs Cancel { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs MarkAsComplete { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs Retry { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs Start { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs left, Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs left, Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DrillRunProperties : Azure.ResourceManager.ResilienceManagement.Models.JobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties>
    {
        internal DrillRunProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation? Attestation { get { throw null; } }
        public string CurrentActiveOperationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DrillId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillMode? DrillMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Notes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage> SupportedVerbsForStage { get { throw null; } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillRunResourceProperties : Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties>
    {
        internal DrillRunResourceProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillRunResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrillRunSubtasks : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrillRunSubtasks(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks Failover { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks FailoverReverse { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks FaultInjection { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks Reprotect { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks ReprotectReverse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks left, Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks left, Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DrillStartContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent>
    {
        public DrillStartContent(Azure.ResourceManager.ResilienceManagement.Models.DrillMode mode) { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillMode Mode { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillStartContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillSystemMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata>
    {
        internal DrillSystemMetadata() { }
        public Azure.ResourceManager.ResilienceManagement.Models.InitialConfig InitialConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories> ResourceTypeCategories { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillSystemMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DrillUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties>
    {
        public DrillUpdateProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.ChaosResourcePropertiesOfDrill ChaosResourceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.AssetPropertiesOfDrill DrillAssetProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill MonitoringProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode? RbacSetupMode { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill RecoveryPlanProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnrollmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties>
    {
        public EnrollmentProperties(Azure.Core.ResourceIdentifier serviceGroupId) { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceGroupId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.EnrollmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExclusionReason : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExclusionReason(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason FailedOverResource { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason UnsupportedResource { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason UserSelectedExclusion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason left, Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason left, Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExclusionState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ExclusionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExclusionState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExclusionState Excluded { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExclusionState Included { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ExclusionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ExclusionState left, Azure.ResourceManager.ResilienceManagement.Models.ExclusionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExclusionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExclusionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ExclusionState left, Azure.ResourceManager.ResilienceManagement.Models.ExclusionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionReadinessState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionReadinessState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState left, Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState left, Azure.ResourceManager.ResilienceManagement.Models.ExecutionReadinessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ExecutionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExecutionState NotRunning { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExecutionState Paused { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExecutionState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ExecutionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ExecutionState left, Azure.ResourceManager.ResilienceManagement.Models.ExecutionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExecutionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExecutionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ExecutionState left, Azure.ResourceManager.ResilienceManagement.Models.ExecutionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionObjectState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionObjectState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState Exists { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState NotExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState left, Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState left, Azure.ResourceManager.ResilienceManagement.Models.ExtensionObjectState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverDirectionTypes : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverDirectionTypes(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes FromSpecificLocations { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes left, Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes left, Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FailoverRequestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties>
    {
        public FailoverRequestProperties(System.Collections.Generic.IEnumerable<string> sourceLocations) { }
        public Azure.ResourceManager.ResilienceManagement.Models.UserConsent? ExecutionConfigurationsUserConsent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SelectedResourceIds { get { throw null; } }
        public System.Collections.Generic.IList<string> SourceLocations { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailoverState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.FailoverState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailoverState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.FailoverState FailedOver { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.FailoverState FailedOverCommitPending { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.FailoverState FailedOverReprotectPending { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.FailoverState None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.FailoverState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.FailoverState left, Azure.ResourceManager.ResilienceManagement.Models.FailoverState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.FailoverState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.FailoverState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.FailoverState left, Azure.ResourceManager.ResilienceManagement.Models.FailoverState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FaultDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails>
    {
        public FaultDetails(string faultUrn, string faultName, Azure.Core.ResourceIdentifier targetResourceId) { }
        public string FaultName { get { throw null; } set { } }
        public string FaultUrn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.FaultDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.FaultDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.FaultDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.FaultDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultProperties>
    {
        public FaultProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.FaultDetails> AvailableFaults { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.CustomFaultDetails CustomFault { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.FaultDetails DefaultFault { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.FaultDetails OverriddenDefaultFault { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.FaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.FaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.FaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.FaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.FaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.FaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForceInclusionState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForceInclusionState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState Disable { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState left, Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState left, Azure.ResourceManager.ResilienceManagement.Models.ForceInclusionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoalAssignmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties>
    {
        public GoalAssignmentProperties(Azure.Core.ResourceIdentifier goalTemplateId, Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType goalAssignmentType) { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType GoalAssignmentType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GoalTemplateId { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget> ServiceLevelResources { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoalAssignmentType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType Resiliency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType left, Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType left, Azure.ResourceManager.ResilienceManagement.Models.GoalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GoalResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties>
    {
        public GoalResourceProperties(Azure.Core.ResourceIdentifier resourceArmId, Azure.ResourceManager.ResilienceManagement.Models.ExclusionState highAvailabilityGoalParticipation, Azure.ResourceManager.ResilienceManagement.Models.AttestationState highAvailabilityAttestationStatus) { }
        public Azure.ResourceManager.ResilienceManagement.Models.AttestationState? DisasterRecoveryAttestationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExclusionState? DisasterRecoveryGoalParticipation { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason? ExclusionReasonForDisasterRecoveryGoals { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExclusionReason? ExclusionReasonForHighAvailabilityGoals { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.AttestationState HighAvailabilityAttestationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ExclusionState HighAvailabilityGoalParticipation { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceArmId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership> ServiceGroupMemberships { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem> UserConfirmationForHighAvailability { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GoalTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties>
    {
        public GoalTemplateProperties(Azure.ResourceManager.ResilienceManagement.Models.GoalType goalType) { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.GoalType GoalType { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public string RegionalRecoveryPointObjective { get { throw null; } set { } }
        public string RegionalRecoveryTimeObjective { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected? RequireDisasterRecovery { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected? RequireHighAvailability { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.GoalTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GoalType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.GoalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GoalType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.GoalType Resiliency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.GoalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.GoalType left, Azure.ResourceManager.ResilienceManagement.Models.GoalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.GoalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.GoalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.GoalType left, Azure.ResourceManager.ResilienceManagement.Models.GoalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HighAvailabilityStatus : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HighAvailabilityStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus NotEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus left, Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus left, Azure.ResourceManager.ResilienceManagement.Models.HighAvailabilityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncludeOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent>
    {
        public IncludeOrUpdateContent(Azure.Core.ResourceIdentifier id) { }
        public Azure.ResourceManager.ResilienceManagement.Models.FaultProperties FaultProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.IncludeOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InitialConfig : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.InitialConfig>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InitialConfig(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.InitialConfig Complete { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.InitialConfig Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.InitialConfig other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.InitialConfig left, Azure.ResourceManager.ResilienceManagement.Models.InitialConfig right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.InitialConfig (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.InitialConfig? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.InitialConfig left, Azure.ResourceManager.ResilienceManagement.Models.InitialConfig right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsoDuration : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.IsoDuration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsoDuration(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.IsoDuration PT15M { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.IsoDuration PT1H { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.IsoDuration PT24H { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.IsoDuration PT4H { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.IsoDuration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.IsoDuration left, Azure.ResourceManager.ResilienceManagement.Models.IsoDuration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.IsoDuration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.IsoDuration left, Azure.ResourceManager.ResilienceManagement.Models.IsoDuration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo>
    {
        internal JobErrorInfo() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo>
    {
        internal JobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail> TasksList { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class JobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobProperties>
    {
        internal JobProperties() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.UserConsent? ExecutionConfigurationsUserConsent { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo JobExtendedInfo { get { throw null; } }
        public string Operation { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> RetryDetails { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobStatus? Status { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy? TriggeredBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> UserComments { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.JobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.JobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class JobResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties>
    {
        internal JobResourceProperties() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobExtendedInfo JobExtendedInfo { get { throw null; } }
        public string JobId { get { throw null; } }
        public string Operation { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> RetryDetails { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobStatus? Status { get { throw null; } }
        public string TaskId { get { throw null; } }
        public string TaskName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> UserComments { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobRetryDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails>
    {
        internal JobRetryDetails() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo ErrorDetails { get { throw null; } }
        public int RetryAttempt { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> UserComments { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobStatus Skipped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.JobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.JobStatus left, Azure.ResourceManager.ResilienceManagement.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.JobStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.JobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.JobStatus left, Azure.ResourceManager.ResilienceManagement.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobTaskDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail>
    {
        internal JobTaskDetail() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobErrorInfo ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> LinkedJobIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.JobRetryDetails> RetryDetails { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail> SubTasksList { get { throw null; } }
        public string TaskId { get { throw null; } }
        public string TaskName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment> UserComments { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobTaskDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobTriggeredBy : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobTriggeredBy(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy System { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy left, Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy left, Azure.ResourceManager.ResilienceManagement.Models.JobTriggeredBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobUserComment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment>
    {
        internal JobUserComment() { }
        public System.DateTimeOffset? CommentOn { get { throw null; } }
        public string Comments { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.CommentType? CommentType { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobUserComment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.JobUserComment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.JobUserComment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.JobUserComment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.JobUserComment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LastRunProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties>
    {
        internal LastRunProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillAttestation? LastRunAttestation { get { throw null; } }
        public System.TimeSpan? LastRunDuration { get { throw null; } }
        public System.DateTimeOffset? LastRunOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.JobStatus? LastRunState { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.LastRunProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedBrokerTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget>
    {
        internal ManagedBrokerTarget() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ManagedBrokerTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarkAsCompleteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent>
    {
        public MarkAsCompleteContent(Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks drillRunStage) { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks DrillRunStage { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MarkAsCompleteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MembershipType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.MembershipType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MembershipType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.MembershipType Direct { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.MembershipType ThroughResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.MembershipType ThroughSubscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.MembershipType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.MembershipType left, Azure.ResourceManager.ResilienceManagement.Models.MembershipType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.MembershipType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.MembershipType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.MembershipType left, Azure.ResourceManager.ResilienceManagement.Models.MembershipType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoringPropertiesOfDrill : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill>
    {
        public MonitoringPropertiesOfDrill() { }
        public Azure.Core.ResourceIdentifier DataCollectionEndpointId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RawMetricsDataCollectionRuleId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceGroupMetricsDataCollectionRuleId { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.MonitoringPropertiesOfDrill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationQualificationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails>
    {
        internal OperationQualificationDetails() { }
        public System.Collections.Generic.IList<string> NotQualifiedReasons { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.QualificationState QualificationState { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QualificationState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.QualificationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QualificationState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.QualificationState Excluded { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.QualificationState NotQualified { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.QualificationState Qualified { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.QualificationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.QualificationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.QualificationState left, Azure.ResourceManager.ResilienceManagement.Models.QualificationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.QualificationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.QualificationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.QualificationState left, Azure.ResourceManager.ResilienceManagement.Models.QualificationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonForRequestingConfirmation : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonForRequestingConfirmation(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation VmInMultiZoneScaleSetStatelessOnly { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation ZonePinnedZrsDataDisksConditional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation left, Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation left, Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendationsHighAvailabilityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo>
    {
        internal RecommendationsHighAvailabilityInfo() { }
        public long? EnabledResourceCount { get { throw null; } }
        public System.DateTimeOffset? EvaluationOn { get { throw null; } }
        public long? NotEnabledResourceCount { get { throw null; } }
        public long? NotEvaluatedResourceCount { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendCapacityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent>
    {
        public RecommendCapacityContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecommendCapacityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent>
    {
        public RecoveryActionContent() { }
        public string Description { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryGroup : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup>
    {
        public RecoveryGroup() { }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryGroupActionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings>
    {
        internal RecoveryGroupActionSettings() { }
        public string ActionDescription { get { throw null; } }
        public string ActionName { get { throw null; } }
        public int? ActionSequence { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask? ActionTask { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType? RecoveryGroupActionType { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryGroupActionType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryGroupActionType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType CustomRunbook { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType ManualAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RecoveryGroupBaseAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction>
    {
        internal RecoveryGroupBaseAction() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int TimeoutInMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryGroupCustomRunbookAction : Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction>
    {
        public RecoveryGroupCustomRunbookAction(string name, int timeoutInMinutes) { }
        public Azure.Core.ResourceIdentifier ActionResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity AssociatedIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupCustomRunbookAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryGroupManualAction : Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction>
    {
        public RecoveryGroupManualAction(string name, int timeoutInMinutes) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupManualAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties>
    {
        public RecoveryGroupProperties(string groupUniqueId, int orderId, string description) { }
        public string Description { get { throw null; } set { } }
        public string GroupUniqueId { get { throw null; } set { } }
        public int OrderId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction> PostActions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupBaseAction> PreActions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryGroupsSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting>
    {
        public RecoveryGroupsSetting(Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup defaultGroup) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup> AdditionalGroups { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroup DefaultGroup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryJobProperties : Azure.ResourceManager.ResilienceManagement.Models.JobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties>
    {
        internal RecoveryJobProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryJobResourceProperties : Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties>
    {
        internal RecoveryJobResourceProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? ProtectionSolutionType { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupActionSettings RecoveryGroupActionSettings { get { throw null; } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.JobResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryJobResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryOperationNames : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryOperationNames(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames Failover { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames FailoverCommit { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames Reprotect { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames TestFailover { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames TestFailoverCleanup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryOperationStatus : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus CompletedWithWarning { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus ValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus ValidationInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPlanActionBaseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>
    {
        internal RecoveryPlanActionBaseResult() { }
        public string JobId { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanActionBaseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPlanExclusionReason : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPlanExclusionReason(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason ExcludedFromRecoveryPlan { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason ProtectionStatus { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanExclusionReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPlanFailoverOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus>
    {
        internal RecoveryPlanFailoverOperationStatus() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastExecutedOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus? OperationStatus { get { throw null; } }
        public System.TimeSpan? RecoveryTimeActual { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPlanOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus>
    {
        internal RecoveryPlanOperationStatus() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastExecutedOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationStatus? OperationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties>
    {
        public RecoveryPlanProperties(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType planType, string planDescription, Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting recoveryGroupsSetting) { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanFailoverOperationStatus LatestFailoverStatus { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanOperationStatus LatestValidationStatus { get { throw null; } }
        public string PlanDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState? PlanState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType PlanType { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryGroupsSetting RecoveryGroupsSetting { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPlanPropertiesOfDrill : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill>
    {
        public RecoveryPlanPropertiesOfDrill(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity identity) { }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RecoveryPlanId { get { throw null; } }
        public int? RecoveryPlanResourceExcludedCount { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanPropertiesOfDrill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPlanState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPlanState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState Ready { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState UnderEdit { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPlanType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPlanType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType Regional { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType Zonal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType left, Azure.ResourceManager.ResilienceManagement.Models.RecoveryPlanType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties>
    {
        public RecoveryResourceProperties(string recoveryResourceUniqueId) { }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity AssociatedIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> AttentionReasons { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState? InclusionState { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus? ProtectionStatus { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public string RecoveryGroupId { get { throw null; } set { } }
        public string RecoveryResourceUniqueId { get { throw null; } set { } }
        public bool? RequiresAttention { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourcePhysicalZones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings> ResourceProtectionSolutions { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting SelectedProtectionSolutionSetting { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? SelectedProtectionSolutionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryResourceQualification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification>
    {
        internal RecoveryResourceQualification() { }
        public Azure.ResourceManager.ResilienceManagement.Models.OperationQualificationDetails OperationQualificationDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.ResilienceMembersData RecoveryResource { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionalDrillProperties : Azure.ResourceManager.ResilienceManagement.Models.DrillProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties>
    {
        public RegionalDrillProperties() { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.DrillProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.DrillProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.RegionalDrillProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelativeResourceCompositionState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelativeResourceCompositionState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState InSync { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState OutOfSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState left, Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState left, Azure.ResourceManager.ResilienceManagement.Models.RelativeResourceCompositionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReprotectContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent>
    {
        public ReprotectContent() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ReprotectRequestSelectedResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ReprotectContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequirementSelected : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequirementSelected(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected NotRequired { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected left, Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected left, Azure.ResourceManager.ResilienceManagement.Models.RequirementSelected right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResilienceHealthStatus : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResilienceHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus NotEvaluated { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResilienceManagementActionTask : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResilienceManagementActionTask(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask None { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask PostActionTask { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask PreActionTask { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementActionTask right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResilienceManagementAssociatedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity>
    {
        public ResilienceManagementAssociatedIdentity(Azure.ResourceManager.Models.ManagedServiceIdentityType type) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementAssociatedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResilienceManagementDrillPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch>
    {
        public ResilienceManagementDrillPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillUpdateProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementDrillPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResilienceManagementErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail>
    {
        internal ResilienceManagementErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResilienceManagementFailoverContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent>
    {
        public ResilienceManagementFailoverContent(Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes failoverDirection) { }
        public Azure.ResourceManager.ResilienceManagement.Models.FailoverDirectionTypes FailoverDirection { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.FailoverRequestProperties FailoverRequestProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementFailoverContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResilienceManagementGoalsInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo>
    {
        internal ResilienceManagementGoalsInfo() { }
        public Azure.Core.ResourceIdentifier AssignmentId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? RegionalRecoveryPointEstimatedInMinutes { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? RegionalRecoveryPointObjectiveInMinutes { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus RegionalRecoveryPointObjectiveStatus { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? RegionalRecoveryTimeActualInMinutes { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.IsoDuration? RegionalRecoveryTimeObjectiveInMinutes { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceHealthStatus RegionalRecoveryTimeObjectiveStatus { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected? RequireDisasterRecovery { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected? RequireHighAvailability { get { throw null; } }
        public Azure.Core.ResourceIdentifier TemplateId { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResilienceManagementProvisioningState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResilienceManagementProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResilienceManagementRbacSetupMode : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResilienceManagementRbacSetupMode(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode AutomatedBuiltinRoles { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode AutomatedCustomRole { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacSetupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResilienceManagementRbacState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResilienceManagementRbacState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState NotSet { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState Set { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementRbacState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResilienceManagementSolutionDisplayName : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResilienceManagementSolutionDisplayName(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName VmInMultiZoneVmss { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName ZonePinnedVmWithZrsDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName left, Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ResourceBaseProtectionSolutionSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting>
    {
        internal ResourceBaseProtectionSolutionSetting() { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCustomProtectionSetting : Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting>
    {
        public ResourceCustomProtectionSetting() { }
        public Azure.Core.ResourceIdentifier FailoverActionResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FailoverCommitActionResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ReprotectActionResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TestFailoverActionResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TestFailoverCleanupActionResourceId { get { throw null; } set { } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceCustomProtectionSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceInclusionState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceInclusionState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState Excluded { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState Included { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState left, Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState left, Azure.ResourceManager.ResilienceManagement.Models.ResourceInclusionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceNativeProtectionSolutionSetting : Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting>
    {
        public ResourceNativeProtectionSolutionSetting() { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceNativeProtectionSolutionSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProtectionSolutionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings>
    {
        internal ResourceProtectionSolutionSettings() { }
        public Azure.Core.AzureLocation? ActiveLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> ActiveLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ActivePhysicalZones { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.FailoverState? FailoverState { get { throw null; } }
        public bool IsAutoFailover { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrimaryResource { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? ProtectionSolutionType { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus? ProtectionStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecoveryLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ReplicaResources { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole? ReplicationRole { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState? TestFailoverState { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProtectionSolutionType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProtectionSolutionType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType AzureNative { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType AzureSiteRecovery { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType CrossZoneVMRecovery { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType CustomRunbook { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType left, Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType left, Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionSolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProtectionStatus : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProtectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus HighlyAvailable { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus NotProtected { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus Protected { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus left, Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus left, Azure.ResourceManager.ResilienceManagement.Models.ResourceProtectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceReplicationRole : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole Primary { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole Replica { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole left, Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole left, Azure.ResourceManager.ResilienceManagement.Models.ResourceReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSiteRecoveryProtectionSetting : Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting>
    {
        public ResourceSiteRecoveryProtectionSetting() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.DiskReprotectInputDetails> DiskReprotectInputDetails { get { throw null; } }
        public string TestFailoverCleanupParamsComments { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TestFailoverParamsNetworkResourceId { get { throw null; } set { } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.ResourceBaseProtectionSolutionSetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ResourceSiteRecoveryProtectionSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeCategories : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeCategories(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories AzureSiteRecoveryVMsPresent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories left, Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories left, Azure.ResourceManager.ResilienceManagement.Models.ResourceTypeCategories right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceGroupMembership : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership>
    {
        internal ServiceGroupMembership() { }
        public Azure.ResourceManager.ResilienceManagement.Models.MembershipType MembershipType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceGroupId { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceGroupMembership>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceLevelTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget>
    {
        public ServiceLevelTarget(Azure.Core.ResourceIdentifier serviceLevelIndicatorResourceId, Azure.Core.ResourceIdentifier serviceLevelObjectiveResourceId) { }
        public Azure.Core.ResourceIdentifier ServiceLevelIndicatorResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceLevelObjectiveResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ServiceLevelTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedVerbsForStage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage>
    {
        internal SupportedVerbsForStage() { }
        public Azure.ResourceManager.ResilienceManagement.Models.DrillRunSubtasks DrillRunStage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.DrillRunOperationVerbs> SupportedVerbs { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.SupportedVerbsForStage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestFailoverCleanupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent>
    {
        public TestFailoverCleanupContent() { }
        public string Comments { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverCleanupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestFailoverState : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestFailoverState(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState None { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState TestFailoverCleanupPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState left, Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState left, Azure.ResourceManager.ResilienceManagement.Models.TestFailoverState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UnifiedResilienceItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties>
    {
        internal UnifiedResilienceItemProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementGoalsInfo Goals { get { throw null; } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.RecommendationsHighAvailabilityInfo RecommendationsHighAvailability { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnifiedResilienceItemRequirementSelected : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnifiedResilienceItemRequirementSelected(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected NotRequired { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected NotSelected { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected left, Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected left, Azure.ResourceManager.ResilienceManagement.Models.UnifiedResilienceItemRequirementSelected right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateGoalResourceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent>
    {
        public UpdateGoalResourceContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResilienceManagement.GoalMembersData> resources) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.GoalMembersData> Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateGoalResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateRecoveryResourcesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent>
    {
        public UpdateRecoveryResourcesContent() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourcesToRemove { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData> ResourcesToUpdate { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateRecoveryResourcesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>
    {
        internal UpdateRecoveryResourcesResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.ResilienceMembersData> FailedResources { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UpdateRecoveryResourcesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsagePlanPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch>
    {
        public UsagePlanPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsagePlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties>
    {
        public UsagePlanProperties() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType? PlanType { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsagePlanType : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsagePlanType(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType Basic { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType left, Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType left, Azure.ResourceManager.ResilienceManagement.Models.UsagePlanType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserConfirmationForHighAvailabilityItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem>
    {
        public UserConfirmationForHighAvailabilityItem(Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName solutionDisplayName, Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus confirmationStatus) { }
        public Azure.ResourceManager.ResilienceManagement.Models.ConfirmationStatus ConfirmationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ReasonForRequestingConfirmation? ReasonForRequestingConfirmation { get { throw null; } set { } }
        public Azure.ResourceManager.ResilienceManagement.Models.ResilienceManagementSolutionDisplayName SolutionDisplayName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.UserConfirmationForHighAvailabilityItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserConsent : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.UserConsent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserConsent(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.UserConsent Allowed { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.UserConsent Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.UserConsent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.UserConsent left, Azure.ResourceManager.ResilienceManagement.Models.UserConsent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.UserConsent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.UserConsent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.UserConsent left, Azure.ResourceManager.ResilienceManagement.Models.UserConsent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateForExecutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent>
    {
        public ValidateForExecutionContent() { }
        public System.Collections.Generic.IList<string> ValidateForExecutionSourceLocations { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForExecutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateForOperationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent>
    {
        public ValidateForOperationContent(Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames operationName) { }
        public Azure.ResourceManager.ResilienceManagement.Models.RecoveryOperationNames OperationName { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForOperationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateForRecoveryOperationBaseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>
    {
        internal ValidateForRecoveryOperationBaseResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResilienceManagement.Models.RecoveryResourceQualification> RecoveryResourceQualifications { get { throw null; } }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ValidateForRecoveryOperationBaseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmPresent : System.IEquatable<Azure.ResourceManager.ResilienceManagement.Models.VmPresent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmPresent(string value) { throw null; }
        public static Azure.ResourceManager.ResilienceManagement.Models.VmPresent Absent { get { throw null; } }
        public static Azure.ResourceManager.ResilienceManagement.Models.VmPresent Present { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResilienceManagement.Models.VmPresent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResilienceManagement.Models.VmPresent left, Azure.ResourceManager.ResilienceManagement.Models.VmPresent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.VmPresent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResilienceManagement.Models.VmPresent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResilienceManagement.Models.VmPresent left, Azure.ResourceManager.ResilienceManagement.Models.VmPresent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ZonalDrillProperties : Azure.ResourceManager.ResilienceManagement.Models.DrillProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties>
    {
        public ZonalDrillProperties() { }
        public Azure.ResourceManager.ResilienceManagement.Models.VmPresent? VmsPresent { get { throw null; } }
        protected override Azure.ResourceManager.ResilienceManagement.Models.DrillProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResilienceManagement.Models.DrillProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResilienceManagement.Models.ZonalDrillProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
