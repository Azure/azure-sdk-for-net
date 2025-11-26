# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.AppService

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: AppService
namespace: Azure.ResourceManager.AppService
require: https://github.com/Azure/azure-rest-api-specs/blob/7b956d28f9182fe7ddc319d43495e19fff57457b/specification/web/resource-manager/Microsoft.Web/AppService/readme.md
#tag: package-2025-03
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
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
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/deploymentStatus/{deploymentStatusId}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/deploymentStatus/{deploymentStatusId}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/authsettingsV2
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/authsettingsV2

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
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/runs/{runName}/actions/{actionName}/repetitions/{repetitionName}: WorkflowRunActionRepetition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/runs/{runName}/actions/{actionName}/scopeRepetitions/{repetitionName}: WorkflowRunActionScopeRepetition
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sitecontainers/{containerName}: SiteContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sitecontainers/{containerName}:  SiteSlotSiteContainer
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}: AppServicePlanHybridConnectionNamespaceRelay
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}: AppServicePlanVirtualNetworkConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/virtualNetworkConnections/{vnetName}/gateways/{gatewayName}: AppServicePlanVirtualNetworkConnectionGateway
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/certificates/{name}: AppCertificate

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
  AppServicePlans_ListWebAppsByHybridConnection: GetAllWebAppsByHybridConnection
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
  WebApps_ListHybridConnections: GetHybridConnections
  WebApps_ListPremierAddOns: GetAllPremierAddOnData
  WebApps_ListRelayServiceConnections: GetAllRelayServiceConnectionData
  WebApps_ListSiteBackups: GetAllSiteBackupData
  WebApps_ListConfigurationsSlot: GetAllConfigurationSlotData
  WebApps_ListHybridConnectionsSlot: GetHybridConnectionsSlot
  WebApps_ListPremierAddOnsSlot: GetAllPremierAddOnSlotData
  WebApps_ListRelayServiceConnectionsSlot: GetAllRelayServiceConnectionSlotData
  WebApps_ListSiteBackupsSlot: GetAllSiteBackupSlotData
  WebApps_ListInstanceProcessThreads: GetSiteInstanceProcessThreads
  WebApps_ListProcessThreads: GetSiteProcessThreads
  WebApps_ListProcessThreadsSlot: GetSiteSlotProcessThreads
  WebApps_ListInstanceProcessThreadsSlot: GetSiteSlotInstanceProcessThreads
  RegionalCheckNameAvailability: CheckDnlResourceNameAvailability

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

