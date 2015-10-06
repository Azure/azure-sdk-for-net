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

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.HadoopClientTests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests;

    [TestClass]
    public class RdpTests : IntegrationTestBase
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
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ICanAddAndDeleteRDPUser()
        {
            IHDInsightSubscriptionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            IHDInsightClient client = HDInsightClient.Connect(credentials);

            ClusterCreateParametersV2 clusterCreationDetails = GetRandomCluster();
            clusterCreationDetails.Version = "1.6";
            ClusterDetails clusterDetails = client.CreateCluster(clusterCreationDetails);

            // add a rdp user - rdp is OFF by default, hence we enable it first
            string userName = "rdpUser";
            string password = GetRandomValidPassword();
            client.EnableRdp(clusterDetails.Name, clusterDetails.Location, userName, password, DateTime.UtcNow.AddHours(1));

            ClusterDetails cluster = await client.GetClusterAsync(clusterDetails.Name);
            Assert.AreEqual(userName, cluster.RdpUserName, "Rdp user name has not been updated");

            // now disable the rdp user
            await client.DisableRdpAsync(clusterDetails.Name, clusterDetails.Location);

            cluster = await client.GetClusterAsync(clusterDetails.Name);

            Assert.IsFalse(String.IsNullOrEmpty(cluster.Name), "Cluster user name is empty, maybe cluster was not created.");
            Assert.IsTrue(String.IsNullOrEmpty(cluster.RdpUserName), "Rdp user name has not been cleared");

            // delete the cluster
            if (!string.Equals(clusterDetails.Name, IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName))
            {
                client.DeleteCluster(clusterDetails.Name);
            }
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ICanDeleteTheRdpUserTwice()
        {
            IHDInsightSubscriptionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(credentials);

            var clusterCreationDetails = GetRandomCluster();
            clusterCreationDetails.Version = "1.6";
            var clusterDetails = client.CreateCluster(clusterCreationDetails);

            await client.DisableRdpAsync(clusterDetails.Name, clusterDetails.Location);

            var cluster = await client.GetClusterAsync(clusterDetails.Name);

            Assert.IsFalse(String.IsNullOrEmpty(cluster.Name), "Cluster user name is empty, maybe cluster was not created.");
            Assert.IsTrue(String.IsNullOrEmpty(cluster.RdpUserName), "Rdp user name has not been cleared");

            try
            {
                await client.DisableRdpAsync(clusterDetails.Name, clusterDetails.Location);

                cluster = await client.GetClusterAsync(clusterDetails.Name);


                Assert.IsFalse(String.IsNullOrEmpty(cluster.Name), "Cluster user name is empty, maybe cluster was not created.");
                Assert.IsTrue(String.IsNullOrEmpty(cluster.RdpUserName), "Rdp user name should still be null");
            }
            catch (Exception ex)
            {
                Assert.Fail("Disabling the Rdp user is an idempotent operation but is throwing an error: The following was the error: \r\n{0}", ex);
            }
            finally
            {
                // delete the cluster
                if (!string.Equals(clusterDetails.Name, IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName))
                {
                    client.DeleteCluster(clusterDetails.Name);
                }
            }
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ICannotAddAnotherRdpUser()
        {
            IHDInsightSubscriptionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(credentials);

            var clusterCreationDetails = GetRandomCluster();
            clusterCreationDetails.Version = "1.6";
            var clusterDetails = client.CreateCluster(clusterCreationDetails);

            await client.DisableRdpAsync(clusterDetails.Name, clusterDetails.Location);

            // now add a user
            string userName = "hdinsightuser";
            string password = GetRandomValidPassword();
            await client.EnableRdpAsync(clusterDetails.Name, clusterDetails.Location, userName, password, DateTime.UtcNow.AddHours(1));

            try
            {
                userName = "anotherrdpuser";
                password = GetRandomValidPassword();
                await client.EnableRdpAsync(clusterDetails.Name, clusterDetails.Location, userName, password, DateTime.UtcNow.AddHours(1));
                Assert.Fail("This test expected an exception but did not receive one.");
            }
            catch (HttpLayerException ex)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.RequestStatusCode);
            }
            finally
            {
                // delete the cluster
                if (!string.Equals(clusterDetails.Name, IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName))
                {
                    client.DeleteCluster(clusterDetails.Name);
                }
            }
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeARdpUserChangeRequest()
        {
            string username = "hdinsightuser";
            string password = GetRandomValidPassword();
            DateTimeOffset expiration = DateTimeOffset.UtcNow;
            var payload = PayloadConverter.SerializeRdpConnectivityRequest(UserChangeRequestOperationType.Enable, username, password, expiration);

            var converter = new ClusterProvisioningServerPayloadConverter();
            var request = converter.DeserializeChangeRequest<RdpUserChangeRequest>(payload);

            Assert.AreEqual(username, request.Username, "Round trip serialize/deserialize enable RDP does not match username");
            Assert.AreEqual(password, request.Password, "Round trip serialize/deserialize enable RDP does not match password");
            Assert.AreEqual(expiration, request.ExpirationDate);
            Assert.AreEqual(UserChangeOperationType.Enable, request.Operation, "Round trip serialize/deserialize enable RDP does not match operation requested");

            payload = PayloadConverter.SerializeRdpConnectivityRequest(UserChangeRequestOperationType.Disable, username, password, expiration);

            request = converter.DeserializeChangeRequest<RdpUserChangeRequest>(payload);

            Assert.AreEqual(UserChangeOperationType.Disable, request.Operation, "Round trip serialize/deserialize disabl RDP does not match operation requested");
            // Technically per spec these shouldn't matter for disable... but the serializer should do it's job correctly.
            Assert.AreEqual(username, request.Username, "Round trip serialize/deserialize disable RDP does not match username");
            Assert.AreEqual(password, request.Password, "Round trip serialize/deserialize disable RDP does not match password");
            Assert.AreEqual(expiration, request.ExpirationDate);
        }
    }
}