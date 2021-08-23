// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Enables configuration of options for the <see cref="HttpClientTransport"/>
    /// </summary>
    public class HttpPipelineTransportOptions
    {
        /// <summary>
        /// A delegate that validates the certificate presented by the server.
        /// </summary>
        public Func<X509Certificate2?, bool>? ServerCertificateCustomValidationCallback { get; set; }
    }
}
