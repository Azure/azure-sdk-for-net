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
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// Class that provides the credentials to submit jobs to an HDInsight cluster.
    /// </summary>
    public class JobSubmissionAccessTokenCredential : HDInsightAccessTokenCredential, IJobSubmissionClientCredential
    {
        /// <summary>
        /// Initializes a new instance of the JobSubmissionAccessTokenCredential class.
        /// </summary>
        public JobSubmissionAccessTokenCredential()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionAccessTokenCredential class.
        /// </summary>
        /// <param name="credentials">HDInsightAccessTokenCredential to be used.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        public JobSubmissionAccessTokenCredential(HDInsightAccessTokenCredential credentials, string cluster)
            : base(credentials)
        {
            this.Cluster = cluster;
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionAccessTokenCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="token">Token to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        public JobSubmissionAccessTokenCredential(Guid subscriptionId, string token, string cluster)
            : base(subscriptionId, token)
        {
            this.Cluster = cluster;
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionAccessTokenCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="token">Token to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        public JobSubmissionAccessTokenCredential(Guid subscriptionId,
                                                     string token,
                                                     string cluster,
                                                     Uri endPoint)
            : this(subscriptionId, token, cluster)
        {
            this.Endpoint = endPoint;
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionAccessTokenCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="token">Token to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        /// <param name="deploymentNamespace">Namespace for the HDInsight service.</param>
        public JobSubmissionAccessTokenCredential(Guid subscriptionId,
                                                     string token,
                                                     string cluster,
                                                     Uri endPoint,
                                                     string deploymentNamespace)
            : this(subscriptionId, token, cluster, endPoint)
        {
            this.DeploymentNamespace = deploymentNamespace;
        }

        /// <inheritdoc/>
        public string Cluster { get; set; }
    }
}
