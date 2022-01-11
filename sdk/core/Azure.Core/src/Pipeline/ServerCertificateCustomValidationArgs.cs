// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Enables configuration of options for the <see cref="HttpClientTransport"/>
    /// </summary>
    public class ServerCertificateCustomValidationArgs
    {
        /// <summary>
        /// The certificate used to authenticate the remote party.
        /// </summary>
        public X509Certificate2? Certificate { get; }

        /// <summary>
        /// The chain of certificate authorities associated with the remote certificate.
        /// </summary>
        public X509Chain? X509Chain { get; }

        /// <summary>
        /// One or more errors associated with the remote certificate.
        /// </summary>
        public SslPolicyErrors SslPolicyErrors { get; }

        /// <summary>
        /// Initializes an instance of <see cref="ServerCertificateCustomValidationArgs"/>.
        /// </summary>
        /// <param name="certificate">The certificate</param>
        /// <param name="x509Chain"></param>
        /// <param name="sslPolicyErrors"></param>
        public ServerCertificateCustomValidationArgs(X509Certificate2? certificate, X509Chain? x509Chain, SslPolicyErrors sslPolicyErrors)
        {
            Certificate = certificate;
            X509Chain = x509Chain;
            SslPolicyErrors = sslPolicyErrors;
        }
    }
}
