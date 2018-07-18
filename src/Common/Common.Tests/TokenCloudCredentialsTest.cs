//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net;
using Microsoft.Azure.Common.Test.Fakes;
using Xunit;

namespace Microsoft.Azure.Common.Test
{
    public class TokenCloudCredentialsTest
    {
        [Fact]
        public void TokenCloudCredentialAddsHeader()
        {
            var tokenCredentials = new TokenCloudCredentials("123","abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(tokenCredentials).WithHandler(handler);
            fakeClient.DoStuff().Wait();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);
        }

        [Fact]
        public void TokenCloudCredentialWithoutSubscriptionAddsHeader()
        {
            var tokenCredentials = new TokenCloudCredentials("abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(tokenCredentials).WithHandler(handler);
            fakeClient.DoStuff().Wait();

            Assert.Null(fakeClient.Credentials.SubscriptionId);
            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);
        }

        [Fact]
        public void TokenCloudCredentialUpdatesHeader()
        {
            var credentials = new TokenCloudCredentials("123", "abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(credentials).WithHandler(handler);
            fakeClient.DoStuff().Wait();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);

            credentials.Token = "xyz";
            fakeClient.DoStuff().Wait();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("xyz", handler.RequestHeaders.Authorization.Parameter);
        }
    }
}
