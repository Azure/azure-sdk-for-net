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
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// Class that provides the credentials to submit jobs to an HDInsight cluster.
    /// </summary>
    public class JobSubmissionCertificateCredential : HDInsightCertificateCredential, IJobSubmissionClientCredential
    {
        /// <summary>
        /// Initializes a new instance of the JobSubmissionCertificateCredential class.
        /// </summary>
        public JobSubmissionCertificateCredential()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionCertificateCredential class.
        /// </summary>
        /// <param name="credentials">HDInsightSubscriptionCertificateCredentials to be used.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        public JobSubmissionCertificateCredential(HDInsightCertificateCredential credentials, string cluster)
            : base(credentials)
        {
            this.Cluster = cluster;
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionCertificateCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="certificate">Certificate to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        public JobSubmissionCertificateCredential(Guid subscriptionId, X509Certificate2 certificate, string cluster)
            : base(subscriptionId, certificate)
        {
            this.Cluster = cluster;
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionCertificateCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="certificate">Certificate to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        public JobSubmissionCertificateCredential(Guid subscriptionId,
                                                     X509Certificate2 certificate,
                                                     string cluster,
                                                     Uri endPoint)
            : this(subscriptionId, certificate, cluster)
        {
            this.Endpoint = endPoint;
        }

        /// <summary>
        ///     Initializes a new instance of the JobSubmissionCertificateCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="certificate">Certificate to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="cluster">The cluster to connect to.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        /// <param name="deploymentNamespace">Namespace for the HDInsight service.</param>
        public JobSubmissionCertificateCredential(Guid subscriptionId,
                                                     X509Certificate2 certificate,
                                                     string cluster,
                                                     Uri endPoint,
                                                     string deploymentNamespace)
            : this(subscriptionId, certificate, cluster, endPoint)
        {
            this.DeploymentNamespace = deploymentNamespace;
        }

        /// <inheritdoc/>
        public string Cluster { get; set; }
    }
}
