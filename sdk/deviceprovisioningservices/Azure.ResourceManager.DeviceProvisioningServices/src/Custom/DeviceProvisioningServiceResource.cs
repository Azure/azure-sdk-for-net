// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class DeviceProvisioningServiceResource
    {
        /// <summary> Get the certificate from the provisioning service. </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<DeviceProvisioningServicesCertificateResource>> GetDeviceProvisioningServicesCertificateAsync(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => await GetDeviceProvisioningServicesCertificateAsync(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary> Get the certificate from the provisioning service. </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DeviceProvisioningServicesCertificateResource> GetDeviceProvisioningServicesCertificate(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => GetDeviceProvisioningServicesCertificate(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);
    }
}
