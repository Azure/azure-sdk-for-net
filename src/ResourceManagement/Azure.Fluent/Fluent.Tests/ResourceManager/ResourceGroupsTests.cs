// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class ResourceGroupsTests
    {
        private string rgName = ResourceNamer.RandomResourceName("rgchash-", 20);

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRUDResourceGroup()
        {
            Action<IResourceGroup> checkResourceGroup = (IResourceGroup resourceGroup) =>
            {
                Assert.NotNull(resourceGroup.Name);
                Assert.True(resourceGroup.Name.Equals(rgName, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(resourceGroup.RegionName);
                Assert.True(resourceGroup.RegionName.Equals(Region.US_EAST2));
                Assert.NotNull(resourceGroup.Id);
                Assert.NotNull(resourceGroup.Tags);
                Assert.Equal(resourceGroup.Tags.Count, 3);
            };

            try
            {
                var resourceManager = CreateResourceManager();
                var resourceGroup = resourceManager.ResourceGroups.Define(rgName)
                    .WithRegion(Region.US_EAST2)
                    .WithTag("t1", "v1")
                    .WithTag("t2", "v2")
                    .WithTag("t3", "v3")
                    .Create();
                checkResourceGroup(resourceGroup);

                resourceGroup = resourceManager.ResourceGroups.GetByName(rgName);
                checkResourceGroup(resourceGroup);

                resourceGroup.Update()
                    .WithoutTag("t1")
                    .WithTag("t4", "v4")
                    .WithTag("t5", "v5")
                    .Apply();
                Assert.NotNull(resourceGroup.Tags);
                Assert.Equal(resourceGroup.Tags.Count, 4);
            }
            finally
            {
                try
                {
                    CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                }
                catch
                { }
            }
        }

        private IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            IResourceManager resourceManager = Microsoft.Azure.Management.Resource.Fluent.ResourceManager.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}
