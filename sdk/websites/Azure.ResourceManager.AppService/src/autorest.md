# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.AppService

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: AppService
namespace: Azure.ResourceManager.AppService
require: https://github.com/Azure/azure-rest-api-specs/blob/35f8a4df47aedc1ce185c854595cba6b83fa6c71/specification/web/resource-manager/readme.md
tag: package-2021-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{hostingEnvironmentName}/recommendations/{name}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/recommendations/{name}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots/{snapshotId}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots/{snapshotId}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkFeatures/{view}

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/capacities/virtualip
- /subscriptions/{subscriptionId}/providers/Microsoft.Web/locations/{location}/deletedSites/{deletedSiteId}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql/status
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkFeatures/{view}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}: WebSite
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}: WebSiteWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/ftp: WebSiteFtpPublishingCredentialsPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings/{connectionStringKey}: WebSiteConfigConnectionString
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}: WebSiteContinuousWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}: WebSiteHybridConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}: WebSitePremierAddon
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateAccess/virtualNetworks: WebSitePrivateAccess
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/resourceHealthMetadata/default: WebSiteResourceHealthMetadata
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}: WebSiteSlotTriggeredWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}: WebSiteSlotTriggeredWebJobHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web: WebSiteSourceControl
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions/{siteExtensionId}: WebSiteExtension
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}: WebSiteSlot
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs/{webJobName}: WebSiteSlotWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/ftp: WebSiteSlotFtpPublishingCredentialsPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}: WebSiteSlotConfigAppSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/connectionstrings/{connectionStringKey}: WebSiteSlotConfigConnectionString
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}: WebSiteSlotContinuousWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}: WebSiteSlotPremierAddOn
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks: WebSiteSlotPrivateAccess
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/resourceHealthMetadata/default: WebSiteSlotResourceHealthMetadata
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}: WebSiteTriggeredwebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}: WebSiteTriggeredWebJobHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/publicCertificates/{publicCertificateName}: WebSiteSlotPublicCertificate
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web: WebSiteSlotSourceControl
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}: WebSiteSlotHybridConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}: WebSiteSlotExtension
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}: AppServicePlanHybridConnectionNamespaceRelay
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}: AppServicePlanVirtualNetworkConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}: AppServicePlanVirtualNetworkConnectionGateway

override-operation-name:
  Diagnostics_ExecuteSiteAnalysis: Execute
  Diagnostics_ExecuteSiteDetector: Execute
  Recommendations_DisableRecommendationForSite: Disable
  WebApps_RunTriggeredWebJob: Run
  StaticSites_CreateOrUpdateStaticSiteAppSettings: CreateOrUpdateAppSettings
  StaticSites_CreateOrUpdateStaticSiteFunctionAppSettings: CreateOrUpdateFunctionAppSettings
  StaticSites_DeleteStaticSiteUser: DeleteUser
  StaticSites_DetachStaticSite: Detach
  StaticSites_ListStaticSiteAppSettings: GetAppSettings
  StaticSites_ListStaticSiteConfiguredRoles: GetConfiguredRoles
  StaticSites_ListStaticSiteFunctionAppSettings: GetFunctionAppSettings
  StaticSites_ListStaticSiteUsers: GetUsers
  StaticSites_ResetStaticSiteApiKey: ResetApiKey
  StaticSites_UpdateStaticSiteUser: UpdateUser
  CheckNameAvailability: CheckAppServiceNameAvailability
  AppServicePlans_ListHybridConnections: GetHybridConnectionRelays
  AppServicePlans_GetHybridConnection: GetHybridConnectionRelays
  StaticSites_CreateOrUpdateStaticSiteBuildAppSettings: CreateOrUpdateAppSettings
  StaticSites_CreateOrUpdateStaticSiteBuildFunctionAppSettings: CreateOrUpdateFunctionAppSettings
  StaticSites_ListStaticSiteBuildFunctions: GetFunctions
  StaticSites_CreateZipDeploymentForStaticSiteBuild: CreateZipDeployment
  StaticSites_ListStaticSiteBuildFunctionAppSettings: GetFunctionAppSettings
  AppServiceCertificateOrders_ValidatePurchaseInformation: ValidateAppServiceCertificateOrderPurchaseInformation
  Recommendations_ResetAllFilters: ResetAllRecommendationFilters
  StaticSites_PreviewWorkflow: PreviewStaticSiteWorkflow
  Provider_GetWebAppStacksForLocation: GetWebAppStacksByLocation
  GetSubscriptionDeploymentLocations: GetAppServiceDeploymentLocations
  Domains_ListRecommendations: GetAppServiceDomainRecommendations
  Domains_CheckAvailability: CheckAppServiceDomainRegistrationAvailability
  Recommendations_DisableRecommendationForSubscription: DisableAppServiceRecommendation
  ResourceHealthMetadata_ListByResourceGroup: GetAllResourceHealthMetadata
  WebApps_ListSnapshotsSlot: GetSlotSnapshots
  WebApps_ListSnapshotsFromDRSecondarySlot: GetSlotSnapshotsFromDRSecondary

