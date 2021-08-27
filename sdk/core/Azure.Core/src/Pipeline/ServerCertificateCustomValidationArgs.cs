// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Enables configuration of options for the <see cref="HttpClientTransport"/>
    /// </summary>
    public struct ServerCertificateCustomValidationArgs
    {
        /// <summary>
        /// The <see cref="HttpMessage"/> related to this request.
        /// </summary>
        public HttpMessage? Message { get; set; }

        /// <summary>
        /// The certificate used to authenticate the remote party.
        /// </summary>
        public X509Certificate2? Certificate { get; set; }

        /// <summary>
        /// The chain of certificate authorities associated with the remote certificate.
        /// </summary>
        public X509Chain? X509Chain { get; set; }

        /// <summary>
        /// One or more errors associated with the remote certificate.
        /// </summary>
        public SslPolicyErrors SslPolicyErrors { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="ServerCertificateCustomValidationArgs"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="certificate">The certificate</param>
        /// <param name="x509Chain"></param>
        /// <param name="sslPolicyErrors"></param>
        public ServerCertificateCustomValidationArgs(HttpMessage? message, X509Certificate2? certificate, X509Chain? x509Chain, SslPolicyErrors sslPolicyErrors)
        {
            Message = message;
            Certificate = certificate;
            X509Chain = x509Chain;
            SslPolicyErrors = sslPolicyErrors;
        }
    }
}
