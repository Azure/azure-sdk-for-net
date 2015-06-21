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

using System;
using System.Net;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class SearchServiceClientTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void RequestIdIsReturnedInResponse()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                
                // We need to use a constant GUID so that this test will still work in playback mode.
                Guid myRequestId = new Guid("c4cfce79-eb42-4e61-9909-84510c04706f");
                client.SetClientRequestId(myRequestId);

                IndexListResponse listResponse = client.Indexes.List();
                Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);

                Assert.Equal(myRequestId.ToString(), listResponse.RequestId);
            });
        }

        [Fact]
        public void CanGetAnIndexClient()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();
                SearchIndexClient indexClient = serviceClient.Indexes.GetClient("test");

                Assert.Equal(serviceClient.Credentials.ApiKey, indexClient.Credentials.ApiKey);
                Assert.Equal(new Uri(serviceClient.BaseUri, "/indexes('test')"), indexClient.BaseUri);
            });
        }

        [Fact]
        public void CanGetAnIndexClientAfterUsingServiceClient()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();
                serviceClient.Indexes.Delete("thisindexdoesnotexist");

                // Should not throw.
                serviceClient.Indexes.GetClient("test");
            });
        }
    }
}
