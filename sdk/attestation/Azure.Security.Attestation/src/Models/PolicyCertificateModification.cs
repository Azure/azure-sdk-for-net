// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;

namespace Azure.Security.Attestation.Models
{
    /// <summary>
    /// Represents the body of a policy Add operation.
    /// </summary>
    [CodeGenModel("AttestationCertificateManagementBody")]
    [JsonConverter(typeof(PolicyCertificateModificationConverter))]
    public partial class PolicyCertificateModification
    {
        /// <summary>
        /// Creates a new attestation token based on the supplied body, certificateand private key.
        /// </summary>
        /// <param name="bodyCertificate"><see cref="X509Certificate2"/> to be encoded as a JSON Web Key in the body of the token.</param>
        public PolicyCertificateModification(X509Certificate2 bodyCertificate)
        {
            this.InternalPolicyCertificate = new JsonWebKey(
                    alg: "RS256",
                    kty: "RSA",
                    use: "sig",
                    x5C: new string[] { Convert.ToBase64String(bodyCertificate.Export(X509ContentType.Cert)) },
                    crv: "",
                    d: "",
                    dp: "",
                    dq: "",
                    e: "",
                    k: "",
                    kid: "",
                    n: "",
                    p: "",
                    q: "",
                    qi: "",
                    x: "",
                    y: "");
        }

        /// <summary>
        /// Represents the policy management certificate to be added or removed.
        /// </summary>
        public X509Certificate2 PolicyCertificate { get; }

        [CodeGenMember("PolicyCertificate")]
        internal JsonWebKey InternalPolicyCertificate { get; }
    }
}
