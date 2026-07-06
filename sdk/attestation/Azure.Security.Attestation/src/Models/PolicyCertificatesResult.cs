// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    [CodeGenType("PolicyCertificatesResult")]
    internal partial class PolicyCertificatesResult
    {
        private IReadOnlyList<X509Certificate2> _certificateList;
        private object _statelock = new object();

        /// <summary>
        /// Returns the list of policy management certificates for this attestation instance.
        /// </summary>
        /// <returns>A list of <see cref="X509Certificate2"/> certificates which are used to sign incoming requests.</returns>
        public IReadOnlyList<X509Certificate2> GetPolicyCertificates()
        {
            lock (_statelock)
            {
                if (_certificateList == null)
                {
                    List<X509Certificate2> certificates = new List<X509Certificate2>();
                    foreach (var key in PolicyCertificates.Keys)
                    {
                        if (key.X5c == null)
                        {
                            // the key returned must have a X5c property.
                            throw new InvalidOperationException(Azure_Security_Attestation.PolicyCertificatesRequireX5C);
                        }
#if NET9_0_OR_GREATER
                        certificates.Add(X509CertificateLoader.LoadCertificate(Convert.FromBase64String(key.X5c[0])));
#else
                        certificates.Add(new X509Certificate2(Convert.FromBase64String(key.X5c[0])));
#endif
                    }
                    _certificateList = certificates;
                }
                return _certificateList;
            }
        }
    }
}
