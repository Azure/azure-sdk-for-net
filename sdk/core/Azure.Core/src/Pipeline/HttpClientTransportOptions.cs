// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Enables configuration of options for the <see cref="HttpClientTransport"/>
    /// </summary>
    public class HttpClientTransportOptions
    {
        /// <summary>
        /// A callback that defines whether to validate the certificate presented by the server.
        /// </summary>
        public Func<X509Certificate2?, bool>? ServerCertificateCustomValidationCallback { get; set; }

        /// <summary>
        /// If <c>true</c>, all service certificates are treated as trusted.
        /// </summary>
        public bool TrustAllServerCertificates { get; set; }
    }
}
