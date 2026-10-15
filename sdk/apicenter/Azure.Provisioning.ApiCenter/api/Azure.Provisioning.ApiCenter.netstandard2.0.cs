namespace Azure.Provisioning.ApiCenter
{
    public partial class ApiCenterApi : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterApi(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterApiProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterApi FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterApiDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterApiDefinition(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterApiVersion Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterApiDefinitionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterApiDefinition FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterApiDefinitionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterApiDefinitionProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiSpecificationDetails Specification { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterApiManagementSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterApiManagementSource() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MsiResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterApiProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterApiProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiCenter.ApiContactInformation> Contacts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CustomProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiCenter.ApiExternalDocumentation> ExternalDocumentation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiLicenseInformation License { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiLifecycleStage> LifecycleStage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Summary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> TermsOfServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApiCenterApiSourceLinkState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="initializing")]
        Initializing = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="syncing")]
        Syncing = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="error")]
        Error = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deleting")]
        Deleting = 3,
    }
    public partial class ApiCenterApiVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterApiVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterApi Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterApiVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterApiVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterApiVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterApiVersionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiLifecycleStage> LifecycleStage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterDeletedService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ApiCenterDeletedService() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterDeletedServiceProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterDeletedService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterDeletedServiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterDeletedServiceProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ScheduledPurgeOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SoftDeletedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterDeployment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterApi Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterDeployment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterDeploymentProperties() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> CustomProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefinitionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Uri> ServerRuntimeUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiCenterDeploymentState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApiCenterDeploymentState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="active")]
        Active = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="inactive")]
        Inactive = 1,
    }
    public partial class ApiCenterEnvironment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterEnvironment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterEnvironmentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterEnvironment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public enum ApiCenterEnvironmentKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="development")]
        Development = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="testing")]
        Testing = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="staging")]
        Staging = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="production")]
        Production = 3,
    }
    public partial class ApiCenterEnvironmentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterEnvironmentProperties() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> CustomProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiCenterEnvironmentKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.EnvironmentOnboardingInformation Onboarding { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterEnvironmentServer Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterEnvironmentServer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterEnvironmentServer() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.EnvironmentServerType> EnvironmentServerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ManagementPortalUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApiCenterImportSpecificationModel
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="never")]
        Never = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ondemand")]
        OnDemand = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="always")]
        Always = 2,
    }
    public partial class ApiCenterLinkState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterLinkState() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiCenterApiSourceLinkState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterMetadataAssignment : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterMetadataAssignment() { }
        public Azure.Provisioning.BicepValue<bool> Deprecated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.MetadataAssignmentEntity> Entity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Required { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterMetadataSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterMetadataSchema(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterService Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterMetadataSchemaProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterMetadataSchema FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterMetadataSchemaProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterMetadataSchemaProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiCenter.ApiCenterMetadataAssignment> AssignedTo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApiCenterProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
    }
    public partial class ApiCenterService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterServiceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterServiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterServiceProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsRestore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiCenterProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCenterWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiCenterWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterService Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterWorkspaceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiCenterWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2024_03_15_PREVIEW;
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiCenterWorkspaceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCenterWorkspaceProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiContactInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiContactInformation() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiExternalDocumentation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiExternalDocumentation() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApiKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="rest")]
        Rest = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="graphql")]
        Graphql = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="grpc")]
        Grpc = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="soap")]
        Soap = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="webhook")]
        Webhook = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="websocket")]
        Websocket = 5,
    }
    public partial class ApiLicenseInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiLicenseInformation() { }
        public Azure.Provisioning.BicepValue<System.Uri> Identifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApiLifecycleStage
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="design")]
        Design = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="development")]
        Development = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="testing")]
        Testing = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="preview")]
        Preview = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="production")]
        Production = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deprecated")]
        Deprecated = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="retired")]
        Retired = 6,
    }
    public partial class ApiSource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiSource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiSourceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiCenter.ApiSource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_06_01_PREVIEW;
        }
    }
    public partial class ApiSourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiSourceProperties() { }
        public Azure.Provisioning.ApiCenter.ApiCenterApiManagementSource AzureApiManagementSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiCenterImportSpecificationModel> ImportSpecification { get { throw null; } set { } }
        public Azure.Provisioning.ApiCenter.ApiCenterLinkState LinkState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetEnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiCenter.ApiLifecycleStage> TargetLifecycleStage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiSpecificationDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiSpecificationDetails() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EnvironmentOnboardingInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EnvironmentOnboardingInformation() { }
        public Azure.Provisioning.BicepValue<System.Uri> DeveloperPortalUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Instructions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnvironmentServerType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Azure API Management")]
        AzureApiManagement = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Azure compute service")]
        AzureComputeService = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Apigee API Management")]
        ApigeeApiManagement = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS API Gateway")]
        AwsApiGateway = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Kong API Gateway")]
        KongApiGateway = 4,
        Kubernetes = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MuleSoft API Management")]
        MuleSoftApiManagement = 6,
    }
    public enum MetadataAssignmentEntity
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="api")]
        Api = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="environment")]
        Environment = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deployment")]
        Deployment = 2,
    }
}
