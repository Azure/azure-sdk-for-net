# Generated code configuration
Run `dotnet build /t:GenerateCode` to generate code.
``` yaml
azure-arm: true
csharp: true
library-name: Automanage
namespace: Azure.ResourceManager.Automanage
require: https://github.com/Azure/azure-rest-api-specs/blob/4b5fe2fb0a5066c4ff2bd429dbd5e1afda6afab3/specification/automanage/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
request-path-is-non-resource:
  - /{scope}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}
  - /subscriptions/{subscriptionId}/providers/Microsoft.Automanage/servicePrincipals/default

parameterized-scopes:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}: AutomanageVmConfigurationProfileAssignment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}: AutomanageHcrpConfigurationProfileAssignment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}: AutomanageHciClusterConfigurationProfileAssignment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}: AutomanageVmConfigurationProfileAssignmentReport
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}: AutomanageHcrpConfigurationProfileAssignmentReport
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}: AutomanageHciClusterConfigurationProfileAssignmentReport
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automanage/configurationProfiles/{configurationProfileName}: AutomanageConfigurationProfile
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automanage/configurationProfiles/{configurationProfileName}/versions/{versionName}: AutomanageConfigurationProfileVersion

override-operation-name:
  ServicePrincipals_ListBySubscription: GetServicePrincipals

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
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

rename-mapping:
  ConfigurationProfile: AutomanageConfigurationProfile
  ConfigurationProfileAssignment: AutomanageConfigurationProfileAssignment
  ConfigurationProfileAssignmentProperties: AutomanageConfigurationProfileAssignmentProperties
  ConfigurationProfileAssignmentProperties.configurationProfile: -|arm-id
  ConfigurationProfileAssignmentProperties.targetId: -|arm-id
  Report: AutomanageConfigurationProfileAssignmentReport
  Report.properties.startTime: StartOn|date-time
  Report.properties.endTime: EndOn|date-time
  Report.properties.lastModifiedTime: LastModifiedOn|date-time
  Report.properties.type: ConfigurationProfileAssignmentProcessingType
  ReportResource: ConfigurationProfileAssignmentReportResourceDetails
  BestPractice: AutomanageBestPractice
  ServicePrincipal: AutomanageServicePrincipalData
  ServicePrincipal.properties.authorizationSet: IsAuthorizationSet
  UpdateResource: AutomanageResourceUpdateDetails

directive:
  # these operations will be supported in the future
  - remove-operation: BestPracticesVersions_Get
  - remove-operation: BestPracticesVersions_ListByTenant
  - remove-operation: ConfigurationProfileAssignments_ListBySubscription
  - remove-operation: ConfigurationProfileAssignments_List
```
