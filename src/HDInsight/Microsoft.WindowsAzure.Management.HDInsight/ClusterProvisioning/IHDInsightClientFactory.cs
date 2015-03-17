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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;

    /// <summary>
    /// Factory for HDInsight.Client.
    /// </summary>
    internal interface IHDInsightClientFactory
    {
        /// <summary>
        /// Creates an instance of the HDInsight.Client class.
        /// </summary>
        /// <param name="credentials">The credentials to use to connect to the subscription.</param>
        /// <returns>Client object that can be used to interact with HDInsight clusters.</returns>
        IHDInsightClient Create(IHDInsightSubscriptionCredentials credentials);

        /// <summary>
        /// Creates the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="httpOperationTimeout">The HTTP operation timeout.</param>
        /// <param name="retryPolicy">The retry olicy.</param>
        /// <returns>Client object that can be used to interact with HDInsight clusters.</returns>
        IHDInsightClient Create(IHDInsightSubscriptionCredentials credentials, TimeSpan httpOperationTimeout, IRetryPolicy retryPolicy);
    }
}
