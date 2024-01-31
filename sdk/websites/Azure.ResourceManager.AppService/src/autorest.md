# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.AppService

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: AppService
namespace: Azure.ResourceManager.AppService
require: https://github.com/Azure/azure-rest-api-specs/blob/35f8a4df47aedc1ce185c854595cba6b83fa6c71/specification/web/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

# mgmt-debug:
#  show-serialized-names: true

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
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}: WebSiteTriggeredwebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}: WebSiteTriggeredWebJobHistory
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
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}: WebSiteSlotTriggeredWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}: WebSiteSlotTriggeredWebJobHistory
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
  WebApps_ListSnapshotsSlot: GetSlotSnapshots
  WebApps_ListSnapshotsFromDRSecondarySlot: GetSlotSnapshotsFromDRSecondary
  # All bellowing operations should be EBNerver once the polymorphic change is ready
  AppServiceEnvironments_ListWebApps: GetAllWebAppData
  ResourceHealthMetadata_ListByResourceGroup: GetAllResourceHealthMetadataData
  ListSiteIdentifiersAssignedToHostName: GetAllSiteIdentifierData
  WebApps_ListConfigurations: GetAllConfigurationData
  WebApps_ListHybridConnections: GetAllHybridConnectionData
  WebApps_ListPremierAddOns: GetAllPremierAddOnData
  WebApps_ListRelayServiceConnections: GetAllRelayServiceConnectionData
  WebApps_ListSiteBackups: GetAllSiteBackupData
  WebApps_ListConfigurationsSlot: GetAllConfigurationSlotData
  WebApps_ListHybridConnectionsSlot: GetAllHybridConnectionSlotData
  WebApps_ListPremierAddOnsSlot: GetAllPremierAddOnSlotData
  WebApps_ListRelayServiceConnectionsSlot: GetAllRelayServiceConnectionSlotData
  WebApps_ListSiteBackupsSlot: GetAllSiteBackupSlotData

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

acronym-mapping:
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
  Db: DB
  SQL: Sql

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
  Site.properties.serverFarmId: AppServicePlanId|arm-id
  SiteAvailabilityState: WebSiteAvailabilityState
  Certificate: AppCertificate
  AppServiceCertificateOrderPatchResource: AppServiceCertificateOrderPatch
  AppServiceCertificatePatchResource: AppServiceCertificatePatch
  AppServiceEnvironmentPatchResource: AppServiceEnvironmentPatchContent
  AppserviceGithubToken: AppServiceGithubToken
  AppServicePlanPatchResource: AppServicePlanPatchContent
  Contact: RegistrationContactInfo
  Login: WebAppLoginInfo
  Recommendation: AppServiceRecommendation
  Resource: AppServiceResource
  DetectorResponse: AppServiceDetector
  ApiKVReference: ApiKeyVaultReference
  Domain: AppServiceDomain
