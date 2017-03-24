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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade;
using VaultUpgrade.Tests;

namespace Microsoft.Azure.Test
{
    public static class VaultUpgradeManagementTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A vault upgrade management client, created from the current context (environment variables)</returns>
        public static RecoveryServicesVaultUpgradeManagementClient GetRecoveryServicesVaultUpgradeManagementClient(
            this TestBase testBase)
        {
            if (ServicePointManager.ServerCertificateValidationCallback == null)
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    IgnoreCertificateErrorHandler;
            }

            TestEnvironment environment = new RDFETestEnvironmentFactory().GetTestEnvironment();

            VaultUpgradeTestsBase.MyCloudService = (HttpMockServer.Mode == HttpRecorderMode.Playback) ?
                "RecoveryServices-DKIEGNVV3OAPUDVOTINGUOLCIJIDA743FNSWQAM4O4NEQUVZFBWA-West-US" :
                Environment.GetEnvironmentVariable("CLOUD_SERVICE_NAME");

            VaultUpgradeTestsBase.MyVaultName = (HttpMockServer.Mode == HttpRecorderMode.Playback) ?
                "TestVault2" :
                Environment.GetEnvironmentVariable("RESOURCE_NAME");

            VaultUpgradeTestsBase.MyVaultType = (HttpMockServer.Mode == HttpRecorderMode.Playback) ?
                "HyperVRecoveryManagerVault" :
                Environment.GetEnvironmentVariable("RESOURCE_TYPE");

            VaultUpgradeTestsBase.MyResourceNamespace = (HttpMockServer.Mode == HttpRecorderMode.Playback) ?
                "HRMBvtd2ToDogfood" :
                Environment.GetEnvironmentVariable("RESOURCE_NAMESPACE");

            if (string.IsNullOrEmpty(VaultUpgradeTestsBase.MyCloudService))
            {
                throw new Exception("Please set CLOUD_SERVICE_NAME environment variable before running the tests in Live mode");
            }
            if (string.IsNullOrEmpty(VaultUpgradeTestsBase.MyVaultName))
            {
                throw new Exception("Please set RESOURCE_NAME environment variable before running the tests in Live mode");
            }
            if (string.IsNullOrEmpty(VaultUpgradeTestsBase.MyVaultType))
            {
                throw new Exception("Please set RESOURCE_TYPE environment variable before running the tests in Live mode");
            }
            if (string.IsNullOrEmpty(VaultUpgradeTestsBase.MyResourceNamespace))
            {
                throw new Exception("Please set RESOURCE_NAMESPACE environment variable before running the tests in Live mode");
            }

            return new RecoveryServicesVaultUpgradeManagementClient(
                VaultUpgradeTestsBase.MyCloudService,
                VaultUpgradeTestsBase.MyResourceNamespace,
                VaultUpgradeTestsBase.MyVaultType,
                VaultUpgradeTestsBase.MyVaultName,
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
