// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing an AppServiceCertificateOrder along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="AppServiceCertificateOrderResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetAppServiceCertificateOrderResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetAppServiceCertificateOrder method.
    /// </summary>
    public partial class AppServiceCertificateOrderResource : ArmResource
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
        [ForwardsClientCalls]
        public virtual async Task<Response<CertificateOrderDetectorResource>> GetCertificateOrderDetectorAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            CertificateOrderDetectorGetOptions options = new CertificateOrderDetectorGetOptions
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            };

            return await GetCertificateOrderDetectors().GetAsync(detectorName, options, cancellationToken).ConfigureAwait(false);
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
        [ForwardsClientCalls]
        public virtual Response<CertificateOrderDetectorResource> GetCertificateOrderDetector(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            CertificateOrderDetectorGetOptions options = new CertificateOrderDetectorGetOptions
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            };

            return GetCertificateOrderDetectors().Get(detectorName, options, cancellationToken);
        }
    }
}
