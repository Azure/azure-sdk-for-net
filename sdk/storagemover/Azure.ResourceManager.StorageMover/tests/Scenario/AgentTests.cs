// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class AgentTests : StorageMoverManagementTestBase
    {
        public AgentTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetExistTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverResource storageMover = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverAgentCollection agents = storageMover.GetStorageMoverAgents();

            StorageMoverAgentResource agent = (await agents.GetAsync(AgentName)).Value;
            StorageMoverAgentResource agent2 = (await agent.GetAsync()).Value;
            Assert.That(agent2.Data.Name, Is.EqualTo(agent.Data.Name));
            Assert.That(agent2.Data.Id, Is.EqualTo(agent.Data.Id));
            Assert.That(agent2.Data.LocalIPAddress, Is.EqualTo(agent.Data.LocalIPAddress));
            Assert.That(agent2.Id.Name, Is.EqualTo(agent.Id.Name));

            int counter = 0;
            await foreach (StorageMoverAgentResource _ in agents.GetAllAsync())
            {
                counter++;
            }
            Assert.That(counter, Is.GreaterThanOrEqualTo(1));

            StorageMoverAgentPatch patch = new StorageMoverAgentPatch
            {
                Description = "This is an updated agent"
            };
            List<ScheduleDayOfWeek> days = new List<ScheduleDayOfWeek> { ScheduleDayOfWeek.Monday, ScheduleDayOfWeek.Tuesday };
            UploadLimitWeeklyRecurrence uploadLimitWeeklyRecurrence = new UploadLimitWeeklyRecurrence(new ScheduleTime(1), new ScheduleTime(2), days, 100);
            patch.UploadLimitScheduleWeeklyRecurrences.Add(uploadLimitWeeklyRecurrence);

            agent = (await agent.UpdateAsync(patch)).Value;
            Assert.That(agent.Data.Description, Is.EqualTo(patch.Description));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences.Count, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences.Count));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].LimitInMbps, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].LimitInMbps));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].Days[0], Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].Days[0]));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].Days.Count, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].Days.Count));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].StartTime.Hour, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].StartTime.Hour));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].StartTime.Minute.ToString(), Is.EqualTo("0"));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].EndTime.Hour, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].EndTime.Hour));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].EndTime.Minute.ToString(), Is.EqualTo("0"));

            agent = (await agents.GetAsync(AgentName)).Value;
            Assert.That(agent.Data.Description, Is.EqualTo(patch.Description));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences.Count, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences.Count));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].LimitInMbps, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].LimitInMbps));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].Days[0], Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].Days[0]));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].Days.Count, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].Days.Count));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].StartTime.Hour, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].StartTime.Hour));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].StartTime.Minute.ToString(), Is.EqualTo("0"));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].EndTime.Hour, Is.EqualTo(patch.UploadLimitScheduleWeeklyRecurrences[0].EndTime.Hour));
            Assert.That(agent.Data.UploadLimitScheduleWeeklyRecurrences[0].EndTime.Minute.ToString(), Is.EqualTo("0"));

            Assert.That((await agents.ExistsAsync(AgentName)).Value, Is.True);
            Assert.That((await agents.ExistsAsync(AgentName + "111")).Value, Is.False);
        }
    }
}
