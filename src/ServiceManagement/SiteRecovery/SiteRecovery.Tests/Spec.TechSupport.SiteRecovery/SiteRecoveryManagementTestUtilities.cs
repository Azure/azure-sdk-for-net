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
using System.Configuration;
using System.Net;
using System.Net.Security;
using Microsoft.WindowsAzure.Management.RecoveryServices;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.Test
{
    using WindowsAzure.Management.SiteRecovery;
    using SiteRecovery.Tests;

    public static class SiteRecoveryManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A recovery services management client, created from the current context (environment variables)</returns>
        public static RecoveryServicesManagementClient GetRecoveryServicesManagementClient(this TestBase testBase)
        {
            TestEnvironment environment = new RDFETestEnvironmentFactory().GetTestEnvironment();

            if (ServicePointManager.ServerCertificateValidationCallback == null)
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    IgnoreCertificateErrorHandler;
            }

            return new RecoveryServicesManagementClient(
                (SubscriptionCloudCredentials)environment.Credentials,
                environment.BaseUri).WithHandler(HttpMockServer.CreateInstance());
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A site recovery management client, created from the current context (environment variables)</returns>
        public static SiteRecoveryManagementClient GetSiteRecoveryManagementClient(this TestBase testBase)
        {
            if (ServicePointManager.ServerCertificateValidationCallback == null)
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    IgnoreCertificateErrorHandler;
            }

            TestEnvironment environment = new RDFETestEnvironmentFactory().GetTestEnvironment();

            SiteRecoveryTestsBase.MyCloudService = (HttpMockServer.Mode == HttpRecorderMode.Playback) ?
                "RecoveryServices-T2RMT6H7QF7AENS66ZV7KS2QZA2BXRAUPOECQXGXX2Q4V3VQ6MUQ-West-US" :
                Environment.GetEnvironmentVariable("CLOUD_SERVICE_NAME");

            SiteRecoveryTestsBase.MyVaultName = (HttpMockServer.Mode == HttpRecorderMode.Playback) ?
                "Hosters-FC-BVT-Vault" :
                Environment.GetEnvironmentVariable("RESOURCE_NAME");

            SiteRecoveryTestsBase.VaultKey = (HttpMockServer.Mode == HttpRecorderMode.Playback) ?
                "mock#ACIK" :
                Environment.GetEnvironmentVariable("CHANNEL_INTEGRITY_KEY");

            if (string.IsNullOrEmpty(SiteRecoveryTestsBase.MyCloudService))
            {
                throw new Exception("Please set CLOUD_SERVICE_NAME environment variable before running the tests in Live mode");
            }
            if (string.IsNullOrEmpty(SiteRecoveryTestsBase.MyVaultName))
            {
                throw new Exception("Please set RESOURCE_NAME environment variable before running the tests in Live mode");
            }
            if (string.IsNullOrEmpty(SiteRecoveryTestsBase.VaultKey))
            {
                throw new Exception("Please set CHANNEL_INTEGRITY_KEY environment variable before running the tests in Live mode");
            }

            return new SiteRecoveryManagementClient(
                SiteRecoveryTestsBase.MyCloudService,
                SiteRecoveryTestsBase.MyVaultName,
                (SubscriptionCloudCredentials)environment.Credentials,
                environment.BaseUri).WithHandler(HttpMockServer.CreateInstance());
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
