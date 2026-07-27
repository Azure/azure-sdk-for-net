# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Authorization
namespace: Azure.ResourceManager.Authorization
require: https://github.com/Azure/azure-rest-api-specs/blob/a436672b07fb1fe276c203b086b3f0e0d0c4aa24/specification/authorization/resource-manager/readme.md
tag: package-2022-04-01
output-folder: Generated/
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
use-model-reader-writer: true
skip-csproj: true
enable-bicep-serialization: true

rename-mapping:
  RoleAssignment.properties.delegatedManagedIdentityResourceId: -|arm-id
  DenyAssignment.properties.doNotApplyToChildScopes: IsAppliedToChildScopes
  RoleAssignmentSchedule.properties.linkedRoleEligibilityScheduleId: -|arm-id
  RoleAssignmentSchedule.properties.roleAssignmentScheduleRequestId: -|arm-id
  RoleAssignmentScheduleInstance.properties.linkedRoleEligibilityScheduleId: -|arm-id
  RoleAssignmentScheduleInstance.properties.linkedRoleEligibilityScheduleInstanceId: -|arm-id
  RoleAssignmentScheduleInstance.properties.originRoleAssignmentId: -|arm-id
  RoleAssignmentScheduleInstance.properties.roleAssignmentScheduleId: -|arm-id
  RoleAssignmentScheduleRequest.properties.linkedRoleEligibilityScheduleId: -|arm-id
  RoleAssignmentScheduleRequest.properties.targetRoleAssignmentScheduleId: -|arm-id
  RoleAssignmentScheduleRequest.properties.targetRoleAssignmentScheduleInstanceId: -|arm-id
  RoleEligibilitySchedule.properties.roleEligibilityScheduleRequestId: -|arm-id
  RoleEligibilityScheduleInstance.properties.roleEligibilityScheduleId: -|arm-id
  RoleEligibilityScheduleRequest.properties.targetRoleEligibilityScheduleId: -|arm-id
  RoleEligibilityScheduleRequest.properties.targetRoleEligibilityScheduleInstanceId: -|arm-id
  RoleManagementPolicyApprovalRule.setting: Settings
  RoleManagementPolicyEnablementRule.enabledRules: EnablementRules
  RoleManagementPolicyNotificationRule.notificationType: NotificationDeliveryType
  RoleManagementPolicyNotificationRule.isDefaultRecipientsEnabled: AreDefaultRecipientsEnabled
  ScopeType.managementgroup: ManagementGroup
  ScopeType.resourcegroup: ResourceGroup
  ApprovalMode: RoleManagementApprovalMode
  ApprovalSettings: RoleManagementApprovalSettings
  ApprovalStage: RoleManagementApprovalStage
  AssignmentType: RoleAssignmentScheduleAssignmentType
  ClassicAdministrator: AuthorizationClassicAdministrator
  ClassicAdministratorListResult: AuthorizationClassicAdministratorListResult
  EnablementRules: RoleAssignmentEnablementRuleType
  ExpandedProperties: RoleManagementExpandedProperties
  NotificationDeliveryMechanism: NotificationDeliveryType
  NotificationLevel: RoleManagementPolicyNotificationLevel
  Permission: RoleDefinitionPermission
  PermissionGetResult: RoleDefinitionPermissionListResult
  RoleDefinition: AuthorizationRoleDefinition
  RoleType: AuthorizationRoleType
  PolicyProperties: RoleManagementPolicyProperties
  Principal: RoleManagementPrincipal
  PrincipalType: RoleManagementPrincipalType
  ProviderOperation: AuthorizationProviderOperationInfo
  ProviderOperationsMetadata: AuthorizationProviderOperationsMetadata
  ProviderOperationsMetadataListResult: AuthorizationProviderOperationsMetadataListResult
  RecipientType: RoleManagementPolicyRecipientType
  RoleAssignmentScheduleRequestPropertiesTicketInfo: RoleAssignmentScheduleTicketInfo
  ScopeType: RoleManagementScopeType
  UserSet: RoleManagementUserInfo
  UserType: RoleManagementUserType

