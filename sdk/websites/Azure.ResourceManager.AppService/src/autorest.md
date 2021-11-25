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
output-folder: ./Generated

mgmt-debug:
  show-request-path: true
  suppress-list-exception: true

directive:
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
