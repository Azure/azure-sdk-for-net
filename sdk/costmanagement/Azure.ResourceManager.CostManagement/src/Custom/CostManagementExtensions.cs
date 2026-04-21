// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CostManagement.Mocking;
using Azure.ResourceManager.CostManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CostManagement
{
    // Backward-compat TenantResource extension methods.
    //
    // All operations below have paths with multiple /providers/ segments, e.g.:
    //   /providers/microsoft.Billing/billingAccounts/{id}/providers/Microsoft.CostManagement/benefitUtilizationSummaries
    //   /providers/microsoft.BillingBenefits/savingsPlanOrders/{id}/providers/Microsoft.CostManagement/benefitUtilizationSummaries
    //   /providers/microsoft.Capacity/reservationorders/{id}/providers/Microsoft.CostManagement/generateBenefitUtilizationSummariesReport
    //   /providers/microsoft.Billing/billingAccounts/{id}/billingProfiles/{id}/providers/Microsoft.CostManagement/pricesheets/default/download
    //   /providers/microsoft.Billing/billingAccounts/{id}/providers/Microsoft.CostManagement/generateReservationDetailsReport
    //   /providers/Microsoft.CostManagement/{externalCloudProviderType}/{externalCloudProviderId}/dimensions
    //
    // The TypeSpec generator correctly assigns these Extension scope (ArmClient) because they extend
    // resources from other RPs (microsoft.Billing, microsoft.BillingBenefits, microsoft.Capacity).
    // These shims restore that old surface for ApiCompat.
    public static partial class CostManagementExtensions
    {
        /// <summary> List benefit utilization summaries by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountId(this TenantResource tenantResource, string billingAccountId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesByBillingAccountId(billingAccountId, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountIdAsync(this TenantResource tenantResource, string billingAccountId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesByBillingAccountIdAsync(billingAccountId, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileId(this TenantResource tenantResource, string billingAccountId, string billingProfileId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesByBillingProfileId(billingAccountId, billingProfileId, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileIdAsync(this TenantResource tenantResource, string billingAccountId, string billingProfileId, GrainContent? grainParameter = default, string filter = null, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesByBillingProfileIdAsync(billingAccountId, billingProfileId, grainParameter, filter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrder(this TenantResource tenantResource, string savingsPlanOrderId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesBySavingsPlanOrder(savingsPlanOrderId, filter, grainParameter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(this TenantResource tenantResource, string savingsPlanOrderId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(savingsPlanOrderId, filter, grainParameter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanId(this TenantResource tenantResource, string savingsPlanOrderId, string savingsPlanId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesBySavingsPlanId(savingsPlanOrderId, savingsPlanId, filter, grainParameter, cancellationToken);
        }

        /// <summary> List benefit utilization summaries by savings plan ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanIdAsync(this TenantResource tenantResource, string savingsPlanOrderId, string savingsPlanId, string filter = null, GrainContent? grainParameter = default, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GetBenefitUtilizationSummariesBySavingsPlanIdAsync(savingsPlanOrderId, savingsPlanId, filter, grainParameter, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing account. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingAccountScope(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportBillingAccountScope(waitUntil, billingAccountId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing account. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(waitUntil, billingAccountId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingProfileScope(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportBillingProfileScope(waitUntil, billingAccountId, billingProfileId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(waitUntil, billingAccountId, billingProfileId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationOrderScope(this TenantResource tenantResource, WaitUntil waitUntil, string reservationOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportReservationOrderScope(waitUntil, reservationOrderId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(this TenantResource tenantResource, WaitUntil waitUntil, string reservationOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(waitUntil, reservationOrderId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationScope(this TenantResource tenantResource, WaitUntil waitUntil, string reservationOrderId, string reservationId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportReservationScope(waitUntil, reservationOrderId, reservationId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided reservation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationScopeAsync(this TenantResource tenantResource, WaitUntil waitUntil, string reservationOrderId, string reservationId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportReservationScopeAsync(waitUntil, reservationOrderId, reservationId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(this TenantResource tenantResource, WaitUntil waitUntil, string savingsPlanOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(waitUntil, savingsPlanOrderId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan order. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(this TenantResource tenantResource, WaitUntil waitUntil, string savingsPlanOrderId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(waitUntil, savingsPlanOrderId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(this TenantResource tenantResource, WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(waitUntil, savingsPlanOrderId, savingsPlanId, content, cancellationToken);
        }

        /// <summary> Triggers generation of a benefit utilization summaries report for the provided savings plan. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(this TenantResource tenantResource, WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, BenefitUtilizationSummariesContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(waitUntil, savingsPlanOrderId, savingsPlanId, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Download price sheet for an invoice. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<DownloadURL> DownloadPriceSheet(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).DownloadPriceSheet(waitUntil, billingAccountId, billingProfileName, invoiceName, cancellationToken);
        }

        /// <summary> Download price sheet for an invoice. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<DownloadURL>> DownloadPriceSheetAsync(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).DownloadPriceSheetAsync(waitUntil, billingAccountId, billingProfileName, invoiceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Download price sheet for a billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("The underlying operation now returns PriceSheetDownloadProperties instead of DownloadURL and the DownloadURL.ValidTill field is no longer available from the service. This overload will throw NotSupportedException at runtime. Use the ArmClient.DownloadByBillingProfilePriceSheet extension method instead.")]
        public static ArmOperation<DownloadURL> DownloadByBillingProfilePriceSheet(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileName, CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This backward-compat overload returns DownloadURL but the underlying operation now returns PriceSheetDownloadProperties. Use the ArmClient.DownloadByBillingProfilePriceSheet extension method instead.");
        }

        /// <summary> Download price sheet for a billing profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("The underlying operation now returns PriceSheetDownloadProperties instead of DownloadURL and the DownloadURL.ValidTill field is no longer available from the service. This overload will throw NotSupportedException at runtime. Use the ArmClient.DownloadByBillingProfilePriceSheetAsync extension method instead.")]
        public static Task<ArmOperation<DownloadURL>> DownloadByBillingProfilePriceSheetAsync(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileName, CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This backward-compat overload returns DownloadURL but the underlying operation now returns PriceSheetDownloadProperties. Use the ArmClient.DownloadByBillingProfilePriceSheetAsync extension method instead.");
        }

        /// <summary> Generate reservation details report by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<OperationStatus> ByBillingAccountIdGenerateReservationDetailsReport(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).ByBillingAccountIdGenerateReservationDetailsReport(waitUntil, billingAccountId, startDate, endDate, cancellationToken);
        }

        /// <summary> Generate reservation details report by billing account ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<OperationStatus>> ByBillingAccountIdGenerateReservationDetailsReportAsync(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).ByBillingAccountIdGenerateReservationDetailsReportAsync(waitUntil, billingAccountId, startDate, endDate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Generate reservation details report by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<OperationStatus> ByBillingProfileIdGenerateReservationDetailsReport(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).ByBillingProfileIdGenerateReservationDetailsReport(waitUntil, billingAccountId, billingProfileId, startDate, endDate, cancellationToken);
        }

        /// <summary> Generate reservation details report by billing profile ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<OperationStatus>> ByBillingProfileIdGenerateReservationDetailsReportAsync(this TenantResource tenantResource, WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            return await GetMockableCostManagementTenantResource(tenantResource).ByBillingProfileIdGenerateReservationDetailsReportAsync(waitUntil, billingAccountId, billingProfileId, startDate, endDate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> List dimensions by external cloud provider type using options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CostManagementDimension> ByExternalCloudProviderTypeDimensions(this TenantResource tenantResource, TenantResourceByExternalCloudProviderTypeDimensionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).ByExternalCloudProviderTypeDimensions(options, cancellationToken);
        }

        /// <summary> List dimensions by external cloud provider type using options bag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CostManagementDimension> ByExternalCloudProviderTypeDimensionsAsync(this TenantResource tenantResource, TenantResourceByExternalCloudProviderTypeDimensionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableCostManagementTenantResource(tenantResource).ByExternalCloudProviderTypeDimensionsAsync(options, cancellationToken);
        }
    }
}
