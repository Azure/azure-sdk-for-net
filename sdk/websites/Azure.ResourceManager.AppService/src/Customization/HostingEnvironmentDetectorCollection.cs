// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing a collection of <see cref="HostingEnvironmentDetectorResource" /> and their operations.
    /// Each <see cref="HostingEnvironmentDetectorResource" /> in the collection will belong to the same instance of <see cref="AppServiceEnvironmentResource" />.
    /// To get a <see cref="HostingEnvironmentDetectorCollection" /> instance call the GetHostingEnvironmentDetectors method from an instance of <see cref="AppServiceEnvironmentResource" />.
    /// </summary>
    public partial class HostingEnvironmentDetectorCollection : ArmCollection, IEnumerable<HostingEnvironmentDetectorResource>, IAsyncEnumerable<HostingEnvironmentDetectorResource>
    {
        /// <summary>
        /// Description for Get Hosting Environment Detector Response
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetHostingEnvironmentDetectorResponse
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<Response<HostingEnvironmentDetectorResource>> GetAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _hostingEnvironmentDetectorDiagnosticsClientDiagnostics.CreateScope("HostingEnvironmentDetectorCollection.Get");
            scope.Start();
            try
            {
                var response = await _hostingEnvironmentDetectorDiagnosticsRestClient.GetHostingEnvironmentDetectorResponseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken).ConfigureAwait(false);
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
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual Response<HostingEnvironmentDetectorResource> Get(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _hostingEnvironmentDetectorDiagnosticsClientDiagnostics.CreateScope("HostingEnvironmentDetectorCollection.Get");
            scope.Start();
            try
            {
                var response = _hostingEnvironmentDetectorDiagnosticsRestClient.GetHostingEnvironmentDetectorResponse(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken);
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
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetHostingEnvironmentDetectorResponse
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _hostingEnvironmentDetectorDiagnosticsClientDiagnostics.CreateScope("HostingEnvironmentDetectorCollection.Exists");
            scope.Start();
            try
            {
                var response = await _hostingEnvironmentDetectorDiagnosticsRestClient.GetHostingEnvironmentDetectorResponseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/detectors/{detectorName}
        /// Operation Id: Diagnostics_GetHostingEnvironmentDetectorResponse
        /// </summary>
        /// <param name="detectorName"> Detector Resource Name. </param>
        /// <param name="startTime"> Start Time. </param>
        /// <param name="endTime"> End Time. </param>
        /// <param name="timeGrain"> Time Grain. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual Response<bool> Exists(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _hostingEnvironmentDetectorDiagnosticsClientDiagnostics.CreateScope("HostingEnvironmentDetectorCollection.Exists");
            scope.Start();
            try
            {
                var response = _hostingEnvironmentDetectorDiagnosticsRestClient.GetHostingEnvironmentDetectorResponse(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
