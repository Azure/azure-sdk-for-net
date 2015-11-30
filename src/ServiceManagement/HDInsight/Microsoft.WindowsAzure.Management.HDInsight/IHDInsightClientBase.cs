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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Threading;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Provides the base interface for ClusterProvisioning Clients.
    /// </summary>
    public interface IHDInsightClientBase : IJobSubmissionClientBase
    {
        /// <summary>
        /// Gets the cluster credentials.
        /// </summary>
        IHDInsightSubscriptionCredentials Credentials { get; }

        /// <summary>
        /// Gets or sets the polling interval for the CreateCluster\DeleteCluster and user change operations.
        /// </summary>
        TimeSpan PollingInterval { get; set; }

        /// <summary>
        /// Gets the Cancellation Token for this client.
        /// </summary>
        CancellationToken CancellationToken { get; }
    }
}
