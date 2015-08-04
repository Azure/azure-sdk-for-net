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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Asv;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Moq;

    [TestClass]
    public class AsvClientTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RestAsvClient")]
        public async Task ICanPerformA_PositiveValidateAccount_Using_RestAsvClientAbstraction()
        {
            var client = ServiceLocator.Instance.Locate<IAsvValidatorClientFactory>().Create();

            await client.ValidateAccount(IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                                         IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key);
            await client.ValidateAccount(IntegrationTestBase.TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name,
                                         IntegrationTestBase.TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RestAsvClient")]
        public async Task ICanPerformA_PositiveValidateContainer_Using_RestAsvClientAbstraction()
        {
            var client = ServiceLocator.Instance.Locate<IAsvValidatorClientFactory>().Create();

            await client.CreateContainerIfNotExists(IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                                           IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                                           IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Container);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RestAsvClient")]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public async Task ICanPerformA_NegativeValidateAccount_InvalidKey_RestAsvClientAbstraction()
        {
            var client = ServiceLocator.Instance.Locate<IAsvValidatorClientFactory>().Create();
            await client.ValidateAccount(IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name, "key");
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RestAsvClient")]
        public async Task ICanPerformA_PositiveCreateContainer_WithNonExistantContainer()
        {
            var storageCreds = new WindowsAzureStorageAccountCredentials()
            {
                Key = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                Name = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name
            };

            var nonExistantContainer = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var client = ServiceLocator.Instance.Locate<IAsvValidatorClientFactory>().Create();
            await client.CreateContainerIfNotExists(storageCreds.Name, storageCreds.Key, nonExistantContainer);

            var storageAbstraction = ServiceLocator.Instance.Locate<IWabStorageAbstractionFactory>().Create(storageCreds);
            var listContainerPath = new Uri(Constants.WabsProtocolSchemeName + nonExistantContainer + "@" + storageCreds.Name);
            var containers = await storageAbstraction.List(listContainerPath, false);
            var containerExists = containers.Any(path => path.UserInfo == nonExistantContainer);
            Assert.IsTrue(containerExists);
        }
    }
}
