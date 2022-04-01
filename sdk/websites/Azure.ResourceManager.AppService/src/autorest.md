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
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
  naming:
    override:
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
      Status: OperationStatus
      DetectorResponse: AppServiceDetector
      DetectorDefinitionResource: DetectorDefinition
    
output-folder: ./Generated

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
#   /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/backups/{backupId}: SiteSlotBackUp
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}: WebSite

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

no-property-type-replacement:
- ApiManagementConfig

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
      
directive:
# rename model
  - rename-model:
      from: ApiKVReference
      to: ApiKeyVaultReference
# 2 AppServiceCertificate exists in 2 different files 
#   - rename-model:
#       from: AppServiceCertificateResource
#       to: AppServiceCertificate
  - rename-model:
      from: AppServiceEnvironmentResource
      to: AppServiceEnvironment
#   - rename-model:
#       from: Certificate
#       to: AppServiceCertificate
#   - rename-model:
#       from: DetectorDefinitionResource
#       to: DetectorDefinition
#   - rename-model:
#       from: DetectorResponse
#       to: AppServiceDetector
  - rename-model:
      from: Domain
      to: AppServiceDomain
#   - rename-model:
#       from: SiteConfig
#       to: SiteConfigProperties
#   - rename-model:
#       from: SiteConfigResource
#       to: SiteConfig

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
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties
#     transform: >
#         delete $["minTlsVersion"];
#         delete $["scmMinTlsVersion"];
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
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.defaultDocuments
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.requestTracingEnabled
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.remoteDebuggingEnabled
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.logsDirectorySizeLimit
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.httpLoggingEnabled
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.detailedErrorLoggingEnabled
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.appSettings
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.connectionStrings
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.machineKey
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.handlerMappings
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.scmType
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.use32BitWorkerProcess
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.webSocketsEnabled
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.managedPipelineMode
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.virtualApplications
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.loadBalancing
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.experiments
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.limits
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.autoHealEnabled
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.autoHealRules
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.vnetRouteAllEnabled
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.vnetPrivatePortsCount
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.cors
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.push
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.apiDefinition
#     transform: >
#         $["x-nullable"] = true;
#   - from: swagger-document
#     where: $.definitions.SiteConfig.properties.apiManagementConfig
#     transform: >
#         $["x-nullable"] = true;
```
