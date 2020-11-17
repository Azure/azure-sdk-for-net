// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Security.Attestation.Models
{
    /// <summary>
    /// Represents a Policy Get or Set or Reset result.
    /// </summary>
    public partial class PolicyResult
    {
        /// <summary>
        /// Resolution of the policy operation.
        /// </summary>
        public PolicyModification PolicyResolution { get; private set; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        [CodeGenMember("Policy")]
        internal /*AttestationToken<StoredAttestationPolicy> */ string BasePolicy { get; private set; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        public AttestationToken<StoredAttestationPolicy> Policy { get; private set; }


        [CodeGenMember("PolicyTokenHash")]
        internal /*byte[]*/string BasePolicyTokenHash { get; private set; }

        /// <summary>
        /// Hash of the specified policy token.
        /// </summary>
        public byte[] PolicyTokenHash { get; private set; }


        /// <summary>
        /// X.509 certificate used to sign the policy document.
        /// </summary>
        [CodeGenMember("PolicySigner")]
        internal string BasePolicySigner { get; private set; }

        /// <summary>
        /// X.509 certificate used to sign the policy document.
        /// </summary>
        public X509Certificate2 PolicySigner { get; private set; }

        internal static PolicyResult DeserializePolicyResult(JsonElement element)
        {
            string policy = default;
            PolicyModification policyModification = default;
            byte[] policyTokenHash = default;
            AttestationSigner policySigner = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("x-ms-policy"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    policy = property.Value.GetString();
                }

                if (property.NameEquals("x-ms-policy-signer"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    JsonWebKey jwk = JsonSerializer.Deserialize<JsonWebKey>(property.Value.GetString());
                    System.Collections.Generic.List<JsonWebKey> keys = new List<JsonWebKey> { jwk };

                    JsonWebKeySet jwks = new JsonWebKeySet(keys.ToArray());
                    policySigner = AttestationSigner.FromJsonWebKeySet(jwks)[0];
                }

                if (property.NameEquals("x-ms-policy-token-hash"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    policyTokenHash = property.Value.GetBytesFromBase64();
                }

                if (property.NameEquals("x-ms-policy-result"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    policyModification = new PolicyModification(property.Value.GetString());
                }
            }
            return new PolicyResult
            {
                Policy = new AttestationToken<StoredAttestationPolicy>(policy),
                PolicyResolution = policyModification,
                PolicyTokenHash = policyTokenHash,
                PolicySigner = policySigner?.SigningCertificates[0],
            };
        }
    }

}
