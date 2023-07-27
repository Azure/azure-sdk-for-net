// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace AzureRedisCache.Tests
{
    public class ManagedIdentityTests : TestBase
    {
        [Fact]
        public void ManagedIdentityCreateUpdateFunctionalTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var _redisCacheManagementHelper = new RedisCacheManagementHelper(this, context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();

                var resourceGroupName = TestUtilities.GenerateName("RedisBegin");
                var redisCacheName = TestUtilities.GenerateName("RedisBegin");



                // ARM resource id of *EXISTING* user assigned identity in the form /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
                // TODO: Create user assigned identity at runtime instead of hard coding the ID
                string userAssignedIdentityId = "/subscriptions/3919658b-68ae-4509-8c17-6a2238340ae7/resourceGroups/tolani-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-uami";

                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                RedisResource response;
                _redisCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisCacheManagementHelper.Location);
                response = _client.Redis.BeginCreate(resourceGroupName, redisCacheName,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            },
                                            Identity = new ManagedServiceIdentity(type: ManagedServiceIdentityType.SystemAssignedUserAssigned
                                            , userAssignedIdentities: new Dictionary<String, UserAssignedIdentity>
                                            {
                                                {userAssignedIdentityId, new UserAssignedIdentity() },
                                            }
                                            )
                                        });

                Assert.Contains(redisCacheName, response.Id);
                Assert.Equal(redisCacheName, response.Name);
                Assert.Equal(ProvisioningState.Creating, response.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, response.Sku.Name);
                Assert.Equal(SkuFamily.P, response.Sku.Family);
                Assert.Equal(ManagedServiceIdentityType.SystemAssignedUserAssigned, response.Identity.Type);
                Assert.NotNull(response.Identity.PrincipalId);
                Assert.NotEmpty(response.Identity.UserAssignedIdentities);
                

                for (int i = 0; i < 60; i++)
                {
                    response = _client.Redis.Get(resourceGroupName, redisCacheName);
                    if (ProvisioningState.Succeeded.Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    TestUtilities.Wait(new TimeSpan(0, 0, 30));
                }

                response = _client.Redis.Update(resourceGroupName, redisCacheName,
                                        parameters: new RedisUpdateParameters
                                        {
                                            Identity = new ManagedServiceIdentity(type: ManagedServiceIdentityType.SystemAssigned
                                            )
                                        });
                Assert.Equal(ManagedServiceIdentityType.SystemAssigned, response.Identity.Type);
                Assert.NotNull(response.Identity.PrincipalId);
                Assert.Null(response.Identity.UserAssignedIdentities);

                if(Utility.IsLiveTest()) Thread.Sleep(60000);


                response = _client.Redis.Update(resourceGroupName, redisCacheName,
                                parameters: new RedisUpdateParameters
                                {
                                    Identity = new ManagedServiceIdentity(type: ManagedServiceIdentityType.UserAssigned
                                    , userAssignedIdentities: new Dictionary<String, UserAssignedIdentity>
                                    {
                                                {userAssignedIdentityId, new UserAssignedIdentity() },
                                    }
                                    )
                                });

                Assert.Equal(ManagedServiceIdentityType.UserAssigned, response.Identity.Type);
                Assert.NotEmpty(response.Identity.UserAssignedIdentities);
                Assert.Null(response.Identity.PrincipalId);

                if (Utility.IsLiveTest()) Thread.Sleep(60000);
                response = _client.Redis.Update(resourceGroupName, redisCacheName,
                                        parameters: new RedisUpdateParameters
                                        {
                                            Identity = new ManagedServiceIdentity(type: ManagedServiceIdentityType.None
                                            )
                                        });
                
                Assert.Null(response.Identity);
                _client.Redis.Delete(resourceGroupName: resourceGroupName, name: redisCacheName);
                _redisCacheManagementHelper.DeleteResourceGroup(resourceGroupName);
            }
        }
    }
}

