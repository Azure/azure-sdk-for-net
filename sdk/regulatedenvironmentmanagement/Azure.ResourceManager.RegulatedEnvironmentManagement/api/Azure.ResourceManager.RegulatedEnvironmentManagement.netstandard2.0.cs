namespace Azure.ResourceManager.RegulatedEnvironmentManagement
{
    public partial class LZAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>, System.Collections.IEnumerable
    {
        protected LZAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string landingZoneAccountName, Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string landingZoneAccountName, Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> Get(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> GetAsync(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetIfExists(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> GetIfExistsAsync(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LZAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>
    {
        public LZAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LZAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LZAccountResource() { }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string landingZoneAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetLZConfiguration(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>> GetLZConfigurationAsync(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationCollection GetLZConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetLZRegistration(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>> GetLZRegistrationAsync(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationCollection GetLZRegistrations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LZConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>, System.Collections.IEnumerable
    {
        protected LZConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string landingZoneConfigurationName, Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string landingZoneConfigurationName, Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> Get(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>> GetAsync(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetIfExists(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>> GetIfExistsAsync(string landingZoneConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LZConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>
    {
        public LZConfigurationData() { }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LZConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LZConfigurationResource() { }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult> CreateCopy(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>> CreateCopyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string landingZoneAccountName, string landingZoneConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult> GenerateLandingZone(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>> GenerateLandingZoneAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult> UpdateAuthoringStatus(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>> UpdateAuthoringStatusAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LZRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>, System.Collections.IEnumerable
    {
        protected LZRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string landingZoneRegistrationName, Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string landingZoneRegistrationName, Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> Get(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>> GetAsync(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetIfExists(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>> GetIfExistsAsync(string landingZoneRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LZRegistrationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>
    {
        public LZRegistrationData() { }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LZRegistrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LZRegistrationResource() { }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string landingZoneAccountName, string landingZoneRegistrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RegulatedEnvironmentManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetLZAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> GetLZAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource GetLZAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountCollection GetLZAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetLZAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetLZAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource GetLZConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetLZConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetLZConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource GetLZRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetLZRegistrations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetLZRegistrationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RegulatedEnvironmentManagement.Mocking
{
    public partial class MockableRegulatedEnvironmentManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRegulatedEnvironmentManagementArmClient() { }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource GetLZAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource GetLZConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource GetLZRegistrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRegulatedEnvironmentManagementResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRegulatedEnvironmentManagementResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetLZAccount(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource>> GetLZAccountAsync(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountCollection GetLZAccounts() { throw null; }
    }
    public partial class MockableRegulatedEnvironmentManagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRegulatedEnvironmentManagementSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetLZAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountResource> GetLZAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetLZConfigurations(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationResource> GetLZConfigurationsAsync(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetLZRegistrations(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationResource> GetLZRegistrationsAsync(string landingZoneAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RegulatedEnvironmentManagement.Models
{
    public static partial class ArmRegulatedEnvironmentManagementModelFactory
    {
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult CreateLZConfigurationCopyResult(Azure.Core.ResourceIdentifier copiedLandingZoneConfigurationId = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent GenerateLandingZoneContent(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption infrastructureAsCodeOutputOptions = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption), Azure.Core.ResourceIdentifier existingManagementSubscriptionId = null, Azure.Core.ResourceIdentifier existingIdentitySubscriptionId = null, Azure.Core.ResourceIdentifier existingConnectivitySubscriptionId = null, string subscriptionBillingScope = null, Azure.Core.ResourceIdentifier existingTopLevelMgParentId = null, string deploymentPrefix = null, string deploymentSuffix = null, string topLevelMgDisplayName = null, string deploymentLocation = null, string organization = null, string environment = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult GenerateLandingZoneResult(string topLevelMgDisplayName = null, string landingZoneConfigurationName = null, System.Uri generatedCodeUri = null, string storageAccountName = null, string containerName = null, string blobName = null, string generatedArmTemplate = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.LZAccountData LZAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties LZAccountProperties(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState?), Azure.Core.ResourceIdentifier storageAccount = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.LZConfigurationData LZConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties LZConfigurationProperties(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState?), Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus? authoringStatus = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus?), Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption ddosProtectionCreationOption = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption), Azure.Core.ResourceIdentifier existingDdosProtectionId = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption logAnalyticsWorkspaceCreationOption = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption), Azure.Core.ResourceIdentifier existingLogAnalyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags> tags = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption firewallCreationOption = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption), string firewallSubnetCidrBlock = null, string gatewaySubnetCidrBlock = null, long logRetentionInDays = (long)0, string hubNetworkCidrBlock = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption azureBastionCreationOption = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption), Azure.Core.ResourceIdentifier existingAzureBastionId = null, string azureBastionSubnetCidrBlock = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties> landingZonesMgChildren = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> topLevelMgMetadataPolicyInitiativesAssignmentProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> landingZonesMgMetadataPolicyInitiativesAssignmentProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> platformMgMetadataPolicyInitiativesAssignmentProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> platformManagementMgMetadataPolicyInitiativesAssignmentProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> platformConnectivityMgMetadataPolicyInitiativesAssignmentProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> platformIdentityMgMetadataPolicyInitiativesAssignmentProperties = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties decommissionedMgMetadata = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties sandboxMgMetadata = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties managedIdentity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties> platformMgChildren = null, string namingConventionFormula = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention> customNamingConvention = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.LZRegistrationData LZRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties LZRegistrationProperties(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState?), Azure.Core.ResourceIdentifier existingTopLevelMgId = null, Azure.Core.ResourceIdentifier existingLandingZoneConfigurationId = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties managedIdentity = null) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult UpdateAuthoringStatusResult(string landingZoneConfigurationName = null, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus authoringStatus = default(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthoringStatus : System.IEquatable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus Authoring { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus ReadyForUse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateLZConfigurationCopyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent>
    {
        public CreateLZConfigurationCopyContent(string name) { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateLZConfigurationCopyResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>
    {
        internal CreateLZConfigurationCopyResult() { }
        public Azure.Core.ResourceIdentifier CopiedLandingZoneConfigurationId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CreateLZConfigurationCopyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomNamingConvention : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention>
    {
        public CustomNamingConvention(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType resourceType, string formula) { }
        public string Formula { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DecommissionedManagementGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties>
    {
        public DecommissionedManagementGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> policyInitiativesAssignmentProperties, bool create) { }
        public bool Create { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PolicyInitiativesAssignmentProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallCreationOption : System.IEquatable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallCreationOption(string value) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption None { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption Premium { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateLandingZoneContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent>
    {
        public GenerateLandingZoneContent(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption infrastructureAsCodeOutputOptions, string deploymentPrefix, string topLevelMgDisplayName, string deploymentLocation) { }
        public string DeploymentLocation { get { throw null; } }
        public string DeploymentPrefix { get { throw null; } }
        public string DeploymentSuffix { get { throw null; } set { } }
        public string Environment { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingConnectivitySubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingIdentitySubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingManagementSubscriptionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingTopLevelMgParentId { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption InfrastructureAsCodeOutputOptions { get { throw null; } }
        public string Organization { get { throw null; } set { } }
        public string SubscriptionBillingScope { get { throw null; } set { } }
        public string TopLevelMgDisplayName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateLandingZoneResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>
    {
        internal GenerateLandingZoneResult() { }
        public string BlobName { get { throw null; } }
        public string ContainerName { get { throw null; } }
        public string GeneratedArmTemplate { get { throw null; } }
        public System.Uri GeneratedCodeUri { get { throw null; } }
        public string LandingZoneConfigurationName { get { throw null; } }
        public string StorageAccountName { get { throw null; } }
        public string TopLevelMgDisplayName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.GenerateLandingZoneResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureAsCodeOutputOption : System.IEquatable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureAsCodeOutputOption(string value) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption ARM { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption Bicep { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.InfrastructureAsCodeOutputOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LZAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties>
    {
        public LZAccountProperties(Azure.Core.ResourceIdentifier storageAccount) { }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZAccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LZConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties>
    {
        public LZConfigurationProperties(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption ddosProtectionCreationOption, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption logAnalyticsWorkspaceCreationOption, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption firewallCreationOption, string gatewaySubnetCidrBlock, long logRetentionInDays, string hubNetworkCidrBlock, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption azureBastionCreationOption, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties managedIdentity) { }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus? AuthoringStatus { get { throw null; } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption AzureBastionCreationOption { get { throw null; } set { } }
        public string AzureBastionSubnetCidrBlock { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.CustomNamingConvention> CustomNamingConvention { get { throw null; } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption DdosProtectionCreationOption { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.DecommissionedManagementGroupProperties DecommissionedMgMetadata { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingAzureBastionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingDdosProtectionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingLogAnalyticsWorkspaceId { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.FirewallCreationOption FirewallCreationOption { get { throw null; } set { } }
        public string FirewallSubnetCidrBlock { get { throw null; } set { } }
        public string GatewaySubnetCidrBlock { get { throw null; } set { } }
        public string HubNetworkCidrBlock { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties> LandingZonesMgChildren { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> LandingZonesMgMetadataPolicyInitiativesAssignmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption LogAnalyticsWorkspaceCreationOption { get { throw null; } set { } }
        public long LogRetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties ManagedIdentity { get { throw null; } set { } }
        public string NamingConventionFormula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PlatformConnectivityMgMetadataPolicyInitiativesAssignmentProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PlatformIdentityMgMetadataPolicyInitiativesAssignmentProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PlatformManagementMgMetadataPolicyInitiativesAssignmentProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties> PlatformMgChildren { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PlatformMgMetadataPolicyInitiativesAssignmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties SandboxMgMetadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> TopLevelMgMetadataPolicyInitiativesAssignmentProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LZManagementGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties>
    {
        public LZManagementGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> policyInitiativesAssignmentProperties, string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PolicyInitiativesAssignmentProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZManagementGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LZRegistrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties>
    {
        public LZRegistrationProperties(Azure.Core.ResourceIdentifier existingTopLevelMgId, Azure.Core.ResourceIdentifier existingLandingZoneConfigurationId) { }
        public Azure.Core.ResourceIdentifier ExistingLandingZoneConfigurationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingTopLevelMgId { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties ManagedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.LZRegistrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties>
    {
        public ManagedIdentityProperties(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType type) { }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType Type { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityResourceType : System.IEquatable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityResourceType(string value) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ManagedIdentityResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlatformManagementGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties>
    {
        public PlatformManagementGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> policyInitiativesAssignmentProperties, string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PolicyInitiativesAssignmentProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PlatformManagementGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyInitiativeAssignmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties>
    {
        public PolicyInitiativeAssignmentProperties(string policyInitiativeId, System.Collections.Generic.IDictionary<string, System.BinaryData> assignmentParameters) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AssignmentParameters { get { throw null; } }
        public string PolicyInitiativeId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceCreationOption : System.IEquatable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceCreationOption(string value) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption No { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption UseExisting { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceCreationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceType : System.IEquatable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceType(string value) { throw null; }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType AutomationAccounts { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType AzureFirewalls { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType BastionHosts { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType Dashboards { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType DdosProtectionPlans { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType NetworkSecurityGroups { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType RouteTables { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType UserAssignedIdentities { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType VirtualNetworks { get { throw null; } }
        public static Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType Workspaces { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType left, Azure.ResourceManager.RegulatedEnvironmentManagement.Models.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxManagementGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties>
    {
        public SandboxManagementGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> policyInitiativesAssignmentProperties, bool create) { }
        public bool Create { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.PolicyInitiativeAssignmentProperties> PolicyInitiativesAssignmentProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.SandboxManagementGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Tags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags>
    {
        public Tags(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.Tags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateAuthoringStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent>
    {
        public UpdateAuthoringStatusContent(Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus authoringStatus) { }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus AuthoringStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateAuthoringStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>
    {
        internal UpdateAuthoringStatusResult() { }
        public Azure.ResourceManager.RegulatedEnvironmentManagement.Models.AuthoringStatus AuthoringStatus { get { throw null; } }
        public string LandingZoneConfigurationName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RegulatedEnvironmentManagement.Models.UpdateAuthoringStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
