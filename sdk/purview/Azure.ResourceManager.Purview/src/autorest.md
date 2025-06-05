# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Purview
namespace: Azure.ResourceManager.Purview
require: https://github.com/Azure/azure-rest-api-specs/blob/86a89f22f5e18449a3fde7c00a416f18c19b70f9/specification/purview/resource-manager/readme.md
#tag: package-2023-05-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
use-model-reader-writer: true
modelerfour:
  flatten-payloads: false

#mgmt-debug: 
#  show-serialized-names: true

rename-mapping:
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  CollectionAdminUpdate.objectId: AdminObjectId
  DefaultAccountPayload.scopeTenantId: -|uuid
  ManagedResources.eventHubNamespace: -|arm-id
  ManagedResources.resourceGroup: -|arm-id
  ManagedResources.storageAccount: -|arm-id
  Account: PurviewAccount
  AccountEndpoints: PurviewAccountEndpoint
  AccountProperties: PurviewAccountProperties
  AccessKeys: PurviewAccountAccessKey
  CheckNameAvailabilityRequest: PurviewAccountNameAvailabilityContent
  CheckNameAvailabilityResult: PurviewAccountNameAvailabilityResult
  CollectionAdminUpdate: CollectionAdminUpdateContent
  DefaultAccountPayload: DefaultPurviewAccountPayload
  ManagedResources: PurviewManagedResource
  Name: PurviewAccountSkuName
  ProvisioningState: PurviewProvisioningState
  PublicNetworkAccess: PurviewPublicNetworkAccess
  Reason: PurviewAccountNameUnavailableReason
  ScopeType: PurviewAccountScopeType
  Status: PurviewPrivateLinkServiceStatus
  PrivateEndpointConnectionStatusUpdateResponse: PrivateEndpointConnectionStatusUpdateResult
  BatchFeatureRequest: PurviewBatchFeatureContent
  BatchFeatureStatus:  PurviewBatchFeatureStatus
  EventHubType: PurviewKafkaEventHubType

prepend-rp-prefix:
  - KafkaConfiguration
  - Credentials
  - CredentialsType
  - AccountProvisioningState
  - AccountStatus
  - EventStreamingState
  - EventStreamingType
  - IngestionStorage
  - ManagedEventHubState
  - UsageName
  - QuotaName

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

override-operation-name:
  Accounts_CheckNameAvailability: CheckPurviewAccountNameAvailability

directive:
  - from: purview.json
    where: $.definitions
    transform: >
      $.AccountSku['x-ms-client-name'] = 'PurviewAccountSku';
      $.Identity.properties.type['x-ms-enum']['name'] = 'IdentityType';
      delete $.Account.properties.sku['allOf'];
      $.Account.properties.sku['$ref'] = '#/definitions/AccountSku';
      delete $.AccountProperties.properties.endpoints['allOf'];
      $.AccountProperties.properties.endpoints['$ref'] = '#/definitions/AccountEndpoints';
      delete $.AccountProperties.properties.managedResources['allOf'];
      $.AccountProperties.properties.managedResources['$ref'] = '#/definitions/ManagedResources';
      delete $.AccountProperties.properties.accountStatus['allOf'];
      $.AccountProperties.properties.accountStatus['$ref'] = '#/definitions/AccountStatus';
```
