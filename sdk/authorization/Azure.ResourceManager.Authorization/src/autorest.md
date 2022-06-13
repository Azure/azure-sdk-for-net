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
modelerfour:
  lenient-model-deduplication: true

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
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type
    transform: $['x-ms-client-name'] = 'RoleAssignmentExpirationType' 
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.duration
    transform: $['x-ms-format'] = 'duration-constant'
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type
    transform: $['x-ms-client-name'] = 'RoleEligibilityExpirationType' 
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.duration
    transform: $['x-ms-format'] = 'duration-constant'
  - from: common-types.json
    where: $.definitions.RoleManagementPolicyExpirationRule.properties.maximumDuration
    transform: $['x-ms-format'] = 'duration-constant'

  - rename-model:
      from: RoleAssignmentScheduleRequestProperties
      to: RoleAssignmentSchedule

  # change single class name
  - from: authorization-RoleDefinitionsCalls.json
    where: $.definitions.Permission
    transform: $['x-ms-client-name'] = "AzurePermission"
  - from: common-types.json
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
  # - from: RoleAssignmentScheduleRequest.json
  #   where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.status
  #   transform: $['x-ms-enum'].name = "RoleAssignmentScheduleRequestStatus"
  # - from: RoleAssignmentScheduleRequest.json
  #   where: $.definitions.RoleAssignmentScheduleRequestFilter.properties.principalId.description
  #   transform: $ = "foo"
  # - from: RoleAssignmentScheduleRequest.json
  #   where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.type
  #   transform: $['x-ms-enum'].name = "RoleAssignmentScheduleRequestType"

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

  # Assign the specified type
  # - from: RoleAssignmentSchedule.json
  #   where: $.definitions.RoleAssignmentScheduleProperties.properties.linkedRoleEligibilityScheduleId
  #   transform: $['x-ms-format'] = 'resource-type'
  # - from: RoleAssignmentScheduleInstance.json
  #   where: $.definitions.RoleAssignmentScheduleInstanceProperties.properties.linkedRoleEligibilityScheduleId
  #   transform: $['x-ms-format'] = 'duration-constant' 
  # - from: RoleAssignmentScheduleRequest.json
  #   where: $.definitions.RoleAssignmentScheduleRequestProperties.properties.linkedRoleEligibilityScheduleId
  #   transform: $['x-ms-format'] = 'azure-location'

```