namespace Azure.ResourceManager.OracleDatabase
{
    public partial class AutonomousDatabaseBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>, System.Collections.IEnumerable
    {
        protected AutonomousDatabaseBackupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string adbbackupid, Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string adbbackupid, Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> Get(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>> GetAsync(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> GetIfExists(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>> GetIfExistsAsync(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutonomousDatabaseBackupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>
    {
        public AutonomousDatabaseBackupData() { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseBackupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutonomousDatabaseBackupResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string autonomousdatabasename, string adbbackupid) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutonomousDatabaseCharacterSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>, System.Collections.IEnumerable
    {
        protected AutonomousDatabaseCharacterSetCollection() { }
        public virtual Azure.Response<bool> Exists(string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> Get(string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>> GetAsync(string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> GetIfExists(string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>> GetIfExistsAsync(string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutonomousDatabaseCharacterSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>
    {
        public AutonomousDatabaseCharacterSetData() { }
        public string AutonomousDatabaseCharacterSet { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseCharacterSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutonomousDatabaseCharacterSetResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string adbscharsetname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>, System.Collections.IEnumerable
    {
        protected AutonomousDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string autonomousdatabasename, Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string autonomousdatabasename, Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Get(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> GetAsync(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetIfExists(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> GetIfExistsAsync(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutonomousDatabaseData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>
    {
        public AutonomousDatabaseData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseNationalCharacterSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>, System.Collections.IEnumerable
    {
        protected AutonomousDatabaseNationalCharacterSetCollection() { }
        public virtual Azure.Response<bool> Exists(string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> Get(string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>> GetAsync(string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> GetIfExists(string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>> GetIfExistsAsync(string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutonomousDatabaseNationalCharacterSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>
    {
        public AutonomousDatabaseNationalCharacterSetData() { }
        public string AutonomousDatabaseNationalCharacterSet { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseNationalCharacterSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutonomousDatabaseNationalCharacterSetResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string adbsncharsetname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutonomousDatabaseResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Action(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> ActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> ChangeDisasterRecoveryConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> ChangeDisasterRecoveryConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string autonomousdatabasename) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Failover(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> FailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile> GenerateWallet(Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>> GenerateWalletAsync(Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource> GetAutonomousDatabaseBackup(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource>> GetAutonomousDatabaseBackupAsync(string adbbackupid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupCollection GetAutonomousDatabaseBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Restore(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> RestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Shrink(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> ShrinkAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Switchover(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> SwitchoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutonomousDBVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>, System.Collections.IEnumerable
    {
        protected AutonomousDBVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> Get(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>> GetAsync(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> GetIfExists(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>> GetIfExistsAsync(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutonomousDBVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>
    {
        public AutonomousDBVersionData() { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDBVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutonomousDBVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string autonomousdbversionsname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerOracleDatabaseContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerOracleDatabaseContext() { }
        public static Azure.ResourceManager.OracleDatabase.AzureResourceManagerOracleDatabaseContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CloudExadataInfrastructureCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>, System.Collections.IEnumerable
    {
        protected CloudExadataInfrastructureCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudexadatainfrastructurename, Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudexadatainfrastructurename, Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> Get(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> GetAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetIfExists(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> GetIfExistsAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudExadataInfrastructureData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>
    {
        public CloudExadataInfrastructureData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> zones) { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudExadataInfrastructureResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudExadataInfrastructureResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> AddStorageCapacity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> AddStorageCapacityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> ConfigureExascale(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> ConfigureExascaleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudexadatainfrastructurename) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> GetOracleDBServer(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>> GetOracleDBServerAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBServerCollection GetOracleDBServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudVmClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>, System.Collections.IEnumerable
    {
        protected CloudVmClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudvmclustername, Azure.ResourceManager.OracleDatabase.CloudVmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudvmclustername, Azure.ResourceManager.OracleDatabase.CloudVmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> Get(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> GetAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetIfExists(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> GetIfExistsAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudVmClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>
    {
        public CloudVmClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterDBNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>, System.Collections.IEnumerable
    {
        protected CloudVmClusterDBNodeCollection() { }
        public virtual Azure.Response<bool> Exists(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> Get(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>> GetAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> GetIfExists(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>> GetIfExistsAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudVmClusterDBNodeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>
    {
        public CloudVmClusterDBNodeData() { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterDBNodeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudVmClusterDBNodeResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> Action(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DBNodeAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>> ActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DBNodeAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername, string dbnodeocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudVmClusterResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> AddVms(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> AddVmsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource> GetCloudVmClusterDBNode(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource>> GetCloudVmClusterDBNodeAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeCollection GetCloudVmClusterDBNodes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> GetCloudVmClusterVirtualNetworkAddress(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>> GetCloudVmClusterVirtualNetworkAddressAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressCollection GetCloudVmClusterVirtualNetworkAddresses() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult> GetPrivateIPAddresses(Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult> GetPrivateIPAddressesAsync(Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> RemoveVms(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> RemoveVmsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudVmClusterVirtualNetworkAddressCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>, System.Collections.IEnumerable
    {
        protected CloudVmClusterVirtualNetworkAddressCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualnetworkaddressname, Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualnetworkaddressname, Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> Get(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>> GetAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> GetIfExists(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>> GetIfExistsAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudVmClusterVirtualNetworkAddressData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>
    {
        public CloudVmClusterVirtualNetworkAddressData() { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterVirtualNetworkAddressResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudVmClusterVirtualNetworkAddressResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername, string virtualnetworkaddressname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExadbVmClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>, System.Collections.IEnumerable
    {
        protected ExadbVmClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string exadbVmClusterName, Azure.ResourceManager.OracleDatabase.ExadbVmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string exadbVmClusterName, Azure.ResourceManager.OracleDatabase.ExadbVmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> Get(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> GetAsync(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetIfExists(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> GetIfExistsAsync(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExadbVmClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>
    {
        public ExadbVmClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExadbVmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExadbVmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExadbVmClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExadbVmClusterResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.ExadbVmClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string exadbVmClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> GetExascaleDBNode(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>> GetExascaleDBNodeAsync(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.ExascaleDBNodeCollection GetExascaleDBNodes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> RemoveVms(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> RemoveVmsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.ExadbVmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExadbVmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExadbVmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExascaleDBNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>, System.Collections.IEnumerable
    {
        protected ExascaleDBNodeCollection() { }
        public virtual Azure.Response<bool> Exists(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> Get(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>> GetAsync(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> GetIfExists(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>> GetIfExistsAsync(string exascaleDbNodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExascaleDBNodeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>
    {
        internal ExascaleDBNodeData() { }
        public Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBNodeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExascaleDBNodeResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult> Action(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DBNodeAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>> ActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DBNodeAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string exadbVmClusterName, string exascaleDbNodeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBStorageVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>, System.Collections.IEnumerable
    {
        protected ExascaleDBStorageVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string exascaleDbStorageVaultName, Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string exascaleDbStorageVaultName, Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> Get(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> GetAsync(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetIfExists(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> GetIfExistsAsync(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExascaleDBStorageVaultData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>
    {
        public ExascaleDBStorageVaultData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBStorageVaultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExascaleDBStorageVaultResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string exascaleDbStorageVaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OracleDatabaseExtensions
    {
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAutonomousDatabase(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> GetAutonomousDatabaseAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource GetAutonomousDatabaseBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> GetAutonomousDatabaseCharacterSet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>> GetAutonomousDatabaseCharacterSetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource GetAutonomousDatabaseCharacterSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetCollection GetAutonomousDatabaseCharacterSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> GetAutonomousDatabaseNationalCharacterSet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>> GetAutonomousDatabaseNationalCharacterSetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource GetAutonomousDatabaseNationalCharacterSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetCollection GetAutonomousDatabaseNationalCharacterSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource GetAutonomousDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCollection GetAutonomousDatabases(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAutonomousDatabases(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAutonomousDatabasesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> GetAutonomousDBVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>> GetAutonomousDBVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource GetAutonomousDBVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDBVersionCollection GetAutonomousDBVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructure(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> GetCloudExadataInfrastructureAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource GetCloudExadataInfrastructureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureCollection GetCloudExadataInfrastructures(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructures(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructuresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> GetCloudVmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource GetCloudVmClusterDBNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterResource GetCloudVmClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterCollection GetCloudVmClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource GetCloudVmClusterVirtualNetworkAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetExadbVmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> GetExadbVmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource GetExadbVmClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExadbVmClusterCollection GetExadbVmClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetExadbVmClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetExadbVmClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource GetExascaleDBNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetExascaleDBStorageVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> GetExascaleDBStorageVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource GetExascaleDBStorageVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultCollection GetExascaleDBStorageVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetExascaleDBStorageVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetExascaleDBStorageVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBServerResource GetOracleDBServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetOracleDBSystem(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> GetOracleDBSystemAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBSystemResource GetOracleDBSystemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBSystemCollection GetOracleDBSystems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetOracleDBSystems(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetOracleDBSystemsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetOracleDBSystemShape(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>> GetOracleDBSystemShapeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource GetOracleDBSystemShapeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeCollection GetOracleDBSystemShapes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> GetOracleDBVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>> GetOracleDBVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBVersionResource GetOracleDBVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBVersionCollection GetOracleDBVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> GetOracleDnsPrivateView(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>> GetOracleDnsPrivateViewAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource GetOracleDnsPrivateViewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewCollection GetOracleDnsPrivateViews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> GetOracleDnsPrivateZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>> GetOracleDnsPrivateZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource GetOracleDnsPrivateZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneCollection GetOracleDnsPrivateZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> GetOracleFlexComponent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>> GetOracleFlexComponentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource GetOracleFlexComponentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleFlexComponentCollection GetOracleFlexComponents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource GetOracleGIMinorVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetOracleGIVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>> GetOracleGIVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleGIVersionResource GetOracleGIVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleGIVersionCollection GetOracleGIVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetOracleNetworkAnchor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> GetOracleNetworkAnchorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource GetOracleNetworkAnchorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorCollection GetOracleNetworkAnchors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetOracleNetworkAnchors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetOracleNetworkAnchorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetOracleResourceAnchor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> GetOracleResourceAnchorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource GetOracleResourceAnchorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleResourceAnchorCollection GetOracleResourceAnchors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetOracleResourceAnchors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetOracleResourceAnchorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> GetOracleSystemVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>> GetOracleSystemVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource GetOracleSystemVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSystemVersionCollection GetOracleSystemVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class OracleDBServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>, System.Collections.IEnumerable
    {
        protected OracleDBServerCollection() { }
        public virtual Azure.Response<bool> Exists(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> Get(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>> GetAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> GetIfExists(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>> GetIfExistsAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleDBServerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>
    {
        public OracleDBServerData() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleDBServerResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudexadatainfrastructurename, string dbserverocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleDBServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBSystemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>, System.Collections.IEnumerable
    {
        protected OracleDBSystemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dbSystemName, Azure.ResourceManager.OracleDatabase.OracleDBSystemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dbSystemName, Azure.ResourceManager.OracleDatabase.OracleDBSystemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> Get(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> GetAsync(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetIfExists(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> GetIfExistsAsync(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleDBSystemData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>
    {
        public OracleDBSystemData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBSystemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleDBSystemResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBSystemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dbSystemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OracleDBSystemShapeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>, System.Collections.IEnumerable
    {
        protected OracleDBSystemShapeCollection() { }
        public virtual Azure.Response<bool> Exists(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> Get(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetAll(string zone = null, string shapeAttribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetAll(string zone, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetAllAsync(string zone = null, string shapeAttribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetAllAsync(string zone, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>> GetAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetIfExists(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>> GetIfExistsAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleDBSystemShapeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>
    {
        public OracleDBSystemShapeData() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBSystemShapeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleDBSystemShapeResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dbsystemshapename) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>, System.Collections.IEnumerable
    {
        protected OracleDBVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> Get(string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> GetAll(Azure.ResourceManager.OracleDatabase.Models.ListDBVersionBySubscriptionLocationContent options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> GetAllAsync(Azure.ResourceManager.OracleDatabase.Models.ListDBVersionBySubscriptionLocationContent options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>> GetAsync(string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> GetIfExists(string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>> GetIfExistsAsync(string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleDBVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>
    {
        internal OracleDBVersionData() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleDBVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dbversionsname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleDBVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDBVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDBVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDnsPrivateViewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>, System.Collections.IEnumerable
    {
        protected OracleDnsPrivateViewCollection() { }
        public virtual Azure.Response<bool> Exists(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> Get(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>> GetAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> GetIfExists(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>> GetIfExistsAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleDnsPrivateViewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>
    {
        public OracleDnsPrivateViewData() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDnsPrivateViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleDnsPrivateViewResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dnsprivateviewocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDnsPrivateZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>, System.Collections.IEnumerable
    {
        protected OracleDnsPrivateZoneCollection() { }
        public virtual Azure.Response<bool> Exists(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> Get(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>> GetAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> GetIfExists(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>> GetIfExistsAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleDnsPrivateZoneData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>
    {
        public OracleDnsPrivateZoneData() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDnsPrivateZoneResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleDnsPrivateZoneResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dnsprivatezonename) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleFlexComponentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>, System.Collections.IEnumerable
    {
        protected OracleFlexComponentCollection() { }
        public virtual Azure.Response<bool> Exists(string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> Get(string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> GetAll(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape? shape = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> GetAllAsync(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape? shape = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>> GetAsync(string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> GetIfExists(string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>> GetIfExistsAsync(string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleFlexComponentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>
    {
        internal OracleFlexComponentData() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleFlexComponentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleFlexComponentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleFlexComponentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleFlexComponentResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleFlexComponentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string flexComponentName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleFlexComponentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleFlexComponentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleFlexComponentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleGIMinorVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>, System.Collections.IEnumerable
    {
        protected OracleGIMinorVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> Get(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> GetAll(Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily? shapeFamily = default(Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily?), string zone = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> GetAllAsync(Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily? shapeFamily = default(Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily?), string zone = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>> GetAsync(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> GetIfExists(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>> GetIfExistsAsync(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleGIMinorVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>
    {
        internal OracleGIMinorVersionData() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleGIMinorVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleGIMinorVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string giversionname, string giMinorVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleGIVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>, System.Collections.IEnumerable
    {
        protected OracleGIVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> Get(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetAll(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape? shape = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape?), string zone = null, string shapeAttribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetAll(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape? shape, string zone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetAllAsync(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape? shape = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape?), string zone = null, string shapeAttribute = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetAllAsync(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape? shape, string zone, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>> GetAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetIfExists(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>> GetIfExistsAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleGIVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>
    {
        public OracleGIVersionData() { }
        public string OracleGIVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleGIVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleGIVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleGIVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleGIVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleGIVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string giversionname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource> GetOracleGIMinorVersion(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource>> GetOracleGIMinorVersionAsync(string giMinorVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionCollection GetOracleGIMinorVersions() { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleGIVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleGIVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleGIVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleNetworkAnchorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>, System.Collections.IEnumerable
    {
        protected OracleNetworkAnchorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkAnchorName, Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkAnchorName, Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> Get(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> GetAsync(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetIfExists(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> GetIfExistsAsync(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleNetworkAnchorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>
    {
        public OracleNetworkAnchorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleNetworkAnchorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleNetworkAnchorResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkAnchorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OracleResourceAnchorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>, System.Collections.IEnumerable
    {
        protected OracleResourceAnchorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceAnchorName, Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceAnchorName, Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> Get(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> GetAsync(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetIfExists(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> GetIfExistsAsync(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleResourceAnchorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>
    {
        public OracleResourceAnchorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleResourceAnchorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleResourceAnchorResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceAnchorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OracleSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>
    {
        public OracleSubscriptionData() { }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleSubscriptionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddAzureSubscriptions(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddAzureSubscriptionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.OracleSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.OracleSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks> GetActivationLinks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>> GetActivationLinksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails> GetCloudAccountDetails(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>> GetCloudAccountDetailsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails> GetSaasSubscriptionDetails(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>> GetSaasSubscriptionDetailsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OracleSystemVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>, System.Collections.IEnumerable
    {
        protected OracleSystemVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> Get(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>> GetAsync(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> GetIfExists(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>> GetIfExistsAsync(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OracleSystemVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>
    {
        public OracleSystemVersionData() { }
        public string OracleSystemVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleSystemVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleSystemVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleSystemVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleSystemVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSystemVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string systemversionname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.OracleSystemVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.OracleSystemVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSystemVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.OracleDatabase.Mocking
{
    public partial class MockableOracleDatabaseArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableOracleDatabaseArmClient() { }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupResource GetAutonomousDatabaseBackupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource GetAutonomousDatabaseCharacterSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource GetAutonomousDatabaseNationalCharacterSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource GetAutonomousDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource GetAutonomousDBVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource GetCloudExadataInfrastructureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeResource GetCloudVmClusterDBNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterResource GetCloudVmClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressResource GetCloudVmClusterVirtualNetworkAddressResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource GetExadbVmClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.ExascaleDBNodeResource GetExascaleDBNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource GetExascaleDBStorageVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBServerResource GetOracleDBServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBSystemResource GetOracleDBSystemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource GetOracleDBSystemShapeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBVersionResource GetOracleDBVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource GetOracleDnsPrivateViewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource GetOracleDnsPrivateZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource GetOracleFlexComponentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionResource GetOracleGIMinorVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleGIVersionResource GetOracleGIVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource GetOracleNetworkAnchorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource GetOracleResourceAnchorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource GetOracleSystemVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableOracleDatabaseResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOracleDatabaseResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAutonomousDatabase(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> GetAutonomousDatabaseAsync(string autonomousdatabasename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCollection GetAutonomousDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructure(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> GetCloudExadataInfrastructureAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureCollection GetCloudExadataInfrastructures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmCluster(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> GetCloudVmClusterAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterCollection GetCloudVmClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetExadbVmCluster(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource>> GetExadbVmClusterAsync(string exadbVmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.ExadbVmClusterCollection GetExadbVmClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetExascaleDBStorageVault(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource>> GetExascaleDBStorageVaultAsync(string exascaleDbStorageVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultCollection GetExascaleDBStorageVaults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetOracleDBSystem(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource>> GetOracleDBSystemAsync(string dbSystemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBSystemCollection GetOracleDBSystems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetOracleNetworkAnchor(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource>> GetOracleNetworkAnchorAsync(string networkAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorCollection GetOracleNetworkAnchors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetOracleResourceAnchor(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource>> GetOracleResourceAnchorAsync(string resourceAnchorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleResourceAnchorCollection GetOracleResourceAnchors() { throw null; }
    }
    public partial class MockableOracleDatabaseSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOracleDatabaseSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource> GetAutonomousDatabaseCharacterSet(Azure.Core.AzureLocation location, string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetResource>> GetAutonomousDatabaseCharacterSetAsync(Azure.Core.AzureLocation location, string adbscharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetCollection GetAutonomousDatabaseCharacterSets(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource> GetAutonomousDatabaseNationalCharacterSet(Azure.Core.AzureLocation location, string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetResource>> GetAutonomousDatabaseNationalCharacterSetAsync(Azure.Core.AzureLocation location, string adbsncharsetname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetCollection GetAutonomousDatabaseNationalCharacterSets(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAutonomousDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> GetAutonomousDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource> GetAutonomousDBVersion(Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDBVersionResource>> GetAutonomousDBVersionAsync(Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDBVersionCollection GetAutonomousDBVersions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructuresAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetExadbVmClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.ExadbVmClusterResource> GetExadbVmClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetExascaleDBStorageVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultResource> GetExascaleDBStorageVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetOracleDBSystems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleDBSystemResource> GetOracleDBSystemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource> GetOracleDBSystemShape(Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeResource>> GetOracleDBSystemShapeAsync(Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeCollection GetOracleDBSystemShapes(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource> GetOracleDBVersion(Azure.Core.AzureLocation location, string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDBVersionResource>> GetOracleDBVersionAsync(Azure.Core.AzureLocation location, string dbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDBVersionCollection GetOracleDBVersions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource> GetOracleDnsPrivateView(Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewResource>> GetOracleDnsPrivateViewAsync(Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewCollection GetOracleDnsPrivateViews(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource> GetOracleDnsPrivateZone(Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneResource>> GetOracleDnsPrivateZoneAsync(Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneCollection GetOracleDnsPrivateZones(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource> GetOracleFlexComponent(Azure.Core.AzureLocation location, string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleFlexComponentResource>> GetOracleFlexComponentAsync(Azure.Core.AzureLocation location, string flexComponentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleFlexComponentCollection GetOracleFlexComponents(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource> GetOracleGIVersion(Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleGIVersionResource>> GetOracleGIVersionAsync(Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleGIVersionCollection GetOracleGIVersions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetOracleNetworkAnchors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorResource> GetOracleNetworkAnchorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetOracleResourceAnchors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.OracleResourceAnchorResource> GetOracleResourceAnchorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscription() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource> GetOracleSystemVersion(Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSystemVersionResource>> GetOracleSystemVersionAsync(Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSystemVersionCollection GetOracleSystemVersions(Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.OracleDatabase.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddSubscriptionOperationState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddSubscriptionOperationState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState left, Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState left, Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmOracleDatabaseModelFactory
    {
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData AutonomousDatabaseBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties AutonomousDatabaseBackupProperties(Azure.Core.ResourceIdentifier autonomousDatabaseOcid, double? databaseSizeInTbs, string dbVersion, string displayName, Azure.Core.ResourceIdentifier ocid, bool? isAutomatic, bool? isRestorable, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState? lifecycleState, int? retentionPeriodInDays, double? sizeInTbs, System.DateTimeOffset? timeAvailableTil, string timeStarted, string timeEnded, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType? backupType, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties AutonomousDatabaseBackupProperties(string databaseOcid = null, double? databaseSizeInTbs = default(double?), string dbVersion = null, string displayName = null, string databaseBackupOcid = null, bool? isAutomatic = default(bool?), bool? isRestorable = default(bool?), string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState?), int? retentionPeriodInDays = default(int?), double? sizeInTbs = default(double?), System.DateTimeOffset? timeAvailableTil = default(System.DateTimeOffset?), string timeStarted = null, string timeEnded = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType? backupType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties AutonomousDatabaseBaseProperties(string adminPassword, string dataBaseType, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel? computeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, Azure.Core.ResourceIdentifier ocid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties AutonomousDatabaseBaseProperties(string adminPassword, string dataBaseType, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, System.DateTimeOffset? disasterRecoveryRoleChangedOn, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, string databaseOcid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties AutonomousDatabaseBaseProperties(string adminPassword = null, string dataBaseType = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDBIds = null, string peerDBId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), System.DateTimeOffset? disasterRecoveryRoleChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType> scheduledOperationsList = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceBeginOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceEndOn = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupCreatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, System.DateTimeOffset? dataGuardRoleChangedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseDeletedOn = default(System.DateTimeOffset?), string timeLocalDataGuardEnabled = null, System.DateTimeOffset? lastFailoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshPointTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSwitchoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseStoppedOn = default(System.DateTimeOffset?), int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string databaseOcid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData AutonomousDatabaseCharacterSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string autonomousDatabaseCharacterSet = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties AutonomousDatabaseCloneProperties(string adminPassword, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel? computeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, Azure.Core.ResourceIdentifier ocid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType? source, Azure.Core.ResourceIdentifier sourceId, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType cloneType, bool? isReconnectCloneEnabled, bool? isRefreshableClone, Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType? refreshableModel, Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType? refreshableStatus, System.DateTimeOffset? reconnectCloneEnabledOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties AutonomousDatabaseCloneProperties(string adminPassword, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, System.DateTimeOffset? disasterRecoveryRoleChangedOn, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, string databaseOcid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType? source, Azure.Core.ResourceIdentifier sourceId, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType cloneType, bool? isReconnectCloneEnabled, bool? isRefreshableClone, Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType? refreshableModel, Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType? refreshableStatus, System.DateTimeOffset? reconnectCloneEnabledOn) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties AutonomousDatabaseCloneProperties(string adminPassword = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDBIds = null, string peerDBId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), System.DateTimeOffset? disasterRecoveryRoleChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType> scheduledOperationsList = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceBeginOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceEndOn = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupCreatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, System.DateTimeOffset? dataGuardRoleChangedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseDeletedOn = default(System.DateTimeOffset?), string timeLocalDataGuardEnabled = null, System.DateTimeOffset? lastFailoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshPointTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSwitchoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseStoppedOn = default(System.DateTimeOffset?), int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string databaseOcid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType? source = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType?), Azure.Core.ResourceIdentifier sourceId = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType cloneType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType), bool? isReconnectCloneEnabled = default(bool?), bool? isRefreshableClone = default(bool?), Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType? refreshableModel = default(Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType?), Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType? refreshableStatus = default(Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType?), System.DateTimeOffset? reconnectCloneEnabledOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile AutonomousDatabaseConnectionStringProfile(Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup? consumerGroup = default(Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup?), string displayName = null, Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType hostFormat = default(Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType), bool? isRegional = default(bool?), Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType protocol = default(Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType), Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType sessionMode = default(Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType), Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType syntaxFormat = default(Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType), Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType? tlsAuthentication = default(Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType?), string value = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings AutonomousDatabaseConnectionStrings(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType allConnectionStrings = null, string dedicated = null, string high = null, string low = null, string medium = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile> profiles = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType AutonomousDatabaseConnectionStringType(string high = null, string low = null, string medium = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls AutonomousDatabaseConnectionUrls(System.Uri apexUri = null, System.Uri databaseTransformsUri = null, System.Uri graphStudioUri = null, System.Uri machineLearningNotebookUri = null, System.Uri mongoDBUri = null, System.Uri ordsUri = null, System.Uri sqlDevWebUri = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties AutonomousDatabaseCrossRegionDisasterRecoveryProperties(string adminPassword, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, System.DateTimeOffset? disasterRecoveryRoleChangedOn, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, string databaseOcid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType source, Azure.Core.ResourceIdentifier sourceId, string sourceLocation, string sourceOcid, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType remoteDisasterRecoveryType, bool? isReplicateAutomaticBackups) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties AutonomousDatabaseCrossRegionDisasterRecoveryProperties(string adminPassword = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDBIds = null, string peerDBId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), System.DateTimeOffset? disasterRecoveryRoleChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType> scheduledOperationsList = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceBeginOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceEndOn = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupCreatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, System.DateTimeOffset? dataGuardRoleChangedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseDeletedOn = default(System.DateTimeOffset?), string timeLocalDataGuardEnabled = null, System.DateTimeOffset? lastFailoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshPointTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSwitchoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseStoppedOn = default(System.DateTimeOffset?), int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string databaseOcid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType source = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType), Azure.Core.ResourceIdentifier sourceId = null, string sourceLocation = null, string sourceOcid = null, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType remoteDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType), bool? isReplicateAutomaticBackups = default(bool?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData AutonomousDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties AutonomousDatabaseFromBackupTimestampProperties(string adminPassword, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, System.DateTimeOffset? disasterRecoveryRoleChangedOn, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, string databaseOcid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType source, Azure.Core.ResourceIdentifier sourceId, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType cloneType, System.DateTimeOffset? timestamp, bool? useLatestAvailableBackupTimeStamp) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties AutonomousDatabaseFromBackupTimestampProperties(string adminPassword = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDBIds = null, string peerDBId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), System.DateTimeOffset? disasterRecoveryRoleChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType> scheduledOperationsList = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceBeginOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceEndOn = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupCreatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, System.DateTimeOffset? dataGuardRoleChangedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseDeletedOn = default(System.DateTimeOffset?), string timeLocalDataGuardEnabled = null, System.DateTimeOffset? lastFailoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshPointTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSwitchoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseStoppedOn = default(System.DateTimeOffset?), int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string databaseOcid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType source = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType), Azure.Core.ResourceIdentifier sourceId = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType cloneType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType), System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), bool? useLatestAvailableBackupTimeStamp = default(bool?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData AutonomousDatabaseNationalCharacterSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string autonomousDatabaseNationalCharacterSet = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties AutonomousDatabaseProperties(string adminPassword, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel? computeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, Azure.Core.ResourceIdentifier ocid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties AutonomousDatabaseProperties(string adminPassword, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType, string characterSet, float? computeCount, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel, int? cpuCoreCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, int? dataStorageSizeInTbs, int? dataStorageSizeInGbs, string dbVersion, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, string displayName, bool? isAutoScalingEnabled, bool? isAutoScalingForStorageEnabled, System.Collections.Generic.IEnumerable<string> peerDBIds, string peerDBId, bool? isLocalDataGuardEnabled, bool? isRemoteDataGuardEnabled, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType, System.DateTimeOffset? disasterRecoveryRoleChangedOn, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB, int? failedDataRecoveryInSeconds, bool? isMtlsConnectionRequired, bool? isPreviewVersionWithServiceTermsAccepted, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, string ncharacterSet, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState, Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations, string privateEndpointIP, string privateEndpointLabel, System.Uri ociUri, Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnetId, System.DateTimeOffset? createdOn, System.DateTimeOffset? maintenanceBeginOn, System.DateTimeOffset? maintenanceEndOn, double? actualUsedDataStorageSizeInTbs, double? allocatedStorageSizeInTbs, Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition, Azure.Core.ResourceIdentifier autonomousDatabaseId, int? inMemoryAreaInGbs, System.DateTimeOffset? nextLongTermBackupCreatedOn, Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule, bool? isPreview, int? localAdgAutoFailoverMaxDataLossLimit, int? memoryPerOracleComputeUnitInGbs, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel, string privateEndpoint, System.Collections.Generic.IEnumerable<int> provisionableCpus, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role, System.Uri serviceConsoleUri, System.Uri sqlWebDeveloperUri, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo, System.DateTimeOffset? dataGuardRoleChangedOn, System.DateTimeOffset? freeAutonomousDatabaseDeletedOn, string timeLocalDataGuardEnabled, System.DateTimeOffset? lastFailoverHappenedOn, System.DateTimeOffset? lastRefreshHappenedOn, System.DateTimeOffset? lastRefreshPointTimestamp, System.DateTimeOffset? lastSwitchoverHappenedOn, System.DateTimeOffset? freeAutonomousDatabaseStoppedOn, int? usedDataStorageSizeInGbs, int? usedDataStorageSizeInTbs, string databaseOcid, int? backupRetentionPeriodInDays, System.Collections.Generic.IEnumerable<string> whitelistedIPs) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties AutonomousDatabaseProperties(string adminPassword = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? databaseComputeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDBIds = null, string peerDBId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), System.DateTimeOffset? disasterRecoveryRoleChangedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails remoteDisasterRecoveryConfiguration = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDB = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType> scheduledOperationsList = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceBeginOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceEndOn = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupCreatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, System.DateTimeOffset? dataGuardRoleChangedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseDeletedOn = default(System.DateTimeOffset?), string timeLocalDataGuardEnabled = null, System.DateTimeOffset? lastFailoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRefreshPointTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSwitchoverHappenedOn = default(System.DateTimeOffset?), System.DateTimeOffset? freeAutonomousDatabaseStoppedOn = default(System.DateTimeOffset?), int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string databaseOcid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary AutonomousDatabaseStandbySummary(int? lagTimeInSeconds = default(int?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), string lifecycleDetails = null, System.DateTimeOffset? dataGuardRoleChangedOn = default(System.DateTimeOffset?), System.DateTimeOffset? disasterRecoveryRoleChangedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile AutonomousDatabaseWalletFile(string walletFiles = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDBVersionData AutonomousDBVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties AutonomousDBVersionProperties(string version, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? dbWorkload, bool? isDefaultForFree, bool? isDefaultForPaid, bool? isFreeTierEnabled, bool? isPaidEnabled) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks CloudAccountActivationLinks(string newCloudAccountActivationLink = null, string existingCloudAccountActivationLink = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails CloudAccountDetails(string cloudAccountName = null, string cloudAccountHomeRegion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData CloudExadataInfrastructureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties CloudExadataInfrastructureProperties(Azure.Core.ResourceIdentifier ocid, int? computeCount, int? storageCount, int? totalStorageSizeInGbs, int? availableStorageSizeInGbs, System.DateTimeOffset? createdOn, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow maintenanceWindow, Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime estimatedPatchingTime, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState? lifecycleState, string shape, System.Uri ociUri, int? cpuCount, int? maxCpuCount, int? memorySizeInGbs, int? maxMemoryInGbs, int? dbNodeStorageSizeInGbs, int? maxDBNodeStorageSizeInGbs, double? dataStorageSizeInTbs, double? maxDataStorageInTbs, string dbServerVersion, string storageServerVersion, int? activatedStorageCount, int? additionalStorageCount, string displayName, Azure.Core.ResourceIdentifier lastMaintenanceRunId, Azure.Core.ResourceIdentifier nextMaintenanceRunId, string monthlyDBServerVersion, string monthlyStorageServerVersion) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties CloudExadataInfrastructureProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration> definedFileSystemConfiguration, string exadataInfraOcid, int? computeCount, int? storageCount, int? totalStorageSizeInGbs, int? availableStorageSizeInGbs, System.DateTimeOffset? createdOn, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow maintenanceWindow, Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime estimatedPatchingTime, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState? lifecycleState, string shape, System.Uri ociUri, int? cpuCount, int? maxCpuCount, int? memorySizeInGbs, int? maxMemoryInGbs, int? dbNodeStorageSizeInGbs, int? maxDBNodeStorageSizeInGbs, double? dataStorageSizeInTbs, double? maxDataStorageInTbs, string dbServerVersion, string storageServerVersion, int? activatedStorageCount, int? additionalStorageCount, string displayName, string lastMaintenanceRunOcid, string nextMaintenanceRunOcid, string monthlyDBServerVersion, string monthlyStorageServerVersion, string databaseServerType, string storageServerType, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties CloudExadataInfrastructureProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration> definedFileSystemConfiguration = null, string exadataInfraOcid = null, int? computeCount = default(int?), int? storageCount = default(int?), int? totalStorageSizeInGbs = default(int?), int? availableStorageSizeInGbs = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow maintenanceWindow = null, Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime estimatedPatchingTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> customerContacts = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState?), string shape = null, System.Uri ociUri = null, int? cpuCount = default(int?), int? maxCpuCount = default(int?), int? memorySizeInGbs = default(int?), int? maxMemoryInGbs = default(int?), int? dbNodeStorageSizeInGbs = default(int?), int? maxDBNodeStorageSizeInGbs = default(int?), double? dataStorageSizeInTbs = default(double?), double? maxDataStorageInTbs = default(double?), string dbServerVersion = null, string storageServerVersion = null, int? activatedStorageCount = default(int?), int? additionalStorageCount = default(int?), string displayName = null, string lastMaintenanceRunOcid = null, string nextMaintenanceRunOcid = null, string monthlyDBServerVersion = null, string monthlyStorageServerVersion = null, string databaseServerType = null, string storageServerType = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails exascaleConfig = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterData CloudVmClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterDBNodeData CloudVmClusterDBNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties CloudVmClusterDBNodeProperties(Azure.Core.ResourceIdentifier ocid, string additionalDetails, Azure.Core.ResourceIdentifier backupIPId, Azure.Core.ResourceIdentifier backupVnic2Id, Azure.Core.ResourceIdentifier backupVnicId, int? cpuCoreCount, int? dbNodeStorageSizeInGbs, Azure.Core.ResourceIdentifier dbServerId, Azure.Core.ResourceIdentifier dbSystemId, string faultDomain, Azure.Core.ResourceIdentifier hostIPId, string hostname, Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState? lifecycleState, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType? maintenanceType, int? memorySizeInGbs, int? softwareStorageSizeInGb, System.DateTimeOffset? timeCreated, System.DateTimeOffset? timeMaintenanceWindowEnd, System.DateTimeOffset? timeMaintenanceWindowStart, Azure.Core.ResourceIdentifier vnic2Id, Azure.Core.ResourceIdentifier vnicId, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties CloudVmClusterDBNodeProperties(string dbNodeOcid = null, string additionalDetails = null, string backupIPOcid = null, string backupVnic2Ocid = null, string backupVnicOcid = null, int? cpuCoreCount = default(int?), int? dbNodeStorageSizeInGbs = default(int?), string dbServerOcid = null, string dbSystemOcid = null, string faultDomain = null, string hostIPOcid = null, string hostname = null, Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState dbNodeLifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState), string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType? maintenanceType = default(Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType?), int? memorySizeInGbs = default(int?), int? softwareStorageSizeInGb = default(int?), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset? timeMaintenanceWindowEnd = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceWindowStart = default(System.DateTimeOffset?), string vnic2Ocid = null, string vnicOcid = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties CloudVmClusterProperties(Azure.Core.ResourceIdentifier ocid, long? listenerPort, int? nodeCount, int? storageSizeInGbs, double? dataStorageSizeInTbs, int? dbNodeStorageSizeInGbs, int? memorySizeInGbs, System.DateTimeOffset? createdOn, string lifecycleDetails, string timeZone, Azure.Core.ResourceIdentifier zoneId, string hostname, string domain, int cpuCoreCount, float? ocpuCount, string clusterName, int? dataStoragePercentage, bool? isLocalBackupEnabled, Azure.Core.ResourceIdentifier cloudExadataInfrastructureId, bool? isSparseDiskgroupEnabled, string systemVersion, System.Collections.Generic.IEnumerable<string> sshPublicKeys, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy? diskRedundancy, System.Collections.Generic.IEnumerable<string> scanIPIds, System.Collections.Generic.IEnumerable<string> vipIds, string scanDnsName, int? scanListenerPortTcp, int? scanListenerPortTcpSsl, Azure.Core.ResourceIdentifier scanDnsRecordId, string shape, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState? lifecycleState, Azure.Core.ResourceIdentifier vnetId, string giVersion, System.Uri ociUri, System.Uri nsgUri, Azure.Core.ResourceIdentifier subnetId, string backupSubnetCidr, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr> nsgCidrs, Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig dataCollectionOptions, string displayName, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> computeNodes, Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig iormConfigCache, Azure.Core.ResourceIdentifier lastUpdateHistoryEntryId, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dbServers, Azure.Core.ResourceIdentifier compartmentId, Azure.Core.ResourceIdentifier subnetOcid) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties CloudVmClusterProperties(string cloudVmClusterOcid, long? listenerPort, int? nodeCount, int? storageSizeInGbs, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails> fileSystemConfigurationDetails, double? dataStorageSizeInTbs, int? dbNodeStorageSizeInGbs, int? memorySizeInGbs, System.DateTimeOffset? createdOn, string lifecycleDetails, string timeZone, string zoneOcid, string hostname, string domain, int cpuCoreCount, float? ocpuCount, string clusterName, int? dataStoragePercentage, bool? isLocalBackupEnabled, Azure.Core.ResourceIdentifier cloudExadataInfrastructureId, bool? isSparseDiskgroupEnabled, string systemVersion, System.Collections.Generic.IEnumerable<string> sshPublicKeys, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy? diskRedundancy, System.Collections.Generic.IEnumerable<string> scanIPIds, System.Collections.Generic.IEnumerable<string> vipIds, string scanDnsName, int? scanListenerPortTcp, int? scanListenerPortTcpSsl, string scanDnsRecordOcid, string shape, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState? lifecycleState, Azure.Core.ResourceIdentifier vnetId, string giVersion, System.Uri ociUri, System.Uri nsgUri, Azure.Core.ResourceIdentifier subnetId, string backupSubnetCidr, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr> nsgCidrs, Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig dataCollectionOptions, string displayName, System.Collections.Generic.IEnumerable<string> computeNodeOcids, Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig iormConfigCache, string lastUpdateHistoryEntryOcid, System.Collections.Generic.IEnumerable<string> dbServerOcids, string compartmentOcid, string clusterSubnetOcid, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties CloudVmClusterProperties(string cloudVmClusterOcid = null, long? listenerPort = default(long?), int? nodeCount = default(int?), int? storageSizeInGbs = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails> fileSystemConfigurationDetails = null, double? dataStorageSizeInTbs = default(double?), int? dbNodeStorageSizeInGbs = default(int?), int? memorySizeInGbs = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string lifecycleDetails = null, string timeZone = null, string zoneOcid = null, string hostname = null, string domain = null, int cpuCoreCount = 0, float? ocpuCount = default(float?), string clusterName = null, int? dataStoragePercentage = default(int?), bool? isLocalBackupEnabled = default(bool?), Azure.Core.ResourceIdentifier cloudExadataInfrastructureId = null, bool? isSparseDiskgroupEnabled = default(bool?), string systemVersion = null, System.Collections.Generic.IEnumerable<string> sshPublicKeys = null, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy? diskRedundancy = default(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy?), System.Collections.Generic.IEnumerable<string> scanIPIds = null, System.Collections.Generic.IEnumerable<string> vipIds = null, string scanDnsName = null, int? scanListenerPortTcp = default(int?), int? scanListenerPortTcpSsl = default(int?), string scanDnsRecordOcid = null, string shape = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState?), Azure.Core.ResourceIdentifier vnetId = null, string giVersion = null, System.Uri ociUri = null, System.Uri nsgUri = null, Azure.Core.ResourceIdentifier subnetId = null, string backupSubnetCidr = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr> nsgCidrs = null, Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig dataCollectionOptions = null, string displayName = null, System.Collections.Generic.IEnumerable<string> computeNodeOcids = null, Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig iormConfigCache = null, string lastUpdateHistoryEntryOcid = null, System.Collections.Generic.IEnumerable<string> dbServerOcids = null, string compartmentOcid = null, string clusterSubnetOcid = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), Azure.Core.ResourceIdentifier exascaleDBStorageVaultOcid = null, Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType? storageManagementType = default(Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterVirtualNetworkAddressData CloudVmClusterVirtualNetworkAddressData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties CloudVmClusterVirtualNetworkAddressProperties(string ipAddress, Azure.Core.ResourceIdentifier vmOcid, Azure.Core.ResourceIdentifier ocid, string domain, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState? lifecycleState, System.DateTimeOffset? assignedOn) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties CloudVmClusterVirtualNetworkAddressProperties(string ipAddress = null, string vipVmOcid = null, string vipOcid = null, string domain = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState?), System.DateTimeOffset? assignedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBIormConfig DBIormConfig(string dbName = null, string flashCacheLimit = null, int? share = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails DBServerPatchingDetails(int? estimatedPatchDuration = default(int?), Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus? patchingStatus = default(Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus?), System.DateTimeOffset? patchingEndedOn = default(System.DateTimeOffset?), System.DateTimeOffset? patchingStartedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration DefinedFileSystemConfiguration(bool? isBackupPartition = default(bool?), bool? isResizable = default(bool?), int? minSizeGb = default(int?), string mountPoint = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime EstimatedPatchingTime(int? estimatedDBServerPatchingTime = default(int?), int? estimatedNetworkSwitchesPatchingTime = default(int?), int? estimatedStorageServerPatchingTime = default(int?), int? totalEstimatedPatchingTime = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig ExadataIormConfig(System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig> dbPlans = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState?), Azure.ResourceManager.OracleDatabase.Models.IormObjective? objective = default(Azure.ResourceManager.OracleDatabase.Models.IormObjective?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExadbVmClusterData ExadbVmClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties ExadbVmClusterProperties(string ocid, string clusterName, string backupSubnetCidr, System.Uri nsgUri, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState? lifecycleState, Azure.Core.ResourceIdentifier vnetId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig dataCollectionOptions, string displayName, string domain, int enabledEcpuCount, Azure.Core.ResourceIdentifier exascaleDBStorageVaultId, string gridImageOcid, Azure.ResourceManager.OracleDatabase.Models.GridImageType? gridImageType, string giVersion, string hostname, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel, int? memorySizeInGbs, int nodeCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr> nsgCidrs, string zoneOcid, string privateZoneOcid, int? scanListenerPortTcp, int? scanListenerPortTcpSsl, int? listenerPort, string shape, System.Collections.Generic.IEnumerable<string> sshPublicKeys, string systemVersion, string timeZone, int totalEcpuCount, int? vmFileSystemStorageTotalSizeInGbs, string lifecycleDetails, string scanDnsName, System.Collections.Generic.IEnumerable<string> scanIPIds, string scanDnsRecordId, int? snapshotFileSystemStorageTotalSizeInGbs, int? totalSizeInGbs, System.Collections.Generic.IEnumerable<string> vipIds, System.Uri ociUri, Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig iormConfigCache, string backupSubnetOcid, string subnetOcid) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties ExadbVmClusterProperties(string ocid = null, string clusterName = null, string backupSubnetCidr = null, System.Uri nsgUri = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState?), Azure.Core.ResourceIdentifier vnetId = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig dataCollectionOptions = null, string displayName = null, string domain = null, int enabledEcpuCount = 0, Azure.Core.ResourceIdentifier exascaleDBStorageVaultId = null, string gridImageOcid = null, Azure.ResourceManager.OracleDatabase.Models.GridImageType? gridImageType = default(Azure.ResourceManager.OracleDatabase.Models.GridImageType?), string giVersion = null, string hostname = null, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), int? memorySizeInGbs = default(int?), int nodeCount = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr> nsgCidrs = null, string zoneOcid = null, string privateZoneOcid = null, int? scanListenerPortTcp = default(int?), int? scanListenerPortTcpSsl = default(int?), int? listenerPort = default(int?), string shape = null, System.Collections.Generic.IEnumerable<string> sshPublicKeys = null, string systemVersion = null, string timeZone = null, int totalEcpuCount = 0, int? vmFileSystemStorageTotalSizeInGbs = default(int?), string lifecycleDetails = null, string scanDnsName = null, System.Collections.Generic.IEnumerable<string> scanIPIds = null, string scanDnsRecordId = null, int? snapshotFileSystemStorageTotalSizeInGbs = default(int?), int? totalSizeInGbs = default(int?), System.Collections.Generic.IEnumerable<string> vipIds = null, System.Uri ociUri = null, Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig iormConfigCache = null, string backupSubnetOcid = null, string subnetOcid = null, Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute? shapeAttribute = default(Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails ExascaleConfigDetails(int totalStorageInGbs = 0, int? availableStorageInGbs = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult ExascaleDBNodeActionResult(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExascaleDBNodeData ExascaleDBNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties ExascaleDBNodeProperties(string ocid = null, string additionalDetails = null, int? cpuCoreCount = default(int?), int? dbNodeStorageSizeInGbs = default(int?), string faultDomain = null, string hostname = null, Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState?), string maintenanceType = null, int? memorySizeInGbs = default(int?), int? softwareStorageSizeInGb = default(int?), System.DateTimeOffset? maintenanceWindowEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceWindowStartOn = default(System.DateTimeOffset?), int? totalCpuCoreCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails ExascaleDBStorageDetails(int? availableSizeInGbs = default(int?), int? totalSizeInGbs = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.ExascaleDBStorageVaultData ExascaleDBStorageVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties ExascaleDBStorageVaultProperties(int? additionalFlashCacheInPercent, string description, string displayName, int? highCapacityDatabaseStorageInputTotalSizeInGbs, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails highCapacityDatabaseStorage, string timeZone, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState? lifecycleState, string lifecycleDetails, int? vmClusterCount, string ocid, System.Uri ociUri) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties ExascaleDBStorageVaultProperties(int? additionalFlashCacheInPercent = default(int?), string description = null, string displayName = null, int? highCapacityDatabaseStorageInputTotalSizeInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails highCapacityDatabaseStorage = null, string timeZone = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState?), string lifecycleDetails = null, int? vmClusterCount = default(int?), string ocid = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier exadataInfrastructureId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute> attachedShapeAttributes = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails GenerateAutonomousDatabaseWalletDetails(Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType? generateType = default(Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType?), bool? isRegional = default(bool?), string password = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType OracleApexDetailsType(string apexVersion = null, string ordsVersion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBServerData OracleDBServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties OracleDBServerProperties(Azure.Core.ResourceIdentifier ocid, string displayName, Azure.Core.ResourceIdentifier compartmentId, Azure.Core.ResourceIdentifier exadataInfrastructureId, int? cpuCoreCount, Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails dbServerPatchingDetails, int? maxMemoryInGbs, int? dbNodeStorageSizeInGbs, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmClusterIds, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dbNodeIds, string lifecycleDetails, Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState? lifecycleState, int? maxCpuCount, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> autonomousVmClusterIds, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> autonomousVirtualMachineIds, int? maxDBNodeStorageInGbs, int? memorySizeInGbs, string shape, System.DateTimeOffset? createdOn, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties OracleDBServerProperties(string dbServerOcid = null, string displayName = null, string compartmentOcid = null, Azure.Core.ResourceIdentifier exadataInfrastructureOcid = null, int? cpuCoreCount = default(int?), Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails dbServerPatchingDetails = null, int? maxMemoryInGbs = default(int?), int? dbNodeStorageSizeInGbs = default(int?), System.Collections.Generic.IEnumerable<string> vmClusterOcids = null, System.Collections.Generic.IEnumerable<string> dbNodeOcids = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState?), int? maxCpuCount = default(int?), System.Collections.Generic.IEnumerable<string> autonomousVmClusterOcids = null, System.Collections.Generic.IEnumerable<string> autonomousVirtualMachineOcids = null, int? maxDBNodeStorageInGbs = default(int?), int? memorySizeInGbs = default(int?), string shape = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties OracleDBSystemBaseProperties(string source = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), System.Uri ociUri = null, Azure.Core.ResourceIdentifier resourceAnchorId = null, Azure.Core.ResourceIdentifier networkAnchorId = null, string clusterName = null, string displayName = null, int? initialDataStorageSizeInGb = default(int?), int? dataStorageSizeInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.StorageManagementType? dbSystemOptionsStorageManagement = default(Azure.ResourceManager.OracleDatabase.Models.StorageManagementType?), Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType? diskRedundancy = default(Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType?), string domainV2 = null, string gridImageOcid = null, string hostname = null, string ocid = null, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModelV2 = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState?), int? listenerPort = default(int?), int? memorySizeInGbs = default(int?), int? nodeCount = default(int?), string scanDnsName = null, System.Collections.Generic.IEnumerable<string> scanIPs = null, string shape = null, System.Collections.Generic.IEnumerable<string> sshPublicKeys = null, Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode? storageVolumePerformanceMode = default(Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode?), string timeZone = null, string version = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), int? computeCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBSystemData OracleDBSystemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties OracleDBSystemProperties(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), System.Uri ociUri = null, Azure.Core.ResourceIdentifier resourceAnchorId = null, Azure.Core.ResourceIdentifier networkAnchorId = null, string clusterName = null, string displayName = null, int? initialDataStorageSizeInGb = default(int?), int? dataStorageSizeInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.StorageManagementType? dbSystemOptionsStorageManagement = default(Azure.ResourceManager.OracleDatabase.Models.StorageManagementType?), Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType? diskRedundancy = default(Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType?), string domainV2 = null, string gridImageOcid = null, string hostname = null, string ocid = null, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? licenseModelV2 = default(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel?), string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState?), int? listenerPort = default(int?), int? memorySizeInGbs = default(int?), int? nodeCount = default(int?), string scanDnsName = null, System.Collections.Generic.IEnumerable<string> scanIPs = null, string shape = null, System.Collections.Generic.IEnumerable<string> sshPublicKeys = null, Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode? storageVolumePerformanceMode = default(Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode?), string timeZone = null, string version = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), int? computeCount = default(int?), Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType), string adminPassword = null, string dbVersion = null, string pluggableDatabaseName = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBSystemShapeData OracleDBSystemShapeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties OracleDBSystemShapeProperties(string shapeFamily, int availableCoreCount, int? minimumCoreCount, int? runtimeMinimumCoreCount, int? coreCountIncrement, int? minStorageCount, int? maxStorageCount, double? availableDataStoragePerServerInTbs, int? availableMemoryPerNodeInGbs, int? availableDBNodePerNodeInGbs, int? minCoreCountPerNode, int? availableMemoryInGbs, int? minMemoryPerNodeInGbs, int? availableDBNodeStorageInGbs, int? minDBNodeStoragePerNodeInGbs, int? availableDataStorageInTbs, int? minDataStorageInTbs, int? minimumNodeCount, int? maximumNodeCount, int? availableCoreCountPerNode) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties OracleDBSystemShapeProperties(string shapeFamily, string shapeName, int availableCoreCount, int? minimumCoreCount, int? runtimeMinimumCoreCount, int? coreCountIncrement, int? minStorageCount, int? maxStorageCount, double? availableDataStoragePerServerInTbs, int? availableMemoryPerNodeInGbs, int? availableDBNodePerNodeInGbs, int? minCoreCountPerNode, int? availableMemoryInGbs, int? minMemoryPerNodeInGbs, int? availableDBNodeStorageInGbs, int? minDBNodeStoragePerNodeInGbs, int? availableDataStorageInTbs, int? minDataStorageInTbs, int? minimumNodeCount, int? maximumNodeCount, int? availableCoreCountPerNode, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel, bool? areServerTypesSupported, string displayName) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties OracleDBSystemShapeProperties(string shapeFamily = null, string shapeName = null, int availableCoreCount = 0, int? minimumCoreCount = default(int?), int? runtimeMinimumCoreCount = default(int?), int? coreCountIncrement = default(int?), int? minStorageCount = default(int?), int? maxStorageCount = default(int?), double? availableDataStoragePerServerInTbs = default(double?), int? availableMemoryPerNodeInGbs = default(int?), int? availableDBNodePerNodeInGbs = default(int?), int? minCoreCountPerNode = default(int?), int? availableMemoryInGbs = default(int?), int? minMemoryPerNodeInGbs = default(int?), int? availableDBNodeStorageInGbs = default(int?), int? minDBNodeStoragePerNodeInGbs = default(int?), int? availableDataStorageInTbs = default(int?), int? minDataStorageInTbs = default(int?), int? minimumNodeCount = default(int?), int? maximumNodeCount = default(int?), int? availableCoreCountPerNode = default(int?), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel?), bool? areServerTypesSupported = default(bool?), string displayName = null, System.Collections.Generic.IEnumerable<string> shapeAttributes = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDBVersionData OracleDBVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties OracleDBVersionProperties(string version = null, bool? isLatestForMajorVersion = default(bool?), bool? isPreviewDbVersion = default(bool?), bool? isUpgradeSupported = default(bool?), bool? doesSupportPluggableDatabase = default(bool?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDnsPrivateViewData OracleDnsPrivateViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties OracleDnsPrivateViewProperties(Azure.Core.ResourceIdentifier ocid, string displayName, bool isProtected, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState? lifecycleState, string self, System.DateTimeOffset createdOn, System.DateTimeOffset updatedOn, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties OracleDnsPrivateViewProperties(string dnsPrivateViewOcid = null, string displayName = null, bool isProtected = false, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState dnsPrivateViewLifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState), string self = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleDnsPrivateZoneData OracleDnsPrivateZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties OracleDnsPrivateZoneProperties(Azure.Core.ResourceIdentifier ocid, bool isProtected, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState? lifecycleState, string self, int serial, string version, Azure.Core.ResourceIdentifier viewId, Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType zoneType, System.DateTimeOffset createdOn, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties OracleDnsPrivateZoneProperties(string zoneOcid = null, bool isProtected = false, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState dnsPrivateZoneLifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState), string self = null, int serial = 0, string version = null, string viewOcid = null, Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType zoneType = default(Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType), System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleFlexComponentData OracleFlexComponentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties OracleFlexComponentProperties(int? minimumCoreCount = default(int?), int? availableCoreCount = default(int?), int? availableDBStorageInGbs = default(int?), int? runtimeMinimumCoreCount = default(int?), string shape = null, int? availableMemoryInGbs = default(int?), int? availableLocalStorageInGbs = default(int?), string computeModel = null, Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType? hardwareType = default(Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType?), string descriptionSummary = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleGIMinorVersionData OracleGIMinorVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties OracleGIMinorVersionProperties(string version = null, string gridImageOcid = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleGIVersionData OracleGIVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string oracleGIVersion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleNetworkAnchorData OracleNetworkAnchorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties OracleNetworkAnchorProperties(string resourceAnchorId = null, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), Azure.Core.ResourceIdentifier vnetId = null, Azure.Core.ResourceIdentifier subnetId = null, string cidrBlock = null, string ociVcnId = null, string ociVcnDnsLabel = null, string ociSubnetId = null, string ociBackupCidrBlock = null, bool? isOracleToAzureDnsZoneSyncEnabled = default(bool?), bool? isOracleDnsListeningEndpointEnabled = default(bool?), bool? isOracleDnsForwardingEndpointEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule> dnsForwardingRules = null, string dnsListeningEndpointAllowedCidrs = null, string dnsListeningEndpointIPAddress = null, string dnsForwardingEndpointIPAddress = null, System.Uri dnsForwardingRulesUri = null, System.Uri dnsListeningEndpointNsgRulesUri = null, System.Uri dnsForwardingEndpointNsgRulesUri = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleResourceAnchorData OracleResourceAnchorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties OracleResourceAnchorProperties(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState?), string linkedCompartmentId = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSubscriptionData OracleSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties properties = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties OracleSubscriptionProperties(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState? provisioningState, string saasSubscriptionId, Azure.Core.ResourceIdentifier cloudAccountId, Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState? cloudAccountState, string termUnit, string productCode, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent? intent) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties OracleSubscriptionProperties(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState?), string saasSubscriptionId = null, string cloudAccountOcid = null, Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState? cloudAccountState = default(Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState?), string termUnit = null, string productCode = null, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent? intent = default(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent?), System.Collections.Generic.IEnumerable<string> azureSubscriptionIds = null, Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState? addSubscriptionOperationState = default(Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState?), string lastOperationStatusDetail = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSystemVersionData OracleSystemVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string oracleSystemVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult PrivateIPAddressResult(string displayName, string hostnameLabel, Azure.Core.ResourceIdentifier ocid, string ipAddress, Azure.Core.ResourceIdentifier subnetId) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult PrivateIPAddressResult(string displayName = null, string hostnameLabel = null, string privateIPAddressesOcid = null, string ipAddress = null, string subnetOcid = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails SaasSubscriptionDetails(string id = null, string subscriptionName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string offerId = null, string planId = null, string saasSubscriptionStatus = null, string publisherId = null, string purchaserEmailId = null, string purchaserTenantId = null, string termUnit = null, bool? isAutoRenew = default(bool?), bool? isFreeTrial = default(bool?)) { throw null; }
    }
    public partial class AutonomousDatabaseActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent>
    {
        public AutonomousDatabaseActionContent() { }
        public string PeerDBId { get { throw null; } set { } }
        public string PeerDBLocation { get { throw null; } set { } }
        public string PeerDBOcid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseBackupLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseBackupLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState Active { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState Creating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutonomousDatabaseBackupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>
    {
        public AutonomousDatabaseBackupPatch() { }
        public int? AutonomousDatabaseBackupUpdateRetentionPeriodInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseBackupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>
    {
        public AutonomousDatabaseBackupProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier AutonomousDatabaseOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType? BackupType { get { throw null; } }
        public string DatabaseBackupOcid { get { throw null; } }
        public string DatabaseOcid { get { throw null; } }
        public double? DatabaseSizeInTbs { get { throw null; } }
        public string DBVersion { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsAutomatic { get { throw null; } }
        public bool? IsRestorable { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState? LifecycleState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public int? RetentionPeriodInDays { get { throw null; } set { } }
        public double? SizeInTbs { get { throw null; } }
        public System.DateTimeOffset? TimeAvailableTil { get { throw null; } }
        public string TimeEnded { get { throw null; } }
        public string TimeStarted { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseBackupType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseBackupType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType Full { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType Incremental { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType LongTerm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AutonomousDatabaseBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>
    {
        protected AutonomousDatabaseBaseProperties() { }
        public double? ActualUsedDataStorageSizeInTbs { get { throw null; } }
        public string AdminPassword { get { throw null; } set { } }
        public double? AllocatedStorageSizeInTbs { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType ApexDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier AutonomousDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? AutonomousMaintenanceScheduleType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> AvailableUpgradeVersions { get { throw null; } }
        public int? BackupRetentionPeriodInDays { get { throw null; } set { } }
        public string CharacterSet { get { throw null; } set { } }
        public float? ComputeCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel? ComputeModel { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings ConnectionStrings { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls ConnectionUrls { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> CustomerContacts { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? DatabaseComputeModel { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? DatabaseEdition { get { throw null; } set { } }
        public string DatabaseOcid { get { throw null; } }
        public System.DateTimeOffset? DataGuardRoleChangedOn { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? DataSafeStatus { get { throw null; } }
        public int? DataStorageSizeInGbs { get { throw null; } set { } }
        public int? DataStorageSizeInTbs { get { throw null; } set { } }
        public string DBVersion { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? DBWorkload { get { throw null; } set { } }
        public System.DateTimeOffset? DisasterRecoveryRoleChangedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public int? FailedDataRecoveryInSeconds { get { throw null; } }
        public System.DateTimeOffset? FreeAutonomousDatabaseDeletedOn { get { throw null; } }
        public System.DateTimeOffset? FreeAutonomousDatabaseStoppedOn { get { throw null; } }
        public int? InMemoryAreaInGbs { get { throw null; } }
        public bool? IsAutoScalingEnabled { get { throw null; } set { } }
        public bool? IsAutoScalingForStorageEnabled { get { throw null; } set { } }
        public bool? IsLocalDataGuardEnabled { get { throw null; } set { } }
        public bool? IsMtlsConnectionRequired { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } }
        public bool? IsPreviewVersionWithServiceTermsAccepted { get { throw null; } set { } }
        public bool? IsRemoteDataGuardEnabled { get { throw null; } }
        public System.DateTimeOffset? LastFailoverHappenedOn { get { throw null; } }
        public System.DateTimeOffset? LastRefreshHappenedOn { get { throw null; } }
        public System.DateTimeOffset? LastRefreshPointTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastSwitchoverHappenedOn { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? LicenseModel { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? LifecycleState { get { throw null; } }
        public int? LocalAdgAutoFailoverMaxDataLossLimit { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? LocalDisasterRecoveryType { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary LocalStandbyDB { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails LongTermBackupSchedule { get { throw null; } set { } }
        public System.DateTimeOffset? MaintenanceBeginOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceEndOn { get { throw null; } }
        public int? MemoryPerOracleComputeUnitInGbs { get { throw null; } }
        public string NcharacterSet { get { throw null; } set { } }
        public System.DateTimeOffset? NextLongTermBackupCreatedOn { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? OpenMode { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? OperationsInsightsStatus { get { throw null; } }
        public string PeerDBId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PeerDBIds { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? PermissionLevel { get { throw null; } set { } }
        public string PrivateEndpoint { get { throw null; } }
        public string PrivateEndpointIP { get { throw null; } set { } }
        public string PrivateEndpointLabel { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<int> ProvisionableCpus { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails RemoteDisasterRecoveryConfiguration { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? Role { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release, please use ScheduledOperationsList instead", false)]
        public Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType ScheduledOperations { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType> ScheduledOperationsList { get { throw null; } }
        public System.Uri ServiceConsoleUri { get { throw null; } }
        public System.Uri SqlWebDeveloperUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedRegionsToCloneTo { get { throw null; } }
        public string TimeLocalDataGuardEnabled { get { throw null; } }
        public int? UsedDataStorageSizeInGbs { get { throw null; } }
        public int? UsedDataStorageSizeInTbs { get { throw null; } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> WhitelistedIPs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseCloneProperties : Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>
    {
        public AutonomousDatabaseCloneProperties(Azure.Core.ResourceIdentifier sourceId, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType cloneType) { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType CloneType { get { throw null; } set { } }
        public bool? IsReconnectCloneEnabled { get { throw null; } }
        public bool? IsRefreshableClone { get { throw null; } }
        public System.DateTimeOffset? ReconnectCloneEnabledOn { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType? RefreshableModel { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType? RefreshableStatus { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType? Source { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseCloneType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseCloneType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType Full { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType Metadata { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseComputeModel : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseComputeModel(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel Ecpu { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel Ocpu { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseComputeModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutonomousDatabaseConnectionStringProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile>
    {
        internal AutonomousDatabaseConnectionStringProfile() { }
        public Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup? ConsumerGroup { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType HostFormat { get { throw null; } }
        public bool? IsRegional { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType Protocol { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType SessionMode { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType SyntaxFormat { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType? TlsAuthentication { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseConnectionStrings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings>
    {
        internal AutonomousDatabaseConnectionStrings() { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType AllConnectionStrings { get { throw null; } }
        public string Dedicated { get { throw null; } }
        public string High { get { throw null; } }
        public string Low { get { throw null; } }
        public string Medium { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringProfile> Profiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStrings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseConnectionStringType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType>
    {
        internal AutonomousDatabaseConnectionStringType() { }
        public string High { get { throw null; } }
        public string Low { get { throw null; } }
        public string Medium { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionStringType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseConnectionUrls : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls>
    {
        internal AutonomousDatabaseConnectionUrls() { }
        public System.Uri ApexUri { get { throw null; } }
        public System.Uri DatabaseTransformsUri { get { throw null; } }
        public System.Uri GraphStudioUri { get { throw null; } }
        public System.Uri MachineLearningNotebookUri { get { throw null; } }
        public System.Uri MongoDBUri { get { throw null; } }
        public System.Uri OrdsUri { get { throw null; } }
        public System.Uri SqlDevWebUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseConnectionUrls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseCrossRegionDisasterRecoveryProperties : Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties>
    {
        public AutonomousDatabaseCrossRegionDisasterRecoveryProperties(Azure.Core.ResourceIdentifier sourceId, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType remoteDisasterRecoveryType) { }
        public bool? IsReplicateAutomaticBackups { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType RemoteDisasterRecoveryType { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType Source { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string SourceOcid { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCrossRegionDisasterRecoveryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseFromBackupTimestampProperties : Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties>
    {
        public AutonomousDatabaseFromBackupTimestampProperties(Azure.Core.ResourceIdentifier sourceId, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType cloneType) { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneType CloneType { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType Source { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public bool? UseLatestAvailableBackupTimeStamp { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseFromBackupTimestampProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseLifecycleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction>
    {
        public AutonomousDatabaseLifecycleAction(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum action) { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum Action { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseLifecycleActionEnum : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseLifecycleActionEnum(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum Restart { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum Start { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleActionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState AvailableNeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState BackupInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Recreating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Restarting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState RestoreFailed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState RestoreInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState RoleChangeInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState ScaleInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Standby { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Starting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Stopped { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Stopping { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Unavailable { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Updating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseModeType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseModeType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutonomousDatabasePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>
    {
        public AutonomousDatabasePatch() { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabasePermissionLevelType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabasePermissionLevelType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType Restricted { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType Unrestricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutonomousDatabaseProperties : Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>
    {
        public AutonomousDatabaseProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseSourceType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseSourceType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType BackupFromId { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType BackupFromTimestamp { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType CloneToRefreshable { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType CrossRegionDataguard { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType CrossRegionDisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType Database { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutonomousDatabaseStandbySummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>
    {
        internal AutonomousDatabaseStandbySummary() { }
        public System.DateTimeOffset? DataGuardRoleChangedOn { get { throw null; } }
        public System.DateTimeOffset? DisasterRecoveryRoleChangedOn { get { throw null; } }
        public int? LagTimeInSeconds { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? LifecycleState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties>
    {
        public AutonomousDatabaseUpdateProperties() { }
        public string AdminPassword { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? AutonomousMaintenanceScheduleType { get { throw null; } set { } }
        public int? BackupRetentionPeriodInDays { get { throw null; } set { } }
        public float? ComputeCount { get { throw null; } set { } }
        public int? CpuCoreCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> CustomerContacts { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType? DatabaseEdition { get { throw null; } set { } }
        public int? DataStorageSizeInGbs { get { throw null; } set { } }
        public int? DataStorageSizeInTbs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsAutoScalingEnabled { get { throw null; } set { } }
        public bool? IsAutoScalingForStorageEnabled { get { throw null; } set { } }
        public bool? IsLocalDataGuardEnabled { get { throw null; } set { } }
        public bool? IsMtlsConnectionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? LicenseModel { get { throw null; } set { } }
        public int? LocalAdgAutoFailoverMaxDataLossLimit { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails LongTermBackupSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseModeType? OpenMode { get { throw null; } set { } }
        public string PeerDBId { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePermissionLevelType? PermissionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType? Role { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release, please use ScheduledOperationsList instead", false)]
        public Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate ScheduledOperations { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate> ScheduledOperationsList { get { throw null; } }
        public System.Collections.Generic.IList<string> WhitelistedIPs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseWalletFile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>
    {
        internal AutonomousDatabaseWalletFile() { }
        public string WalletFiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousDatabaseWorkloadType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousDatabaseWorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType Ajd { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType Apex { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType DW { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType Oltp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutonomousDBVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties>
    {
        public AutonomousDBVersionProperties(string version) { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWorkloadType? DBWorkload { get { throw null; } }
        public bool? IsDefaultForFree { get { throw null; } }
        public bool? IsDefaultForPaid { get { throw null; } }
        public bool? IsFreeTierEnabled { get { throw null; } }
        public bool? IsPaidEnabled { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDBVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutonomousMaintenanceScheduleType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutonomousMaintenanceScheduleType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType Early { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType Regular { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType left, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudAccountActivationLinks : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>
    {
        internal CloudAccountActivationLinks() { }
        public string ExistingCloudAccountActivationLink { get { throw null; } }
        public string NewCloudAccountActivationLink { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountActivationLinks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudAccountDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>
    {
        internal CloudAccountDetails() { }
        public string CloudAccountHomeRegion { get { throw null; } }
        public string CloudAccountName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudAccountProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudAccountProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudExadataInfrastructureLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudExadataInfrastructureLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudExadataInfrastructurePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch>
    {
        public CloudExadataInfrastructurePatch() { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructurePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudExadataInfrastructureProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties>
    {
        public CloudExadataInfrastructureProperties(string shape, string displayName) { }
        public int? ActivatedStorageCount { get { throw null; } }
        public int? AdditionalStorageCount { get { throw null; } }
        public int? AvailableStorageSizeInGbs { get { throw null; } }
        public int? ComputeCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? ComputeModel { get { throw null; } }
        public int? CpuCount { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> CustomerContacts { get { throw null; } }
        public string DatabaseServerType { get { throw null; } set { } }
        public double? DataStorageSizeInTbs { get { throw null; } }
        public int? DBNodeStorageSizeInGbs { get { throw null; } }
        public string DBServerVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration> DefinedFileSystemConfiguration { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime EstimatedPatchingTime { get { throw null; } }
        public string ExadataInfraOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails ExascaleConfig { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier LastMaintenanceRunId { get { throw null; } }
        public string LastMaintenanceRunOcid { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState? LifecycleState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? MaxCpuCount { get { throw null; } }
        public double? MaxDataStorageInTbs { get { throw null; } }
        public int? MaxDBNodeStorageSizeInGbs { get { throw null; } }
        public int? MaxMemoryInGbs { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string MonthlyDBServerVersion { get { throw null; } }
        public string MonthlyStorageServerVersion { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier NextMaintenanceRunId { get { throw null; } }
        public string NextMaintenanceRunOcid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public string Shape { get { throw null; } set { } }
        public int? StorageCount { get { throw null; } set { } }
        public string StorageServerType { get { throw null; } set { } }
        public string StorageServerVersion { get { throw null; } }
        public int? TotalStorageSizeInGbs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudExadataInfrastructureUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>
    {
        public CloudExadataInfrastructureUpdateProperties() { }
        public int? ComputeCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact> CustomerContacts { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? StorageCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterDBNodeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This constructor is obsolete and will be removed in a future release", false)]
        public CloudVmClusterDBNodeContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dbServers) { }
        public CloudVmClusterDBNodeContent(System.Collections.Generic.IEnumerable<string> dbServerOcids) { }
        public System.Collections.Generic.IList<string> DBServerOcids { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> DBServers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterDBNodeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CloudVmClusterDBNodeProperties(Azure.Core.ResourceIdentifier ocid, Azure.Core.ResourceIdentifier dbSystemId) { }
        public string AdditionalDetails { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier BackupIPId { get { throw null; } }
        public string BackupIPOcid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier BackupVnic2Id { get { throw null; } }
        public string BackupVnic2Ocid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier BackupVnicId { get { throw null; } }
        public string BackupVnicOcid { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState DBNodeLifecycleState { get { throw null; } }
        public string DBNodeOcid { get { throw null; } }
        public int? DBNodeStorageSizeInGbs { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier DBServerId { get { throw null; } }
        public string DBServerOcid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier DBSystemId { get { throw null; } }
        public string DBSystemOcid { get { throw null; } }
        public string FaultDomain { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier HostIPId { get { throw null; } }
        public string HostIPOcid { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState? LifecycleState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType? MaintenanceType { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int? SoftwareStorageSizeInGb { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceWindowEnd { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceWindowStart { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Vnic2Id { get { throw null; } }
        public string Vnic2Ocid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier VnicId { get { throw null; } }
        public string VnicOcid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDBNodeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudVmClusterDiskRedundancy : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudVmClusterDiskRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy High { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy left, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy left, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudVmClusterLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudVmClusterLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudVmClusterNsgCidr : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr>
    {
        public CloudVmClusterNsgCidr(string source) { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange DestinationPortRange { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>
    {
        public CloudVmClusterPatch() { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterPortRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange>
    {
        public CloudVmClusterPortRange(int min, int max) { }
        public int Max { get { throw null; } set { } }
        public int Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPortRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>
    {
        public CloudVmClusterProperties(string hostname, int cpuCoreCount, Azure.Core.ResourceIdentifier cloudExadataInfrastructureId, System.Collections.Generic.IEnumerable<string> sshPublicKeys, Azure.Core.ResourceIdentifier vnetId, string giVersion, Azure.Core.ResourceIdentifier subnetId, string displayName) { }
        public string BackupSubnetCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CloudExadataInfrastructureId { get { throw null; } set { } }
        public string CloudVmClusterOcid { get { throw null; } }
        public string ClusterName { get { throw null; } set { } }
        public string ClusterSubnetOcid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier CompartmentId { get { throw null; } }
        public string CompartmentOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? ComputeModel { get { throw null; } }
        public System.Collections.Generic.IList<string> ComputeNodeOcids { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ComputeNodes { get { throw null; } }
        public int CpuCoreCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig DataCollectionOptions { get { throw null; } set { } }
        public int? DataStoragePercentage { get { throw null; } set { } }
        public double? DataStorageSizeInTbs { get { throw null; } set { } }
        public int? DBNodeStorageSizeInGbs { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DBServerOcids { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> DBServers { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterDiskRedundancy? DiskRedundancy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExascaleDBStorageVaultOcid { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails> FileSystemConfigurationDetails { get { throw null; } }
        public string GiVersion { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig IormConfigCache { get { throw null; } }
        public bool? IsLocalBackupEnabled { get { throw null; } set { } }
        public bool? IsSparseDiskgroupEnabled { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier LastUpdateHistoryEntryId { get { throw null; } }
        public string LastUpdateHistoryEntryOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? LicenseModel { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState? LifecycleState { get { throw null; } }
        public long? ListenerPort { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr> NsgCidrs { get { throw null; } }
        public System.Uri NsgUri { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public float? OcpuCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public string ScanDnsName { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier ScanDnsRecordId { get { throw null; } }
        public string ScanDnsRecordOcid { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ScanIPIds { get { throw null; } }
        public int? ScanListenerPortTcp { get { throw null; } set { } }
        public int? ScanListenerPortTcpSsl { get { throw null; } set { } }
        public string Shape { get { throw null; } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType? StorageManagementType { get { throw null; } }
        public int? StorageSizeInGbs { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier SubnetOcid { get { throw null; } }
        public string SystemVersion { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> VipIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier ZoneId { get { throw null; } set { } }
        public string ZoneOcid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>
    {
        public CloudVmClusterUpdateProperties() { }
        public System.Collections.Generic.IList<string> ComputeNodeOcids { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ComputeNodes { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig DataCollectionOptions { get { throw null; } set { } }
        public double? DataStorageSizeInTbs { get { throw null; } set { } }
        public int? DBNodeStorageSizeInGbs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails> FileSystemConfigurationDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? LicenseModel { get { throw null; } set { } }
        public int? MemorySizeInGbs { get { throw null; } set { } }
        public float? OcpuCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public int? StorageSizeInGbs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterVirtualNetworkAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties>
    {
        public CloudVmClusterVirtualNetworkAddressProperties() { }
        public System.DateTimeOffset? AssignedOn { get { throw null; } }
        public string Domain { get { throw null; } }
        public string IPAddress { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState? LifecycleState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public string VipOcid { get { throw null; } }
        public string VipVmOcid { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier VmOcid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterVirtualNetworkAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigureExascaleCloudExadataInfrastructureDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails>
    {
        public ConfigureExascaleCloudExadataInfrastructureDetails(int totalStorageInGbs) { }
        public int TotalStorageInGbs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConfigureExascaleCloudExadataInfrastructureDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionConsumerGroup : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionConsumerGroup(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup High { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup Low { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup Medium { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup Tp { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup Tpurgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup left, Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup left, Azure.ResourceManager.OracleDatabase.Models.ConnectionConsumerGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionHostFormatType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionHostFormatType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType Fqdn { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType IP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionHostFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionProtocolType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType Tcp { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType Tcps { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionSessionModeType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionSessionModeType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType Direct { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionSessionModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionTlsAuthenticationType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionTlsAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType Mutual { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType Server { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType left, Azure.ResourceManager.OracleDatabase.Models.ConnectionTlsAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataGuardRoleType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataGuardRoleType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType BackupCopy { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType DisabledStandby { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType Primary { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType SnapshotStandby { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType Standby { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType left, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType left, Azure.ResourceManager.OracleDatabase.Models.DataGuardRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSafeStatusType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSafeStatusType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType Deregistering { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType NotRegistered { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType Registered { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType Registering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType left, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType left, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DBIormConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig>
    {
        internal DBIormConfig() { }
        public string DBName { get { throw null; } }
        public string FlashCacheLimit { get { throw null; } }
        public int? Share { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBIormConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBIormConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DBNodeAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeAction>
    {
        public DBNodeAction(Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType action) { }
        public Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType Action { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBNodeAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBNodeAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBNodeActionType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBNodeActionType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType Reset { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType SoftReset { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType Start { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType left, Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType left, Azure.ResourceManager.OracleDatabase.Models.DBNodeActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DBNodeDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails>
    {
        public DBNodeDetails(Azure.Core.ResourceIdentifier dbNodeId) { }
        public Azure.Core.ResourceIdentifier DBNodeId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBNodeMaintenanceType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBNodeMaintenanceType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType VmdbRebootMigration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType left, Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType left, Azure.ResourceManager.OracleDatabase.Models.DBNodeMaintenanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBNodeProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBNodeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Starting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Stopped { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Stopping { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DBServerPatchingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails>
    {
        internal DBServerPatchingDetails() { }
        public int? EstimatedPatchDuration { get { throw null; } }
        public System.DateTimeOffset? PatchingEndedOn { get { throw null; } }
        public System.DateTimeOffset? PatchingStartedOn { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus? PatchingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBServerPatchingStatus : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBServerPatchingStatus(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus left, Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus left, Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBServerProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBServerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBSystemDatabaseEditionType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBSystemDatabaseEditionType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType EnterpriseEdition { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType EnterpriseEditionDeveloper { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType EnterpriseEditionExtreme { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType EnterpriseEditionHighPerformance { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType StandardEdition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType left, Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType left, Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBSystemDiskRedundancyType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBSystemDiskRedundancyType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType High { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType left, Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType left, Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBSystemLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBSystemLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Migrated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Updating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DBSystemSourceType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DBSystemSourceType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType left, Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType left, Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DefinedFileSystemConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration>
    {
        internal DefinedFileSystemConfiguration() { }
        public bool? IsBackupPartition { get { throw null; } }
        public bool? IsResizable { get { throw null; } }
        public int? MinSizeGb { get { throw null; } }
        public string MountPoint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DefinedFileSystemConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiagnosticCollectionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig>
    {
        public DiagnosticCollectionConfig() { }
        public bool? IsDiagnosticsEventsEnabled { get { throw null; } set { } }
        public bool? IsHealthMonitoringEnabled { get { throw null; } set { } }
        public bool? IsIncidentLogsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DisasterRecoveryConfigurationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails>
    {
        public DisasterRecoveryConfigurationDetails() { }
        public Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? DisasterRecoveryType { get { throw null; } set { } }
        public bool? IsReplicateAutomaticBackups { get { throw null; } set { } }
        public bool? IsSnapshotStandby { get { throw null; } set { } }
        public System.DateTimeOffset? TimeSnapshotStandbyEnabledTill { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryConfigurationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisasterRecoveryType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisasterRecoveryType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType Adg { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType BackupBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType left, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType left, Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsPrivateViewsLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsPrivateViewsLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState Active { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState Deleted { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsPrivateZonesLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsPrivateZonesLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState Active { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState Creating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState Deleted { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EstimatedPatchingTime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>
    {
        internal EstimatedPatchingTime() { }
        public int? EstimatedDBServerPatchingTime { get { throw null; } }
        public int? EstimatedNetworkSwitchesPatchingTime { get { throw null; } }
        public int? EstimatedStorageServerPatchingTime { get { throw null; } }
        public int? TotalEstimatedPatchingTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExadataIormConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>
    {
        internal ExadataIormConfig() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OracleDatabase.Models.DBIormConfig> DBPlans { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState? LifecycleState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.IormObjective? Objective { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExadataVmClusterStorageManagementType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExadataVmClusterStorageManagementType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType Asm { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType Exascale { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType left, Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType left, Azure.ResourceManager.OracleDatabase.Models.ExadataVmClusterStorageManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExadbVmClusterLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExadbVmClusterLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExadbVmClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch>
    {
        public ExadbVmClusterPatch() { }
        public int? ExadbVmClusterUpdateNodeCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExadbVmClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties>
    {
        public ExadbVmClusterProperties(Azure.Core.ResourceIdentifier vnetId, Azure.Core.ResourceIdentifier subnetId, string displayName, int enabledEcpuCount, Azure.Core.ResourceIdentifier exascaleDBStorageVaultId, string hostname, int nodeCount, string shape, System.Collections.Generic.IEnumerable<string> sshPublicKeys, int totalEcpuCount, Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails vmFileSystemStorage) { }
        public string BackupSubnetCidr { get { throw null; } set { } }
        public string BackupSubnetOcid { get { throw null; } }
        public string ClusterName { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DiagnosticCollectionConfig DataCollectionOptions { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int EnabledEcpuCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExascaleDBStorageVaultId { get { throw null; } set { } }
        public string GiVersion { get { throw null; } }
        public string GridImageOcid { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.GridImageType? GridImageType { get { throw null; } }
        public string Hostname { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig IormConfigCache { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? LicenseModel { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterLifecycleState? LifecycleState { get { throw null; } }
        public int? ListenerPort { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public int NodeCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterNsgCidr> NsgCidrs { get { throw null; } }
        public System.Uri NsgUri { get { throw null; } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public string PrivateZoneOcid { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public string ScanDnsName { get { throw null; } }
        public string ScanDnsRecordId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ScanIPIds { get { throw null; } }
        public int? ScanListenerPortTcp { get { throw null; } set { } }
        public int? ScanListenerPortTcpSsl { get { throw null; } set { } }
        public string Shape { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute? ShapeAttribute { get { throw null; } set { } }
        public int? SnapshotFileSystemStorageTotalSizeInGbs { get { throw null; } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string SubnetOcid { get { throw null; } }
        public string SystemVersion { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public int TotalEcpuCount { get { throw null; } set { } }
        public int? TotalSizeInGbs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VipIds { get { throw null; } }
        public int? VmFileSystemStorageTotalSizeInGbs { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        public string ZoneOcid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExadbVmClusterStorageDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails>
    {
        public ExadbVmClusterStorageDetails(int totalSizeInGbs) { }
        public int TotalSizeInGbs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadbVmClusterStorageDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleConfigDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails>
    {
        internal ExascaleConfigDetails() { }
        public int? AvailableStorageInGbs { get { throw null; } }
        public int TotalStorageInGbs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleConfigDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBNodeActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>
    {
        internal ExascaleDBNodeActionResult() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBNodeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties>
    {
        internal ExascaleDBNodeProperties() { }
        public string AdditionalDetails { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } }
        public int? DBNodeStorageSizeInGbs { get { throw null; } }
        public string FaultDomain { get { throw null; } }
        public string Hostname { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DBNodeProvisioningState? LifecycleState { get { throw null; } }
        public string MaintenanceType { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowStartOn { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string Ocid { get { throw null; } }
        public int? SoftwareStorageSizeInGb { get { throw null; } }
        public int? TotalCpuCoreCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBNodeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBStorageDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails>
    {
        internal ExascaleDBStorageDetails() { }
        public int? AvailableSizeInGbs { get { throw null; } }
        public int? TotalSizeInGbs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBStorageInputDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails>
    {
        public ExascaleDBStorageInputDetails(int totalSizeInGbs) { }
        public int TotalSizeInGbs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExascaleDBStorageVaultLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExascaleDBStorageVaultLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExascaleDBStorageVaultPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch>
    {
        public ExascaleDBStorageVaultPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExascaleDBStorageVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties>
    {
        public ExascaleDBStorageVaultProperties(string displayName, Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageInputDetails highCapacityDatabaseStorageInput) { }
        public int? AdditionalFlashCacheInPercent { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute> AttachedShapeAttributes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExadataInfrastructureId { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageDetails HighCapacityDatabaseStorage { get { throw null; } }
        public int? HighCapacityDatabaseStorageInputTotalSizeInGbs { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultLifecycleState? LifecycleState { get { throw null; } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public int? VmClusterCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExascaleDBStorageVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExascaleStorageShapeAttribute : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExascaleStorageShapeAttribute(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute BlockStorage { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute SmartStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute left, Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute left, Azure.ResourceManager.OracleDatabase.Models.ExascaleStorageShapeAttribute right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSystemConfigurationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails>
    {
        public FileSystemConfigurationDetails() { }
        public int? FileSystemSizeGb { get { throw null; } set { } }
        public string MountPoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.FileSystemConfigurationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FlexComponentHardwareType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FlexComponentHardwareType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType Cell { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType Compute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType left, Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType left, Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateAutonomousDatabaseWalletDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>
    {
        public GenerateAutonomousDatabaseWalletDetails(string password) { }
        public Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType? GenerateType { get { throw null; } set { } }
        public bool? IsRegional { get { throw null; } set { } }
        public string Password { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GIMinorVersionShapeFamily : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GIMinorVersionShapeFamily(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily Exadata { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily ExadbXS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily left, Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily left, Azure.ResourceManager.OracleDatabase.Models.GIMinorVersionShapeFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GridImageType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.GridImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GridImageType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.GridImageType CustomImage { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.GridImageType ReleaseUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.GridImageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.GridImageType left, Azure.ResourceManager.OracleDatabase.Models.GridImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.GridImageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.GridImageType left, Azure.ResourceManager.OracleDatabase.Models.GridImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IormLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IormLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState BootStrapping { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState Disabled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState Enabled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IormObjective : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.IormObjective>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IormObjective(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.IormObjective Auto { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormObjective Balanced { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormObjective Basic { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormObjective HighThroughput { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.IormObjective LowLatency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.IormObjective other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.IormObjective left, Azure.ResourceManager.OracleDatabase.Models.IormObjective right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.IormObjective (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.IormObjective left, Azure.ResourceManager.OracleDatabase.Models.IormObjective right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListDBVersionBySubscriptionLocationContent
    {
        public ListDBVersionBySubscriptionLocationContent() { }
        public Azure.Core.ResourceIdentifier DbSystemId { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape? DbSystemShape { get { throw null; } set { } }
        public bool? IsDatabaseSoftwareImageSupported { get { throw null; } set { } }
        public bool? IsUpgradeSupported { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType? ShapeFamily { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.StorageManagementType? StorageManagement { get { throw null; } set { } }
    }
    public partial class LongTermBackUpScheduleDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>
    {
        public LongTermBackUpScheduleDetails() { }
        public System.DateTimeOffset? BackupOn { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType? RepeatCadence { get { throw null; } set { } }
        public int? RetentionPeriodInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceMonth : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth>
    {
        public MaintenanceMonth(Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName name) { }
        public Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceMonthName : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceMonthName(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName April { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName August { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName December { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName February { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName January { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName July { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName June { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName March { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName May { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName November { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName October { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName left, Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName left, Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonthName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenancePatchingMode : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenancePatchingMode(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode NonRolling { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode Rolling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode left, Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode left, Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenancePreference : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenancePreference(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference CustomPreference { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference NoPreference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference left, Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference left, Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkAnchorDnsForwardingRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule>
    {
        public NetworkAnchorDnsForwardingRule(string domainNames, string forwardingIPAddress) { }
        public string DomainNames { get { throw null; } set { } }
        public string ForwardingIPAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkAnchorUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties>
    {
        public NetworkAnchorUpdateProperties() { }
        public bool? IsOracleDnsForwardingEndpointEnabled { get { throw null; } set { } }
        public bool? IsOracleDnsListeningEndpointEnabled { get { throw null; } set { } }
        public bool? IsOracleToAzureDnsZoneSyncEnabled { get { throw null; } set { } }
        public string OciBackupCidrBlock { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationsInsightsStatusType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationsInsightsStatusType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType Disabling { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType Enabled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType Enabling { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType FailedDisabling { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType FailedEnabling { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType NotEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType left, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType left, Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleApexDetailsType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType>
    {
        internal OracleApexDetailsType() { }
        public string ApexVersion { get { throw null; } }
        public string OrdsVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleApexDetailsType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleAzureSubscriptionsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent>
    {
        public OracleAzureSubscriptionsContent(System.Collections.Generic.IEnumerable<string> azureSubscriptionIds) { }
        public System.Collections.Generic.IList<string> AzureSubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleAzureSubscriptionsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleBaseDbSystemShape : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleBaseDbSystemShape(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape VmStandardX86 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape left, Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape left, Azure.ResourceManager.OracleDatabase.Models.OracleBaseDbSystemShape right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleCustomerContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact>
    {
        public OracleCustomerContact(string email) { }
        public string Email { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleCustomerContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleDatabaseComputeModel : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleDatabaseComputeModel(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel Ecpu { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel Ocpu { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleDatabaseDayOfWeek : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek>
    {
        public OracleDatabaseDayOfWeek(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName name) { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleDatabaseDayOfWeekName : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleDatabaseDayOfWeekName(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Friday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Monday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Saturday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Sunday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Thursday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Tuesday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleDatabaseDayOfWeekUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate>
    {
        public OracleDatabaseDayOfWeekUpdate() { }
        public OracleDatabaseDayOfWeekUpdate(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName name) { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleDatabaseEditionType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleDatabaseEditionType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType EnterpriseEdition { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType StandardEdition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseEditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleDatabaseMaintenanceWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow>
    {
        public OracleDatabaseMaintenanceWindow() { }
        public int? CustomActionTimeoutInMins { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek> DaysOfWeek { get { throw null; } }
        public System.Collections.Generic.IList<int> HoursOfDay { get { throw null; } }
        public bool? IsCustomActionTimeoutEnabled { get { throw null; } set { } }
        public bool? IsMonthlyPatchingEnabled { get { throw null; } set { } }
        public int? LeadTimeInWeeks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.MaintenanceMonth> Months { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.MaintenancePatchingMode? PatchingMode { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.MaintenancePreference? Preference { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> WeeksOfMonth { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseMaintenanceWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleDatabaseProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleDatabaseProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleDatabaseResourceProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleDatabaseResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleDatabaseSystemShape : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleDatabaseSystemShape(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape ExadataX11M { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape ExadataX9M { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape ExadbXS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape left, Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseSystemShape right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleDBServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties>
    {
        public OracleDBServerProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AutonomousVirtualMachineIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AutonomousVirtualMachineOcids { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AutonomousVmClusterIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AutonomousVmClusterOcids { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier CompartmentId { get { throw null; } }
        public string CompartmentOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? ComputeModel { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> DBNodeIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DBNodeOcids { get { throw null; } }
        public int? DBNodeStorageSizeInGbs { get { throw null; } }
        public string DBServerOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DBServerPatchingDetails DBServerPatchingDetails { get { throw null; } }
        public string DisplayName { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier ExadataInfrastructureId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExadataInfrastructureOcid { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DBServerProvisioningState? LifecycleState { get { throw null; } }
        public int? MaxCpuCount { get { throw null; } }
        public int? MaxDBNodeStorageInGbs { get { throw null; } }
        public int? MaxMemoryInGbs { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Shape { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VmClusterIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmClusterOcids { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OracleDBSystemBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties>
    {
        protected OracleDBSystemBaseProperties(Azure.Core.ResourceIdentifier resourceAnchorId, Azure.Core.ResourceIdentifier networkAnchorId, string hostname, string shape, System.Collections.Generic.IEnumerable<string> sshPublicKeys) { }
        public string ClusterName { get { throw null; } set { } }
        public int? ComputeCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? ComputeModel { get { throw null; } set { } }
        public int? DataStorageSizeInGbs { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.StorageManagementType? DbSystemOptionsStorageManagement { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DBSystemDiskRedundancyType? DiskRedundancy { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string DomainV2 { get { throw null; } set { } }
        public string GridImageOcid { get { throw null; } }
        public string Hostname { get { throw null; } set { } }
        public int? InitialDataStorageSizeInGb { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel? LicenseModelV2 { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DBSystemLifecycleState? LifecycleState { get { throw null; } }
        public int? ListenerPort { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkAnchorId { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceAnchorId { get { throw null; } set { } }
        public string ScanDnsName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ScanIPs { get { throw null; } }
        public string Shape { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode? StorageVolumePerformanceMode { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBSystemPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch>
    {
        public OracleDBSystemPatch() { }
        public Azure.ResourceManager.OracleDatabase.Models.DBSystemSourceType? DbSystemUpdateSource { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBSystemProperties : Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties>
    {
        public OracleDBSystemProperties(Azure.Core.ResourceIdentifier resourceAnchorId, Azure.Core.ResourceIdentifier networkAnchorId, string hostname, string shape, System.Collections.Generic.IEnumerable<string> sshPublicKeys, Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType databaseEdition, string dbVersion) : base (default(Azure.Core.ResourceIdentifier), default(Azure.Core.ResourceIdentifier), default(string), default(string), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string AdminPassword { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DBSystemDatabaseEditionType DatabaseEdition { get { throw null; } set { } }
        public string DBVersion { get { throw null; } set { } }
        public string PluggableDatabaseName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBSystemShapeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OracleDBSystemShapeProperties(int availableCoreCount) { }
        public bool? AreServerTypesSupported { get { throw null; } }
        public int AvailableCoreCount { get { throw null; } }
        public int? AvailableCoreCountPerNode { get { throw null; } }
        public int? AvailableDataStorageInTbs { get { throw null; } }
        public double? AvailableDataStoragePerServerInTbs { get { throw null; } }
        public int? AvailableDBNodePerNodeInGbs { get { throw null; } }
        public int? AvailableDBNodeStorageInGbs { get { throw null; } }
        public int? AvailableMemoryInGbs { get { throw null; } }
        public int? AvailableMemoryPerNodeInGbs { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseComputeModel? ComputeModel { get { throw null; } }
        public int? CoreCountIncrement { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? MaximumNodeCount { get { throw null; } }
        public int? MaxStorageCount { get { throw null; } }
        public int? MinCoreCountPerNode { get { throw null; } }
        public int? MinDataStorageInTbs { get { throw null; } }
        public int? MinDBNodeStoragePerNodeInGbs { get { throw null; } }
        public int? MinimumCoreCount { get { throw null; } }
        public int? MinimumNodeCount { get { throw null; } }
        public int? MinMemoryPerNodeInGbs { get { throw null; } }
        public int? MinStorageCount { get { throw null; } }
        public int? RuntimeMinimumCoreCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ShapeAttributes { get { throw null; } }
        public string ShapeFamily { get { throw null; } }
        public string ShapeName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBSystemShapeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDBVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties>
    {
        internal OracleDBVersionProperties() { }
        public bool? DoesSupportPluggableDatabase { get { throw null; } }
        public bool? IsLatestForMajorVersion { get { throw null; } }
        public bool? IsPreviewDbVersion { get { throw null; } }
        public bool? IsUpgradeSupported { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDBVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDnsPrivateViewProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OracleDnsPrivateViewProperties(Azure.Core.ResourceIdentifier ocid, bool isProtected, string self, System.DateTimeOffset createdOn, System.DateTimeOffset updatedOn) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState DnsPrivateViewLifecycleState { get { throw null; } }
        public string DnsPrivateViewOcid { get { throw null; } }
        public bool IsProtected { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState? LifecycleState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Self { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateViewProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleDnsPrivateZoneProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This constructor is obsolete and will be removed in a future release", false)]
        public OracleDnsPrivateZoneProperties(Azure.Core.ResourceIdentifier ocid, bool isProtected, string self, int serial, string version, Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType zoneType, System.DateTimeOffset createdOn) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState DnsPrivateZoneLifecycleState { get { throw null; } }
        public bool IsProtected { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState? LifecycleState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Self { get { throw null; } }
        public int Serial { get { throw null; } }
        public string Version { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier ViewId { get { throw null; } }
        public string ViewOcid { get { throw null; } }
        public string ZoneOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType ZoneType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleDnsPrivateZoneType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleDnsPrivateZoneType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType Primary { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType left, Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType left, Azure.ResourceManager.OracleDatabase.Models.OracleDnsPrivateZoneType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleFlexComponentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties>
    {
        internal OracleFlexComponentProperties() { }
        public int? AvailableCoreCount { get { throw null; } }
        public int? AvailableDBStorageInGbs { get { throw null; } }
        public int? AvailableLocalStorageInGbs { get { throw null; } }
        public int? AvailableMemoryInGbs { get { throw null; } }
        public string ComputeModel { get { throw null; } }
        public string DescriptionSummary { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.FlexComponentHardwareType? HardwareType { get { throw null; } }
        public int? MinimumCoreCount { get { throw null; } }
        public int? RuntimeMinimumCoreCount { get { throw null; } }
        public string Shape { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleFlexComponentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleGIMinorVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties>
    {
        internal OracleGIMinorVersionProperties() { }
        public string GridImageOcid { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleGIMinorVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleLicenseModel : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleLicenseModel(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel BringYourOwnLicense { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel left, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel left, Azure.ResourceManager.OracleDatabase.Models.OracleLicenseModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleNetworkAnchorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch>
    {
        public OracleNetworkAnchorPatch() { }
        public Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleNetworkAnchorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties>
    {
        public OracleNetworkAnchorProperties(string resourceAnchorId, Azure.Core.ResourceIdentifier subnetId) { }
        public string CidrBlock { get { throw null; } }
        public string DnsForwardingEndpointIPAddress { get { throw null; } }
        public System.Uri DnsForwardingEndpointNsgRulesUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.NetworkAnchorDnsForwardingRule> DnsForwardingRules { get { throw null; } }
        public System.Uri DnsForwardingRulesUri { get { throw null; } }
        public string DnsListeningEndpointAllowedCidrs { get { throw null; } set { } }
        public string DnsListeningEndpointIPAddress { get { throw null; } }
        public System.Uri DnsListeningEndpointNsgRulesUri { get { throw null; } }
        public bool? IsOracleDnsForwardingEndpointEnabled { get { throw null; } set { } }
        public bool? IsOracleDnsListeningEndpointEnabled { get { throw null; } set { } }
        public bool? IsOracleToAzureDnsZoneSyncEnabled { get { throw null; } set { } }
        public string OciBackupCidrBlock { get { throw null; } set { } }
        public string OciSubnetId { get { throw null; } }
        public string OciVcnDnsLabel { get { throw null; } set { } }
        public string OciVcnId { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceAnchorId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleNetworkAnchorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleResourceAnchorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch>
    {
        public OracleResourceAnchorPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleResourceAnchorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties>
    {
        public OracleResourceAnchorProperties() { }
        public string LinkedCompartmentId { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleResourceAnchorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleSubscriptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>
    {
        public OracleSubscriptionPatch() { }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleSubscriptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>
    {
        public OracleSubscriptionProperties() { }
        public Azure.ResourceManager.OracleDatabase.Models.AddSubscriptionOperationState? AddSubscriptionOperationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AzureSubscriptionIds { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier CloudAccountId { get { throw null; } }
        public string CloudAccountOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState? CloudAccountState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent? Intent { get { throw null; } set { } }
        public string LastOperationStatusDetail { get { throw null; } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public string SaasSubscriptionId { get { throw null; } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleSubscriptionProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleSubscriptionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleSubscriptionUpdateIntent : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleSubscriptionUpdateIntent(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent Reset { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent Retain { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent left, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent left, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleSubscriptionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>
    {
        public OracleSubscriptionUpdateProperties() { }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateIntent? Intent { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateIPAddressesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public PrivateIPAddressesContent(Azure.Core.ResourceIdentifier subnetId, Azure.Core.ResourceIdentifier vnicId) { }
        public PrivateIPAddressesContent(string subnetOcid, string vnicOcid) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public string SubnetOcid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier VnicId { get { throw null; } }
        public string VnicOcid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateIPAddressResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult>
    {
        internal PrivateIPAddressResult() { }
        public string DisplayName { get { throw null; } }
        public string HostnameLabel { get { throw null; } }
        public string IPAddress { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier Ocid { get { throw null; } }
        public string PrivateIPAddressesOcid { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public string SubnetOcid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefreshableModelType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefreshableModelType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType Automatic { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType left, Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType left, Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefreshableStatusType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefreshableStatusType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType NotRefreshing { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType Refreshing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType left, Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType left, Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoveVirtualMachineFromExadbVmClusterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails>
    {
        public RemoveVirtualMachineFromExadbVmClusterDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails> dbNodes) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.DBNodeDetails> DBNodes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RemoveVirtualMachineFromExadbVmClusterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RepeatCadenceType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RepeatCadenceType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType Monthly { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType OneTime { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType Weekly { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType left, Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType left, Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreAutonomousDatabaseDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>
    {
        public RestoreAutonomousDatabaseDetails(System.DateTimeOffset timestamp) { }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasSubscriptionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>
    {
        internal SaasSubscriptionDetails() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } }
        public bool? IsFreeTrial { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PlanId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public string PurchaserEmailId { get { throw null; } }
        public string PurchaserTenantId { get { throw null; } }
        public string SaasSubscriptionStatus { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TermUnit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledOperationsType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>
    {
        public ScheduledOperationsType(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeek dayOfWeek) { }
        public System.DateTimeOffset? AutoStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? AutoStopOn { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName? DayOfWeekName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledOperationsTypeUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>
    {
        public ScheduledOperationsTypeUpdate() { }
        public ScheduledOperationsTypeUpdate(Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate dayOfWeek) { }
        public System.DateTimeOffset? AutoStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? AutoStopOn { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekUpdate DayOfWeek { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleDatabaseDayOfWeekName? DayOfWeekName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShapeFamilyType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShapeFamilyType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType Exadata { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType ExadbXS { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType SingleNode { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType VirtualMachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType left, Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType left, Azure.ResourceManager.OracleDatabase.Models.ShapeFamilyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageManagementType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.StorageManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageManagementType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.StorageManagementType Lvm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.StorageManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.StorageManagementType left, Azure.ResourceManager.OracleDatabase.Models.StorageManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.StorageManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.StorageManagementType left, Azure.ResourceManager.OracleDatabase.Models.StorageManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageVolumePerformanceMode : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageVolumePerformanceMode(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode Balanced { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode HighPerformance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode left, Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode left, Azure.ResourceManager.OracleDatabase.Models.StorageVolumePerformanceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyntaxFormatType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyntaxFormatType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType Ezconnect { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType EzconnectPlus { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType Long { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType left, Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType left, Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkAddressLifecycleState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkAddressLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState Terminating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState left, Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WalletGenerateType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WalletGenerateType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType All { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType left, Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType left, Azure.ResourceManager.OracleDatabase.Models.WalletGenerateType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
