// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Client;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication
{
    [Collection("SerialCollection1")]
    public class Subscription : TestBase, IDisposable
    {
        private string TEST_CONNECTION_STRING;
        private string AZURE_TEST_MODE;
        private string TEST_ORGID_AUTHENTICATION;
        private string TEST_CSM_ORGID_AUTHENTICATION;

        public Subscription()
        {
            TEST_CONNECTION_STRING = Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING");
            AZURE_TEST_MODE = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            TEST_ORGID_AUTHENTICATION = Environment.GetEnvironmentVariable("TEST_ORGID_AUTHENTICATION");
            TEST_CSM_ORGID_AUTHENTICATION = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            if (HttpMockServer.FileSystemUtilsObject == null)
            {
                HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            }
        }

        [Theory]
        [InlineData("Playback", "")]
        [InlineData("Playback", "Environment=Prod")]
        [InlineData("Playback", "Environment=Current")]
        public void CsmTests(string mode, string envString)
        {
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", mode);
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", envString);
            HttpMockServer.RecordsDirectory = "SessionRecords";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testEnv = TestEnvironmentFactory.GetTestEnvironment();
                var client = context.GetServiceClient<SimpleClient>(testEnv);
                var graphClient = context.GetGraphServiceClient<SimpleClient>(testEnv);
                var response = client.CsmGetLocation();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                Assert.Equal(testEnv.Endpoints.ResourceManagementUri, client.BaseUri);
                Assert.Equal(testEnv.Endpoints.GraphUri, graphClient.BaseUri);
            }
        }

        [Fact]
        public void EnvironmentFactoryInCsmUsesBaseUriEndpointFromConnectionString()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "BaseUri=https://foo.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=123");
            TestEnvironment testEnv = new TestEnvironment();
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            Assert.Equal("https://foo.net/", environment.BaseUri.ToString());
            Assert.Equal(testEnv.EnvEndpoints[EnvironmentNames.Prod].GalleryUri, environment.Endpoints.GalleryUri);
        }

        [Fact]
        public void EnvironmentFactoryInCsmDoesNotGetSubscriptionIfSubscriptionIdIsNone()
        {
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Prod;SubscriptionId=None");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmClientSubscriptionNone.json");
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            Assert.Equal("None", environment.SubscriptionId);
        }

        [Fact]
        public void EnvironmentFactoryInCsmUsesEndpointFromConnectionString()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "GraphUri=https://www.graph.net;BaseUri=https://foo.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a");
            TestEnvironment testEnv = new TestEnvironment();
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            Assert.Equal("https://foo.net/", environment.BaseUri.ToString());
            Assert.Equal(testEnv.EnvEndpoints[EnvironmentNames.Prod].GalleryUri, environment.Endpoints.GalleryUri);
            Assert.Equal("https://www.graph.net/", environment.Endpoints.GraphUri.ToString());
        }

        [Fact]
        public void TestGetServiceClientWithoutHandlers()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=abc");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmTests.json");
            var client = MockContext.Start((this.GetType().FullName), "CsmTests.json").GetServiceClient<SimpleClient>();
            Assert.Equal(5, client.HttpMessageHandlers.Count());
            Assert.True(client.HttpMessageHandlers.First() is HttpMockServer);
        }

        [Fact]
        public void TestGetServiceClientWithHandlers()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=abc");
            HttpMockServer.RecordsDirectory = "SessionRecords";
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmTests.json");
            var client = MockContext.Start((this.GetType().FullName), "CsmTests.json").GetServiceClient<SimpleClient>(handlers: new MockHandler());
            Assert.Equal(6, client.HttpMessageHandlers.Count());
            Assert.True(client.HttpMessageHandlers.First() is MockHandler);
        }

        [Fact]
        public void TestGetServiceClientWhenSubscriptionIdIsNone()
        {
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=None;RawToken=abc");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmClientSubscriptionNone.json");
            var client = MockContext.Start((this.GetType().FullName), "CsmClientSubscriptionNone").GetServiceClient<SimpleClient>(handlers: new MockHandler());
            Assert.Equal(6, client.HttpMessageHandlers.Count());
            Assert.True(client.HttpMessageHandlers.First() is MockHandler);
        }

        [Fact]
        public void TestMockServerAddedOnce()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=abc");
            HttpMockServer.RecordsDirectory = "SessionRecords";
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmTests.json");
            var handler = new MockHandler();
            var client1 = MockContext.Start(this.GetType().FullName, "CsmTests.json").GetServiceClient<SimpleClient>(handlers: handler);
            Assert.Equal(1, CountMockServers(handler));
            var client2 = MockContext.Start(this.GetType().FullName, "CsmTests.json").GetServiceClient<SimpleClient>(handlers: handler);
            Assert.Equal(1, CountMockServers(handler));
        }

        public static int CountMockServers(DelegatingHandler handler)
        {
            var result = 0;
            if (handler is HttpMockServer)
            {
                result++;
            }

            if (handler.InnerHandler != null && handler.InnerHandler is DelegatingHandler)
            {
                result += CountMockServers(handler.InnerHandler as DelegatingHandler);
            }

            return result;
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", TEST_CONNECTION_STRING);
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", AZURE_TEST_MODE);
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", TEST_ORGID_AUTHENTICATION);
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", TEST_CSM_ORGID_AUTHENTICATION);
        }
    }
}
