# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Confluent
namespace: Azure.ResourceManager.Confluent
require: https://github.com/Azure/azure-rest-api-specs/blob/fca48bec19cc5aab0a45c0769bfca0f667164dbf/specification/confluent/resource-manager/readme.md
#tag: package-2024-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

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
  API: Api

prepend-rp-prefix:
  - ProvisionState
  - UserDetail
  - OfferDetail
  - SaaSOfferStatus
  - APIKeyRecord

rename-mapping:
  OrganizationResource: ConfluentOrganization
  OrganizationResource.properties.organizationId: -|uuid
  OrganizationResourceListResult: ConfluentOrganizationListResult
  ConfluentAgreementResource: ConfluentAgreement
  ConfluentAgreementResource.properties.accepted: IsAccepted
  ConfluentAgreementResource.properties.retrieveDatetime: RetrieveOn
  OrganizationResourceUpdate: ConfluentOrganizationPatch
  ConfluentAgreementResourceListResponse: ConfluentAgreementListResult
  ValidationResponse: ConfluentOrganizationValidationResult
  CreateAPIKeyModel: ConfluentApiKeyCreateContent
  MetadataEntity.created_at: CreatedOn|date-time
  MetadataEntity.updated_at: UpdatedOn|date-time
  MetadataEntity.deleted_at: DeletedOn|date-time
  SCMetadataEntity.createdTimestamp: CreatedOn|date-time
  SCMetadataEntity.updatedTimestamp: UpdatedOn|date-time
  SCMetadataEntity.deletedTimestamp: DeletedOn|date-time
  ListAccessRequestModel: AccessListContent
  AccessListClusterSuccessResponse: AccessClusterListResult
  ClusterRecord: AccessClusterRecord
  AccessListEnvironmentsSuccessResponse: AccessEnvironmentListResult
  EnvironmentRecord: AccessEnvironmentRecord
  AccessListInvitationsSuccessResponse: AccessInvitationListResult
  InvitationRecord: AccessInvitationRecord
  InvitationRecord.accepted_at: AcceptedOn|date-time
  InvitationRecord.expires_at: ExpireOn|date-time
  ListRegionsSuccessResponse: ConfluentRegionListResult
  RegionRecord: ConfluentRegionRecord
  AccessRoleBindingNameListSuccessResponse: AccessRoleBindingNameListResult
  AccessListServiceAccountsSuccessResponse: AccessServiceAccountListResult
  ServiceAccountRecord: AccessServiceAccountRecord
  AccessCreateRoleBindingRequestModel: AccessRoleBindingCreateContent
  RoleBindingRecord: AccessRoleBindingRecord
  AccessInviteUserAccountModel: AccessInvitationContent
  AccessListUsersSuccessResponse: AccessUserListResult
  UserRecord: AccessUserRecord
  AccessListRoleBindingsSuccessResponse: AccessRoleBindingListResult

override-operation-name:
  Validations_ValidateOrganization: ValidateOrganization
  Validations_ValidateOrganizationV2: ValidateOrganizationV2
  Organization_GetClusterById: GetCluster
  Organization_GetEnvironmentById: GetEnvironment
  Organization_GetSchemaRegistryClusterById: GetSchemaRegistryCluster
  Access_CreateRoleBinding: CreateAccessRoleBinding
  Access_DeleteRoleBinding: DeleteAccessRoleBinding
  Access_ListClusters: GetAccessClusters
  Access_ListEnvironments: GetAccessEnvironments
  Access_ListInvitations: GetAccessInvitations
  Access_ListRoleBindingNameList: GetAccessRoleBindingNames
  Access_ListServiceAccounts: GetAccessServiceAccounts
  Access_InviteUser: InviteUser
  Access_ListUsers: GetAccessUsers
  Access_ListRoleBindings: GetAccessRoleBindings

directive:
  - remove-operation: OrganizationOperations_List

```
