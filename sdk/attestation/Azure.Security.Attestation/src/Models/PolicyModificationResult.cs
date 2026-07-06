// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a Policy Get or Set or Reset result.
    /// </summary>
    [CodeGenType("PolicyResult")]
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
        public PolicyModification PolicyResolution { get => BasePolicyResolution ?? default; }

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

        [CodeGenMember("PolicyResolution")]
        internal PolicyModification? BasePolicyResolution { get; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        [CodeGenMember("Policy")]
        internal string BasePolicy { get; }

        /// <summary>
        /// JSON Web Token containing the policy retrieved.
        /// </summary>
        internal AttestationToken PolicyToken { get => AttestationToken.Deserialize(BasePolicy); }

        /// <summary>
        /// X.509 certificate used to sign the policy document.
        /// </summary>
        [CodeGenMember("PolicySigner")]
        internal JsonWebKey BasePolicySigner { get; }
    }
}
