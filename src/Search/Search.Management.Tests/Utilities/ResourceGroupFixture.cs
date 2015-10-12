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
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public class ResourceGroupFixture : IResourceFixture
    {
        private const string SearchNamespace = "Microsoft.Search";

        public virtual void Initialize(MockContext context)
        {
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>();

            // Register subscription and get a valid location for search services.
            Provider provider = client.Providers.Register(SearchNamespace);
            Assert.NotNull(provider);

            // We only support one resource type.
            Location = provider.ResourceTypes.First().Locations.First();

            // Create resource group
            ResourceGroupName = TestUtilities.GenerateName();
            ResourceGroup resourceGroup =
                client.ResourceGroups.CreateOrUpdate(ResourceGroupName, new ResourceGroup() { Location = Location });
            Assert.NotNull(resourceGroup);
        }

        public string Location { get; private set; }

        public string ResourceGroupName { get; private set; }
    }
}
