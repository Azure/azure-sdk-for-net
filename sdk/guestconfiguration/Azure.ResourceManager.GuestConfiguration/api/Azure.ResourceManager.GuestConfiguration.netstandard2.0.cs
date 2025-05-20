namespace Azure.ResourceManager.GuestConfiguration
{
    public partial class AzureResourceManagerGuestConfigurationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerGuestConfigurationContext() { }
        public static Azure.ResourceManager.GuestConfiguration.AzureResourceManagerGuestConfigurationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class GuestConfigurationAssignmentData : Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>
    {
        public GuestConfigurationAssignmentData() { }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class GuestConfigurationExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetGuestConfigurationHcrpAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetGuestConfigurationHcrpAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource GetGuestConfigurationHcrpAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentCollection GetGuestConfigurationHcrpAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetGuestConfigurationVmAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource GetGuestConfigurationVmAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentCollection GetGuestConfigurationVmAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetGuestConfigurationVmssAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetGuestConfigurationVmssAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource GetGuestConfigurationVmssAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentCollection GetGuestConfigurationVmssAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> GetGuestConfigurationVMwarevSphereAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>> GetGuestConfigurationVMwarevSphereAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource GetGuestConfigurationVMwarevSphereAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentCollection GetGuestConfigurationVMwarevSphereAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class GuestConfigurationHcrpAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>, System.Collections.IEnumerable
    {
        protected GuestConfigurationHcrpAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> Get(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetIfExists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetIfExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestConfigurationHcrpAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestConfigurationHcrpAssignmentResource() { }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName, string guestConfigurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReport(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>> GetReportAsync(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReports(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReportsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestConfigurationVmAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>, System.Collections.IEnumerable
    {
        protected GuestConfigurationVmAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> Get(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetIfExists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetIfExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestConfigurationVmAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestConfigurationVmAssignmentResource() { }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string guestConfigurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReport(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>> GetReportAsync(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReports(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReportsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestConfigurationVmssAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>, System.Collections.IEnumerable
    {
        protected GuestConfigurationVmssAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestConfigurationVmssAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestConfigurationVmssAssignmentResource() { }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmssName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReport(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>> GetReportAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReports(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReportsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestConfigurationVMwarevSphereAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>, System.Collections.IEnumerable
    {
        protected GuestConfigurationVMwarevSphereAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> Get(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>> GetAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> GetIfExists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>> GetIfExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestConfigurationVMwarevSphereAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestConfigurationVMwarevSphereAssignmentResource() { }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string guestConfigurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReport(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReportAsync(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReports(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReportsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.GuestConfiguration.Mocking
{
    public partial class MockableGuestConfigurationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableGuestConfigurationArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetGuestConfigurationHcrpAssignment(Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetGuestConfigurationHcrpAssignmentAsync(Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource GetGuestConfigurationHcrpAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentCollection GetGuestConfigurationHcrpAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignment(Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetGuestConfigurationVmAssignmentAsync(Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource GetGuestConfigurationVmAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentCollection GetGuestConfigurationVmAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetGuestConfigurationVmssAssignment(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetGuestConfigurationVmssAssignmentAsync(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource GetGuestConfigurationVmssAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentCollection GetGuestConfigurationVmssAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource> GetGuestConfigurationVMwarevSphereAssignment(Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource>> GetGuestConfigurationVMwarevSphereAssignmentAsync(Azure.Core.ResourceIdentifier scope, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentResource GetGuestConfigurationVMwarevSphereAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationVMwarevSphereAssignmentCollection GetGuestConfigurationVMwarevSphereAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableGuestConfigurationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGuestConfigurationResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableGuestConfigurationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGuestConfigurationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetAllGuestConfigurationAssignmentDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.GuestConfiguration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionAfterReboot : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionAfterReboot(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot ContinueConfiguration { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot StopConfiguration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot left, Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot left, Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmGuestConfigurationModelFactory
    {
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason AssignmentReportResourceComplianceReason(string phrase = null, string code = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo AssignmentReportResourceInfo(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? complianceStatus = default(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus?), string assignmentResourceSettingName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason> reasons = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData GuestConfigurationAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo GuestConfigurationAssignmentInfo(string name = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo configuration = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties GuestConfigurationAssignmentProperties(string targetResourceId = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation guestConfiguration = null, Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? complianceStatus = default(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus?), System.DateTimeOffset? lastComplianceStatusCheckedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier latestReportId = null, string parameterHash = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo latestAssignmentReport = null, string context = null, string assignmentHash = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState?), string resourceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo> vmssVmList = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport GuestConfigurationAssignmentReport(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties properties = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails GuestConfigurationAssignmentReportDetails(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? complianceStatus = default(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Guid? jobId = default(System.Guid?), Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType? operationType = default(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo> resources = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo GuestConfigurationAssignmentReportInfo(Azure.Core.ResourceIdentifier id = null, System.Guid? reportId = default(System.Guid?), Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo assignment = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo vm = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? complianceStatus = default(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus?), Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType? operationType = default(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo> resources = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties GuestConfigurationAssignmentReportProperties(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? complianceStatus = default(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus?), System.Guid? reportId = default(System.Guid?), Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo assignment = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo vm = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails details = null, string vmssResourceId = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo GuestConfigurationInfo(string name = null, string version = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation GuestConfigurationNavigation(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind? kind, string name, string version, System.Uri contentUri, string contentHash, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType? assignmentType, string assignmentSource, string contentType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter> configurationParameters, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter> configurationProtectedParameters, Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting configurationSetting) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation GuestConfigurationNavigation(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind? kind = default(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind?), string name = null, string version = null, System.Uri contentUri = null, string contentHash = null, string contentManagedIdentity = null, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType? assignmentType = default(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType?), string assignmentSource = null, string contentType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter> configurationParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter> configurationProtectedParameters = null, Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting configurationSetting = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData GuestConfigurationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo GuestConfigurationVmInfo(Azure.Core.ResourceIdentifier id = null, System.Guid? uuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo GuestConfigurationVmssVmInfo(System.Guid? vmId = default(System.Guid?), Azure.Core.ResourceIdentifier vmResourceId = null, Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? complianceStatus = default(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus?), System.Guid? latestReportId = default(System.Guid?), System.DateTimeOffset? lastComplianceCheckedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting LcmConfigurationSetting(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode? configurationMode = default(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode?), bool? isModuleOverwriteAllowed = default(bool?), Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot? actionAfterReboot = default(Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot?), float? refreshFrequencyInMins = default(float?), bool? rebootIfNeeded = default(bool?), float? configurationModeFrequencyInMins = default(float?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignedGuestConfigurationMachineComplianceStatus : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignedGuestConfigurationMachineComplianceStatus(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus Compliant { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus left, Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus left, Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssignmentReportResourceComplianceReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason>
    {
        public AssignmentReportResourceComplianceReason() { }
        public string Code { get { throw null; } }
        public string Phrase { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssignmentReportResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo>
    {
        public AssignmentReportResourceInfo() { }
        public string AssignmentResourceSettingName { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason> Reasons { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationAssignmentInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo>
    {
        public GuestConfigurationAssignmentInfo() { }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo Configuration { get { throw null; } set { } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationAssignmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties>
    {
        public GuestConfigurationAssignmentProperties() { }
        public string AssignmentHash { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public string Context { get { throw null; } set { } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation GuestConfiguration { get { throw null; } set { } }
        public System.DateTimeOffset? LastComplianceStatusCheckedOn { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo LatestAssignmentReport { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LatestReportId { get { throw null; } }
        public string ParameterHash { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo> VmssVmList { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationAssignmentReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>
    {
        internal GuestConfigurationAssignmentReport() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationAssignmentReportDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails>
    {
        internal GuestConfigurationAssignmentReportDetails() { }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Guid? JobId { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType? OperationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo> Resources { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationAssignmentReportInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo>
    {
        public GuestConfigurationAssignmentReportInfo() { }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo Assignment { get { throw null; } set { } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType? OperationType { get { throw null; } }
        public System.Guid? ReportId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo> Resources { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo Vm { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationAssignmentReportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties>
    {
        internal GuestConfigurationAssignmentReportProperties() { }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo Assignment { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails Details { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Guid? ReportId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo Vm { get { throw null; } }
        public string VmssResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationAssignmentReportType : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationAssignmentReportType(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType Consistency { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationAssignmentType : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType ApplyAndAutoCorrect { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType ApplyAndMonitor { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType Audit { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType DeployAndAutoCorrect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestConfigurationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo>
    {
        public GuestConfigurationInfo() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationKind : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationKind(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind Dsc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestConfigurationNavigation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation>
    {
        public GuestConfigurationNavigation() { }
        public string AssignmentSource { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType? AssignmentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter> ConfigurationParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter> ConfigurationProtectedParameters { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting ConfigurationSetting { get { throw null; } }
        public string ContentHash { get { throw null; } set { } }
        public string ContentManagedIdentity { get { throw null; } set { } }
        public string ContentType { get { throw null; } }
        public System.Uri ContentUri { get { throw null; } set { } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter>
    {
        public GuestConfigurationParameter() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestConfigurationResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData>
    {
        public GuestConfigurationResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationVmInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo>
    {
        public GuestConfigurationVmInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Guid? Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestConfigurationVmssVmInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo>
    {
        public GuestConfigurationVmssVmInfo() { }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.DateTimeOffset? LastComplianceCheckedOn { get { throw null; } }
        public System.Guid? LatestReportId { get { throw null; } }
        public System.Guid? VmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LcmConfigurationMode : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LcmConfigurationMode(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode ApplyAndAutoCorrect { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode ApplyAndMonitor { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode ApplyOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode left, Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode left, Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LcmConfigurationSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting>
    {
        internal LcmConfigurationSetting() { }
        public Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot? ActionAfterReboot { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode? ConfigurationMode { get { throw null; } }
        public float? ConfigurationModeFrequencyInMins { get { throw null; } }
        public bool? IsModuleOverwriteAllowed { get { throw null; } }
        public bool? RebootIfNeeded { get { throw null; } }
        public float? RefreshFrequencyInMins { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
