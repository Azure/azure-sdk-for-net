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
    using System.Threading;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;
    
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects;

    [TestClass]
    public class TimothyTests : IntegrationTestBase
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

        internal IRetryPolicy GetRetryPolicy()
        {
            return RetryPolicyFactory.CreateExponentialRetryPolicy(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100), 3, 0.2);
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeUserChangeResponseWithErrorPackage()
        {
            var serverConverter = new ClusterProvisioningServerPayloadConverter();

            PassthroughResponse responseObject = new PassthroughResponse()
            {
                Data = Guid.NewGuid(),
                Error = new ErrorDetails()
                {
                    ErrorId = "Error123",
                    ErrorMessage = "ErrorMessage",
                    StatusCode = HttpStatusCode.NotAcceptable
                }
            };

            var payload = serverConverter.SerailizeChangeRequestResponse(responseObject);

            var deserialized = new PayloadConverter().DeserializeConnectivityResponse(payload);

            Assert.AreEqual(responseObject.Data, deserialized.Data, "Round trip serialize/deserialize enable RDP does not match the ID code");
            Assert.IsNotNull(deserialized.ErrorDetails, "No error object was present after deserialization.");
            Assert.AreEqual(responseObject.Error.ErrorId, deserialized.ErrorDetails.ErrorId, "The Error Id did not match after deserialization.");
            Assert.AreEqual(responseObject.Error.ErrorMessage, deserialized.ErrorDetails.ErrorMessage, "The error message did not match after deserialization.");
            Assert.AreEqual(responseObject.Error.StatusCode, deserialized.ErrorDetails.StatusCode, "The status code did not match after deserialization.");
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanNotSubmitAJobWithTheIncorectCredintials()
        {
            IHDInsightCertificateCredential hdInsightCredentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(new HDInsightCertificateCredential(hdInsightCredentials.SubscriptionId, hdInsightCredentials.Certificate));

            var manager = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>();
            var pocoClient = manager.Create(hdInsightCredentials, GetAbstractionContext(), false);

            var clusterDetails = GetRandomCluster();
            client.CreateCluster(clusterDetails);

            try
            {
                ClusterDetails cluster = pocoClient.ListContainer(clusterDetails.Name).WaitForResult();
                BasicAuthCredential hadoopCredentials = new BasicAuthCredential()
                {
                    Server = GatewayUriResolver.GetGatewayUri(cluster.ConnectionUrl),
                    UserName = clusterDetails.UserName,
                    Password = clusterDetails.Password
                };

                var hadoopClient = JobSubmissionClientFactory.Connect(hadoopCredentials);
                var mapReduceJob = new MapReduceJobCreateParameters()
                {
                    ClassName = "pi",
                    JobName = "pi estimation jobDetails",
                    JarFile = "/example/hadoop-examples.jar",
                    StatusFolder = "/piresults"
                };

                mapReduceJob.Arguments.Add("16");
                mapReduceJob.Arguments.Add("10000");

                var jobCreationDetails = hadoopClient.CreateMapReduceJob(mapReduceJob);

                var id = pocoClient.DisableHttp(clusterDetails.Name, clusterDetails.Location).WaitForResult();
                while (!pocoClient.IsComplete(cluster.Name, cluster.Location, id).WaitForResult())
                {
                    Thread.Sleep(500);
                }

                // now add a user
                string userName = "hdinsightuser";
                string password = GetRandomValidPassword();
                id = pocoClient.EnableHttp(clusterDetails.Name, clusterDetails.Location, userName, password).WaitForResult();
                while (!pocoClient.IsComplete(cluster.Name, cluster.Location, id).WaitForResult())
                {
                    Thread.Sleep(500);
                }

                jobCreationDetails = hadoopClient.CreateMapReduceJob(mapReduceJob);

                Assert.Fail("This test expected an exception but did not receive one.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Help.DoNothing(ex);
            }
            finally
            {
                // delete the cluster
                client.DeleteCluster(clusterDetails.Name);
            }


        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeUserChangeResponse()
        {
            var serverConverter = new ClusterProvisioningServerPayloadConverter();

            PassthroughResponse responseObject = new PassthroughResponse() { Data = Guid.NewGuid() };

            var payload = serverConverter.SerailizeChangeRequestResponse(responseObject);

            var deserialized = new PayloadConverter().DeserializeConnectivityResponse(payload);

            Assert.AreEqual(responseObject.Data, deserialized.Data, "Round trip serialize/deserialize enable RDP does not match the ID code");
        }
    }
}
