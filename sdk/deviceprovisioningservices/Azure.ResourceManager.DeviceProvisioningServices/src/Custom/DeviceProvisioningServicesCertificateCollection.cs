// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class DeviceProvisioningServicesCertificateCollection
    {
        /// <summary>
        /// Add new certificate or update an existing certificate.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceProvisioningServicesCertificateResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string certificateName, DeviceProvisioningServicesCertificateData data, string ifMatch, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, certificateName, data, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Add new certificate or update an existing certificate.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceProvisioningServicesCertificateResource> CreateOrUpdate(WaitUntil waitUntil, string certificateName, DeviceProvisioningServicesCertificateData data, string ifMatch, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, certificateName, data, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);

        /// <summary>
        /// Get the certificate from the provisioning service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeviceProvisioningServicesCertificateResource>> GetAsync(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => await GetAsync(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the certificate from the provisioning service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeviceProvisioningServicesCertificateResource> Get(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => Get(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => await ExistsAsync(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => Exists(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DeviceProvisioningServicesCertificateResource>> GetIfExistsAsync(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => await GetIfExistsAsync(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> CertificateResponses_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="certificateName"> Name of the certificate to retrieve. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="certificateName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="certificateName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DeviceProvisioningServicesCertificateResource> GetIfExists(string certificateName, string ifMatch, CancellationToken cancellationToken = default)
            => GetIfExists(certificateName, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);
    }
}