irregular-plural-words:
  status: status

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
  Address: RegistrationAddressInfo
  AddressResponse.properties.internalIpAddress: -|ip-address
  AddressResponse.properties.outboundIpAddresses: -|ip-address
  AddressResponse.properties.serviceIpAddress: -|ip-address
  AddressResponse.properties.vipMappings: VirtualIPMappings
  AddressResponse: AppServiceEnvironmentAddressResult
  AllowedPrincipals: AppServiceAadAllowedPrincipals
  AnalysisData: AnalysisDetectorEvidences
  AnalysisDefinition: WebSiteAnalysisDefinition
  ApiKVReference.properties.identityType: Identity
  ApiKVReference: ApiKeyVaultReference
  ApiKVReferenceCollection: AppServiceApiKeyVaultReferenceList
  Apple.enabled: IsEnabled
  Apple: AppServiceAppleProvider
  AppleRegistration: AppServiceAppleRegistration
  ApplicationStackCollection: ApplicationStackListResult
  ApplicationStackResource.properties.name: StackName
  AppServiceCertificate.keyVaultId: -|arm-id
  AppServiceCertificate: AppServiceCertificateProperties
  AppServiceCertificateCollection: AppServiceCertificateListResult
  AppServiceCertificateOrder.properties.autoRenew: IsAutoRenew
  AppServiceCertificateOrder.properties.expirationTime: ExpireOn
  AppServiceCertificateOrder.properties.lastCertificateIssuanceTime: LastCertificateIssuedOn
  AppServiceCertificateOrder.properties.nextAutoRenewalTimeStamp: NextAutoRenewTimeStamp
  AppServiceCertificateOrderCollection: AppServiceCertificateOrderListResult
  AppServiceCertificateOrderPatchResource.properties.autoRenew: IsAutoRenew
  AppServiceCertificateOrderPatchResource: AppServiceCertificateOrderPatch
  AppServiceCertificatePatchResource.properties.keyVaultId: -|arm-id
  AppServiceCertificatePatchResource: AppServiceCertificatePatch
  AppServiceCertificateResource.properties.keyVaultId: -|arm-id
  AppServiceCertificateResource: AppServiceCertificate
  AppServiceEnvironment.suspended: IsSuspended
  AppServiceEnvironment.zoneRedundant: IsZoneRedundant
  AppServiceEnvironment: AppServiceEnvironmentProperties
  AppServiceEnvironmentCollection: AppServiceEnvironmentListResult
  AppServiceEnvironmentPatchResource.properties.suspended: IsSuspended
  AppServiceEnvironmentPatchResource.properties.zoneRedundant: IsZoneRedundant
  AppServiceEnvironmentPatchResource: AppServiceEnvironmentPatchContent
  AppServiceEnvironmentResource.properties.suspended: IsSuspended
  AppServiceEnvironmentResource.properties.zoneRedundant: IsZoneRedundant
  AppServiceEnvironmentResource: AppServiceEnvironment
  AppserviceGithubToken: AppServiceGithubToken
  AppServicePlan.properties.asyncScalingEnabled: IsAsyncScalingEnabled
  AppServicePlan.properties.elasticScaleEnabled: IsElasticScaleEnabled
  AppServicePlan.properties.freeOfferExpirationTime: FreeOfferExpireOn
  AppServicePlan.properties.hyperV: IsHyperV
  AppServicePlan.properties.perSiteScaling: IsPerSiteScaling
  AppServicePlan.properties.reserved: IsReserved
  AppServicePlan.properties.spotExpirationTime: SpotExpireOn
  AppServicePlan.properties.zoneRedundant: IsZoneRedundant
  AppServicePlanCollection: AppServicePlanListResult
  AppServicePlanPatchResource.properties.elasticScaleEnabled: IsElasticScaleEnabled
  AppServicePlanPatchResource.properties.hyperV: IsHyperV
  AppServicePlanPatchResource.properties.perSiteScaling: IsPerSiteScaling
  AppServicePlanPatchResource.properties.reserved: IsReserved
  AppServicePlanPatchResource.properties.zoneRedundant: IsZoneRedundant
  AppServicePlanPatchResource: AppServicePlanPatchContent
  AseRegion.properties.dedicatedHost: IsDedicatedHostEnabled
  AseRegion.properties.standard: IsStandard
  AseRegion.properties.zoneRedundant: IsZoneRedundantEnabled
  AseRegion: AppServiceAseRegion
  AseV3NetworkingConfiguration.properties.externalInboundIpAddresses: -|ip-address
  AseV3NetworkingConfiguration.properties.ftpEnabled: IsFtpEnabled
  AseV3NetworkingConfiguration.properties.internalInboundIpAddresses: -|ip-address
  AseV3NetworkingConfiguration.properties.linuxOutboundIpAddresses: -|ip-address
  AseV3NetworkingConfiguration.properties.remoteDebugEnabled: IsRemoteDebugEnabled
  AseV3NetworkingConfiguration.properties.windowsOutboundIpAddresses: -|ip-address
  AuthenticationType: FunctionAppStorageAccountAuthenticationType
  AuthPlatform.enabled: IsEnabled
  AuthType: SiteContainerAuthType
  AzureActiveDirectory.enabled: IsEnabled
  AzureActiveDirectory: AppServiceAadProvider
  AzureActiveDirectoryLogin.disableWWWAuthenticate: IsWwwAuthenticateDisabled
  AzureActiveDirectoryLogin: AppServiceAadLoginFlow
  AzureActiveDirectoryRegistration.clientSecretCertificateThumbprint: ClientSecretCertificateThumbprintString
  AzureActiveDirectoryRegistration: AppServiceAadRegistration
  AzureActiveDirectoryValidation: AppServiceAadValidation
  AzureBlobStorageApplicationLogsConfig: AppServiceBlobStorageApplicationLogsConfig
  AzureBlobStorageHttpLogsConfig.enabled: IsEnabled
  AzureBlobStorageHttpLogsConfig: AppServiceBlobStorageHttpLogsConfig
  AzureResourceErrorInfo: WorkflowExpressionResourceErrorInfo
  AzureResourceType: AppServiceResourceType
  AzureStaticWebApps.enabled: IsEnabled
  AzureStaticWebApps: AppServiceStaticWebAppsProvider
  AzureStaticWebAppsRegistration: AppServiceStaticWebAppsRegistration
  AzureStorageInfoValue: AppServiceStorageAccessInfo
  AzureStoragePropertyDictionaryResource: AzureStoragePropertyDictionary
  AzureStorageProtocol: AppServiceStorageProtocol
  AzureStorageState: AppServiceStorageAccountState
  AzureStorageType: AppServiceStorageType
  AzureTableStorageApplicationLogsConfig.sasUrl: SasUriString
  AzureTableStorageApplicationLogsConfig: AppServiceTableStorageApplicationLogsConfig
  BackupItem.properties.created: CreatedOn
  BackupItem.properties.finishedTimeStamp: FinishedOn
  BackupItem.properties.lastRestoreTimeStamp: LastRestoreOn
  BackupItem.properties.name: BackupName
  BackupItem.properties.scheduled: IsScheduled
  BackupItem: WebAppBackup
  BackupItemCollection: WebAppBackupItemListResult
  BackupItemStatus: WebAppBackupStatus
  BackupRequest.properties.enabled: IsEnabled
  BackupRequest: WebAppBackupInfo
  BackupSchedule.keepAtLeastOneBackup: ShouldKeepAtLeastOneBackup
  BackupSchedule.lastExecutionTime: LastExecutedOn
  BackupSchedule: WebAppBackupSchedule
  BasicAuthName: StaticSiteBasicAuthName
  BillingMeter.properties.billingLocation: -|azure-location
  BillingMeter.properties.meterId: -|uuid
  BillingMeterCollection: AppServiceBillingMeterListResult
  BuildStatus: StaticSiteBuildStatus
  Capability: AppServiceSkuCapability
  Certificate.properties.expirationDate: ExpireOn
  Certificate.properties.keyVaultId: -|arm-id
  Certificate.properties.thumbprint: ThumbprintString
  Certificate.properties.valid: IsValid
  Certificate: AppCertificate
  CertificateCollection: AppCertificateListResult
  CertificateDetails.thumbprint: ThumbprintString
  CertificatePatchResource: AppCertificatePatch
  CertificatePatchResource.properties.keyVaultId: -|arm-id
  CertificatePatchResource.properties.thumbprint: ThumbprintString
  CertificatePatchResource.properties.valid: IsValid
  Channels: RecommendationChannel
  CheckNameResourceTypes.Site: WebSite
  CloningInfo.overwrite: CanOverwrite
  CloningInfo.sourceWebAppLocation: -|azure-location
  Contact: RegistrationContactInfo
  ContainerThrottlingData: ContainerThrottlingInfo
  ContentHash: WebAppContentHash
  ContentLink: WebAppContentLink
  ContinuousWebJob.properties.using_sdk: IsUsingSdk
  ContinuousWebJobCollection: ContinuousWebJobListResult
  CookieExpiration: WebAppCookieExpiration
  CorsSettings.supportCredentials: IsCredentialsSupported
  CsmOperationCollection: CsmOperationListResult
  CsmPublishingProfileOptions.includeDisasterRecoveryEndpoints: IsIncludeDisasterRecoveryEndpoints
  CsmPublishingProfileOptions: CsmPublishingProfile
  CsmUsageQuotaCollection: CsmUsageQuotaListResult
  CustomOpenIdConnectProvider.enabled: IsEnabled
  Dapr.enabled: IsEnabled
  DaprConfig.enableApiLogging: IsApiLoggingEnabled
  DaprConfig.enabled: IsEnabled
  DaprConfig: AppDaprConfig
  DaprLogLevel: AppDaprLogLevel
  DatabaseConnection.properties.resourceId: -|arm-id
  DatabaseConnection: StaticSiteDatabaseConnection
  DatabaseConnectionOverview.resourceId: -|arm-id
  DatabaseConnectionOverview: StaticSiteDatabaseConnectionOverview
  DatabaseConnectionPatchRequest.properties.resourceId: -|arm-id
  DatabaseConnectionPatchRequest: StaticSiteDatabaseConnectionPatchContent
  DataSource: DetectorDataSource
  DayOfWeek: WebAppDayOfWeek
  DefaultAction: SiteDefaultAction
  DeletedAppRestoreRequest: DeletedAppRestoreContent
  DeletedWebAppCollection: DeletedWebAppListResult
  Deployment.properties.active: IsActive
  Deployment: WebAppDeployment
  DeploymentCollection: WebAppDeploymentListResult
  DetectorResponse: AppServiceDetector
  DetectorResponseCollection: AppServiceDetectorListResult
  DiagnosticAnalysisCollection: WebSiteAnalysisDefinitionListResult
  DiagnosticCategoryCollection: DiagnosticCategoryListResult
  DiagnosticData: DiagnosticDataset
  DiagnosticDetectorCollection: DiagnosticDetectorListResult
  Dimension.toBeExportedForShoebox: IsToBeExportedForShoebox
  Dimension: MetricDimension
  DnlResourceNameAvailability: DnlResourceNameAvailabilityResult
  Domain.properties.autoRenew: IsAutoRenew
  Domain.properties.expirationTime: ExpireOn
  Domain.properties.privacy: IsDomainPrivacyEnabled
  Domain.properties.readyForDnsRecordManagement: IsDnsRecordManagementReady
  Domain: AppServiceDomain
  DomainAvailabilityCheckResult.available: IsAvailable
  DomainCollection: AppServiceDomainListResult
  DomainControlCenterSsoRequest: DomainControlCenterSsoRequestInfo
  DomainOwnershipIdentifierCollection: DomainOwnershipIdentifierListResult
  DomainPatchResource.properties.autoRenew: IsAutoRenew
  DomainPatchResource.properties.privacy: IsDomainPrivacyEnabled
  DomainPatchResource.properties.readyForDnsRecordManagement: IsReadyForDnsRecordManagement
  EnabledConfig: WebAppEnabledConfig
  EndpointDetail.ipAddress: -|ip-address
  EnvironmentVariable: WebAppEnvironmentVariable
  ErrorInfo: WebAppErrorInfo
  ErrorProperties: WebAppErrorProperties
  ErrorResponse.error: ErrorInfo
  ErrorResponse: WebAppErrorResponse
  Experiments: RoutingRuleExperiments
  Expression: WorkflowExpression
  ExpressionRoot: WorkflowExpressionRoot
  Facebook.enabled: IsEnabled
  Facebook: AppServiceFacebookProvider
  FileSystemHttpLogsConfig.enabled: IsEnabled
  FrequencyUnit: BackupFrequencyUnit
  FunctionAppRuntimeSettings.remoteDebuggingSupported: IsRemoteDebuggingSupported
  FunctionAppStackCollection: FunctionAppStackListResult
  FunctionEnvelopeCollection: FunctionEnvelopeListResult
  FunctionsAlwaysReadyConfig.instanceCount: AlwaysReadyInstanceCount
  FunctionsAlwaysReadyConfig: FunctionAppAlwaysReadyConfig
  FunctionsDeploymentStorage: FunctionAppStorage
  FunctionsDeploymentStorageAuthentication: FunctionAppStorageAuthentication
  FunctionsRuntime: FunctionAppRuntime
  FunctionsScaleAndConcurrency.instanceMemoryMB: FunctionAppInstanceMemoryMB
  FunctionsScaleAndConcurrency.maximumInstanceCount: FunctionAppMaximumInstanceCount
  FunctionsScaleAndConcurrency: FunctionAppScaleAndConcurrency
  FunctionsScaleAndConcurrencyTriggersHttp.perInstanceConcurrency: ConcurrentHttpPerInstanceConcurrency
  FunctionStorageType: FunctionAppStorageType
  GeoRegionCollection: AppServiceGeoRegionListResult
  GitHub.enabled: IsEnabled
  GitHub: AppServiceGitHubProvider
  GlobalCsmSkuDescription.locations: -|azure-location
  GlobalValidation.requireAuthentication: IsAuthenticationRequired
  Google.enabled: IsEnabled
  Google: AppServiceGoogleProvider
  HandlerMapping: HttpRequestHandlerMapping
  HostKeys: FunctionAppHostKeys
  HostNameBinding.properties.thumbprint: ThumbprintString
  HostNameBindingCollection: HostNameBindingListResult
  HostNameSslState.thumbprint: ThumbprintString
  HttpSettings.requireHttps: IsHttpsRequired
  HybridConnection.properties.relayArmUri: relayArmId|arm-id
  HybridConnectionCollection: HybridConnectionListResult
  IdentifierCollection: AppServiceIdentifierListResult
  InAvailabilityReasonType: AppServiceNameUnavailableReason
  InboundEnvironmentEndpointCollection: InboundEnvironmentEndpointListResult
  InsightStatus: DetectorInsightStatus
  IpAddress: WebAppIPAddress
  IpAddressRange: WebAppIPAddressRange
  IpSecurityRestriction.ipAddress: IPAddressOrCidr
  IpSecurityRestriction.vnetSubnetResourceId: -|arm-id
  IssueType: DetectorIssueType
  JsonSchema: WebAppJsonSchema
  KeyInfo: WebAppKeyInfo
  KeyInfoProperties: WebAppKeyInfoProperties
  KeyType: WebAppKeyType
  KeyValuePairStringObject: DataProviderKeyValuePair
  KubeEnvironment.properties.aksResourceID: -|arm-id
  KubeEnvironment.properties.internalLoadBalancerEnabled: IsInternalLoadBalancerEnabled
  KubeEnvironmentCollection: KubeEnvironmentListResult
  KubeEnvironmentPatchResource.properties.aksResourceID: -|arm-id
  KubeEnvironmentPatchResource.properties.internalLoadBalancerEnabled: IsInternalLoadBalancerEnabled
  LegacyMicrosoftAccount.enabled: IsEnabled
  Login: WebAppLoginInfo
  LogLevel: WebAppLogLevel
  MetricSpecification.enableRegionalMdmAccount: IsRegionalMdmAccountEnabled
  MetricSpecification.supportsInstanceLevelAggregation: IsInstanceLevelAggregationSupported
  MigrateMySqlStatus.properties.localMySqlEnabled: IsLocalMySqlEnabled
  MSDeploy.properties.appOffline: IsAppOffline
  MSDeploy: WebAppMSDeploy
  MSDeployLog: WebAppMSDeployLog
  MSDeployLogEntry: WebAppMSDeployLogEntry
  MSDeployLogEntryType: WebAppMSDeployLogEntryType
  MSDeployStatus.properties.complete: IsComplete
  NameIdentifier: AppServiceDomainNameIdentifier
  NameIdentifierCollection: AppServiceDomainNameIdentifierListResult
  NetworkTrace: WebAppNetworkTrace
  Nonce: LoginFlowNonceSettings
  OpenAuthenticationAccessPolicies.policies: OpenAuthenticationPolicyList
  OutboundEnvironmentEndpointCollection: OutboundEnvironmentEndpointListResult
  OutboundVnetRouting.allTraffic: IsAllTrafficEnabled
  OutboundVnetRouting.applicationTraffic: IsApplicationTrafficEnabled
  OutboundVnetRouting.contentShareTraffic: IsContentShareTrafficEnabled
  OutboundVnetRouting.imagePullTraffic: IsImagePullTrafficEnabled
  OutboundVnetRouting.backupRestoreTraffic: IsBackupRestoreTrafficEnabled
  ParameterType: WebAppParameterType
  PerfMonCounterCollection: PerfMonCounterListResult
  PerfMonResponse: PerfMonResponseInfo
  PremierAddOnOffer.properties.promoCodeRequired: IsPromoCodeRequired
  PremierAddOnOfferCollection: PremierAddOnOfferListResult
  PrivateAccess.properties.enabled: IsEnabled
  PrivateAccessVirtualNetwork.resourceId: -|arm-id
  PrivateEndpointConnectionCollection: RemotePrivateEndpointConnectionListResult
  PrivateLinkConnectionApprovalRequestResource: PrivateLinkConnectionApprovalRequestInfo
  PrivateLinkResource: AppServicePrivateLinkResourceData
  PrivateLinkResourceProperties: AppServicePrivateLinkResourceProperties
  ProcessInfo.properties.threads: ProcessThreads
  ProcessInfoCollection: ProcessInfoListResult
  ProcessModuleInfoCollection: ProcessModuleInfoListResult
  ProcessThreadInfo: WebAppProcessThreadInfo
  ProcessThreadInfoCollection: WebAppProcessThreadInfoListResult
  ProcessThreadProperties.href: -|uri
  ProcessThreadProperties: WebAppProcessThreadProperties
  PublicCertificate.properties.thumbprint: ThumbprintString
  PublicCertificateCollection: PublicCertificateListResult
  PublishingCredentialsPoliciesCollection: PublishingCredentialsPoliciesListResult
  PushSettings: WebAppPushSettings
  Recommendation: AppServiceRecommendation
  RecommendationCollection: AppServiceRecommendationListResult
  RecurrenceFrequency: WorkflowRecurrenceFrequency
  RecurrenceSchedule: WorkflowRecurrenceSchedule
  RegenerateActionParameter: WorkflowRegenerateActionContent
  RemotePrivateEndpointConnection.properties.ipAddresses: -|ip-address
  RemotePrivateEndpointConnectionARMResource.properties.ipAddresses: -|ip-address
  Rendering: DiagnosticDataRendering
  RenderingType: DiagnosticDataRenderingType
  RepetitionIndex: WorkflowRunActionRepetitionIndex
  Request: WebAppRequest
  RequestHistory: WebAppRequestHistory
  RequestHistoryProperties: WebAppRequestHistoryProperties
  Resource: AppServiceResource
  ResourceCollection: AppServicePlanResourceListResult
  ResourceConfig: FunctionAppResourceConfig
  ResourceHealthMetadata.properties.signalAvailability: IsSignalAvailable
  ResourceHealthMetadataCollection: ResourceHealthMetadataListResult
  ResourceMetricDefinitionCollection: ResourceMetricDefinitionListResult
  ResourceNameAvailability: AppServiceNameAvailabilityResult
  ResourceNameAvailability.nameAvailable: IsNameAvailable
  ResourceNameAvailabilityRequest: AppServiceNameAvailabilityRequest
  ResourceReference.id: -|arm-id
  ResourceReference.type: -|resource-type
  ResourceReference: WorkflowResourceReference
  Response: WebAppResponse
  ResponseMetaData: DetectorMetadata
  RestoreRequest.properties.overwrite: CanOverwrite
  RestoreRequest: RestoreRequestInfo
  RetryHistory: WebAppRetryHistory
  RouteType: AppServiceVirtualNetworkRouteType
  RunActionCorrelation: WebAppRunActionCorrelation
  RunCorrelation: WebAppRunCorrelation
  RuntimeName: FunctionAppRuntimeName
  Scale: ContainerAppScale
  ScaleRule: ContainerAppScaleRule
  ScaleRuleAuth: ContainerAppScaleRuleAuth
  Site.properties.clientAffinityEnabled: IsClientAffinityEnabled
  Site.properties.clientAffinityPartitioningEnabled: IsClientAffinityPartitioningEnabled
  Site.properties.clientAffinityProxyEnabled: IsClientAffinityProxyEnabled
  Site.properties.clientCertEnabled: IsClientCertEnabled
  Site.properties.enabled: IsEnabled
  Site.properties.endToEndEncryptionEnabled: IsEndToEndEncryptionEnabled
  Site.properties.hostNamesDisabled: IsHostNameDisabled
  Site.properties.httpsOnly: IsHttpsOnly
  Site.properties.hyperV: IsHyperV
  Site.properties.reserved: IsReserved
  Site.properties.scmSiteAlsoStopped: IsScmSiteAlsoStopped
  Site.properties.serverFarmId: AppServicePlanId|arm-id
  Site.properties.sshEnabled: IsSshEnabled
  Site.properties.storageAccountRequired: IsStorageAccountRequired
  Site.properties.suspendedTill: SuspendOn
  Site.properties.virtualNetworkSubnetId: -|arm-id
  Site: WebSite
  SiteAuthSettings.properties.clientSecretCertificateThumbprint: ClientSecretCertificateThumbprintString
  SiteAuthSettings.properties.enabled: IsEnabled
  SiteAuthSettings.properties.tokenStoreEnabled: IsTokenStoreEnabled
  SiteAvailabilityState: WebSiteAvailabilityState
  SiteConfig.properties.acrUseManagedIdentityCreds: UseManagedIdentityCreds
  SiteConfig.properties.alwaysOn: IsAlwaysOn
  SiteConfig.properties.autoHealEnabled: IsAutoHealEnabled
  SiteConfig.properties.detailedErrorLoggingEnabled: IsDetailedErrorLoggingEnabled
  SiteConfig.properties.functionsRuntimeScaleMonitoringEnabled: IsFunctionsRuntimeScaleMonitoringEnabled
  SiteConfig.properties.http20Enabled: IsHttp20Enabled
  SiteConfig.properties.httpLoggingEnabled: IsHttpLoggingEnabled
  SiteConfig.properties.localMySqlEnabled: IsLocalMySqlEnabled
  SiteConfig.properties.remoteDebuggingEnabled: IsRemoteDebuggingEnabled
  SiteConfig.properties.requestTracingEnabled: IsRequestTracingEnabled
  SiteConfig.properties.scmIpSecurityRestrictionsUseMain: AllowIPSecurityRestrictionsForScmToUseMain
  SiteConfig.properties.vnetRouteAllEnabled: IsVnetRouteAllEnabled
  SiteConfig.properties.webSocketsEnabled: IsWebSocketsEnabled
  SiteConfigProperties.acrUseManagedIdentityCreds: UseManagedIdentityCreds
  SiteConfigProperties.alwaysOn: IsAlwaysOn
  SiteConfigProperties.autoHealEnabled: IsAutoHealEnabled
  SiteConfigProperties.detailedErrorLoggingEnabled: IsDetailedErrorLoggingEnabled
  SiteConfigProperties.functionsRuntimeScaleMonitoringEnabled: IsFunctionsRuntimeScaleMonitoringEnabled
  SiteConfigProperties.http20Enabled: IsHttp20Enabled
  SiteConfigProperties.httpLoggingEnabled: IsHttpLoggingEnabled
  SiteConfigProperties.localMySqlEnabled: IsLocalMySqlEnabled
  SiteConfigProperties.remoteDebuggingEnabled: IsRemoteDebuggingEnabled
  SiteConfigProperties.requestTracingEnabled: IsRequestTracingEnabled
  SiteConfigProperties.scmIpSecurityRestrictionsUseMain: AllowIPSecurityRestrictionsForScmToUseMain
  SiteConfigProperties.vnetRouteAllEnabled: IsVnetRouteAllEnabled
  SiteConfigProperties.webSocketsEnabled: IsWebSocketsEnabled
  SiteConfigResourceCollection: SiteConfigListResult
  SiteConfigurationSnapshotInfo.properties.time: SnapshotTakenTime
  SiteConfigurationSnapshotInfoCollection: SiteConfigurationSnapshotInfoListResult
  SiteExtensionInfoCollection: SiteExtensionInfoListResult
  SiteLogsConfig.properties.detailedErrorMessages: IsDetailedErrorMessages  # The autogened name by safe flatten which can't be renamed by other configs
  SiteLogsConfig.properties.failedRequestsTracing: IsFailedRequestsTracing  # The autogened name by safe flatten which can't be renamed by other configs
  SitePatchResource.properties.clientAffinityEnabled: IsClientAffinityEnabled
  SitePatchResource.properties.clientAffinityProxyEnabled: IsClientAffinityProxyEnabled
  SitePatchResource.properties.clientCertEnabled: IsClientCertEnabled
  SitePatchResource.properties.enabled: IsEnabled
  SitePatchResource.properties.hostNamesDisabled: IsHostNameDisabled
  SitePatchResource.properties.httpsOnly: IsHttpsOnly
  SitePatchResource.properties.hyperV: IsHyperV
  SitePatchResource.properties.lastModifiedTimeUtc: LastModifiedOn
  SitePatchResource.properties.reserved: IsReserved
  SitePatchResource.properties.scmSiteAlsoStopped: IsScmSiteAlsoStopped
  SitePatchResource.properties.storageAccountRequired: IsStorageAccountRequired
  SitePatchResource.properties.suspendedTill: SuspendOn
  SitePatchResource.properties.virtualNetworkSubnetId: -|arm-id
  SitePatchResource: SitePatchInfo
  SiteSealRequest.lightTheme: IsLightTheme
  SiteSourceControl.properties.deploymentRollbackEnabled: IsDeploymentRollbackEnabled
  SkuCapacity: AppServiceSkuCapacity
  SkuDescription.locations: -|azure-location
  SkuDescription: AppServiceSkuDescription
  SkuInfo: AppServicePoolSkuInfo
  SkuInfoCollection: AppServicePoolSkuInfoListResult
  SkuInfos: AppServiceSkuResult
  SlotDifferenceCollection: SlotDifferenceListResult
  Snapshot: AppSnapshot
  SnapshotCollection: AppSnapshotListResult
  SnapshotRestoreRequest.properties.overwrite: CanOverwrite
  Solution: DiagnosticSolution
  SolutionType: DiagnosticSolutionType
  SourceControlCollection: AppServiceSourceControlListResult
  SslState: HostNameBindingSslState
  StackMajorVersion.applicationInsights: IsApplicationInsights
  StampCapacityCollection: StampCapacityListResult
  StaticSiteARMResource: StaticSite
  StaticSiteBasicAuthPropertiesARMResource: StaticSiteBasicAuthProperties
  StaticSiteBuildARMResource.properties.createdTimeUtc: CreatedOn
  StaticSiteBuildARMResource: StaticSiteBuild
  StaticSiteBuildCollection: StaticSiteBuildListResult
  StaticSiteCollection: StaticSiteListResult
  StaticSiteCustomDomainOverviewARMResource: StaticSiteCustomDomainOverview
  StaticSiteCustomDomainOverviewCollection: StaticSiteCustomDomainOverviewListResult
  StaticSiteCustomDomainRequestPropertiesARMResource: StaticSiteCustomDomainContent
  StaticSiteFunctionOverviewARMResource: StaticSiteFunctionOverview
  StaticSiteFunctionOverviewCollection: StaticSiteFunctionOverviewListResult
  StaticSiteLinkedBackend: StaticSiteLinkedBackendInfo
  StaticSiteLinkedBackendARMResource.properties.backendResourceId: -|arm-id
  StaticSiteLinkedBackendARMResource: StaticSiteLinkedBackend
  StaticSiteResetPropertiesARMResource: StaticSiteResetContent
  StaticSiteTemplateOptions: StaticSiteTemplate
  StaticSiteUserARMResource: StaticSiteUser
  StaticSiteUserCollection: StaticSiteUserListResult
  StaticSiteUserInvitationRequestResource: StaticSiteUserInvitationContent
  StaticSiteUserInvitationResponseResource: StaticSiteUserInvitationResult
  StaticSiteUserProvidedFunctionApp: StaticSiteUserProvidedFunctionAppProperties  # just rename this to avoid collision, this class will be automatically removed
  StaticSiteUserProvidedFunctionAppARMResource: StaticSiteUserProvidedFunctionApp
  StaticSiteUserProvidedFunctionAppsCollection: StaticSiteUserProvidedFunctionAppsListResult
  StaticSiteZipDeploymentARMResource: StaticSiteZipDeployment
  Status: AppServiceStatusInfo
  StatusOptions: AppServicePlanStatus
  StorageMigrationResponse: StorageMigrationResult
  StorageType: ArtifactStorageType
  StringDictionary: AppServiceConfigurationDictionary
  StringList: StaticSiteStringList
  SupportedTlsVersions: AppServiceSupportedTlsVersion
  SupportTopic: DetectorSupportTopic
  SwiftVirtualNetwork.properties.subnetResourceId: -|arm-id
  SwiftVirtualNetwork.properties.swiftSupported: IsSwiftSupported
  Template: ContainerAppTemplate
  TldLegalAgreementCollection: TldLegalAgreementListResult
  TlsCipherSuites.TLS_AES_128_GCM_SHA256: TlsAes128GcmSha256
  TlsCipherSuites.TLS_AES_256_GCM_SHA384: TlsAes256GcmSha384
  TlsCipherSuites.TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256: TlsECDiffieHellmanECDsaWithAes128CbcSha256
  TlsCipherSuites.TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256: TlsECDiffieHellmanECDsaWithAes128GcmSha256
  TlsCipherSuites.TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384: TlsECDiffieHellmanECDsaWithAes256GcmSha384
  TlsCipherSuites.TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA: TlsECDiffieHellmanRsaWithAes128CbcSha
  TlsCipherSuites.TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256: TlsECDiffieHellmanRsaWithAes128CbcSha256
  TlsCipherSuites.TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256: TlsECDiffieHellmanRsaWithAes128GcmSha256
  TlsCipherSuites.TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA: TlsECDiffieHellmanRsaWithAes256CbcSha
  TlsCipherSuites.TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384: TlsECDiffieHellmanRsaWithAes256CbcSha384
  TlsCipherSuites.TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384: TlsECDiffieHellmanRsaWithAes256GcmSha384
  TlsCipherSuites.TLS_RSA_WITH_AES_128_CBC_SHA: TlsRsaWithAes128CbcSha
  TlsCipherSuites.TLS_RSA_WITH_AES_128_CBC_SHA256: TlsRsaWithAes128CbcSha256
  TlsCipherSuites.TLS_RSA_WITH_AES_128_GCM_SHA256: TlsRsaWithAes128GcmSha256
  TlsCipherSuites.TLS_RSA_WITH_AES_256_CBC_SHA: TlsRsaWithAes256CbcSha
  TlsCipherSuites.TLS_RSA_WITH_AES_256_CBC_SHA256: TlsRsaWithAes256CbcSha256
  TlsCipherSuites.TLS_RSA_WITH_AES_256_GCM_SHA384: TlsRsaWithAes256GcmSha384
  TlsCipherSuites: AppServiceTlsCipherSuite
  TokenStore.enabled: IsEnabled
  TopLevelDomain.properties.privacy: IsDomainPrivacySupported
  TopLevelDomainAgreementOption.forTransfer: IsForTransfer
  TopLevelDomainCollection: TopLevelDomainListResult
  TriggeredJobHistoryCollection: TriggeredJobHistoryListResult
  TriggeredWebJob.properties.storageAccountRequired: IsStorageAccountRequired
  TriggeredWebJob.properties.using_sdk: IsUsingSdk
  TriggeredWebJobCollection: TriggeredWebJobListResult
  TriggerTypes: FunctionTriggerType
  Twitter.enabled: IsEnabled
  Twitter: AppServiceTwitterProvider
  UpgradeAvailability: AppServiceEnvironmentUpgradeAvailability
  UpgradePreference: AppServiceEnvironmentUpgradePreference
  UsageCollection: AppServiceUsageListResult
  User: PublishingUser
  ValidateRequest: AppServiceValidateContent
  ValidateResourceTypes.Site: WebSite
  ValidateResponse: AppServiceValidateResult
  VirtualApplication.preloadEnabled: IsPreloadEnabled
  VirtualIPMapping.inUse: IsInUse
  VnetGateway: AppServiceVirtualNetworkGateway
  VnetInfo.certThumbprint: CertThumbprintString
  VnetInfo.resyncRequired: IsResyncRequired
  VnetInfo: AppServiceVirtualNetworkProperties
  VnetInfoResource.properties.certThumbprint: CertThumbprintString
  VnetInfoResource.properties.resyncRequired: IsResyncRequired
  VnetInfoResource: AppServiceVirtualNetwork
  VnetParameters.properties.subnetResourceId: -|arm-id
  VnetParameters: AppServiceVirtualNetworkValidationContent
  VnetRoute: AppServiceVirtualNetworkRoute
  VnetValidationFailureDetails.properties.failed: IsFailed
  VnetValidationFailureDetails: VirtualNetworkValidationFailureDetails
  VnetValidationTestFailure: VirtualNetworkValidationTestFailure
  VolumeMount.readOnly: IsReadOnly
  VolumeMount: SiteContainerVolumeMount
  WebAppCollection: WebAppListResult
  WebAppInstanceStatusCollection: WebAppInstanceStatusListResult
  WebAppRuntimeSettings.remoteDebuggingSupported: IsRemoteDebuggingSupported
  WebAppStackCollection: WebAppStackListResult
  WebJob.properties.using_sdk: IsUsingSdk
  WebJobCollection: WebJobCListResult
  WebSiteInstanceStatus.properties.healthCheckUrl: healthCheckUrlString
  WorkerPoolCollection: AppServiceWorkerPoolListResult
  WorkerPoolResource: AppServiceWorkerPool
  Workflow: WorkflowData
  WorkflowOutputParameter: WorkflowOutputContent
  WorkflowParameter: WorkflowContent
  WorkflowTriggerHistory.properties.fired: IsFired
  WorkflowTriggerListCallbackUrlQueries.se: SasTimestamp
  WorkflowTriggerListCallbackUrlQueries.sig: SasSignature
  WorkflowTriggerListCallbackUrlQueries.sp: SasPermission
  WorkflowTriggerListCallbackUrlQueries.sv: SasVersion
  WorkflowTriggerListCallbackUrlQueries: WorkflowTriggerListCallbackUriQueries

