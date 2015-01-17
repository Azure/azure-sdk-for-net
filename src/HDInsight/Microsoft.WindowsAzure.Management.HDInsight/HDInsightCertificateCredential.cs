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
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    /// <summary>
    ///     Class that provides the credentials to talk to an RDFE.
    /// </summary>
    public class HDInsightCertificateCredential : IHDInsightCertificateCredential
    {
        private const string ProductionEndPoint = @"https://management.core.windows.net/";

        private const string ProductionNamespace = @"hdinsight";

        /// <summary>
        /// Initializes a new instance of the HDInsightCertificateCredential class.
        /// </summary>
        public HDInsightCertificateCredential()
        {
            this.Endpoint = new Uri(ProductionEndPoint);
            this.DeploymentNamespace = ProductionNamespace;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightCertificateCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="certificate">Certificate to be used to connect authenticate the user with the subscription in azure.</param>
        public HDInsightCertificateCredential(Guid subscriptionId, X509Certificate2 certificate)
            : this()
        {
            this.SubscriptionId = subscriptionId;
            this.Certificate = certificate;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightCertificateCredential class.
        /// </summary>
        /// <param name="credential">The credentials to copy.</param>
        public HDInsightCertificateCredential(HDInsightCertificateCredential credential)
        {
            credential.ArgumentNotNull("credentials");
            this.SubscriptionId = credential.SubscriptionId;
            this.Certificate = credential.Certificate;
            this.Endpoint = credential.Endpoint;
            this.DeploymentNamespace = credential.DeploymentNamespace;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightCertificateCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="certificate">Certificate to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        public HDInsightCertificateCredential(Guid subscriptionId,
                                                           X509Certificate2 certificate,
                                                           Uri endPoint)
            : this(subscriptionId, certificate)
        {
            this.Endpoint = endPoint;
        }

        /// <summary>
        ///     Initializes a new instance of the HDInsightCertificateCredential class.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id to be used.</param>
        /// <param name="certificate">Certificate to be used to connect authenticate the user with the subscription in azure.</param>
        /// <param name="endPoint">Azure Enpoint for RDFE.</param>
        /// <param name="deploymentNamespace">Namespace for the HDInsight service.</param>
        public HDInsightCertificateCredential(Guid subscriptionId,
                                                           X509Certificate2 certificate,
                                                           Uri endPoint,
                                                           string deploymentNamespace)
            : this(subscriptionId, certificate, endPoint)
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
        public X509Certificate2 Certificate { get; set; }
    }
}