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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ConnectionCredentials
{
    using System;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;

    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    internal class AlternativeEnvironmentIHDInsightSubscriptionCertificateCredentialsFactory : IHDInsightSubscriptionCredentialsFactory
    {
        private AzureTestCredentials creds;
        public AlternativeEnvironmentIHDInsightSubscriptionCertificateCredentialsFactory()
        {
            creds = IntegrationTestBase.GetCredentialsForEnvironmentType(EnvironmentType.Current);
        }

        private IHDInsightCertificateCredential Create(IHDInsightCertificateCredential ignoreCreds)
        {
            return new HDInsightCertificateCredential()
            {
                Certificate = new X509Certificate2(this.creds.Certificate),
                Endpoint = new Uri(this.creds.Endpoint),
                DeploymentNamespace = this.creds.CloudServiceName,
                SubscriptionId = this.creds.SubscriptionId
            };
        }

        private IHDInsightAccessTokenCredential Create(IHDInsightAccessTokenCredential credentials)
        {
            return new HDInsightAccessTokenCredential()
            {
                AccessToken = this.creds.AccessToken,
                Endpoint = new Uri(this.creds.Endpoint),
                DeploymentNamespace = this.creds.CloudServiceName,
                SubscriptionId = this.creds.SubscriptionId
            };
        }

        public IHDInsightSubscriptionCredentials Create(IHDInsightSubscriptionCredentials credentials)
        {
            IHDInsightCertificateCredential certCreds = credentials as IHDInsightCertificateCredential;
            IHDInsightAccessTokenCredential tokenCreds = credentials as IHDInsightAccessTokenCredential;
            if (certCreds != null)
            {
                return Create(certCreds);
            }
            else if (tokenCreds != null)
            {
                return Create(tokenCreds);
            }
            else
            {
                throw new NotSupportedException("Credential Type is not supported");
            }
        }
    }
}