# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Billing
namespace: Azure.ResourceManager.Billing
require: https://github.com/Azure/azure-rest-api-specs/blob/7dc76b4edb665c8f9e0c7b7c0aaf2f34f8b25833/specification/billing/resource-manager/readme.md
#tag: package-2024-04
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - Assignments_CreateOrUpdate
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

# mgmt-debug:
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
  '*TenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'billingAccountId': 'arm-id'
  'billingProfileId': 'arm-id'
  'customerId': 'arm-id'
  'roleDefinitionId': 'arm-id'
  'billingRequestId': 'arm-id'
  'invoiceSectionId': 'arm-id'
  'paymentMethodId': 'arm-id'
  'destinationInvoiceSectionId': 'arm-id'
  'managementGroupId': 'arm-id'
  'resourceGroupId': 'arm-id'

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
  AutoRenew: BillingSubscriptionAutoRenewState
  Amount: BillingAmount
  AvailableBalance: BillingAvailableBalanceData
  AzurePlan: BillingAzurePlan
  BillingProfileProperties.invoiceEmailOptIn: IsInvoiceEmailOptIn
  BillingRelationshipType.CSPPartner: CspPartner
  BillingRelationshipType.CSPCustomer: CspCustomer
  BillingSubscription.properties.customerId: SubscriptionCustomerId
  BillingSubscription.properties.beneficiaryTenantId: SubscriptionBeneficiaryTenantId
  BillingSubscriptionAlias.properties.billingSubscriptionId: SubscriptionAliasSubscriptionId
  BillingSubscriptionAlias.properties.customerId: SubscriptionAliasCustomerId
  BillingSubscriptionAlias.properties.beneficiaryTenantId: SubscriptionAliasBeneficiaryTenantId
  Cancellation: PolicyOverrideCancellation
  CancellationReason: CustomerSubscriptionCancellationReason
  Category: BillingAgreementCategory
  CheckAccessRequest: BillingCheckAccessContent
  CheckAccessResponse: BillingCheckAccessResult
  Commitment: BillingBenefitCommitment
  CommitmentGrain: BillingBenefitCommitmentGrain
  CreditType: BillingTransactionCreditType
  CustomerStatus: BillingCustomerStatus
  DocumentDownloadRequest: BillingDocumentDownloadRequestContent
  DocumentDownloadResult: BillingDocumentDownloadResult
  DocumentDownloadResult.expiryTime: ExpireOn|date-time
  DocumentSource: BillingDocumentSource
  DocumentSource.DRS: Drs
  DocumentSource.ENF: Enf
  EnrollmentDetails: BillingAccountEnrollmentDetails
  FailedPayment: BillingInvoiceFailedPayment
  FailedPaymentReason: BillingInvoiceFailedPaymentReason
  MarkupStatus: EnrollmentMarkupStatus
  MoveBillingSubscriptionRequest: BillingSubscriptionMoveContent
  MoveBillingSubscriptionEligibilityResult: BillingSubscriptionValidateMoveEligibilityResult
  MoveBillingSubscriptionErrorDetails: BillingSubscriptionValidateMoveEligibilityError
  MoveProductRequest: MoveProductContent
  NextBillingCycleDetails.billingFrequency: NextBillingCycleBillingFrequency
  Participant: BillingAgreementParticipant
  RenewalTermDetails: SubscriptionRenewalTermDetails
  Reseller: CreatedSubscriptionReseller
  Reservation.properties.expiryDate: ExpireOn|date-time
  Reservation.properties.expiryDateTime: ReservationExpireOn
  Reservation.properties.purchaseDate: PurchaseOn
  Reservation.properties.purchaseDateTime: ReservationPurchaseOn
  Reservation.properties.archived: IsArchived
  Reservation.properties.renew: IsRenewed
  ReservationOrder.properties.expiryDate: ExpireOn
  ReservationOrder.properties.expiryDateTime: ReservationExpireOn
  ReservationOrder.properties.reviewDateTime: ReviewedOn
  ReservationPurchaseRequest.properties.renew: IsRenewed
  Payment: BillingInvoicePayment
  Payment.date: MadeOn
  PaymentDetail: BillingPlanPaymentDetail
  PaymentDetail.paymentDate: PaymentCompletedOn
  PaymentMethod.properties.id: PaymentMethodId|arm-id
  PaymentMethodProperties.id: PaymentMethodId|arm-id
  PaymentMethodProperties: PaymentMethodProjectionProperties
  PaymentOnAccount.invoiceId: -|arm-id
  Patch.properties.renew: IsRenewed
  PurchaseRequest: BillingPurchaseProperties
  PurchaseRequest.properties.renew: IsRenewed
  RebillDetails.invoiceDocumentId: -|arm-id
  RebillDetails.creditNoteDocumentId: -|arm-id
  RefundDetailsSummary.rebillInvoiceId: -|arm-id
  RegistrationNumber.required: IsRequired
  RenewPropertiesResponse: ReservationRenewProperties
  SavingsPlanModel: BillingSavingsPlanModel
  SavingsPlanModel.properties.renew: IsRenewed
  SavingsPlanUpdateRequestProperties.renew: IsRenewed
  SavingsPlanValidateResponse: SavingsPlanValidateResult
  SavingsPlanValidResponseProperty.valid: IsValid
  SupportLevel: BillingEnrollmentSupportLevel
  Transaction: BillingTransactionData
  TransactionProperties.invoiceId: -|arm-id
  TransferStatus: PartnerTransferStatus
  Utilization: SavingsPlanUtilization
  UtilizationAggregates: SavingsPlanUtilizationAggregates
  ValidateTransferResponse: BillingTransferValidationResult
  ValidationResultProperties: BillingTransferValidationResultProperties

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
  - InvoiceStatus
  - InvoiceType
  - PaymentMethod
  - PaymentMethodLink
  - PaymentOnAccount
  - PaymentStatus
  - PaymentTerm
  - PolicySummary
  - PolicyType
  - Price
  - Principal
  - PrincipalType
  - ProvisioningState
  - Product
  - ProductProperties
  - ProductDetails
  - ProductStatus
  - ProductTransferStatus
  - ProductType
  - ProvisioningTenantState
  - RenewProperties
  - Reservation
  - ReservationOrder
  - RegistrationNumber
  - SavingsPlanTerm
  - SpendingLimit
  - SupportedAccountType
  - SystemOverrides
  - TaxIdentifier
  - TaxIdentifierType
  - TaxIdentifierStatus
  - TransactionKind
  - TransactionProperties
  - TransactionSummary
  - TransferDetails
  - TransferError
  - TransferStatus
  - TransitionDetails

