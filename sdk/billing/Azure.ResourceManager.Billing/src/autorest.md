# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Billing
namespace: Azure.ResourceManager.Billing
require: https://github.com/Azure/azure-rest-api-specs/blob/6b08774c89877269e73e11ac3ecbd1bd4e14f5a0/specification/billing/resource-manager/readme.md
tag: package-2021-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  skipped-operations:
  - Assignments_CreateOrUpdate
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

request-path-to-resource-name:
  /providers/Microsoft.Billing/paymentMethods/{paymentMethodName}: BillingPaymentMethod
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

rename-mapping:
  NextBillingCycleDetails.billingFrequency: NextBillingCycleBillingFrequency
  BillingSubscriptionAlias.properties.billingSubscriptionId: -|arm-id
  AutoRenew: BillingSubscriptionAutoRenewState
  Amount: BillingAmount
  RenewalTermDetails: SubscriptionRenewalTermDetails
  Reseller: CreatedSubscriptionReseller
  MoveBillingSubscriptionRequest: BillingSubscriptionMoveContent
  MoveBillingSubscriptionRequest.destinationInvoiceSectionId: -|arm-id
  ValidateMoveBillingSubscriptionEligibilityResult: BillingSubscriptionValidateMoveEligibilityResult
  ValidateMoveBillingSubscriptionEligibilityError: BillingSubscriptionValidateMoveEligibilityError
  PaymentMethod: BillingPaymentMethod
  PaymentMethod.properties.type: PaymentMethodType
  PaymentMethodLink: BillingPaymentMethodLink
  PaymentMethodProjectionProperties.id: PaymentMethodId|arm-id

directive:
  - from: billingSubscription.json
    where: $.definitions
    transform: >
      $.BillingSubscriptionProperties.properties.billingProfileId['x-ms-format'] = 'arm-id';
      $.BillingSubscriptionProperties.properties.invoiceSectionId['x-ms-format'] = 'arm-id';
      $.BillingSubscriptionProperties.properties.termDuration['format'] = 'duration';
      $.BillingSubscriptionSplitRequest.properties.termDuration['format'] = 'duration';
      $.RenewalTermDetails.properties.termDuration['format'] = 'duration';

```
