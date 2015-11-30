// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource
{
    using System.Collections.Generic;
    using System.Net.Http;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;

    /// <summary>
    /// A concrete implementation of <see cref="IRdfeClustersResourceRestClientFactory"/>.
    /// </summary>
    internal class RdfeClustersResourceRestClientFactory : IRdfeClustersResourceRestClientFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IRdfeClustersResourceRestClient" /> with the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="context">The context.</param>
        /// <param name="ignoreSslErrors">If set to <c>true</c> ignore SSL errors.</param>
        /// <param name="schemaVersion">The schema version.</param>
        /// <returns>
        /// An instance of IRDFEClustersResourceRestClient.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "When the IRDFE client is disposed, this will be as well.")]
        public IRdfeClustersResourceRestClient Create(
            IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors, string schemaVersion)
        {
            var defaultHttpClientHandler = new WebRequestHandler();
            var certCreds = credentials as IHDInsightCertificateCredential;

            if (ignoreSslErrors)
            {
                defaultHttpClientHandler.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            }

            if (certCreds != null)
            {
                defaultHttpClientHandler.ClientCertificates.Add(certCreds.Certificate);
            }
            return this.Create(defaultHttpClientHandler, credentials, context, ignoreSslErrors, schemaVersion);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "When the IRDFE client is disposed, this will be as well.")]
        public IRdfeClustersResourceRestClient Create(
            HttpMessageHandler defaultHttpClientHandler,
            IHDInsightSubscriptionCredentials credentials,
            IAbstractionContext context,
            bool ignoreSslErrors,
            string schemaVersion)
        {
            HttpRestClientRetryPolicy retryPolicy = null;
            var tokenCreds = credentials as IHDInsightAccessTokenCredential;

            var customHandlers = new List<DelegatingHandler>();

            customHandlers.Add(new CustomHeaderHandler("SchemaVersion", schemaVersion));

            if (context != null && context.Logger != null)
            {
                customHandlers.Add(new HttpLoggingHandler(context.Logger));
                retryPolicy = new HttpRestClientRetryPolicy(context.RetryPolicy);
            }
            else
            {
                retryPolicy = new HttpRestClientRetryPolicy(RetryPolicyFactory.CreateExponentialRetryPolicy());
                customHandlers.Add(new HttpLoggingHandler(new Logger()));
            }

            if (tokenCreds != null)
            {
                customHandlers.Add(new BearerTokenMessageHandler(tokenCreds.AccessToken));
            }

            var httpConfiguration = new HttpRestClientConfiguration(defaultHttpClientHandler, customHandlers, retryPolicy);
            var client = new RdfeClustersResourceRestClient(credentials.Endpoint, httpConfiguration);
            return client;
        }
    }
}