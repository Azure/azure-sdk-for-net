// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Azure.Security.Attestation.Models
{
    public partial class PolicyResult
    {
        /// <summary>
        /// Returns the X.509 certificate used to sign the attestation policy, if one was provided.
        /// </summary>
        public X509Certificate2 PolicySigner { get; }
    }
}
