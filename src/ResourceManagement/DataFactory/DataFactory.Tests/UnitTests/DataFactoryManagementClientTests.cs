// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Net.Http;
using DataFactory.Tests.Framework;
using Microsoft.Azure;
using Microsoft.Azure.Management.DataFactories;
using Moq;
using Xunit;
using Core = Microsoft.Azure.Management.DataFactories.Core;

namespace DataFactory.Tests.UnitTests
{
    public class DataFactoryManagementClientTests
    {
        private static readonly Uri TestBaseUri = new Uri("https://fakebaseuri.azure.com");

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void DefaultContructorTest()
        {
            var client = new DataFactoryManagementClient();
            DataFactoryManagementClientTests.ValidateDefaultClientProperties(client);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void ConstructorWithCredentialsTest()
        {
            Mock<TokenCloudCredentials> mockCredentials = CreateMockCredentials();
            SubscriptionCloudCredentials creds = mockCredentials.Object;

            var client = new DataFactoryManagementClient(creds);
            DataFactoryManagementClientTests.ValidateClientWithCredentials(client, creds, mockCredentials);
            Assert.NotNull(client.BaseUri);
            Assert.NotNull(client.InternalClient.BaseUri);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void ConstructorWithCredentialsAndBaseUriTest()
        {
            Mock<TokenCloudCredentials> mockCredentials = CreateMockCredentials();
            SubscriptionCloudCredentials creds = mockCredentials.Object;

            var client = new DataFactoryManagementClient(creds, TestBaseUri);

            ValidateClientWithCredentials(client, creds, mockCredentials);
            Assert.Equal(TestBaseUri, client.BaseUri);
            Assert.Equal(TestBaseUri, client.InternalClient.BaseUri);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void ConstructorWithHttpClientTest()
        {
            var httpClient = new HttpClient();
            var client = new DataFactoryManagementClient(httpClient);

            ValidateDefaultClientProperties(client);
            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(httpClient, client.InternalClient.HttpClient);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void ConstructorWithCredentialsAndHttpClientTest()
        {
            var httpClient = new HttpClient();
            Mock<TokenCloudCredentials> mockCredentials = CreateMockCredentials();
            SubscriptionCloudCredentials creds = mockCredentials.Object;

            var client = new DataFactoryManagementClient(creds, httpClient);

            ValidateClientWithCredentials(client, creds, mockCredentials);
            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(httpClient, client.InternalClient.HttpClient);
        }
        
        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void ConstructorWithCredentialsAndBaseUriAndHttpClientTest()
        {
            var httpClient = new HttpClient();
            Mock<TokenCloudCredentials> mockCredentials = CreateMockCredentials();
            SubscriptionCloudCredentials creds = mockCredentials.Object;

            var client = new DataFactoryManagementClient(creds, TestBaseUri, httpClient);

            ValidateClientWithCredentials(client, creds, mockCredentials);
            Assert.Equal(TestBaseUri, client.BaseUri);
            Assert.Equal(TestBaseUri, client.InternalClient.BaseUri);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(httpClient, client.InternalClient.HttpClient);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void RetryTimeoutsMatchInternalTimeouts()
        {
            int testTimeout = 9;

            var client = new DataFactoryManagementClient();
            Core.DataFactoryManagementClient internalClient = client.InternalClient;

            Assert.Equal(internalClient.LongRunningOperationInitialTimeout, client.LongRunningOperationInitialTimeout);
            Assert.Equal(internalClient.LongRunningOperationRetryTimeout, client.LongRunningOperationRetryTimeout);

            client.LongRunningOperationRetryTimeout = testTimeout;
            Assert.Equal(client.LongRunningOperationRetryTimeout, internalClient.LongRunningOperationRetryTimeout);
            Assert.Equal(testTimeout, internalClient.LongRunningOperationRetryTimeout);

            client.LongRunningOperationInitialTimeout = testTimeout;
            Assert.Equal(client.LongRunningOperationInitialTimeout, internalClient.LongRunningOperationInitialTimeout);
            Assert.Equal(testTimeout, internalClient.LongRunningOperationInitialTimeout);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void CredentialsAreSameAsInternalCredentials()
        {
            var client = new DataFactoryManagementClient();
            Core.DataFactoryManagementClient internalClient = client.InternalClient;

            Assert.Equal(internalClient.Credentials, client.Credentials);
            Assert.Same(internalClient.Credentials, client.Credentials);

            TokenCloudCredentials testCreds = CreateMockCredentials().Object;

            client.Credentials = testCreds;
            Assert.Equal(internalClient.Credentials, client.Credentials);
            Assert.Same(internalClient.Credentials, client.Credentials);
            Assert.Equal(testCreds, internalClient.Credentials);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void BaseUriIsSameAsInternalBaseUri()
        {
            var client = new DataFactoryManagementClient();
            Core.DataFactoryManagementClient internalClient = client.InternalClient;

            Assert.Equal(internalClient.BaseUri, client.BaseUri);
            Assert.Same(internalClient.BaseUri, client.BaseUri);

            client.BaseUri = TestBaseUri;
            Assert.Equal(internalClient.BaseUri, client.BaseUri);
            Assert.Same(internalClient.BaseUri, client.BaseUri);
            Assert.Equal(TestBaseUri, internalClient.BaseUri);
        }

        private static void ValidateClientWithCredentials(
            DataFactoryManagementClient client,
            SubscriptionCloudCredentials expectedCredentials, 
            Mock<TokenCloudCredentials> mockCredentials)
        {
            ValidateDefaultClientProperties(client);
            Assert.Equal(expectedCredentials, client.Credentials);
            Assert.Equal(expectedCredentials, client.InternalClient.Credentials);

            Assert.NotNull(client.InternalClient.BaseUri);
            Assert.NotNull(client.BaseUri);

            ValidateCredentialMock(mockCredentials, client);
        }

        private static void ValidateDefaultClientProperties(DataFactoryManagementClient client)
        {
            Assert.NotNull(client);

            Core.DataFactoryManagementClient internalClient = client.InternalClient;

            Assert.NotNull(internalClient);
            Assert.Equal(internalClient.LongRunningOperationInitialTimeout, client.LongRunningOperationInitialTimeout);
            Assert.Equal(internalClient.LongRunningOperationRetryTimeout, client.LongRunningOperationRetryTimeout);
            Assert.NotNull(client.HttpClient);
            Assert.NotNull(client.InternalClient.HttpClient);
            Assert.Equal(internalClient.HttpClient.Timeout, client.HttpClient.Timeout);
        }

        private static void ValidateCredentialMock(Mock<TokenCloudCredentials> mockCredentials, DataFactoryManagementClient client)
        {
            mockCredentials.Verify(creds => creds.InitializeServiceClient(client), Times.Once);
            mockCredentials.Verify(creds => creds.InitializeServiceClient(client.InternalClient), Times.Once);
        }

        private static Mock<TokenCloudCredentials> CreateMockCredentials()
        {
            return new Mock<TokenCloudCredentials>("subId", "token");
        }
    }
}
