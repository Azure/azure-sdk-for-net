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
    using System.Net.Http;

    /// <summary>
    /// A factory class used to instantiate a IRDFE Restclient.
    /// </summary>
    internal interface IRdfeClustersResourceRestClientFactory
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
        IRdfeClustersResourceRestClient Create(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors, string schemaVersion);

        /// <summary>
        /// Creates an instance of <see cref="IRdfeClustersResourceRestClient" /> with the specified credentials.
        /// </summary>
        /// <param name="defaultHttpClientHandler">The default HTTP client handler.</param>
        /// <param name="credentials">The credentials.</param>
        /// <param name="context">The context.</param>
        /// <param name="ignoreSslErrors">If set to <c>true</c> ignore SSL errors.</param>
        /// <param name="schemaVersion">The schema version.</param>
        /// <returns>
        /// An instance of IRDFEClustersResourceRestClient.
        /// </returns>
        IRdfeClustersResourceRestClient Create(HttpMessageHandler defaultHttpClientHandler, IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors, string schemaVersion);
    }
}
