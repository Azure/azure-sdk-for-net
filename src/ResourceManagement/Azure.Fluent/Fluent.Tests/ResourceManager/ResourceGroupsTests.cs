// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class ResourceGroupsTests
    {
        [Fact]
        public void CanCRUDResourceGroup()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgchash-");
                Action<IResourceGroup> checkResourceGroup = (IResourceGroup resourceGroup) =>
                {
                    Assert.NotNull(resourceGroup.Name);
                    Assert.True(resourceGroup.Name.Equals(rgName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(resourceGroup.RegionName);
                    Assert.True(StringComparer.CurrentCultureIgnoreCase.Equals(resourceGroup.RegionName, Region.US_EAST2.Name));
                    Assert.NotNull(resourceGroup.Id);
                    Assert.NotNull(resourceGroup.Tags);
                    Assert.Equal(resourceGroup.Tags.Count, 3);
                };

                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
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
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
