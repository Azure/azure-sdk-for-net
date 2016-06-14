// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var _client = RedisCacheManagementTestUtilities.GetRedisManagementClient(this, context);

                // First try to get cache and verify that it is premium cache
                RedisResource response = _client.Redis.Get(resourceGroupName: "sunnyjapan", name: "sunny-scheduling-dv2");
                Assert.Contains("sunny-scheduling-dv2", response.Id);
                Assert.Equal("sunny-scheduling-dv2", response.Name);
                Assert.True("succeeded".Equals(response.ProvisioningState, StringComparison.OrdinalIgnoreCase));
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

                ValidateResponseForSchedulePatch(_client.PatchSchedules.CreateOrUpdate(resourceGroupName: "sunnyjapan", name: "sunny-scheduling-dv2", parameters: new RedisPatchSchedulesRequest(entries)));
                ValidateResponseForSchedulePatch(_client.PatchSchedules.Get(resourceGroupName: "sunnyjapan", name: "sunny-scheduling-dv2"));
                _client.PatchSchedules.Delete(resourceGroupName: "sunnyjapan", name: "sunny-scheduling-dv2");
                var ex = Assert.Throws<CloudException>(() => _client.PatchSchedules.Get(resourceGroupName: "sunnyjapan", name: "sunny-scheduling-dv2"));
                Assert.Contains("There are no patch schedules found for redis cache 'sunny-scheduling-dv2'", ex.Message);
                Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
            }
        }

        private void ValidateResponseForSchedulePatch(RedisPatchSchedulesResponse schedulesSet)
        {
            Assert.Contains("sunny-scheduling-dv2/patchSchedules/default", schedulesSet.Id);
            Assert.Contains("sunny-scheduling-dv2/default", schedulesSet.Name);
            Assert.Contains("Microsoft.Cache/Redis/PatchSchedules", schedulesSet.Type);
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
