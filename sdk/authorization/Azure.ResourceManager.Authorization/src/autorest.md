# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
tag: package-2020-10-01
library-name: Authorization
namespace: Azure.ResourceManager.Authorization
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a416080c85111fbe4e0a483a1b99f1126ca6e97c/specification/authorization/resource-manager/readme.md
output-folder: Generated/
clear-output-folder: true
skip-csproj: true

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

list-exception: 
- /{roleDefinitionId}
- /{roleAssignmentId}

directive:
  # Duplicate Schema name
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions.RoleAssignmentScheduleRequestProperties
    transform: $['x-ms-client-name'] = 'RoleAssignmentScheduleRequestProperties' 

  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type
    transform: $['x-ms-client-name'] = 'RoleAssignmentExpirationType' 
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.duration
    transform: $['x-ms-format'] = 'constant'
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type
    transform: $['x-ms-client-name'] = 'RoleEligibilityExpirationType' 
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.duration
    transform: $['x-ms-format'] = 'constant'
  - from: common-types.json
    where: $.definitions.RoleManagementPolicyExpirationRule.properties.maximumDuration
    transform: $['x-ms-format'] = 'constant'

  # change single class name
  - from: authorization-RoleDefinitionsCalls.json
    where: $.definitions.Permission
    transform: $['x-ms-client-name'] = "AzurePermission"
  - from: common-types.json
    where: $.definitions.Principal
    transform: $['x-ms-client-name'] = "AzurePrincipal"
  - from: RoleAssignmentSchedule.json
    where: $.definitions.RoleAssignmentScheduleProperties.properties.status
    transform: $['x-ms-enum'].name = "RoleAssignmentScheduleStatus"
  - from: RoleAssignmentScheduleInstance.json
    where: $.definitions.RoleAssignmentScheduleInstanceProperties.properties.status
    transform: $['x-ms-enum'].name = "RoleAssignmentScheduleInstanceStatus"
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.status
    transform: $['x-ms-enum'].name = "RoleAssignmentScheduleRequestStatus"
  - from: RoleEligibilitySchedule.json
    where: $.definitions.RoleEligibilityScheduleProperties.properties.status
    transform: $['x-ms-enum'].name = "RoleEligibilityScheduleStatus"
  - from: RoleEligibilityScheduleInstance.json
    where: $.definitions.RoleEligibilityScheduleInstanceProperties.properties.status
    transform: $['x-ms-enum'].name = "RoleEligibilityScheduleInstanceStatus"
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions.RoleEligibilityScheduleRequestProperties.properties.status
    transform: $['x-ms-enum'].name = "RoleEligibilityScheduleRequestStatus"
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type
    transform: $['x-ms-enum'].name = "RoleAssignmentScheduleType"
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type
    transform: $['x-ms-enum'].name = "RoleEligibilityScheduleType"

  # Rename the name of the common class
  - from: authorization-ProviderOperationsCalls.json
    where: $.definitions.ResourceType
    transform:  $['x-ms-client-name'] = "ProviderOperationsResourceType"

  # remove all ById Path
  - from: authorization-RoleAssignmentsCalls.json
    where: $.paths['/{roleAssignmentId}']
    transform: $ = {}
  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/{roleDefinitionId}']
    transform: $ = {}

  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/permissions'].get
    transform: $.operationId = "AzurePermissionsForResourceGroup_List"
  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/permissions'].get
    transform: $.operationId = "AzurePermissionsForResource_List" 

  # change type to ResourceIdentifier
  - from: authorization-RoleAssignmentsCalls.json
    where: $.definitions.RoleAssignmentPropertiesWithScope.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: RoleAssignmentSchedule.json
    where: $.definitions.RoleAssignmentScheduleProperties.properties.roleAssignmentScheduleRequestId
    transform: $['x-ms-format'] = 'arm-id'
  - from: RoleAssignmentScheduleInstance.json
    where: $.definitions.RoleAssignmentScheduleInstanceProperties.properties.originRoleAssignmentId
    transform: $['x-ms-format'] = 'arm-id'
  - from: RoleAssignmentScheduleInstance.json
    where: $.definitions.RoleAssignmentScheduleInstanceFilter.properties.roleAssignmentScheduleId
    transform: $['x-ms-format'] = 'arm-id'
  - from: RoleAssignmentScheduleInstance.json
    where: $.definitions.RoleAssignmentScheduleInstanceProperties.properties.roleAssignmentScheduleId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleAssignmentScheduleFilter.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleAssignmentScheduleProperties.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleAssignmentScheduleInstanceFilter.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleAssignmentScheduleInstanceProperties.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleAssignmentScheduleRequestFilter.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleFilter.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleProperties.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleInstanceFilter.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleInstanceProperties.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleRequestFilter.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleRequestProperties.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleManagementPolicyAssignmentProperties.properties.roleDefinitionId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleInstanceFilter.properties.roleEligibilityScheduleId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleInstanceProperties.properties.roleEligibilityScheduleId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleManagementPolicyAssignmentProperties.properties.policyId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.RoleEligibilityScheduleProperties.properties.roleEligibilityScheduleRequestId
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.ExpandedProperties.properties.roleDefinition.properties.id
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.PolicyAssignmentProperties.properties.roleDefinition.properties.id
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.ExpandedProperties.properties.scope.properties.id
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.PolicyAssignmentProperties.properties.scope.properties.id
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.PolicyAssignmentProperties.properties.policy.properties.id
    transform: $['x-ms-format'] = 'arm-id'
  - from: swagger-document
    where: $.definitions.PolicyProperties.properties.scope.properties.id
    transform: $['x-ms-format'] = 'arm-id'

  # Rename models
  - rename-model:
      from: RoleAssignmentScheduleRequestProperties
      to: RoleAssignmentSchedule
  - rename-model:
      from: ProviderOperationsMetadata
      to: ProviderOperations
  - rename-model:
      from: UserSet
      to: UserInfo
```