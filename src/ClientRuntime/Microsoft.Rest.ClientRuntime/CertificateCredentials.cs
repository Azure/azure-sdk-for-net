// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
#if !PORTABLE

using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Rest.ClientRuntime.Properties;

namespace Microsoft.Rest
{
    /// <summary>
    /// Certificate based credentials for use with a REST Service Client.
    /// </summary>
    public class CertificateCredentials : ServiceClientCredentials
    {
        /// <summary>
        /// The Microsoft Azure Service Management API use mutual authentication
        /// of management certificates over SSL to ensure that a request made
        /// to the service is secure. No anonymous requests are allowed.
        /// </summary>
        public X509Certificate2 ManagementCertificate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateCredentials"/>
        /// class with the given 'Bearer' token.
        /// </summary>
        public CertificateCredentials(X509Certificate2 managementCertificate)
        {
            if (managementCertificate == null)
            {
                throw new ArgumentNullException("managementCertificate");
            }
            ManagementCertificate = managementCertificate;
        }

        /// <summary>
        /// Initialize a ServiceClient instance to process credentials.
        /// </summary>
        /// <typeparam name="T">Type of ServiceClient.</typeparam>
        /// <param name="client">The ServiceClient.</param>
        /// <remarks>
        /// This will add a certificate to the shared root WebRequestHandler in
        /// the ServiceClient's HttpClient handler pipeline.
        /// </remarks>
        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            WebRequestHandler handler = client.HttpMessageHandlers.FirstOrDefault(h => h is WebRequestHandler) as WebRequestHandler;
            if (handler == null)
            {
                throw new PlatformNotSupportedException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.WebRequestHandlerNotFound,
                        client.GetType().Name,
                        typeof(WebRequestHandler).Name));
            }

            handler.ClientCertificates.Add(ManagementCertificate);
        }
    }
}
#endif