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
    using System.Globalization;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    internal class ProductionIHDInsightSubscriptionCertificateCredentialsFactory : IHDInsightSubscriptionCredentialsFactory
    {
        private const string EndPoint = @"https://management.core.windows.net/";

        private const string Namespace = @"hdinsight";

        private IHDInsightCertificateCredential Create(IHDInsightCertificateCredential credentials)
        {
            credentials.ArgumentNotNull("credentials");
            return new HDInsightCertificateCredential()
            {
                Certificate = credentials.Certificate,
                DeploymentNamespace = credentials.DeploymentNamespace,
                Endpoint = credentials.Endpoint,
                SubscriptionId = credentials.SubscriptionId
            };
        }

        private IHDInsightAccessTokenCredential Create(IHDInsightAccessTokenCredential credentials)
        {
            credentials.ArgumentNotNull("credentials");
            return new HDInsightAccessTokenCredential()
            {
                AccessToken = credentials.AccessToken,
                DeploymentNamespace = credentials.DeploymentNamespace,
                Endpoint = credentials.Endpoint,
                SubscriptionId = credentials.SubscriptionId
            };
        }

        public IHDInsightSubscriptionCredentials Create(IHDInsightSubscriptionCredentials credentials)
        {
            credentials.ArgumentNotNull("credentials");
            IHDInsightCertificateCredential certCreds = credentials as IHDInsightCertificateCredential;
            IHDInsightAccessTokenCredential tokenCreds = credentials as IHDInsightAccessTokenCredential;
            if (certCreds != null)
            {
                return this.Create(certCreds);
            }
            else if (tokenCreds != null)
            {
                return this.Create(tokenCreds);
            }
            else
            {
                throw new NotSupportedException("Credential Type is not supported");
            }
        }
        
    }
}