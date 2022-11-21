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
    /// A Class representing a SiteDiagnosticDetector along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SiteDiagnosticDetectorResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSiteDiagnosticDetectorResource method.
    /// Otherwise you can get one from its parent resource <see cref="SiteDiagnosticResource" /> using the GetSiteDiagnosticDetector method.
    /// </summary>
    public partial class SiteDiagnosticDetectorResource : ArmResource
    {
        /// <summary>
        /// Description for Execute Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute
        /// Operation Id: Diagnostics_ExecuteSiteDetector
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DiagnosticDetectorResponse>> ExecuteAsync(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorResource.Execute");
            scope.Start();
            try
            {
                var response = await _siteDiagnosticDetectorDiagnosticsRestClient.ExecuteSiteDetectorAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Execute Detector
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute
        /// Operation Id: Diagnostics_ExecuteSiteDetector
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DiagnosticDetectorResponse> Execute(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteDiagnosticDetectorDiagnosticsClientDiagnostics.CreateScope("SiteDiagnosticDetectorResource.Execute");
            scope.Start();
            try
            {
                var response = _siteDiagnosticDetectorDiagnosticsRestClient.ExecuteSiteDetector(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken);
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
