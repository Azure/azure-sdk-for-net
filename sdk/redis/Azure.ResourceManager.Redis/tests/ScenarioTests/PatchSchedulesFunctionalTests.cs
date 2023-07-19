// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests
{
    public class PatchSchedulesFunctionalTests : RedisManagementTestBase
    {
        public PatchSchedulesFunctionalTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private RedisCollection Collection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            Collection = ResourceGroup.GetAllRedis();
        }

        [Test]
        public async Task CreateUpdateDeleteTest()
        {
            await SetCollectionsAsync();

            var redisCacheName = Recording.GenerateAssetName("RedisSchedules");
            var parameter = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1));
            var redis = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, parameter)).Value;

            var scheduleCollection = redis.GetRedisPatchSchedules();
            var data = new RedisPatchScheduleData(new RedisPatchScheduleSetting[]
            {
                    new RedisPatchScheduleSetting(RedisDayOfWeek.Monday, 10)
                    {
                        MaintenanceWindow = TimeSpan.FromHours(10)
                    },
                    new RedisPatchScheduleSetting(RedisDayOfWeek.Tuesday, 11)
                    {
                        MaintenanceWindow = TimeSpan.FromHours(11)
                    }
            });
            var schedule = (await scheduleCollection.CreateOrUpdateAsync(WaitUntil.Completed, RedisPatchScheduleDefaultName.Default, data)).Value;
            ValidateResponseForSchedulePatch(schedule, redisCacheName);

            schedule = (await scheduleCollection.GetAsync(RedisPatchScheduleDefaultName.Default)).Value;
            ValidateResponseForSchedulePatch(schedule, redisCacheName);

            await schedule.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await scheduleCollection.ExistsAsync(RedisPatchScheduleDefaultName.Default)).Value;
            Assert.IsFalse(falseResult);
        }

        private void ValidateResponseForSchedulePatch(RedisPatchScheduleResource schedulesSet, string redisName)
        {
            Assert.AreEqual(2, schedulesSet.Data.ScheduleEntries.Count);
            Assert.AreEqual(DefaultLocation, schedulesSet.Data.Location);
            foreach (var schedule in schedulesSet.Data.ScheduleEntries)
            {
                if (schedule.DayOfWeek.Equals(RedisDayOfWeek.Monday))
                {
                    Assert.AreEqual(10, schedule.StartHourUtc);
                    Assert.AreEqual(TimeSpan.FromHours(10), schedule.MaintenanceWindow);
                }
                else if (schedule.DayOfWeek.Equals(RedisDayOfWeek.Tuesday))
                {
                    Assert.AreEqual(11, schedule.StartHourUtc);
                    Assert.AreEqual(TimeSpan.FromHours(11), schedule.MaintenanceWindow);
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
