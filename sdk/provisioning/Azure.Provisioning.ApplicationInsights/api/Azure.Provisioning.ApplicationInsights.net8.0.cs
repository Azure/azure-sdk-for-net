namespace Azure.Provisioning.ApplicationInsights
{
    public enum ApplicationInsightsApplicationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="web")]
        Web = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="other")]
        Other = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationInsightsBuiltInRole : System.IEquatable<Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationInsightsBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole ApplicationInsightsComponentContributor { get { throw null; } }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole ApplicationInsightsSnapshotDebugger { get { throw null; } }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole MonitoringContributor { get { throw null; } }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole MonitoringMetricsPublisher { get { throw null; } }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole MonitoringReader { get { throw null; } }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole WorkbookContributor { get { throw null; } }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole WorkbookReader { get { throw null; } }
        public bool Equals(Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole left, Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole left, Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationInsightsComponent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationInsightsComponent(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ApplicationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.ApplicationInsightsApplicationType> ApplicationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.ComponentFlowType> FlowType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HockeyAppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HockeyAppToken { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.ComponentIngestionMode> IngestionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstrumentationKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDisableIPMasking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsForceCustomerStorageForProfiler { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsImmediatePurgeDataOn30Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LaMigrationOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NamePropertiesName { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApplicationInsights.PrivateLinkScopedResourceReference> PrivateLinkScopedResources { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.ApplicationInsightsPublicNetworkAccessType> PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.ApplicationInsightsPublicNetworkAccessType> PublicNetworkAccessForQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.ComponentRequestSource> RequestSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> SamplingPercentage { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ApplicationInsights.ApplicationInsightsBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsComponent FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_08_01;
            public static readonly string V2015_05_01;
            public static readonly string V2020_02_02;
        }
    }
    public enum ApplicationInsightsPublicNetworkAccessType
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ApplicationInsightsWebTest : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationInsightsWebTest(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrequencyInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRetryEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.WebTestKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApplicationInsights.WebTestGeolocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ApplicationInsights.WebTestRequest Request { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SyntheticMonitorId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.ApplicationInsights.WebTestValidationRules ValidationRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebTest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.WebTestKind> WebTestKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebTestName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsWebTest FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2014_04_01;
            public static readonly string V2014_08_01;
            public static readonly string V2015_05_01;
            public static readonly string V2022_06_15;
        }
    }
    public partial class ApplicationInsightsWorkbook : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationInsightsWorkbook(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApplicationInsights.WorkbookSharedTypeKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Revision { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerializedData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> StorageUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsWorkbook FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_02_12;
            public static readonly string V2020_10_20;
            public static readonly string V2021_03_08;
            public static readonly string V2021_08_01;
            public static readonly string V2022_04_01;
            public static readonly string V2023_06_01;
        }
    }
    public partial class ApplicationInsightsWorkbookTemplate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationInsightsWorkbookTemplate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Author { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApplicationInsights.WorkbookTemplateGallery> Galleries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<Azure.Provisioning.ApplicationInsights.WorkbookTemplateLocalizedGallery>> LocalizedGalleries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TemplateData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsWorkbookTemplate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2020_11_20;
        }
    }
    public enum ComponentFlowType
    {
        Bluefield = 0,
    }
    public enum ComponentIngestionMode
    {
        ApplicationInsights = 0,
        ApplicationInsightsWithDiagnosticSettings = 1,
        LogAnalytics = 2,
    }
    public enum ComponentRequestSource
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="rest")]
        Rest = 0,
    }
    public partial class PrivateLinkScopedResourceReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateLinkScopedResourceReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScopeId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebTestContentValidation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebTestContentValidation() { }
        public Azure.Provisioning.BicepValue<string> ContentMatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreCase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PassIfTextFound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebTestGeolocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebTestGeolocation() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebTestKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ping")]
        Ping = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="multistep")]
        MultiStep = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard")]
        Standard = 2,
    }
    public partial class WebTestRequest : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebTestRequest() { }
        public Azure.Provisioning.BicepValue<bool> FollowRedirects { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApplicationInsights.WebTestRequestHeaderField> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpVerb { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ParseDependentRequests { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestBody { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RequestUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebTestRequestHeaderField : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebTestRequestHeaderField() { }
        public Azure.Provisioning.BicepValue<string> HeaderFieldName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HeaderFieldValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebTestValidationRules : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebTestValidationRules() { }
        public Azure.Provisioning.BicepValue<bool> CheckSsl { get { throw null; } set { } }
        public Azure.Provisioning.ApplicationInsights.WebTestContentValidation ContentValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ExpectedHttpStatusCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreHttpStatusCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SslCertRemainingLifetimeCheck { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WorkbookSharedTypeKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="shared")]
        Shared = 0,
    }
    public partial class WorkbookTemplateGallery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkbookTemplateGallery() { }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Order { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkbookType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkbookTemplateLocalizedGallery : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkbookTemplateLocalizedGallery() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApplicationInsights.WorkbookTemplateGallery> Galleries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TemplateData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
