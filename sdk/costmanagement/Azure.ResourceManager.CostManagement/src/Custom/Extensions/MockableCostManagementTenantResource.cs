// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement.Mocking
{
    public partial class MockableCostManagementTenantResource : ArmResource
    {
        /// <summary>
        /// Gets a URL to download the current month's pricesheet for a billing profile. The operation is supported for billing accounts with agreement type Microsoft Partner Agreement or Microsoft Customer Agreement.Due to Azure product growth, the Azure price sheet download experience in this preview version will be updated from a single csv file to a Zip file containing multiple csv files, each with max 200k records.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/providers/Microsoft.CostManagement/pricesheets/default/download</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PriceSheet_DownloadByBillingProfile</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DownloadURL>> DownloadByBillingProfilePriceSheetAsync(WaitUntil waitUntil, string billingAccountName, string billingProfileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            Argument.AssertNotNullOrEmpty(billingProfileName, nameof(billingProfileName));

            using var scope = PriceSheetClientDiagnostics.CreateScope("MockableCostManagementTenantResource.DownloadByBillingProfilePriceSheet");
            scope.Start();
            try
            {
                var response = await PriceSheetRestClient.DownloadByBillingProfileAsync(billingAccountName, billingProfileName, cancellationToken).ConfigureAwait(false);
                var operation = new CostManagementArmOperation<DownloadURL>(new DownloadURLOperationSource(), PriceSheetClientDiagnostics, Pipeline, PriceSheetRestClient.CreateDownloadByBillingProfileRequest(billingAccountName, billingProfileName).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a URL to download the current month's pricesheet for a billing profile. The operation is supported for billing accounts with agreement type Microsoft Partner Agreement or Microsoft Customer Agreement.Due to Azure product growth, the Azure price sheet download experience in this preview version will be updated from a single csv file to a Zip file containing multiple csv files, each with max 200k records.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/providers/Microsoft.CostManagement/pricesheets/default/download</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PriceSheet_DownloadByBillingProfile</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-03-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DownloadURL> DownloadByBillingProfilePriceSheet(WaitUntil waitUntil, string billingAccountName, string billingProfileName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(billingAccountName, nameof(billingAccountName));
            Argument.AssertNotNullOrEmpty(billingProfileName, nameof(billingProfileName));

            using var scope = PriceSheetClientDiagnostics.CreateScope("MockableCostManagementTenantResource.DownloadByBillingProfilePriceSheet");
            scope.Start();
            try
            {
                var response = PriceSheetRestClient.DownloadByBillingProfile(billingAccountName, billingProfileName, cancellationToken);
                var operation = new CostManagementArmOperation<DownloadURL>(new DownloadURLOperationSource(), PriceSheetClientDiagnostics, Pipeline, PriceSheetRestClient.CreateDownloadByBillingProfileRequest(billingAccountName, billingProfileName).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
