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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;

    /// <summary>
    /// Factory class to create an instance of the IRdfeServiceRestClient.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rdfe", Justification = "Rdfe is an acronym for Red Dog Front End")]
    internal interface IRdfeServiceRestClientFactory
    {
        /// <summary>
        /// Creates an instance of the IRdfeServiceRestClient.
        /// </summary>
        /// <param name="credentials">Credentials object.</param>
        /// <param name="context">The Abstraction context.</param>
        /// <param name="ignoreSslErrors">
        ///     Specifies that server side SSL errors should be ignored.
        /// </param>
        /// <returns>An instance of the IRdfeServiceRestClient.</returns>
        IRdfeServiceRestClient Create(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors);
    }
}
