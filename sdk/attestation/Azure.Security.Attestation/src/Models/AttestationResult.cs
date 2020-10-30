// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Security.Attestation.Models
{
    public partial class AttestationResult
    {
        /// <summary>
        /// Returns the X.509 certificate used to sign the attestation policy, if one was provided.
        /// </summary>
        ///
        public X509Certificate2 PolicySigningCertificate { get; }

        /// <summary>
        /// Returns the X.509 certificate used to sign the attestation policy, if one was provided.
        /// </summary>
        ///
        public X509Certificate2 DeprecatedPolicySigner { get; }


        internal JsonWebKey PolicySigner { get; }
    }
}
