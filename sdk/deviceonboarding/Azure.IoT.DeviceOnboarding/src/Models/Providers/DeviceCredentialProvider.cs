// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Security.Cryptography.Cose;

namespace Azure.IoT.DeviceOnboarding.Models.Providers
{
    /// <summary>
    /// Interface for consumer to provide implementations around managing device credentials
    /// </summary>
    public abstract class DeviceCredentialProvider
    {
        /// <summary>
        /// Retrieve or create the device certificate used for device credentials
        /// </summary>
        /// <returns></returns>
        public abstract CertChain GetDeviceCertificate();

        /// <summary>
        ///Get Hash from CertChain
        /// </summary>
        /// <param name="certChain"></param>
        /// <returns></returns>
        public abstract Hash GetCertChainHash(CertChain certChain);

        /// <summary>
        ///Get Hash using HMAC
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="keySize"></param>
        /// <param name="keyIdenitifier"></param>
        /// <returns></returns>
        public abstract Hash GetHMAC(byte[] payload, KeySize keySize, string keyIdenitifier);

        /// <summary>
        /// Create signed CoseSign1Message
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="unprotectedHeaders"></param>
        /// <param name="privateKeyToSign"></param>
        /// <param name="publicKeyType"></param>
        /// <returns></returns>
        public abstract CoseSign1Message CreateCoseSign1Message(byte[] payload, CoseHeaderMap unprotectedHeaders, PublicKeyType publicKeyType, AsymmetricAlgorithm privateKeyToSign = null);

        /// <summary>
        /// Retrieve or create device credentials
        /// </summary>
        /// <returns></returns>
        public abstract DeviceCredential GetDeviceCredentials(RendezvousInfo rvInfo = null);

        /// <summary>
        /// Save device credentials
        /// </summary>
        /// <param name="deviceCreds"></param>
        public abstract void SetDeviceCredentials(DeviceCredential deviceCreds);
    }
}
