//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// Credentials using a management certificate to authorize requests.
    /// </summary>
    public sealed class CertificateCloudCredentials
        : SubscriptionCloudCredentials
    {
        // The Windows Azure Subscription ID.
        public string _subscriptionId = null;

        /// <summary>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management API.
        /// </summary>
        public override string SubscriptionId
        {
            get { return _subscriptionId; }
        }

        /// <summary>
        /// The Windows Azure Service Management API use mutual authentication
        /// of management certificates over SSL to ensure that a request made
        /// to the service is secure. No anonymous requests are allowed.
        /// </summary>
        public X509Certificate2 ManagementCertificate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the CertificateCloudCredentials
        /// class.
        /// </summary>
        /// <param name="subscriptionId">The Subscription ID.</param>
        /// <param name="managementCertificate">
        /// The management certificate.
        /// </param>
        public CertificateCloudCredentials(string subscriptionId, X509Certificate2 managementCertificate)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }
            else if (subscriptionId.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("subscriptionId");
            }
            else if (managementCertificate == null)
            {
                throw new ArgumentNullException("managementCertificate");
            }

            _subscriptionId = subscriptionId;
            ManagementCertificate = managementCertificate;
        }

        /// <summary>
        /// Attempt to create certificate credentials from a collection of
        /// settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>
        /// CertificateCloudCrendentials is created, null otherwise.
        /// </returns>
        public static CertificateCloudCredentials Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            string subscriptionId = ConfigurationHelper.GetString(settings, "SubscriptionId", false);
            X509Certificate2 certificate = PlatformConfigurationHelper.GetCertificate(settings, "ManagementCertificate", false);

            if (subscriptionId != null && certificate != null)
            {
                return new CertificateCloudCredentials(subscriptionId, certificate);
            }

            return null;
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
            WebRequestHandler handler = client.GetHttpPipeline().OfType<WebRequestHandler>().FirstOrDefault();
            if (handler == null)
            {
                throw new PlatformNotSupportedException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Microsoft.WindowsAzure.Common.Platform.Properties.Resources.CertificateCloudCredentials_InitializeServiceClient_NoWebRequestHandler,
                        client.GetType().Name,
                        typeof(WebRequestHandler).Name));
            }
            
            handler.ClientCertificates.Add(ManagementCertificate);
        }

        /// <summary>
        /// Apply the credentials to the HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Task that will complete when processing has completed.
        /// </returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
