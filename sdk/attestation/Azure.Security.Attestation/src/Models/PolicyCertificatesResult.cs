// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Security.Attestation.Models
{
    [JsonConverter(typeof(PolicyCertificatesResultConverter))]
    public partial class PolicyCertificatesResult
    {
        private IReadOnlyList<X509Certificate2> _certificateList;
        private object _statelock = new object();

        /// <summary>
        /// Creates a new instance of a <see cref="PolicyCertificatesResult"/> object.
        /// </summary>
        public PolicyCertificatesResult()
        {
        }

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
                    foreach (var key in InternalPolicyCertificates.Keys)
                    {
                        if (key.X5C == null)
                        {
                            // the key returned must have a X5c property.
                            throw new InvalidOperationException(Azure_Security_Attestation.PolicyCertificatesRequireX5C);
                        }
                        certificates.Add(new X509Certificate2(Convert.FromBase64String(key.X5C[0])));
                    }
                    _certificateList = certificates;
                }
                return _certificateList;
            }
        }

        /// <summary>
        /// Returns the X.509 certificates used to manage policy on the instance.
        /// </summary>
        [CodeGenMember("PolicyCertificates")]
        internal JsonWebKeySet InternalPolicyCertificates
        { get; private set; }
    }
}
