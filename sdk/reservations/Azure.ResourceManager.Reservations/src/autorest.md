# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
generate-model-factory: false
csharp: true
library-name: Reservations
namespace: Azure.ResourceManager.Reservations
require: https://github.com/Azure/azure-rest-api-specs/blob/a207ec1754c20e5d601c08274bc33d40167968c2/specification/reservations/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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
  PurchaseRequest: ReservationPurchaseContent
  PurchaseRequest.properties.renew: IsRenewEnabled
  CalculatePriceResponse: CalculatePriceResult
  CalculatePriceResponseProperties: CalculatePriceResultProperties
  CalculateExchangeOperationResultResponse: CalculateExchangeResult
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

directive:
  - from: quota.json
    where: $.definitions
    transform: >
      $.QuotaRequestProperties.properties.value['x-ms-client-name'] = 'QuotaRequestValue';
      $.ResourceTypesName['x-ms-enum']['name'] = 'ResourceTypeName';
      $.QuotaProperties.properties.name['x-ms-client-name'] = 'ResourceName';
      $.QuotaProperties.properties.resourceType['x-ms-client-name'] = 'ResourceTypeName';
      $.CurrentQuotaLimitBase['x-ms-client-name'] = 'ReservationQuotas';
  - from: reservations.json
    where: $.definitions
    transform: >
      $.ReservationOrderProperties.properties.expiryDate['x-ms-client-name'] = 'ExpireOn';
      $.ReservationOrderProperties.properties.expiryDateTime['x-ms-client-name'] = 'ReservationExpireOn';
      $.ReservationsProperties.properties.expiryDate['x-ms-client-name'] = 'ExpireOn';
      $.ReservationsProperties.properties.expiryDateTime['x-ms-client-name'] = 'ReservationExpireOn';
      $.ReservationsProperties.properties.purchaseDate['x-ms-client-name'] = 'PurchaseOn';
      $.ReservationsProperties.properties.purchaseDateTime['x-ms-client-name'] = 'ReservationPurchaseOn';
      delete $.Location;
      $.ReservationResponse.properties.etag['x-ms-client-name'] = 'version';
      $.ReservationResponse.properties.kind['x-ms-enum'].name = 'ReservationKind';
      $.ReservationOrderResponse.properties.etag['x-ms-client-name'] = 'version';
      $.Price['x-ms-client-name'] = 'PurchasePrice';
      $.Catalog.properties.resourceType['x-ms-client-name'] = 'AppliedResourceType';
      $.Catalog.properties.name['x-ms-client-name'] = 'SkuName';
      $.Catalog['x-ms-client-name'] = 'ReservationCatalog';
      $.CalculateExchangeOperationResultResponse.properties.id['x-ms-format'] = 'arm-id';
      $.ExchangeOperationResultResponse.properties.id['x-ms-format'] = 'arm-id';
      $.CalculatePriceResponseProperties.properties.reservationOrderId['format'] = 'uuid';
      $.ChangeDirectoryResult.properties.id['format'] = 'uuid';
      $.ReservationToExchange.properties.reservationId['x-ms-format'] = 'arm-id';
      $.ReservationToPurchaseExchange.properties.reservationId['x-ms-format'] = 'arm-id';
      $.ReservationToPurchaseExchange.properties.reservationOrderId['x-ms-format'] = 'arm-id';
      $.ReservationToReturnForExchange.properties.reservationId['x-ms-format'] = 'arm-id';
      $.SplitProperties.properties.reservationId['x-ms-format'] = 'arm-id';
      $.ReservationsProperties.properties.renew['x-ms-client-name'] = 'IsRenewEnabled';
      $.ReservationToReturn.properties.reservationId['x-ms-format'] = 'arm-id';
      $.ExchangePolicyErrors.properties.policyErrors["x-nullable"] = true;
      $.PurchaseRequestProperties.properties.appliedScopes["x-nullable"] = true;
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
