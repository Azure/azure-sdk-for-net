# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Reservations
namespace: Azure.ResourceManager.Reservations
require: https://github.com/Azure/azure-rest-api-specs/blob/49b2b960e028825de1e3b95568c93ed235354e06/specification/reservations/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  "SessionId": "uuid"
  "DestinationTenantId": "uuid"
  "BillingScopeId": "arm-id"
  "SubRequestId": "uuid"

override-operation-name:
  Reservation_AvailableScopes: GetAvailableScopes
  CalculateExchange_Post: CalculateReservationExchange
  Exchange_Post: Exchange
  GetAppliedReservationList: GetAppliedReservations
  CalculateRefund_Post: CalculateRefund
  Return_Post: Return

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
  ReservationOrderResponse: ReservationOrder
  ReservationOrderResponse.properties.expiryDate: ExpireOn
  ProvisioningState: ReservationProvisioningState
  ReservationResponse: ReservationDetail
  ReservationsProperties: ReservationProperties
  AvailableScopeProperties: AvailableScopesProperties
  AvailableScopeRequest: AvailableScopesContent
  BillingPlan: SavingsPlanBillingPlan
  PurchaseRequest: ReservationPurchaseContent
  PurchaseRequest.properties.renew: IsRenewEnabled
  CalculatePriceResponse: CalculatePriceResult
  CalculatePriceResponseProperties: CalculatePriceResultProperties
  CalculateExchangeOperationResultResponse: CalculateExchangeResult
  CatalogMsrp: ReservationCatalogMsrp
  ExchangeOperationResultResponse: ExchangeResult
  AppliedReservations: AppliedReservationData
  CalculateExchangeRequestProperties: CalculateExchangeContentProperties
  CalculateExchangeResponseProperties: CalculateExchangeResultProperties
  CalculatePriceResponsePropertiesBillingCurrencyTotal: CalculatePriceResultPropertiesBillingCurrencyTotal
  CalculatePriceResponsePropertiesPricingCurrencyTotal: CalculatePriceResultPropertiesPricingCurrencyTotal
  ChangeDirectoryResponse: ChangeDirectoryDetail
  ExchangeResponseProperties: ExchangeResultProperties
  PaymentDetail.paymentDate: PayOn
  RenewPropertiesResponse: RenewProperties
  RenewPropertiesResponseBillingCurrencyTotal: RenewPropertiesBillingCurrencyTotal
  RenewPropertiesResponsePricingCurrencyTotal: RenewPropertiesPricingCurrencyTotal
  ReservationsProperties.archived: IsArchived
  ReservationsProperties.effectiveDateTime: EffectOn
  ReservationsProperties.expiryDate: ExpireOn
  ReservationsPropertiesUtilization:  ReservationPropertiesUtilization
  ScopeProperties.valid: IsValid
  SubRequest: SubContent
  OperationStatus: ReservationOperationStatus
  ResourceName: ReservationResourceName
  Patch.properties.renew: IsRenewEnabled
  CalculateRefundRequest: ReservationCalculateRefundContent
  CalculateRefundResponse: ReservationCalculateRefundResult
  CalculateRefundRequestProperties: ReservationCalculateRefundRequestProperties
  RefundResponse: ReservationRefundResult
  RefundBillingInformation: ReservationRefundBillingInformation
  RefundRequest: ReservationRefundContent
  RefundPolicyError: ReservationRefundPolicyError
  RefundPolicyResultProperty: ReservationRefundPolicyResultProperty
  RefundRequestProperties: ReservationRefundRequestProperties
  RefundResponseProperties: ReservationRefundResponseProperties
  ErrorResponseCode: ReservationErrorResponseCode
  CurrentQuotaLimitBase: ReservationQuotas
  ResourceType: ResourceTypeName
  QuotaProperties.name: ResourceName
  QuotaProperties.resourceType: ResourceTypeName
  QuotaRequestDetails.properties.value: QuotaRequestValue
  ChangeDirectoryResult.id: -|uuid
  ReservationsProperties.renew: IsRenewEnabled
  ReservationToExchange.reservationId: -|arm-id
  ReservationToPurchaseExchange.reservationOrderId: -|arm-id
  ReservationToPurchaseExchange.reservationId: -|arm-id
  ReservationToReturn.reservationId: -|arm-id
  ReservationToReturnForExchange.reservationId: -|arm-id
  SavingsPlanPurchaseRequest: SavingsPlanPurchase
  SplitRequest.properties.reservationId: -|arm-id
  CalculateExchangeOperationResultResponse.id: -|arm-id
  CalculatePriceResponseProperties.reservationOrderId: -|uuid
  AppliedScopeProperties.subscriptionId: -|arm-id
  AppliedScopeProperties.resourceGroupId: -|arm-id
  AppliedScopeProperties.managementGroupId: -|arm-id
  ExchangeOperationResultResponse.id: -|arm-id
  Price: PurchasePrice
  Catalog: ReservationCatalog
  Catalog.resourceType: AppliedResourceType
  Catalog.name: SkuName
  ReservationResponse.etag: Version
  Kind: ReservationKind
  ReservationOrderResponse.etag: Version
  Commitment: BenefitsCommitment
  CommitmentGrain: BenefitsCommitmentGrain

directive:
  - from: reservations.json
    where: $.definitions
    transform: >
      $.ExchangePolicyErrors.properties.policyErrors["x-nullable"] = true;
      $.PurchaseRequestProperties.properties.appliedScopes["x-nullable"] = true;
      delete $.Location;
      $.ReservationOrderProperties.properties.expiryDate['x-ms-client-name'] = 'ExpireOn';
      $.ReservationOrderProperties.properties.expiryDateTime['x-ms-client-name'] = 'ReservationExpireOn';
      $.ReservationsProperties.properties.expiryDate['x-ms-client-name'] = 'ExpireOn';
      $.ReservationsProperties.properties.expiryDateTime['x-ms-client-name'] = 'ReservationExpireOn';
      $.ReservationsProperties.properties.purchaseDate['x-ms-client-name'] = 'PurchaseOn';
      $.ReservationsProperties.properties.purchaseDateTime['x-ms-client-name'] = 'ReservationPurchaseOn';
  - from: reservations.json
    where: $.parameters
    transform: >
      $.ReservationIdParameter['format'] = 'uuid';
      $.ReservationOrderIdParameter['format'] = 'uuid';
  - from: quota.json
    where: $.parameters
    transform: >
      $.RequestIdInParameters['format'] = 'uuid';
  - remove-operation: Operation_List
```