# rename property
  Apple.enabled: IsEnabled
  BackupRequest.properties.enabled: IsEnabled
  BackupSchedule.keepAtLeastOneBackup: ShouldKeepAtLeastOneBackup
  BackupSchedule.lastExecutionTime: LastExecutedOn
  BillingMeter.properties.meterId: -|uuid
  SiteConfig.properties.httpLoggingEnabled: IsHttpLoggingEnabled
  SiteConfig.properties.scmIpSecurityRestrictionsUseMain: AllowIPSecurityRestrictionsForScmToUseMain
  SiteConfigProperties.scmIpSecurityRestrictionsUseMain: AllowIPSecurityRestrictionsForScmToUseMain
  SitePatchResource.properties.virtualNetworkSubnetId: -|arm-id
  Site.properties.virtualNetworkSubnetId: -|arm-id
  PrivateAccessVirtualNetwork.resourceId: -|arm-id
  KubeEnvironmentPatchResource.properties.aksResourceID: -|arm-id
  KubeEnvironment.properties.aksResourceID: -|arm-id
  SiteConfigProperties.acrUseManagedIdentityCreds: UseManagedIdentityCreds
  SkuDescription.locations: -|azure-location
  GlobalCsmSkuDescription.locations: -|azure-location
  Certificate.properties.keyVaultId: -|arm-id
  AppServiceCertificateResource.properties.keyVaultId: -|arm-id
  CertificatePatchResource.properties.keyVaultId: -|arm-id
  AppServiceCertificatePatchResource.properties.keyVaultId: -|arm-id
  AppServiceCertificate.keyVaultId: -|arm-id
  SwiftVirtualNetwork.properties.subnetResourceId: -|arm-id
  VnetParameters.properties.subnetResourceId: -|arm-id
  IpSecurityRestriction.vnetSubnetResourceId: -|arm-id
  AddressResponse.properties.internalIpAddress: -|ip-address
  AddressResponse.properties.outboundIpAddresses: -|ip-address
  AddressResponse.properties.serviceIpAddress: -|ip-address
  EndpointDetail.ipAddress: -|ip-address
  IpSecurityRestriction.ipAddress: IPAddressOrCidr
  Operation.idL -|arm-id: -|arm-id
  AseV3NetworkingConfiguration.properties.windowsOutboundIpAddresses: -|ip-address
  AseV3NetworkingConfiguration.properties.linuxOutboundIpAddresses: -|ip-address
  AseV3NetworkingConfiguration.properties.externalInboundIpAddresses: -|ip-address
  AseV3NetworkingConfiguration.properties.internalInboundIpAddresses: -|ip-address
  RemotePrivateEndpointConnectionARMResource.properties.ipAddresses: -|ip-address
  RemotePrivateEndpointConnection.properties.ipAddresses: -|ip-address
  Site.properties.scmSiteAlsoStopped: IsScmSiteAlsoStopped
  AppServiceEnvironment.suspended: IsSuspended
  SitePatchResource.properties.reserved: IsReserved
  Domain.properties.privacy: IsDomainPrivacyEnabled
  Domain.properties.readyForDnsRecordManagement: IsDnsRecordManagementReady
  SiteLogsConfig.properties.detailedErrorMessages: IsDetailedErrorMessages  # The autogened name by safe flatten which can't be renamed by other configs
  SiteLogsConfig.properties.failedRequestsTracing: IsFailedRequestsTracing  # The autogened name by safe flatten which can't be renamed by other configs
  AppServiceEnvironment.zoneRedundant: IsZoneRedundant
  CloningInfo.overwrite: CanOverwrite
  RestoreRequest.properties.overwrite: CanOverwrite
  SnapshotRestoreRequest.properties.overwrite: CanOverwrite
  ValidateResourceTypes.Site: WebSite
  CheckNameResourceTypes.Site: WebSite
  ApiKVReference.properties.identityType: Identity
  AppServiceCertificateOrder.properties.autoRenew: IsAutoRenew
  AppServiceCertificateOrder.properties.expirationTime: ExpireOn
  AppServiceCertificateOrder.properties.lastCertificateIssuanceTime: LastCertificateIssuedOn
  AppServiceCertificateOrder.properties.nextAutoRenewalTimeStamp: NextAutoRenewTimeStamp
  Domain.properties.expirationTime: ExpireOn
  Domain.properties.autoRenew: IsAutoRenew
  AppServicePlan.properties.elasticScaleEnabled: IsElasticScaleEnabled
  AppServicePlan.properties.freeOfferExpirationTime: FreeOfferExpireOn
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
  SiteConfig.properties.acrUseManagedIdentityCreds: UseManagedIdentityCreds
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
  TopLevelDomain.properties.privacy: IsDomainPrivacySupported
  TriggeredWebJob.properties.using_sdk: IsUsingSdk
  VnetInfoResource.properties.resyncRequired: IsResyncRequired
  WebJob.properties.using_sdk: IsUsingSdk
  CsmPublishingProfileOptions.includeDisasterRecoveryEndpoints: IsIncludeDisasterRecoveryEndpoints
  AppServiceCertificateOrderPatchResource.properties.autoRenew: IsAutoRenew
  DomainPatchResource.properties.autoRenew: IsAutoRenew
  DomainPatchResource.properties.privacy: IsDomainPrivacyEnabled
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
  AzureActiveDirectoryLogin.disableWWWAuthenticate: IsWwwAuthenticateDisabled
  AzureBlobStorageHttpLogsConfig.enabled: IsEnabled
  AzureStaticWebApps.enabled: IsEnabled
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
  BackupItem.properties.name: BackupName
  ApplicationStackResource.properties.name: StackName
  BillingMeter.properties.billingLocation: -|azure-location
  AddressResponse.properties.vipMappings: VirtualIPMappings
  CloningInfo.sourceWebAppLocation: -|azure-location
  AzureTableStorageApplicationLogsConfig.sasUrl: SasUriString
  WebSiteInstanceStatus.properties.healthCheckUrl: healthCheckUrlString

