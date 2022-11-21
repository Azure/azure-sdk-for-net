// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DeviceProvisioningServices.Models;

namespace Azure.ResourceManager.DeviceProvisioningServices
{
    /// <summary>
    /// A Class representing a DeviceProvisioningServicesCertificate along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DeviceProvisioningServicesCertificateResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDeviceProvisioningServicesCertificateResource method.
    /// Otherwise you can get one from its parent resource <see cref="DeviceProvisioningServiceResource" /> using the GetDeviceProvisioningServicesCertificate method.
    /// </summary>
    public partial class DeviceProvisioningServicesCertificateResource : ArmResource
    {
        /// <summary>
        /// Deletes the specified certificate associated with the Provisioning Service
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}
        /// Operation Id: DpsCertificate_Delete
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

            using var scope = _deviceProvisioningServicesCertificateDpsCertificateClientDiagnostics.CreateScope("DeviceProvisioningServicesCertificateResource.Delete");
            scope.Start();
            try
            {
                var response = await _deviceProvisioningServicesCertificateDpsCertificateRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, certificateCommonName, certificateRawBytes, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken).ConfigureAwait(false);
                var operation = new DeviceProvisioningServicesArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified certificate associated with the Provisioning Service
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}
        /// Operation Id: DpsCertificate_Delete
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

            using var scope = _deviceProvisioningServicesCertificateDpsCertificateClientDiagnostics.CreateScope("DeviceProvisioningServicesCertificateResource.Delete");
            scope.Start();
            try
            {
                var response = _deviceProvisioningServicesCertificateDpsCertificateRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, certificateCommonName, certificateRawBytes, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken);
                var operation = new DeviceProvisioningServicesArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Generate verification code for Proof of Possession.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/generateVerificationCode
        /// Operation Id: DpsCertificate_GenerateVerificationCode
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

            using var scope = _deviceProvisioningServicesCertificateDpsCertificateClientDiagnostics.CreateScope("DeviceProvisioningServicesCertificateResource.GenerateVerificationCode");
            scope.Start();
            try
            {
                var response = await _deviceProvisioningServicesCertificateDpsCertificateRestClient.GenerateVerificationCodeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, certificateCommonName, certificateRawBytes, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Generate verification code for Proof of Possession.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/generateVerificationCode
        /// Operation Id: DpsCertificate_GenerateVerificationCode
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

            using var scope = _deviceProvisioningServicesCertificateDpsCertificateClientDiagnostics.CreateScope("DeviceProvisioningServicesCertificateResource.GenerateVerificationCode");
            scope.Start();
            try
            {
                var response = _deviceProvisioningServicesCertificateDpsCertificateRestClient.GenerateVerificationCode(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, certificateCommonName, certificateRawBytes, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the certificate&apos;s private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify
        /// Operation Id: DpsCertificate_VerifyCertificate
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

            using var scope = _deviceProvisioningServicesCertificateDpsCertificateClientDiagnostics.CreateScope("DeviceProvisioningServicesCertificateResource.VerifyCertificate");
            scope.Start();
            try
            {
                var response = await _deviceProvisioningServicesCertificateDpsCertificateRestClient.VerifyCertificateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, content, certificateCommonName, certificateRawBytes, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DeviceProvisioningServicesCertificateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the certificate&apos;s private key possession by providing the leaf cert issued by the verifying pre uploaded certificate.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify
        /// Operation Id: DpsCertificate_VerifyCertificate
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

            using var scope = _deviceProvisioningServicesCertificateDpsCertificateClientDiagnostics.CreateScope("DeviceProvisioningServicesCertificateResource.VerifyCertificate");
            scope.Start();
            try
            {
                var response = _deviceProvisioningServicesCertificateDpsCertificateRestClient.VerifyCertificate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, ifMatch, content, certificateCommonName, certificateRawBytes, certificateIsVerified, certificatePurpose, certificateCreatedOn, certificateLastUpdatedOn, certificateHasPrivateKey, certificateNonce, cancellationToken);
                return Response.FromValue(new DeviceProvisioningServicesCertificateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
