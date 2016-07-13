﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Client;
using System;
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

        [Theory]
        [InlineData("BaseUri=https://management-preview.core.windows-int.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;Environment=Dogfood")]
        [InlineData("GraphUri=https://management-preview.core.windows-int.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;Environment=Dogfood")]
        [InlineData("GalleryUri=https://management-preview.core.windows-int.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;Environment=Dogfood")]
        [InlineData("AADAuthEndpoint=https://management-preview.core.windows-int.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;Environment=Dogfood")]
        [InlineData("GalleryUri=http://foo;AADAuthEndpoint=https://management-preview.core.windows-int.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;Environment=Dogfood")]
        public void EnvironmentFactoryThrowsIfCsmConnectionStringHasEnvironmentAndEndpoints(string connection)
        {
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connection);
            Assert.Throws<ArgumentException>(() => TestEnvironmentFactory.GetTestEnvironment());
        }

        [Fact]
        public void EnvironmentFactoryInCsmUsesBaseUriEndpointFromConnectionString()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "BaseUri=https://foo.net;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=123");
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            Assert.Equal("https://foo.net/", environment.BaseUri.ToString());
            Assert.Equal(TestEnvironment.EnvEndpoints[EnvironmentNames.Prod].GalleryUri, environment.Endpoints.GalleryUri);
        }

        [Fact]
        public void EnvironmentFactoryInCsmDoesNotGetSubscriptionIfSubscriptionIdIsNone()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Prod;SubscriptionId=None");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmClientSubscriptionNone.json");
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
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            Assert.Equal("https://foo.net/", environment.BaseUri.ToString());
            Assert.Equal(TestEnvironment.EnvEndpoints[EnvironmentNames.Prod].GalleryUri, environment.Endpoints.GalleryUri);
            Assert.Equal("https://www.graph.net/", environment.Endpoints.GraphUri.ToString());
        }

        [Fact]
        public void TestGetServiceClientWithoutHandlers()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=abc");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmTests.json");
            var client = MockContext.Start((this.GetType().FullName)).GetServiceClient<SimpleClient>();
            Assert.Equal(4, client.HttpMessageHandlers.Count());
            Assert.True(client.HttpMessageHandlers.First() is HttpMockServer);
        }

        [Fact]
        public void TestGetServiceClientWithHandlers()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=abc");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmTests.json");
            var client = MockContext.Start((this.GetType().FullName)).GetServiceClient<SimpleClient>(handlers: new MockHandler());
            Assert.Equal(5, client.HttpMessageHandlers.Count());
            Assert.True(client.HttpMessageHandlers.First() is MockHandler);
        }

        [Fact]
        public void TestGetServiceClientWhenSubscriptionIdIsNone()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=None;RawToken=abc");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmClientSubscriptionNone.json");
            var client = MockContext.Start((this.GetType().FullName)).GetServiceClient<SimpleClient>(handlers: new MockHandler());
            Assert.Equal(5, client.HttpMessageHandlers.Count());
            Assert.True(client.HttpMessageHandlers.First() is MockHandler);
        }

        [Fact]
        public void TestMockServerAddedOnce()
        {
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            Environment.SetEnvironmentVariable("TEST_CONNECTION_STRING", "");
            Environment.SetEnvironmentVariable("TEST_ORGID_AUTHENTICATION", "");
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "Environment=Next;SubscriptionId=ee39cb6d-d45b-4694-825a-f4d6f87ed72a;RawToken=abc");
            HttpMockServer.Initialize("Microsoft.Rest.ClientRuntime.Azure.TestFramework.Test.Authentication.Subscription", "CsmTests.json");
            var handler = new MockHandler();
            var client1 = MockContext.Start(this.GetType().FullName).GetServiceClient<SimpleClient>(handlers: handler);
            Assert.Equal(1, CountMockServers(handler));
            var client2 = MockContext.Start(this.GetType().FullName).GetServiceClient<SimpleClient>(handlers: handler);
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
