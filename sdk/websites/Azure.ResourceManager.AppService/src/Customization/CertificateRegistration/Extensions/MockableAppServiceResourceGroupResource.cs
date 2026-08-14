// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceResourceGroupResource : ArmResource
    {
        /// <summary> Gets a collection of AppServiceCertificateOrderResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of AppServiceCertificateOrderResources and their operations over a AppServiceCertificateOrderResource. </returns>
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AppServiceCertificateOrderCollection GetAppServiceCertificateOrders()
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateOrderName"> Name of the certificate order.. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateOrderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="certificateOrderName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<AppServiceCertificateOrderResource>> GetAppServiceCertificateOrderAsync(string certificateOrderName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }

        /// <summary>
        /// Description for Get a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServiceCertificateOrders_Get</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServiceCertificateOrderResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateOrderName"> Name of the certificate order.. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="certificateOrderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="certificateOrderName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AppServiceCertificateOrderResource> GetAppServiceCertificateOrder(string certificateOrderName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace. Please use the same API from that namespace.");
        }
    }
}
