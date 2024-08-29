# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Billing
namespace: Azure.ResourceManager.Billing
require: https://github.com/Azure/azure-rest-api-specs/blob/7dc76b4edb665c8f9e0c7b7c0aaf2f34f8b25833/specification/billing/resource-manager/readme.md
tag: package-2024-04
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

#mgmt-debug: 
#  show-serialized-names: true

request-path-to-resource-name:
  /providers/Microsoft.Billing/paymentMethods/{paymentMethodName}: BillingPaymentMethod
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptions/{billingSubscriptionName}: BillingSubscription
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/billingSubscriptions/{billingSubscriptionName}: BillingProfileSubscription
  /providers/Microsoft.Billing/billingAccounts/default/billingSubscriptions/{subscriptionId}/invoices/{invoiceName}: SubscriptionBillingInvoice
  /providers/Microsoft.Billing/billingAccounts/default/invoices/{invoiceName}: DefaultBillingInvoice
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/invoices/{invoiceName}: BillingInvoice
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/billingRoleAssignments/{billingRoleAssignmentName}: BillingProfileRoleAssignment
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/billingRoleAssignments/{billingRoleAssignmentName}: BillingCustomerRoleAssignment
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}/billingRoleAssignments/{billingRoleAssignmentName}: BillingInvoiceSectionRoleAssignment
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingRoleAssignments/{billingRoleAssignmentName}: BillingRoleAssignment
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/departments/{departmentName}/billingRoleAssignments/{billingRoleAssignmentName}: BillingDepartmentRoleAssignment
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/enrollmentAccounts/{enrollmentAccountName}/billingRoleAssignments/{billingRoleAssignmentName}: BillingEnrollmentAccountRoleAssignment
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/billingRoleDefinitions/{roleDefinitionName}: BillingProfileRoleDefinition
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/billingRoleDefinitions/{roleDefinitionName}: BillingCustomerRoleDefinition
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}/billingRoleDefinitions/{roleDefinitionName}: BillingInvoiceSectionRoleDefinition
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingRoleDefinitions/{roleDefinitionName}: BillingRoleDefinition
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/departments/{departmentName}/billingRoleDefinitions/{roleDefinitionName}: BillingDepartmentRoleDefinition
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/enrollmentAccounts/{enrollmentAccountName}/billingRoleDefinitions/{roleDefinitionName}: BillingEnrollmentAccountRoleDefinition
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/customers/{customerName}: BillingCustomer
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}: BillingProfileCustomer
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/customers/{customerName}/policies/default: BillingCustomerPolicy
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/customers/{customerName}/policies/{policyName}: BillingProfileCustomerPolicy
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/enrollmentAccounts/{enrollmentAccountName}: BillingEnrollmentAccount
  /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/departments/{departmentName}/enrollmentAccounts/{enrollmentAccountName}: BillingDepartmentEnrollmentAccount

request-path-is-non-resource:
  - /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/availableBalance/default
  - /providers/Microsoft.Billing/billingAccounts/{billingAccountName}/availableBalance/default

override-operation-name:
  AvailableBalances_GetByBillingAccount: GetBillingAccountAvailableBalance
  AvailableBalances_GetByBillingProfile: GetBillingProfileAvailableBalance

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
  AcceptanceMode: AgreementAcceptanceMode
  AcceptTransferRequest: AcceptTransferContent
  AccessDecision: BillingProfileAccessDecision
  AddressValidationResponse: BillingAddressValidationResult
  AppliedScopeProperties.managementGroupId: -|arm-id
  AppliedScopeProperties.resourceGroupId: -|arm-id
  AutoRenew: BillingSubscriptionAutoRenewState
  Amount: BillingAmount
  AzurePlan: BillingAzurePlan
  BillingSubscriptionAlias.properties.billingSubscriptionId: -|arm-id
  BillingSubscriptionAlias.properties.provisioningTenantId: -|uuid
  Commitment: BillingBenefitCommitment
  InvoiceProperties.billingProfileId: -|arm-id
  MoveBillingSubscriptionRequest: BillingSubscriptionMoveContent
  MoveBillingSubscriptionRequest.destinationInvoiceSectionId: -|arm-id
  MoveBillingSubscriptionEligibilityResult: BillingSubscriptionValidateMoveEligibilityResult
  MoveBillingSubscriptionErrorDetails: BillingSubscriptionValidateMoveEligibilityError
  NextBillingCycleDetails.billingFrequency: NextBillingCycleBillingFrequency
  RenewalTermDetails: SubscriptionRenewalTermDetails
  Reseller: CreatedSubscriptionReseller
  Reservation.properties.expiryDate: ExpireOn|date-time
  Reservation.properties.expiryDateTime: ReservationExpireOn
  Reservation.properties.purchaseDate: PurchaseOn
  Reservation.properties.purchaseDateTime: ReservationPurchaseOn
  Reservation.properties.archived: IsArchived
  Reservation.properties.renew: IsRenewed
  ReservationOrder.properties.customerId: -|arm-id
  ReservationOrder.properties.billingProfileId: -|arm-id
  ReservationOrder.properties.billingAccountId: -|arm-id
  ReservationOrder.properties.expiryDate: ExpireOn
  ReservationOrder.properties.expiryDateTime: ReservationExpireOn
  ReservationOrder.properties.reviewDateTime: ReviewedOn
  AvailableBalance: BillingAvailableBalanceData
  PaymentMethod.properties.id: PaymentMethodId
  PaymentMethodLink.properties.paymentMethodId: -|arm-id
  PaymentMethodProperties.id: PaymentMethodId|arm-id
  PaymentMethodProperties: PaymentMethodProjectionProperties
  PurchaseRequest: BillingPurchaseProperties
  TransferStatus: PartnerTransferStatus
  SavingsPlanModel: BillingSavingsPlanModel
  SavingsPlanModel.properties.billingProfileId: -|arm-id
  SavingsPlanModel.properties.customerId: -|arm-id
  SavingsPlanModel.properties.billingAccountId: -|arm-id
  SavingsPlanModel.properties.renew: IsRenewed
  Utilization: SavingsPlanUtilization

