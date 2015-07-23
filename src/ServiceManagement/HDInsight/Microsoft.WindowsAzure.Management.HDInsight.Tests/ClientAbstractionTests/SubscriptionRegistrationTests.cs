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
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class SubscriptionRegistrationTests : IntegrationTestBase
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
        [TestCategory("SubscriptionRegistrationClient")]
        public async Task ICanPerformA_PositiveSubscriptionValidation_Using_SubscriptionRegistrationAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(credentials, GetAbstractionContext(), false);
            Assert.IsTrue(await client.ValidateSubscriptionLocation("East US 2"));
            Assert.IsFalse(await client.ValidateSubscriptionLocation("No Where"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("SubscriptionRegistrationClient")]
        public async Task ICanPerformA_RepeatedSubscriptionRegistration_Using_SubscriptionRegistrationAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(credentials, GetAbstractionContext(), false);
            await client.RegisterSubscription();
            await client.RegisterSubscription();
            await client.RegisterSubscriptionLocation("North Europe");
            await client.RegisterSubscriptionLocation("North Europe");
            Assert.IsTrue(await client.ValidateSubscriptionLocation("North Europe"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("SubscriptionRegistrationClient")]
        public async Task ICannotPerformA_RepeatedUnregistration_Using_SubscriptionRegistrationAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            string location = "North Europe";
            DeleteClusters(credentials, location);

            // Need to delete clusters, otherwise unregister will no-op
            var client = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(credentials, GetAbstractionContext(), false);
            try
            {
                await client.UnregisterSubscriptionLocation("North Europe");
                await client.UnregisterSubscriptionLocation("North Europe");
                Assert.Fail("Expected exception.");
            }
            catch (HttpLayerException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.RequestStatusCode);
                // Error looks like The cloud service with name [namespace] was not found.
                Assert.IsTrue(e.RequestContent.Contains("The cloud service with name"));
                Assert.IsTrue(e.RequestContent.Contains("was not found."));
            }

            Assert.IsFalse(await client.ValidateSubscriptionLocation(location));
        }
        
        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("SubscriptionRegistrationClient")]
        public async Task ICannotPerformA_UnregisterIfClustersExist_Using_SubscriptionRegistrationAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();

            var client = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(credentials, GetAbstractionContext(), false);
            try
            {
                await client.UnregisterSubscriptionLocation("East US 2");
                Assert.Fail("Expected exception.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(e.Message, "Cannot unregister a subscription location if it contains clusters");
            }

            Assert.IsTrue(await client.ValidateSubscriptionLocation("East US 2"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("SubscriptionRegistrationClient")]
        public async Task ICanPerformA_UnregisterSubscription_Using_SubscriptionRegistrationAbstraction()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            DeleteClusters(credentials, "North Europe");

            var client = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(credentials, GetAbstractionContext(), false);
            await client.RegisterSubscriptionLocation("North Europe");
            await client.UnregisterSubscriptionLocation("North Europe");
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("RestClient")]
        [TestCategory("SubscriptionRegistrationClient")]
        [TestCategory("CheckIn")]
        public async Task ICannotPerformA_CreateContainersOnUnregisterdSubscription_Using_RestClient()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();

            // Unregisters location
            var location = "North Europe";
            DeleteClusters(credentials, location);
            var client = ServiceLocator.Instance.Locate<ISubscriptionRegistrationClientFactory>().Create(credentials, GetAbstractionContext(), false);
            if (await client.ValidateSubscriptionLocation(location))
            {
                await client.UnregisterSubscriptionLocation(location);
            }
            Assert.IsFalse(await client.ValidateSubscriptionLocation(location), "Subscription location '{0}' is still registered.", location);

            try
            {
                // Creates the cluster
                var restClient = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(credentials, GetAbstractionContext(), false);
                var cluster = GetRandomCluster();
                string payload = new PayloadConverter().SerializeClusterCreateRequest(cluster);
                await restClient.CreateContainer(cluster.Name, location, payload);

                Assert.Fail("Expected exception.");
            }
            catch (HttpLayerException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.RequestStatusCode);
                // Error looks like The cloud service with name [namespace] was not found.
                Assert.IsTrue(e.RequestContent.Contains("The cloud service with name"));
                Assert.IsTrue(e.RequestContent.Contains("was not found."));
            }
        }
    }
}