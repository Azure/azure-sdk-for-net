// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary> Response from the identity service containing the TLS cert. </summary>
    public partial class ServiceIdentityResult
    {
        /// <summary> Initializes a new instance of <see cref="ServiceIdentityResult"/>. </summary>
        /// <param name="ledgerTlsCertificate"> String representing the service certificate. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ledgerTlsCertificate"/> is null. </exception>
        internal ServiceIdentityResult(string ledgerTlsCertificate)
        {
            Argument.AssertNotNull(ledgerTlsCertificate, nameof(ledgerTlsCertificate));

            TlsCertificatePem = ledgerTlsCertificate;
            CreatedAt = DateTime.Now;
        }

        /// <summary> String representing the PEM encoded TLS cert. </summary>
        public string TlsCertificatePem { get; }

        /// <summary> The time this class was created to be used in cache. </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Parses the PEM certificate string to the X509Certificate2.
        /// </summary>
        public X509Certificate2 GetCertificate()
        {
            return PemReader.LoadCertificate(TlsCertificatePem.AsSpan(), null, PemReader.KeyType.Auto, true);
        }
    }
}
