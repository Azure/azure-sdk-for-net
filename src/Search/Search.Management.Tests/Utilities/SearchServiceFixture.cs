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
using Microsoft.Azure.Management.Search;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public class SearchServiceFixture : ResourceGroupFixture
    {
        public SearchServiceFixture()
        {
            SearchManagementClient client = 
                TestBase.GetServiceClient<SearchManagementClient>(new CSMTestEnvironmentFactory());

            SearchServiceName = SearchTestUtilities.GenerateServiceName();

            var createServiceParameters =
                new SearchServiceCreateOrUpdateParameters()
                {
                    Location = Location,
                    Properties = new SearchServiceProperties() { Sku = new Sku(SkuType.Free) }
                };

            SearchServiceCreateOrUpdateResponse createServiceResponse =
                client.Services.CreateOrUpdate(ResourceGroupName, SearchServiceName, createServiceParameters);
            Assert.Equal(HttpStatusCode.Created, createServiceResponse.StatusCode);

            AdminKeyResponse adminKeyResponse = client.AdminKeys.List(ResourceGroupName, SearchServiceName);
            Assert.Equal(HttpStatusCode.OK, adminKeyResponse.StatusCode);

            PrimaryApiKey = adminKeyResponse.PrimaryKey;

            ListQueryKeysResponse queryKeyResponse = client.QueryKeys.List(ResourceGroupName, SearchServiceName);
            Assert.Equal(HttpStatusCode.OK, queryKeyResponse.StatusCode);
            Assert.Equal(1, queryKeyResponse.QueryKeys.Count);

            QueryApiKey = queryKeyResponse.QueryKeys[0].Key;
        }

        public string SearchServiceName { get; private set; }

        public string PrimaryApiKey { get; private set; }

        public string QueryApiKey { get; private set; }
    }
}