models-to-treat-empty-string-as-null:
  - RoleAssignmentData

format-by-name-rules:
  'tenantId': 'uuid'
  'applicationId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'principalId': 'uuid'
  'requestorId': 'uuid'
  'roleDefinitionId': 'arm-id'
  'policyId': 'arm-id'
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

generate-arm-resource-extensions:
  - /{scope}/providers/Microsoft.Authorization/denyAssignments/{denyAssignmentId}
  - /{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}
  - /{scope}/providers/Microsoft.Authorization/roleAssignmentSchedules/{roleAssignmentScheduleName}
  - /{scope}/providers/Microsoft.Authorization/roleAssignmentScheduleInstances/{roleAssignmentScheduleInstanceName}
  - /{scope}/providers/Microsoft.Authorization/roleDefinitions/{roleDefinitionId}
  - /{scope}/providers/Microsoft.Authorization/roleAssignmentScheduleRequests/{roleAssignmentScheduleRequestName}
  - /{scope}/providers/Microsoft.Authorization/roleEligibilitySchedules/{roleEligibilityScheduleName}
  - /{scope}/providers/Microsoft.Authorization/roleEligibilityScheduleRequests/{roleEligibilityScheduleRequestName}
  - /{scope}/providers/Microsoft.Authorization/roleManagementPolicies/{roleManagementPolicyName}
  - /{scope}/providers/Microsoft.Authorization/roleManagementPolicyAssignments/{roleManagementPolicyAssignmentName}
  - /{scope}/providers/Microsoft.Authorization/roleEligibilityScheduleInstances/{roleEligibilityScheduleInstanceName}

