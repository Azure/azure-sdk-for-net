// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Factory class for creating Attestation Service Model types, used for Mocking.
    /// </summary>
    public static class AttestationModelFactory
    {
        /// <summary>
        /// Create an instance of an AttestationResponse object for mocking purposes.
        /// </summary>
        /// <typeparam name="T">Type of the token body.</typeparam>
        /// <param name="response">Response type associated with the underlying response.</param>
        /// <param name="token">Attestation Token to be included in the response.</param>
        /// <param name="body">Optional body instance. If no body is provided, the body of the token is used.</param>
        /// <remarks>The <paramref name="body"/> parameter is provided to create an attestation response whose Value property is something other than the body of the token.</remarks>
        /// <returns>An <see cref="Attestation.AttestationResponse"/> object.</returns>
        public static AttestationResponse<T> AttestationResponse<T>(Response response, AttestationToken token, T body = default(T))
            where T : class =>
            new AttestationResponse<T>(response, token, body);

        /// <summary> Initializes a new instance of AttestationResult for mocking purposes. </summary>
        /// <param name="jti"> Unique Identifier for the token. </param>
        /// <param name="issuer"> The Principal who issued the token. </param>
        /// <param name="issuedAt"> The time at which the token was issued, in the number of seconds since 1970-01-0T00:00:00Z UTC. </param>
        /// <param name="expiration"> The expiration time after which the token is no longer valid, in the number of seconds since 1970-01-0T00:00:00Z UTC. </param>
        /// <param name="notBefore"> The not before time before which the token cannot be considered valid, in the number of seconds since 1970-01-0T00:00:00Z UTC. </param>
        /// <param name="cnf"> An RFC 7800 Proof of Possession Key. </param>
        /// <param name="nonce"> The Nonce input to the attestation request, if provided. </param>
        /// <param name="version"> The Schema version of this structure. Current Value: 1.0. </param>
        /// <param name="runtimeClaims"> Runtime Claims. </param>
        /// <param name="inittimeClaims"> Inittime Claims. </param>
        /// <param name="policyClaims"> Policy Generated Claims. </param>
        /// <param name="verifierType"> The Attestation type being attested. </param>
        /// <param name="policySigner"> The certificate used to sign the policy object, if specified. </param>
        /// <param name="policyHash"> The SHA256 hash of the BASE64URL encoded policy text used for attestation. </param>
        /// <param name="isDebuggable"> True if the enclave is debuggable, false otherwise. </param>
        /// <param name="productId"> The SGX Product ID for the enclave. </param>
        /// <param name="mrEnclave"> The HEX encoded SGX MRENCLAVE value for the enclave. </param>
        /// <param name="mrSigner"> The HEX encoded SGX MRSIGNER value for the enclave. </param>
        /// <param name="svn"> The SGX SVN value for the enclave. </param>
        /// <param name="enclaveHeldData"> A copy of the RuntimeData specified as an input to the attest call. </param>
        /// <param name="sgxCollateral"> The SGX SVN value for the enclave. </param>
        /// <param name="deprecatedVersion"> DEPRECATED: Private Preview version of x-ms-ver claim. </param>
        /// <param name="deprecatedIsDebuggable"> DEPRECATED: Private Preview version of x-ms-sgx-is-debuggable claim. </param>
        /// <param name="deprecatedSgxCollateral"> DEPRECATED: Private Preview version of x-ms-sgx-collateral claim. </param>
        /// <param name="deprecatedEnclaveHeldData"> DEPRECATED: Private Preview version of x-ms-sgx-ehd claim. </param>
        /// <param name="deprecatedEnclaveHeldData2"> DEPRECATED: Private Preview version of x-ms-sgx-ehd claim. </param>
        /// <param name="deprecatedProductId"> DEPRECATED: Private Preview version of x-ms-sgx-product-id. </param>
        /// <param name="deprecatedMrEnclave"> DEPRECATED: Private Preview version of x-ms-sgx-mrenclave. </param>
        /// <param name="deprecatedMrSigner"> DEPRECATED: Private Preview version of x-ms-sgx-mrsigner. </param>
        /// <param name="deprecatedSvn"> DEPRECATED: Private Preview version of x-ms-sgx-svn. </param>
        /// <param name="deprecatedTee"> DEPRECATED: Private Preview version of x-ms-tee. </param>
        /// <param name="deprecatedPolicySigner"> DEPRECATED: Private Preview version of x-ms-policy-signer. </param>
        /// <param name="deprecatedPolicyHash"> DEPRECATED: Private Preview version of x-ms-policy-hash. </param>
        /// <param name="deprecatedRpData"> DEPRECATED: Private Preview version of nonce. </param>
        /// <returns>An <see cref="Attestation.AttestationResult"/> object.</returns>
        public static AttestationResult AttestationResult(
            string jti = null,
            string issuer = null,
            DateTimeOffset issuedAt = default,
            DateTimeOffset expiration = default,
            DateTimeOffset notBefore = default,
            object cnf = null,
            string nonce = null,
            string version = null,
            object runtimeClaims = null,
            object inittimeClaims = null,
            object policyClaims = null,
            string verifierType = null,
            AttestationSigner policySigner = null,
            BinaryData policyHash = null,
            bool? isDebuggable = null,
            float? productId = null,
            string mrEnclave = null,
            string mrSigner = null,
            float? svn = null,
            BinaryData enclaveHeldData = null,
            object sgxCollateral = null,
            string deprecatedVersion = null,
            bool? deprecatedIsDebuggable = null,
            object deprecatedSgxCollateral = null,
            BinaryData deprecatedEnclaveHeldData = null,
            BinaryData deprecatedEnclaveHeldData2 = null,
            float? deprecatedProductId = null,
            string deprecatedMrEnclave = null,
            string deprecatedMrSigner = null,
            float? deprecatedSvn = null,
            string deprecatedTee = null,
            AttestationSigner deprecatedPolicySigner = null,
            BinaryData deprecatedPolicyHash = null,
            string deprecatedRpData = null)
        {
            var policySignerJwk = JwkFromAttestationSigner(policySigner);
            var deprecatedPolicySignerJwk = JwkFromAttestationSigner(deprecatedPolicySigner);

            return new AttestationResult(jti,
                issuer,
                issuedAt.ToUnixTimeSeconds(),
                expiration.ToUnixTimeSeconds(),
                notBefore.ToUnixTimeSeconds(),
                cnf,
                nonce,
                version,
                runtimeClaims,
                inittimeClaims,
                policyClaims,
                verifierType,
                policySignerJwk,
                policyHash != null ? Base64Url.Encode(policyHash.ToArray()) : null,
                isDebuggable,
                productId,
                mrEnclave,
                mrSigner,
                svn,
                enclaveHeldData != null ? Base64Url.Encode(enclaveHeldData.ToArray()) : null,
                sgxCollateral,
                deprecatedVersion,
                deprecatedIsDebuggable,
                deprecatedSgxCollateral,
                deprecatedEnclaveHeldData != null ? Base64Url.Encode(deprecatedEnclaveHeldData.ToArray()) : null,
                deprecatedEnclaveHeldData != null ? Base64Url.Encode(deprecatedEnclaveHeldData2.ToArray()) : null,
                deprecatedProductId,
                deprecatedMrEnclave,
                deprecatedMrSigner,
                deprecatedSvn,
                deprecatedTee,
                deprecatedPolicySignerJwk,
                deprecatedPolicyHash != null ? Base64Url.Encode(deprecatedPolicyHash.ToArray()) : null,
                deprecatedRpData);
        }
        /// <summary>
        /// Creates a new instance of <see cref="Attestation.PolicyCertificatesModificationResult"/> for mocking purposes.
        /// </summary>
        /// <param name="certificateThumbprint">The thumbprint of the certificate which was modified.</param>
        /// <param name="certificateResolution">The modification which was performed.</param>
        /// <returns>A <see cref="Attestation.PolicyCertificatesModificationResult"/> object.</returns>
        public static PolicyCertificatesModificationResult PolicyCertificatesModificationResult(PolicyCertificateResolution certificateResolution, string certificateThumbprint) =>
            new PolicyCertificatesModificationResult(certificateThumbprint, certificateResolution);

        /// <summary>
        /// Create a PolicyModificationResult type for mocking purposes.
        /// </summary>
        /// <param name="policyModification">The policy Modification which has occurred.</param>
        /// <param name="policyHash">The SHA256 hash of the policy token which was modified</param>
        /// <param name="signer">The signer which was used to sign the token which modified the policy.</param>
        /// <returns></returns>
        public static PolicyModificationResult PolicyModificationResult(PolicyModification policyModification, string policyHash, AttestationSigner signer)
        {
            JsonWebKey jwk = JwkFromAttestationSigner(signer);
            return new PolicyModificationResult(policyModification, policyHash, jwk, null);
        }

        private static JsonWebKey JwkFromAttestationSigner(AttestationSigner signer)
        {
            JsonWebKey jwk = null;
            if (signer != null)
            {
                jwk = new JsonWebKey("RSA");
                jwk.Kid = signer.CertificateKeyId;
                foreach (var cert in signer.SigningCertificates)
                {
                    jwk.X5C.Add(Convert.ToBase64String(cert.Export(X509ContentType.Cert)));
                }
            }
            return jwk;
        }
    }
}