# rename resource
  AppServiceCertificate: AppServiceCertificateProperties
  AppServiceCertificateResource: AppServiceCertificate
  StaticSiteARMResource: StaticSite
  StaticSiteBuildARMResource: StaticSiteBuild
  StaticSiteCustomDomainOverviewARMResource: StaticSiteCustomDomainOverview
  StaticSiteUserProvidedFunctionAppARMResource: StaticSiteUserProvidedFunctionApp
  StaticSiteUserProvidedFunctionApp: StaticSiteUserProvidedFunctionAppProperties # just rename this to avoid collision, this class will be automatically removed
  StaticSiteCustomDomainRequestPropertiesARMResource: StaticSiteCustomDomainContent
  User: PublishingUser
  WorkerPoolResource: AppServiceWorkerPool
  CsmPublishingProfileOptions: CsmPublishingProfile
  StaticSiteTemplateOptions: StaticSiteTemplate
  PrivateLinkResource: AppServicePrivateLinkResourceData
  PrivateLinkResourceProperties: AppServicePrivateLinkResourceProperties
  AzureStoragePropertyDictionaryResource: AzureStoragePropertyDictionary
  ContainerThrottlingData: ContainerThrottlingInfo
  DeletedAppRestoreRequest: DeletedAppRestoreContent
  DiagnosticData: DiagnosticDataset
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
  Address: RegistrationAddressInfo
  AddressResponse: AppServiceEnvironmentAddressResult
  AllowedPrincipals: AppServiceAadAllowedPrincipals
  AnalysisData: AnalysisDetectorEvidences
  Apple: AppServiceAppleProvider
  AppleRegistration: AppServiceAppleRegistration
  AzureActiveDirectory: AppServiceAadProvider
  AzureActiveDirectoryLogin: AppServiceAadLoginFlow
  AzureActiveDirectoryRegistration: AppServiceAadRegistration
  AzureActiveDirectoryValidation: AppServiceAadValidation
  AzureBlobStorageApplicationLogsConfig: AppServiceBlobStorageApplicationLogsConfig
  AzureBlobStorageHttpLogsConfig: AppServiceBlobStorageHttpLogsConfig
  AzureResourceType: AppServiceResourceType
  AzureStaticWebApps: AppServiceStaticWebAppsProvider
  AzureStaticWebAppsRegistration: AppServiceStaticWebAppsRegistration
  AzureStorageInfoValue: AppServiceStorageAccessInfo
  AzureStoragePropertyDictionary: AppServiceStorageDictionaryResourceData
  AzureStorageState: AppServiceStorageAccountState
  AzureStorageType: AppServiceStorageType
  AzureTableStorageApplicationLogsConfig: AppServiceTableStorageApplicationLogsConfig
  BackupItem: WebAppBackup
  BackupItemStatus: WebAppBackupStatus
  BackupRequest: WebAppBackupInfo
  BackupSchedule: WebAppBackupSchedule
  BuildStatus: StaticSiteBuildStatus
  Capability: AppServiceSkuCapability
  Channels: RecommendationChannel
  ResponseMetaData: DetectorMetadata
  DataSource: DetectorDataSource
  Deployment: WebAppDeployment
  Dimension: MetricDimension
  EnabledConfig: WebAppEnabledConfig
  Experiments: RoutingRuleExperiments
  Facebook: AppServiceFacebookProvider
  FrequencyUnit: BackupFrequencyUnit
  GitHub: AppServiceGitHubProvider
  Google: AppServiceGoogleProvider
  HandlerMapping: HttpRequestHandlerMapping
  HostKeys: FunctionAppHostKeys
  Twitter: AppServiceTwitterProvider
  InsightStatus: DetectorInsightStatus
  LogLevel: WebAppLogLevel
  MSDeploy: WebAppMSDeploy
  MSDeployLog: WebAppMSDeployLog
  MSDeployLogEntry: WebAppMSDeployLogEntry
  MSDeployLogEntryType: WebAppMSDeployLogEntryType
  NetworkTrace: WebAppNetworkTrace
  Nonce: LoginFlowNonceSettings
  PushSettings: WebAppPushSettings
  Rendering: DiagnosticDataRendering
  RenderingType: DiagnosticDataRenderingType
  RouteType: AppServiceVirtualNetworkRouteType
  Solution: DiagnosticSolution
  SolutionType: DiagnosticSolutionType
  SslState: HostNameBindingSslState
  StorageType: ArtifactStorageType
  StringList: StaticSiteStringList
  StatusOptions: AppServicePlanStatus
  TriggerTypes: FunctionTriggerType
  CookieExpiration: WebAppCookieExpiration
  KeyInfo: WebAppKeyInfo
  KeyValuePairStringObject: DataProviderKeyValuePair
  IssueType: DetectorIssueType
  VnetInfo: AppServiceVirtualNetworkProperties
  VnetInfoResource: AppServiceVirtualNetwork
  VnetParameters: AppServiceVirtualNetworkValidationContent
  VnetRoute: AppServiceVirtualNetworkRoute
  VnetGateway: AppServiceVirtualNetworkGateway
  SupportTopic: DetectorSupportTopic
  SupportedTlsVersions: AppServiceSupportedTlsVersion
  VnetValidationFailureDetails: VirtualNetworkValidationFailureDetails
  VnetValidationTestFailure: VirtualNetworkValidationTestFailure
  KeyInfoProperties: WebAppKeyInfoProperties
  # All `Collection` models for pageable operation should be renamed to `ListResult`, https://github.com/Azure/autorest.csharp/issues/2756
  DomainCollection: AppServiceDomainListResult
  IdentifierCollection: AppServiceIdentifierListResult
  DeletedWebAppCollection: DeletedWebAppListResult
  DeploymentCollection: WebAppDeploymentListResult
  BackupItemCollection: WebAppBackupItemListResult
  BillingMeterCollection: AppServiceBillingMeterListResult
  NameIdentifierCollection: AppServiceDomainNameIdentifierListResult
  UsageCollection: AppServiceUsageListResult
  ResourceCollection: AppServicePlanResourceListResult
  SourceControlCollection: AppServiceSourceControlListResult
  ApiKVReferenceCollection: AppServiceApiKeyVaultReferenceList
  AppServicePlanCollection: AppServicePlanListResult
  ApplicationStackCollection: ApplicationStackListResult
  AppServiceCertificateCollection: AppServiceCertificateListResult
  AppServiceCertificateOrderCollection: AppServiceCertificateOrderListResult
  AppServiceEnvironmentCollection: AppServiceEnvironmentListResult
  CertificateCollection: AppCertificateListResult
  ContinuousWebJobCollection: ContinuousWebJobListResult
  CsmOperationCollection: CsmOperationListResult
  CsmUsageQuotaCollection: CsmUsageQuotaListResult
  DetectorResponseCollection: AppServiceDetectorListResult
  DiagnosticAnalysisCollection: WebSiteAnalysisDefinitionListResult
  DiagnosticCategoryCollection: DiagnosticCategoryListResult
  DiagnosticDetectorCollection: DiagnosticDetectorListResult
  DomainOwnershipIdentifierCollection: DomainOwnershipIdentifierListResult
  FunctionAppStackCollection: FunctionAppStackListResult
  FunctionEnvelopeCollection: FunctionEnvelopeListResult
  GeoRegionCollection: AppServiceGeoRegionListResult
  HostNameBindingCollection: HostNameBindingListResult
  HybridConnectionCollection: HybridConnectionListResult
  InboundEnvironmentEndpointCollection: InboundEnvironmentEndpointListResult
  KubeEnvironmentCollection: KubeEnvironmentListResult
  OutboundEnvironmentEndpointCollection: OutboundEnvironmentEndpointListResult
  PerfMonCounterCollection: PerfMonCounterListResult
  PremierAddOnOfferCollection: PremierAddOnOfferListResult
  PrivateEndpointConnectionCollection: RemotePrivateEndpointConnectionListResult
  ProcessInfoCollection: ProcessInfoListResult
  ProcessModuleInfoCollection: ProcessModuleInfoListResult
  ProcessThreadInfoCollection: ProcessThreadInfoListResult
  PublicCertificateCollection: PublicCertificateListResult
  PublishingCredentialsPoliciesCollection: PublishingCredentialsPoliciesListResult
  RecommendationCollection: AppServiceRecommendationListResult
  ResourceHealthMetadataCollection: ResourceHealthMetadataListResult
  ResourceMetricDefinitionCollection: ResourceMetricDefinitionListResult
  SiteConfigResourceCollection: SiteConfigListResult
  SiteConfigurationSnapshotInfoCollection: SiteConfigurationSnapshotInfoListResult
  SiteExtensionInfoCollection: SiteExtensionInfoListResult
  SkuInfoCollection: AppServicePoolSkuInfoListResult
  SlotDifferenceCollection: SlotDifferenceListResult
  SnapshotCollection: AppSnapshotListResult
  StampCapacityCollection: StampCapacityListResult
  StaticSiteBuildCollection: StaticSiteBuildListResult
  StaticSiteCollection: StaticSiteListResult
  StaticSiteCustomDomainOverviewCollection: StaticSiteCustomDomainOverviewListResult
  StaticSiteFunctionOverviewCollection: StaticSiteFunctionOverviewListResult
  StaticSiteUserCollection: StaticSiteUserListResult
  StaticSiteUserProvidedFunctionAppsCollection: StaticSiteUserProvidedFunctionAppsListResult
  TldLegalAgreementCollection: TldLegalAgreementListResult
  TopLevelDomainCollection: TopLevelDomainListResult
  TriggeredJobHistoryCollection: TriggeredJobHistoryListResult
  TriggeredWebJobCollection: TriggeredWebJobListResult
  WebAppCollection: WebAppListResult
  WebAppInstanceStatusCollection: WebAppInstanceStatusListResult
  WebAppStackCollection: WebAppStackListResult
  WebJobCollection: WebJobCListResult
  WorkerPoolCollection: AppServiceWorkerPoolListResult
  HybridConnection.properties.relayArmUri: relayArmId|arm-id
  AzureActiveDirectoryRegistration.clientSecretCertificateThumbprint: ClientSecretCertificateThumbprintString
  Certificate.properties.thumbprint: ThumbprintString
  CertificateDetails.thumbprint: ThumbprintString
  CertificatePatchResource.properties.thumbprint: ThumbprintString
  HostNameBinding.properties.thumbprint: ThumbprintString
  HostNameSslState.thumbprint: ThumbprintString
  PublicCertificate.properties.thumbprint: ThumbprintString
  SiteAuthSettings.properties.clientSecretCertificateThumbprint: ClientSecretCertificateThumbprintString
  VnetInfoResource.properties.certThumbprint: CertThumbprintString
  VnetInfo.certThumbprint: CertThumbprintString

