namespace Azure.ResourceManager.SelfHelp
{
    public partial class AzureResourceManagerSelfHelpContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSelfHelpContext() { }
        public static Azure.ResourceManager.SelfHelp.AzureResourceManagerSelfHelpContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class SelfHelpDiagnosticCollection : Azure.ResourceManager.ArmCollection
    {
        protected SelfHelpDiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Get(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetAsync(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> GetIfExists(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetIfExistsAsync(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpDiagnosticData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>
    {
        public SelfHelpDiagnosticData() { }
        public System.DateTimeOffset? AcceptedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo> Diagnostics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> GlobalParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation> Insights { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpDiagnosticResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SelfHelpDiagnosticResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string diagnosticsResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SelfHelpExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult> CheckSelfHelpNameAvailability(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>> CheckSelfHelpNameAvailabilityAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> DiscoverSolutions(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> DiscoverSolutionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlp(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlp(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlpAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlpAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> GetSelfHelpDiagnostic(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetSelfHelpDiagnosticAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource GetSelfHelpDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticCollection GetSelfHelpDiagnostics(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutionsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource> GetSelfHelpSimplifiedSolution(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource>> GetSelfHelpSimplifiedSolutionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource GetSelfHelpSimplifiedSolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionCollection GetSelfHelpSimplifiedSolutions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource> GetSelfHelpSolution(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource>> GetSelfHelpSolutionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult> GetSelfHelpSolutionById(this Azure.ResourceManager.Resources.TenantResource tenantResource, string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>> GetSelfHelpSolutionByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource GetSelfHelpSolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpSolutionCollection GetSelfHelpSolutions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource> GetSelfHelpTroubleshooter(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource>> GetSelfHelpTroubleshooterAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource GetSelfHelpTroubleshooterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterCollection GetSelfHelpTroubleshooters(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class SelfHelpSimplifiedSolutionCollection : Azure.ResourceManager.ArmCollection
    {
        protected SelfHelpSimplifiedSolutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simplifiedSolutionsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simplifiedSolutionsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource> Get(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource>> GetAsync(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource> GetIfExists(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource>> GetIfExistsAsync(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpSimplifiedSolutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>
    {
        public SelfHelpSimplifiedSolutionData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Appendix { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
        public string Title { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpSimplifiedSolutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SelfHelpSimplifiedSolutionResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string simplifiedSolutionsResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpSolutionCollection : Azure.ResourceManager.ArmCollection
    {
        protected SelfHelpSolutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionResourceName, Azure.ResourceManager.SelfHelp.SelfHelpSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionResourceName, Azure.ResourceManager.SelfHelp.SelfHelpSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource> Get(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource>> GetAsync(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource> GetIfExists(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource>> GetIfExistsAsync(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpSolutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>
    {
        public SelfHelpSolutionData() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps ReplacementMaps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> Sections { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion> TriggerCriteria { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpSolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpSolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpSolutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SelfHelpSolutionResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpSolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string solutionResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SelfHelp.SelfHelpSolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpSolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpSolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response WarmUp(Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> WarmUpAsync(Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpTroubleshooterCollection : Azure.ResourceManager.ArmCollection
    {
        protected SelfHelpTroubleshooterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string troubleshooterName, Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string troubleshooterName, Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource> Get(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource>> GetAsync(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource> GetIfExists(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource>> GetIfExistsAsync(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpTroubleshooterData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>
    {
        public SelfHelpTroubleshooterData() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep> Steps { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpTroubleshooterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SelfHelpTroubleshooterResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Continue(Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ContinueAsync(Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string troubleshooterName) { throw null; }
        public virtual Azure.Response End(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EndAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult> Restart(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>> RestartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SelfHelp.Mocking
{
    public partial class MockableSelfHelpArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSelfHelpArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult> CheckSelfHelpNameAvailability(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>> CheckSelfHelpNameAvailabilityAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> GetSelfHelpDiagnostic(Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetSelfHelpDiagnosticAsync(Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource GetSelfHelpDiagnosticResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticCollection GetSelfHelpDiagnostics(Azure.Core.ResourceIdentifier scope) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutions(Azure.Core.ResourceIdentifier scope, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutionsAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource> GetSelfHelpSimplifiedSolution(Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource>> GetSelfHelpSimplifiedSolutionAsync(Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionResource GetSelfHelpSimplifiedSolutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionCollection GetSelfHelpSimplifiedSolutions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource> GetSelfHelpSolution(Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource>> GetSelfHelpSolutionAsync(Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpSolutionResource GetSelfHelpSolutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpSolutionCollection GetSelfHelpSolutions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource> GetSelfHelpTroubleshooter(Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource>> GetSelfHelpTroubleshooterAsync(Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterResource GetSelfHelpTroubleshooterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterCollection GetSelfHelpTroubleshooters(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableSelfHelpSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSelfHelpSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlp(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlpAsync(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSelfHelpTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSelfHelpTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> DiscoverSolutions(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> DiscoverSolutionsAsync(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlp(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata> DiscoverSolutionsNlpAsync(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult> GetSelfHelpSolutionById(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>> GetSelfHelpSolutionByIdAsync(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SelfHelp.Models
{
    public static partial class ArmSelfHelpModelFactory
    {
        public static Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult AutomatedCheckResult(string version = null, string status = null, string result = null, Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType? resultType = default(Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ClassificationService ClassificationService(Azure.Core.ResourceIdentifier serviceId = null, string displayName = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent DiscoveryNlpContent(string issueSummary = null, string resourceId = null, string serviceId = null, string additionalContext = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.KBSearchResult KBSearchResult(string solutionId = null, string content = null, string title = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence? confidence = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence?), string source = null, Azure.ResourceManager.SelfHelp.Models.KBSearchResultType? resultType = default(Azure.ResourceManager.SelfHelp.Models.KBSearchResultType?), int? rank = default(int?), string link = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.KBWebResult KBWebResult(string replacementKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.KBSearchResult> searchResults = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart MetricsBasedChart(string name = null, Azure.ResourceManager.SelfHelp.Models.ChartAggregationType? aggregationType = default(Azure.ResourceManager.SelfHelp.Models.ChartAggregationType?), System.TimeSpan? timeSpanDuration = default(System.TimeSpan?), string title = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter> filter = null, string replacementKey = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult ReplacementMapsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.KBWebResult> webResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> videos = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail> videoGroups = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ResponseConfig ResponseConfig(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties ResponseValidationProperties(string regex = null, Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope? validationScope = default(Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope?), bool? isRequired = default(bool?), string validationErrorMessage = null, long? maxLength = default(long?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult RestartTroubleshooterResult(string troubleshooterResourceName = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData SelfHelpDiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> globalParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation> insights = null, System.DateTimeOffset? acceptedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo SelfHelpDiagnosticInfo(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? status = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> insights = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpError error = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight SelfHelpDiagnosticInsight(string id = null, string title = null, string results = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel? insightImportanceLevel = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpError SelfHelpError(string code = null, string errorType = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpError> details = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter SelfHelpFilter(string name = null, string values = null, string @operator = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult SelfHelpNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSection SelfHelpSection(string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps replacementMaps = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpSimplifiedSolutionData SelfHelpSimplifiedSolutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string solutionId = null, System.Collections.Generic.IDictionary<string, string> parameters = null, string title = null, System.Collections.Generic.IReadOnlyDictionary<string, string> appendix = null, string content = null, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpSolutionData SelfHelpSolutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion> triggerCriteria = null, System.Collections.Generic.IDictionary<string, string> parameters = null, string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState?), string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps replacementMaps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> sections = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata SelfHelpSolutionMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties> solutions = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata SelfHelpSolutionMetadata(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string solutionId, string solutionType, string description, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> requiredParameterSets) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch SelfHelpSolutionPatch(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion> triggerCriteria = null, System.Collections.Generic.IDictionary<string, string> parameters = null, string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState?), string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps replacementMaps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> sections = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult SelfHelpSolutionResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string solutionId = null, string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult replacementMaps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionSection> sections = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpStep SelfHelpStep(string id = null, string title = null, string description = null, string guidance = null, Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus? executionStatus = default(Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus?), string executionStatusDescription = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpType? stepType = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpType?), bool? isLastStep = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput> inputs = null, Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult automatedCheckResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> insights = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpTroubleshooterData SelfHelpTroubleshooterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string solutionId = null, System.Collections.Generic.IDictionary<string, string> parameters = null, Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep> steps = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo SelfHelpVideo(string src = null, string title = null, string replacementKey = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties SolutionMetadataProperties(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType? solutionType = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType?), string description = null, System.Collections.Generic.IEnumerable<string> requiredInputs = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata SolutionNlpMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string problemTitle = null, string problemDescription = null, string serviceId = null, string problemClassificationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties> solutions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.ClassificationService> relatedServices = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps SolutionReplacementMaps(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.KBWebResult> webResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic> diagnostics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters> troubleshooters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart> metricsBasedCharts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> videos = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail> videoGroups = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic SolutionsDiagnostic(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? status = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus?), string statusDetails = null, string replacementKey = null, string estimatedCompletionTime = null, System.Collections.Generic.IEnumerable<string> requiredParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> insights = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionSection SolutionSection(string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult replacementMaps = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters SolutionsTroubleshooters(string solutionId = null, string title = null, string summary = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput TroubleshooterStepInput(string questionId = null, Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType? questionType = default(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType?), string questionTitle = null, string questionContent = null, Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType? questionContentType = default(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType?), string responseHint = null, string recommendedOption = null, string selectedOptionValue = null, Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties responseValidationProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.ResponseConfig> responseOptions = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail VideoGroupDetail(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo> videos = null, string replacementKey = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo VideoGroupVideo(string src = null, string title = null) { throw null; }
    }
    public partial class AutomatedCheckResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>
    {
        internal AutomatedCheckResult() { }
        public string Result { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType? ResultType { get { throw null; } }
        public string Status { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomatedCheckResultType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomatedCheckResultType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType Error { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType Information { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType Success { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType left, Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType left, Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChartAggregationType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.ChartAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChartAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ChartAggregationType Avg { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ChartAggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ChartAggregationType Max { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ChartAggregationType Min { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ChartAggregationType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.ChartAggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.ChartAggregationType left, Azure.ResourceManager.SelfHelp.Models.ChartAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.ChartAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.ChartAggregationType left, Azure.ResourceManager.SelfHelp.Models.ChartAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClassificationService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>
    {
        public ClassificationService() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ClassificationService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ClassificationService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryNlpContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>
    {
        public DiscoveryNlpContent(string issueSummary) { }
        public string AdditionalContext { get { throw null; } set { } }
        public string IssueSummary { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
        public string ServiceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KBSearchResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.KBSearchResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBSearchResult>
    {
        internal KBSearchResult() { }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence? Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public string Link { get { throw null; } }
        public int? Rank { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.KBSearchResultType? ResultType { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Source { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.KBSearchResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.KBSearchResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.KBSearchResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.KBSearchResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBSearchResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBSearchResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBSearchResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KBSearchResultType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.KBSearchResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KBSearchResultType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.KBSearchResultType Community { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.KBSearchResultType Documentation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.KBSearchResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.KBSearchResultType left, Azure.ResourceManager.SelfHelp.Models.KBSearchResultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.KBSearchResultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.KBSearchResultType left, Azure.ResourceManager.SelfHelp.Models.KBSearchResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KBWebResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.KBWebResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBWebResult>
    {
        internal KBWebResult() { }
        public string ReplacementKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.KBSearchResult> SearchResults { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.KBWebResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.KBWebResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.KBWebResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.KBWebResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBWebResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBWebResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.KBWebResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricsBasedChart : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>
    {
        internal MetricsBasedChart() { }
        public Azure.ResourceManager.SelfHelp.Models.ChartAggregationType? AggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter> Filter { get { throw null; } }
        public string Name { get { throw null; } }
        public string ReplacementKey { get { throw null; } }
        public System.TimeSpan? TimeSpanDuration { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplacementMapsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult>
    {
        internal ReplacementMapsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail> VideoGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> Videos { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.KBWebResult> WebResults { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>
    {
        internal ResponseConfig() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ResponseConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ResponseConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties>
    {
        internal ResponseValidationProperties() { }
        public bool? IsRequired { get { throw null; } }
        public long? MaxLength { get { throw null; } }
        public string Regex { get { throw null; } }
        public string ValidationErrorMessage { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope? ValidationScope { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestartTroubleshooterResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>
    {
        internal RestartTroubleshooterResult() { }
        public string TroubleshooterResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpConfidence : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpConfidence(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence High { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence Low { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence left, Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence left, Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpDiagnosticInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo>
    {
        internal SelfHelpDiagnosticInfo() { }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpDiagnosticInsight : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight>
    {
        internal SelfHelpDiagnosticInsight() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel? InsightImportanceLevel { get { throw null; } }
        public string Results { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpDiagnosticInvocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation>
    {
        public SelfHelpDiagnosticInvocation() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalParameters { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpDiagnosticStatus : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpDiagnosticStatus(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus MissingInputs { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus left, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus left, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpError>
    {
        internal SelfHelpError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpError> Details { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter>
    {
        internal SelfHelpFilter() { }
        public string Name { get { throw null; } }
        public string Operator { get { throw null; } }
        public string Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpImportanceLevel : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpImportanceLevel(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel Information { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel left, Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel left, Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpName : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpName(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpName ProblemClassificationId { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpName ReplacementKey { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpName SolutionId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpName left, Azure.ResourceManager.SelfHelp.Models.SelfHelpName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpName left, Azure.ResourceManager.SelfHelp.Models.SelfHelpName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent>
    {
        public SelfHelpNameAvailabilityContent() { }
        public string ResourceName { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>
    {
        internal SelfHelpNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpProvisioningState : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState PartialComplete { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState left, Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState left, Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpSection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection>
    {
        internal SelfHelpSection() { }
        public string Content { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps ReplacementMaps { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpSolutionMetadata : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>
    {
        public SelfHelpSolutionMetadata() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Description { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RequiredParameterSets { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string SolutionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties> Solutions { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string SolutionType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpSolutionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch>
    {
        public SelfHelpSolutionPatch() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps ReplacementMaps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> Sections { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion> TriggerCriteria { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpSolutionResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>
    {
        public SelfHelpSolutionResult() { }
        public string Content { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult ReplacementMaps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SolutionSection> Sections { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Title { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpSolutionType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpSolutionType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType Diagnostics { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType SelfHelp { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType Solutions { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType Troubleshooters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType left, Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType left, Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>
    {
        internal SelfHelpStep() { }
        public Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult AutomatedCheckResults { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus? ExecutionStatus { get { throw null; } }
        public string ExecutionStatusDescription { get { throw null; } }
        public string Guidance { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput> Inputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public bool? IsLastStep { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpType? StepType { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpType AutomatedCheck { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpType Decision { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpType Input { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpType Insight { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpType Solution { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpType left, Azure.ResourceManager.SelfHelp.Models.SelfHelpType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpType left, Azure.ResourceManager.SelfHelp.Models.SelfHelpType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpVideo : Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo>
    {
        internal SelfHelpVideo() { }
        public string ReplacementKey { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionMetadataProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>
    {
        public SolutionMetadataProperties() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredInputs { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionType? SolutionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionNlpMetadata : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata>
    {
        public SolutionNlpMetadata() { }
        public string ProblemClassificationId { get { throw null; } set { } }
        public string ProblemDescription { get { throw null; } set { } }
        public string ProblemTitle { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.ClassificationService> RelatedServices { get { throw null; } }
        public string ServiceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties> Solutions { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SolutionProvisioningState : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SolutionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState PartialComplete { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState left, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState left, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SolutionReplacementMaps : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps>
    {
        internal SolutionReplacementMaps() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic> Diagnostics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart> MetricsBasedCharts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters> Troubleshooters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail> VideoGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> Videos { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.KBWebResult> WebResults { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionReplacementMaps>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionsDiagnostic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>
    {
        internal SolutionsDiagnostic() { }
        public string EstimatedCompletionTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public string ReplacementKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredParameters { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionSection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionSection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionSection>
    {
        internal SolutionSection() { }
        public string Content { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ReplacementMapsResult ReplacementMaps { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionSection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionSection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionsTroubleshooters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>
    {
        internal SolutionsTroubleshooters() { }
        public string SolutionId { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTriggerCriterion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion>
    {
        public SolutionTriggerCriterion() { }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpName? Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionTriggerCriterion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionWarmUpContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent>
    {
        public SolutionWarmUpContent() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TroubleshooterContinueContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent>
    {
        public TroubleshooterContinueContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult> Responses { get { throw null; } }
        public string StepId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterContinueContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TroubleshooterExecutionStatus : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TroubleshooterExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus Success { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TroubleshooterProvisioningState : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TroubleshooterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState AutoContinue { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TroubleshooterQuestionContentType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TroubleshooterQuestionContentType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType Html { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType Markdown { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType Text { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TroubleshooterQuestionType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TroubleshooterQuestionType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType DateTimePicker { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType Dropdown { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType MultiLineInfoBox { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType MultiSelect { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType RadioButton { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType TextInput { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TroubleshooterResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>
    {
        public TroubleshooterResult() { }
        public string QuestionId { get { throw null; } set { } }
        public Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType? QuestionType { get { throw null; } set { } }
        public string Response { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TroubleshooterStepInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput>
    {
        internal TroubleshooterStepInput() { }
        public string QuestionContent { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionContentType? QuestionContentType { get { throw null; } }
        public string QuestionId { get { throw null; } }
        public string QuestionTitle { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.TroubleshooterQuestionType? QuestionType { get { throw null; } }
        public string RecommendedOption { get { throw null; } }
        public string ResponseHint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.ResponseConfig> ResponseOptions { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties ResponseValidationProperties { get { throw null; } }
        public string SelectedOptionValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterStepInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TroubleshooterValidationScope : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TroubleshooterValidationScope(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope GuidFormat { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope IPAddressFormat { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope None { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope NumberOnlyFormat { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope UrlFormat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope left, Azure.ResourceManager.SelfHelp.Models.TroubleshooterValidationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VideoGroupDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail>
    {
        internal VideoGroupDetail() { }
        public string ReplacementKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo> Videos { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoGroupVideo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>
    {
        internal VideoGroupVideo() { }
        public string Src { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
