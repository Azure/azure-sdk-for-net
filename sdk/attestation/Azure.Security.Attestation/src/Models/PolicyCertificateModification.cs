// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents the body of a policy Add operation.
    /// </summary>
    [CodeGenType("AttestationCertificateManagementBody")]
    internal partial class PolicyCertificateModification
    {
        /// <summary>
        /// Creates a new attestation token based on the supplied body, certificateand private key.
        /// </summary>
        /// <param name="bodyCertificate"><see cref="X509Certificate2"/> to be encoded as a JSON Web Key in the body of the token.</param>
        internal PolicyCertificateModification(X509Certificate2 bodyCertificate)
            : this(new JsonWebKey(
                alg: "RS256",
                crv: null,
                d: null,
                dp: null,
                dq: null,
                e: null,
                k: null,
                kid: null,
                kty: "RSA",
                n: null,
                p: null,
                q: null,
                qi: null,
                use: "sig",
                x: null,
                x5c: new List<string> { Convert.ToBase64String(bodyCertificate.Export(X509ContentType.Cert)) },
                y: null,
                additionalBinaryDataProperties: null))
        {
        }

        /// <summary>
        /// Represents the policy management certificate to be added or removed.
        /// </summary>
        internal X509Certificate2 PolicyCertificate { get; }
    }
}
