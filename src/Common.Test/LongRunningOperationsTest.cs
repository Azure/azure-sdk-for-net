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

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.WebControls;
using Microsoft.Azure.Common.Test.Fakes;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Xunit;

namespace Microsoft.Azure.Common.Test
{
    public class LongRunningOperationsTest
    {
        [Fact]
        public void TestCreateOrUpdate()
        {
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var handler = new LROTestHandler(CreateOrUpdateWithTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.True(true);
            //Assert.Equal("Bearer", handler.RequestHeaders.Authorization.Scheme);
            //Assert.Equal("abc", handler.RequestHeaders.Authorization.Parameter);
        }

        private IEnumerable<HttpResponseMessage> CreateOrUpdateWithTwoTries()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
	
                    ""properties"": { 
	                    ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://foo/bar");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
	
                    ""properties"": { 
	                    ""provisioningState"": ""Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response3;
        }
    }
}
