# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Subscription
namespace: Azure.ResourceManager.Subscription
require: https://github.com/Azure/azure-rest-api-specs/blob/2614c5038cb384e864c1608e76be61a5ee84cb02/specification/subscription/resource-manager/readme.md
#tag: package-2021-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

list-exception:
  - /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/providers/Microsoft.Subscription/policies/default

override-operation-name:
  Subscription_AcceptOwnershipStatus: GetAcceptOwnershipStatus
  Subscription_AcceptOwnership: AcceptSubscriptionOwnership

rename-mapping:
  AcceptOwnershipStatusResponse.subscriptionTenantId: -|uuid
  PutAliasRequestAdditionalProperties.subscriptionTenantId: -|uuid
  SubscriptionAliasResponseProperties.createdTime: CreatedOn|date-time
  AcceptOwnership: AcceptOwnershipState
  AcceptOwnershipStatusResponse: AcceptOwnershipStatus
  BillingAccountPoliciesResponse: BillingAccountPolicy
  BillingAccountPoliciesResponseProperties: BillingAccountPolicyProperties
  TenantPolicy: TenantPolicyProperties
  GetTenantPolicyResponse: TenantPolicy
  GetTenantPolicyListResponse: TenantPoliciesResult
  Provisioning: AcceptOwnershipProvisioningState
  ProvisioningState: SubscriptionProvisioningState
  PutAliasRequestAdditionalProperties: SubscriptionAliasAdditionalProperties
  SubscriptionAliasResponse: SubscriptionAlias
  SubscriptionAliasResponseProperties: SubscriptionAliasProperties
  ServiceTenantResponse: ServiceTenant
  Workload: SubscriptionWorkload

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

directive:
  # Exists on ArmResource as GetAvailableLocationsGetSubscription
  - remove-operation: 'Subscriptions_ListLocations'
  # Exists on ArmResource as GetSubscription
  - remove-operation: 'Subscriptions_Get'
  # Exists on ArmResource as GetSubscriptions
  - remove-operation: 'Subscriptions_List'
  # Exists on ArmResource as GetTenants
  - remove-operation: 'Tenants_List'
  - from: swagger-document
    where: $.definitions.PutAliasRequest
    transform: >
      $.properties.properties['x-ms-client-flatten'] = true;
```
