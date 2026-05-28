namespace Azure.Provisioning.ApiManagement
{
    public partial class AdditionalLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdditionalLocation() { }
        public Azure.Provisioning.BicepValue<bool> DisableGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> GatewayRegionalUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementNatGatewayState> NatGatewayState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> OutboundPublicIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PlatformVersion> PlatformVersion { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> PrivateIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> PublicIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AlwaysLog
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="allErrors")]
        AllErrors = 0,
    }
    public partial class ApiContactInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiContactInformation() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiCreateOrUpdatePropertiesWsdlSelector : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiCreateOrUpdatePropertiesWsdlSelector() { }
        public Azure.Provisioning.BicepValue<string> WsdlEndpointName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WsdlServiceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiDiagnostic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiDiagnostic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.AlwaysLog> AlwaysLog { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Backend { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Frontend { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.HttpCorrelationProtocol> HttpCorrelationProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLogClientIPEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoggerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.OperationNameFormat> OperationNameFormat { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.SamplingSettings Sampling { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.TraceVerbosityLevel> Verbosity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiDiagnostic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConfigurationApiHostname { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedAtUtc { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FrontendDefaultHostname { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ApiManagement.ApiManagementGatewaySkuProperties Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.VirtualNetworkType> VirtualNetworkType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiGatewayConfigConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiGatewayConfigConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DefaultHostname { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Hostnames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiGatewayConfigConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiGatewaySkuType
    {
        Standard = 0,
        WorkspaceGatewayStandard = 1,
        WorkspaceGatewayPremium = 2,
    }
    public partial class ApiIssue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiIssue(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ApiId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.IssueState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiIssue FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiIssueAttachment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiIssueAttachment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContentFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiIssue? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiIssueAttachment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiIssueComment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiIssueComment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiIssue? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Text { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiIssueComment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiLicenseInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiLicenseInformation() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiManagementApi : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementApi(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApiRevision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiRevisionDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiType> ApiType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiVersionDescription { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ApiVersionSetId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiContactInformation Contact { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsCurrent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOnline { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiLicenseInformation License { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ApiOperationInvokableProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.SoapApiType> SoapApiType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceApiId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TermsOfServiceLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.TranslateRequiredQueryParametersConduct> TranslateRequiredQueryParametersConduct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementApi FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementAuthorizationError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiManagementAuthorizationError() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiManagementAuthorizationServer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementAuthorizationServer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AuthorizationEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.AuthorizationMethod> AuthorizationMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.BearerTokenSendingMethod> BearerTokenSendingMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ClientAuthenticationMethod> ClientAuthenticationMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientRegistrationEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DoesSupportState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.GrantType> GrantTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceOwnerPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceOwnerUsername { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.TokenBodyParameterContract> TokenBodyParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TokenEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseInApiDocumentation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseInTestConsole { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementAuthorizationServer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiManagementAuthorizationType
    {
        OAuth2 = 0,
    }
    public partial class ApiManagementBackend : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementBackend(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ApiManagement.BackendServiceFabricClusterProperties BackendServiceFabricCluster { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.CircuitBreakerRule> CircuitBreakerRules { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.BackendPoolItem> PoolServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.BackendProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.BackendProxyContract Proxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.BackendTlsProperties Tls { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.BackendType> TypePropertiesType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementBackend FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementCache : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementCache(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UseFromLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementCache FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ApiManagement.KeyVaultContractCreateProperties KeyVaultDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementDiagnostic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementDiagnostic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.AlwaysLog> AlwaysLog { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Backend { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Frontend { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.HttpCorrelationProtocol> HttpCorrelationProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLogClientIPEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoggerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.OperationNameFormat> OperationNameFormat { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.SamplingSettings Sampling { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.TraceVerbosityLevel> Verbosity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementDiagnostic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementEmailTemplate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementEmailTemplate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDefault { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.EmailTemplateParametersContractProperties> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementEmailTemplate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ApiManagement.ResourceLocationDataContract LocationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public Azure.Provisioning.ApiManagement.GatewayKeysContract GetKeys() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementGatewayCertificateAuthority : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementGatewayCertificateAuthority(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsTrusted { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementGatewayCertificateAuthority FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementGatewayHostnameConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementGatewayHostnameConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CertificateId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Hostname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsClientCertificateRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementGateway? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementGatewayHostnameConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementGatewaySkuProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiManagementGatewaySkuProperties() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiGatewaySkuType> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiManagementGlobalSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementGlobalSchema(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Document { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiSchemaType> SchemaType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementGlobalSchema FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementGroupType> ApiManagementGroupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExternalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementGroupType> GroupType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsBuiltIn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiManagementGroupType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="custom")]
        Custom = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="system")]
        System = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="external")]
        External = 2,
    }
    public partial class ApiManagementIdentityProvider : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementIdentityProvider(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AllowedTenants { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Authority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientLibrary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.IdentityProviderType> IdentityProviderType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordResetPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProfileEditingPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SignInPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SignInTenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SignUpPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementIdentityProvider FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementLogger : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementLogger(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsBuffered { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.LoggerType> LoggerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementLogger FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementNamedValue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementNamedValue(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.KeyVaultContractProperties KeyVaultDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementNamedValue FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiManagementNatGatewayState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ApiManagementNotification : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementNotification(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.RecipientsContractProperties Recipients { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementNotification FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementOpenIdConnectProvider : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementOpenIdConnectProvider(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MetadataEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UseInApiDocumentation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseInTestConsole { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementOpenIdConnectProvider FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementPortalDelegationSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementPortalDelegationSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSubscriptionDelegationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUserRegistrationDelegationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementPortalDelegationSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementPortalRevision : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementPortalRevision(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsCurrent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PortalRevisionStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StatusDetails { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementPortalRevision FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementPortalSignInSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementPortalSignInSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRedirectEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementPortalSignInSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementPortalSignUpSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementPortalSignUpSetting(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSignUpDeveloperPortalEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.ApiManagement.TermsOfServiceProperties TermsOfService { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementPortalSignUpSetting FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ApiManagement.ApiManagementPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.ApiManagement.ApiManagementPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiManagementPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum ApiManagementPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class ApiManagementPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiManagementPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiManagementProduct : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementProduct(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsApprovalRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementProductState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SubscriptionsLimit { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Terms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementProduct FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementProductPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementProductPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementProductPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiManagementProductState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="notPublished")]
        NotPublished = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="published")]
        Published = 1,
    }
    public partial class ApiManagementProductTag : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementProductTag(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementProductTag FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.AdditionalLocation> AdditionalLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.CertificateConfiguration> Certificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedAtUtc { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> CustomProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.DeveloperPortalStatus> DeveloperPortalStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> DeveloperPortalUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableClientCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> GatewayRegionalUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> GatewayUri { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.HostnameConfiguration> HostnameConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.LegacyApiState> LegacyApi { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.LegacyPortalStatus> LegacyPortalStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ManagementApiUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MinApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementNatGatewayState> NatGatewayState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NotificationSenderEmail { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> OutboundPublicIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PlatformVersion> PlatformVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> PortalUri { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> PrivateIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<System.Net.IPAddress> PublicIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPAddressId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublisherEmail { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublisherName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Restore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ScmUri { get { throw null; } }
        public Azure.Provisioning.ApiManagement.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetProvisioningState { get { throw null; } }
        public Azure.Provisioning.ApiManagement.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.VirtualNetworkType> VirtualNetworkType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementServiceSkuProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiManagementServiceSkuProperties() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementServiceSkuType> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApiManagementServiceSkuType
    {
        Developer = 0,
        Standard = 1,
        Premium = 2,
        Basic = 3,
        Consumption = 4,
        Isolated = 5,
        BasicV2 = 6,
        StandardV2 = 7,
    }
    public partial class ApiManagementSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowTracing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotifiesOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OwnerId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.SubscriptionState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StateComment { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementTag : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementTag(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementTag FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiManagementUser : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiManagementUser(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.AppType> AppType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ConfirmationEmailType> Confirmation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FirstName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.GroupContractProperties> Groups { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.UserIdentityContract> Identities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Note { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RegistriesOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementUserState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiManagementUser FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiManagementUserState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="active")]
        Active = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="blocked")]
        Blocked = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="pending")]
        Pending = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deleted")]
        Deleted = 3,
    }
    public partial class ApiOperation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiOperation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Method { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Policies { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.RequestContract Request { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ResponseContract> Responses { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ParameterContract> TemplateParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UriTemplate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiOperation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiOperationInvokableProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="https")]
        Https = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ws")]
        Ws = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="wss")]
        Wss = 3,
    }
    public partial class ApiOperationPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiOperationPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiOperation? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiOperationPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiOperationTag : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiOperationTag(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiOperation? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiOperationTag FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiRelease : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiRelease(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ApiId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Notes { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiRelease FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiSchema(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Components { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Definitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiSchema FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiSchemaType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="xml")]
        Xml = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="json")]
        Json = 1,
    }
    public partial class ApiTag : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiTag(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiTag FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiTagDescription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiTagDescription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExternalDocsDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ExternalDocsUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TagId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiTagDescription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum ApiType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="soap")]
        Soap = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="websocket")]
        WebSocket = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="graphql")]
        GraphQL = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="odata")]
        Odata = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="grpc")]
        Grpc = 5,
    }
    public partial class ApiVersionSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApiVersionSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VersionHeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.VersioningScheme> VersioningScheme { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VersionQueryName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ApiVersionSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ApiVersionSetContractDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApiVersionSetContractDetails() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VersionHeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.VersioningScheme> VersioningScheme { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VersionQueryName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="portal")]
        Portal = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="developerPortal")]
        DeveloperPortal = 1,
    }
    public partial class AuthenticationSettingsContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AuthenticationSettingsContract() { }
        public Azure.Provisioning.ApiManagement.OAuth2AuthenticationSettingsContract OAuth2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.OAuth2AuthenticationSettingsContract> OAuth2AuthenticationSettings { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.OpenIdAuthenticationSettingsContract OpenId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.OpenIdAuthenticationSettingsContract> OpenidAuthenticationSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AuthorizationAccessPolicyContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AuthorizationAccessPolicyContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AppIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.AuthorizationContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.AuthorizationAccessPolicyContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class AuthorizationContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AuthorizationContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementAuthorizationType> AuthorizationType { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementAuthorizationError Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.OAuth2GrantType> OAuth2GrantType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.AuthorizationProviderContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.AuthorizationContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum AuthorizationMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEAD")]
        Head = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OPTIONS")]
        Options = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TRACE")]
        Trace = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET")]
        Get = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="POST")]
        Post = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PUT")]
        Put = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PATCH")]
        Patch = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DELETE")]
        Delete = 7,
    }
    public partial class AuthorizationProviderContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AuthorizationProviderContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IdentityProvider { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.AuthorizationProviderOAuth2Settings Oauth2 { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.AuthorizationProviderContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class AuthorizationProviderOAuth2GrantTypes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AuthorizationProviderOAuth2GrantTypes() { }
        public Azure.Provisioning.BicepDictionary<string> AuthorizationCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ClientCredentials { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AuthorizationProviderOAuth2Settings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AuthorizationProviderOAuth2Settings() { }
        public Azure.Provisioning.ApiManagement.AuthorizationProviderOAuth2GrantTypes GrantTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RedirectUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackendAuthorizationHeaderCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendAuthorizationHeaderCredentials() { }
        public Azure.Provisioning.BicepValue<string> Parameter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scheme { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackendCredentialsContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendCredentialsContract() { }
        public Azure.Provisioning.ApiManagement.BackendAuthorizationHeaderCredentials Authorization { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Certificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> CertificateIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<string>> Header { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<string>> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackendPoolItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendPoolItem() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackendProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="soap")]
        Soap = 1,
    }
    public partial class BackendProxyContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendProxyContract() { }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackendServiceFabricClusterProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendServiceFabricClusterProperties() { }
        public Azure.Provisioning.BicepValue<string> ClientCertificateId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientCertificatethumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ManagementEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPartitionResolutionRetries { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ServerCertificateThumbprints { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.X509CertificateName> ServerX509Names { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackendTlsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendTlsProperties() { }
        public Azure.Provisioning.BicepValue<bool> ShouldValidateCertificateChain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldValidateCertificateName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackendType
    {
        Single = 0,
        Pool = 1,
    }
    public enum BearerTokenSendingMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="authorizationHeader")]
        AuthorizationHeader = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="query")]
        Query = 1,
    }
    public partial class CertificateConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CertificateConfiguration() { }
        public Azure.Provisioning.ApiManagement.CertificateInformation Certificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertificatePassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.CertificateConfigurationStoreName> StoreName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CertificateConfigurationStoreName
    {
        CertificateAuthority = 0,
        Root = 1,
    }
    public partial class CertificateInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CertificateInformation() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CertificateSource
    {
        Managed = 0,
        KeyVault = 1,
        Custom = 2,
        BuiltIn = 3,
    }
    public enum CertificateStatus
    {
        Completed = 0,
        Failed = 1,
        InProgress = 2,
    }
    public partial class CircuitBreakerFailureCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CircuitBreakerFailureCondition() { }
        public Azure.Provisioning.BicepValue<long> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ErrorReasons { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Percentage { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.FailureStatusCodeRange> StatusCodeRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CircuitBreakerRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CircuitBreakerRule() { }
        public Azure.Provisioning.BicepValue<bool> AcceptRetryAfter { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.CircuitBreakerFailureCondition FailureCondition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TripDuration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClientAuthenticationMethod
    {
        Basic = 0,
        Body = 1,
    }
    public enum ConfirmationEmailType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="signup")]
        SignUp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="invite")]
        Invite = 1,
    }
    public enum ContentFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="wadl-xml")]
        WadlXml = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="wadl-link-json")]
        WadlLinkJson = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="swagger-json")]
        SwaggerJson = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="swagger-link-json")]
        SwaggerLinkJson = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="wsdl")]
        Wsdl = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="wsdl-link")]
        WsdlLink = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="openapi")]
        OpenApi = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="openapi+json")]
        OpenApiJson = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="openapi-link")]
        OpenApiLink = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="openapi+json-link")]
        OpenApiJsonLink = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="graphql-link")]
        GraphQLLink = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="odata")]
        Odata = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="odata-link")]
        OdataLink = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="grpc")]
        Grpc = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="grpc-link")]
        GrpcLink = 14,
    }
    public partial class DataMasking : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataMasking() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.DataMaskingEntity> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.DataMaskingEntity> QueryParams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataMaskingEntity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataMaskingEntity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.DataMaskingMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataMaskingMode
    {
        Mask = 0,
        Hide = 1,
    }
    public enum DeveloperPortalStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DocumentationContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DocumentationContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.DocumentationContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class EmailTemplateParametersContractProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EmailTemplateParametersContractProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FailureStatusCodeRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FailureStatusCodeRange() { }
        public Azure.Provisioning.BicepValue<int> Max { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Min { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GatewayKeysContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GatewayKeysContract() { }
        public Azure.Provisioning.BicepValue<string> Primary { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Secondary { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GrantType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="authorizationCode")]
        AuthorizationCode = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="implicit")]
        Implicit = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="resourceOwnerPassword")]
        ResourceOwnerPassword = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="clientCredentials")]
        ClientCredentials = 3,
    }
    public partial class GroupContractProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GroupContractProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementGroupType> ApiManagementGroupType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExternalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsBuiltIn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HostnameConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HostnameConfiguration() { }
        public Azure.Provisioning.ApiManagement.CertificateInformation Certificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertificatePassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.CertificateSource> CertificateSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.CertificateStatus> CertificateStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.HostnameType> HostnameType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientCertificateNegotiationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultSslBindingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultSecretUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HostnameType
    {
        Proxy = 0,
        Portal = 1,
        Management = 2,
        Scm = 3,
        DeveloperPortal = 4,
        ConfigurationApi = 5,
    }
    public enum HttpCorrelationProtocol
    {
        None = 0,
        Legacy = 1,
        W3C = 2,
    }
    public partial class HttpMessageDiagnostic : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HttpMessageDiagnostic() { }
        public Azure.Provisioning.BicepValue<int> BodyBytes { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.DataMasking DataMasking { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Headers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IdentityProviderType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="facebook")]
        Facebook = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="google")]
        Google = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="microsoft")]
        Microsoft = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="twitter")]
        Twitter = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="aad")]
        Aad = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="aadB2C")]
        AadB2C = 5,
    }
    public enum IssueState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="proposed")]
        Proposed = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="open")]
        Open = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="removed")]
        Removed = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="resolved")]
        Resolved = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="closed")]
        Closed = 4,
    }
    public partial class KeyVaultContractCreateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultContractCreateProperties() { }
        public Azure.Provisioning.BicepValue<string> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretIdentifier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultContractProperties : Azure.Provisioning.ApiManagement.KeyVaultContractCreateProperties
    {
        public KeyVaultContractProperties() { }
        public Azure.Provisioning.ApiManagement.KeyVaultLastAccessStatusContractProperties LastStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultLastAccessStatusContractProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultLastAccessStatusContractProperties() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeStampUtc { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LegacyApiState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum LegacyPortalStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum LoggerType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureEventHub")]
        AzureEventHub = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="applicationInsights")]
        ApplicationInsights = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureMonitor")]
        AzureMonitor = 2,
    }
    public partial class OAuth2AuthenticationSettingsContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OAuth2AuthenticationSettingsContract() { }
        public Azure.Provisioning.BicepValue<string> AuthorizationServerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OAuth2GrantType
    {
        AuthorizationCode = 0,
        ClientCredentials = 1,
    }
    public partial class OpenIdAuthenticationSettingsContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OpenIdAuthenticationSettingsContract() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.BearerTokenSendingMethod> BearerTokenSendingMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OpenIdProviderId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OperationNameFormat
    {
        Name = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Url")]
        Uri = 1,
    }
    public partial class ParameterContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ParameterContract() { }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ApiManagement.ParameterExampleContract> Examples { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParameterContractType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TypeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParameterExampleContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ParameterExampleContract() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExternalValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Summary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineDiagnosticSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineDiagnosticSettings() { }
        public Azure.Provisioning.ApiManagement.HttpMessageDiagnostic Request { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.HttpMessageDiagnostic Response { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PlatformVersion
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="undetermined")]
        Undetermined = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="stv1")]
        Stv1 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="stv2")]
        Stv2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mtv1")]
        Mtv1 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="stv2.1")]
        Stv21 = 4,
    }
    public enum PolicyContentFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="xml")]
        Xml = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="xml-link")]
        XmlLink = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rawxml")]
        RawXml = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rawxml-link")]
        RawXmlLink = 3,
    }
    public enum PolicyFragmentContentFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="xml")]
        Xml = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rawxml")]
        Rawxml = 1,
    }
    public partial class PolicyFragmentContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PolicyFragmentContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyFragmentContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.PolicyFragmentContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class PolicyRestrictionContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PolicyRestrictionContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyRestrictionRequireBase> RequireBase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.PolicyRestrictionContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum PolicyRestrictionRequireBase
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="true")]
        True = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="false")]
        False = 1,
    }
    public partial class PortalConfigContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PortalConfigContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> CorsAllowedOrigins { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PortalConfigCspProperties Csp { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PortalConfigDelegationProperties Delegation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBasicAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Require { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PortalConfigTermsOfServiceProperties SignupTermsOfService { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.PortalConfigContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class PortalConfigCspProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PortalConfigCspProperties() { }
        public Azure.Provisioning.BicepList<string> AllowedSources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PortalSettingsCspMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.Uri> ReportUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PortalConfigDelegationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PortalConfigDelegationProperties() { }
        public Azure.Provisioning.BicepValue<bool> DelegateRegistration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DelegateSubscription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> DelegationUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PortalConfigTermsOfServiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PortalConfigTermsOfServiceProperties() { }
        public Azure.Provisioning.BicepValue<bool> RequireConsent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Text { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PortalRevisionStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="pending")]
        Pending = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="publishing")]
        Publishing = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="completed")]
        Completed = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="failed")]
        Failed = 3,
    }
    public enum PortalSettingsCspMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="reportOnly")]
        ReportOnly = 2,
    }
    public enum PublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class RecipientsContractProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecipientsContractProperties() { }
        public Azure.Provisioning.BicepList<string> Emails { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Users { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RemotePrivateEndpointConnectionWrapper : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RemotePrivateEndpointConnectionWrapper() { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.ApiManagement.ApiManagementPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RepresentationContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RepresentationContract() { }
        public Azure.Provisioning.BicepValue<string> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ApiManagement.ParameterExampleContract> Examples { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ParameterContract> FormParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TypeName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RequestContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RequestContract() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ParameterContract> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ParameterContract> QueryParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.RepresentationContract> Representations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResolverContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ResolverContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ResolverContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ResourceLocationDataContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceLocationDataContract() { }
        public Azure.Provisioning.BicepValue<string> City { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CountryOrRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> District { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResponseContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResponseContract() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ParameterContract> Headers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.RepresentationContract> Representations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StatusCode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SamplingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SamplingSettings() { }
        public Azure.Provisioning.BicepValue<double> Percentage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.SamplingType> SamplingType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SamplingType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="fixed")]
        Fixed = 0,
    }
    public partial class ServiceApiResolverPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceApiResolverPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ResolverContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceApiResolverPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceApiWiki : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceApiWiki(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.WikiDocumentationContract> Documents { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceApiWiki FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceProductApiLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceProductApiLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApiId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceProductApiLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceProductGroupLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceProductGroupLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceProductGroupLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceProductWiki : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceProductWiki(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.WikiDocumentationContract> Documents { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceProductWiki FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceTagApiLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceTagApiLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApiId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementTag? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceTagApiLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceTagOperationLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceTagOperationLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OperationId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementTag? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceTagOperationLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceTagProductLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceTagProductLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementTag? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceTagProductLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApi : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApi(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApiRevision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiRevisionDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiType> ApiType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApiVersionDescription { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ApiVersionSetId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiContactInformation Contact { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsCurrent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsOnline { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiLicenseInformation License { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ApiOperationInvokableProtocol> Protocols { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.SoapApiType> SoapApiType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceApiId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TermsOfServiceLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.TranslateRequiredQueryParametersConduct> TranslateRequiredQueryParametersConduct { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApi FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApiDiagnostic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApiDiagnostic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.AlwaysLog> AlwaysLog { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Backend { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Frontend { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.HttpCorrelationProtocol> HttpCorrelationProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLogClientIPEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoggerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.OperationNameFormat> OperationNameFormat { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.SamplingSettings Sampling { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.TraceVerbosityLevel> Verbosity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApiDiagnostic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApiOperation : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApiOperation(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Method { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Policies { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.RequestContract Request { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ResponseContract> Responses { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.ParameterContract> TemplateParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UriTemplate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApiOperation FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApiOperationPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApiOperationPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceApiOperation? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApiOperationPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApiPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApiPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApiPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApiRelease : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApiRelease(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ApiId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Notes { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpdatedOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApiRelease FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApiSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApiSchema(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Components { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Definitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceApi? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApiSchema FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceApiVersionSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceApiVersionSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VersionHeaderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.VersioningScheme> VersioningScheme { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VersionQueryName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceApiVersionSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceBackend : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceBackend(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ApiManagement.BackendServiceFabricClusterProperties BackendServiceFabricCluster { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.CircuitBreakerRule> CircuitBreakerRules { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ApiManagement.BackendPoolItem> PoolServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.BackendProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.BackendProxyContract Proxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.BackendTlsProperties Tls { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.BackendType> TypePropertiesType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceBackend FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceCertificate(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ApiManagement.KeyVaultContractCreateProperties KeyVaultDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceCertificate FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceDiagnostic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceDiagnostic(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.AlwaysLog> AlwaysLog { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Backend { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.PipelineDiagnosticSettings Frontend { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.HttpCorrelationProtocol> HttpCorrelationProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLogClientIPEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoggerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.OperationNameFormat> OperationNameFormat { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.SamplingSettings Sampling { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.TraceVerbosityLevel> Verbosity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceDiagnostic FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementGroupType> ApiManagementGroupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExternalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementGroupType> GroupType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsBuiltIn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceLogger : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceLogger(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsBuffered { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.LoggerType> LoggerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceLogger FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceNamedValue : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceNamedValue(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.KeyVaultContractProperties KeyVaultDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceNamedValue FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceNotification : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceNotification(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.RecipientsContractProperties Recipients { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceNotification FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspacePolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspacePolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspacePolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspacePolicyFragment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspacePolicyFragment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyFragmentContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspacePolicyFragment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceProduct : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceProduct(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsApprovalRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiManagementProductState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SubscriptionsLimit { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Terms { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceProduct FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceProductApiLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceProductApiLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApiId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceProductApiLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceProductGroupLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceProductGroupLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceProductGroupLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceProductPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceProductPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.PolicyContentFormat> Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceProduct? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceProductPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceSchema(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Document { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.ApiSchemaType> SchemaType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceSchema FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceSubscription(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowTracing { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotifiesOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OwnerId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ApiManagement.SubscriptionState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StateComment { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceSubscription FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceTag : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceTag(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.WorkspaceContract? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceTag FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceTagApiLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceTagApiLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApiId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceTag? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceTagApiLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceTagOperationLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceTagOperationLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OperationId { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceTag? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceTagOperationLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class ServiceWorkspaceTagProductLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceWorkspaceTagProductLink(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ServiceWorkspaceTag? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.ServiceWorkspaceTagProductLink FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public enum SoapApiType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        SoapToRest = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="soap")]
        SoapPassThrough = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="websocket")]
        WebSocket = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="graphql")]
        GraphQL = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="odata")]
        OData = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="grpc")]
        Grpc = 5,
    }
    public partial class SubscriptionKeyParameterNamesContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubscriptionKeyParameterNamesContract() { }
        public Azure.Provisioning.BicepValue<string> Header { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SubscriptionState
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="suspended")]
        Suspended = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="active")]
        Active = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="expired")]
        Expired = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="submitted")]
        Submitted = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rejected")]
        Rejected = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cancelled")]
        Cancelled = 5,
    }
    public partial class TenantAccessInfo : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TenantAccessInfo(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccessInfoType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDirectAccessEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.TenantAccessInfo FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class TermsOfServiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TermsOfServiceProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsConsentRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisplayEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Text { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TokenBodyParameterContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TokenBodyParameterContract() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TraceVerbosityLevel
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="verbose")]
        Verbose = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="information")]
        Information = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="error")]
        Error = 2,
    }
    public enum TranslateRequiredQueryParametersConduct
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="template")]
        Template = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="query")]
        Query = 1,
    }
    public partial class UserIdentityContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserIdentityContract() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Provider { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VersioningScheme
    {
        Segment = 0,
        Query = 1,
        Header = 2,
    }
    public partial class VirtualNetworkConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Subnetname { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> VnetId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualNetworkType
    {
        None = 0,
        External = 1,
        Internal = 2,
    }
    public partial class WikiDocumentationContract : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WikiDocumentationContract() { }
        public Azure.Provisioning.BicepValue<string> DocumentationId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceContract : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkspaceContract(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ApiManagement.ApiManagementService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ApiManagement.WorkspaceContract FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_05_01;
        }
    }
    public partial class X509CertificateName : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public X509CertificateName() { }
        public Azure.Provisioning.BicepValue<string> IssuerCertificateThumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
