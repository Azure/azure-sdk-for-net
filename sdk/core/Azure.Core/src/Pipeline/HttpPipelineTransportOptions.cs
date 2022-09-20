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
            ClientCertificates = new List<X509Certificate2>();
        }

        /// <summary>
        /// A delegate that validates the certificate presented by the server.
        /// </summary>
        public Func<ServerCertificateCustomValidationArgs, bool>? ServerCertificateCustomValidationCallback { get; set; }

        /// <summary>
        /// The client certificate collection that will be configured for the transport.
        /// </summary>
        /// <value></value>
        public IList<X509Certificate2> ClientCertificates {get;}
    }
}
