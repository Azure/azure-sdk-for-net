// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing a HostingEnvironmentDetector along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="HostingEnvironmentDetectorResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetHostingEnvironmentDetectorResource method.
    /// Otherwise you can get one from its parent resource <see cref="AppServiceEnvironmentResource" /> using the GetHostingEnvironmentDetector method.
    /// </summary>
    public partial class HostingEnvironmentDetectorResource : ArmResource
    {
        /// <summary>
        /// Description for Get Hosting Environment Detector Response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetHostingEnvironmentDetectorResponse
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<HostingEnvironmentDetectorResource>> GetAsync(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _hostingEnvironmentDetectorDiagnosticsClientDiagnostics.CreateScope("HostingEnvironmentDetectorResource.Get");
            scope.Start();
            try
            {
                var response = await _hostingEnvironmentDetectorDiagnosticsRestClient.GetHostingEnvironmentDetectorResponseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new HostingEnvironmentDetectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get Hosting Environment Detector Response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetHostingEnvironmentDetectorResponse
        /// </summary>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<HostingEnvironmentDetectorResource> Get(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            using var scope = _hostingEnvironmentDetectorDiagnosticsClientDiagnostics.CreateScope("HostingEnvironmentDetectorResource.Get");
            scope.Start();
            try
            {
                var response = _hostingEnvironmentDetectorDiagnosticsRestClient.GetHostingEnvironmentDetectorResponse(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, startTime, endTime, timeGrain, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new HostingEnvironmentDetectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
