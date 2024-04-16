namespace Azure.ResourceManager.SelfHelp
{
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
        Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SelfHelpDiagnosticResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string diagnosticsResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SelfHelpExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult> CheckSelfHelpNameAvailability(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>> CheckSelfHelpNameAvailabilityAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> GetSelfHelpDiagnostic(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetSelfHelpDiagnosticAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource GetSelfHelpDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticCollection GetSelfHelpDiagnostics(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutions(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource GetSimplifiedSolutionsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource> GetSimplifiedSolutionsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource>> GetSimplifiedSolutionsResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceCollection GetSimplifiedSolutionsResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SolutionResource GetSolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource> GetSolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource>> GetSolutionResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SolutionResourceCollection GetSolutionResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource> GetSolutionResourceSelfHelp(this Azure.ResourceManager.Resources.TenantResource tenantResource, string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource>> GetSolutionResourceSelfHelpAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource GetSolutionResourceSelfHelpResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpCollection GetSolutionResourceSelfHelps(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.SelfHelp.TroubleshooterResource GetTroubleshooterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource> GetTroubleshooterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource>> GetTroubleshooterResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.TroubleshooterResourceCollection GetTroubleshooterResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPSubscriptionScopes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPSubscriptionScopesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPTenantScopes(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPTenantScopesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SimplifiedSolutionsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SimplifiedSolutionsResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string simplifiedSolutionsResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SimplifiedSolutionsResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected SimplifiedSolutionsResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simplifiedSolutionsResourceName, Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simplifiedSolutionsResourceName, Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource> Get(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource>> GetAsync(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource> GetIfExists(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource>> GetIfExistsAsync(string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SimplifiedSolutionsResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData>
    {
        public SimplifiedSolutionsResourceData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Appendix { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SolutionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string solutionResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SolutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SolutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response WarmUp(Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody solutionWarmUpRequestBody = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> WarmUpAsync(Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody solutionWarmUpRequestBody = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected SolutionResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SolutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionResourceName, Azure.ResourceManager.SelfHelp.SolutionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SolutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionResourceName, Azure.ResourceManager.SelfHelp.SolutionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource> Get(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource>> GetAsync(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SolutionResource> GetIfExists(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SolutionResource>> GetIfExistsAsync(string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SolutionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceData>
    {
        public SolutionResourceData() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ReplacementMaps ReplacementMaps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> Sections { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion> TriggerCriteria { get { throw null; } }
        Azure.ResourceManager.SelfHelp.SolutionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SolutionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SolutionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SolutionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionResourceSelfHelpCollection : Azure.ResourceManager.ArmCollection
    {
        protected SolutionResourceSelfHelpCollection() { }
        public virtual Azure.Response<bool> Exists(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource> Get(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource>> GetAsync(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource> GetIfExists(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource>> GetIfExistsAsync(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionResourceSelfHelpData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData>
    {
        public SolutionResourceSelfHelpData() { }
        public string Content { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp ReplacementMaps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp> Sections { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionResourceSelfHelpResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionResourceSelfHelpResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string solutionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TroubleshooterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TroubleshooterResource() { }
        public virtual Azure.ResourceManager.SelfHelp.TroubleshooterResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Continue(Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody continueRequestBody = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ContinueAsync(Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody continueRequestBody = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string troubleshooterName) { throw null; }
        public virtual Azure.Response End(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EndAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult> Restart(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>> RestartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.TroubleshooterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.TroubleshooterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.TroubleshooterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.TroubleshooterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TroubleshooterResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected TroubleshooterResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.TroubleshooterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string troubleshooterName, Azure.ResourceManager.SelfHelp.TroubleshooterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.TroubleshooterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string troubleshooterName, Azure.ResourceManager.SelfHelp.TroubleshooterResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource> Get(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource>> GetAsync(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SelfHelp.TroubleshooterResource> GetIfExists(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SelfHelp.TroubleshooterResource>> GetIfExistsAsync(string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TroubleshooterResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.TroubleshooterResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.TroubleshooterResourceData>
    {
        public TroubleshooterResourceData() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep> Steps { get { throw null; } }
        Azure.ResourceManager.SelfHelp.TroubleshooterResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.TroubleshooterResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.TroubleshooterResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.TroubleshooterResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.TroubleshooterResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.TroubleshooterResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.TroubleshooterResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource GetSimplifiedSolutionsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource> GetSimplifiedSolutionsResource(Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResource>> GetSimplifiedSolutionsResourceAsync(Azure.Core.ResourceIdentifier scope, string simplifiedSolutionsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceCollection GetSimplifiedSolutionsResources(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SolutionResource GetSolutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource> GetSolutionResource(Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResource>> GetSolutionResourceAsync(Azure.Core.ResourceIdentifier scope, string solutionResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SolutionResourceCollection GetSolutionResources(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource GetSolutionResourceSelfHelpResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.TroubleshooterResource GetTroubleshooterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource> GetTroubleshooterResource(Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.TroubleshooterResource>> GetTroubleshooterResourceAsync(Azure.Core.ResourceIdentifier scope, string troubleshooterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.TroubleshooterResourceCollection GetTroubleshooterResources(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableSelfHelpSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSelfHelpSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPSubscriptionScopes(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPSubscriptionScopesAsync(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSelfHelpTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSelfHelpTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutions(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutionsAsync(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource> GetSolutionResourceSelfHelp(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpResource>> GetSolutionResourceSelfHelpAsync(string solutionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpCollection GetSolutionResourceSelfHelps() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPTenantScopes(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource> PostDiscoverySolutionNLPTenantScopesAsync(Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent discoverSolutionRequest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SelfHelp.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregationType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.AggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregationType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.AggregationType Avg { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.AggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.AggregationType Max { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.AggregationType Min { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.AggregationType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.AggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.AggregationType left, Azure.ResourceManager.SelfHelp.Models.AggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.AggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.AggregationType left, Azure.ResourceManager.SelfHelp.Models.AggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmSelfHelpModelFactory
    {
        public static Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult AutomatedCheckResult(string version = null, string status = null, string result = null, Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType? resultType = default(Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ClassificationService ClassificationService(Azure.Core.ResourceIdentifier serviceId = null, string displayName = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent DiscoveryNlpRequest(string issueSummary = null, string resourceId = null, string serviceId = null, string additionalContext = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart MetricsBasedChart(string name = null, Azure.ResourceManager.SelfHelp.Models.AggregationType? aggregationType = default(Azure.ResourceManager.SelfHelp.Models.AggregationType?), System.TimeSpan? timeSpanDuration = default(System.TimeSpan?), string title = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter> filter = null, string replacementKey = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ReplacementMaps ReplacementMaps(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.WebResult> webResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic> diagnostics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters> troubleshooters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart> metricsBasedCharts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> videos = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.VideoGroup> videoGroups = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp ReplacementMapsSelfHelp(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.WebResult> webResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> videos = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.VideoGroup> videoGroups = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ResponseConfig ResponseConfig(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties ResponseValidationProperties(string regex = null, Azure.ResourceManager.SelfHelp.Models.ValidationScope? validationScope = default(Azure.ResourceManager.SelfHelp.Models.ValidationScope?), bool? isRequired = default(bool?), string validationErrorMessage = null, long? maxLength = default(long?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult RestartTroubleshooterResult(string troubleshooterResourceName = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SearchResult SearchResult(string solutionId = null, string content = null, string title = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence? confidence = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence?), string source = null, Azure.ResourceManager.SelfHelp.Models.ResultType? resultType = default(Azure.ResourceManager.SelfHelp.Models.ResultType?), int? rank = default(int?), string link = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp SectionSelfHelp(string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp replacementMaps = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData SelfHelpDiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> globalParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation> insights = null, System.DateTimeOffset? acceptedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo SelfHelpDiagnosticInfo(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? status = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> insights = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpError error = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This function is obsolete and will be removed in a future release.", false)]
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight SelfHelpDiagnosticInsight(string id = null, string title = null, string results = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel? insightImportanceLevel = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpError SelfHelpError(string code = null, string errorType = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpError> details = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter SelfHelpFilter(string name = null, string values = null, string @operator = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult SelfHelpNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSection SelfHelpSection(string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.ReplacementMaps replacementMaps = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata SelfHelpSolutionMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties> solutions = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata SelfHelpSolutionMetadata(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string solutionId, string solutionType, string description, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> requiredParameterSets) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpStep SelfHelpStep(string id = null, string title = null, string description = null, string guidance = null, Azure.ResourceManager.SelfHelp.Models.ExecutionStatus? executionStatus = default(Azure.ResourceManager.SelfHelp.Models.ExecutionStatus?), string executionStatusDescription = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpType? stepType = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpType?), bool? isLastStep = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.StepInput> inputs = null, Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult automatedCheckResults = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> insights = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo SelfHelpVideo(string src = null, string title = null, string replacementKey = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SimplifiedSolutionsResourceData SimplifiedSolutionsResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string solutionId = null, System.Collections.Generic.IDictionary<string, string> parameters = null, string title = null, System.Collections.Generic.IReadOnlyDictionary<string, string> appendix = null, string content = null, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties SolutionMetadataProperties(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SolutionType? solutionType = default(Azure.ResourceManager.SelfHelp.Models.SolutionType?), string description = null, System.Collections.Generic.IEnumerable<string> requiredInputs = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource SolutionNlpMetadataResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string problemTitle = null, string problemDescription = null, string serviceId = null, string problemClassificationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties> solutions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.ClassificationService> relatedServices = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SolutionResourceData SolutionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion> triggerCriteria = null, System.Collections.Generic.IDictionary<string, string> parameters = null, string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState?), string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.ReplacementMaps replacementMaps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> sections = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch SolutionResourcePatch(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion> triggerCriteria = null, System.Collections.Generic.IDictionary<string, string> parameters = null, string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState?), string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.ReplacementMaps replacementMaps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> sections = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SolutionResourceSelfHelpData SolutionResourceSelfHelpData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string solutionId = null, string title = null, string content = null, Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp replacementMaps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp> sections = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic SolutionsDiagnostic(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? status = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus?), string statusDetails = null, string replacementKey = null, string estimatedCompletionTime = null, System.Collections.Generic.IEnumerable<string> requiredParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> insights = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters SolutionsTroubleshooters(string solutionId = null, string title = null, string summary = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.StepInput StepInput(string questionId = null, Azure.ResourceManager.SelfHelp.Models.QuestionType? questionType = default(Azure.ResourceManager.SelfHelp.Models.QuestionType?), string questionTitle = null, string questionContent = null, Azure.ResourceManager.SelfHelp.Models.QuestionContentType? questionContentType = default(Azure.ResourceManager.SelfHelp.Models.QuestionContentType?), string responseHint = null, string recommendedOption = null, string selectedOptionValue = null, Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties responseValidationProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.ResponseConfig> responseOptions = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.TroubleshooterResourceData TroubleshooterResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string solutionId = null, System.Collections.Generic.IDictionary<string, string> parameters = null, Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.TroubleshooterProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep> steps = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.VideoGroup VideoGroup(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo> videos = null, string replacementKey = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo VideoGroupVideo(string src = null, string title = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.WebResult WebResult(string replacementKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SearchResult> searchResults = null) { throw null; }
    }
    public partial class AutomatedCheckResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult>
    {
        internal AutomatedCheckResult() { }
        public string Result { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResultType? ResultType { get { throw null; } }
        public string Status { get { throw null; } }
        public string Version { get { throw null; } }
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
    public partial class ClassificationService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>
    {
        public ClassificationService() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceId { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.ClassificationService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ClassificationService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ClassificationService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContinueRequestBody : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody>
    {
        public ContinueRequestBody() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult> Responses { get { throw null; } }
        public string StepId { get { throw null; } set { } }
        Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ContinueRequestBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryNlpContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>
    {
        public DiscoveryNlpContent(string issueSummary) { }
        public string AdditionalContext { get { throw null; } set { } }
        public string IssueSummary { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
        public string ServiceId { get { throw null; } set { } }
        Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.DiscoveryNlpContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionStatus : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.ExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ExecutionStatus Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ExecutionStatus Success { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ExecutionStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.ExecutionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.ExecutionStatus left, Azure.ResourceManager.SelfHelp.Models.ExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.ExecutionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.ExecutionStatus left, Azure.ResourceManager.SelfHelp.Models.ExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsBasedChart : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>
    {
        internal MetricsBasedChart() { }
        public Azure.ResourceManager.SelfHelp.Models.AggregationType? AggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpFilter> Filter { get { throw null; } }
        public string Name { get { throw null; } }
        public string ReplacementKey { get { throw null; } }
        public System.TimeSpan? TimeSpanDuration { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionContentType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.QuestionContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionContentType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionContentType Html { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionContentType Markdown { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionContentType Text { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.QuestionContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.QuestionContentType left, Azure.ResourceManager.SelfHelp.Models.QuestionContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.QuestionContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.QuestionContentType left, Azure.ResourceManager.SelfHelp.Models.QuestionContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.QuestionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionType DateTimePicker { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionType Dropdown { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionType MultiLineInfoBox { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionType MultiSelect { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionType RadioButton { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.QuestionType TextInput { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.QuestionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.QuestionType left, Azure.ResourceManager.SelfHelp.Models.QuestionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.QuestionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.QuestionType left, Azure.ResourceManager.SelfHelp.Models.QuestionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReplacementMaps : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMaps>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMaps>
    {
        internal ReplacementMaps() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic> Diagnostics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.MetricsBasedChart> MetricsBasedCharts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters> Troubleshooters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.VideoGroup> VideoGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> Videos { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.WebResult> WebResults { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.ReplacementMaps System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMaps>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMaps>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ReplacementMaps System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMaps>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMaps>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMaps>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplacementMapsSelfHelp : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp>
    {
        internal ReplacementMapsSelfHelp() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.VideoGroup> VideoGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpVideo> Videos { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.WebResult> WebResults { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.ResponseConfig>
    {
        internal ResponseConfig() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
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
        public Azure.ResourceManager.SelfHelp.Models.ValidationScope? ValidationScope { get { throw null; } }
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
        Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.RestartTroubleshooterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResultType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.ResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResultType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ResultType Community { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ResultType Documentation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.ResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.ResultType left, Azure.ResourceManager.SelfHelp.Models.ResultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.ResultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.ResultType left, Azure.ResourceManager.SelfHelp.Models.ResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SearchResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SearchResult>
    {
        internal SearchResult() { }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpConfidence? Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public string Link { get { throw null; } }
        public int? Rank { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ResultType? ResultType { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Source { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.SearchResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SearchResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SearchResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SearchResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SearchResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SearchResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SearchResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SectionSelfHelp : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp>
    {
        internal SectionSelfHelp() { }
        public string Content { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ReplacementMapsSelfHelp ReplacementMaps { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SectionSelfHelp>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.SelfHelp.Models.ReplacementMaps ReplacementMaps { get { throw null; } }
        public string Title { get { throw null; } }
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
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfHelpStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SelfHelpStep>
    {
        internal SelfHelpStep() { }
        public Azure.ResourceManager.SelfHelp.Models.AutomatedCheckResult AutomatedCheckResults { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ExecutionStatus? ExecutionStatus { get { throw null; } }
        public string ExecutionStatusDescription { get { throw null; } }
        public string Guidance { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.StepInput> Inputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public bool? IsLastStep { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpType? StepType { get { throw null; } }
        public string Title { get { throw null; } }
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
        public Azure.ResourceManager.SelfHelp.Models.SolutionType? SolutionType { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionNlpMetadataResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource>
    {
        public SolutionNlpMetadataResource() { }
        public string ProblemClassificationId { get { throw null; } set { } }
        public string ProblemDescription { get { throw null; } set { } }
        public string ProblemTitle { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.ClassificationService> RelatedServices { get { throw null; } }
        public string ServiceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.SolutionMetadataProperties> Solutions { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionNlpMetadataResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SolutionResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch>
    {
        public SolutionResourcePatch() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SolutionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ReplacementMaps ReplacementMaps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpSection> Sections { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion> TriggerCriteria { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsDiagnostic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionsTroubleshooters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>
    {
        internal SolutionsTroubleshooters() { }
        public string SolutionId { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionsTroubleshooters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SolutionType : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SolutionType(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionType Diagnostics { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionType SelfHelp { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionType Solutions { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SolutionType Troubleshooters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SolutionType left, Azure.ResourceManager.SelfHelp.Models.SolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SolutionType left, Azure.ResourceManager.SelfHelp.Models.SolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SolutionWarmUpRequestBody : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody>
    {
        public SolutionWarmUpRequestBody() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.SolutionWarmUpRequestBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StepInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.StepInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.StepInput>
    {
        internal StepInput() { }
        public string QuestionContent { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.QuestionContentType? QuestionContentType { get { throw null; } }
        public string QuestionId { get { throw null; } }
        public string QuestionTitle { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.QuestionType? QuestionType { get { throw null; } }
        public string RecommendedOption { get { throw null; } }
        public string ResponseHint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.ResponseConfig> ResponseOptions { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ResponseValidationProperties ResponseValidationProperties { get { throw null; } }
        public string SelectedOptionValue { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.StepInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.StepInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.StepInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.StepInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.StepInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.StepInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.StepInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerCriterion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion>
    {
        public TriggerCriterion() { }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpName? Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.SelfHelp.Models.TriggerCriterion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TriggerCriterion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TriggerCriterion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TroubleshooterResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>
    {
        public TroubleshooterResult() { }
        public string QuestionId { get { throw null; } set { } }
        public Azure.ResourceManager.SelfHelp.Models.QuestionType? QuestionType { get { throw null; } set { } }
        public string Response { get { throw null; } set { } }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.TroubleshooterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationScope : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.ValidationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationScope(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ValidationScope GuidFormat { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ValidationScope IPAddressFormat { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ValidationScope None { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ValidationScope NumberOnlyFormat { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ValidationScope URLFormat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.ValidationScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.ValidationScope left, Azure.ResourceManager.SelfHelp.Models.ValidationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.ValidationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.ValidationScope left, Azure.ResourceManager.SelfHelp.Models.ValidationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VideoGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroup>
    {
        internal VideoGroup() { }
        public string ReplacementKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo> Videos { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.VideoGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.VideoGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoGroupVideo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>
    {
        internal VideoGroupVideo() { }
        public string Src { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.VideoGroupVideo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.WebResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.WebResult>
    {
        internal WebResult() { }
        public string ReplacementKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SearchResult> SearchResults { get { throw null; } }
        Azure.ResourceManager.SelfHelp.Models.WebResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.WebResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SelfHelp.Models.WebResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SelfHelp.Models.WebResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.WebResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.WebResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SelfHelp.Models.WebResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
