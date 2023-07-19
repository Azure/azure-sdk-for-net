// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AzureRedisCache.Tests.ScenarioTests;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
using Xunit;
using DayOfWeekEnum = Microsoft.Azure.Management.Redis.Models.DayOfWeek;

namespace AzureRedisCache.Tests
{
    public class PatchSchedulesFunctionalTests : TestBase
    {
        [Fact]
        public void PatchSchedules_PutGetDelete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var _redisCacheManagementHelper = new RedisCacheManagementHelper(this, context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();

                var resourceGroupName = TestUtilities.GenerateName("RedisSchedules");
                var redisCacheName = TestUtilities.GenerateName("RedisSchedules");

                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);
                _redisCacheManagementHelper.TryCreateResourceGroup(resourceGroupName, RedisCacheManagementHelper.Location);
                _client.Redis.Create(resourceGroupName, redisCacheName,
                                        parameters: new RedisCreateParameters
                                        {
                                            Location = RedisCacheManagementHelper.Location,
                                            Sku = new Sku()
                                            {
                                                Name = SkuName.Premium,
                                                Family = SkuFamily.P,
                                                Capacity = 1
                                            }
                                        });

                // First try to get cache and verify that it is premium cache
                RedisResource response = _client.Redis.Get(resourceGroupName, redisCacheName);
                Assert.Contains(redisCacheName, response.Id);
                Assert.Equal(redisCacheName, response.Name);
                Assert.Equal(ProvisioningState.Succeeded, response.ProvisioningState, ignoreCase: true);
                Assert.Equal(SkuName.Premium, response.Sku.Name);
                Assert.Equal(SkuFamily.P, response.Sku.Family);

                ScheduleEntry[] entries = new ScheduleEntry[]
                {
                    new ScheduleEntry
                    {
                        DayOfWeek = DayOfWeekEnum.Monday,
                        StartHourUtc = 10,
                        MaintenanceWindow = TimeSpan.FromHours(10)
                    },
                    new ScheduleEntry
                    {
                        DayOfWeek = DayOfWeekEnum.Tuesday,
                        StartHourUtc = 11,
                        MaintenanceWindow = TimeSpan.FromHours(11)
                    }
                };

                ValidateResponseForSchedulePatch(
                    _client.PatchSchedules.CreateOrUpdate(
                        resourceGroupName, 
                        redisCacheName, 
                        parameters: 
                        new RedisPatchSchedule(entries)), 
                    redisCacheName);
                ValidateResponseForSchedulePatch(
                    _client.PatchSchedules.Get(resourceGroupName, redisCacheName),
                    redisCacheName);

                _client.PatchSchedules.Delete(resourceGroupName, redisCacheName);

                var ex = Assert.Throws<ErrorResponseException>(() => _client.PatchSchedules.Get(resourceGroupName, redisCacheName));
                Assert.Contains("There are no patch schedules found for redis cache", ex.Response.Content);
            }
        }

        private void ValidateResponseForSchedulePatch(RedisPatchSchedule schedulesSet, string redisName)
        {
            Assert.Contains(redisName + "/patchSchedules/default", schedulesSet.Id);
            Assert.Contains(redisName + "/default", schedulesSet.Name);
            Assert.Contains("Microsoft.Cache/Redis/PatchSchedules", schedulesSet.Type);
            Assert.Equal(RedisCacheManagementHelper.Location,schedulesSet.Location);
            Assert.Equal(2, schedulesSet.ScheduleEntries.Count);
            foreach (var schedule in schedulesSet.ScheduleEntries)
            {
                if (schedule.DayOfWeek.Equals(DayOfWeekEnum.Monday))
                {
                    Assert.Equal(10, schedule.StartHourUtc);
                    Assert.Equal(TimeSpan.FromHours(10), schedule.MaintenanceWindow);
                }
                else if (schedule.DayOfWeek.Equals(DayOfWeekEnum.Tuesday))
                {
                    Assert.Equal(11, schedule.StartHourUtc);
                    Assert.Equal(TimeSpan.FromHours(11), schedule.MaintenanceWindow);
                }
                else
                {
                    // we should never reach this
                    Assert.True(false);
                }
            }
        }
    }
}

