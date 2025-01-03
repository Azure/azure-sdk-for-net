// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmBillingModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.PaymentMethodProjectionProperties"/>. </summary>
        /// <param name="paymentMethodId"> Id of payment method. </param>
        /// <param name="family"> The family of payment method. </param>
        /// <param name="paymentMethodProjectionPropertiesType"> The type of payment method. </param>
        /// <param name="accountHolderName"> The account holder name for the payment method. This is only supported for payment methods with family CreditCard. </param>
        /// <param name="expiration"> The expiration month and year of the payment method. This is only supported for payment methods with family CreditCard. </param>
        /// <param name="lastFourDigits"> Last four digits of payment method. </param>
        /// <param name="displayName"> The display name of the payment method. </param>
        /// <param name="logos"> The list of logos for the payment method. </param>
        /// <param name="status"> Status of the payment method. </param>
        /// <returns> A new <see cref="Models.PaymentMethodProjectionProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PaymentMethodProjectionProperties PaymentMethodProjectionProperties(ResourceIdentifier paymentMethodId, PaymentMethodFamily? family, string paymentMethodProjectionPropertiesType, string accountHolderName, string expiration, string lastFourDigits, string displayName, IEnumerable<PaymentMethodLogo> logos, PaymentMethodStatus? status)
            => PaymentMethodProjectionProperties(paymentMethodId, accountHolderName, displayName, expiration, family, lastFourDigits, logos, paymentMethodProjectionPropertiesType, status);

        /// <summary> Initializes a new instance of <see cref="Billing.BillingSubscriptionAliasData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="autoRenew"> Indicates whether auto renewal is turned on or off for a subscription. </param>
        /// <param name="beneficiaryTenantId"> The provisioning tenant of the subscription. </param>
        /// <param name="billingFrequency"> The billing frequency of the subscription in the ISO8601 format. Example: P1M, P3M, P1Y. </param>
        /// <param name="billingProfileId"> The ID of the billing profile to which the subscription is billed. This field is only applicable for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="billingPolicies"> Dictionary of billing policies associated with the subscription. </param>
        /// <param name="billingProfileDisplayName"> The display name of the billing profile to which the subscription is billed. This field is only applicable for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="billingProfileName"> The name of the billing profile to which the subscription is billed. This field is only applicable for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="consumptionCostCenter"> The cost center applied to the subscription. This field is only available for consumption subscriptions of Microsoft Customer Agreement Type billing accounts. </param>
        /// <param name="customerId"> The ID of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="customerDisplayName"> The name of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="displayName"> The name of the subscription. </param>
        /// <param name="enrollmentAccountId"> The enrollment Account ID associated with the subscription. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <param name="enrollmentAccountDisplayName"> The enrollment Account name associated with the subscription. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <param name="invoiceSectionId"> The ID of the invoice section to which the subscription is billed. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="invoiceSectionDisplayName"> The display name of the invoice section to which the subscription is billed. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="invoiceSectionName"> The name of the invoice section to which the subscription is billed. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="lastMonthCharges"> The last month's charges. This field is only available for usage based subscriptions of Microsoft Customer Agreement billing accounts. </param>
        /// <param name="monthToDateCharges"> The current month to date charges. This field is only available for usage based subscriptions of Microsoft Customer Agreement billing accounts. </param>
        /// <param name="nextBillingCycleBillingFrequency"> Next billing cycle details of the subscription. </param>
        /// <param name="offerId"> The offer ID for the subscription. This field is only available for the Microsoft Online Services Program billing accounts. </param>
        /// <param name="productCategory"> The category of the product for which the subscription is purchased. Possible values include: AzureSupport, Hardware, ReservationOrder, SaaS, SavingsPlanOrder, Software, UsageBased, Other. </param>
        /// <param name="productType"> The type of the product for which the subscription is purchased. </param>
        /// <param name="productTypeId"> The ID of the product for which the subscription is purchased. </param>
        /// <param name="purchaseOn"> The purchase date of the subscription in UTC time. </param>
        /// <param name="quantity"> The number of licenses purchased for the subscription. </param>
        /// <param name="reseller"> The reseller for which the subscription is created. The field is available for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="renewalTermDetails"> The term details of the subscription at the next renewal. </param>
        /// <param name="skuDescription"> The SKU description of the product for which the subscription is purchased. This field is only available for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="skuId"> The SKU ID of the product for which the subscription is purchased. This field is only available for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="status"> The status of the subscription. This field is not available for Enterprise Agreement billing accounts. </param>
        /// <param name="subscriptionId"> The ID of the usage-based subscription. This field is only available for usage-based subscriptions of Microsoft Customer Agreement billing accounts. </param>
        /// <param name="suspensionReasons"> The suspension reason for the subscription. This field is not available for Enterprise Agreement billing accounts. </param>
        /// <param name="termDuration"> The duration for which you can use the subscription. Example P1Y and P1M. </param>
        /// <param name="termStartOn"> The start date of the term in UTC time. </param>
        /// <param name="termEndOn"> The end date of the term in UTC time. </param>
        /// <param name="subscriptionEnrollmentAccountStatus"> The current enrollment account status of the subscription. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <param name="enrollmentAccountStartOn"> The enrollment Account and the subscription association start date. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <param name="billingSubscriptionId"> The ID of the billing subscription with the subscription alias. </param>
        /// <returns> A new <see cref="Billing.BillingSubscriptionAliasData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingSubscriptionAliasData BillingSubscriptionAliasData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, BillingSubscriptionAutoRenewState? autoRenew, string beneficiaryTenantId, string billingFrequency, ResourceIdentifier billingProfileId, IReadOnlyDictionary<string, string> billingPolicies, string billingProfileDisplayName, string billingProfileName, string consumptionCostCenter, string customerId, string customerDisplayName, string displayName, string enrollmentAccountId, string enrollmentAccountDisplayName, ResourceIdentifier invoiceSectionId, string invoiceSectionDisplayName, string invoiceSectionName, BillingAmount lastMonthCharges, BillingAmount monthToDateCharges, string nextBillingCycleBillingFrequency, string offerId, string productCategory, string productType, string productTypeId, DateTimeOffset? purchaseOn, long? quantity, CreatedSubscriptionReseller reseller, SubscriptionRenewalTermDetails renewalTermDetails, string skuDescription, string skuId, BillingSubscriptionStatus? status, string subscriptionId, IEnumerable<string> suspensionReasons, TimeSpan? termDuration, DateTimeOffset? termStartOn, DateTimeOffset? termEndOn, SubscriptionEnrollmentAccountStatus? subscriptionEnrollmentAccountStatus, DateTimeOffset? enrollmentAccountStartOn, ResourceIdentifier billingSubscriptionId)
            => BillingSubscriptionAliasData(id, name, resourceType, systemData, autoRenew, null, null, billingFrequency, billingProfileId, billingPolicies, billingProfileDisplayName, billingProfileName, consumptionCostCenter, null, customerDisplayName, null, displayName, enrollmentAccountId, enrollmentAccountDisplayName, invoiceSectionId, invoiceSectionDisplayName, invoiceSectionName, lastMonthCharges, monthToDateCharges, nextBillingCycleBillingFrequency, offerId, productCategory, productType, productTypeId, purchaseOn, quantity, reseller, renewalTermDetails, skuId, skuDescription, null, null, termDuration, termStartOn, termEndOn, null, status, null, null, subscriptionId, suspensionReasons, null, enrollmentAccountStartOn, subscriptionEnrollmentAccountStatus, null, null);

        /// <summary> Initializes a new instance of <see cref="Billing.BillingSubscriptionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="autoRenew"> Indicates whether auto renewal is turned on or off for a subscription. </param>
        /// <param name="beneficiaryTenantId"> The provisioning tenant of the subscription. </param>
        /// <param name="billingFrequency"> The billing frequency of the subscription in the ISO8601 format. Example: P1M, P3M, P1Y. </param>
        /// <param name="billingProfileId"> The ID of the billing profile to which the subscription is billed. This field is only applicable for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="billingPolicies"> Dictionary of billing policies associated with the subscription. </param>
        /// <param name="billingProfileDisplayName"> The display name of the billing profile to which the subscription is billed. This field is only applicable for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="billingProfileName"> The name of the billing profile to which the subscription is billed. This field is only applicable for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="consumptionCostCenter"> The cost center applied to the subscription. This field is only available for consumption subscriptions of Microsoft Customer Agreement Type billing accounts. </param>
        /// <param name="customerId"> The ID of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="customerDisplayName"> The name of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="displayName"> The name of the subscription. </param>
        /// <param name="enrollmentAccountId"> The enrollment Account ID associated with the subscription. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <param name="enrollmentAccountDisplayName"> The enrollment Account name associated with the subscription. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <param name="invoiceSectionId"> The ID of the invoice section to which the subscription is billed. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="invoiceSectionDisplayName"> The display name of the invoice section to which the subscription is billed. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="invoiceSectionName"> The name of the invoice section to which the subscription is billed. The field is applicable only for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="lastMonthCharges"> The last month's charges. This field is only available for usage based subscriptions of Microsoft Customer Agreement billing accounts. </param>
        /// <param name="monthToDateCharges"> The current month to date charges. This field is only available for usage based subscriptions of Microsoft Customer Agreement billing accounts. </param>
        /// <param name="nextBillingCycleBillingFrequency"> Next billing cycle details of the subscription. </param>
        /// <param name="offerId"> The offer ID for the subscription. This field is only available for the Microsoft Online Services Program billing accounts. </param>
        /// <param name="productCategory"> The category of the product for which the subscription is purchased. Possible values include: AzureSupport, Hardware, ReservationOrder, SaaS, SavingsPlanOrder, Software, UsageBased, Other. </param>
        /// <param name="productType"> The type of the product for which the subscription is purchased. </param>
        /// <param name="productTypeId"> The ID of the product for which the subscription is purchased. </param>
        /// <param name="purchaseOn"> The purchase date of the subscription in UTC time. </param>
        /// <param name="quantity"> The number of licenses purchased for the subscription. </param>
        /// <param name="reseller"> The reseller for which the subscription is created. The field is available for Microsoft Partner Agreement billing accounts. </param>
        /// <param name="renewalTermDetails"> The term details of the subscription at the next renewal. </param>
        /// <param name="skuDescription"> The SKU description of the product for which the subscription is purchased. This field is only available for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="skuId"> The SKU ID of the product for which the subscription is purchased. This field is only available for Microsoft Customer Agreement billing accounts. </param>
        /// <param name="status"> The status of the subscription. This field is not available for Enterprise Agreement billing accounts. </param>
        /// <param name="subscriptionId"> The ID of the usage-based subscription. This field is only available for usage-based subscriptions of Microsoft Customer Agreement billing accounts. </param>
        /// <param name="suspensionReasons"> The suspension reason for the subscription. This field is not available for Enterprise Agreement billing accounts. </param>
        /// <param name="termDuration"> The duration for which you can use the subscription. Example P1Y and P1M. </param>
        /// <param name="termStartOn"> The start date of the term in UTC time. </param>
        /// <param name="termEndOn"> The end date of the term in UTC time. </param>
        /// <param name="subscriptionEnrollmentAccountStatus"> The current enrollment account status of the subscription. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <param name="enrollmentAccountStartOn"> The enrollment Account and the subscription association start date. This field is available only for the Enterprise Agreement billing accounts. </param>
        /// <returns> A new <see cref="Billing.BillingSubscriptionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingSubscriptionData BillingSubscriptionData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, BillingSubscriptionAutoRenewState? autoRenew, string beneficiaryTenantId, string billingFrequency, ResourceIdentifier billingProfileId, IReadOnlyDictionary<string, string> billingPolicies, string billingProfileDisplayName, string billingProfileName, string consumptionCostCenter, string customerId, string customerDisplayName, string displayName, string enrollmentAccountId, string enrollmentAccountDisplayName, ResourceIdentifier invoiceSectionId, string invoiceSectionDisplayName, string invoiceSectionName, BillingAmount lastMonthCharges, BillingAmount monthToDateCharges, string nextBillingCycleBillingFrequency, string offerId, string productCategory, string productType, string productTypeId, DateTimeOffset? purchaseOn, long? quantity, CreatedSubscriptionReseller reseller, SubscriptionRenewalTermDetails renewalTermDetails, string skuDescription, string skuId, BillingSubscriptionStatus? status, string subscriptionId, IEnumerable<string> suspensionReasons, TimeSpan? termDuration, DateTimeOffset? termStartOn, DateTimeOffset? termEndOn, SubscriptionEnrollmentAccountStatus? subscriptionEnrollmentAccountStatus, DateTimeOffset? enrollmentAccountStartOn)
            => BillingSubscriptionData(id, name, resourceType, systemData, autoRenew, null, null, billingFrequency, billingProfileId, billingPolicies, billingProfileDisplayName, billingProfileName, consumptionCostCenter, null, customerDisplayName, null, displayName, enrollmentAccountId, enrollmentAccountDisplayName, invoiceSectionId, invoiceSectionDisplayName, invoiceSectionName, lastMonthCharges, monthToDateCharges, nextBillingCycleBillingFrequency, offerId, productCategory, productType, productTypeId, purchaseOn, quantity, reseller, renewalTermDetails, skuId, skuDescription, null, null, termDuration, termStartOn, termEndOn, null, status, null, null, subscriptionId, suspensionReasons, null, enrollmentAccountStartOn, subscriptionEnrollmentAccountStatus, null);

        /// <summary> Initializes a new instance of <see cref="Models.BillingRoleAssignmentProperties"/>. </summary>
        /// <param name="provisioningState"> The provisioning state of the resource during a long-running operation. </param>
        /// <param name="createdOn"> The date the role assignment was created. </param>
        /// <param name="createdByPrincipalTenantId"> The tenant Id of the user who created the role assignment. </param>
        /// <param name="createdByPrincipalId"> The object ID of the user who created the role assignment. </param>
        /// <param name="createdByPrincipalPuid"> The principal PUID of the user who created the role assignment. </param>
        /// <param name="createdByUserEmailAddress"> The email address of the user who created the role assignment. This is supported only for billing accounts with agreement type Enterprise Agreement. </param>
        /// <param name="modifiedOn"> The date the role assignment was modified. </param>
        /// <param name="modifiedByPrincipalPuid"> The principal PUID of the user who modified the role assignment. </param>
        /// <param name="modifiedByUserEmailAddress"> The email address of the user who modified the role assignment. This is supported only for billing accounts with agreement type Enterprise Agreement. </param>
        /// <param name="modifiedByPrincipalId"> The principal PUID of the user who modified the role assignment. </param>
        /// <param name="modifiedByPrincipalTenantId"> The tenant Id of the user who modified the role assignment. </param>
        /// <param name="principalPuid"> The principal PUID of the user to whom the role was assigned. </param>
        /// <param name="principalId"> The object id of the user to whom the role was assigned. </param>
        /// <param name="principalTenantId"> The principal tenant id of the user to whom the role was assigned. </param>
        /// <param name="roleDefinitionId"> The ID of the role definition. </param>
        /// <param name="scope"> The scope at which the role was assigned. </param>
        /// <param name="userAuthenticationType"> The authentication type of the user, whether Organization or MSA, of the user to whom the role was assigned. This is supported only for billing accounts with agreement type Enterprise Agreement. </param>
        /// <param name="userEmailAddress"> The email address of the user to whom the role was assigned. This is supported only for billing accounts with agreement type Enterprise Agreement. </param>
        /// <param name="principalTenantName"> The friendly name of the tenant of the user to whom the role was assigned. This will be 'Primary Tenant' for the primary tenant of the billing account. </param>
        /// <param name="principalDisplayName"> The display name of the principal to whom the role was assigned. </param>
        /// <param name="principalType"> The type of a role Assignment. </param>
        /// <param name="billingRequestId"> The ID of the billing request that was created for the role assignment. This is only applicable to cross tenant role assignments or role assignments created through the billing request. </param>
        /// <param name="billingAccountId"> The fully qualified ID that uniquely identifies a billing account. </param>
        /// <param name="billingAccountDisplayName"> The name of the billing account. </param>
        /// <param name="billingProfileId"> The fully qualified ID that uniquely identifies a billing profile. </param>
        /// <param name="billingProfileDisplayName"> The name of the billing profile. </param>
        /// <param name="invoiceSectionId"> The fully qualified ID that uniquely identifies an invoice section. </param>
        /// <param name="invoiceSectionDisplayName"> The name of the invoice section. </param>
        /// <param name="customerId"> The fully qualified ID that uniquely identifies a customer. </param>
        /// <param name="customerDisplayName"> The name of the customer. </param>
        /// <returns> A new <see cref="Models.BillingRoleAssignmentProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingRoleAssignmentProperties BillingRoleAssignmentProperties(BillingProvisioningState? provisioningState = null, DateTimeOffset? createdOn = null, Guid? createdByPrincipalTenantId = null, string createdByPrincipalId = null, string createdByPrincipalPuid = null, string createdByUserEmailAddress = null, DateTimeOffset? modifiedOn = null, string modifiedByPrincipalPuid = null, string modifiedByUserEmailAddress = null, string modifiedByPrincipalId = null, Guid? modifiedByPrincipalTenantId = null, string principalPuid = null, string principalId = null, Guid? principalTenantId = null, ResourceIdentifier roleDefinitionId = null, string scope = null, string userAuthenticationType = null, string userEmailAddress = null, string principalTenantName = null, string principalDisplayName = null, BillingPrincipalType? principalType = null, ResourceIdentifier billingRequestId = null, ResourceIdentifier billingAccountId = null, string billingAccountDisplayName = null, ResourceIdentifier billingProfileId = null, string billingProfileDisplayName = null, ResourceIdentifier invoiceSectionId = null, string invoiceSectionDisplayName = null, ResourceIdentifier customerId = null, string customerDisplayName = null)
        {
            return new BillingRoleAssignmentProperties(
                provisioningState,
                createdOn,
                createdByPrincipalTenantId.ToString(),
                createdByPrincipalId,
                createdByPrincipalPuid,
                createdByUserEmailAddress,
                modifiedOn,
                modifiedByPrincipalPuid,
                modifiedByUserEmailAddress,
                modifiedByPrincipalId,
                modifiedByPrincipalTenantId,
                principalPuid,
                principalId,
                principalTenantId,
                roleDefinitionId,
                scope,
                userAuthenticationType,
                userEmailAddress,
                principalTenantName,
                principalDisplayName,
                principalType,
                billingRequestId,
                billingAccountId,
                billingAccountDisplayName,
                billingProfileId,
                billingProfileDisplayName,
                invoiceSectionId,
                invoiceSectionDisplayName,
                customerId,
                customerDisplayName,
                serializedAdditionalRawData: null);
        }
    }
}
