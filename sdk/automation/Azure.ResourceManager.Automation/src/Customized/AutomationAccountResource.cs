// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A Class representing an AutomationAccount along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AutomationAccountResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAutomationAccountResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetAutomationAccount method.
    /// </summary>
    public partial class AutomationAccountResource : ArmResource
    {
        /// <summary>
        /// Return list of software update configuration runs
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationRuns
        /// Operation Id: SoftwareUpdateConfigurationRuns_List
        /// </summary>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="filter"> The filter to apply on the operation. You can use the following filters: &apos;properties/osType&apos;, &apos;properties/status&apos;, &apos;properties/startTime&apos;, and &apos;properties/softwareUpdateConfiguration/name&apos;. </param>
        /// <param name="skip"> Number of entries you skip before returning results. </param>
        /// <param name="top"> Maximum number of entries returned in the results collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SoftwareUpdateConfigurationRun" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SoftwareUpdateConfigurationRun> GetSoftwareUpdateConfigurationRunsAsync(string clientRequestId = null, string filter = null, string skip = null, string top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SoftwareUpdateConfigurationRun>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _softwareUpdateConfigurationRunsClientDiagnostics.CreateScope("AutomationAccountResource.GetSoftwareUpdateConfigurationRuns");
                scope.Start();
                try
                {
                    var response = await _softwareUpdateConfigurationRunsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, clientRequestId, filter, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Return list of software update configuration runs
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationRuns
        /// Operation Id: SoftwareUpdateConfigurationRuns_List
        /// </summary>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="filter"> The filter to apply on the operation. You can use the following filters: &apos;properties/osType&apos;, &apos;properties/status&apos;, &apos;properties/startTime&apos;, and &apos;properties/softwareUpdateConfiguration/name&apos;. </param>
        /// <param name="skip"> Number of entries you skip before returning results. </param>
        /// <param name="top"> Maximum number of entries returned in the results collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SoftwareUpdateConfigurationRun" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SoftwareUpdateConfigurationRun> GetSoftwareUpdateConfigurationRuns(string clientRequestId = null, string filter = null, string skip = null, string top = null, CancellationToken cancellationToken = default)
        {
            Page<SoftwareUpdateConfigurationRun> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _softwareUpdateConfigurationRunsClientDiagnostics.CreateScope("AutomationAccountResource.GetSoftwareUpdateConfigurationRuns");
                scope.Start();
                try
                {
                    var response = _softwareUpdateConfigurationRunsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, clientRequestId, filter, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Return list of software update configuration machine runs
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationMachineRuns
        /// Operation Id: SoftwareUpdateConfigurationMachineRuns_List
        /// </summary>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="filter"> The filter to apply on the operation. You can use the following filters: &apos;properties/osType&apos;, &apos;properties/status&apos;, &apos;properties/startTime&apos;, and &apos;properties/softwareUpdateConfiguration/name&apos;. </param>
        /// <param name="skip"> number of entries you skip before returning results. </param>
        /// <param name="top"> Maximum number of entries returned in the results collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SoftwareUpdateConfigurationMachineRun" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SoftwareUpdateConfigurationMachineRun> GetSoftwareUpdateConfigurationMachineRunsAsync(string clientRequestId = null, string filter = null, string skip = null, string top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SoftwareUpdateConfigurationMachineRun>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _softwareUpdateConfigurationMachineRunsClientDiagnostics.CreateScope("AutomationAccountResource.GetSoftwareUpdateConfigurationMachineRuns");
                scope.Start();
                try
                {
                    var response = await _softwareUpdateConfigurationMachineRunsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, clientRequestId, filter, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Return list of software update configuration machine runs
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurationMachineRuns
        /// Operation Id: SoftwareUpdateConfigurationMachineRuns_List
        /// </summary>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="filter"> The filter to apply on the operation. You can use the following filters: &apos;properties/osType&apos;, &apos;properties/status&apos;, &apos;properties/startTime&apos;, and &apos;properties/softwareUpdateConfiguration/name&apos;. </param>
        /// <param name="skip"> number of entries you skip before returning results. </param>
        /// <param name="top"> Maximum number of entries returned in the results collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SoftwareUpdateConfigurationMachineRun" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SoftwareUpdateConfigurationMachineRun> GetSoftwareUpdateConfigurationMachineRuns(string clientRequestId = null, string filter = null, string skip = null, string top = null, CancellationToken cancellationToken = default)
        {
            Page<SoftwareUpdateConfigurationMachineRun> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _softwareUpdateConfigurationMachineRunsClientDiagnostics.CreateScope("AutomationAccountResource.GetSoftwareUpdateConfigurationMachineRuns");
                scope.Start();
                try
                {
                    var response = _softwareUpdateConfigurationMachineRunsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, clientRequestId, filter, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
