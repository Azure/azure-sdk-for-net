// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Azure.Core;
using System.Runtime.CompilerServices;
using System;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a Policy Get or Set or Reset result.
    /// </summary>
    [CodeGenModel("PolicyResult")]
    public partial class PolicyModificationResult
    {
        /// <summary>
        /// Creates a new instance of a <see cref="PolicyModificationResult"/> object.
        /// </summary>
        public PolicyModificationResult()
        {
        }

        /// <summary>
        /// Resolution of the policy operation.
        /// </summary>
        public PolicyModification PolicyResolution { get; private set; }

        /// <summary>
        /// Signing Certificate used to set the policy.
        /// </summary>
        public AttestationSigner PolicySigner
        {
            get
            {
                if (BasePolicySigner != null)
                {
                    return AttestationSigner.FromJsonWebKey(BasePolicySigner);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Hash of the Base64Url encoded policy text. Calculated as SHA256(PolicySetToken).
        /// </summary>
        public BinaryData PolicyTokenHash { get => BasePolicyTokenHash != null ? BinaryData.FromBytes(Base64Url.Decode(BasePolicyTokenHash)) : null; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        [CodeGenMember("Policy")]
        internal string BasePolicy { get; private set; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        internal AttestationToken PolicyToken { get => AttestationToken.Deserialize(BasePolicy); }

        [CodeGenMember("PolicyTokenHash")]
        internal string BasePolicyTokenHash { get; private set; }

        /// <summary>
        /// X.509 certificate used to sign the policy document.
        /// </summary>
        [CodeGenMember("PolicySigner")]
        internal JsonWebKey BasePolicySigner { get; private set; }
    }
}
