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
mgmt-debug:
  show-serialized-names: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
  naming:
    override:
      Status: OperationStatus
      DetectorDefinitionResource: DetectorDefinition

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
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/ftp: BasicPublishingCredentialsPolicyFtp
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/configreferences/connectionstrings/{connectionStringKey}: SiteConfigConnectionString
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{webJobName}: SiteContinuousWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}: SiteHybridConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/premieraddons/{premierAddOnName}: SitePremierAddon
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateAccess/virtualNetworks: SitePrivateAccess
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/resourceHealthMetadata/default: SiteResourceHealthMetadata
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}: SiteSlotConfigAppSetting
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/connectionstrings/{connectionStringKey}: SiteSlotConfigConnectionString
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}: SiteSlotContinuousWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}: SiteSlotPremierAddOn
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks: SiteSlotPrivateAccess
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/resourceHealthMetadata/default: SiteSlotResourceHealthMetadata
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}: SiteSlotTriggeredWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/history/{id}: SiteSlotTriggeredWebJobHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/webjobs/{webJobName}: SiteSlotWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web: SiteSourceControl
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}: SiteTriggeredwebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/history/{id}: SiteTriggeredWebJobHistory
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/webjobs/{webJobName}: SiteWebJob
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}: WebSite
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web: SiteSlotSourceControl
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/hybridconnection/{entityName}: SiteSlotHybridConnectionCollection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/siteextensions/{siteExtensionId}: SiteExtension
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

no-property-type-replacement:
- ApiManagementConfig

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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
#   Serverfarm: AppServicePlan
#   serverFarm: AppServicePlan
#   ServerFarm: AppServicePlan
  Etag: ETag|etag

