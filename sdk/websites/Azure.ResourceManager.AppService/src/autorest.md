# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

# Azure.ResourceManager.AppService

> see https://aka.ms/autorest

``` yaml
azure-arm: true
library-name: AppService
namespace: Azure.ResourceManager.AppService
require: C:\Users\v-zihewang\Documents\GitHub\azure-rest-api-specs\specification\web\resource-manager\readme.md
tag: package-2021-02
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
operation-group-to-resource-type:
  # BackupItem: Microsoft.Compute/cloudServices/roles
  ResourceHealthMetadata: Microsoft.Web/sites/resourceHealthMetadata
  Recommendations: Microsoft.Web/sites/recommendations
  Provider: Microsoft.Web
  Global: Microsoft.Web/deletedSites
  DeletedWebApps: Microsoft.Web/locations/deletedSites
  DomainRegistrationProvider: Microsoft.DomainRegistration/operations
  TopLevelDomains: Microsoft.DomainRegistration/topLevelDomains
  CertificateRegistrationProvider: Microsoft.CertificateRegistration/operations
  CertificateOrdersDiagnostics: Microsoft.CertificateRegistration/certificateOrders/detectors
  Diagnostics: Microsoft.Web/sites/diagnostics
  DiagnosticCategory: Microsoft.Web/sites/slot/diagnostics
  Slots: Microsoft.Web/sites/slots
  Site: Microsoft.Web/sites

operation-group-to-resource:
  Recommendations: RecommendationRule
  ResourceHealthMetadata: ResourceHealthMetadata
  BackupItems: BackupItem
  Provider: NonResource
  Global: NonResource
  DeletedWebApps: NonResource
  DomainRegistrationProvider: NonResource
  TopLevelDomains: NonResource
  CertificateRegistrationProvider: NonResource
  CertificateOrdersDiagnostics: NonResource
  Diagnostics: DiagnosticCategory
  DiagnosticCategory: DiagnosticCategory
  Slots: Site
  Site: Site

operation-group-to-parent:
  Recommendations: subscriptions
  ResourceHealthMetadata: subscriptions
  Provider: subscriptions
  DeletedWebApps: subscriptions
  DomainRegistrationProvider: subscriptions
  TopLevelDomains: subscriptions
  CertificateRegistrationProvider: subscriptions
  CertificateOrdersDiagnostics: subscriptions 
  Diagnostics: Microsoft.Web/sites
  DiagnosticCategory: Microsoft.Web/sites/slot
  Slots: Microsoft.Web/sites
  Site: resourceGroups

operation-group-is-extension:
- Diagnostics
- DiagnosticCategory
- Slots
- Site

operation-groups-to-omit:
- WebApps
# directive:
#   ## first we need to unify all the paths by changing `virtualmachines` to `virtualMachines` so that every path could have consistent casing
#   - from: swagger-document
#     where: $.paths
#     transform: >
#       for (var key in $) {
#           const newKey = key.replace('virtualmachines', 'virtualMachines');
#           if (newKey !== key) {
#               $[newKey] = $[key]
#               delete $[key]
#           }
#       }
#   - from: compute.json
#     where: $.definitions.VirtualMachineImageProperties.properties.dataDiskImages
#     transform: $.description="The list of data disk images information."
#   - from: disk.json
#     where: $.definitions.GrantAccessData.properties.access
#     transform: $.description="The Access Level, accepted values include None, Read, Write."
#   - rename-model:
#       from: SshPublicKey
#       to: SshPublicKeyInfo
#   - rename-model:
#       from: LogAnalyticsOperationResult
#       to: LogAnalytics
#   - rename-model:
#       from: SshPublicKeyResource
#       to: SshPublicKey
#   - rename-model:
#       from: RollingUpgradeStatusInfo
#       to: VirtualMachineScaleSetRollingUpgrade
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections/{privateEndpointConnectionName}'].put.operationId
#     transform: return "PrivateEndpointConnections_CreateOrUpdate"
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections/{privateEndpointConnectionName}'].get.operationId
#     transform: return "PrivateEndpointConnections_Get"
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections/{privateEndpointConnectionName}'].delete.operationId
#     transform: return "PrivateEndpointConnections_Delete"
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskAccesses/{diskAccessName}/privateEndpointConnections'].get.operationId
#     transform: return "PrivateEndpointConnections_List"
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/providers/Microsoft.Compute/galleries'].get.operationId
#     transform: return "Galleries_ListBySubscription"
#   ## temporary approach
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/updateDomains/{updateDomain}'].put.parameters
#     transform: >
#         $[2] = {
#             "in": "path",
#             "name": "updateDomain",
#             "description": "Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.",
#             "required": true,
#             "type": "string"
#         }
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/updateDomains/{updateDomain}'].get.parameters
#     transform: >
#         $[2] = {
#             "in": "path",
#             "name": "updateDomain",
#             "description": "Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.",
#             "required": true,
#             "type": "string"
#         }
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/start'].post.operationId
#     transform: return 'VirtualMachines_PowerOn';
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/start'].post.operationId
#     transform: return 'VirtualMachineScaleSets_PowerOn';
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/start'].post.operationId
#     transform: return 'VirtualMachineScaleSetVMs_PowerOn';
#   - from: swagger-document
#     where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/start'].post.operationId
#     transform: return 'CloudServices_PowerOn';
# ```