no-property-type-replacement:
- ApiManagementConfig

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'serverFarmId': 'arm-id'

keep-plural-enums:
- StackPreferredOS

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  Ipssl: IPSsl|ipSsl
  WWW: Www
  Ms: MS

rename-mapping:
# site and site related
  Site: WebSite
  Site.properties.clientAffinityEnabled: IsClientAffinityEnabled
  Site.properties.clientCertEnabled: IsClientCertEnabled
  Site.properties.enabled: IsEnabled
  Site.properties.hostNamesDisabled: IsHostNameDisabled
  Site.properties.httpsOnly: IsHttpsOnly
  Site.properties.hyperV: IsHyperV
  Site.properties.reserved: IsReserved
  Site.properties.suspendedTill: SuspendOn
  Site.properties.storageAccountRequired: IsStorageAccountRequired
  Site.properties.serverFarmId: AppServicePlanId
  SiteAvailabilityState: WebSiteAvailabilityState
  Certificate: AppCertificate
  AppServiceCertificateOrderPatchResource: AppServiceCertificateOrderPatch
  AppServiceCertificatePatchResource: AppServiceCertificatePatch
  AppServiceEnvironmentPatchResource: AppServiceEnvironmentPatchContent
  AppserviceGithubToken: AppServiceGithubToken
  AppServicePlanPatchResource: AppServicePlanPatchContent
  Contact: ContactInformation
  Login: LoginInformation
  MSDeploy: MsDeploy
  MSDeployLog: MsDeployLog
  MSDeployLogEntry: MsDeployLogEntry
  Operation: OperationInformation
  Recommendation: AppServiceRecommendation
  Resource: AppServiceResource
  DetectorResponse: AppServiceDetector
  ApiKVReference: ApiKeyVaultReference
  Domain: AppServiceDomain
