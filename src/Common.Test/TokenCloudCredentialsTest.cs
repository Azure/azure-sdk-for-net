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
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Common.Test.Fakes;
using Microsoft.WindowsAzure.Common.TransientFaultHandling;
using Xunit;
using System.Net.Http;

namespace Microsoft.WindowsAzure.Common.Test
{
    public class TokenCloudCredentialsTest
    {
        [Fact]
        public async void TokenCloudCredentialAddsHeader()
        {
            var tokenCredentials = new TokenCloudCredentials("123","abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(tokenCredentials).WithHandler(handler);
            await fakeClient.DoStuff();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);
        }

        [Fact]
        public async void TokenCloudCredentialUpdatesHeader()
        {
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var fakeClient = new FakeServiceClientWithCredentials(tokenCredentials).WithHandler(handler);
            await fakeClient.DoStuff();

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);

            tokenCredentials.Token = "xyz";

            Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            Assert.Equal("xyz", handler.RequestHeaders.Authorization.Parameter);
        }
    }
}
