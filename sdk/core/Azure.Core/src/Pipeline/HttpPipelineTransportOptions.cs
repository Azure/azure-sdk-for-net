// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Enables configuration of options for the <see cref="HttpClientTransport"/>
    /// </summary>
    public class HttpPipelineTransportOptions
    {
        /// <summary>
        /// Initializes an instance of <see cref="HttpPipelineTransportOptions"/>.
        /// </summary>
        public HttpPipelineTransportOptions()
        {
            // suppress false positive of NetAnalyzers: error CA1416: This call site is reachable on all platforms. 'X509Certificate2' is unsupported on: 'browser'.
#pragma warning disable CA1416
            ClientCertificates = new List<X509Certificate2>();
#pragma warning restore CA1416
        }

        /// <summary>
        /// A delegate that validates the certificate presented by the server.
        /// </summary>
        public Func<ServerCertificateCustomValidationArgs, bool>? ServerCertificateCustomValidationCallback { get; set; }

        /// <summary>
        /// The client certificate collection that will be configured for the transport.
        /// </summary>
        /// <value></value>
        public IList<X509Certificate2> ClientCertificates { get; }

         /// <summary>
        /// Gets or sets a value that indicates whether the redirect policy should follow redirection responses.
        /// </summary>
        /// <value>
        /// <c>true</c> if the redirect policy should follow redirection responses; otherwise <c>false</c>. The default value is <c>false</c>.
        /// </value>
        public bool IsClientRedirectEnabled { get; set; }
    }
}
