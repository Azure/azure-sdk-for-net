// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Search.Fluent;
using Azure.Tests;

namespace Fluent.Tests
{
    public class Search
    {
        [Fact]
        public void CanCRUD()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgsearch");
                var resourceManager = TestHelper.CreateResourceManager();
                var manager = TestHelper.CreateSearchManager();
                var searchServiceName = TestUtilities.GenerateName("ssrv");
                ISearchService searchService = null;

                try
                {
                    Assert.True(manager.SearchServices.CheckNameAvailability(searchServiceName).IsAvailable);

                    searchService = manager.SearchServices.Define(searchServiceName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithSku(Microsoft.Azure.Management.Search.Fluent.Models.SkuName.Standard)
                        .WithTag("tag1", "value1")
                        .Create();
                    Assert.Equal(Microsoft.Azure.Management.Search.Fluent.Models.SkuName.Standard, searchService.Sku.Name);
                    Assert.Equal(1, searchService.ReplicaCount);
                    Assert.Equal(1, searchService.PartitionCount);

                    var adminKeys = searchService.GetAdminKeys();
                    Assert.NotNull(adminKeys);
                    Assert.NotNull(adminKeys.PrimaryKey);
                    Assert.NotNull(adminKeys.SecondaryKey);

                    var queryKeys = searchService.ListQueryKeys();
                    Assert.NotNull(queryKeys);
                    Assert.Equal(1, queryKeys.Count);

                    searchService.CreateQueryKey("testKey1");

                    SdkContext.DelayProvider.Delay(1000);

                    searchService = searchService.Update()
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .WithReplicaCount(1)
                        .WithPartitionCount(2)
                        .Apply();
                    Assert.True(searchService.Tags.ContainsKey("tag2"));
                    Assert.True(!searchService.Tags.ContainsKey("tag1"));
                    Assert.Equal(1, searchService.ReplicaCount);
                    Assert.Equal(2, searchService.PartitionCount);
                    Assert.Equal(2, searchService.ListQueryKeys().Count);

                    var adminKeyPrimary = searchService.GetAdminKeys().PrimaryKey;
                    var adminKeySecondary = searchService.GetAdminKeys().SecondaryKey;

                    searchService.DeleteQueryKey(searchService.ListQueryKeys()[1].Key);
                    searchService.RegenerateAdminKeys(Microsoft.Azure.Management.Search.Fluent.Models.AdminKeyKind.Primary);
                    searchService.RegenerateAdminKeys(Microsoft.Azure.Management.Search.Fluent.Models.AdminKeyKind.Secondary);
                    queryKeys = searchService.ListQueryKeys();
                    Assert.NotNull(queryKeys);
                    Assert.Equal(1, queryKeys.Count);
                    Assert.DoesNotMatch(adminKeyPrimary, searchService.GetAdminKeys().PrimaryKey);
                    Assert.DoesNotMatch(adminKeyPrimary, searchService.GetAdminKeys().SecondaryKey);
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

        [Fact]
        public void CanCRUDFreeSku()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgsearch");
                var resourceManager = TestHelper.CreateResourceManager();
                var manager = TestHelper.CreateSearchManager();
                var searchServiceName = TestUtilities.GenerateName("ssrv");
                ISearchService searchService = null;

                try
                {
                    Assert.True(manager.SearchServices.CheckNameAvailability(searchServiceName).IsAvailable);

                    // List all Search services in the subscription and skip if there is already one resource of type free SKU
                    var runTest = true;
                    var resources = manager.SearchServices.List();
                    foreach (var item in resources)
                    {
                        if (item.Sku.Name.Equals(Microsoft.Azure.Management.Search.Fluent.Models.SkuName.Free))
                        {
                            runTest = false;
                            break;
                        }
                    }

                    if (runTest)
                    {
                        searchService = manager.SearchServices.Define(searchServiceName)
                            .WithRegion(Region.USEast)
                            .WithNewResourceGroup(rgName)
                            .WithFreeSku()
                            .WithTag("tag1", "value1")
                            .Create();
                        Assert.Equal(Microsoft.Azure.Management.Search.Fluent.Models.SkuName.Free, searchService.Sku.Name);
                        Assert.Equal(1, searchService.ReplicaCount);
                        Assert.Equal(1, searchService.PartitionCount);

                        SdkContext.DelayProvider.Delay(5000);

                        searchService = searchService.Update()
                            .WithTag("tag2", "value2")
                            .WithTag("tag3", "value3")
                            .WithoutTag("tag1")
                            .Apply();
                        Assert.True(searchService.Tags.ContainsKey("tag2"));
                        Assert.True(!searchService.Tags.ContainsKey("tag1"));
                        Assert.Equal(1, searchService.ReplicaCount);
                        Assert.Equal(1, searchService.PartitionCount);
                        Assert.Equal(1, searchService.ListQueryKeys().Count);
                    }
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

        [Fact]
        public void CanCRUDBasicSku()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgsearch");
                var resourceManager = TestHelper.CreateResourceManager();
                var manager = TestHelper.CreateSearchManager();
                var searchServiceName = TestUtilities.GenerateName("ssrv");
                ISearchService searchService = null;

                try
                {
                    Assert.True(manager.SearchServices.CheckNameAvailability(searchServiceName).IsAvailable);

                    searchService = manager.SearchServices.Define(searchServiceName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithBasicSku()
                        .WithReplicaCount(1)
                        .WithTag("tag1", "value1")
                        .Create();
                    Assert.Equal(Microsoft.Azure.Management.Search.Fluent.Models.SkuName.Basic, searchService.Sku.Name);
                    Assert.Equal(1, searchService.ReplicaCount);
                    Assert.Equal(1, searchService.PartitionCount);

                    SdkContext.DelayProvider.Delay(5000);

                    searchService = searchService.Update()
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .WithReplicaCount(1)
                        .Apply();
                    Assert.True(searchService.Tags.ContainsKey("tag2"));
                    Assert.True(!searchService.Tags.ContainsKey("tag1"));
                    Assert.Equal(1, searchService.ReplicaCount);
                    Assert.Equal(1, searchService.PartitionCount);
                    Assert.Equal(1, searchService.ListQueryKeys().Count);
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

        [Fact]
        public void CanCRUDStandardSku()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgsearch");
                var resourceManager = TestHelper.CreateResourceManager();
                var manager = TestHelper.CreateSearchManager();
                var searchServiceName = TestUtilities.GenerateName("ssrv");
                ISearchService searchService = null;

                try
                {
                    Assert.True(manager.SearchServices.CheckNameAvailability(searchServiceName).IsAvailable);

                    searchService = manager.SearchServices.Define(searchServiceName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithStandardSku()
                        .WithPartitionCount(1)
                        .WithReplicaCount(1)
                        .WithTag("tag1", "value1")
                        .Create();
                    Assert.Equal(Microsoft.Azure.Management.Search.Fluent.Models.SkuName.Standard, searchService.Sku.Name);
                    Assert.Equal(1, searchService.ReplicaCount);
                    Assert.Equal(1, searchService.PartitionCount);

                    SdkContext.DelayProvider.Delay(5000);

                    searchService = searchService.Update()
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .WithReplicaCount(1)
                        .WithPartitionCount(1)
                        .Apply();
                    Assert.True(searchService.Tags.ContainsKey("tag2"));
                    Assert.True(!searchService.Tags.ContainsKey("tag1"));
                    Assert.Equal(1, searchService.ReplicaCount);
                    Assert.Equal(1, searchService.PartitionCount);
                    Assert.Equal(1, searchService.ListQueryKeys().Count);
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
