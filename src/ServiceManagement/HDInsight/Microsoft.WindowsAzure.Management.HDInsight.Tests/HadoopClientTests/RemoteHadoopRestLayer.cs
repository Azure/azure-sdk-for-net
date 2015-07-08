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
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionRestCleint.Remote;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Moq;

    [TestClass]
    public class RemoteHadoopRestLayer : IntegrationTestBase
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

        internal class MockResults
        {
            public Uri RequestUri { get; set; }
            public bool SendAsyncCalled { get; set; }
            public Dictionary<string, string> Headers { get; set; }
            public HttpMethod Method { get; set; }
            public HttpContent Content { get; set; }
 
            public MockResults()
            {
                this.SendAsyncCalled = false;
                this.Headers = new Dictionary<string, string>();
                this.Content = new StringContent(String.Empty);
            }
        }

        internal MockResults SetupHttpAbstractionMocking()
        {
            var results = new MockResults();
            // Locate the test manager so we can override the lower layer.
            var manager = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();

            // Create a Mock of the HTTP layer response.
            var moqResponse = new Moq.Mock<IHttpResponseMessageAbstraction>(MockBehavior.Loose);
            // Always return 200 OK
            moqResponse.SetupGet(res => res.StatusCode)
                       .Returns(HttpStatusCode.OK);

            // Create a mock of the Request client.
            var moqClient = new Moq.Mock<IHttpClientAbstraction>(MockBehavior.Loose);

            // Mock the return to set the request headers.
            moqClient.SetupGet(client => client.RequestHeaders)
                     .Returns(() => results.Headers);

            // Mock the return to set the request uri.
            moqClient.SetupGet(client => client.RequestUri)
                     .Returns(() => results.RequestUri);

            // Mock the return to set the request uri.
            moqClient.SetupSet(abstraction => abstraction.RequestUri = It.IsAny<Uri>()).Callback<Uri>(uri => results.RequestUri = uri);

            // Mock the return to set the http method.
            moqClient.SetupGet(client => client.Method)
                     .Returns(() => results.Method);

            // Mock the return to set the http method.
            moqClient.SetupSet(abstraction => abstraction.Method = It.IsAny<HttpMethod>()).Callback<HttpMethod>(method => results.Method = method);

            // Mock the return to set the content.
            moqClient.SetupGet(client => client.Content)
                     .Returns(() => results.Content);

            moqClient.SetupSet(abstraction => abstraction.Content = It.IsAny<HttpContent>()).Callback<HttpContent>(content => results.Content = content);

            // Mock the SendAsync method (to just return the response object previously created).
            moqClient.Setup(c => c.SendAsync())
                     .Returns(() => Task.Run(() =>
                     {
                         results.SendAsyncCalled = true;
                         return moqResponse.Object;
                     }));

            // Mock the factory to return our mock client.
            var moqFactory = new Moq.Mock<IHttpClientAbstractionFactory>();

            // Overload both create methods.
            moqFactory.Setup(fac => fac.Create(It.IsAny<X509Certificate2>(), It.IsAny<HDInsight.IAbstractionContext>(), false))
                      .Returns(() => moqClient.Object);
            moqFactory.Setup(fac => fac.Create(It.IsAny<HDInsight.IAbstractionContext>(), false))
                      .Returns(() => moqClient.Object);

            // Override the factory in the Service Locator (for this test only).
            manager.Override<IHttpClientAbstractionFactory>(moqFactory.Object);
           
            return results;
        }

        internal BasicAuthCredential GetRemoteHadoopCredential()
        {
            var azureTestCredentials = GetCredentials("hadoop");
            var credentials = new BasicAuthCredential()
            {
                Server = new Uri(azureTestCredentials.WellKnownCluster.Cluster),
                UserName = azureTestCredentials.AzureUserName,
                Password = azureTestCredentials.AzurePassword
            };
            return credentials;
        }

        private string userAgentString = "Mock Test UserAgent";

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ListJobsWithValidRequest()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call ListJobs.
            restClient.ListJobs().WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Get, mockResults.Method);
            Assert.AreEqual("/templeton/v1/jobs", mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + cred.UserName + "&" + HadoopRemoteRestConstants.ShowAllFields, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json",mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ListJobsWithUsernameThatNeedsToBeEncoded()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            cred.UserName = "&Needs=Encoding";
            var encodedUserName = "%26Needs%3DEncoding";
            
            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call ListJobs
            restClient.ListJobs().WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Get, mockResults.Method);
            Assert.AreEqual("/templeton/v1/jobs", mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + encodedUserName + "&" + HadoopRemoteRestConstants.ShowAllFields, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void GetJobWithValidRequest()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call GetJob.
            var jobId = "12345";
            restClient.GetJob(jobId).WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Get, mockResults.Method);
            Assert.AreEqual("/templeton/v1/jobs/" + jobId, mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + cred.UserName, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void GetJobWithUsernameThatNeedsToBeEncoded()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            cred.UserName = "&Needs=Encoding";
            var encodedUserName = "%26Needs%3DEncoding";

            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call GetJob
            var jobId = "12345";
            restClient.GetJob(jobId).WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Get, mockResults.Method);
            Assert.AreEqual("/templeton/v1/jobs/" +jobId, mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + encodedUserName, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void GetJobWithJobIdThatNeedsToBeEncoded()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();

            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call GetJob
            var jobId = "1&2=345";
            var encodedJobId = "1%262%3D345";
            restClient.GetJob(jobId).WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Get, mockResults.Method);
            Assert.AreEqual("/templeton/v1/jobs/" + encodedJobId, mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + cred.UserName, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SubmitHiveJobWithValidRequest()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call SubmitHiveJob.
            var payload = "some payload";
            restClient.SubmitHiveJob(payload).WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Post, mockResults.Method);
            Assert.AreEqual("/templeton/v1/hive", mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + cred.UserName , mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
            Assert.AreEqual(payload, mockResults.Content.ReadAsStringAsync().Result);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SubmitHiveJobWithUsernameThatNeedsToBeEncoded()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            cred.UserName = "&Needs=Encoding";
            var encodedUserName = "%26Needs%3DEncoding";

            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call SubmitHiveJob.
            var payload = "some payload";
            restClient.SubmitHiveJob(payload).WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Post, mockResults.Method);
            Assert.AreEqual("/templeton/v1/hive", mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + encodedUserName, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
            Assert.AreEqual(payload, mockResults.Content.ReadAsStringAsync().Result);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SubmitMRJarJobWithValidRequest()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call SubmitHiveJob.
            var payload = "some payload";
            restClient.SubmitMapReduceJob(payload).WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Post, mockResults.Method);
            Assert.AreEqual("/templeton/v1/mapreduce/jar", mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + cred.UserName, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
            Assert.AreEqual(payload, mockResults.Content.ReadAsStringAsync().Result);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SubmitMRJarJobWithUsernameThatNeedsToBeEncoded()
        {
            var mockResults = SetupHttpAbstractionMocking();

            // Get the Asv Client factory.
            var factory = ServiceLocator.Instance.Locate<IHadoopRemoteJobSubmissionRestClientFactory>();

            var cred = GetRemoteHadoopCredential();
            cred.UserName = "&Needs=Encoding";
            var encodedUserName = "%26Needs%3DEncoding";

            // Create a client.
            var restClient = factory.Create(cred, GetAbstractionContext(), false, userAgentString);

            // Call SubmitHiveJob.
            var payload = "some payload";
            restClient.SubmitMapReduceJob(payload).WaitForResult();

            Assert.IsTrue(mockResults.SendAsyncCalled);

            Assert.AreEqual(HttpMethod.Post, mockResults.Method);
            Assert.AreEqual("/templeton/v1/mapreduce/jar", mockResults.RequestUri.AbsolutePath);
            Assert.AreEqual("?user.name=" + encodedUserName, mockResults.RequestUri.Query);
            Assert.AreEqual(4, mockResults.Headers.Count);
            Assert.IsTrue(mockResults.Headers.ContainsKey("accept"));
            Assert.IsTrue(mockResults.Headers.ContainsKey("useragent"));
            Assert.AreEqual("application/json", mockResults.Headers["accept"]);
            Assert.IsTrue(mockResults.Headers.ContainsKey("Authorization"));
            Assert.IsTrue(mockResults.Headers["Authorization"].StartsWith("Basic "));
            Assert.AreEqual(payload, mockResults.Content.ReadAsStringAsync().Result);
        }
    }
}
