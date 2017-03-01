//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net;
using System.Net.Security;
using Microsoft.Azure.Management.SiteRecoveryVault;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.Test
{
    using Azure.Management.SiteRecovery;
    using Rest.ClientRuntime.Azure.TestFramework;
    using SiteRecovery.Tests;

    public static class SiteRecoveryManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A recovery services management client, created from the current context (environment variables)</returns>
        public static SiteRecoveryVaultManagementClient GetSiteRecoveryVaultManagementClient(this TestBase testBase)
        {
            TestEnvironment environment = TestEnvironmentFactory.GetTestEnvironment();

            //if (ServicePointManager.ServerCertificateValidationCallback == null)
            //{
            //    ServicePointManager.ServerCertificateValidationCallback =
            //        IgnoreCertificateErrorHandler;
            //}

            var credentials = new CredentialAdapter(
                environment.TokenInfo[TokenAudience.Management],
                environment.SubscriptionId);

            var client = new SiteRecoveryVaultManagementClient(
                "Microsoft.SiteRecoveryBVTD2",
                "SiteRecoveryVault",
                credentials,
                environment.BaseUri).WithHandler(HttpMockServer.CreateInstance());

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
                client.LongRunningOperationInitialTimeout = 0;
            }

            return client;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A site recovery management client, created from the current context (environment variables)</returns>
        public static SiteRecoveryManagementClient GetSiteRecoveryManagementClient(this TestBase testBase, String scenario = "")
        {
            //if (ServicePointManager.ServerCertificateValidationCallback == null)
            //{
            //    ServicePointManager.ServerCertificateValidationCallback =
            //        IgnoreCertificateErrorHandler;
            //}

            TestEnvironment environment = TestEnvironmentFactory.GetTestEnvironment();

            var credentials = new CredentialAdapter(
                environment.TokenInfo[TokenAudience.Management],
                environment.SubscriptionId);

            switch (scenario)
            {
                case Constants.A2A:
                    SiteRecoveryTestsBase.MyVaultName = "integrationTest1";
                    SiteRecoveryTestsBase.MyResourceGroupName = "rg1";
                    SiteRecoveryTestsBase.ResourceNamespace = "Microsoft.RecoveryServicesBVTD2";
                    SiteRecoveryTestsBase.ResourceType = "RecoveryServicesVault";
                    environment.BaseUri = new Uri("https://sriramvu:8443/Rdfeproxy.svc");
                    break;
                
                default:
                    SiteRecoveryTestsBase.MyVaultName = "hydratest";
                    SiteRecoveryTestsBase.VaultKey = "loMUdckuT9SEvpQKcSG07A==";
                    SiteRecoveryTestsBase.MyResourceGroupName = "RecoveryServices-WHNOWF6LI6NM4B55QDIYR3YG3YAEZNTDUOWHPQX7NJB2LHDGTXJA-West-US";
                    SiteRecoveryTestsBase.ResourceNamespace = "Microsoft.SiteRecoveryBVTD2";
                    SiteRecoveryTestsBase.ResourceType = "SiteRecoveryVault";
                    break;
            };

            var client = new SiteRecoveryManagementClient(
                SiteRecoveryTestsBase.MyVaultName,
                SiteRecoveryTestsBase.MyResourceGroupName,
                SiteRecoveryTestsBase.ResourceNamespace,
                SiteRecoveryTestsBase.ResourceType,
                credentials,
                environment.BaseUri).WithHandler(HttpMockServer.CreateInstance());

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
                client.LongRunningOperationInitialTimeout = 0;
            }

            return client;
        }

        private static bool IgnoreCertificateErrorHandler
           (object sender,
           System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
