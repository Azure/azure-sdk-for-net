// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using CR.Azure.NetCore.Tests;
using Xunit;
using Microsoft.Azure;
using CR.Azure.NetCore.Tests.Fakes;

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    [Collection("ADAL Test Collection")]
    public class TokenCloudCredentialsTest
    {
        [Fact]
        public void TokenCloudCredentialAddsHeader()
        {
            var tokenCredentials = new TokenCredentials("abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(tokenCredentials);
            fakeClient = new FakeServiceClientWithCredentials(tokenCredentials, handler);
            fakeClient.DoStuff().Wait();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);
        }

        [Fact]
        public void TokenCloudCredentialWithoutSubscriptionAddsHeader()
        {
            var tokenCredentials = new TokenCredentials("abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(tokenCredentials);
            fakeClient = new FakeServiceClientWithCredentials(tokenCredentials, handler);
            fakeClient.DoStuff().Wait();

            //Assert.Null(fakeClient.Credentials.SubscriptionId);
            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);
        }

        [Fact]
        public void TokenCloudCredentialUpdatesHeader()
        {
            var credentials = new TokenCredentials("abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(credentials);
            fakeClient = new FakeServiceClientWithCredentials(credentials, handler);
            fakeClient.DoStuff().Wait();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);

            credentials= new TokenCredentials("xyz");
            fakeClient = new FakeServiceClientWithCredentials(credentials, handler);

            fakeClient.DoStuff().Wait();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("xyz", handler.RequestHeaders.Authorization.Parameter);
        }
    }
}