# rename property
  ValidateResourceTypes.Site: WebSite
  CheckNameResourceTypes.Site: WebSite
  ApiKVReference.properties.identityType: Identity
  AppServiceCertificateOrder.properties.autoRenew: IsAutoRenew
  AppServiceCertificateOrder.properties.expirationTime: ExpireOn
  AppServiceCertificateOrder.properties.lastCertificateIssuanceTime: LastCertificateIssuedOn
  AppServiceCertificateOrder.properties.nextAutoRenewalTimeStamp: NextAutoRenewTimeStamp
  Domain.properties.privacy: AppServiceHasPrivacy
  Domain.properties.expirationTime: ExpireOn
  Domain.properties.autoRenew: IsAutoRenew
  AppServicePlan.properties.elasticScaleEnabled: IsElasticScaleEnabled
  AppServicePlan.properties.freeOfferExpirationTime: FreeOfferExpiredOn
  AppServicePlan.properties.hyperV: IsHyperV
  AppServicePlan.properties.perSiteScaling: IsPerSiteScaling
  AppServicePlan.properties.reserved: IsReserved
  AppServicePlan.properties.spotExpirationTime: SpotExpireOn
  AppServicePlan.properties.zoneRedundant: IsZoneRedundant
  BackupItem.properties.created: CreatedOn
  BackupItem.properties.finishedTimeStamp: FinishedOn
  BackupItem.properties.lastRestoreTimeStamp: LastRestoreOn
  BackupItem.properties.scheduled: IsScheduled
  Certificate.properties.expirationDate: ExpireOn
  Certificate.properties.valid: IsValid
  ContinuousWebJob.properties.using_sdk: IsUsingSdk
  Deployment.properties.active: IsActive
  KubeEnvironment.properties.internalLoadBalancerEnabled: IsInternalLoadBalancerEnabled
  MigrateMySqlStatus.properties.localMySqlEnabled: IsLocalMySqlEnabled
  MSDeployStatus.properties.complete: IsComplete
  PrivateAccess.properties.enabled: IsEnabled
  ResourceHealthMetadata.properties.signalAvailability: IsSignalAvailable
  SiteConfig.properties.acrUseManagedIdentityCreds: HasAcrUseManagedIdentityCreds
  SiteConfig.properties.alwaysOn: IsAlwaysOn
  SiteConfig.properties.autoHealEnabled: IsAutoHealEnabled
  SiteConfig.properties.detailedErrorLoggingEnabled: IsDetailedErrorLoggingEnabled
  SiteConfig.properties.functionsRuntimeScaleMonitoringEnabled: IsFunctionsRuntimeScaleMonitoringEnabled
  SiteConfig.properties.http20Enabled: IsHttp20Enabled
  SiteConfig.properties.localMySqlEnabled: IsLocalMySqlEnabled
  SiteConfig.properties.remoteDebuggingEnabled: IsRemoteDebuggingEnabled
  SiteConfig.properties.requestTracingEnabled: IsRequestTracingEnabled
  SiteConfig.properties.vnetRouteAllEnabled: IsVnetRouteAllEnabled
  SiteConfig.properties.webSocketsEnabled: IsWebSocketsEnabled
  SiteSourceControl.properties.deploymentRollbackEnabled: IsDeploymentRollbackEnabled
  StaticSiteBuildARMResource.properties.createdTimeUtc: CreatedOn
  SwiftVirtualNetwork.properties.swiftSupported: IsSwiftSupported
  TopLevelDomain.properties.privacy: HasPrivacy
  TriggeredWebJob.properties.using_sdk: IsUsingSdk
  VnetInfoResource.properties.resyncRequired: IsResyncRequired
  WebJob.properties.using_sdk: IsUsingSdk
  CsmPublishingProfileOptions.includeDisasterRecoveryEndpoints: IsIncludeDisasterRecoveryEndpoints
  AppServiceCertificateOrderPatchResource.properties.autoRenew: IsAutoRenew
  DomainPatchResource.properties.autoRenew: IsAutoRenew
  DomainPatchResource.properties.privacy: HasPrivacy
  DomainPatchResource.properties.readyForDnsRecordManagement: IsReadyForDnsRecordManagement
  AppServiceEnvironmentResource.properties.suspended: IsSuspended
  AppServiceEnvironmentResource.properties.zoneRedundant: IsZoneRedundant
  AppServiceEnvironmentPatchResource.properties.suspended: IsSuspended
  AppServiceEnvironmentPatchResource.properties.zoneRedundant: IsZoneRedundant
  AppServicePlanPatchResource.properties.elasticScaleEnabled: IsElasticScaleEnabled
  AppServicePlanPatchResource.properties.hyperV: IsHyperV
  AppServicePlanPatchResource.properties.perSiteScaling: IsPerSiteScaling
  AppServicePlanPatchResource.properties.reserved: IsReserved
  AppServicePlanPatchResource.properties.zoneRedundant: IsZoneRedundant
  AuthPlatform.enabled: IsEnabled
  AzureActiveDirectory.enabled: IsEnabled
  AzureActiveDirectoryLogin.disableWWWAuthenticate: IsDisableWWWAuthenticate
  AzureBlobStorageHttpLogsConfig.enabled: IsEnabled
  AzureStaticWebApps.enabled: IsEnabled
  BackupRequest.properties.storageAccountUrl: IsEnabled
  CertificatePatchResource.properties.valid: IsValid
  CorsSettings.supportCredentials: IsCredentialsSupported
  CustomOpenIdConnectProvider.enabled: IsEnabled
  Dimension.toBeExportedForShoebox: IsToBeExportedForShoebox
  DomainAvailabilityCheckResult.available: IsAvailable
  Facebook.enabled: IsEnabled
  FileSystemHttpLogsConfig.enabled: IsEnabled
  FunctionAppRuntimeSettings.remoteDebuggingSupported: IsRemoteDebuggingSupported
  GitHub.enabled: IsEnabled
  GlobalValidation.requireAuthentication: IsAuthenticationRequired
  Google.enabled: IsEnabled
  HostNameSslState.toUpdate: IsToUpdate
  HttpSettings.requireHttps: IsHttpsRequired
  KubeEnvironmentPatchResource.properties.internalLoadBalancerEnabled: IsInternalLoadBalancerEnabled
  LegacyMicrosoftAccount.enabled: IsEnabled
  MetricSpecification.enableRegionalMdmAccount: IsRegionalMdmAccountEnabled
  MetricSpecification.supportsInstanceLevelAggregation: IsInstanceLevelAggregationSupported
  MSDeploy.properties.appOffline: IsAppOffline
  PremierAddOnOffer.properties.promoCodeRequired: IsPromoCodeRequired
  ResourceNameAvailability.nameAvailable: IsNameAvailable
  SiteAuthSettings.properties.enabled: IsEnabled
  SiteAuthSettings.properties.tokenStoreEnabled: IsTokenStoreEnabled
  SiteConfigProperties.alwaysOn: IsAlwaysOn
  SiteConfigProperties.autoHealEnabled: IsAutoHealEnabled
  SiteConfigProperties.functionsRuntimeScaleMonitoringEnabled: IsFunctionsRuntimeScaleMonitoringEnabled
  SiteConfigProperties.detailedErrorLoggingEnabled: IsDetailedErrorLoggingEnabled
  SiteConfigProperties.httpLoggingEnabled: IsHttpLoggingEnabled
  SiteConfigProperties.http20Enabled: IsHttp20Enabled
  SiteConfigProperties.localMySqlEnabled: IsLocalMySqlEnabled
  SiteConfigProperties.remoteDebuggingEnabled: IsRemoteDebuggingEnabled
  SiteConfigProperties.requestTracingEnabled: IsRequestTracingEnabled
  SiteConfigProperties.vnetRouteAllEnabled: IsVnetRouteAllEnabled
  SiteConfigProperties.webSocketsEnabled: IsWebSocketsEnabled
  SiteConfigurationSnapshotInfo.properties.time: SnapshotTakenTime
  SitePatchResource.properties.clientAffinityEnabled: IsClientAffinityEnabled
  SitePatchResource.properties.clientCertEnabled: IsClientCertEnabled
  SitePatchResource.properties.enabled: IsEnabled
  SitePatchResource.properties.hostNamesDisabled: IsHostNameDisabled
  SitePatchResource.properties.httpsOnly: IsHttpsOnly
  SitePatchResource.properties.hyperV: IsHyperV
  SitePatchResource.properties.lastModifiedTimeUtc: LastModifiedOn
  SitePatchResource.properties.scmSiteAlsoStopped: IsScmSiteAlsoStopped
  SitePatchResource.properties.storageAccountRequired: IsStorageAccountRequired
  SitePatchResource.properties.suspendedTill: SuspendOn
  SiteSealRequest.lightTheme: IsLightTheme
  StackMajorVersion.applicationInsights: IsApplicationInsights
  TokenStore.enabled: IsEnabled
  TopLevelDomainAgreementOption.forTransfer: IsForTransfer
  Twitter.enabled: IsEnabled
  VirtualApplication.preloadEnabled: IsPreloadEnabled
  VirtualIPMapping.inUse: IsInUse
  VnetInfo.resyncRequired: IsResyncRequired
  VnetValidationFailureDetails.properties.failed: IsFailed
  WebAppRuntimeSettings.remoteDebuggingSupported: IsRemoteDebuggingSupported