directive:
  # The requested resource does not support http method 'DELETE'
  - remove-operation: 'RoleManagementPolicies_Delete'
  - remove-operation: 'RoleManagementPolicyAssignments_Delete'
  # TODO: remove dup methods with scope method, here is another issue logged https://github.com/Azure/autorest.csharp/issues/2629
  - remove-operation: 'RoleAssignments_ListForSubscription'
  - remove-operation: 'RoleAssignments_ListForResourceGroup'
  - remove-operation: 'RoleAssignments_ListForResource'
  - remove-operation: 'DenyAssignments_ListForResource'
  - remove-operation: 'DenyAssignments_ListForResourceGroup'
  - remove-operation: 'DenyAssignments_List'
  # remove all ById Path
  - from: authorization-RoleAssignmentsCalls.json
    where: $.paths['/{roleAssignmentId}']
    transform: $ = {}
  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/{roleDefinitionId}']
    transform: $ = {}
  - from: authorization-RoleDefinitionsCalls.json
    where: $['x-ms-paths']['/{roleId}?disambiguation_dummy']
    transform: $ = {}
  - from: authorization-DenyAssignmentCalls.json
    where: $.paths['/{denyAssignmentId}']
    transform: $ = {}

  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/permissions'].get
    transform: $.operationId = 'AzurePermissionsForResourceGroup_List'
  - from: authorization-RoleDefinitionsCalls.json
    where: $.paths['/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/permissions'].get
    transform: $.operationId = 'AzurePermissionsForResource_List'

  - from: authorization-RoleAssignmentsCalls.json
    where: $.definitions
    transform: >
      $.RoleAssignmentProperties.properties.delegatedManagedIdentityResourceId["x-nullable"] = true;
  - from: common-types.json
    where: $.definitions
    transform: >
      $.RoleManagementPolicyExpirationRule.properties.maximumDuration['format'] = 'duration';
      $.UserSet.properties.id['x-ms-format'] = 'uuid';
      $.RoleManagementPolicyRuleTarget.properties.level = {
          'type': 'string',
          'description': 'The assignment level to which rule is applied.',
          'enum': [
            'Assignment',
            'Eligibility'
          ],
          'x-ms-enum': {
            'name': 'RoleManagementAssignmentLevel',
            'modelAsString': true
          }
        };
      $.Principal.properties.type = {
          'type': 'string',
          'description': 'Type of the principal.',
          'x-ms-client-name': 'principalType',
          'enum': [
            'User',
            'Group',
            'ServicePrincipal',
            'ForeignGroup',
            'Device'
          ],
          'x-ms-enum': {
            'name': 'principalType',
            'modelAsString': true
          }
        };
      delete $.Permission;

  - from: RoleAssignmentSchedule.json
    where: $.definitions
    transform: >
      $.RoleAssignmentScheduleProperties.properties.status['x-ms-enum']['name'] = 'RoleManagementScheduleStatus';
      $.RoleAssignmentScheduleProperties.properties.memberType['x-ms-enum']['name'] = 'RoleManagementScheduleMemberType';
  - from: RoleAssignmentScheduleInstance.json
    where: $.definitions
    transform: >
      $.RoleAssignmentScheduleInstanceProperties.properties.status['x-ms-enum']['name'] = 'RoleManagementScheduleStatus';
      $.RoleAssignmentScheduleInstanceProperties.properties.memberType['x-ms-enum']['name'] = 'RoleManagementScheduleMemberType';
  - from: RoleAssignmentScheduleRequest.json
    where: $.definitions
    transform: >
      $.RoleAssignmentScheduleRequestProperties.properties.status['x-ms-enum']['name'] = 'RoleManagementScheduleStatus';
      $.RoleAssignmentScheduleRequestProperties.properties.requestType['x-ms-enum']['name'] = 'RoleManagementScheduleRequestType';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type['x-ms-enum']['name'] = 'RoleManagementScheduleExpirationType';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type['x-ms-client-name'] = 'ExpirationType';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.duration['format'] = 'duration';
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo['x-ms-client-flatten'] = true;
      $.RoleAssignmentScheduleRequestProperties.properties.scheduleInfo.properties.expiration['x-ms-client-flatten'] = true;
  - from: RoleEligibilitySchedule.json
    where: $.definitions
    transform: >
      $.RoleEligibilityScheduleProperties.properties.status['x-ms-enum']['name'] = 'RoleManagementScheduleStatus';
      $.RoleEligibilityScheduleProperties.properties.memberType['x-ms-enum']['name'] = 'RoleManagementScheduleMemberType';
  - from: RoleEligibilityScheduleInstance.json
    where: $.definitions
    transform: >
      $.RoleEligibilityScheduleInstanceProperties.properties.status['x-ms-enum']['name'] = 'RoleManagementScheduleStatus';
      $.RoleEligibilityScheduleInstanceProperties.properties.memberType['x-ms-enum']['name'] = 'RoleManagementScheduleMemberType';
  - from: RoleEligibilityScheduleRequest.json
    where: $.definitions
    transform: >
      $.RoleEligibilityScheduleRequestProperties.properties.status['x-ms-enum']['name'] = 'RoleManagementScheduleStatus';
      $.RoleEligibilityScheduleRequestProperties.properties.requestType['x-ms-enum']['name'] = 'RoleManagementScheduleRequestType';
      $.RoleEligibilityScheduleRequestProperties.properties.scheduleInfo.properties.expiration.properties.type['x-ms-enum']['name'] = 'RoleManagementScheduleExpirationType';
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
      $.PolicyProperties.properties.scope.properties.type = {
          'type': 'string',
          'description': 'Type of the scope.',
          'x-ms-client-name': 'ScopeType',
          'enum': [
            'subscription',
            'managementgroup',
            'resourcegroup'
          ],
          'x-ms-enum': {
            'name': 'ScopeType',
            'modelAsString': true
          }
        };
  - from: authorization-RoleDefinitionsCalls.json
    where: $.definitions
    transform: >
      $.RoleDefinitionProperties.properties.type = {
          'type': 'string',
          'description': 'The role type.',
          'x-ms-client-name': 'RoleType',
          'enum': [
            'BuiltInRole',
            'CustomRole'
          ],
          'x-ms-enum': {
            'name': 'RoleType',
            'modelAsString': true
          }
        };
  - from: authorization-ProviderOperationsCalls.json
    where: $.definitions
    transform: >
      $.ResourceType['x-ms-client-name'] = 'AuthorizationProviderResourceType';
      $.ProviderOperation.properties.properties['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.ExpandedProperties.properties
    transform: >
      $.scope['x-ms-client-flatten'] = true;
      $.scope.properties.id['x-ms-format'] = 'arm-id';
      $.scope.properties.id['x-ms-client-name'] = 'ScopeId';
      $.scope.properties.displayName['x-ms-client-name'] = 'ScopeDisplayName';
      $.scope.properties.type = {
          'type': 'string',
          'description': 'Type of the scope.',
          'x-ms-client-name': 'ScopeType',
          'enum': [
            'subscription',
            'managementgroup',
            'resourcegroup'
          ],
          'x-ms-enum': {
            'name': 'ScopeType',
            'modelAsString': true
          }
        };
      $.roleDefinition['x-ms-client-flatten'] = true;
      $.roleDefinition.properties.id['x-ms-format'] = 'arm-id';
      $.roleDefinition.properties.id['x-ms-client-name'] = 'RoleDefinitionId';
      $.roleDefinition.properties.displayName['x-ms-client-name'] = 'RoleDefinitionDisplayName';
      $.roleDefinition.properties.type = {
          'type': 'string',
          'description': 'The role type.',
          'x-ms-client-name': 'RoleType',
          'enum': [
            'BuiltInRole',
            'CustomRole'
          ],
          'x-ms-enum': {
            'name': 'RoleType',
            'modelAsString': true
          }
        };
      $.principal['x-ms-client-flatten'] = true;
      $.principal.properties.id['x-ms-format'] = 'arm-id';
      $.principal.properties.id['x-ms-client-name'] = 'PrincipalId';
      $.principal.properties.displayName['x-ms-client-name'] = 'PrincipalDisplayName';
      $.principal.properties.type = {
          'type': 'string',
          'description': 'Type of the principal.',
          'x-ms-client-name': 'principalType',
          'enum': [
            'User',
            'Group',
            'ServicePrincipal',
            'ForeignGroup',
            'Device'
          ],
          'x-ms-enum': {
            'name': 'principalType',
            'modelAsString': true
          }
        };
  - from: swagger-document
    where: $.definitions.PolicyAssignmentProperties.properties
    transform: >
      $.scope['x-ms-client-flatten'] = true;
      $.scope.properties.id['x-ms-format'] = 'arm-id';
      $.scope.properties.id['x-ms-client-name'] = 'ScopeId';
      $.scope.properties.displayName['x-ms-client-name'] = 'ScopeDisplayName';
      $.scope.properties.type = {
          'type': 'string',
          'description': 'Type of the scope.',
          'x-ms-client-name': 'ScopeType',
          'enum': [
            'subscription',
            'managementgroup',
            'resourcegroup'
          ],
          'x-ms-enum': {
            'name': 'ScopeType',
            'modelAsString': true
          }
        };
      $.roleDefinition['x-ms-client-flatten'] = true;
      $.roleDefinition.properties.id['x-ms-format'] = 'arm-id';
      $.roleDefinition.properties.id['x-ms-client-name'] = 'RoleDefinitionId';
      $.roleDefinition.properties.displayName['x-ms-client-name'] = 'RoleDefinitionDisplayName';
      $.roleDefinition.properties.type = {
          'type': 'string',
          'description': 'The role type.',
          'x-ms-client-name': 'RoleType',
          'enum': [
            'BuiltInRole',
            'CustomRole'
          ],
          'x-ms-enum': {
            'name': 'RoleType',
            'modelAsString': true
          }
        };
      $.policy['x-ms-client-flatten'] = true;
      $.policy.properties.id['x-ms-format'] = 'arm-id';
      $.policy.properties.id['x-ms-client-name'] = 'PolicyId';

```
