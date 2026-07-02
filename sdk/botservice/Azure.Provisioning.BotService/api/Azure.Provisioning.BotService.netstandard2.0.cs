namespace Azure.Provisioning.BotService
{
    public partial class AcsChatChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public AcsChatChannel() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlexaChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public AlexaChannel() { }
        public Azure.Provisioning.BotService.AlexaChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AlexaChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AlexaChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> AlexaSkillId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceEndpointUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UriFragment { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BotChannel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BotChannel(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotResource Parent { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotChannelProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotServiceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.BotService.BotChannel FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_09_15_PREVIEW;
        }
    }
    public partial class BotChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotChannelProperties() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BotConnectionSetting : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BotConnectionSetting(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotResource Parent { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotConnectionSettingProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotServiceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.BotService.BotConnectionSetting FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_09_15_PREVIEW;
        }
    }
    public partial class BotConnectionSettingParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotConnectionSettingParameter() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BotConnectionSettingProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotConnectionSettingProperties() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.BotConnectionSettingParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceProviderDisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceProviderId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SettingId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BotMsaAppType
    {
        UserAssignedMSI = 0,
        SingleTenant = 1,
        MultiTenant = 2,
    }
    public partial class BotProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotProperties() { }
        public Azure.Provisioning.BicepDictionary<string> AllSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppPasswordHint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CmekEncryptionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> CmekKeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ConfiguredChannels { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeveloperAppInsightKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeveloperAppInsightsApiKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeveloperAppInsightsApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnabledChannels { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndpointVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> IconUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCmekEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDeveloperAppInsightsApiKeySet { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStreamingSupported { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LuisAppIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LuisKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ManifestUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MigrationToken { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MsaAppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> MsaAppMSIResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MsaAppTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotMsaAppType> MsaAppType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.BotServiceNetworkSecurityPerimeterConfiguration> NetworkSecurityPerimeterConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OpenWithHint { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.BotServicePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServicePublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublishingCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaTransformationVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BotResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BotResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotServiceSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.BotService.BotResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_09_15_PREVIEW;
        }
    }
    public enum BotServiceAccessMode
    {
        Enforced = 0,
        Learning = 1,
        Audit = 2,
    }
    public enum BotServiceKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="sdk")]
        Sdk = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="designer")]
        Designer = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="bot")]
        Bot = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="function")]
        Function = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azurebot")]
        Azurebot = 4,
    }
    public partial class BotServiceNetworkSecurityPerimeterConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BotServiceNetworkSecurityPerimeterConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotResource Parent { get { throw null; } set { } }
        public Azure.Provisioning.BotService.NetworkSecurityPerimeterConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.BotService.BotServiceNetworkSecurityPerimeterConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_09_15_PREVIEW;
        }
    }
    public partial class BotServiceNetworkSecurityPerimeterProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotServiceNetworkSecurityPerimeterProfile() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.NspAccessRule> AccessRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> AccessRulesVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DiagnosticSettingsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EnabledLogCategories { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BotServiceNspAccessRuleSubscription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotServiceNspAccessRuleSubscription() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BotServicePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BotServicePrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BotService.BotServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotResource Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServicePrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.BotService.BotServicePrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_09_15_PREVIEW;
        }
    }
    public enum BotServicePrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum BotServicePrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class BotServicePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotServicePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServicePrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BotServiceProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Accepted = 2,
        Succeeded = 3,
        Failed = 4,
        Deleting = 5,
    }
    public enum BotServicePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public partial class BotServiceResourceAssociation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotServiceResourceAssociation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceAccessMode> AccessMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BotServiceSeverity
    {
        Warning = 0,
        Error = 1,
    }
    public partial class BotServiceSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BotServiceSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceSkuTier> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BotServiceSkuName
    {
        F0 = 0,
        S1 = 1,
    }
    public enum BotServiceSkuTier
    {
        Free = 0,
        Standard = 1,
    }
    public partial class DirectLineChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public DirectLineChannel() { }
        public Azure.Provisioning.BotService.DirectLineChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DirectLineChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DirectLineChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> DirectLineEmbedCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionKey1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionKey2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.DirectLineSite> Sites { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DirectLineSite : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DirectLineSite() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBlockUserUploadEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDetailedLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEndpointParametersEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNoStorageEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecureSiteEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsTokenEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsV1Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsV3Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWebchatPreviewEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWebChatSpeechEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key2 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SiteId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SiteName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TrustedOrigins { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DirectLineSpeechChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public DirectLineSpeechChannel() { }
        public Azure.Provisioning.BotService.DirectLineSpeechChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DirectLineSpeechChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DirectLineSpeechChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CognitiveServiceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomSpeechModelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomVoiceDeploymentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefaultBotForCogSvcAccount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EmailChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public EmailChannel() { }
        public Azure.Provisioning.BotService.EmailChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EmailChannelAuthMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="0")]
        Password = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="1")]
        Graph = 1,
    }
    public partial class EmailChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EmailChannelProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.EmailChannelAuthMethod> AuthMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EmailAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MagicCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FacebookChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public FacebookChannel() { }
        public Azure.Provisioning.BotService.FacebookChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FacebookChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FacebookChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AppSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> CallbackUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.FacebookPage> Pages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VerifyToken { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FacebookPage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FacebookPage() { }
        public Azure.Provisioning.BicepValue<string> AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KikChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public KikChannel() { }
        public Azure.Provisioning.BotService.KikChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KikChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KikChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> ApiKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsValidated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LineChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public LineChannel() { }
        public Azure.Provisioning.BotService.LineChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LineChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LineChannelProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> CallbackUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsValidated { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.LineRegistration> LineRegistrations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LineRegistration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LineRegistration() { }
        public Azure.Provisioning.BicepValue<string> ChannelAccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ChannelSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GeneratedId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class M365Extensions : Azure.Provisioning.BotService.BotChannelProperties
    {
        public M365Extensions() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MsTeamsChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public MsTeamsChannel() { }
        public Azure.Provisioning.BotService.MsTeamsChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MsTeamsChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MsTeamsChannelProperties() { }
        public Azure.Provisioning.BicepValue<bool> AcceptedTerms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CallingWebhook { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IncomingCallRoute { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCallingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeter() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PerimeterGuid { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkSecurityPerimeterConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityPerimeterConfigurationProperties() { }
        public Azure.Provisioning.BotService.NetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } }
        public Azure.Provisioning.BotService.BotServiceNetworkSecurityPerimeterProfile Profile { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.ProvisioningIssue> ProvisioningIssues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BotService.BotServiceResourceAssociation ResourceAssociation { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NspAccessRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NspAccessRule() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BotService.NspAccessRuleProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NspAccessRuleDirection
    {
        Inbound = 0,
        Outbound = 1,
    }
    public partial class NspAccessRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NspAccessRuleProperties() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.NspAccessRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } }
        public Azure.Provisioning.BicepList<string> FullyQualifiedDomainNames { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.NetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } }
        public Azure.Provisioning.BicepList<string> PhoneNumbers { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.BotServiceNspAccessRuleSubscription> Subscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OmniChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public OmniChannel() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OutlookChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public OutlookChannel() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ProvisioningIssue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProvisioningIssue() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BotService.ProvisioningIssueProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ProvisioningIssueProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ProvisioningIssueProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IssueType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.BotService.BotServiceSeverity> Severity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.NspAccessRule> SuggestedAccessRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> SuggestedResourceIds { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SearchAssistant : Azure.Provisioning.BotService.BotChannelProperties
    {
        public SearchAssistant() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SkypeChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public SkypeChannel() { }
        public Azure.Provisioning.BotService.SkypeChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SkypeChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SkypeChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> CallingWebHook { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupsMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IncomingCallRoute { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCallingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGroupsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMediaCardsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMessagingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsScreenSharingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsVideoEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SlackChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public SlackChannel() { }
        public Azure.Provisioning.BotService.SlackChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SlackChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SlackChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsValidated { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> LandingPageUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastSubmissionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RedirectAction { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> RegisterBeforeOAuthFlow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scopes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SigningSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VerificationToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SmsChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public SmsChannel() { }
        public Azure.Provisioning.BotService.SmsChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SmsChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SmsChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> AccountSID { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsValidated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TelegramChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public TelegramChannel() { }
        public Azure.Provisioning.BotService.TelegramChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TelegramChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TelegramChannelProperties() { }
        public Azure.Provisioning.BicepValue<string> AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsValidated { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TelephonyChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public TelephonyChannel() { }
        public Azure.Provisioning.BotService.TelephonyChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TelephonyChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TelephonyChannelProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.TelephonyChannelResourceApiConfiguration> ApiConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultLocale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.TelephonyPhoneNumbers> PhoneNumbers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PremiumSku { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TelephonyChannelResourceApiConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TelephonyChannelResourceApiConfiguration() { }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CognitiveServiceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultLocale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProviderName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TelephonyPhoneNumbers : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TelephonyPhoneNumbers() { }
        public Azure.Provisioning.BicepValue<string> AcsEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AcsResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcsSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CognitiveServiceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultLocale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OfferType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhoneNumber { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebChatChannel : Azure.Provisioning.BotService.BotChannelProperties
    {
        public WebChatChannel() { }
        public Azure.Provisioning.BotService.WebChatChannelProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebChatChannelProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebChatChannelProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BotService.WebChatSite> Sites { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebChatEmbedCode { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebChatSite : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebChatSite() { }
        public Azure.Provisioning.BicepValue<string> AppId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsBlockUserUploadEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDetailedLoggingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEndpointParametersEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNoStorageEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecureSiteEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsTokenEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsV1Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsV3Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWebchatPreviewEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWebChatSpeechEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Key2 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SiteId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SiteName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TrustedOrigins { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
