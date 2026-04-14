// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement.Mocking
{
    // Backward-compat methods that existed on TenantResource in v1.0.2 but moved to ArmClient in the new SDK.
    // Each method constructs a ResourceIdentifier from the old string params and delegates to the
    // generated ArmClient-based extension methods. See also: Custom/CostManagementExtensions.cs.
    public partial class MockableCostManagementTenantResource
    {
        // ===== BenefitUtilizationSummaries =====

        /// <summary> List benefit utilization summaries by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountId(string billingAccountId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesByBillingAccountId(Client, scope, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountIdAsync(string billingAccountId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesByBillingAccountIdAsync(Client, scope, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileId(string billingAccountId, string billingProfileId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesByBillingProfileId(Client, scope, billingProfileId, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileIdAsync(string billingAccountId, string billingProfileId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesByBillingProfileIdAsync(Client, scope, billingProfileId, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrder(string savingsPlanOrderId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesBySavingsPlanOrder(Client, scope, filter, grainParameter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(string savingsPlanOrderId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(Client, scope, filter, grainParameter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanId(string savingsPlanOrderId, string savingsPlanId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesBySavingsPlanId(Client, scope, savingsPlanId, filter, grainParameter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanIdAsync(string savingsPlanOrderId, string savingsPlanId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return CostManagementExtensions.GetBenefitUtilizationSummariesBySavingsPlanIdAsync(Client, scope, savingsPlanId, filter, grainParameter, cancellationToken);
        }

        // ===== GenerateBenefitUtilizationSummariesReport =====

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing account. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingAccountScope(WaitUntil waitUntil, string billingAccountId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.GenerateBenefitUtilizationSummariesReportBillingAccountScope(Client, waitUntil, scope, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing account. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(WaitUntil waitUntil, string billingAccountId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return await CostManagementExtensions.GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(Client, waitUntil, scope, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingProfileScope(WaitUntil waitUntil, string billingAccountId, string billingProfileId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.GenerateBenefitUtilizationSummariesReportBillingProfileScope(Client, waitUntil, scope, billingProfileId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(WaitUntil waitUntil, string billingAccountId, string billingProfileId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return await CostManagementExtensions.GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(Client, waitUntil, scope, billingProfileId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationOrderScope(WaitUntil waitUntil, string reservationOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationorders/{reservationOrderId}");
            return CostManagementExtensions.GenerateBenefitUtilizationSummariesReportReservationOrderScope(Client, waitUntil, scope, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(WaitUntil waitUntil, string reservationOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationorders/{reservationOrderId}");
            return await CostManagementExtensions.GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(Client, waitUntil, scope, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationScope(WaitUntil waitUntil, string reservationOrderId, string reservationId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationorders/{reservationOrderId}");
            return CostManagementExtensions.GenerateBenefitUtilizationSummariesReportReservationScope(Client, waitUntil, scope, reservationId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationScopeAsync(WaitUntil waitUntil, string reservationOrderId, string reservationId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Capacity/reservationorders/{reservationOrderId}");
            return await CostManagementExtensions.GenerateBenefitUtilizationSummariesReportReservationScopeAsync(Client, waitUntil, scope, reservationId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(WaitUntil waitUntil, string savingsPlanOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return CostManagementExtensions.GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(Client, waitUntil, scope, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(WaitUntil waitUntil, string savingsPlanOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return await CostManagementExtensions.GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(Client, waitUntil, scope, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return CostManagementExtensions.GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(Client, waitUntil, scope, savingsPlanId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.BillingBenefits/savingsPlanOrders/{savingsPlanOrderId}");
            return await CostManagementExtensions.GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(Client, waitUntil, scope, savingsPlanId, content, cancellationToken).ConfigureAwait(false);
        }

        // ===== PriceSheet Download =====

        /// <summary> Download price sheet for an invoice. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DownloadURL> DownloadPriceSheet(WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.DownloadPriceSheet(Client, waitUntil, scope, billingProfileName, invoiceName, cancellationToken);
        }

        /// <summary> Download price sheet for an invoice. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DownloadURL>> DownloadPriceSheetAsync(WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return await CostManagementExtensions.DownloadPriceSheetAsync(Client, waitUntil, scope, billingProfileName, invoiceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Download price sheet for a billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DownloadURL> DownloadByBillingProfilePriceSheet(WaitUntil waitUntil, string billingAccountId, string billingProfileName, CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This backward-compat overload returns DownloadURL but the underlying operation now returns PricesheetDownloadProperties. Use the ArmClient extension method instead.");
        }

        /// <summary> Download price sheet for a billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DownloadURL>> DownloadByBillingProfilePriceSheetAsync(WaitUntil waitUntil, string billingAccountId, string billingProfileName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new System.NotSupportedException("This backward-compat overload returns DownloadURL but the underlying operation now returns PricesheetDownloadProperties. Use the ArmClient extension method instead.");
        }

        // ===== GenerateReservationDetailsReport =====

        /// <summary> Generate reservation details report by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<OperationStatus> ByBillingAccountIdGenerateReservationDetailsReport(WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.ByBillingAccountIdGenerateReservationDetailsReport(Client, waitUntil, scope, startDate, endDate, cancellationToken);
        }

        /// <summary> Generate reservation details report by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<OperationStatus>> ByBillingAccountIdGenerateReservationDetailsReportAsync(WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return await CostManagementExtensions.ByBillingAccountIdGenerateReservationDetailsReportAsync(Client, waitUntil, scope, startDate, endDate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Generate reservation details report by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<OperationStatus> ByBillingProfileIdGenerateReservationDetailsReport(WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return CostManagementExtensions.ByBillingProfileIdGenerateReservationDetailsReport(Client, waitUntil, scope, billingProfileId, startDate, endDate, cancellationToken);
        }

        /// <summary> Generate reservation details report by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<OperationStatus>> ByBillingProfileIdGenerateReservationDetailsReportAsync(WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            var scope = new ResourceIdentifier($"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}");
            return await CostManagementExtensions.ByBillingProfileIdGenerateReservationDetailsReportAsync(Client, waitUntil, scope, billingProfileId, startDate, endDate, cancellationToken).ConfigureAwait(false);
        }

        // ===== ByExternalCloudProviderTypeDimensions (options bag backward compat) =====

        /// <summary> List dimensions by external cloud provider type using options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CostManagementDimension> ByExternalCloudProviderTypeDimensions(TenantResourceByExternalCloudProviderTypeDimensionsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return ByExternalCloudProviderTypeDimensions(options.ExternalCloudProviderType, options.ExternalCloudProviderId, options.Filter, options.Expand, options.Skiptoken, options.Top, cancellationToken);
        }

        /// <summary> List dimensions by external cloud provider type using options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CostManagementDimension> ByExternalCloudProviderTypeDimensionsAsync(TenantResourceByExternalCloudProviderTypeDimensionsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return ByExternalCloudProviderTypeDimensionsAsync(options.ExternalCloudProviderType, options.ExternalCloudProviderId, options.Filter, options.Expand, options.Skiptoken, options.Top, cancellationToken);
        }
    }
}