prepend-rp-prefix:
  - AccountStatus
  - AccountSubType
  - AccountType
  - AddressDetails
  - AddressValidationStatus
  - AgreementType
  - Agreement
  - AgreementProperties
  - AppliedScopeProperties
  - AppliedScopeType
  - AssociatedTenant
  - AssociatedTenantProperties
  - AvailableBalanceProperties
  - Beneficiary
  - Customer
  - CustomerProperties
  - CustomerPolicy
  - CustomerPolicyProperties
  - Department
  - DepartmentProperties
  - EnrollmentAccount
  - EnrollmentAccountProperties
  - Invoice
  - InvoiceProperties
  - InvoiceSection
  - InvoiceSectionProperties
  - PaymentMethod
  - PaymentMethodFamily
  - PaymentMethodLink
  - PaymentMethodStatus
  - Price
  - ProvisioningState
  - Product
  - ProductProperties
  - RenewProperties
  - Reservation
  - ReservationOrder
  - SavingsPlanTerm
  - SystemOverrides
  - TransferDetails

directive:
  - from: billingSubscription.json
    where: $.definitions
    transform: >
      $.BillingSubscriptionProperties.properties.billingProfileId['x-ms-format'] = 'arm-id';
      $.BillingSubscriptionProperties.properties.invoiceSectionId['x-ms-format'] = 'arm-id';
      $.BillingSubscriptionProperties.properties.termDuration['format'] = 'duration';
      $.BillingSubscriptionSplitRequest.properties.termDuration['format'] = 'duration';
      $.RenewalTermDetails.properties.termDuration['format'] = 'duration';
  - from: availableBalance.json
    where: $.definitions
    transform: >
      delete $.AvailableBalanceProperties.properties.amount.allOf;
      $.AvailableBalanceProperties.properties.amount['$ref'] = './types.json#/definitions/Amount';
      delete $.AvailableBalanceProperties.properties.totalPaymentsOnAccount.allOf;
      $.AvailableBalanceProperties.properties.totalPaymentsOnAccount['$ref'] = './types.json#/definitions/Amount';
  - from: policy.json
    where: $.definitions
    transform: >
      delete $.BillingAccountPolicyProperties.properties.enterpriseAgreementPolicies.allOf;
      $.BillingAccountPolicyProperties.properties.enterpriseAgreementPolicies['$ref'] = '#/definitions/EnterpriseAgreementPolicies';
  - from: billingAccount.json
    where: $.definitions
    transform: >
      delete $.BillingAccountProperties.properties.enrollmentDetails.allOf;
      $.BillingAccountProperties.properties.enrollmentDetails['$ref'] = '#/definitions/EnrollmentDetails';
      delete $.BillingAccountProperties.properties.soldTo.allOf;
      $.BillingAccountProperties.properties.soldTo['$ref'] = './types.json#/definitions/AddressDetails';
      delete $.BillingAccountProperties.properties.registrationNumber.allOf;
      $.BillingAccountProperties.properties.registrationNumber['$ref'] = '#/definitions/RegistrationNumber';

```
