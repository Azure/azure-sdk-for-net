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
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    /// <summary>
    ///     Class that provides the credentials to talk to an RDFE with a token.
    /// </summary>
    public class HDInsightAccessTokenCredential : IHDInsightAccessTokenCredential
    {
        private const string ProductionEndPoint = @"https://management.core.windows.net/";

        private const string ProductionNamespace = @"hdinsight";

        /// <summary>
        /// Initializes a new instance of the HDInsightAccessTokenCredential class.
        /// </summary>
        public HDInsightAccessTokenCredential()
        {
            this.Endpoint = new Uri(ProductionEndPoint);
            this.DeploymentNamespace = ProductionNamespace;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightAccessTokenCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="token">Access token to be used to connect authenticate the user with the subscription in azure.</param>
        public HDInsightAccessTokenCredential(Guid subscriptionId, string token)
            : this()
        {
            this.SubscriptionId = subscriptionId;
            this.AccessToken = token;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightAccessTokenCredential class.
        /// </summary>
        /// <param name="credential">The credentials to copy.</param>
        public HDInsightAccessTokenCredential(HDInsightAccessTokenCredential credential)
        {
            credential.ArgumentNotNull("credential");
            this.SubscriptionId = credential.SubscriptionId;
            this.AccessToken = credential.AccessToken;
            this.Endpoint = credential.Endpoint;
            this.DeploymentNamespace = credential.DeploymentNamespace;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightAccessTokenCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="token">Access token to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        public HDInsightAccessTokenCredential(Guid subscriptionId,
                                                           string token,
                                                           Uri endPoint)
            : this(subscriptionId, token)
        {
            this.Endpoint = endPoint;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightAccessTokenCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="token">Access token to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        /// <param name="deploymentNamespace">Namespace for the HDInsight service.</param>
        public HDInsightAccessTokenCredential(Guid subscriptionId,
                                                           string token,
                                                           Uri endPoint,
                                                           string deploymentNamespace)
            : this(subscriptionId, token, endPoint)
        {
            this.DeploymentNamespace = deploymentNamespace;
        }

        /// <inheritdoc />
        public Uri Endpoint { get; set; }

        /// <inheritdoc />
        public string DeploymentNamespace { get; set; }

        /// <inheritdoc />
        public Guid SubscriptionId { get; set; }

        /// <inheritdoc />
        public string AccessToken { get; set; }
    }
}