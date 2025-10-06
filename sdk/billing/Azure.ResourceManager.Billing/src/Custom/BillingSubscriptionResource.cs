// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Billing.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Billing
{
    /// <summary>
    /// A Class representing a BillingSubscription along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="BillingSubscriptionResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetBillingSubscriptionResource method.
    /// Otherwise you can get one from its parent resource <see cref="TenantResource"/> using the GetBillingSubscription method.
    /// </summary>
    public partial class BillingSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Gets a subscription by its ID. The operation is currently supported for billing accounts with agreement type Microsoft Customer Agreement, Microsoft Partner Agreement and Microsoft Online Services Program.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptions/{billingSubscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BillingSubscriptionResource>> GetAsync(CancellationToken cancellationToken)
            => await GetAsync(null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets a subscription by its ID. The operation is currently supported for billing accounts with agreement type Microsoft Customer Agreement, Microsoft Partner Agreement and Microsoft Online Services Program.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptions/{billingSubscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BillingSubscriptionResource> Get(CancellationToken cancellationToken)
            => Get(null, cancellationToken);

        /// <summary>
        /// Updates the properties of a billing subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptions/{billingSubscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptions_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Request parameters that are provided to the update billing subscription operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BillingSubscriptionResource>> UpdateAsync(WaitUntil waitUntil, BillingSubscriptionData data, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, InitPatchData(data), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates the properties of a billing subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptions/{billingSubscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptions_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Request parameters that are provided to the update billing subscription operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingSubscriptionResource> Update(WaitUntil waitUntil, BillingSubscriptionData data, CancellationToken cancellationToken)
            => Update(waitUntil, InitPatchData(data), cancellationToken);

        private static BillingSubscriptionPatch InitPatchData(BillingSubscriptionData data)
        {
            return new BillingSubscriptionPatch(data.Id,
                                                data.Name,
                                                data.ResourceType,
                                                data.SystemData,
                                                data.AutoRenew,
                                                data.SubscriptionBeneficiaryTenantId,
                                                data.Beneficiary,
                                                data.BillingFrequency,
                                                data.BillingProfileId,
                                                data.BillingPolicies,
                                                data.BillingProfileDisplayName,
                                                data.BillingProfileName,
                                                data.ConsumptionCostCenter,
                                                data.SubscriptionCustomerId,
                                                data.CustomerDisplayName,
                                                data.CustomerName,
                                                data.DisplayName,
                                                data.EnrollmentAccountId,
                                                data.EnrollmentAccountDisplayName,
                                                data.InvoiceSectionId,
                                                data.InvoiceSectionDisplayName,
                                                data.InvoiceSectionName,
                                                data.LastMonthCharges,
                                                data.MonthToDateCharges,
                                                data.NextBillingCycleDetails,
                                                data.OfferId,
                                                data.ProductCategory,
                                                data.ProductType,
                                                data.ProductTypeId,
                                                data.PurchaseOn,
                                                data.Quantity,
                                                data.Reseller,
                                                data.RenewalTermDetails,
                                                data.SkuId,
                                                data.SkuDescription,
                                                data.SystemOverrides,
                                                data.ResourceUri,
                                                data.TermDuration,
                                                data.TermStartOn,
                                                data.TermEndOn,
                                                data.ProvisioningTenantId,
                                                data.Status,
                                                data.OperationStatus,
                                                data.ProvisioningState,
                                                data.SubscriptionId,
                                                data.SuspensionReasons,
                                                data.SuspensionReasonDetails,
                                                data.EnrollmentAccountStartOn,
                                                data.SubscriptionEnrollmentAccountStatus,
                                                data.Tags,
                                                null);
        }
    }
}
