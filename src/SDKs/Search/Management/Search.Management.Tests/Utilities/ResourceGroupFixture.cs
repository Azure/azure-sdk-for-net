// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System.Linq;
    using Management.ResourceManager;
    using Management.ResourceManager.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ResourceGroupFixture : IResourceFixture
    {
        private const string SearchNamespace = "Microsoft.Search";

        public string Location { get; private set; }

        public string ResourceGroupName { get; private set; }

        public virtual void Initialize(MockContext context)
        {
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>();

            // Register subscription and get a valid location for search services.
            Provider provider = client.Providers.Register(SearchNamespace);
            Assert.NotNull(provider);

            // We only support one resource type.
            Location = provider.ResourceTypes.First().Locations.First();

            // Create resource group
            ResourceGroupName = SearchTestUtilities.GenerateName();
            ResourceGroup resourceGroup =
                client.ResourceGroups.CreateOrUpdate(ResourceGroupName, new ResourceGroup() { Location = Location });
            Assert.NotNull(resourceGroup);
        }

        public virtual void Cleanup()
        {
            // Nothing to cleanup.
        }
    }
}
