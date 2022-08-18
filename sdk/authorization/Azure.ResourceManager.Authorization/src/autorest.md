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

rename-mapping:
  ProviderOperation: ProviderOperationInfo
  UserSet: RoleManagementUserInfo
  UserType: RoleManagementUserType
  PolicyProperties: RoleManagementPolicyProperties
  Permission: RoleDefinitionPermission
  PermissionGetResult: RoleDefinitionPermissionListResult
  ApprovalSettings: RoleManagementApprovalSettings
  ApprovalMode: RoleManagementApprovalMode
  ApprovalStage: RoleManagementApprovalStage
  AssignmentType: RoleAssignmentScheduleAssignmentType
  EnablementRules: RoleAssignmentEnablementRuleType
  Principal: RoleManagementPrincipal
  NotificationLevel: RoleManagementPolicyNotificationLevel
  RecipientType: RoleManagementPolicyRecipientType

format-by-name-rules:
  'tenantId': 'uuid'
  'applicationId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'principalId': 'uuid'
  'requestorId': 'uuid'
  'targetRoleAssignmentScheduleId': 'uuid'
  'targetRoleAssignmentScheduleInstanceId': 'uuid'
  'linkedRoleEligibilityScheduleId': 'uuid'
  'roleEligibilityScheduleId': 'arm-id'
  'linkedRoleEligibilityScheduleInstanceId': 'uuid'
  'roleAssignmentScheduleRequestId': 'arm-id'
  'roleEligibilityScheduleRequestId': 'arm-id'
  'originRoleAssignmentId': 'arm-id'
  'roleAssignmentScheduleId': 'arm-id'
  'roleDefinitionId': 'arm-id'
  'policyId': 'arm-id'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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

request-path-to-resource-type:
  /{scope}/providers/Microsoft.Authorization/roleManagementPolicyAssignments/{roleManagementPolicyAssignmentName}: Microsoft.Authorization/roleManagementPolicyAssignment

list-exception: 
- /{roleDefinitionId}
- /{roleAssignmentId}

