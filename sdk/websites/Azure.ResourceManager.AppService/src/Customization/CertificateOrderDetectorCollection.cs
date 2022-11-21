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
    /// A class representing a collection of <see cref="CertificateOrderDetectorResource" /> and their operations.
    /// Each <see cref="CertificateOrderDetectorResource" /> in the collection will belong to the same instance of <see cref="AppServiceCertificateOrderResource" />.
    /// To get a <see cref="CertificateOrderDetectorCollection" /> instance call the GetCertificateOrderDetectors method from an instance of <see cref="AppServiceCertificateOrderResource" />.
    /// </summary>
    public partial class CertificateOrderDetectorCollection : ArmCollection, IEnumerable<CertificateOrderDetectorResource>, IAsyncEnumerable<CertificateOrderDetectorResource>
    {
        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}
        /// Operation Id: CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<Response<CertificateOrderDetectorResource>> GetAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _certificateOrderDetectorCertificateOrdersDiagnosticsClientDiagnostics.CreateScope("CertificateOrderDetectorCollection.Get");
            scope.Start();
            try
            {
                var response = await _certificateOrderDetectorCertificateOrdersDiagnosticsRestClient.GetAppServiceCertificateOrderDetectorResponseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CertificateOrderDetectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}
        /// Operation Id: CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual Response<CertificateOrderDetectorResource> Get(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _certificateOrderDetectorCertificateOrdersDiagnosticsClientDiagnostics.CreateScope("CertificateOrderDetectorCollection.Get");
            scope.Start();
            try
            {
                var response = _certificateOrderDetectorCertificateOrdersDiagnosticsRestClient.GetAppServiceCertificateOrderDetectorResponse(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CertificateOrderDetectorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}
        /// Operation Id: CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _certificateOrderDetectorCertificateOrdersDiagnosticsClientDiagnostics.CreateScope("CertificateOrderDetectorCollection.Exists");
            scope.Start();
            try
            {
                var response = await _certificateOrderDetectorCertificateOrdersDiagnosticsRestClient.GetAppServiceCertificateOrderDetectorResponseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}
        /// Operation Id: CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual Response<bool> Exists(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectorName, nameof(detectorName));

            using var scope = _certificateOrderDetectorCertificateOrdersDiagnosticsClientDiagnostics.CreateScope("CertificateOrderDetectorCollection.Exists");
            scope.Start();
            try
            {
                var response = _certificateOrderDetectorCertificateOrdersDiagnosticsRestClient.GetAppServiceCertificateOrderDetectorResponse(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, detectorName, startTime, endTime, timeGrain, cancellationToken: cancellationToken);
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
