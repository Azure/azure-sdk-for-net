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
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.HadoopClientTests
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects;

    [TestClass]
    public class ApiSecurityPocoClientTests : IntegrationTestBase
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
        public void WhenIEnableAndDisableAnHttpUserAPostMesageIsSentToTheServer()
        {
            this.EnableHttpSpy();
            var credentials = GetValidCredentials();
            var pocoClient = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>().Create(credentials, GetAbstractionContext(), false);
            var serverPayloadConverter = new ClusterProvisioningServerPayloadConverter();
            var passthrough = new PassthroughResponse();
            passthrough.Data = Guid.NewGuid();
            this.EnableHttpMock((ca) => new HttpResponseMessageAbstraction(
                                        HttpStatusCode.Accepted, new HttpResponseHeadersAbstraction(), serverPayloadConverter.SerailizeChangeRequestResponse(passthrough)));
            this.ApplyIndividualTestMockingOnly();
            pocoClient.DisableHttp("some name", "somewhere").WaitForResult();
            var httpCalls = this.GetHttpCalls();
            Assert.IsNotNull(httpCalls, "The system could not locate an Http call this could indicate that the test system is not operating correctly.");
            Assert.AreEqual(1, httpCalls.Count());
            var call = httpCalls.FirstOrDefault();
            Assert.AreEqual(HttpMethod.Post, call.Item1.Method);

            this.ClearHttpCalls();
            pocoClient.EnableHttp("some name", "somewhere", "some one", "some secret");
            httpCalls = this.GetHttpCalls();
            Assert.IsNotNull(httpCalls, "The system could not locate an Http call this could indicate that the test system is not operating correctly.");
            Assert.AreEqual(1, httpCalls.Count());
            call = httpCalls.FirstOrDefault();
            Assert.AreEqual(HttpMethod.Post, call.Item1.Method);
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ICanDeleteAndAddAHttpUser()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));

            var manager = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>();
            var pocoClient = manager.Create(credentials, GetAbstractionContext(), false);
            var containers = await pocoClient.ListContainers();
            ClusterDetails clusterDetails = containers.Last();

            var clusterCreationDetails = GetRandomCluster();
            clusterDetails = client.CreateCluster(clusterCreationDetails);

            var operationId = await pocoClient.DisableHttp(clusterDetails.Name, clusterDetails.Location);
            await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

            ClusterDetails cluster = await pocoClient.ListContainer(clusterDetails.Name);

            Assert.IsFalse(String.IsNullOrEmpty(cluster.Name), "Cluster user name is empty, maybe cluster was not created.");
            Assert.IsTrue(String.IsNullOrEmpty(cluster.HttpUserName), "Http user name has not been cleared");
            Assert.IsTrue(String.IsNullOrEmpty(cluster.HttpPassword), "Http password has not been cleared");

            // now add a user
            string userName = "hdinsightuser";
            string password = GetRandomValidPassword();
            operationId = await pocoClient.EnableHttp(clusterDetails.Name, clusterDetails.Location, userName, password);

            await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

            cluster = await pocoClient.ListContainer(clusterDetails.Name);
            Assert.AreEqual(userName, cluster.HttpUserName, "Http user name has not been updated");
            Assert.AreEqual(password, cluster.HttpPassword, "Http password has not been updated");

            if (!string.Equals(clusterDetails.Name, IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName))
            {
                client.DeleteCluster(clusterDetails.Name);
            }
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ICanDeleteAndAddRdpUser()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));

            var manager = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>();
            var pocoClient = manager.Create(credentials, GetAbstractionContext(), false);
            var containers = await pocoClient.ListContainers();
            ClusterDetails clusterDetails = containers.Last();

            var clusterCreationDetails = GetRandomCluster();
            clusterDetails = client.CreateCluster(clusterCreationDetails);
            // now add a user
            string userName = "hdinsightrdpuser";
            string password = GetRandomValidPassword();
            var operationId =
                await
                    pocoClient.EnableRdp(clusterDetails.Name, clusterDetails.Location, userName, password,
                        DateTime.Now.AddDays(6));
            await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

            ClusterDetails cluster = await pocoClient.ListContainer(clusterDetails.Name);

            Assert.IsFalse(String.IsNullOrEmpty(cluster.Name), "Cluster user name is empty, maybe cluster was not created.");
            Assert.AreEqual(userName, cluster.RdpUserName, "Rdp user name has not been updated");

            operationId = await pocoClient.DisableRdp(clusterDetails.Name, clusterDetails.Location);

            await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

            cluster = await pocoClient.ListContainer(clusterDetails.Name);
            Assert.IsTrue(String.IsNullOrEmpty(cluster.RdpUserName), "rdp user name has not been cleared");
            
            if (!string.Equals(clusterDetails.Name, IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName))
            {
                client.DeleteCluster(clusterDetails.Name);
            }
        }

        private static async Task WaitforCompletion(IHDInsightManagementPocoClient pocoClient, string dnsName, string location, Guid operationId)
        {
            await
                pocoClient.WaitForOperationCompleteOrError(dnsName, location, operationId,
                    TimeSpan.FromMilliseconds(IHadoopClientExtensions.GetPollingInterval()), TimeSpan.FromMinutes(10),
                    CancellationToken.None);
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ICanDeleteTheHttpUserTwice()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));

            var manager = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>();
            var pocoClient = manager.Create(credentials, GetAbstractionContext(), false);
            var containers = await pocoClient.ListContainers();
            var clusterDetails = containers.Last();
            if (clusterDetails == null)
            {
                var clusterCreationDetails = GetRandomCluster();
                clusterDetails = client.CreateCluster(clusterCreationDetails);
            }

            var operationId = await pocoClient.DisableHttp(clusterDetails.Name, clusterDetails.Location);
            await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

            try
            {
                operationId = await pocoClient.DisableHttp(clusterDetails.Name, clusterDetails.Location);
                await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

                var cluster = await pocoClient.ListContainer(clusterDetails.Name);

                Assert.IsFalse(String.IsNullOrEmpty(cluster.Name), "Cluster user name is empty, maybe cluster was not created.");
                Assert.IsTrue(String.IsNullOrEmpty(cluster.HttpUserName), "Http user name should still be null");
                Assert.IsTrue(String.IsNullOrEmpty(cluster.HttpPassword), "Http password has not been updated");
            }
            catch (Exception ex)
            {
                Assert.Fail(String.Format("Disabling the Http user is an idempotent operation but is throwing an error: {0}", ex.StackTrace));
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
        public async Task ICannotAddAnotherHttpUser()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));

            var manager = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>();
            var pocoClient = manager.Create(credentials, GetAbstractionContext(), false);
            var containers = await pocoClient.ListContainers();
            ClusterDetails clusterDetails = containers.Last();
            var clusterCreationDetails = GetRandomCluster();
            clusterDetails = client.CreateCluster(clusterCreationDetails);

            var operationId = await pocoClient.DisableHttp(clusterDetails.Name, clusterDetails.Location);
            await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

            // now add a user
            string userName = "hdinsightuser";
            string password = GetRandomValidPassword();
            operationId = await pocoClient.EnableHttp(clusterDetails.Name, clusterDetails.Location, userName, password);
            await WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId);

            try
            {
                userName = "anotheruser";
                password = GetRandomValidPassword();
                await pocoClient.EnableHttp(clusterDetails.Name, clusterDetails.Location, userName, password);
            }
            catch (HttpLayerException ex)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.RequestStatusCode);
                return;
            }
            finally
            {
                // delete the cluster
                if (!string.Equals(clusterDetails.Name, IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName))
                {
                    client.DeleteCluster(clusterDetails.Name);
                }
            }

            Assert.Fail("Adding http user twice did not throw an exception");
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public async Task ICannotSubmitAChangeHttpUserOperationWhileAnotherIsInProgress()
        {
            IHadoopClientExtensions.GetPollingInterval = () => 5;
            this.SetHDInsightManagementRestSimulatorClientOperationTime(100);
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));

            var manager = ServiceLocator.Instance.Locate<IHDInsightManagementPocoClientFactory>();
            var pocoClient = manager.Create(credentials, GetAbstractionContext(), false);
            var containers = await pocoClient.ListContainers();
            ClusterDetails clusterDetails = containers.Last();
            var clusterCreationDetails = GetRandomCluster();
            clusterDetails = client.CreateCluster(clusterCreationDetails);

            var operationId = Guid.Empty;
            var userName = "hdinsightuser";
            var password = GetRandomValidPassword();

            try
            {
                // disable then enable without waiting
                operationId = await pocoClient.DisableHttp(clusterDetails.Name, clusterDetails.Location);
                await pocoClient.EnableHttp(clusterDetails.Name, clusterDetails.Location, userName, password);
                Assert.Fail("Adding http user twice did not throw an exception");
            }
            catch (HttpLayerException ex)
            {
                Assert.AreEqual(HttpStatusCode.Conflict, ex.RequestStatusCode);
            }
            finally
            {
                if (operationId != Guid.Empty)
                {
                    WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId).WaitForResult();
                    Thread.Sleep(HDInsightManagementRestSimulatorClient.OperationTimeToCompletionInMilliseconds * 2);
                    operationId = pocoClient.EnableHttp(clusterDetails.Name, clusterDetails.Location, userName, password).WaitForResult();
                    WaitforCompletion(pocoClient, clusterDetails.Name, clusterDetails.Location, operationId).WaitForResult();
                }

                // delete the cluster
                if (!string.Equals(clusterDetails.Name, IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName))
                {
                    client.DeleteCluster(clusterDetails.Name);
                }
            }

        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeAHttpUserChangeRequest()
        {
            string username = "hdinsightuser";
            string password = GetRandomValidPassword();
            var payload = PayloadConverter.SerializeHttpConnectivityRequest(UserChangeRequestOperationType.Enable, username, password, DateTimeOffset.MinValue);

            var serverConverter = new ClusterProvisioningServerPayloadConverter();
            var request = serverConverter.DeserializeChangeRequest<HttpUserChangeRequest>(payload);

            Assert.AreEqual(username, request.Username, "Round trip serialize/deserialize enable http does not match username");
            Assert.AreEqual(password, request.Password, "Round trip serialize/deserialize enable http does not match password");
            Assert.AreEqual(UserChangeOperationType.Enable, request.Operation, "Round trip serialize/deserialize enable http does not match operation requested");

            payload = PayloadConverter.SerializeHttpConnectivityRequest(UserChangeRequestOperationType.Disable, username, password, DateTimeOffset.MinValue);

            request = serverConverter.DeserializeChangeRequest<HttpUserChangeRequest>(payload);

            Assert.AreEqual(UserChangeOperationType.Disable, request.Operation, "Round trip serialize/deserialize disabl http does not match operation requested");
            // Technically per spec these shouldn't matter for disable... but the serializer should do it's jobDetails correctly.
            Assert.AreEqual(username, request.Username, "Round trip serialize/deserialize disable http does not match username");
            Assert.AreEqual(password, request.Password, "Round trip serialize/deserialize disable http does not match password");
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeAGetOperationStatusWithNoErrorDetails()
        {
            var responseObject = new UserChangeOperationStatusResponse()
            {
                OperationType = UserChangeOperationType.Enable,
                UserType = UserType.Http,
                RequestIssueDate = DateTime.UtcNow,
                State = UserChangeOperationState.Completed,
                Error = null
            };

            var passthroughOpStatus = new PassthroughResponse()
            {
                Data = responseObject,
                Error = null
            };

            // serialize the non error response
            var serializedPassthroughResponse = new ClusterProvisioningServerPayloadConverter();
            var serializedOpResponse = serializedPassthroughResponse.SerailizeChangeRequestResponse(passthroughOpStatus);

            // now deseialize it
            var deserialized = new PayloadConverter().DeserializeConnectivityStatus(serializedOpResponse);
            Assert.IsNotNull(deserialized, "Nothing was returned from the deserializer.");
            Assert.IsNotNull(deserialized.Data, "No data object was present after deserialization.");
            Assert.AreEqual(responseObject.OperationType.ToString(), deserialized.Data.OperationType.ToString(), "The OperationType did not match after deserialization.");
            Assert.AreEqual(responseObject.RequestIssueDate, deserialized.Data.RequestIssueDate, "The IssueDate did not match after deserialization.");
            Assert.AreEqual(responseObject.State.ToString(), deserialized.Data.State.ToString(), "The State did not match after deserialization.");
            Assert.AreEqual(responseObject.UserType.ToString(), deserialized.Data.UserType.ToString(), "The user type not match after deserialization.");
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeAGetOperationStatusWithErrorDetails()
        {
            var errorStatusCode = HttpStatusCode.NotAcceptable;
            var errorIdDetails = "Error123";
            var errorMessageDetails = "This is an error!";
            ErrorDetails errorDetails = new ErrorDetails()
            {
                StatusCode = errorStatusCode,
                ErrorId = errorIdDetails,
                ErrorMessage = errorMessageDetails
            };

            var userChangeResponse = new UserChangeOperationStatusResponse()
            {
                OperationType = UserChangeOperationType.Enable,
                UserType = UserType.Http,
                RequestIssueDate = DateTime.UtcNow,
                State = UserChangeOperationState.Completed,
                Error = errorDetails
            };

            var responseObject = new PassthroughResponse()
            {
                Data = userChangeResponse,
                Error = errorDetails
            };

            // SERIALIZE THE RESPONSE
            var serializedPassthroughResponse = new ClusterProvisioningServerPayloadConverter();
            var serializedOpResponse = serializedPassthroughResponse.SerailizeChangeRequestResponse(responseObject);

            // now deseialize it
            var deserialized = new PayloadConverter().DeserializeConnectivityStatus(serializedOpResponse);

            Assert.IsNotNull(deserialized, "Nothing was returned from the deserializer.");
            Assert.IsNotNull(deserialized.ErrorDetails, "No error object was present after deserialization.");
            Assert.AreEqual(responseObject.Error.ErrorId, deserialized.ErrorDetails.ErrorId, "The Error Id did not match after deserialization.");
            Assert.AreEqual(responseObject.Error.ErrorMessage, deserialized.ErrorDetails.ErrorMessage, "The error message did not match after deserialization.");
            Assert.AreEqual(responseObject.Error.StatusCode, deserialized.ErrorDetails.StatusCode, "The status code did not match after deserialization.");
            Assert.IsNotNull(deserialized.Data, "No data object was present after deserialization.");
            Assert.AreEqual(userChangeResponse.OperationType.ToString(), deserialized.Data.OperationType.ToString(), "The OperationType did not match after deserialization.");
            Assert.AreEqual(userChangeResponse.RequestIssueDate, deserialized.Data.RequestIssueDate, "The IssueDate did not match after deserialization.");
            Assert.AreEqual(userChangeResponse.State.ToString(), deserialized.Data.State.ToString(), "The State did not match after deserialization.");
            Assert.AreEqual(userChangeResponse.UserType.ToString(), deserialized.Data.UserType.ToString(), "The user type not match after deserialization.");

            Assert.IsNotNull(deserialized.Data.ErrorDetails, "No error object was present after deserialization.");
            Assert.AreEqual(userChangeResponse.Error.ErrorId, deserialized.Data.ErrorDetails.ErrorId, "The (inner) Error Id did not match after deserialization.");
            Assert.AreEqual(userChangeResponse.Error.ErrorMessage, deserialized.Data.ErrorDetails.ErrorMessage, "The (inner) error message did not match after deserialization.");
            Assert.AreEqual(userChangeResponse.Error.StatusCode, deserialized.Data.ErrorDetails.StatusCode, "The (inner) status code did not match after deserialization.");
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeAGetOperationStatusWithNilData()
        {
            var serializedOpResponse =
                "<PassthroughResponse xmlns='http://schemas.microsoft.com/hdinsight/2013/05/management' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'><Data i:nil='true'/><Error><StatusCode>NotFound</StatusCode><ErrorId>INVALID_PASSTHROUGHREQUEST</ErrorId><ErrorMessage>INVALID_PASSTHROUGHREQUEST</ErrorMessage></Error></PassthroughResponse>";
            // now deseialize it
            var deserialized = new PayloadConverter().DeserializeConnectivityResponse(serializedOpResponse);

            Assert.IsNotNull(deserialized, "Nothing was returned from the deserializer.");
            Assert.IsNotNull(deserialized.ErrorDetails, "No error object was present after deserialization.");
            Assert.AreEqual(deserialized.ErrorDetails.ErrorId, "INVALID_PASSTHROUGHREQUEST");
            Assert.AreEqual(deserialized.ErrorDetails.ErrorMessage, "INVALID_PASSTHROUGHREQUEST");
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        public void ICanSerializeAndDeserializeAChangeRequestPassthroughWithNullFields()
        {
            var responseObject = new PassthroughResponse()
            {
                Data = null,
                Error = null
            };
            // SERIALIZE THE RESPONSE
            var serializedPassthroughResponse = new ClusterProvisioningServerPayloadConverter();
            var serializedOpResponse = serializedPassthroughResponse.SerailizeChangeRequestResponse(responseObject);

            // now deseialize it
            var deserialized = new PayloadConverter().DeserializeConnectivityResponse(serializedOpResponse);
        }
    }
}
