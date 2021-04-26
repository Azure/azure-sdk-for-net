// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents the body of a policy Add operation.
    /// </summary>
    [CodeGenModel("AttestationCertificateManagementBody")]
    internal partial class PolicyCertificateModification
    {
        /// <summary>
        /// Creates a new attestation token based on the supplied body, certificateand private key.
        /// </summary>
        /// <param name="bodyCertificate"><see cref="X509Certificate2"/> to be encoded as a JSON Web Key in the body of the token.</param>
        internal PolicyCertificateModification(X509Certificate2 bodyCertificate)
        {
            InternalPolicyCertificate = new JsonWebKey(kty: "RSA")
            {
                Alg = "RS256",
                Use = "sig",
            };
            InternalPolicyCertificate.X5C.Add(Convert.ToBase64String(bodyCertificate.Export(X509ContentType.Cert)));
        }

        /// <summary>
        /// Represents the policy management certificate to be added or removed.
        /// </summary>
        internal X509Certificate2 PolicyCertificate { get; }

        [CodeGenMember("PolicyCertificate")]
        internal JsonWebKey InternalPolicyCertificate { get; }
    }
}
