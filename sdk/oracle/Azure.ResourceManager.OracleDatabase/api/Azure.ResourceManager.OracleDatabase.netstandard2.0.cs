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
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string autonomousdatabasename) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Failover(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> FailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Switchover(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> SwitchoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.AutonomousDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutonomousDbVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>, System.Collections.IEnumerable
    {
        protected AutonomousDbVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> Get(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>> GetAsync(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> GetIfExists(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>> GetIfExistsAsync(string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutonomousDbVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>
    {
        public AutonomousDbVersionData() { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDbVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutonomousDbVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string autonomousdbversionsname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudexadatainfrastructurename) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbServerResource> GetDbServer(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbServerResource>> GetDbServerAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DbServerCollection GetDbServers() { throw null; }
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
        Azure.ResourceManager.OracleDatabase.CloudVmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.CloudVmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.CloudVmClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudVmClusterResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> AddVms(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> AddVmsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbNodeResource> GetDbNode(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbNodeResource>> GetDbNodeAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DbNodeCollection GetDbNodes() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties> GetPrivateIPAddresses(Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties> GetPrivateIPAddressesAsync(Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> GetVirtualNetworkAddress(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>> GetVirtualNetworkAddressAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressCollection GetVirtualNetworkAddresses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> RemoveVms(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> RemoveVmsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DbNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DbNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DbNodeResource>, System.Collections.IEnumerable
    {
        protected DbNodeCollection() { }
        public virtual Azure.Response<bool> Exists(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbNodeResource> Get(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.DbNodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.DbNodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbNodeResource>> GetAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DbNodeResource> GetIfExists(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DbNodeResource>> GetIfExistsAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.DbNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DbNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.DbNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DbNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DbNodeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>
    {
        public DbNodeData() { }
        public Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.DbNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DbNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbNodeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DbNodeResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.DbNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.DbNodeResource> Action(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DbNodeAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.DbNodeResource>> ActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.Models.DbNodeAction body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername, string dbnodeocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.DbNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DbNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DbServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DbServerResource>, System.Collections.IEnumerable
    {
        protected DbServerCollection() { }
        public virtual Azure.Response<bool> Exists(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbServerResource> Get(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.DbServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.DbServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbServerResource>> GetAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DbServerResource> GetIfExists(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DbServerResource>> GetIfExistsAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.DbServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DbServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.DbServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DbServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DbServerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>
    {
        public DbServerData() { }
        public Azure.ResourceManager.OracleDatabase.Models.DbServerProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.DbServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DbServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DbServerResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.DbServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudexadatainfrastructurename, string dbserverocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.DbServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DbServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbSystemShapeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>, System.Collections.IEnumerable
    {
        protected DbSystemShapeCollection() { }
        public virtual Azure.Response<bool> Exists(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> Get(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>> GetAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> GetIfExists(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>> GetIfExistsAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DbSystemShapeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>
    {
        public DbSystemShapeData() { }
        public Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.DbSystemShapeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DbSystemShapeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbSystemShapeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DbSystemShapeResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.DbSystemShapeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dbsystemshapename) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.DbSystemShapeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DbSystemShapeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DbSystemShapeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsPrivateViewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>, System.Collections.IEnumerable
    {
        protected DnsPrivateViewCollection() { }
        public virtual Azure.Response<bool> Exists(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> Get(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>> GetAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> GetIfExists(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>> GetIfExistsAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsPrivateViewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>
    {
        public DnsPrivateViewData() { }
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.DnsPrivateViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DnsPrivateViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsPrivateViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsPrivateViewResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.DnsPrivateViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dnsprivateviewocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.DnsPrivateViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DnsPrivateViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsPrivateZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>, System.Collections.IEnumerable
    {
        protected DnsPrivateZoneCollection() { }
        public virtual Azure.Response<bool> Exists(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> Get(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>> GetAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> GetIfExists(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>> GetIfExistsAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsPrivateZoneData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>
    {
        public DnsPrivateZoneData() { }
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsPrivateZoneResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsPrivateZoneResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dnsprivatezonename) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GiVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.GiVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.GiVersionResource>, System.Collections.IEnumerable
    {
        protected GiVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource> Get(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.GiVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.GiVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource>> GetAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.GiVersionResource> GetIfExists(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.GiVersionResource>> GetIfExistsAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.GiVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.GiVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.GiVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.GiVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GiVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.GiVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>
    {
        public GiVersionData() { }
        public string GiVersion { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.GiVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.GiVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GiVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.GiVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GiVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.GiVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string giversionname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.GiVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.GiVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.GiVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> GetAutonomousDbVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>> GetAutonomousDbVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource GetAutonomousDbVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDbVersionCollection GetAutonomousDbVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructure(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource>> GetCloudExadataInfrastructureAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource GetCloudExadataInfrastructureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureCollection GetCloudExadataInfrastructures(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructures(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructuresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource>> GetCloudVmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterResource GetCloudVmClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterCollection GetCloudVmClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DbNodeResource GetDbNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DbServerResource GetDbServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> GetDbSystemShape(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>> GetDbSystemShapeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DbSystemShapeResource GetDbSystemShapeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DbSystemShapeCollection GetDbSystemShapes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> GetDnsPrivateView(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>> GetDnsPrivateViewAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource GetDnsPrivateViewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DnsPrivateViewCollection GetDnsPrivateViews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> GetDnsPrivateZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>> GetDnsPrivateZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource GetDnsPrivateZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DnsPrivateZoneCollection GetDnsPrivateZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource> GetGiVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource>> GetGiVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.GiVersionResource GetGiVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.GiVersionCollection GetGiVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource> GetSystemVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource>> GetSystemVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.SystemVersionResource GetSystemVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.SystemVersionCollection GetSystemVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource GetVirtualNetworkAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class OracleSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.OracleSubscriptionData>
    {
        public OracleSubscriptionData() { }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.OracleSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.OracleSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks> GetActivationLinks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>> GetActivationLinksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SystemVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.SystemVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.SystemVersionResource>, System.Collections.IEnumerable
    {
        protected SystemVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource> Get(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.SystemVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.SystemVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource>> GetAsync(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.SystemVersionResource> GetIfExists(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.SystemVersionResource>> GetIfExistsAsync(string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.SystemVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.SystemVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.SystemVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.SystemVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SystemVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>
    {
        public SystemVersionData() { }
        public string SystemVersion { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.SystemVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.SystemVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SystemVersionResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.SystemVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string systemversionname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.SystemVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.SystemVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.SystemVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworkAddressCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkAddressCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualnetworkaddressname, Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualnetworkaddressname, Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> Get(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>> GetAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> GetIfExists(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>> GetIfExistsAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkAddressData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>
    {
        public VirtualNetworkAddressData() { }
        public Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworkAddressResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkAddressResource() { }
        public virtual Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername, string virtualnetworkaddressname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource GetAutonomousDbVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource GetCloudExadataInfrastructureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.CloudVmClusterResource GetCloudVmClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DbNodeResource GetDbNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DbServerResource GetDbServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DbSystemShapeResource GetDbSystemShapeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource GetDnsPrivateViewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource GetDnsPrivateZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.GiVersionResource GetGiVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.SystemVersionResource GetSystemVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressResource GetVirtualNetworkAddressResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource> GetAutonomousDbVersion(Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.AutonomousDbVersionResource>> GetAutonomousDbVersionAsync(Azure.Core.AzureLocation location, string autonomousdbversionsname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.AutonomousDbVersionCollection GetAutonomousDbVersions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureResource> GetCloudExadataInfrastructuresAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OracleDatabase.CloudVmClusterResource> GetCloudVmClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource> GetDbSystemShape(Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DbSystemShapeResource>> GetDbSystemShapeAsync(Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DbSystemShapeCollection GetDbSystemShapes(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource> GetDnsPrivateView(Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateViewResource>> GetDnsPrivateViewAsync(Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DnsPrivateViewCollection GetDnsPrivateViews(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource> GetDnsPrivateZone(Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.DnsPrivateZoneResource>> GetDnsPrivateZoneAsync(Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.DnsPrivateZoneCollection GetDnsPrivateZones(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource> GetGiVersion(Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.GiVersionResource>> GetGiVersionAsync(Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.GiVersionCollection GetGiVersions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.OracleSubscriptionResource GetOracleSubscription() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource> GetSystemVersion(Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OracleDatabase.SystemVersionResource>> GetSystemVersionAsync(Azure.Core.AzureLocation location, string systemversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OracleDatabase.SystemVersionCollection GetSystemVersions(Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class ActivationLinks : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>
    {
        internal ActivationLinks() { }
        public string ExistingCloudAccountActivationLink { get { throw null; } }
        public string NewCloudAccountActivationLink { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.ActivationLinks System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ActivationLinks System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ActivationLinks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddRemoveDbNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode>
    {
        public AddRemoveDbNode(System.Collections.Generic.IEnumerable<string> dbServers) { }
        public System.Collections.Generic.IList<string> DbServers { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AddRemoveDbNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AllConnectionStringType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType>
    {
        internal AllConnectionStringType() { }
        public string High { get { throw null; } }
        public string Low { get { throw null; } }
        public string Medium { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApexDetailsType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType>
    {
        internal ApexDetailsType() { }
        public string ApexVersion { get { throw null; } }
        public string OrdsVersion { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmOracleDatabaseModelFactory
    {
        public static Azure.ResourceManager.OracleDatabase.Models.ActivationLinks ActivationLinks(string newCloudAccountActivationLink = null, string existingCloudAccountActivationLink = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType AllConnectionStringType(string high = null, string low = null, string medium = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType ApexDetailsType(string apexVersion = null, string ordsVersion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseBackupData AutonomousDatabaseBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties AutonomousDatabaseBackupProperties(string autonomousDatabaseOcid = null, double? databaseSizeInTbs = default(double?), string dbVersion = null, string displayName = null, string ocid = null, bool? isAutomatic = default(bool?), bool? isRestorable = default(bool?), string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState?), int? retentionPeriodInDays = default(int?), double? sizeInTbs = default(double?), System.DateTimeOffset? timeAvailableTil = default(System.DateTimeOffset?), string timeStarted = null, string timeEnded = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType? backupType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType?), Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties AutonomousDatabaseBaseProperties(string adminPassword = null, string dataBaseType = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.ComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.ComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.WorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.WorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDbIds = null, string peerDbId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDb = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.LicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.LicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceBegin = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceEnd = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupTimeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.OpenModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.OpenModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.RoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.RoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, string timeDataGuardRoleChanged = null, string timeDeletionOfFreeAutonomousDatabase = null, string timeLocalDataGuardEnabled = null, string timeOfLastFailover = null, string timeOfLastRefresh = null, string timeOfLastRefreshPoint = null, string timeOfLastSwitchover = null, string timeReclamationOfFreeAutonomousDatabase = null, int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string ocid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseCharacterSetData AutonomousDatabaseCharacterSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string autonomousDatabaseCharacterSet = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties AutonomousDatabaseCloneProperties(string adminPassword = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.ComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.ComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.WorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.WorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDbIds = null, string peerDbId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDb = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.LicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.LicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceBegin = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceEnd = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupTimeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.OpenModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.OpenModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.RoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.RoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, string timeDataGuardRoleChanged = null, string timeDeletionOfFreeAutonomousDatabase = null, string timeLocalDataGuardEnabled = null, string timeOfLastFailover = null, string timeOfLastRefresh = null, string timeOfLastRefreshPoint = null, string timeOfLastSwitchover = null, string timeReclamationOfFreeAutonomousDatabase = null, int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string ocid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null, Azure.ResourceManager.OracleDatabase.Models.SourceType? source = default(Azure.ResourceManager.OracleDatabase.Models.SourceType?), Azure.Core.ResourceIdentifier sourceId = null, Azure.ResourceManager.OracleDatabase.Models.CloneType cloneType = default(Azure.ResourceManager.OracleDatabase.Models.CloneType), bool? isReconnectCloneEnabled = default(bool?), bool? isRefreshableClone = default(bool?), Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType? refreshableModel = default(Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType?), Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType? refreshableStatus = default(Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType?), string timeUntilReconnectCloneEnabled = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseData AutonomousDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDatabaseNationalCharacterSetData AutonomousDatabaseNationalCharacterSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string autonomousDatabaseNationalCharacterSet = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties AutonomousDatabaseProperties(string adminPassword = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? autonomousMaintenanceScheduleType = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType?), string characterSet = null, float? computeCount = default(float?), Azure.ResourceManager.OracleDatabase.Models.ComputeModel? computeModel = default(Azure.ResourceManager.OracleDatabase.Models.ComputeModel?), int? cpuCoreCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> customerContacts = null, int? dataStorageSizeInTbs = default(int?), int? dataStorageSizeInGbs = default(int?), string dbVersion = null, Azure.ResourceManager.OracleDatabase.Models.WorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.WorkloadType?), string displayName = null, bool? isAutoScalingEnabled = default(bool?), bool? isAutoScalingForStorageEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> peerDbIds = null, string peerDbId = null, bool? isLocalDataGuardEnabled = default(bool?), bool? isRemoteDataGuardEnabled = default(bool?), Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? localDisasterRecoveryType = default(Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary localStandbyDb = null, int? failedDataRecoveryInSeconds = default(int?), bool? isMtlsConnectionRequired = default(bool?), bool? isPreviewVersionWithServiceTermsAccepted = default(bool?), Azure.ResourceManager.OracleDatabase.Models.LicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.LicenseModel?), string ncharacterSet = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType scheduledOperations = null, string privateEndpointIP = null, string privateEndpointLabel = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier vnetId = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceBegin = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceEnd = default(System.DateTimeOffset?), double? actualUsedDataStorageSizeInTbs = default(double?), double? allocatedStorageSizeInTbs = default(double?), Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType apexDetails = null, System.Collections.Generic.IEnumerable<string> availableUpgradeVersions = null, Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType connectionStrings = null, Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType connectionUrls = null, Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? dataSafeStatus = default(Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType?), Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType? databaseEdition = default(Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType?), Azure.Core.ResourceIdentifier autonomousDatabaseId = null, int? inMemoryAreaInGbs = default(int?), System.DateTimeOffset? nextLongTermBackupTimeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails longTermBackupSchedule = null, bool? isPreview = default(bool?), int? localAdgAutoFailoverMaxDataLossLimit = default(int?), int? memoryPerOracleComputeUnitInGbs = default(int?), Azure.ResourceManager.OracleDatabase.Models.OpenModeType? openMode = default(Azure.ResourceManager.OracleDatabase.Models.OpenModeType?), Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? operationsInsightsStatus = default(Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType?), Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType? permissionLevel = default(Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType?), string privateEndpoint = null, System.Collections.Generic.IEnumerable<int> provisionableCpus = null, Azure.ResourceManager.OracleDatabase.Models.RoleType? role = default(Azure.ResourceManager.OracleDatabase.Models.RoleType?), System.Uri serviceConsoleUri = null, System.Uri sqlWebDeveloperUri = null, System.Collections.Generic.IEnumerable<string> supportedRegionsToCloneTo = null, string timeDataGuardRoleChanged = null, string timeDeletionOfFreeAutonomousDatabase = null, string timeLocalDataGuardEnabled = null, string timeOfLastFailover = null, string timeOfLastRefresh = null, string timeOfLastRefreshPoint = null, string timeOfLastSwitchover = null, string timeReclamationOfFreeAutonomousDatabase = null, int? usedDataStorageSizeInGbs = default(int?), int? usedDataStorageSizeInTbs = default(int?), string ocid = null, int? backupRetentionPeriodInDays = default(int?), System.Collections.Generic.IEnumerable<string> whitelistedIPs = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary AutonomousDatabaseStandbySummary(int? lagTimeInSeconds = default(int?), Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState?), string lifecycleDetails = null, string timeDataGuardRoleChanged = null, string timeDisasterRecoveryRoleChanged = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile AutonomousDatabaseWalletFile(string walletFiles = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.AutonomousDbVersionData AutonomousDbVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties AutonomousDbVersionProperties(string version = null, Azure.ResourceManager.OracleDatabase.Models.WorkloadType? dbWorkload = default(Azure.ResourceManager.OracleDatabase.Models.WorkloadType?), bool? isDefaultForFree = default(bool?), bool? isDefaultForPaid = default(bool?), bool? isFreeTierEnabled = default(bool?), bool? isPaidEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails CloudAccountDetails(string cloudAccountName = null, string cloudAccountHomeRegion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudExadataInfrastructureData CloudExadataInfrastructureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureProperties CloudExadataInfrastructureProperties(string ocid = null, int? computeCount = default(int?), int? storageCount = default(int?), int? totalStorageSizeInGbs = default(int?), int? availableStorageSizeInGbs = default(int?), string timeCreated = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow maintenanceWindow = null, Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime estimatedPatchingTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> customerContacts = null, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState?), string shape = null, System.Uri ociUri = null, int? cpuCount = default(int?), int? maxCpuCount = default(int?), int? memorySizeInGbs = default(int?), int? maxMemoryInGbs = default(int?), int? dbNodeStorageSizeInGbs = default(int?), int? maxDbNodeStorageSizeInGbs = default(int?), double? dataStorageSizeInTbs = default(double?), double? maxDataStorageInTbs = default(double?), string dbServerVersion = null, string storageServerVersion = null, int? activatedStorageCount = default(int?), int? additionalStorageCount = default(int?), string displayName = null, string lastMaintenanceRunId = null, string nextMaintenanceRunId = null, string monthlyDbServerVersion = null, string monthlyStorageServerVersion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.CloudVmClusterData CloudVmClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties CloudVmClusterProperties(string ocid = null, long? listenerPort = default(long?), int? nodeCount = default(int?), int? storageSizeInGbs = default(int?), double? dataStorageSizeInTbs = default(double?), int? dbNodeStorageSizeInGbs = default(int?), int? memorySizeInGbs = default(int?), System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), string lifecycleDetails = null, string timeZone = null, string zoneId = null, string hostname = null, string domain = null, int cpuCoreCount = 0, float? ocpuCount = default(float?), string clusterName = null, int? dataStoragePercentage = default(int?), bool? isLocalBackupEnabled = default(bool?), Azure.Core.ResourceIdentifier cloudExadataInfrastructureId = null, bool? isSparseDiskgroupEnabled = default(bool?), string systemVersion = null, System.Collections.Generic.IEnumerable<string> sshPublicKeys = null, Azure.ResourceManager.OracleDatabase.Models.LicenseModel? licenseModel = default(Azure.ResourceManager.OracleDatabase.Models.LicenseModel?), Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy? diskRedundancy = default(Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy?), System.Collections.Generic.IEnumerable<string> scanIPIds = null, System.Collections.Generic.IEnumerable<string> vipIds = null, string scanDnsName = null, int? scanListenerPortTcp = default(int?), int? scanListenerPortTcpSsl = default(int?), string scanDnsRecordId = null, string shape = null, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState?), Azure.Core.ResourceIdentifier vnetId = null, string giVersion = null, System.Uri ociUri = null, System.Uri nsgUri = null, Azure.Core.ResourceIdentifier subnetId = null, string backupSubnetCidr = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.NsgCidr> nsgCidrs = null, Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig dataCollectionOptions = null, string displayName = null, System.Collections.Generic.IEnumerable<string> computeNodes = null, Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig iormConfigCache = null, string lastUpdateHistoryEntryId = null, System.Collections.Generic.IEnumerable<string> dbServers = null, string compartmentId = null, string subnetOcid = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType ConnectionStringType(Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType allConnectionStrings = null, string dedicated = null, string high = null, string low = null, string medium = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.ProfileType> profiles = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType ConnectionUrlType(System.Uri apexUri = null, System.Uri databaseTransformsUri = null, System.Uri graphStudioUri = null, System.Uri machineLearningNotebookUri = null, System.Uri mongoDbUri = null, System.Uri ordsUri = null, System.Uri sqlDevWebUri = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbIormConfig DbIormConfig(string dbName = null, string flashCacheLimit = null, int? share = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DbNodeData DbNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties DbNodeProperties(string ocid = null, string additionalDetails = null, string backupIPId = null, string backupVnic2Id = null, string backupVnicId = null, int? cpuCoreCount = default(int?), int? dbNodeStorageSizeInGbs = default(int?), string dbServerId = null, string dbSystemId = null, string faultDomain = null, string hostIPId = null, string hostname = null, Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState?), string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType? maintenanceType = default(Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType?), int? memorySizeInGbs = default(int?), int? softwareStorageSizeInGb = default(int?), System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceWindowEnd = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceWindowStart = default(System.DateTimeOffset?), string vnic2Id = null, string vnicId = null, Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DbServerData DbServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.DbServerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails DbServerPatchingDetails(int? estimatedPatchDuration = default(int?), Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus? patchingStatus = default(Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus?), System.DateTimeOffset? timePatchingEnded = default(System.DateTimeOffset?), System.DateTimeOffset? timePatchingStarted = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerProperties DbServerProperties(string ocid = null, string displayName = null, string compartmentId = null, string exadataInfrastructureId = null, int? cpuCoreCount = default(int?), Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails dbServerPatchingDetails = null, int? maxMemoryInGbs = default(int?), int? dbNodeStorageSizeInGbs = default(int?), System.Collections.Generic.IEnumerable<string> vmClusterIds = null, System.Collections.Generic.IEnumerable<string> dbNodeIds = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState?), int? maxCpuCount = default(int?), System.Collections.Generic.IEnumerable<string> autonomousVmClusterIds = null, System.Collections.Generic.IEnumerable<string> autonomousVirtualMachineIds = null, int? maxDbNodeStorageInGbs = default(int?), int? memorySizeInGbs = default(int?), string shape = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DbSystemShapeData DbSystemShapeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties DbSystemShapeProperties(string shapeFamily = null, int availableCoreCount = 0, int? minimumCoreCount = default(int?), int? runtimeMinimumCoreCount = default(int?), int? coreCountIncrement = default(int?), int? minStorageCount = default(int?), int? maxStorageCount = default(int?), double? availableDataStoragePerServerInTbs = default(double?), int? availableMemoryPerNodeInGbs = default(int?), int? availableDbNodePerNodeInGbs = default(int?), int? minCoreCountPerNode = default(int?), int? availableMemoryInGbs = default(int?), int? minMemoryPerNodeInGbs = default(int?), int? availableDbNodeStorageInGbs = default(int?), int? minDbNodeStoragePerNodeInGbs = default(int?), int? availableDataStorageInTbs = default(int?), int? minDataStorageInTbs = default(int?), int? minimumNodeCount = default(int?), int? maximumNodeCount = default(int?), int? availableCoreCountPerNode = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DnsPrivateViewData DnsPrivateViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties DnsPrivateViewProperties(string ocid = null, string displayName = null, bool isProtected = false, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState?), string self = null, System.DateTimeOffset timeCreated = default(System.DateTimeOffset), System.DateTimeOffset timeUpdated = default(System.DateTimeOffset), Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.DnsPrivateZoneData DnsPrivateZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties DnsPrivateZoneProperties(string ocid = null, bool isProtected = false, Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState?), string self = null, int serial = 0, string version = null, string viewId = null, Azure.ResourceManager.OracleDatabase.Models.ZoneType zoneType = default(Azure.ResourceManager.OracleDatabase.Models.ZoneType), System.DateTimeOffset timeCreated = default(System.DateTimeOffset), Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime EstimatedPatchingTime(int? estimatedDbServerPatchingTime = default(int?), int? estimatedNetworkSwitchesPatchingTime = default(int?), int? estimatedStorageServerPatchingTime = default(int?), int? totalEstimatedPatchingTime = default(int?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig ExadataIormConfig(System.Collections.Generic.IEnumerable<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig> dbPlans = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState?), Azure.ResourceManager.OracleDatabase.Models.Objective? objective = default(Azure.ResourceManager.OracleDatabase.Models.Objective?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails GenerateAutonomousDatabaseWalletDetails(Azure.ResourceManager.OracleDatabase.Models.GenerateType? generateType = default(Azure.ResourceManager.OracleDatabase.Models.GenerateType?), bool? isRegional = default(bool?), string password = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.GiVersionData GiVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string giVersion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.OracleSubscriptionData OracleSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties properties = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties OracleSubscriptionProperties(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState?), string saasSubscriptionId = null, string cloudAccountId = null, Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState? cloudAccountState = default(Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState?), string termUnit = null, string productCode = null, Azure.ResourceManager.OracleDatabase.Models.Intent? intent = default(Azure.ResourceManager.OracleDatabase.Models.Intent?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties PrivateIPAddressProperties(string displayName = null, string hostnameLabel = null, string ocid = null, string ipAddress = null, string subnetId = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ProfileType ProfileType(Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup? consumerGroup = default(Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup?), string displayName = null, Azure.ResourceManager.OracleDatabase.Models.HostFormatType hostFormat = default(Azure.ResourceManager.OracleDatabase.Models.HostFormatType), bool? isRegional = default(bool?), Azure.ResourceManager.OracleDatabase.Models.ProtocolType protocol = default(Azure.ResourceManager.OracleDatabase.Models.ProtocolType), Azure.ResourceManager.OracleDatabase.Models.SessionModeType sessionMode = default(Azure.ResourceManager.OracleDatabase.Models.SessionModeType), Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType syntaxFormat = default(Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType), Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType? tlsAuthentication = default(Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType?), string value = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails SaasSubscriptionDetails(string id = null, string subscriptionName = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), string offerId = null, string planId = null, string saasSubscriptionStatus = null, string publisherId = null, string purchaserEmailId = null, string purchaserTenantId = null, string termUnit = null, bool? isAutoRenew = default(bool?), bool? isFreeTrial = default(bool?)) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.SystemVersionData SystemVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string systemVersion = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.VirtualNetworkAddressData VirtualNetworkAddressData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties VirtualNetworkAddressProperties(string ipAddress = null, string vmOcid = null, string ocid = null, string domain = null, string lifecycleDetails = null, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? provisioningState = default(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState?), Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState? lifecycleState = default(Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState?), System.DateTimeOffset? timeAssigned = default(System.DateTimeOffset?)) { throw null; }
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
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseBackupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupProperties>
    {
        public AutonomousDatabaseBackupProperties() { }
        public string AutonomousDatabaseOcid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupType? BackupType { get { throw null; } }
        public double? DatabaseSizeInTbs { get { throw null; } }
        public string DbVersion { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsAutomatic { get { throw null; } }
        public bool? IsRestorable { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBackupLifecycleState? LifecycleState { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int? RetentionPeriodInDays { get { throw null; } set { } }
        public double? SizeInTbs { get { throw null; } }
        public System.DateTimeOffset? TimeAvailableTil { get { throw null; } }
        public string TimeEnded { get { throw null; } }
        public string TimeStarted { get { throw null; } }
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
        public Azure.ResourceManager.OracleDatabase.Models.ApexDetailsType ApexDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier AutonomousDatabaseId { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousMaintenanceScheduleType? AutonomousMaintenanceScheduleType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> AvailableUpgradeVersions { get { throw null; } }
        public int? BackupRetentionPeriodInDays { get { throw null; } set { } }
        public string CharacterSet { get { throw null; } set { } }
        public float? ComputeCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ComputeModel? ComputeModel { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType ConnectionStrings { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType ConnectionUrls { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> CustomerContacts { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType? DatabaseEdition { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DataSafeStatusType? DataSafeStatus { get { throw null; } }
        public int? DataStorageSizeInGbs { get { throw null; } set { } }
        public int? DataStorageSizeInTbs { get { throw null; } set { } }
        public string DbVersion { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.WorkloadType? DbWorkload { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public int? FailedDataRecoveryInSeconds { get { throw null; } }
        public int? InMemoryAreaInGbs { get { throw null; } }
        public bool? IsAutoScalingEnabled { get { throw null; } set { } }
        public bool? IsAutoScalingForStorageEnabled { get { throw null; } set { } }
        public bool? IsLocalDataGuardEnabled { get { throw null; } set { } }
        public bool? IsMtlsConnectionRequired { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } }
        public bool? IsPreviewVersionWithServiceTermsAccepted { get { throw null; } set { } }
        public bool? IsRemoteDataGuardEnabled { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.LicenseModel? LicenseModel { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? LifecycleState { get { throw null; } }
        public int? LocalAdgAutoFailoverMaxDataLossLimit { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DisasterRecoveryType? LocalDisasterRecoveryType { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary LocalStandbyDb { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails LongTermBackupSchedule { get { throw null; } set { } }
        public int? MemoryPerOracleComputeUnitInGbs { get { throw null; } }
        public string NcharacterSet { get { throw null; } set { } }
        public System.DateTimeOffset? NextLongTermBackupTimeStamp { get { throw null; } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.OpenModeType? OpenMode { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OperationsInsightsStatusType? OperationsInsightsStatus { get { throw null; } }
        public string PeerDbId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PeerDbIds { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType? PermissionLevel { get { throw null; } set { } }
        public string PrivateEndpoint { get { throw null; } }
        public string PrivateEndpointIP { get { throw null; } set { } }
        public string PrivateEndpointLabel { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<int> ProvisionableCpus { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.RoleType? Role { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType ScheduledOperations { get { throw null; } set { } }
        public System.Uri ServiceConsoleUri { get { throw null; } }
        public System.Uri SqlWebDeveloperUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedRegionsToCloneTo { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string TimeDataGuardRoleChanged { get { throw null; } }
        public string TimeDeletionOfFreeAutonomousDatabase { get { throw null; } }
        public string TimeLocalDataGuardEnabled { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceBegin { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceEnd { get { throw null; } }
        public string TimeOfLastFailover { get { throw null; } }
        public string TimeOfLastRefresh { get { throw null; } }
        public string TimeOfLastRefreshPoint { get { throw null; } }
        public string TimeOfLastSwitchover { get { throw null; } }
        public string TimeReclamationOfFreeAutonomousDatabase { get { throw null; } }
        public int? UsedDataStorageSizeInGbs { get { throw null; } }
        public int? UsedDataStorageSizeInTbs { get { throw null; } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> WhitelistedIPs { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseCloneProperties : Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>
    {
        public AutonomousDatabaseCloneProperties(Azure.Core.ResourceIdentifier sourceId, Azure.ResourceManager.OracleDatabase.Models.CloneType cloneType) { }
        public Azure.ResourceManager.OracleDatabase.Models.CloneType CloneType { get { throw null; } set { } }
        public bool? IsReconnectCloneEnabled { get { throw null; } }
        public bool? IsRefreshableClone { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.RefreshableModelType? RefreshableModel { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.RefreshableStatusType? RefreshableStatus { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.SourceType? Source { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        public string TimeUntilReconnectCloneEnabled { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseCloneProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AutonomousDatabasePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>
    {
        public AutonomousDatabasePatch() { }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabasePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseProperties : Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>
    {
        public AutonomousDatabaseProperties() { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDatabaseStandbySummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseStandbySummary>
    {
        internal AutonomousDatabaseStandbySummary() { }
        public int? LagTimeInSeconds { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseLifecycleState? LifecycleState { get { throw null; } }
        public string TimeDataGuardRoleChanged { get { throw null; } }
        public string TimeDisasterRecoveryRoleChanged { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> CustomerContacts { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType? DatabaseEdition { get { throw null; } set { } }
        public int? DataStorageSizeInGbs { get { throw null; } set { } }
        public int? DataStorageSizeInTbs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsAutoScalingEnabled { get { throw null; } set { } }
        public bool? IsAutoScalingForStorageEnabled { get { throw null; } set { } }
        public bool? IsLocalDataGuardEnabled { get { throw null; } set { } }
        public bool? IsMtlsConnectionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.LicenseModel? LicenseModel { get { throw null; } set { } }
        public int? LocalAdgAutoFailoverMaxDataLossLimit { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails LongTermBackupSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OpenModeType? OpenMode { get { throw null; } set { } }
        public string PeerDbId { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType? PermissionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.RoleType? Role { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate ScheduledOperations { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> WhitelistedIPs { get { throw null; } }
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
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDatabaseWalletFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutonomousDbVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties>
    {
        public AutonomousDbVersionProperties(string version) { }
        public Azure.ResourceManager.OracleDatabase.Models.WorkloadType? DbWorkload { get { throw null; } }
        public bool? IsDefaultForFree { get { throw null; } }
        public bool? IsDefaultForPaid { get { throw null; } }
        public bool? IsFreeTierEnabled { get { throw null; } }
        public bool? IsPaidEnabled { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.AutonomousDbVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureResourceProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloneType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.CloneType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloneType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.CloneType Full { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.CloneType Metadata { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.CloneType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.CloneType left, Azure.ResourceManager.OracleDatabase.Models.CloneType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.CloneType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.CloneType left, Azure.ResourceManager.OracleDatabase.Models.CloneType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudAccountDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudAccountDetails>
    {
        internal CloudAccountDetails() { }
        public string CloudAccountHomeRegion { get { throw null; } }
        public string CloudAccountName { get { throw null; } }
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
        public int? CpuCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> CustomerContacts { get { throw null; } }
        public double? DataStorageSizeInTbs { get { throw null; } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } }
        public string DbServerVersion { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime EstimatedPatchingTime { get { throw null; } }
        public string LastMaintenanceRunId { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureLifecycleState? LifecycleState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? MaxCpuCount { get { throw null; } }
        public double? MaxDataStorageInTbs { get { throw null; } }
        public int? MaxDbNodeStorageSizeInGbs { get { throw null; } }
        public int? MaxMemoryInGbs { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string MonthlyDbServerVersion { get { throw null; } }
        public string MonthlyStorageServerVersion { get { throw null; } }
        public string NextMaintenanceRunId { get { throw null; } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Shape { get { throw null; } set { } }
        public int? StorageCount { get { throw null; } set { } }
        public string StorageServerVersion { get { throw null; } }
        public string TimeCreated { get { throw null; } }
        public int? TotalStorageSizeInGbs { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.CustomerContact> CustomerContacts { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? StorageCount { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudExadataInfrastructureUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CloudVmClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>
    {
        public CloudVmClusterPatch() { }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>
    {
        public CloudVmClusterProperties(string hostname, int cpuCoreCount, Azure.Core.ResourceIdentifier cloudExadataInfrastructureId, System.Collections.Generic.IEnumerable<string> sshPublicKeys, Azure.Core.ResourceIdentifier vnetId, string giVersion, Azure.Core.ResourceIdentifier subnetId, string displayName) { }
        public string BackupSubnetCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CloudExadataInfrastructureId { get { throw null; } set { } }
        public string ClusterName { get { throw null; } set { } }
        public string CompartmentId { get { throw null; } }
        public System.Collections.Generic.IList<string> ComputeNodes { get { throw null; } }
        public int CpuCoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig DataCollectionOptions { get { throw null; } set { } }
        public int? DataStoragePercentage { get { throw null; } set { } }
        public double? DataStorageSizeInTbs { get { throw null; } set { } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DbServers { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy? DiskRedundancy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string GiVersion { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig IormConfigCache { get { throw null; } }
        public bool? IsLocalBackupEnabled { get { throw null; } set { } }
        public bool? IsSparseDiskgroupEnabled { get { throw null; } set { } }
        public string LastUpdateHistoryEntryId { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.LicenseModel? LicenseModel { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterLifecycleState? LifecycleState { get { throw null; } }
        public long? ListenerPort { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.NsgCidr> NsgCidrs { get { throw null; } }
        public System.Uri NsgUri { get { throw null; } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public float? OcpuCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string ScanDnsName { get { throw null; } }
        public string ScanDnsRecordId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ScanIPIds { get { throw null; } }
        public int? ScanListenerPortTcp { get { throw null; } set { } }
        public int? ScanListenerPortTcpSsl { get { throw null; } set { } }
        public string Shape { get { throw null; } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public int? StorageSizeInGbs { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string SubnetOcid { get { throw null; } }
        public string SystemVersion { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> VipIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        public string ZoneId { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>
    {
        public CloudVmClusterUpdateProperties() { }
        public System.Collections.Generic.IList<string> ComputeNodes { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig DataCollectionOptions { get { throw null; } set { } }
        public double? DataStorageSizeInTbs { get { throw null; } set { } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.LicenseModel? LicenseModel { get { throw null; } set { } }
        public int? MemorySizeInGbs { get { throw null; } set { } }
        public float? OcpuCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public int? StorageSizeInGbs { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CloudVmClusterUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeModel : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ComputeModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeModel(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ComputeModel Ecpu { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ComputeModel Ocpu { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ComputeModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ComputeModel left, Azure.ResourceManager.OracleDatabase.Models.ComputeModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ComputeModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ComputeModel left, Azure.ResourceManager.OracleDatabase.Models.ComputeModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectionStringType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType>
    {
        internal ConnectionStringType() { }
        public Azure.ResourceManager.OracleDatabase.Models.AllConnectionStringType AllConnectionStrings { get { throw null; } }
        public string Dedicated { get { throw null; } }
        public string High { get { throw null; } }
        public string Low { get { throw null; } }
        public string Medium { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OracleDatabase.Models.ProfileType> Profiles { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionStringType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionUrlType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType>
    {
        internal ConnectionUrlType() { }
        public System.Uri ApexUri { get { throw null; } }
        public System.Uri DatabaseTransformsUri { get { throw null; } }
        public System.Uri GraphStudioUri { get { throw null; } }
        public System.Uri MachineLearningNotebookUri { get { throw null; } }
        public System.Uri MongoDbUri { get { throw null; } }
        public System.Uri OrdsUri { get { throw null; } }
        public System.Uri SqlDevWebUri { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ConnectionUrlType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumerGroup : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumerGroup(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup High { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup Low { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup Medium { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup Tp { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup Tpurgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup left, Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup left, Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomerContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CustomerContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CustomerContact>
    {
        public CustomerContact(string email) { }
        public string Email { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.CustomerContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CustomerContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.CustomerContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.CustomerContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CustomerContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CustomerContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.CustomerContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseEditionType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseEditionType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType EnterpriseEdition { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType StandardEdition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType left, Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType left, Azure.ResourceManager.OracleDatabase.Models.DatabaseEditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig>
    {
        public DataCollectionConfig() { }
        public bool? IsDiagnosticsEventsEnabled { get { throw null; } set { } }
        public bool? IsHealthMonitoringEnabled { get { throw null; } set { } }
        public bool? IsIncidentLogsEnabled { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DataCollectionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DayOfWeek : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek>
    {
        public DayOfWeek(Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName name) { }
        public Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Name { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.DayOfWeek System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DayOfWeek System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DayOfWeekName : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DayOfWeekName(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Friday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Monday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Saturday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Sunday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Thursday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Tuesday { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName left, Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName left, Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DbIormConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig>
    {
        internal DbIormConfig() { }
        public string DbName { get { throw null; } }
        public string FlashCacheLimit { get { throw null; } }
        public int? Share { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DbIormConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DbIormConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbNodeAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeAction>
    {
        public DbNodeAction(Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum action) { }
        public Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum Action { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DbNodeAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DbNodeAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbNodeActionEnum : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbNodeActionEnum(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum Reset { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum SoftReset { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum Start { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum left, Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum left, Azure.ResourceManager.OracleDatabase.Models.DbNodeActionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbNodeMaintenanceType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbNodeMaintenanceType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType VmdbRebootMigration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType left, Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType left, Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DbNodeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties>
    {
        public DbNodeProperties(string ocid, string dbSystemId) { }
        public string AdditionalDetails { get { throw null; } }
        public string BackupIPId { get { throw null; } }
        public string BackupVnic2Id { get { throw null; } }
        public string BackupVnicId { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } }
        public string DbServerId { get { throw null; } }
        public string DbSystemId { get { throw null; } }
        public string FaultDomain { get { throw null; } }
        public string HostIPId { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState? LifecycleState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DbNodeMaintenanceType? MaintenanceType { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int? SoftwareStorageSizeInGb { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceWindowEnd { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceWindowStart { get { throw null; } }
        public string Vnic2Id { get { throw null; } }
        public string VnicId { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbNodeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbNodeProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbNodeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Starting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Stopped { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Stopping { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Terminated { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Terminating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DbNodeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DbServerPatchingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails>
    {
        internal DbServerPatchingDetails() { }
        public int? EstimatedPatchDuration { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus? PatchingStatus { get { throw null; } }
        public System.DateTimeOffset? TimePatchingEnded { get { throw null; } }
        public System.DateTimeOffset? TimePatchingStarted { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbServerPatchingStatus : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbServerPatchingStatus(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus left, Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus left, Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DbServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerProperties>
    {
        public DbServerProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AutonomousVirtualMachineIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AutonomousVmClusterIds { get { throw null; } }
        public string CompartmentId { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DbNodeIds { get { throw null; } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DbServerPatchingDetails DbServerPatchingDetails { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ExadataInfrastructureId { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState? LifecycleState { get { throw null; } }
        public int? MaxCpuCount { get { throw null; } }
        public int? MaxDbNodeStorageInGbs { get { throw null; } }
        public int? MaxMemoryInGbs { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Shape { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmClusterIds { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DbServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DbServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbServerProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbServerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.DbServerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DbSystemShapeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties>
    {
        public DbSystemShapeProperties(int availableCoreCount) { }
        public int AvailableCoreCount { get { throw null; } }
        public int? AvailableCoreCountPerNode { get { throw null; } }
        public int? AvailableDataStorageInTbs { get { throw null; } }
        public double? AvailableDataStoragePerServerInTbs { get { throw null; } }
        public int? AvailableDbNodePerNodeInGbs { get { throw null; } }
        public int? AvailableDbNodeStorageInGbs { get { throw null; } }
        public int? AvailableMemoryInGbs { get { throw null; } }
        public int? AvailableMemoryPerNodeInGbs { get { throw null; } }
        public int? CoreCountIncrement { get { throw null; } }
        public int? MaximumNodeCount { get { throw null; } }
        public int? MaxStorageCount { get { throw null; } }
        public int? MinCoreCountPerNode { get { throw null; } }
        public int? MinDataStorageInTbs { get { throw null; } }
        public int? MinDbNodeStoragePerNodeInGbs { get { throw null; } }
        public int? MinimumCoreCount { get { throw null; } }
        public int? MinimumNodeCount { get { throw null; } }
        public int? MinMemoryPerNodeInGbs { get { throw null; } }
        public int? MinStorageCount { get { throw null; } }
        public int? RuntimeMinimumCoreCount { get { throw null; } }
        public string ShapeFamily { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DbSystemShapeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct DiskRedundancy : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy High { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy left, Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy left, Azure.ResourceManager.OracleDatabase.Models.DiskRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsPrivateViewProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties>
    {
        public DnsPrivateViewProperties(string ocid, bool isProtected, string self, System.DateTimeOffset timeCreated, System.DateTimeOffset timeUpdated) { }
        public string DisplayName { get { throw null; } }
        public bool IsProtected { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewsLifecycleState? LifecycleState { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Self { get { throw null; } }
        public System.DateTimeOffset TimeCreated { get { throw null; } }
        public System.DateTimeOffset TimeUpdated { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateViewProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DnsPrivateZoneProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties>
    {
        public DnsPrivateZoneProperties(string ocid, bool isProtected, string self, int serial, string version, Azure.ResourceManager.OracleDatabase.Models.ZoneType zoneType, System.DateTimeOffset timeCreated) { }
        public bool IsProtected { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZonesLifecycleState? LifecycleState { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Self { get { throw null; } }
        public int Serial { get { throw null; } }
        public System.DateTimeOffset TimeCreated { get { throw null; } }
        public string Version { get { throw null; } }
        public string ViewId { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ZoneType ZoneType { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.DnsPrivateZoneProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public int? EstimatedDbServerPatchingTime { get { throw null; } }
        public int? EstimatedNetworkSwitchesPatchingTime { get { throw null; } }
        public int? EstimatedStorageServerPatchingTime { get { throw null; } }
        public int? TotalEstimatedPatchingTime { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.EstimatedPatchingTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExadataIormConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>
    {
        internal ExadataIormConfig() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OracleDatabase.Models.DbIormConfig> DbPlans { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.IormLifecycleState? LifecycleState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.Objective? Objective { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ExadataIormConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateAutonomousDatabaseWalletDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>
    {
        public GenerateAutonomousDatabaseWalletDetails(string password) { }
        public Azure.ResourceManager.OracleDatabase.Models.GenerateType? GenerateType { get { throw null; } set { } }
        public bool? IsRegional { get { throw null; } set { } }
        public string Password { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.GenerateAutonomousDatabaseWalletDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerateType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.GenerateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerateType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.GenerateType All { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.GenerateType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.GenerateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.GenerateType left, Azure.ResourceManager.OracleDatabase.Models.GenerateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.GenerateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.GenerateType left, Azure.ResourceManager.OracleDatabase.Models.GenerateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostFormatType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.HostFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostFormatType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.HostFormatType Fqdn { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.HostFormatType IP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.HostFormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.HostFormatType left, Azure.ResourceManager.OracleDatabase.Models.HostFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.HostFormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.HostFormatType left, Azure.ResourceManager.OracleDatabase.Models.HostFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Intent : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.Intent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Intent(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.Intent Reset { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.Intent Retain { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.Intent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.Intent left, Azure.ResourceManager.OracleDatabase.Models.Intent right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.Intent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.Intent left, Azure.ResourceManager.OracleDatabase.Models.Intent right) { throw null; }
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
    public readonly partial struct LicenseModel : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.LicenseModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseModel(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.LicenseModel BringYourOwnLicense { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.LicenseModel LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.LicenseModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.LicenseModel left, Azure.ResourceManager.OracleDatabase.Models.LicenseModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.LicenseModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.LicenseModel left, Azure.ResourceManager.OracleDatabase.Models.LicenseModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LongTermBackUpScheduleDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>
    {
        public LongTermBackUpScheduleDetails() { }
        public bool? IsDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.RepeatCadenceType? RepeatCadence { get { throw null; } set { } }
        public int? RetentionPeriodInDays { get { throw null; } set { } }
        public System.DateTimeOffset? TimeOfBackup { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.LongTermBackUpScheduleDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow>
    {
        public MaintenanceWindow() { }
        public int? CustomActionTimeoutInMins { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.DayOfWeek> DaysOfWeek { get { throw null; } }
        public System.Collections.Generic.IList<int> HoursOfDay { get { throw null; } }
        public bool? IsCustomActionTimeoutEnabled { get { throw null; } set { } }
        public bool? IsMonthlyPatchingEnabled { get { throw null; } set { } }
        public int? LeadTimeInWeeks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.OracleDatabase.Models.Month> Months { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.PatchingMode? PatchingMode { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.Preference? Preference { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> WeeksOfMonth { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.MaintenanceWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Month : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.Month>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.Month>
    {
        public Month(Azure.ResourceManager.OracleDatabase.Models.MonthName name) { }
        public Azure.ResourceManager.OracleDatabase.Models.MonthName Name { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.Month System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.Month>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.Month>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.Month System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.Month>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.Month>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.Month>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonthName : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.MonthName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonthName(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName April { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName August { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName December { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName February { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName January { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName July { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName June { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName March { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName May { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName November { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName October { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.MonthName September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.MonthName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.MonthName left, Azure.ResourceManager.OracleDatabase.Models.MonthName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.MonthName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.MonthName left, Azure.ResourceManager.OracleDatabase.Models.MonthName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NsgCidr : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NsgCidr>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NsgCidr>
    {
        public NsgCidr(string source) { }
        public Azure.ResourceManager.OracleDatabase.Models.PortRange DestinationPortRange { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.NsgCidr System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NsgCidr>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.NsgCidr>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.NsgCidr System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NsgCidr>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NsgCidr>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.NsgCidr>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Objective : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.Objective>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Objective(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.Objective Auto { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.Objective Balanced { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.Objective Basic { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.Objective HighThroughput { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.Objective LowLatency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.Objective other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.Objective left, Azure.ResourceManager.OracleDatabase.Models.Objective right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.Objective (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.Objective left, Azure.ResourceManager.OracleDatabase.Models.Objective right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenModeType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.OpenModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenModeType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.OpenModeType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.OpenModeType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.OpenModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.OpenModeType left, Azure.ResourceManager.OracleDatabase.Models.OpenModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.OpenModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.OpenModeType left, Azure.ResourceManager.OracleDatabase.Models.OpenModeType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class OracleSubscriptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>
    {
        public OracleSubscriptionPatch() { }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleSubscriptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProperties>
    {
        public OracleSubscriptionProperties() { }
        public string CloudAccountId { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.CloudAccountProvisioningState? CloudAccountState { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.Intent? Intent { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        public Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public string SaasSubscriptionId { get { throw null; } }
        public string TermUnit { get { throw null; } set { } }
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
    public partial class OracleSubscriptionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>
    {
        public OracleSubscriptionUpdateProperties() { }
        public Azure.ResourceManager.OracleDatabase.Models.Intent? Intent { get { throw null; } set { } }
        public string ProductCode { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.OracleSubscriptionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchingMode : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.PatchingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchingMode(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.PatchingMode NonRolling { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.PatchingMode Rolling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.PatchingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.PatchingMode left, Azure.ResourceManager.OracleDatabase.Models.PatchingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.PatchingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.PatchingMode left, Azure.ResourceManager.OracleDatabase.Models.PatchingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeerDbDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails>
    {
        public PeerDbDetails() { }
        public string PeerDbId { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PeerDbDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PermissionLevelType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PermissionLevelType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType Restricted { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType Unrestricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType left, Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType left, Azure.ResourceManager.OracleDatabase.Models.PermissionLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PortRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PortRange>
    {
        public PortRange(int min, int max) { }
        public int Max { get { throw null; } set { } }
        public int Min { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.PortRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PortRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PortRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PortRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PortRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PortRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PortRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Preference : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.Preference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Preference(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.Preference CustomPreference { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.Preference NoPreference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.Preference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.Preference left, Azure.ResourceManager.OracleDatabase.Models.Preference right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.Preference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.Preference left, Azure.ResourceManager.OracleDatabase.Models.Preference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateIPAddressesFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter>
    {
        public PrivateIPAddressesFilter(string subnetId, string vnicId) { }
        public string SubnetId { get { throw null; } }
        public string VnicId { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressesFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateIPAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties>
    {
        internal PrivateIPAddressProperties() { }
        public string DisplayName { get { throw null; } }
        public string HostnameLabel { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string Ocid { get { throw null; } }
        public string SubnetId { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.PrivateIPAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ProfileType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ProfileType>
    {
        internal ProfileType() { }
        public Azure.ResourceManager.OracleDatabase.Models.ConsumerGroup? ConsumerGroup { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.HostFormatType HostFormat { get { throw null; } }
        public bool? IsRegional { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.ProtocolType Protocol { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.SessionModeType SessionMode { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType SyntaxFormat { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType? TlsAuthentication { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.ProfileType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ProfileType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ProfileType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ProfileType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ProfileType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ProfileType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ProfileType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtocolType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ProtocolType TCP { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ProtocolType Tcps { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ProtocolType left, Azure.ResourceManager.OracleDatabase.Models.ProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ProtocolType left, Azure.ResourceManager.OracleDatabase.Models.ProtocolType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState left, Azure.ResourceManager.OracleDatabase.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreAutonomousDatabaseDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>
    {
        public RestoreAutonomousDatabaseDetails(System.DateTimeOffset timestamp) { }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.RestoreAutonomousDatabaseDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.RoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.RoleType BackupCopy { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RoleType DisabledStandby { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RoleType Primary { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RoleType SnapshotStandby { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.RoleType Standby { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.RoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.RoleType left, Azure.ResourceManager.OracleDatabase.Models.RoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.RoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.RoleType left, Azure.ResourceManager.OracleDatabase.Models.RoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaasSubscriptionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>
    {
        internal SaasSubscriptionDetails() { }
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
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.SaasSubscriptionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledOperationsType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>
    {
        public ScheduledOperationsType(Azure.ResourceManager.OracleDatabase.Models.DayOfWeek dayOfWeek) { }
        public Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName? DayOfWeekName { get { throw null; } set { } }
        public string ScheduledStartTime { get { throw null; } set { } }
        public string ScheduledStopTime { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledOperationsTypeUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>
    {
        public ScheduledOperationsTypeUpdate() { }
        public Azure.ResourceManager.OracleDatabase.Models.DayOfWeekName? DayOfWeekName { get { throw null; } set { } }
        public string ScheduledStartTime { get { throw null; } set { } }
        public string ScheduledStopTime { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.ScheduledOperationsTypeUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionModeType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.SessionModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionModeType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.SessionModeType Direct { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SessionModeType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.SessionModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.SessionModeType left, Azure.ResourceManager.OracleDatabase.Models.SessionModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.SessionModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.SessionModeType left, Azure.ResourceManager.OracleDatabase.Models.SessionModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.SourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.SourceType BackupFromId { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SourceType BackupFromTimestamp { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SourceType CloneToRefreshable { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SourceType CrossRegionDataguard { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SourceType CrossRegionDisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SourceType Database { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SourceType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.SourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.SourceType left, Azure.ResourceManager.OracleDatabase.Models.SourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.SourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.SourceType left, Azure.ResourceManager.OracleDatabase.Models.SourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyntaxFormatType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyntaxFormatType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType Ezconnect { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.SyntaxFormatType Ezconnectplus { get { throw null; } }
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
    public readonly partial struct TlsAuthenticationType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType Mutual { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType Server { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType left, Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType left, Azure.ResourceManager.OracleDatabase.Models.TlsAuthenticationType right) { throw null; }
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
    public partial class VirtualNetworkAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties>
    {
        public VirtualNetworkAddressProperties() { }
        public string Domain { get { throw null; } }
        public string IPAddress { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressLifecycleState? LifecycleState { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.OracleDatabase.Models.AzureResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? TimeAssigned { get { throw null; } }
        public string VmOcid { get { throw null; } set { } }
        Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OracleDatabase.Models.VirtualNetworkAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.WorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.WorkloadType AJD { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.WorkloadType Apex { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.WorkloadType DW { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.WorkloadType Oltp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.WorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.WorkloadType left, Azure.ResourceManager.OracleDatabase.Models.WorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.WorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.WorkloadType left, Azure.ResourceManager.OracleDatabase.Models.WorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneType : System.IEquatable<Azure.ResourceManager.OracleDatabase.Models.ZoneType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneType(string value) { throw null; }
        public static Azure.ResourceManager.OracleDatabase.Models.ZoneType Primary { get { throw null; } }
        public static Azure.ResourceManager.OracleDatabase.Models.ZoneType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OracleDatabase.Models.ZoneType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OracleDatabase.Models.ZoneType left, Azure.ResourceManager.OracleDatabase.Models.ZoneType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OracleDatabase.Models.ZoneType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OracleDatabase.Models.ZoneType left, Azure.ResourceManager.OracleDatabase.Models.ZoneType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