# rename resource
  AppServiceCertificate: AppServiceCertificateProperties
  AppServiceCertificateResource: AppServiceCertificate
  StaticSiteARMResource: StaticSite
  StaticSiteBuildARMResource: StaticSiteBuild
  StaticSiteCustomDomainOverviewARMResource: StaticSiteCustomDomainOverview
  StaticSiteUserProvidedFunctionAppARMResource: StaticSiteUserProvidedFunctionApp
  StaticSiteUserProvidedFunctionApp: StaticSiteUserProvidedFunctionAppProperties # just rename this to avoid collision, this class will be automatically removed
  StaticSiteCustomDomainRequestPropertiesARMResource: StaticSiteCustomDomainContent
# same name in model
#   VnetInfoResource: VnetInfo
  WorkerPoolResource: WorkerPool
  CsmPublishingProfileOptions: CsmPublishingProfile
  StaticSiteTemplateOptions: StaticSiteTemplate
  PrivateLinkResource: AppServicePrivateLinkResourceData
  PrivateLinkResourceProperties: AppServicePrivateLinkResourceProperties
  AzureStoragePropertyDictionaryResource: AzureStoragePropertyDictionary
  ContainerThrottlingData: ContainerThrottlingInfo
  DeletedAppRestoreRequest: DeletedAppRestoreContent
  DiagnosticData: DiagnosticInfo
  DomainControlCenterSsoRequest: DomainControlCenterSsoRequestInfo
  PerfMonResponse: PerfMonResponseInfo
  PrivateLinkConnectionApprovalRequestResource: PrivateLinkConnectionApprovalRequestInfo
  RestoreRequest: RestoreRequestInfo
  SitePatchResource: SitePatchInfo
  StaticSiteResetPropertiesARMResource: StaticSiteResetContent
  StaticSiteUserARMResource: StaticSiteUser
  StaticSiteUserInvitationRequestResource: StaticSiteUserInvitationContent
  StaticSiteUserInvitationResponseResource: StaticSiteUserInvitationResult
  StaticSiteZipDeploymentARMResource: StaticSiteZipDeployment
  StorageMigrationResponse: StorageMigrationResult
  Status: AppServiceStatusInfo
  AppServiceEnvironmentResource: AppServiceEnvironment
  AppServiceEnvironment: AppServiceEnvironmentProperties
  StringDictionary: AppServiceConfigurationDictionary
  StaticSiteFunctionOverviewARMResource: StaticSiteFunctionOverview
  ValidateRequest: AppServiceValidateContent
  ValidateResponse: AppServiceValidateResult
  SkuInfo: AppServicePoolSkuInfo
  SkuInfos: AppServiceSkuResult
  NameIdentifier: AppServiceDomainNameIdentifier
  SkuCapacity: AppServiceSkuCapacity
  SkuDescription: AppServiceSkuDescription
  Snapshot: AppSnapshot
  AnalysisDefinition: WebSiteAnalysisDefinition

