// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing a SiteSlotDiagnosticAnalysis along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SiteSlotDiagnosticAnalysisResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSiteSlotDiagnosticAnalysisResource method.
    /// Otherwise you can get one from its parent resource <see cref="SiteSlotDiagnosticResource" /> using the GetSiteSlotDiagnosticAnalysis method.
    /// </summary>
    public partial class SiteSlotDiagnosticAnalysisResource : ArmResource
    {
        /// <summary>
        /// Description for Execute Analysis
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slot}/diagnostics/{diagnosticCategory}/analyses/{analysisName}/execute
        /// Operation Id: Diagnostics_ExecuteSiteAnalysisSlot
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DiagnosticAnalysis>> ExecuteSiteAnalysisSlotAsync(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteSlotDiagnosticAnalysisResource.ExecuteSiteAnalysisSlot");
            scope.Start();
            try
            {
                var response = await _siteSlotDiagnosticAnalysisDiagnosticsRestClient.ExecuteSiteAnalysisSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Execute Analysis
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slot}/diagnostics/{diagnosticCategory}/analyses/{analysisName}/execute
        /// Operation Id: Diagnostics_ExecuteSiteAnalysisSlot
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DiagnosticAnalysis> ExecuteSiteAnalysisSlot(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotDiagnosticAnalysisDiagnosticsClientDiagnostics.CreateScope("SiteSlotDiagnosticAnalysisResource.ExecuteSiteAnalysisSlot");
            scope.Start();
            try
            {
                var response = _siteSlotDiagnosticAnalysisDiagnosticsRestClient.ExecuteSiteAnalysisSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
