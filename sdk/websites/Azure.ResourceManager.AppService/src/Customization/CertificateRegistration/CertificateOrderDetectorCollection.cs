// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing a collection of <see cref="CertificateOrderDetectorResource"/> and their operations.
    /// Each <see cref="CertificateOrderDetectorResource"/> in the collection will belong to the same instance of <see cref="AppServiceCertificateOrderResource"/>.
    /// To get a <see cref="CertificateOrderDetectorCollection"/> instance call the GetCertificateOrderDetectors method from an instance of <see cref="AppServiceCertificateOrderResource"/>.
    /// </summary>
    [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CertificateOrderDetectorCollection : ArmCollection, IEnumerable<CertificateOrderDetectorResource>, IAsyncEnumerable<CertificateOrderDetectorResource>
    {
        /// <summary> Initializes a new instance of the <see cref="CertificateOrderDetectorCollection"/> class for mocking. </summary>
        protected CertificateOrderDetectorCollection()
        {
        }

        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
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
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Microsoft.CertificateRegistration call to get a detector response from App Lens.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
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
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Microsoft.CertificateRegistration to get the list of detectors for this RP.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_ListAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CertificateOrderDetectorResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CertificateOrderDetectorResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Microsoft.CertificateRegistration to get the list of detectors for this RP.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_ListAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CertificateOrderDetectorResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CertificateOrderDetectorResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
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
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
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
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual async Task<NullableResponse<CertificateOrderDetectorResource>> GetIfExistsAsync(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/detectors/{detectorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateOrdersDiagnostics_GetAppServiceCertificateOrderDetectorResponse</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CertificateOrderDetectorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="detectorName"> The detector name which needs to be run. </param>
        /// <param name="startTime"> The start time for detector response. </param>
        /// <param name="endTime"> The end time for the detector response. </param>
        /// <param name="timeGrain"> The time grain for the detector response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="detectorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="detectorName"/> is null. </exception>
        public virtual NullableResponse<CertificateOrderDetectorResource> GetIfExists(string detectorName, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string timeGrain = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        IEnumerator<CertificateOrderDetectorResource> IEnumerable<CertificateOrderDetectorResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CertificateOrderDetectorResource> IAsyncEnumerable<CertificateOrderDetectorResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