# mgmt-debug:
#   show-serialized-names: true

directive:
# operation removal - should be temporary
# pageable lro
  - remove-operation: AppServiceEnvironments_ChangeVnet
  - remove-operation: AppServiceEnvironments_Resume
  - remove-operation: AppServiceEnvironments_Suspend
# these operations are apparently not operations in Microsoft.Web RP. Instead, their paths look like operations on resource groups
  - remove-operation: ValidateMove
  - remove-operation: Move
# this operation is a LRO operation
  - remove-operation: Global_GetSubscriptionOperationWithAsyncResponse
# ResourceId
  - from: Certificates.json
    where: $.definitions.Certificate.properties.properties.properties.serverFarmId
    transform: $["x-ms-format"] = "arm-id"
  - from: Certificates.json
    where: $.definitions.Certificate.properties.properties.properties.keyVaultId
    transform: $["x-ms-format"] = "arm-id"
  - from: Certificates.json
    where: $.definitions.CertificatePatchResource.properties.properties.properties.keyVaultId
    transform: $["x-ms-format"] = "arm-id"
  - from: Certificates.json
    where: $.definitions.CertificatePatchResource.properties.properties.properties.serverFarmId
    transform: $["x-ms-format"] = "arm-id"
# not sure
  - from: KubeEnvironments.json
    where: $.definitions.KubeEnvironment.properties.properties.properties.aksResourceID
    transform: $["x-ms-format"] = "arm-id"
  - from: KubeEnvironments.json
    where: $.definitions.StaticSiteUserProvidedFunctionAppARMResource.properties.properties.properties.functionAppResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: ResourceProvider.json
    where: $.definitions.VnetParameters.properties.properties.properties.subnetResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: WebApps.json
    where: $.definitions.SwiftVirtualNetwork.properties.properties.properties.subnetResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: WebApps.json
    where: $.definitions.SwiftVirtualNetwork.properties.properties.properties.serverFarmId
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.VnetInfo.properties.vnetResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: Recommendations.json
    where: $.definitions.Recommendation.properties.properties.properties.resourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: ResourceProvider.json
    where: $.definitions.BillingMeter.properties.properties.properties.meterId
    transform: $["x-ms-format"] = "uuid"
  - from: CommonDefinitions.json
    where: $.definitions.CloningInfo.properties.sourceWebAppId
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.CloningInfo.properties.trafficManagerProfileId
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.SupportTopic.properties.pesId
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.VnetInfo.properties.vnetResourceId
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.VirtualNetworkProfile.properties.id
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.VirtualNetworkProfile.properties.type
    transform: $["x-ms-format"] = "resource-type"
  - from: CommonDefinitions.json
    where: $.definitions.HostingEnvironmentProfile.properties.id
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.HostingEnvironmentProfile.properties.type
    transform: $["x-ms-format"] = "resource-type"
  - from: CommonDefinitions.json
    where: $.definitions.KubeEnvironmentProfile.properties.id
    transform: $["x-ms-format"] = "arm-id"
  - from: CommonDefinitions.json
    where: $.definitions.KubeEnvironmentProfile.properties.type
    transform: $["x-ms-format"] = "resource-type"
  - from: WebApps.json
    where: $.definitions.DeletedAppRestoreRequest.properties.properties.properties.deletedSiteId
    transform: $["x-ms-format"] = "arm-id"
  - from: ResourceProvider.json
    where: $.definitions.SkuInfos.properties.resourceType
    transform: $["x-ms-format"] = "resource-type"
  - from: ResourceProvider.json
    where: $.definitions.ValidateProperties.properties.serverFarmId
    transform: $["x-ms-format"] = "arm-id"
  - from: AppServiceEnvironments.json
    where: $.definitions.SkuInfo.properties.resourceType
    transform: $["x-ms-format"] = "resource-type"
  - from: WebApps.json
    where: $.definitions.SnapshotRecoverySource.properties.id
    transform: $["x-ms-format"] = "arm-id"
