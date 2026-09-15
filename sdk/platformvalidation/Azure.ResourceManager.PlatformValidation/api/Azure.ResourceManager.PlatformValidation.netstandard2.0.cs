namespace Azure.ResourceManager.PlatformValidation
{
    public partial class AzureResourceManagerPlatformValidationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPlatformValidationContext() { }
        public static Azure.ResourceManager.PlatformValidation.AzureResourceManagerPlatformValidationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CloudValidationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.CloudValidationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.CloudValidationResource>, System.Collections.IEnumerable
    {
        protected CloudValidationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.CloudValidationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudValidationName, Azure.ResourceManager.PlatformValidation.CloudValidationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudValidationName, Azure.ResourceManager.PlatformValidation.CloudValidationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource> Get(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> GetAsync(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetIfExists(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> GetIfExistsAsync(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlatformValidation.CloudValidationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.CloudValidationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlatformValidation.CloudValidationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.CloudValidationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudValidationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>
    {
        public CloudValidationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.CloudValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.CloudValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudValidationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudValidationResource() { }
        public virtual Azure.ResourceManager.PlatformValidation.CloudValidationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudValidationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> GetValidationExecutionPlan(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> GetValidationExecutionPlanAsync(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanCollection GetValidationExecutionPlans() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlatformValidation.CloudValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.CloudValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.CloudValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.CloudValidationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExecutionPlanRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>, System.Collections.IEnumerable
    {
        protected ExecutionPlanRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string executionPlanRunName, Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string executionPlanRunName, Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> Get(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>> GetAsync(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> GetIfExists(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>> GetIfExistsAsync(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExecutionPlanRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>
    {
        public ExecutionPlanRunData() { }
        public Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionPlanRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExecutionPlanRunResource() { }
        public virtual Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudValidationName, string validationExecutionPlanName, string executionPlanRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> GetValidationTestRun(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>> GetValidationTestRunAsync(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestRunCollection GetValidationTestRuns() { throw null; }
        Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PlatformValidationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetCloudValidation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> GetCloudValidationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.CloudValidationResource GetCloudValidationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.CloudValidationCollection GetCloudValidations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetCloudValidations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetCloudValidationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource GetExecutionPlanRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource GetValidationExecutionPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource> GetValidationTest(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource>> GetValidationTestAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestCategoryCollection GetValidationTestCategories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> GetValidationTestCategory(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>> GetValidationTestCategoryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource GetValidationTestCategoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestResource GetValidationTestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestRunResource GetValidationTestRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestCollection GetValidationTests(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource GetValidationTestVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ValidationExecutionPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>, System.Collections.IEnumerable
    {
        protected ValidationExecutionPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string validationExecutionPlanName, Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string validationExecutionPlanName, Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> Get(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> GetAsync(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> GetIfExists(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> GetIfExistsAsync(string validationExecutionPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ValidationExecutionPlanData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>
    {
        public ValidationExecutionPlanData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationExecutionPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ValidationExecutionPlanResource() { }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudValidationName, string validationExecutionPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource> GetExecutionPlanRun(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource>> GetExecutionPlanRunAsync(string executionPlanRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ExecutionPlanRunCollection GetExecutionPlanRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ValidationTestCategoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>, System.Collections.IEnumerable
    {
        protected ValidationTestCategoryCollection() { }
        public virtual Azure.Response<bool> Exists(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> Get(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>> GetAsync(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> GetIfExists(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>> GetIfExistsAsync(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ValidationTestCategoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>
    {
        internal ValidationTestCategoryData() { }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestCategoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ValidationTestCategoryResource() { }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string validationTestCategoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestResource>, System.Collections.IEnumerable
    {
        protected ValidationTestCollection() { }
        public virtual Azure.Response<bool> Exists(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource> Get(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.ValidationTestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.ValidationTestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource>> GetAsync(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestResource> GetIfExists(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestResource>> GetIfExistsAsync(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ValidationTestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>
    {
        internal ValidationTestData() { }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ValidationTestResource() { }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string validationTestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> GetValidationTestVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>> GetValidationTestVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestVersionCollection GetValidationTestVersions() { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>, System.Collections.IEnumerable
    {
        protected ValidationTestRunCollection() { }
        public virtual Azure.Response<bool> Exists(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> Get(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>> GetAsync(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> GetIfExists(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>> GetIfExistsAsync(string validationTestRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ValidationTestRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>
    {
        internal ValidationTestRunData() { }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ValidationTestRunResource() { }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudValidationName, string validationExecutionPlanName, string executionPlanRunName, string validationTestRunName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>, System.Collections.IEnumerable
    {
        protected ValidationTestVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ValidationTestVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>
    {
        internal ValidationTestVersionData() { }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ValidationTestVersionResource() { }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string validationTestName, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlatformValidation.ValidationTestVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.ValidationTestVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.ValidationTestVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.PlatformValidation.Mocking
{
    public partial class MockablePlatformValidationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePlatformValidationArmClient() { }
        public virtual Azure.ResourceManager.PlatformValidation.CloudValidationResource GetCloudValidationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ExecutionPlanRunResource GetExecutionPlanRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanResource GetValidationExecutionPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource GetValidationTestCategoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestResource GetValidationTestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestRunResource GetValidationTestRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestVersionResource GetValidationTestVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePlatformValidationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlatformValidationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetCloudValidation(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.CloudValidationResource>> GetCloudValidationAsync(string cloudValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.CloudValidationCollection GetCloudValidations() { throw null; }
    }
    public partial class MockablePlatformValidationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlatformValidationSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetCloudValidations(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlatformValidation.CloudValidationResource> GetCloudValidationsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource> GetValidationTest(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestResource>> GetValidationTestAsync(string validationTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestCategoryCollection GetValidationTestCategories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource> GetValidationTestCategory(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlatformValidation.ValidationTestCategoryResource>> GetValidationTestCategoryAsync(string validationTestCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlatformValidation.ValidationTestCollection GetValidationTests() { throw null; }
    }
}
namespace Azure.ResourceManager.PlatformValidation.Models
{
    public static partial class ArmPlatformValidationModelFactory
    {
        public static Azure.ResourceManager.PlatformValidation.CloudValidationData CloudValidationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch CloudValidationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties CloudValidationProperties(string description = null, Azure.ResourceManager.PlatformValidation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PlatformValidation.Models.ProvisioningState?), Azure.ResponseError error = null, Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState? overallState = default(Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties CloudValidationUpdateProperties(string description = null, Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState? overallState = default(Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState?)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ExecutionPlanRunData ExecutionPlanRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties ExecutionPlanRunProperties(string description = null, Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus? status = default(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus?), Azure.ResponseError error = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), System.DateTimeOffset? reportedOn = default(System.DateTimeOffset?), Azure.ResourceManager.PlatformValidation.Models.TestRunSummary testRunSummary = null, string planConfigurationSnapshot = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> testRunIds = null, Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState? provisioningState = default(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo PlatformValidationMoboBrokerResourceInfo(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.TestRunSummary TestRunSummary(int? totalTests = default(int?), int? passedTests = default(int?), int? failedTests = default(int?), int? skippedTests = default(int?), Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult? overallResult = default(Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult?), string message = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationExecutionPlanData ValidationExecutionPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch ValidationExecutionPlanPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties ValidationExecutionPlanProperties(string description = null, string planConfigurationUri = null, string planConfigurationJson = null, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState? provisioningState = default(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState?), Azure.ResponseError error = null, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState? overallState = default(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState?)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties ValidationExecutionPlanUpdateProperties(string description = null, string planConfigurationUri = null, string planConfigurationJson = null, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState? overallState = default(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState?)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestCategoryData ValidationTestCategoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties ValidationTestCategoryProperties(string displayName = null, string description = null, Azure.ResourceManager.PlatformValidation.Models.CatalogAudience? audience = default(Azure.ResourceManager.PlatformValidation.Models.CatalogAudience?), Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState?), string parentCategoryId = null, System.Collections.Generic.IEnumerable<string> owners = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestData ValidationTestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails ValidationTestFailureDetails(string errorCode = null, string errorMessage = null, string details = null, string diagnosticInfo = null, System.Collections.Generic.IEnumerable<string> recommendedActions = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput ValidationTestInput(string name = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition definition = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition ValidationTestInputDefinition(string description = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType? type = default(Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType?), bool? required = default(bool?), string defaultValue = null, System.Collections.Generic.IEnumerable<string> allowedValues = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails ValidationTestPassDetails(string resultCode = null, string testName = null, string resultDetails = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties ValidationTestProperties(string description = null, Azure.ResourceManager.PlatformValidation.Models.CatalogAudience? audience = default(Azure.ResourceManager.PlatformValidation.Models.CatalogAudience?), Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState?), System.Collections.Generic.IEnumerable<string> categoryIds = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState? overallState = default(Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState?), System.Collections.Generic.IEnumerable<string> owners = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput> inputs = null, string testStoreUri = null, string currentVersion = null, string latestPublishedVersion = null, System.DateTimeOffset? lastPublishedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestRunData ValidationTestRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties ValidationTestRunProperties(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus? status = default(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus?), Azure.ResponseError error = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState? provisioningState = default(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), System.DateTimeOffset? reportedOn = default(System.DateTimeOffset?), string testId = null, string inputsJson = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails> passDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails> failureDetails = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.ValidationTestVersionData ValidationTestVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties ValidationTestVersionProperties(string description = null, Azure.ResourceManager.PlatformValidation.Models.CatalogAudience? audience = default(Azure.ResourceManager.PlatformValidation.Models.CatalogAudience?), Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState?), System.Collections.Generic.IEnumerable<string> categoryIds = null, Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState? overallState = default(Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState?), System.Collections.Generic.IEnumerable<string> owners = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput> inputs = null, string contentHash = null, string testStoreUri = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogAudience : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.CatalogAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogAudience(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.CatalogAudience Internal { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.CatalogAudience Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.CatalogAudience other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.CatalogAudience left, Azure.ResourceManager.PlatformValidation.Models.CatalogAudience right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.CatalogAudience (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.CatalogAudience? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.CatalogAudience left, Azure.ResourceManager.PlatformValidation.Models.CatalogAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudValidationOverallState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudValidationOverallState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState left, Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState left, Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudValidationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch>
    {
        public CloudValidationPatch() { }
        public Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties>
    {
        public CloudValidationProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState? OverallState { get { throw null; } set { } }
        public Azure.ResourceManager.PlatformValidation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudValidationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties>
    {
        public CloudValidationUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PlatformValidation.Models.CloudValidationOverallState? OverallState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.CloudValidationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionPlanRunProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties>
    {
        public ExecutionPlanRunProperties() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public string PlanConfigurationSnapshot { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> TestRunIds { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.TestRunSummary TestRunSummary { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionPlanRunProvisioningState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionPlanRunProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState Processing { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionPlanRunStatus : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionPlanRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus left, Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus left, Azure.ResourceManager.PlatformValidation.Models.ExecutionPlanRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlatformValidationMoboBrokerResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo>
    {
        internal PlatformValidationMoboBrokerResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.PlatformValidationMoboBrokerResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Disabling { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestRunOverallResult : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestRunOverallResult(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult Failed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult PartiallyPassed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult left, Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult left, Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TestRunSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.TestRunSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.TestRunSummary>
    {
        internal TestRunSummary() { }
        public int? FailedTests { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.TestRunOverallResult? OverallResult { get { throw null; } }
        public int? PassedTests { get { throw null; } }
        public int? SkippedTests { get { throw null; } }
        public int? TotalTests { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.TestRunSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.TestRunSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.TestRunSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.TestRunSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.TestRunSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.TestRunSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.TestRunSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.TestRunSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.TestRunSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationExecutionPlanOverallState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationExecutionPlanOverallState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState left, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState left, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationExecutionPlanPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch>
    {
        public ValidationExecutionPlanPatch() { }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationExecutionPlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties>
    {
        public ValidationExecutionPlanProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState? OverallState { get { throw null; } set { } }
        public string PlanConfigurationJson { get { throw null; } set { } }
        public string PlanConfigurationUri { get { throw null; } set { } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationExecutionPlanProvisioningState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationExecutionPlanProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationExecutionPlanUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties>
    {
        public ValidationExecutionPlanUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanOverallState? OverallState { get { throw null; } set { } }
        public string PlanConfigurationJson { get { throw null; } set { } }
        public string PlanConfigurationUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationExecutionPlanUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestCategoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties>
    {
        internal ValidationTestCategoryProperties() { }
        public Azure.ResourceManager.PlatformValidation.Models.CatalogAudience? Audience { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<string> Owners { get { throw null; } }
        public string ParentCategoryId { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestCategoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestFailureDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails>
    {
        internal ValidationTestFailureDetails() { }
        public string Details { get { throw null; } }
        public string DiagnosticInfo { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecommendedActions { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput>
    {
        internal ValidationTestInput() { }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition Definition { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationTestInputDataType : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationTestInputDataType(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType Array { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType Boolean { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType Integer { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType Number { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType Object { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationTestInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition>
    {
        internal ValidationTestInputDefinition() { }
        public System.Collections.Generic.IList<string> AllowedValues { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? Required { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDataType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationTestOverallState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationTestOverallState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState Active { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState Draft { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState Published { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationTestPassDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails>
    {
        internal ValidationTestPassDetails() { }
        public string ResultCode { get { throw null; } }
        public string ResultDetails { get { throw null; } }
        public string TestName { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties>
    {
        internal ValidationTestProperties() { }
        public Azure.ResourceManager.PlatformValidation.Models.CatalogAudience? Audience { get { throw null; } }
        public System.Collections.Generic.IList<string> CategoryIds { get { throw null; } }
        public string CurrentVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput> Inputs { get { throw null; } }
        public System.DateTimeOffset? LastPublishedOn { get { throw null; } }
        public string LatestPublishedVersion { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState? OverallState { get { throw null; } }
        public System.Collections.Generic.IList<string> Owners { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string TestStoreUri { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationTestRunProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties>
    {
        internal ValidationTestRunProperties() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PlatformValidation.Models.ValidationTestFailureDetails> FailureDetails { get { throw null; } }
        public string InputsJson { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PlatformValidation.Models.ValidationTestPassDetails> PassDetails { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus? Status { get { throw null; } }
        public string TestId { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationTestRunProvisioningState : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationTestRunProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationTestRunStatus : System.IEquatable<Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationTestRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus Error { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus NotRunning { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus left, Azure.ResourceManager.PlatformValidation.Models.ValidationTestRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationTestVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties>
    {
        internal ValidationTestVersionProperties() { }
        public Azure.ResourceManager.PlatformValidation.Models.CatalogAudience? Audience { get { throw null; } }
        public System.Collections.Generic.IList<string> CategoryIds { get { throw null; } }
        public string ContentHash { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PlatformValidation.Models.ValidationTestInput> Inputs { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ValidationTestOverallState? OverallState { get { throw null; } }
        public System.Collections.Generic.IList<string> Owners { get { throw null; } }
        public Azure.ResourceManager.PlatformValidation.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string TestStoreUri { get { throw null; } }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlatformValidation.Models.ValidationTestVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
