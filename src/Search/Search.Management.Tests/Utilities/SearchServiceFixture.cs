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

using Microsoft.Azure.Management.Search;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public class SearchServiceFixture : ResourceGroupFixture
    {
        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            SearchManagementClient client = context.GetServiceClient<SearchManagementClient>();

            SearchServiceName = SearchTestUtilities.GenerateServiceName();

            var createServiceParameters =
                new SearchServiceCreateOrUpdateParameters()
                {
                    Location = Location,
                    Properties = new SearchServiceProperties() { Sku = new Sku() { Name = SkuType.Free } }
                };

            SearchServiceResource service =
                client.Services.CreateOrUpdate(ResourceGroupName, SearchServiceName, createServiceParameters);
            Assert.NotNull(service);

            AdminKeyResult adminKeyResult = client.AdminKeys.List(ResourceGroupName, SearchServiceName);
            Assert.NotNull(adminKeyResult);

            PrimaryApiKey = adminKeyResult.PrimaryKey;

            ListQueryKeysResult queryKeyResult = client.QueryKeys.List(ResourceGroupName, SearchServiceName);
            Assert.NotNull(queryKeyResult);
            Assert.Equal(1, queryKeyResult.Value.Count);

            QueryApiKey = queryKeyResult.Value[0].Key;
        }

        public string SearchServiceName { get; private set; }

        public string PrimaryApiKey { get; private set; }

        public string QueryApiKey { get; private set; }
    }
}