directive:
  # The requested resource does not support http method 'DELETE'
  - remove-operation: 'RoleManagementPolicies_Delete'
  - remove-operation: 'RoleManagementPolicyAssignments_Delete'

  # remove all ById Path
  - from: authorization-RoleAssignmentsCalls.json
    where: $.paths['/{roleAssignmentId}']
    transform: $ = {}
  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/{roleDefinitionId}']
    transform: $ = {}

  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/permissions'].get
    transform: $.operationId = 'AzurePermissionsForResourceGroup_List'
  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/permissions'].get
    transform: $.operationId = 'AzurePermissionsForResource_List' 

  - from: common-types.json
    where: $.definitions
    transform: >
      $.RoleManagementPolicyExpirationRule.properties.maximumDuration['format'] = 'duration';
      $.UserSet.properties.id['x-ms-format'] = 'uuid';
      delete $.Permission;

  - from: RoleAssignmentSchedule.json
    where: $.definitions
    transform: >
      $.RoleAssignmentScheduleProperties.properties.status['x-ms-enum']['name'] = 'RoleAssignmentScheduleStatus';
      $.RoleAssignmentScheduleProperties.properties.principalType['x-ms-enum']['name'] = 'RoleAssignmentSchedulePrincipalType';
      $.RoleAssignmentScheduleProperties.properties.memberType['x-ms-enum']['name'] = 'RoleAssignmentScheduleMemberType';
  - from: RoleAssignmentScheduleInstance.json
    where: $.definitions
    transform: >
      $.RoleAssignmentScheduleInstanceProperties.properties.status['x-ms-enum']['name'] = 'RoleAssignmentScheduleStatus';
      $.RoleAssignmentScheduleInstanceProperties.properties.principalType['x-ms-enum']['name'] = 'RoleAssignmentSchedulePrincipalType';
      $.RoleAssignmentScheduleInstanceProperties.properties.memberType['x-ms-enum']['name'] = 'RoleAssignmentScheduleMemberType';
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions
    transform: >
      $.RoleAssignmentScheduleRequestProperties.properties.status['x-ms-enum']['name'] = 'RoleAssignmentScheduleStatus';
      $.RoleAssignmentScheduleRequestProperties.properties.principalType['x-ms-enum']['name'] = 'RoleAssignmentSchedulePrincipalType';
      $.RoleAssignmentScheduleRequestProperties.properties.requestType['x-ms-enum']['name'] = 'RoleAssignmentScheduleRequestType';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type['x-ms-enum']['name'] = 'RoleAssignmentScheduleExpirationType';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type['x-ms-client-name'] = 'ExpirationType';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.duration['format'] = 'duration';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo['x-ms-client-flatten'] = true;
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration['x-ms-client-flatten'] = true;
  - from: RoleEligibilitySchedule.json
    where: $.definitions
    transform: >
      $.RoleEligibilityScheduleProperties.properties.status['x-ms-enum']['name'] = 'RoleEligibilityScheduleStatus';
      $.RoleEligibilityScheduleProperties.properties.principalType['x-ms-enum']['name'] = 'RoleEligibilitySchedulePrincipalType';
      $.RoleEligibilityScheduleProperties.properties.memberType['x-ms-enum']['name'] = 'RoleEligibilityScheduleMemberType';
  - from: RoleEligibilityScheduleInstance.json
    where: $.definitions
    transform: >
      $.RoleEligibilityScheduleInstanceProperties.properties.status['x-ms-enum']['name'] = 'RoleEligibilityScheduleStatus';
      $.RoleEligibilityScheduleInstanceProperties.properties.principalType['x-ms-enum']['name'] = 'RoleEligibilitySchedulePrincipalType';
      $.RoleEligibilityScheduleInstanceProperties.properties.memberType['x-ms-enum']['name'] = 'RoleEligibilityScheduleMemberType';
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions
    transform: >
      $.RoleEligibilityScheduleRequestProperties.properties.status['x-ms-enum']['name'] = 'RoleEligibilityScheduleStatus';
      $.RoleEligibilityScheduleRequestProperties.properties.principalType['x-ms-enum']['name'] = 'RoleEligibilitySchedulePrincipalType';
      $.RoleEligibilityScheduleRequestProperties.properties.requestType['x-ms-enum']['name'] = 'RoleEligibilityScheduleRequestType';
      $.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type['x-ms-enum']['name'] = 'RoleEligibilityScheduleExpirationType';
      $.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type['x-ms-client-name'] = 'ExpirationType';
      $.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.duration['format'] = 'duration';
      $.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo['x-ms-client-flatten'] = true;
      $.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration['x-ms-client-flatten'] = true;
  - from: RoleManagementPolicy.json
    where: $.definitions
    transform: >
      $.PolicyProperties.properties.scope['x-ms-client-flatten'] = true;
      $.PolicyProperties.properties.scope.properties.id['x-ms-format'] = 'arm-id';
      $.PolicyProperties.properties.scope.properties.id['x-ms-client-name'] = 'ScopeId';
      $.PolicyProperties.properties.scope.properties.displayName['x-ms-client-name'] = 'ScopeDisplayName';
      $.PolicyProperties.properties.scope.properties.type['x-ms-client-name'] = 'ScopeType';

  - from: authorization-ProviderOperationsCalls.json
    where: $.definitions
    transform: >
      $.ResourceType['x-ms-client-name'] = 'ProviderOperationsResourceType';
      $.ProviderOperation.properties.properties['x-nullable'] = true

  - from: swagger-document
    where: $.definitions.ExpandedProperties.properties
    transform: >
      $.scope['x-ms-client-flatten'] = true;
      $.scope.properties.id['x-ms-format'] = 'arm-id';
      $.scope.properties.id['x-ms-client-name'] = 'ScopeId';
      $.scope.properties.displayName['x-ms-client-name'] = 'ScopeDisplayName';
      $.scope.properties.type['x-ms-client-name'] = 'ScopeType';
      $.roleDefinition['x-ms-client-flatten'] = true;
      $.roleDefinition.properties.id['x-ms-format'] = 'arm-id';
      $.roleDefinition.properties.id['x-ms-client-name'] = 'RoleDefinitionId';
      $.roleDefinition.properties.displayName['x-ms-client-name'] = 'RoleDefinitionDisplayName';
      $.roleDefinition.properties.type['x-ms-client-name'] = 'RoleDefinitionType';
      $.principal['x-ms-client-flatten'] = true;
      $.principal.properties.id['x-ms-format'] = 'arm-id';
      $.principal.properties.id['x-ms-client-name'] = 'PrincipalId';
      $.principal.properties.displayName['x-ms-client-name'] = 'PrincipalDisplayName';
      $.principal.properties.type['x-ms-client-name'] = 'PrincipalType';

  - from: swagger-document
    where: $.definitions.PolicyAssignmentProperties.properties
    transform: >
      $.scope['x-ms-client-flatten'] = true;
      $.scope.properties.id['x-ms-format'] = 'arm-id';
      $.scope.properties.id['x-ms-client-name'] = 'ScopeId';
      $.scope.properties.displayName['x-ms-client-name'] = 'ScopeDisplayName';
      $.scope.properties.type['x-ms-client-name'] = 'ScopeType';
      $.roleDefinition['x-ms-client-flatten'] = true;
      $.roleDefinition.properties.id['x-ms-format'] = 'arm-id';
      $.roleDefinition.properties.id['x-ms-client-name'] = 'RoleDefinitionId';
      $.roleDefinition.properties.displayName['x-ms-client-name'] = 'RoleDefinitionDisplayName';
      $.roleDefinition.properties.type['x-ms-client-name'] = 'RoleDefinitionType';
      $.policy['x-ms-client-flatten'] = true;
      $.policy.properties.id['x-ms-format'] = 'arm-id';
      $.policy.properties.id['x-ms-client-name'] = 'PolicyId';

```
