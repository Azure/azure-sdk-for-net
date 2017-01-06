// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Redis.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Azure.Tests.Redis
{
    public class RedisCacheTests
    {
        private const string RG_NAME = "javacsmrg375";
        private const string RG_NAME_SECOND = "javacsmrg375Second";
        private const string RR_NAME = "javacsmrc375";
        private const string RR_NAME_SECOND = "javacsmrc375Second";
        private const string RR_NAME_THIRD = "javacsmrc375Third";
        private const string SA_NAME = "javacsmsa375";

        [Fact]
        public void CanCRUDRedisCache()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                try
                {
                    var redisManager = TestHelper.CreateRedisManager();
                    
                    // Create
                    var resourceGroup = redisManager.ResourceManager.ResourceGroups
                                            .Define(RG_NAME_SECOND)
                                            .WithRegion(Region.US_CENTRAL)
                                            .Create();

                    var redisCacheDefinition1 = redisManager.RedisCaches
                            .Define(RR_NAME)
                            .WithRegion(Region.ASIA_EAST)
                            .WithNewResourceGroup(RG_NAME)
                            .WithBasicSku()
                            .Create();

                    var redisCacheDefinition2 = redisManager.RedisCaches
                            .Define(RR_NAME_SECOND)
                            .WithRegion(Region.US_CENTRAL)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithPremiumSku()
                            .WithShardCount(10)
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Sunday, 10, TimeSpan.FromMinutes(302))
                            .Create();

                    var redisCacheDefinition3 = redisManager.RedisCaches
                            .Define(RR_NAME_THIRD)
                            .WithRegion(Region.US_CENTRAL)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithPremiumSku(2)
                            .WithRedisConfiguration("maxclients", "2")
                            .WithNonSslPort()
                            .Create();

                    var redisCache = redisCacheDefinition1;
                    var redisCachePremium = redisCacheDefinition3;
                    Assert.Equal(RG_NAME, redisCache.ResourceGroupName);
                    Assert.Equal(SkuName.Basic, redisCache.Sku.Name);

                    // List by Resource Group
                    var redisCaches = redisManager.RedisCaches.ListByGroup(RG_NAME);

                    if (!redisCaches.Any(r => r.Name.Equals(RR_NAME, StringComparison.OrdinalIgnoreCase)))
                    {
                        Assert.True(false);
                    }
                    Assert.Equal(1, redisCaches.Count);

                    // List all Redis resources
                    redisCaches = redisManager.RedisCaches.List();

                    if (!redisCaches.Any(r => r.Name.Equals(RR_NAME, StringComparison.OrdinalIgnoreCase)))
                    {
                        Assert.True(false);
                    }
                    Assert.Equal(3, redisCaches.Count);

                    // Get
                    var redisCacheGet = redisManager.RedisCaches.GetByGroup(RG_NAME, RR_NAME);
                    Assert.NotNull(redisCacheGet);
                    Assert.Equal(redisCache.Id, redisCacheGet.Id);
                    Assert.Equal(redisCache.ProvisioningState, redisCacheGet.ProvisioningState);

                    // Get Keys
                    var redisKeys = redisCache.Keys;
                    Assert.NotNull(redisKeys);
                    Assert.NotNull(redisKeys.PrimaryKey);
                    Assert.NotNull(redisKeys.SecondaryKey);

                    // Regen key
                    var oldKeys = redisCache.RefreshKeys();
                    var updatedPrimaryKey = redisCache.RegenerateKey(RedisKeyType.Primary);
                    var updatedSecondaryKey = redisCache.RegenerateKey(RedisKeyType.Secondary);
                    Assert.NotNull(oldKeys);
                    Assert.NotNull(updatedPrimaryKey);
                    Assert.NotNull(updatedSecondaryKey);
                    Assert.NotEqual(oldKeys.PrimaryKey, updatedPrimaryKey.PrimaryKey);
                    Assert.Equal(oldKeys.SecondaryKey, updatedPrimaryKey.SecondaryKey);
                    Assert.NotEqual(oldKeys.SecondaryKey, updatedSecondaryKey.SecondaryKey);
                    Assert.NotEqual(updatedPrimaryKey.SecondaryKey, updatedSecondaryKey.SecondaryKey);
                    Assert.Equal(updatedPrimaryKey.PrimaryKey, updatedSecondaryKey.PrimaryKey);

                    // Update to STANDARD Sku from BASIC SKU
                    redisCache = redisCache.Update()
                            .WithStandardSku()
                            .Apply();
                    Assert.Equal(SkuName.Standard, redisCache.Sku.Name);
                    Assert.Equal(SkuFamily.C, redisCache.Sku.Family);

                    try
                    {
                        redisCache.Update()
                                .WithBasicSku(1)
                                .Apply();
                        Assert.False(true);
                    }
                    catch (CloudException)
                    {
                        // expected since Sku downgrade is not supported
                    }
                    catch (AggregateException ex)
                    {
                        if (ex.InnerException == null ||
                            ex.InnerException.InnerException == null ||
                            !(ex.InnerException.InnerException is CloudException))
                        {
                            // expected since Sku downgrade is not supported and the inner exception
                            // should be of type CloudException
                            Assert.False(true);
                        }
                    }

                    // Refresh
                    redisCache.Refresh();

                    // delete
                    redisManager.RedisCaches.DeleteById(redisCache.Id);

                    // Premium SKU Functionality
                    var premiumCache = redisCachePremium.AsPremium();
                    Assert.Equal(SkuFamily.P, premiumCache.Sku.Family);

                    // Redis configuration update
                    premiumCache.Update()
                            .WithRedisConfiguration("maxclients", "3")
                            .Apply();

                    premiumCache.Update()
                            .WithoutRedisConfiguration("maxclients")
                            .Apply();

                    premiumCache.Update()
                            .WithoutRedisConfiguration()
                            .Apply();

                    premiumCache.Update()
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Monday, 1)
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Tuesday, 5)
                            .Apply();

                    // Reboot
                    premiumCache.ForceReboot(RebootType.AllNodes);

                    // Patch Schedule
                    var patchSchedule = premiumCache.ListPatchSchedules();
                    Assert.Equal(2, patchSchedule.Count());

                    premiumCache.DeletePatchSchedule();

                    patchSchedule = redisManager.RedisCaches
                                                .GetById(premiumCache.Id)
                                                .AsPremium()
                                                .ListPatchSchedules();
                    Assert.Null(patchSchedule);

                    // currently throws because SAS url of the container should be provided as
                    // {"error":{
                    //      "code":"InvalidRequestBody",
                    //      "message": "One of the SAS URIs provided could not be used for the following reason:
                    //                  The SAS token is poorly formatted.\r\nRequestID=ed105089-b93b-427e-9cbb-d78ed80d23b0",
                    //      "target":null}}
                    // com.microsoft.azure.CloudException: One of the SAS URIs provided could not be used for the following reason: The SAS token is poorly formatted.
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(RG_NAME);
                    }
                    catch
                    { }
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(RG_NAME_SECOND);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