prepend-rp-prefix:
  - ApiDefinitionInfo
  - ApiKeyVaultReferenceData
  - ArmPlan
  - BillingMeter
  - BlobStorageTokenStore
  - TokenStore
  - CertificateDetails
  - CertificateEmail
  - DatabaseBackupSetting
  - DatabaseType
  - DeploymentLocations
  - GeoRegion
  - DnsType
  - DomainStatus
  - DomainType
  - EndpointDependency
  - EndpointDetail
  - FtpsState
  - HostName
  - HostNameType
  - HostType
  - HttpSettings
  - HttpLogsConfig
  - HttpSettingsRoutes
  - Identifier
  - IdentityProviders
  - NameValuePair
  - OperationStatus
  - Operation
  - UsageState
  - CorsSettings
  - SourceControl
  - ForwardProxy
  - IpSecurityRestriction
  - IpFilterTag
  - VirtualNetworkProfile

models-to-treat-empty-string-as-null:
  - WebAppBackupData
  - WebSiteInstanceStatusData

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
  - from: KubeEnvironments.json
    where: $.definitions.StaticSiteUserProvidedFunctionAppARMResource.properties.properties.properties.functionAppResourceId
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
# workaround incorrect definition in swagger before it's fixed. github issue 35146
  - from: WebApps.json
    where: $.definitions.KeyInfo
    transform: >
      $["properties"] = {
        "properties":{
          "description": "Properties of function key info.",
          "type": "object",
          "properties": {
            "name": {
              "description": "Key name",
              "type": "string"
            },
            "value": {
              "description": "Key value",
              "type": "string"
            }
          }
        }
      }
    reason: workaround incorrect definition in swagger before it's fixed. github issue 35146
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
  - from: WebApps.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/syncfunctiontriggers'].post
    transform: >
        $['responses'] = {
            "200":{
                "description": "No Content"
            },
            "204": {
                "description": "No Content"
            },
            "default": {
                "description": "App Service error response.",
                "schema": {
                    "$ref": "./CommonDefinitions.json#/definitions/DefaultErrorResponse"
                }
            }
        };
```
