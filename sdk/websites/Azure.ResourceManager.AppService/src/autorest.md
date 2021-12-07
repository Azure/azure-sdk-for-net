# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.AppService

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: AppService
namespace: Azure.ResourceManager.AppService
require: https://github.com/Azure/azure-rest-api-specs/blob/ec2b6d1985ce89c8646276e0806a738338e98bd2/specification/web/resource-manager/readme.md
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

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/capacities/virtualip
- /subscriptions/{subscriptionId}/providers/Microsoft.Web/locations/{location}/deletedSites/{deletedSiteId}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql/status
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/networkFeatures/{view}

request-path-to-singleton-resource: 
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/sourcecontrols/web: sourcecontrols/web
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/configurations/networking: configurations/networking
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/ftp: basicPublishingCredentialsPolicies/ftp
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm: basicPublishingCredentialsPolicies/scm
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/logs: config/logs
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/logs: config/logs
# exist problem
#   /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web/snapshots/{snapshotId}: snapshots/{snapshotId}
#   /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots/{snapshotId}: snapshots/{snapshotId}
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web: config/web
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/migratemysql/status: migratemysql/status
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/privateAccess/virtualNetworks: privateAccess/virtualNetworks
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/ftp: basicPublishingCredentialsPolicies/ftp
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm: basicPublishingCredentialsPolicies/scm
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web: config/web
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/networkConfig/virtualNetwork: networkConfig/virtualNetwork
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/slotConfigNames: config/slotConfigNames

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

mgmt-debug:
  show-request-path: true
  suppress-list-exception: true
      
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
  - rename-model:
      from: SiteConfigResource
      to: SiteConfig

# Enum rename
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Web/availableStacks"].get.parameters
    transform: >
      $[0]={
            "name": "osTypeSelected",
            "in": "query",
            "type": "string",
            "enum": [
              "Windows",
              "Linux",
              "WindowsFunctions",
              "LinuxFunctions",
              "All"
            ],
            "x-ms-enum": {
            "name": "OsTypeSelected",
            "modelAsString": true
          }
          }
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Web/availableStacks"].get.parameters
    transform: >
      $[0]={
            "name": "osTypeSelected",
            "in": "query",
            "type": "string",
            "enum": [
              "Windows",
              "Linux",
              "WindowsFunctions",
              "LinuxFunctions",
              "All"
            ],
            "x-ms-enum": {
            "name": "OsTypeSelected",
            "modelAsString": true
          }
          }
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Web/functionAppStacks"].get.parameters
    transform: >
      $[1]={
            "name": "stackOsType",
            "in": "query",
            "description": "Stack OS Type",
            "type": "string",
            "enum": [
              "Windows",
              "Linux",
              "All"
            ],
            "x-ms-enum": {
            "name": "StackOsType",
            "modelAsString": true
          }
          }
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Web/webAppStacks"].get.parameters
    transform: >
      $[1]={
            "name": "stackOsType",
            "in": "query",
            "description": "Stack OS Type",
            "type": "string",
            "enum": [
              "Windows",
              "Linux",
              "All"
            ],
            "x-ms-enum": {
            "name": "StackOsType",
            "modelAsString": true
          }
          }
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Web/locations/{location}/functionAppStacks"].get.parameters
    transform: >
      $[0]={
            "name": "location",
            "in": "path",
            "description": "Function App stack location.",
            "required": true,
            "type": "string"
          },
          {
            "name": "stackOsType",
            "in": "query",
            "description": "Stack OS Type",
            "type": "string",
            "enum": [
              "Windows",
              "Linux",
              "All"
            ],
            "x-ms-enum": {
            "name": "StackOsType",
            "modelAsString": true
          }
          }
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Web/locations/{location}/webAppStacks"].get.parameters
    transform: >
      $[0]={
            "name": "location",
            "in": "path",
            "description": "Web App stack location.",
            "required": true,
            "type": "string"
          },
          {
            "name": "stackOsType",
            "in": "query",
            "description": "Stack OS Type",
            "type": "string",
            "enum": [
              "Windows",
              "Linux",
              "All"
            ],
            "x-ms-enum": {
            "name": "StackOsType",
            "modelAsString": true
          }
          }
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
    where: $.definitions.ApiManagementConfig.properties
    transform: >
        $["apiconfig111"] = {
          "description": "this is a fake",
          "type": "string"
        }
  - from: swagger-document
    where: $.definitions.SiteConfig.properties
    transform: >
        delete $["minTlsVersion"];
        delete $["scmMinTlsVersion"];
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
