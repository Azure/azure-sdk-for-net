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

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public class ResourceGroupFixture
    {
        private const string SearchNamespace = "Microsoft.Search";

        public ResourceGroupFixture()
        {
            ResourceManagementClient client = 
                TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());

            // Register subscription
            AzureOperationResponse registerResponse = client.Providers.Register(SearchNamespace);
            Assert.Equal(HttpStatusCode.OK, registerResponse.StatusCode);

            // Get a valid location for search services.
            ProviderGetResult providerResult = client.Providers.Get(SearchNamespace);
            Assert.Equal(HttpStatusCode.OK, providerResult.StatusCode);

            // We only support one resource type.
            Location = providerResult.Provider.ResourceTypes.First().Locations.First();

            // Create resource group
            ResourceGroupName = TestUtilities.GenerateName();
            ResourceGroupCreateOrUpdateResult resourceGroupResult =
                client.ResourceGroups.CreateOrUpdate(ResourceGroupName, new ResourceGroup(Location));
            Assert.Equal(HttpStatusCode.Created, resourceGroupResult.StatusCode);
        }

        public string Location { get; private set; }

        public string ResourceGroupName { get; private set; }
    }
}
