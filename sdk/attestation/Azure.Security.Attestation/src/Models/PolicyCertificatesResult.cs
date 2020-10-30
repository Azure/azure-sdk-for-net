// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Azure.Security.Attestation.Models
{
    public partial class PolicyCertificatesResult
    {
        /// <summary>
        /// Returns the X.509 certificates used to manage policy on the instance.
        /// </summary>
        public IEnumerable<System.Security.Cryptography.X509Certificates.X509Certificate2> PolicyCertificates
        { get; private set; }
    }

}
