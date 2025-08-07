# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: BillingBenefits
namespace: Azure.ResourceManager.BillingBenefits
require: https://github.com/Azure/azure-rest-api-specs/blob/bab95d5636c7d47cc5584ea8dadb21199d229ca7/specification/billingbenefits/resource-manager/readme.md
tag: package-2022-11-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
list-exception:
- /providers/Microsoft.BillingBenefits/savingsPlanOrderAliases/{savingsPlanOrderAliasName}
- /providers/Microsoft.BillingBenefits/reservationOrderAliases/{reservationOrderAliasName}

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
  AVS: Avs
  Db: DB

rename-mapping:
  ReservationOrderAliasResponse: BillingBenefitsReservationOrderAlias
  ReservationOrderAliasResponse.properties.billingScopeId: -|arm-id
  ReservationOrderAliasResponse.properties.reservationOrderId: -|arm-id
  ReservationOrderAliasResponse.properties.renew: IsRenewed
  ReservationOrderAliasRequest.properties.billingScopeId: -|arm-id
  ReservationOrderAliasRequest.properties.renew: IsRenewed
  AppliedScopeProperties: BillingBenefitsAppliedScopeProperties
  AppliedScopeProperties.managementGroupId: -|arm-id
  AppliedScopeProperties.subscriptionId: -|arm-id
  AppliedScopeProperties.resourceGroupId: -|arm-id
  AppliedScopeType: BillingBenefitsAppliedScopeType
  BillingPlan: BillingBenefitsBillingPlan
  ProvisioningState: BillingBenefitsProvisioningState
  InstanceFlexibility: BillingBenefitsInstanceFlexibility
  ReservedResourceType: BillingBenefitsReservedResourceType
  Term: BillingBenefitsTerm
  SavingsPlanModel: BillingBenefitsSavingsPlan
  SavingsPlanModel.properties.billingAccountId: -|arm-id
  SavingsPlanModel.properties.billingProfileId: -|arm-id
  SavingsPlanModel.properties.billingScopeId: -|arm-id
  SavingsPlanModel.properties.effectiveDateTime: EffectOn
  SavingsPlanModel.properties.expiryDateTime: ExpireOn
  SavingsPlanModel.properties.renew: IsRenewed
  Commitment: BillingBenefitsCommitment
  CommitmentGrain: BillingBenefitsCommitmentGrain
  ExtendedStatusInfo: BillingBenefitsExtendedStatusInfo
  Utilization: BillingBenefitsSavingsPlanUtilization
  UtilizationAggregates: BillingBenefitsSavingsPlanUtilizationAggregate
  PurchaseRequest: BillingBenefitsPurchaseContent
  PurchaseRequest.properties.billingScopeId: -|arm-id
  PurchaseRequest.properties.effectiveDateTime: EffectOn
  PurchaseRequest.properties.renew: IsRenewed
  SavingsPlanValidResponseProperty: SavingsPlanValidateResult
  SavingsPlanValidResponseProperty.valid: IsValid
  SavingsPlanOrderAliasModel: BillingBenefitsSavingsPlanOrderAlias
  SavingsPlanOrderAliasModel.properties.billingScopeId: -|arm-id
  SavingsPlanOrderAliasModel.properties.savingsPlanOrderId: -|arm-id
  SavingsPlanOrderModel: BillingBenefitsSavingsPlanOrder
  SavingsPlanOrderModel.properties.BillingAccountId: -|arm-id
  SavingsPlanOrderModel.properties.billingProfileId: -|arm-id
  SavingsPlanOrderModel.properties.expiryDateTime: ExpireOn
  RoleAssignmentEntity: BillingBenefitsRoleAssignmentEntity
  RoleAssignmentEntity.id: -|arm-id
  RoleAssignmentEntity.properties.roleDefinitionId: -|arm-id
  RoleAssignmentEntity.properties.scope: -|arm-id
  Price: BillingBenefitsPrice
  PaymentDetail: SavingsPlanOrderPaymentDetail
  PaymentDetail.paymentDate: PayOn
  PaymentStatus: BillingBenefitsPaymentStatus
  SavingsPlanUpdateRequestProperties: BillingBenefitsSavingsPlanPatchProperties
  SavingsPlanUpdateRequestProperties.renew: IsRenewed

directive:
  - from: billingbenefits.json
    where: $.parameters
    transform: >
      $.ExpandParameter['x-ms-parameter-location'] = 'method';
  - from: billingbenefits.json
    where: $.paths
    transform: >
      $['/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}/savingsPlans/{savingsPlanId}/validate'].post['x-ms-pageable'] = {
          'nextLinkName': 'nextLink',
          'itemName': 'benefits'
      };
      $['/providers/Microsoft.BillingBenefits/validate'].post['x-ms-pageable'] = {
          'nextLinkName': 'nextLink',
          'itemName': 'benefits'
      };
      $['/providers/Microsoft.BillingBenefits/savingsPlans'].get.parameters[2]['x-ms-client-name'] = 'orderBy';
      $['/providers/Microsoft.BillingBenefits/savingsPlans'].get.parameters[4]['x-ms-client-name'] = 'skipToken';
  - remove-operation: Operation_List

models-to-treat-empty-string-as-null:
  - BillingBenefitsAppliedScopeProperties
```