rename-mapping:
  Site: WebSite
  AppServiceCertificateOrderPatchResource: AppServiceCertificateOrderPatch
  AppServiceCertificatePatchResource: AppServiceCertificatePatch
  AppServiceEnvironmentPatchResource: AppServiceEnvironmentPatchOptions
  AppserviceGithubToken: AppServiceGithubToken
  AppServicePlanPatchResource: AppServicePlanPatchOptions
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
  Domain.properties.privacy: HasPrivacy
  Domain.properties.expirationTime: ExpireOn
  Domain.properties.autoRenew: IsAutoRenew
  AppServiceEnvironment.properties.ipsslAddressCount: IPSslAddressCount
  AppServiceEnvironment.properties.suspended: IsSuspended
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
  ContinuousWebJob.properties.using_sdk: IsUseingSdk
  Deployment.properties.active: IsActive
  KubeEnvironment.properties.internalLoadBalancerEnabled: IsInternalLoadBalancerEnabled
  MigrateMySqlStatus.properties.localMySqlEnabled: IsLocalMySqlEnabled
  MSDeployStatus.properties.complete: IsComplete
  PrivateAccess.properties.enabled: IsEnabled
  ResourceHealthMetadata.properties.signalAvailability: HasSignalAvailability
  SiteConfig.properties.acrUseManagedIdentityCreds: HasAcrUseManagedIdentityCreds
  SiteConfig.properties.alwaysOn: IsAlwaysOn
  SiteConfig.properties.autoHealEnabled: IsAutoHealEnabled
  SiteConfig.properties.detailedErrorLoggingEnabled: IsDetailedErrorLogginEnabled
  SiteConfig.properties.functionsRuntimeScaleMonitoringEnabled: IsFunctionsRuntimeScaleMonitorEnabled
  SiteConfig.properties.http20Enabled: IsHttpLoggingEnabled
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
  Site.properties.clientAffinityEnabled: IsClientAffinityEnabled
  Site.properties.clientCertEnabled: IsClientCertEnabled
  Site.properties.enabled: IsEnabled
  Site.properties.hostNamesDisabled: IsHostNamesDisabled
  Site.properties.httpsOnly: IsHttpsOnly
  Site.properties.hyperV: IsHyperV
  Site.properties.storageAccountRequired: IsStorageAccountRequired
  CsmPublishingProfileOptions.includeDisasterRecoveryEndpoints: IsIncludeDisasterRecoveryEndpoints
  AppServiceCertificateOrderPatchResource.properties.autoRenew: IsAutoRenew
  AppServiceCertificateOrderPatchResource.properties.nextAutoRenewalTimeStamp: NextAutoRenewalTimeStampOn
  DomainPatchResource.properties.autoRenew: IsAutoRenew
  DomainPatchResource.properties.privacy: HasPrivacy
  DomainPatchResource.properties.readyForDnsRecordManagement: IsReadyForDnsRecordManagement
  AppServiceEnvironmentAutoGenerated.hasLinuxWorkers: IsHasLinuxWorkers
  AppServiceEnvironmentAutoGenerated.ipsslAddressCount: IPSslAddressCount
  AppServiceEnvironmentAutoGenerated.suspended: IsSuspended
  AppServiceEnvironmentAutoGenerated.zoneRedundant: IsZoneRedundant
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
  BackupSchedule.keepAtLeastOneBackup: IsKeepAtLeastOneBackup
  CertificateDetails.notAfter: NoAfterOn
  CertificateDetails.notBefore: NoBeforeOn
  CertificateEmail.properties.timeStamp: TimeStampOn
  CertificatePatchResource.properties.valid: IsValid
  CloningInfo.cloneCustomHostNames: IsCloneCustomHostNames
  CloningInfo.cloneSourceControl: IsCloneSourceControl
  CloningInfo.configureLoadBalancing: IsConfigureLoadBalancing
  CloningInfo.overwrite: IsOverwrite
  ContainerInfo.currentTimeStamp: CurrentTimeStampOn
  ContainerInfo.previousTimeStamp: PreviousTimeStampOn
  CorsSettings.supportCredentials: IsSupportCredentials
  CsmSlotEntity.preserveVnet: IsPreserveVnet
  CustomOpenIdConnectProvider.enabled: IsEnabled
  DeletedAppRestoreRequest.properties.recoverConfiguration: IsRecoverConfiguration
  DeletedAppRestoreRequest.properties.useDRSecondary: IsUseDRSecondary
  DiagnosticDetectorResponse.properties.issueDetected: IsIssueDetected
  DiagnosticMetricSample.timestamp: TimestampOn
  Dimension.toBeExportedForShoebox: IsToBeExportedForShoebox
  DomainAvailabilityCheckResult.available: IsAvailable
  Facebook.enabled: IsEnabled
  FileSystemHttpLogsConfig.enabled: IsEnabled
  FunctionAppRuntimeSettings.remoteDebuggingSupported: IsRemoteDebuggingSupported
  GitHub.enabled: IsEnabled
  GitHubActionConfiguration.generateWorkflowFile: IsGenerateWorkflowFile
  GlobalValidation.requireAuthentication: IsGlobalValidation
  Google.enabled: IsEnabled
  HostNameSslState.toUpdate: IsToUpdate
  HttpSettings.requireHttps: IsRequireHttps
  KubeEnvironmentPatchResource.properties.internalLoadBalancerEnabled: IsInternalLoadBalancerEnabled
  LegacyMicrosoftAccount.enabled: IsEnabled
  Login.preserveUrlFragmentsForLogins: IsPreserveUrlFragmentsForLogins
  MetricSpecification.enableRegionalMdmAccount: IsEnableRegionalMdmAccount
  MetricSpecification.fillGapWithZero: IsFillGapWithZero
  MetricSpecification.supportsInstanceLevelAggregation: IsSupportsInstanceLevelAggregation
  MSDeploy.properties.appOffline: IsAppOffline
  MSDeploy.properties.skipAppData: IsSkipAppData
  Nonce.validateNonce: IsValiddateNonce
  PerfMonSample.time: MeasuredCounterTime
  PremierAddOnOffer.properties.promoCodeRequired: IsPromoCodeRequired
  ResourceNameAvailability.nameAvailable: IsNameAvailable
  RestoreRequest.properties.adjustConnectionStrings: IsAdjustConnectionStrings
  RestoreRequest.properties.ignoreConflictingHostNames: IsIgnoreConflictingHostNames
  RestoreRequest.properties.ignoreDatabases: IsIgnoreDatabases
  RestoreRequest.properties.overwrite: IsOverwrite
  SiteAuthSettings.properties.enabled: IsEnabled
  SiteAuthSettings.properties.tokenStoreEnabled: IsTokenStoreEnabled
  SiteConfigProperties.acrUseManagedIdentityCreds: IsAcrUseManagedIdentityCreds
  SiteConfigProperties.alwaysOn: IsAlwaysOn
  SiteConfigProperties.autoHealEnabled: AutoHealEnabled
  SiteConfigProperties.functionsRuntimeScaleMonitoringEnabled: IsFunctionsRuntimeScaleMonitoringEnabled
  SiteConfigProperties.detailedErrorLoggingEnabled: IsDetailedErrorLoggingEnabled
  SiteConfigProperties.httpLoggingEnabled: IsHttpLoggingEnabled
  SiteConfigProperties.http20Enabled: IsHttp20Enabled
  SiteConfigProperties.localMySqlEnabled: IsLocalMySqlEnabled
  SiteConfigProperties.remoteDebuggingEnabled: IsRemoteDebuggingEnabled
  SiteConfigProperties.requestTracingEnabled: IsRequestTracingEnabled
  SiteConfigProperties.scmIpSecurityRestrictionsUseMain: IsScmIPSecurityRestrictionsUseMain
  SiteConfigProperties.use32BitWorkerProcess: IsUse32BitWorkerProcess
  SiteConfigProperties.vnetRouteAllEnabled: IsVnetRouteAllEnabled
  SiteConfigProperties.webSocketsEnabled: IsWebSocketsEnabled
  SiteConfigPropertiesDictionary.use32BitWorkerProcess: IsUse32BitWorkerProcess
  SiteConfigurationSnapshotInfo.properties.time: SnapshotTakenTime
  SitePatchResource.properties.clientAffinityEnabled: IsClientAffinityEnabled
  SitePatchResource.properties.clientCertEnabled: IsClientCertEnabled
  SitePatchResource.properties.enabled: IsEnabled
  SitePatchResource.properties.hostNamesDisabled: IsHostNamesDisabled
  SitePatchResource.properties.httpsOnly: IsHttpOnly
  SitePatchResource.properties.hyperV: IsHyperV
  SitePatchResource.properties.lastModifiedTimeUtc: LastModifiedTimeOn
  SitePatchResource.properties.scmSiteAlsoStopped: IsScmSiteAlsoStopped
  SitePatchResource.properties.storageAccountRequired: IsStorageAccountRequired
  SitePatchResource.properties.suspendedTill: SuspendTillOn
  SiteSealRequest.lightTheme: IsLightTheme
  SkuDescription.locations: AzureLocations
  SnapshotRestoreRequest.properties.ignoreConflictingHostNames: IsIgnoreConflictingHostNames
  SnapshotRestoreRequest.properties.overwrite: IsOverwrite
  SnapshotRestoreRequest.properties.recoverConfiguration: IsRecoverConfiguration
  StackMajorVersion.applicationInsights: IsApplicationInsights
  StampCapacity.excludeFromCapacityAllocation: IsExcludeFromCapacityAllocation
  StaticSitePatchResource.properties.allowConfigFileUpdates: IsAllowConfigFileUpdates
  StaticSiteBuildProperties.appLocation: AppAzureLocation
  StaticSiteBuildProperties.apiLocation: ApiAzureLocation
  StaticSiteBuildProperties.appArtifactLocation: AppArtifactAzureLocation
  StaticSiteBuildProperties.outputLocation: OutputAzureLocation
  StaticSiteBuildProperties.skipGithubActionWorkflowGeneration: IsSkipGithubActionWorkflowGeneration
  StaticSiteResetPropertiesARMResource.properties.shouldUpdateRepository: IsShouldUpdateRepository
  StorageMigrationOptions.properties.blockWriteAccessToSite: IsBlockWriteAccessToSite
  TokenStore.enabled: IsEnabled
  TopLevelDomainAgreementOption.forTransfer: IsForTransfer
  TopLevelDomainAgreementOption.includePrivacy: IsIncludePrivacy
  Twitter.enabled: IsEnabled
  ValidateRequest.properties.needLinuxWorkers: IsNeedLinuxWorkers
  VirtualApplication.preloadEnabled: IsPreloadEnabled
  VirtualIPMapping.inUse: IsInUse
  VnetInfo.resyncRequired: IsResyncRequired
  VnetValidationFailureDetails.properties.failed: IsFailed
  WebAppRuntimeSettings.remoteDebuggingSupported: IsRemoteDebuggingSupported
