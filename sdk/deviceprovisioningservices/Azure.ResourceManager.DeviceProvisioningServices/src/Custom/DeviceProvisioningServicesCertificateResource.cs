// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DeviceProvisioningServices.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class DeviceProvisioningServicesCertificateResource : ArmResource
    {
        /// <summary>
        /// Deletes the specified certificate associated with the Provisioning Service
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponse_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, DeviceProvisioningServicesCertificateResourceDeleteOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return await this.DeleteAsync(
                waitUntil,
                options.IfMatch,
                options.CertificateCommonName,
                options.CertificateRawBytes != null ? BinaryData.FromBytes(options.CertificateRawBytes) : null,
                options.CertificateIsVerified,
                options.CertificatePurpose,
                options.CertificateCreatedOn,
                options.CertificateLastUpdatedOn,
                options.CertificateHasPrivateKey,
                options.CertificateNonce,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the specified certificate associated with the Provisioning Service
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponse_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, DeviceProvisioningServicesCertificateResourceDeleteOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return this.Delete(
                waitUntil,
                options.IfMatch,
                options.CertificateCommonName,
                options.CertificateRawBytes != null ? BinaryData.FromBytes(options.CertificateRawBytes) : null,
                options.CertificateIsVerified,
                options.CertificatePurpose,
                options.CertificateCreatedOn,
                options.CertificateLastUpdatedOn,
                options.CertificateHasPrivateKey,
                options.CertificateNonce,
                cancellationToken);
        }

        /// <summary>
        /// Generate verification code for Proof of Possession.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/generateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_GenerateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<CertificateVerificationCodeResult>> GenerateVerificationCodeAsync(DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return await GenerateVerificationCodeAsync(
                options.IfMatch,
                options.CertificateCommonName,
                options.CertificateRawBytes != null ? BinaryData.FromBytes(options.CertificateRawBytes) : null,
                options.CertificateIsVerified,
                options.CertificatePurpose,
                options.CertificateCreatedOn,
                options.CertificateLastUpdatedOn,
                options.CertificateHasPrivateKey,
                options.CertificateNonce,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Generate verification code for Proof of Possession.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/generateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_GenerateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CertificateVerificationCodeResult> GenerateVerificationCode(DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return GenerateVerificationCode(
                options.IfMatch,
                options.CertificateCommonName,
                options.CertificateRawBytes != null ? BinaryData.FromBytes(options.CertificateRawBytes) : null,
                options.CertificateIsVerified,
                options.CertificatePurpose,
                options.CertificateCreatedOn,
                options.CertificateLastUpdatedOn,
                options.CertificateHasPrivateKey,
                options.CertificateNonce,
                cancellationToken);
        }

        /// <summary>
        /// Verifies the certificate's private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_VerifyCertificate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeviceProvisioningServicesCertificateResource>> VerifyCertificateAsync(DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return await VerifyCertificateAsync(
                options.IfMatch,
                options.Content,
                options.CertificateCommonName,
                options.CertificateRawBytes != null ? BinaryData.FromBytes(options.CertificateRawBytes) : null,
                options.CertificateIsVerified,
                options.CertificatePurpose,
                options.CertificateCreatedOn,
                options.CertificateLastUpdatedOn,
                options.CertificateHasPrivateKey,
                options.CertificateNonce,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Verifies the certificate's private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_VerifyCertificate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeviceProvisioningServicesCertificateResource> VerifyCertificate(DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return VerifyCertificate(
                options.IfMatch,
                options.Content,
                options.CertificateCommonName,
                options.CertificateRawBytes != null ? BinaryData.FromBytes(options.CertificateRawBytes) : null,
                options.CertificateIsVerified,
                options.CertificatePurpose,
                options.CertificateCreatedOn,
                options.CertificateLastUpdatedOn,
                options.CertificateHasPrivateKey,
                options.CertificateNonce,
                cancellationToken);
        }

        /// <summary>
        /// Get the certificate from the provisioning service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeviceProvisioningServicesCertificateResource>> GetAsync(string ifMatch, CancellationToken cancellationToken = default)
            => await GetAsync(ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get the certificate from the provisioning service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeviceProvisioningServicesCertificateResource> Get(string ifMatch, CancellationToken cancellationToken = default)
            => Get(ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);

        /// <summary>
        /// Update a DeviceProvisioningServicesCertificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DeviceProvisioningServicesCertificateResource>> UpdateAsync(WaitUntil waitUntil, DeviceProvisioningServicesCertificateData data, string ifMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Update a DeviceProvisioningServicesCertificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The certificate body. </param>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DeviceProvisioningServicesCertificateResource> Update(WaitUntil waitUntil, DeviceProvisioningServicesCertificateData data, string ifMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : null, cancellationToken);

        /// <summary>
        /// Deletes the specified certificate associated with the Provisioning Service
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="certificateCommonName"> This is optional, and it is the Common Name of the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data within the certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> A description that mentions the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Time the certificate is created. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains a private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, string certificateCommonName, byte[] certificateRawBytes, bool? certificateIsVerified = default, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default, DateTimeOffset? certificateCreatedOn = default, DateTimeOffset? certificateLastUpdatedOn = default, bool? certificateHasPrivateKey = default, string certificateNonce = default, CancellationToken cancellationToken = default)
            => await DeleteAsync(waitUntil, ifMatch, certificateCommonName, certificateRawBytes != null ? BinaryData.FromBytes(certificateRawBytes) : null, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes the specified certificate associated with the Provisioning Service
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="certificateCommonName"> This is optional, and it is the Common Name of the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data within the certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> A description that mentions the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Time the certificate is created. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains a private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, string certificateCommonName, byte[] certificateRawBytes, bool? certificateIsVerified = default, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default, DateTimeOffset? certificateCreatedOn = default, DateTimeOffset? certificateLastUpdatedOn = default, bool? certificateHasPrivateKey = default, string certificateNonce = default, CancellationToken cancellationToken = default)
            => Delete(waitUntil, ifMatch, certificateCommonName, certificateRawBytes != null ? BinaryData.FromBytes(certificateRawBytes) : null, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken);

        /// <summary>
        /// Generate verification code for Proof of Possession.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/generateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_GenerateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Description mentioning the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Time the certificate is created. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<CertificateVerificationCodeResult>> GenerateVerificationCodeAsync(string ifMatch, string certificateCommonName, byte[] certificateRawBytes, bool? certificateIsVerified = default, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default, DateTimeOffset? certificateCreatedOn = default, DateTimeOffset? certificateLastUpdatedOn = default, bool? certificateHasPrivateKey = default, string certificateNonce = default, CancellationToken cancellationToken = default)
            => await GenerateVerificationCodeAsync(ifMatch, certificateCommonName, certificateRawBytes != null ? BinaryData.FromBytes(certificateRawBytes) : null, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Generate verification code for Proof of Possession.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/generateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_GenerateVerificationCode</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Description mentioning the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Time the certificate is created. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CertificateVerificationCodeResult> GenerateVerificationCode(string ifMatch, string certificateCommonName, byte[] certificateRawBytes, bool? certificateIsVerified = default, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default, DateTimeOffset? certificateCreatedOn = default, DateTimeOffset? certificateLastUpdatedOn = default, bool? certificateHasPrivateKey = default, string certificateNonce = default, CancellationToken cancellationToken = default)
            => GenerateVerificationCode(ifMatch, certificateCommonName, certificateRawBytes != null ? BinaryData.FromBytes(certificateRawBytes) : null, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken);

        /// <summary>
        /// Verifies the certificate's private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_VerifyCertificate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="content"> The name of the certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Describe the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Time the certificate is created. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeviceProvisioningServicesCertificateResource>> VerifyCertificateAsync(string ifMatch, CertificateVerificationCodeContent content, string certificateCommonName, byte[] certificateRawBytes, bool? certificateIsVerified = default, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default, DateTimeOffset? certificateCreatedOn = default, DateTimeOffset? certificateLastUpdatedOn = default, bool? certificateHasPrivateKey = default, string certificateNonce = default, CancellationToken cancellationToken = default)
            => await VerifyCertificateAsync(ifMatch, content, certificateCommonName, certificateRawBytes != null ? BinaryData.FromBytes(certificateRawBytes) : null, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Verifies the certificate's private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CertificateResponses_VerifyCertificate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DeviceProvisioningServicesCertificateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="content"> The name of the certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Describe the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Time the certificate is created. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeviceProvisioningServicesCertificateResource> VerifyCertificate(string ifMatch, CertificateVerificationCodeContent content, string certificateCommonName, byte[] certificateRawBytes, bool? certificateIsVerified = default, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = default, DateTimeOffset? certificateCreatedOn = default, DateTimeOffset? certificateLastUpdatedOn = default, bool? certificateHasPrivateKey = default, string certificateNonce = default, CancellationToken cancellationToken = default)
            => VerifyCertificate(ifMatch, content, certificateCommonName, certificateRawBytes != null ? BinaryData.FromBytes(certificateRawBytes) : null, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken);
    }
}
