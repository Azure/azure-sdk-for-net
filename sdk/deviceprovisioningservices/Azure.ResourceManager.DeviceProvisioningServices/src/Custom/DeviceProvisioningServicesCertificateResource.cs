// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.DeviceProvisioningServices.Models;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class DeviceProvisioningServicesCertificateResource
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
        /// <description>DpsCertificate_Delete</description>
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
        /// <param name="certificateLastUpdatedOn"> Time the certificate is last updated. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains a private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = null, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = null, DateTimeOffset? certificateCreatedOn = null, DateTimeOffset? certificateLastUpdatedOn = null, bool? certificateHasPrivateKey = null, string certificateNonce = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            DeviceProvisioningServicesCertificateResourceDeleteOptions options = new DeviceProvisioningServicesCertificateResourceDeleteOptions(ifMatch);
            options.CertificateCommonName = certificateCommonName;
            options.CertificateIsVerified = certificateIsVerified;
            options.CertificatePurpose = certificatePurpose;
            options.CertificateCreatedOn = certificateCreatedOn;
            options.CertificateLastUpdatedOn = certificateLastUpdatedOn;
            options.CertificateHasPrivateKey = certificateHasPrivateKey;
            options.CertificateNonce = certificateNonce;

            return await DeleteAsync(waitUntil, options, cancellationToken).ConfigureAwait(false);
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
        /// <description>DpsCertificate_Delete</description>
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
        /// <param name="certificateLastUpdatedOn"> Time the certificate is last updated. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains a private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = null, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = null, DateTimeOffset? certificateCreatedOn = null, DateTimeOffset? certificateLastUpdatedOn = null, bool? certificateHasPrivateKey = null, string certificateNonce = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            DeviceProvisioningServicesCertificateResourceDeleteOptions options = new DeviceProvisioningServicesCertificateResourceDeleteOptions(ifMatch);
            options.CertificateCommonName = certificateCommonName;
            options.CertificateIsVerified = certificateIsVerified;
            options.CertificatePurpose = certificatePurpose;
            options.CertificateCreatedOn = certificateCreatedOn;
            options.CertificateLastUpdatedOn = certificateLastUpdatedOn;
            options.CertificateHasPrivateKey = certificateHasPrivateKey;
            options.CertificateNonce = certificateNonce;

            return Delete(waitUntil, options, cancellationToken);
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
        /// <description>DpsCertificate_GenerateVerificationCode</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Description mentioning the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Certificate creation time. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual async Task<Response<CertificateVerificationCodeResult>> GenerateVerificationCodeAsync(string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = null, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = null, DateTimeOffset? certificateCreatedOn = null, DateTimeOffset? certificateLastUpdatedOn = null, bool? certificateHasPrivateKey = null, string certificateNonce = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions options = new DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions(ifMatch);
            options.CertificateCommonName = certificateCommonName;
            options.CertificateRawBytes = certificateRawBytes;
            options.CertificateIsVerified = certificateIsVerified;
            options.CertificatePurpose = certificatePurpose;
            options.CertificateCreatedOn = certificateCreatedOn;
            options.CertificateLastUpdatedOn = certificateLastUpdatedOn;
            options.CertificateHasPrivateKey = certificateHasPrivateKey;
            options.CertificateNonce = certificateNonce;

            return await GenerateVerificationCodeAsync(options, cancellationToken).ConfigureAwait(false);
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
        /// <description>DpsCertificate_GenerateVerificationCode</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. This is required to update an existing certificate, and ignored while creating a brand new certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Description mentioning the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Certificate creation time. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public virtual Response<CertificateVerificationCodeResult> GenerateVerificationCode(string ifMatch, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = null, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = null, DateTimeOffset? certificateCreatedOn = null, DateTimeOffset? certificateLastUpdatedOn = null, bool? certificateHasPrivateKey = null, string certificateNonce = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions options = new DeviceProvisioningServicesCertificateResourceGenerateVerificationCodeOptions(ifMatch);
            options.CertificateCommonName = certificateCommonName;
            options.CertificateRawBytes = certificateRawBytes;
            options.CertificateIsVerified = certificateIsVerified;
            options.CertificatePurpose = certificatePurpose;
            options.CertificateCreatedOn = certificateCreatedOn;
            options.CertificateLastUpdatedOn = certificateLastUpdatedOn;
            options.CertificateHasPrivateKey = certificateHasPrivateKey;
            options.CertificateNonce = certificateNonce;

            return GenerateVerificationCode(options, cancellationToken);
        }

        /// <summary>
        /// Verifies the certificate&apos;s private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DpsCertificate_VerifyCertificate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="content"> The name of the certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Describe the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Certificate creation time. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<DeviceProvisioningServicesCertificateResource>> VerifyCertificateAsync(string ifMatch, CertificateVerificationCodeContent content, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = null, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = null, DateTimeOffset? certificateCreatedOn = null, DateTimeOffset? certificateLastUpdatedOn = null, bool? certificateHasPrivateKey = null, string certificateNonce = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));
            Argument.AssertNotNull(content, nameof(content));

            DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions options = new DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions(ifMatch, content);
            options.CertificateCommonName = certificateCommonName;
            options.CertificateRawBytes = certificateRawBytes;
            options.CertificateIsVerified = certificateIsVerified;
            options.CertificatePurpose = certificatePurpose;
            options.CertificateCreatedOn = certificateCreatedOn;
            options.CertificateLastUpdatedOn = certificateLastUpdatedOn;
            options.CertificateHasPrivateKey = certificateHasPrivateKey;
            options.CertificateNonce = certificateNonce;

            return await VerifyCertificateAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Verifies the certificate&apos;s private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DpsCertificate_VerifyCertificate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> ETag of the certificate. </param>
        /// <param name="content"> The name of the certificate. </param>
        /// <param name="certificateCommonName"> Common Name for the certificate. </param>
        /// <param name="certificateRawBytes"> Raw data of certificate. </param>
        /// <param name="certificateIsVerified"> Indicates if the certificate has been verified by owner of the private key. </param>
        /// <param name="certificatePurpose"> Describe the purpose of the certificate. </param>
        /// <param name="certificateCreatedOn"> Certificate creation time. </param>
        /// <param name="certificateLastUpdatedOn"> Certificate last updated time. </param>
        /// <param name="certificateHasPrivateKey"> Indicates if the certificate contains private key. </param>
        /// <param name="certificateNonce"> Random number generated to indicate Proof of Possession. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<DeviceProvisioningServicesCertificateResource> VerifyCertificate(string ifMatch, CertificateVerificationCodeContent content, string certificateCommonName = null, byte[] certificateRawBytes = null, bool? certificateIsVerified = null, DeviceProvisioningServicesCertificatePurpose? certificatePurpose = null, DateTimeOffset? certificateCreatedOn = null, DateTimeOffset? certificateLastUpdatedOn = null, bool? certificateHasPrivateKey = null, string certificateNonce = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));
            Argument.AssertNotNull(content, nameof(content));

            DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions options = new DeviceProvisioningServicesCertificateResourceVerifyCertificateOptions(ifMatch, content);
            options.CertificateCommonName = certificateCommonName;
            options.CertificateRawBytes = certificateRawBytes;
            options.CertificateIsVerified = certificateIsVerified;
            options.CertificatePurpose = certificatePurpose;
            options.CertificateCreatedOn = certificateCreatedOn;
            options.CertificateLastUpdatedOn = certificateLastUpdatedOn;
            options.CertificateHasPrivateKey = certificateHasPrivateKey;
            options.CertificateNonce = certificateNonce;

            return VerifyCertificate(options, cancellationToken);
        }
    }
}