#   - from: StaticSites.json
#     where: $.definitions.StaticSiteUserProvidedFunctionApp.properties.properties.properties.functionAppResourceId
#     transform: $["x-ms-format"] = "arm-id"
  - from: StaticSites.json
    where: $.definitions.StaticSiteUserProvidedFunctionAppARMResource.properties.properties.properties.functionAppResourceId
    transform: $["x-ms-format"] = "arm-id"
# StaticSiteUserProvidedFunctionAppARMResource and StaticSiteUserProvidedFunctionApp are two models with exactly same properties but different names. Here we manually replace the references so that these two models are combined
  - from: StaticSites.json
    where: $.definitions.StaticSite.properties.userProvidedFunctionApps.items
    transform: $["$ref"] = "#/definitions/StaticSiteUserProvidedFunctionAppARMResource"
  - from: StaticSites.json
    where: $.definitions.StaticSiteBuildARMResource.properties.properties.properties.userProvidedFunctionApps.items
    transform: $["$ref"] = "#/definitions/StaticSiteUserProvidedFunctionAppARMResource"
#   - from: StaticSites.json
#     where: $.definitions.StaticSiteUserProvidedFunctionAppARMResource
#     transform: $["x-ms-client-name"] = "StaticSiteUserProvidedFunctionApp"
  - from: ResourceProvider.json
    where: $.definitions.VnetParameters.properties.properties.properties.subnetResourceId
    transform: $["x-ms-format"] = "arm-id"