#rename resource
  AppServiceCertificate: AppServiceCertificateInfo
  AppServiceCertificateResource: AppServicCertificate
  StaticSiteARMResource: StaticSiteARM
  StaticSiteBuildARMResource: StaticSiteBuildARM
  StaticSiteCustomDomainOverviewARMResource: StaticSiteCustomDomainOverviewARM
  StaticSiteUserProvidedFunctionAppARMResource: StaticSiteUserProvidedFunctionAppARM
# same name in model
#   VnetInfoResource: VnetInfo
  WorkerPoolResource: WorkerPool
  CsmPublishingProfileOptions: CsmPublishingProfile
  StaticSiteTemplateOptions: StaticSiteTemplate
  PrivateLinkResource: AppServicePrivateLink
  PrivateLinkResourceProperties: AppServicePrivateLinkResourceProperties
  AzureStoragePropertyDictionaryResource: AzureStoragePropertyDictionary
  ContainerThrottlingData: ContainerThrottlingInfo
  DeletedAppRestoreRequest: DeletedAppRestoreRequestInfo
  DiagnosticData: DiagnosticInfo
  DomainControlCenterSsoRequest: DomainControlCenterSsoRequestInfo
  MsDeployLogEntry: MSDeployLogEntry
  PerfMonResponse: PerfMonResponseInfo
  PrivateLinkConnectionApprovalRequestResource: PrivateLinkConnectionApprovalRequestInfo
  RestoreRequest: RestoreRequestInfo
  SitePatchResource: SitePatchInfo
  StaticSiteResetPropertiesARMResource: StaticSiteResetPropertiesARM
  StaticSiteUserARMResource: StaticSiteUserARM
  StaticSiteUserInvitationRequestResource: StaticSiteUserInvitationRequestInfo
  StaticSiteUserInvitationResponseResource: StaticSiteUserInvitationResponseInfo
  StaticSiteZipDeploymentARMResource: StaticSiteZipDeploymentARM
  StorageMigrationResponse: StorageMigrationResponseInfo

directive:
  - rename-model:
      from: AppServiceEnvironmentResource
      to: AppServiceEnvironment

# ResourceId
  - from: Certificates.json
    where: $.definitions.Certificate.properties.properties.properties.serverFarmId
    transform: $["x-ms-format"] = "arm-id"
  - from: Certificates.json
    where: $.definitions.Certificate.properties.properties.properties.keyVaultId
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
  - from: CommonDefinitions.json
    where: $.definitions.VnetInfo.properties.vnetResourceId
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

# pageable lro
  - remove-operation: AppServiceEnvironments_ChangeVnet
  - remove-operation: AppServiceEnvironments_Resume
  - remove-operation: AppServiceEnvironments_Suspend
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