directive:
  - from: billingSubscription.json
    where: $.definitions
    transform: >
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
      delete $.BillingProfilePolicyProperties.properties.enterpriseAgreementPolicies.allOf;
      $.BillingProfilePolicyProperties.properties.enterpriseAgreementPolicies['$ref'] = '#/definitions/EnterpriseAgreementPolicies';
  - from: billingAccount.json
    where: $.definitions
    transform: >
      delete $.BillingAccountProperties.properties.enrollmentDetails.allOf;
      $.BillingAccountProperties.properties.enrollmentDetails['$ref'] = '#/definitions/EnrollmentDetails';
      delete $.BillingAccountProperties.properties.soldTo.allOf;
      $.BillingAccountProperties.properties.soldTo['$ref'] = './types.json#/definitions/AddressDetails';
      delete $.BillingAccountProperties.properties.registrationNumber.allOf;
      $.BillingAccountProperties.properties.registrationNumber['$ref'] = '#/definitions/RegistrationNumber';
  - from: billingProfile.json
    where: $.definitions
    transform: >
      delete $.BillingProfileProperties.properties.billTo.allOf;
      $.BillingProfileProperties.properties.billTo['$ref'] = './types.json#/definitions/AddressDetails';
      delete $.BillingProfileProperties.properties.indirectRelationshipInfo.allOf;
      $.BillingProfileProperties.properties.indirectRelationshipInfo['$ref'] = './types.json#/definitions/IndirectRelationshipInfo';
      delete $.BillingProfileProperties.properties.shipTo.allOf;
      $.BillingProfileProperties.properties.shipTo['$ref'] = './types.json#/definitions/AddressDetails';
      delete $.BillingProfileProperties.properties.soldTo.allOf;
      $.BillingProfileProperties.properties.soldTo['$ref'] = './types.json#/definitions/AddressDetails';
      delete $.BillingProfileProperties.properties.currentPaymentTerm.allOf;
      $.BillingProfileProperties.properties.currentPaymentTerm['$ref'] = '#/definitions/PaymentTerm';
  - from: billingProperty.json
    where: $.definitions
    transform: >
      delete $.BillingPropertyProperties.properties.subscriptionServiceUsageAddress.allOf;
      $.BillingPropertyProperties.properties.subscriptionServiceUsageAddress['$ref'] = './types.json#/definitions/AddressDetails';
      delete $.BillingPropertyProperties.properties.enrollmentDetails.allOf;
      $.BillingPropertyProperties.properties.enrollmentDetails['$ref'] = '#/definitions/SubscriptionEnrollmentDetails';
  - from: billingRequest.json
    where: $.definitions
    transform: >
      delete $.BillingRequestProperties.properties.reviewedBy.allOf;
      $.BillingRequestProperties.properties.reviewedBy['$ref'] = '#/definitions/Principal';
      delete $.BillingRequestProperties.properties.createdBy.allOf;
      $.BillingRequestProperties.properties.createdBy['$ref'] = '#/definitions/Principal';
      delete $.BillingRequestProperties.properties.lastUpdatedBy.allOf;
      $.BillingRequestProperties.properties.lastUpdatedBy['$ref'] = '#/definitions/Principal';
  - from: billingAccount.json
    where: $.definitions
    transform: >
      delete $.EnrollmentDetails.properties.indirectRelationshipInfo.allOf;
      $.EnrollmentDetails.properties.indirectRelationshipInfo['$ref'] = './types.json#/definitions/IndirectRelationshipInfo';
  - from: invoice.json
    where: $.definitions
    transform: >
      delete $.InvoiceProperties.properties.amountDue.allOf;
      $.InvoiceProperties.properties.amountDue['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.azurePrepaymentApplied.allOf;
      $.InvoiceProperties.properties.azurePrepaymentApplied['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.billedAmount.allOf;
      $.InvoiceProperties.properties.billedAmount['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.creditAmount.allOf;
      $.InvoiceProperties.properties.creditAmount['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.freeAzureCreditApplied.allOf;
      $.InvoiceProperties.properties.freeAzureCreditApplied['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.rebillDetails.allOf;
      $.InvoiceProperties.properties.rebillDetails['$ref'] = '#/definitions/RebillDetails';
      delete $.InvoiceProperties.properties.subTotal.allOf;
      $.InvoiceProperties.properties.subTotal['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.taxAmount.allOf;
      $.InvoiceProperties.properties.taxAmount['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.totalAmount.allOf;
      $.InvoiceProperties.properties.totalAmount['$ref'] = './types.json#/definitions/Amount';
      delete $.InvoiceProperties.properties.refundDetails.allOf;
      $.InvoiceProperties.properties.refundDetails['$ref'] = '#/definitions/RefundDetailsSummary';
      delete $.Payment.properties.amount.allOf;
      $.Payment.properties.amount['$ref'] = './types.json#/definitions/Amount';
      delete $.RefundDetailsSummary.properties.amountRequested.allOf;
      $.RefundDetailsSummary.properties.amountRequested['$ref'] = './types.json#/definitions/Amount';
      delete $.RefundDetailsSummary.properties.amountRefunded.allOf;
      $.RefundDetailsSummary.properties.amountRefunded['$ref'] = './types.json#/definitions/Amount';
  - from: product.json
    where: $.definitions
    transform: >
      delete $.MoveProductEligibilityResult.properties.errorDetails.allOf;
      $.MoveProductEligibilityResult.properties.errorDetails['$ref'] = '#/definitions/MoveProductErrorDetails';
      delete $.ProductProperties.properties.lastCharge.allOf;
      $.ProductProperties.properties.lastCharge['$ref'] = './types.json#/definitions/Amount';
      delete $.ProductProperties.properties.reseller.allOf;
      $.ProductProperties.properties.reseller['$ref'] = './types.json#/definitions/Amount';
  - from: availableBalance.json
    where: $.definitions
    transform: >
      delete $.PaymentOnAccount.properties.amount.allOf;
      $.PaymentOnAccount.properties.amount['$ref'] = './types.json#/definitions/Reseller';
  - from: transaction.json
    where: $.definitions
    transform: >
      delete $.RefundTransactionDetails.properties.amountRequested.allOf;
      $.RefundTransactionDetails.properties.amountRequested['$ref'] = './types.json#/definitions/Amount';
      delete $.RefundTransactionDetails.properties.amountRefunded.allOf;
      $.RefundTransactionDetails.properties.amountRefunded['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.azureCreditApplied.allOf;
      $.TransactionProperties.properties.azureCreditApplied['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.consumptionCommitmentDecremented.allOf;
      $.TransactionProperties.properties.consumptionCommitmentDecremented['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.effectivePrice.allOf;
      $.TransactionProperties.properties.effectivePrice['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.marketPrice.allOf;
      $.TransactionProperties.properties.marketPrice['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.subTotal.allOf;
      $.TransactionProperties.properties.subTotal['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.tax.allOf;
      $.TransactionProperties.properties.tax['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.transactionAmount.allOf;
      $.TransactionProperties.properties.transactionAmount['$ref'] = './types.json#/definitions/Amount';
      delete $.TransactionProperties.properties.refundTransactionDetails.allOf;
      $.TransactionProperties.properties.refundTransactionDetails['$ref'] = '#/definitions/RefundTransactionDetails';

```