# Enum rename
  - from: swagger-document
    where: $.definitions.AppServiceCertificateOrder.properties.properties.properties.appServiceCertificateNotRenewableReasons.items
    transform: >
      $["x-ms-enum"]={
            "name": "AppServiceCertificateNotRenewableReason",
            "modelAsString": true
          }
  - from: swagger-document
    where: $.definitions.AppServiceCertificateOrderPatchResource.properties.properties.properties.appServiceCertificateNotRenewableReasons.items
    transform: >
      $["x-ms-enum"]={
            "name": "AppServiceCertificateNotRenewableReason",
            "modelAsString": true
          }
  - from: swagger-document
    where: $.definitions.Domain.properties.properties.properties.domainNotRenewableReasons.items
    transform: >
      $["x-ms-enum"]={
            "name": "DomainNotRenewableReasons",
            "modelAsString": true
          }
  - from: swagger-document
    where: $.definitions.DomainPatchResource.properties.properties.properties.domainNotRenewableReasons.items
    transform: >
      $["x-ms-enum"]={
            "name": "DomainNotRenewableReasons",
            "modelAsString": true
          }
# get array
  - remove-operation: AppServicePlans_GetRouteForVnet
  - from: swagger-document
    where: $.definitions.AppServicePlan.properties.properties.properties.hostingEnvironmentProfile
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AppServicePlan.properties.properties.properties.spotExpirationTime
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AppServicePlan.properties.properties.properties.freeOfferExpirationTime
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.AppServicePlan.properties.properties.properties.kubeEnvironmentProfile
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.HostNameSslState.properties.toUpdate
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.SiteConfig.properties.*
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.SiteConfig
    transform: >
        $["x-ms-client-name"] = "SiteConfigProperties"
  - from: swagger-document
    where: $.definitions.SiteConfigResource
    transform: >
        $["x-ms-client-name"] = "SiteConfig"
  - from: swagger-document
    where: $.definitions.ApiManagementConfig.properties.*
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Site.properties.properties.properties.trafficManagerHostNames
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Site.properties.properties.properties.hostingEnvironmentProfile
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Site.properties.properties.properties.suspendedTill
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Site.properties.properties.properties.maxNumberOfWorkers
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Site.properties.properties.properties.cloningInfo
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Site.properties.properties.properties.slotSwapStatus
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Site.properties.properties.properties.inProgressOperationId
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.SiteSourceControl.properties.properties.properties.gitHubActionConfiguration
    transform: >
        $["x-nullable"] = true;
  - from: CommonDefinitions.json
    where: $.definitions.LogSpecification.properties.blobDuration
    transform: >
        $["format"] = "duration";
  - from: CommonDefinitions.json
    where: $.definitions.MetricAvailability.properties.blobDuration
    transform: >
        $["format"] = "duration";
  - from: WebApps.json
    where: $.definitions.TriggeredJobRun.properties.duration
    transform: >
        $["format"] = "duration";
        $["x-ms-format"] = "duration-constant";
```
