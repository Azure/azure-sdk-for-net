// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Azure.Tests;

namespace Fluent.Tests
{
    public class ContainerRegistry
    {
        [Fact]
        public void ContainerRegistryCRUD()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var regName = TestUtilities.GenerateName("reg");
                var saName = TestUtilities.GenerateName("regsa");
                var rgName = TestUtilities.GenerateName("crRg");
                var registryManager = TestHelper.CreateRegistryManager();
                var resourceManager = TestHelper.CreateResourceManager();
                IRegistry registry = null;

                try
                {
                    registry = registryManager.ContainerRegistries.Define(regName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .WithNewStorageAccount(saName)
                            .WithRegistryNameAsAdminUser()
                            .Create();

                    Assert.True(registry.AdminUserEnabled);
                    Assert.Equal(registry.StorageAccountName, saName);

                    registry = registry.Update()
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .Apply();

                    Assert.True(registry.Tags.ContainsKey("tag2"));
                    Assert.True(!registry.Tags.ContainsKey("tag1"));
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }

            }
        }
    }
}
