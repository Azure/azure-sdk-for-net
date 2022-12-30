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
    /// A Class representing a CertificateOrderDetector along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="CertificateOrderDetectorResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetCertificateOrderDetectorResource method.
    /// Otherwise you can get one from its parent resource <see cref="AppServiceCertificateOrderResource" /> using the GetCertificateOrderDetector method.
    /// </summary>
    public partial class CertificateOrderDetectorResource : ArmResource
    {
        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}
        /// Operation Id: CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse
        /// </summary>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CertificateOrderDetectorResource>> GetAsync(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default) =>
            await GetAsync(new CertificateOrderDetectorResourceGetOptions
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}
        /// Operation Id: CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse
        /// </summary>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CertificateOrderDetectorResource> Get(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default) =>
            Get(new CertificateOrderDetectorResourceGetOptions
            {
                StartTime = startTime,
                EndTime = endTime,
                TimeGrain = timeGrain
            }, cancellationToken);
    }
}
