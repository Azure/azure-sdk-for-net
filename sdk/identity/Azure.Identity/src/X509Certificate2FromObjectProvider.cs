// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// X509Certificate2FromObjectProvider provides an X509Certificate2 from an existing instance.
    /// </summary>
    internal class X509Certificate2FromObjectProvider : IX509Certificate2Provider
    {
        private X509Certificate2 Certificate { get; }

        public X509Certificate2FromObjectProvider(X509Certificate2 clientCertificate)
        {
            Certificate = clientCertificate ?? throw new ArgumentNullException(nameof(clientCertificate));
        }

        public ValueTask<X509Certificate2> GetCertificateAsync(bool async, CancellationToken cancellationToken)
        {
            return new ValueTask<X509Certificate2>(Certificate);
        }
    }
}