prepend-rp-prefix:
  - ApiDefinitionInfo
  - ArmPlan
  - BillingMeter
  - BlobStorageTokenStore
  - CertificateDetails
  - CertificateEmail
  - CorsSettings
  - DatabaseBackupSetting
  - DatabaseType
  - DeploymentLocations
  - DnsType
  - DomainStatus
  - DomainType
  - EndpointDependency
  - EndpointDetail
  - ForwardProxy
  - FtpsState
  - GeoRegion
  - HostName
  - HostNameType
  - HostType
  - HttpLogsConfig
  - HttpSettings
  - HttpSettingsRoutes
  - Identifier
  - IdentityProviders
  - IpFilterTag
  - IPMode
  - IpSecurityRestriction
  - NameValuePair
  - Operation
  - OperationStatus
  - SourceControl
  - TokenStore
  - UsageState
  - VirtualNetworkProfile

models-to-treat-empty-string-as-null:
  - WebAppBackupData
  - WebSiteInstanceStatusData
  - AppServiceApiDefinitionInfo

directive:
# operation removal - should be temporary
# pageable lro
  - remove-operation: AppServiceEnvironments_ChangeVnet
  - remove-operation: AppServiceEnvironments_Resume
  - remove-operation: AppServiceEnvironments_Suspend
  # - remove-operation: WebApps_GetAuthSettingsV2WithoutSecrets
  # - remove-operation: WebApps_GetAuthSettingsV2WithoutSecretsSlot
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
  # Fix for issue https://github.com/Azure/azure-sdk-for-net/issues/43295
  - from: WebApps.json
    where: $.definitions.TriggeredJobRun.properties.status
    transform: >
        $["enum"] = [
            "Success",
            "Failed",
            "Error",
            "Aborted",
            "Running"
        ]
  - from: WebApps.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridConnectionRelays'].get
    transform: >
        $['responses']['200']['schema']['$ref'] = "./AppServicePlans.json#/definitions/HybridConnectionCollection";
  - from: WebApps.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridConnectionRelays'].get
    transform: >
        $['responses']['200']['schema']['$ref'] = "./AppServicePlans.json#/definitions/HybridConnectionCollection";
  # Fix https://github.com/Azure/azure-sdk-for-net/issues/47267, fix the issue of data type mismatch in the AsyncPageable return values.
  - from: AppServicePlans.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}/sites'].get
    transform: >
        $['responses']['200']['schema']['$ref'] = "./CommonDefinitions.json#/definitions/WebAppCollection";
  # The Enum name "StorageType" is shared by artifactsStorageType, cause the apicompat error
  - from: CommonDefinitions.json
    where: $.definitions.FunctionsDeployment.properties.storage.properties.type
    transform: >
        $["x-ms-enum"] = {
                "name": "functionStorageType",
                "modelAsString": true
              };
  # Remove ContainerApps.json, ContainerAppsRevisions.json since Container Apps has been separated into another SDK
  - from: ContainerApps.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  - from: ContainerAppsRevisions.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  # Reuse defined DayOfWeek
  - from: WebApps.json
    where: $.definitions.RecurrenceSchedule.properties.weekDays
    transform: >
        $.items = {
            "$ref": "#/definitions/DayOfWeek",
            "description": "The days of the week."
          };
  # Fix https://github.com/Azure/azure-sdk-for-net/issues/39126, fix the `ProcessThreadInfo` definition based on the return result
  - from: WebApps.json
    where: $.definitions
    transform: >
        $.ProcessThreadProperties = {
            "description": "Process Thread properties.",
            "type": "object",
            "properties": {
              "id": {
                "format": "int32",
                "description": "Thread ID.",
                "type": "integer",
                "readOnly": true
              },
              "href": {
                "description": "HRef URI.",
                "type": "string"
              },
              "state": {
                "description": "Thread state.",
                "type": "string"
              }
            }
          };
  - from: WebApps.json
    where: $.definitions.ProcessThreadInfo
    transform: >
        $.properties = {
            "properties": {
              "$ref": "#/definitions/ProcessThreadProperties",
              "description": "ProcessThreadInfo resource specific properties",
              "type": "object"
            }
          };
  - from: WebApps.json
    where: $.definitions.ProcessInfo
    transform: >
        $.properties.properties.properties.threads.items = {
            "$ref": "#/definitions/ProcessThreadProperties"
          };
  # Fix for issue: https://github.com/Azure/azure-sdk-for-net/issues/46854
  # TODO: Remove this workaround after the issue is resolved. Issue link: https://github.com/Azure/azure-rest-api-specs/issues/19022
  - from: Certificates.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/certificates/{name}'].put
    transform: >
        $["x-ms-long-running-operation"] = true;
        $['responses'] = {
            "200": {
                "description": "OK.",
                "schema": {
                    "$ref": "./CommonDefinitions.json#/definitions/Certificate"
                }
            },
            "202": {
                "description": "OK.",
            },
            "default": {
                "description": "App Service error response.",
                "schema": {
                    "$ref": "./CommonDefinitions.json#/definitions/DefaultErrorResponse"
                }
            }
        };
```
