// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class JobDefinitionScheduleTests : StorageMoverManagementTestBase
    {
        public JobDefinitionScheduleTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateJobDefinitionWithWeeklyScheduleTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().GetAsync(ProjectName)).Value;
            JobDefinitionCollection jobDefinitions = project.GetJobDefinitions();

            string jobDefinitionName = Recording.GenerateAssetName("jobdef-sched-");

            // Create job definition with weekly schedule and data integrity validation
            JobDefinitionData jobDefinitionData = new JobDefinitionData(StorageMoverCopyMode.Additive, NfsEndpointName, ContainerEndpointName);
            jobDefinitionData.Description = "Job definition with weekly schedule";
            jobDefinitionData.DataIntegrityValidation = StorageMoverDataIntegrityValidation.SaveVerifyFileMD5;

            StorageMoverScheduleInfo schedule = new StorageMoverScheduleInfo { Frequency = StorageMoverScheduleFrequency.Weekly, IsActive = true };
            schedule.ExecutionTime = new StorageMoverSchedulerTime { Hour = 2 };
            schedule.StartOn = Recording.Now.AddDays(1);
            schedule.EndOn = Recording.Now.AddDays(30);
            schedule.DaysOfWeek.Add("Monday");
            schedule.DaysOfWeek.Add("Wednesday");
            schedule.DaysOfWeek.Add("Friday");
            jobDefinitionData.Schedule = schedule;

            JobDefinitionResource jobDefinition = (await jobDefinitions.CreateOrUpdateAsync(WaitUntil.Completed, jobDefinitionName, jobDefinitionData)).Value;
            Assert.AreEqual(jobDefinitionName, jobDefinition.Data.Name);
            Assert.AreEqual(NfsEndpointName, jobDefinition.Data.SourceName);
            Assert.AreEqual(ContainerEndpointName, jobDefinition.Data.TargetName);
            Assert.AreEqual("Additive", jobDefinition.Data.CopyMode.ToString());
            Assert.AreEqual("Job definition with weekly schedule", jobDefinition.Data.Description);

            // Verify schedule
            Assert.IsNotNull(jobDefinition.Data.Schedule);
            Assert.AreEqual(StorageMoverScheduleFrequency.Weekly, jobDefinition.Data.Schedule.Frequency);
            Assert.IsTrue(jobDefinition.Data.Schedule.IsActive);
            Assert.AreEqual(2, jobDefinition.Data.Schedule.ExecutionTime.Hour);
            Assert.AreEqual(3, jobDefinition.Data.Schedule.DaysOfWeek.Count);

            // Get and verify persistence
            jobDefinition = (await jobDefinitions.GetAsync(jobDefinitionName)).Value;
            Assert.AreEqual(jobDefinitionName, jobDefinition.Data.Name);
            Assert.IsNotNull(jobDefinition.Data.Schedule);
            Assert.AreEqual(StorageMoverScheduleFrequency.Weekly, jobDefinition.Data.Schedule.Frequency);

            // Clean up
            await jobDefinition.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse((await jobDefinitions.ExistsAsync(jobDefinitionName)).Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateJobDefinitionWithDailyScheduleAndPreservePermissionsTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().GetAsync(ProjectName)).Value;
            JobDefinitionCollection jobDefinitions = project.GetJobDefinitions();

            string jobDefinitionName = Recording.GenerateAssetName("jobdef-daily-");

            // Create job definition with daily schedule and preserve permissions
            JobDefinitionData jobDefinitionData = new JobDefinitionData(StorageMoverCopyMode.Mirror, NfsEndpointName, ContainerEndpointName);
            jobDefinitionData.Description = "Job definition with daily schedule";
            jobDefinitionData.DataIntegrityValidation = StorageMoverDataIntegrityValidation.None;
            jobDefinitionData.IsPermissionsPreserved = true;
            jobDefinitionData.Schedule = new StorageMoverScheduleInfo
            {
                Frequency = StorageMoverScheduleFrequency.Daily,
                IsActive = true,
                ExecutionTime = new StorageMoverSchedulerTime { Hour = 0 },
                StartOn = Recording.Now.AddDays(1),
                EndOn = Recording.Now.AddDays(30),
            };

            JobDefinitionResource jobDefinition = (await jobDefinitions.CreateOrUpdateAsync(WaitUntil.Completed, jobDefinitionName, jobDefinitionData)).Value;
            Assert.AreEqual(jobDefinitionName, jobDefinition.Data.Name);
            Assert.AreEqual("Mirror", jobDefinition.Data.CopyMode.ToString());
            Assert.IsNotNull(jobDefinition.Data.Schedule);
            Assert.AreEqual(StorageMoverScheduleFrequency.Daily, jobDefinition.Data.Schedule.Frequency);
            Assert.IsTrue(jobDefinition.Data.Schedule.IsActive);

            // Clean up
            await jobDefinition.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task CreateJobDefinitionWithOnetimeScheduleTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().GetAsync(ProjectName)).Value;
            JobDefinitionCollection jobDefinitions = project.GetJobDefinitions();

            string jobDefinitionName = Recording.GenerateAssetName("jobdef-once-");

            // Create job definition with one-time schedule
            JobDefinitionData jobDefinitionData = new JobDefinitionData(StorageMoverCopyMode.Additive, NfsEndpointName, ContainerEndpointName);
            jobDefinitionData.Description = "Job definition with one-time schedule";
            jobDefinitionData.Schedule = new StorageMoverScheduleInfo
            {
                Frequency = StorageMoverScheduleFrequency.Onetime,
                IsActive = true,
                ExecutionTime = new StorageMoverSchedulerTime { Hour = 10 },
                StartOn = Recording.Now.AddDays(1),
            };

            JobDefinitionResource jobDefinition = (await jobDefinitions.CreateOrUpdateAsync(WaitUntil.Completed, jobDefinitionName, jobDefinitionData)).Value;
            Assert.AreEqual(jobDefinitionName, jobDefinition.Data.Name);
            Assert.IsNotNull(jobDefinition.Data.Schedule);
            Assert.AreEqual(StorageMoverScheduleFrequency.Onetime, jobDefinition.Data.Schedule.Frequency);
            Assert.IsTrue(jobDefinition.Data.Schedule.IsActive);

            // Clean up
            await jobDefinition.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task CreateJobDefinitionWithHourlyScheduleTest()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, ResourceGroupNamePrefix, EuapLocation);
            try
            {
                StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().CreateOrUpdateAsync(
                    WaitUntil.Completed, Recording.GenerateAssetName(StorageMoverPrefix), new StorageMoverData(EuapLocation))).Value;
                StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().CreateOrUpdateAsync(
                    WaitUntil.Completed, Recording.GenerateAssetName("project-"), new StorageMoverProjectData())).Value;
                StorageMoverEndpointCollection endpoints = storageMover.GetStorageMoverEndpoints();
                string sourceName = Recording.GenerateAssetName("smbfs-src-");
                string targetName = Recording.GenerateAssetName("smbfs-tgt-");
                await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, sourceName, new StorageMoverEndpointData(
                    new AzureStorageSmbFileShareEndpointProperties(new ResourceIdentifier(FakeStorageAccountId), "srcshare")
                    {
                        EndpointKind = StorageMoverEndpointKind.Source,
                    }));
                await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, targetName, new StorageMoverEndpointData(
                    new AzureStorageSmbFileShareEndpointProperties(new ResourceIdentifier(FakeStorageAccountId), "tgtshare")
                    {
                        EndpointKind = StorageMoverEndpointKind.Target,
                    }));

                JobDefinitionData CreateJobDefinition(string interval) => new JobDefinitionData(StorageMoverCopyMode.Additive, sourceName, targetName)
                {
                    JobType = JobType.CloudToCloud,
                    Description = "Job definition with hourly schedule",
                    Schedule = new StorageMoverScheduleInfo
                    {
                        Frequency = StorageMoverScheduleFrequency.Hourly,
                        RepeatInterval = interval,
                        IsActive = true,
                        ExecutionTime = new StorageMoverSchedulerTime { Hour = 9, Minute = 0 },
                        StartOn = Recording.Now.AddDays(1),
                        EndOn = Recording.Now.AddDays(30),
                    },
                };

                JobDefinitionCollection jobs = project.GetJobDefinitions();
                string jobName = Recording.GenerateAssetName("jobdef-hourly-");
                JobDefinitionResource job = (await jobs.CreateOrUpdateAsync(WaitUntil.Completed, jobName, CreateJobDefinition("4h"))).Value;
                Assert.AreEqual(jobName, job.Data.Name);
                Assert.AreEqual(StorageMoverScheduleFrequency.Hourly, job.Data.Schedule.Frequency);
                Assert.AreEqual("4h", job.Data.Schedule.RepeatInterval);
                Assert.IsTrue(job.Data.Schedule.IsActive);

                job = (await jobs.GetAsync(jobName)).Value;
                Assert.AreEqual(StorageMoverScheduleFrequency.Hourly, job.Data.Schedule.Frequency);
                Assert.AreEqual("4h", job.Data.Schedule.RepeatInterval);

                job = (await job.UpdateAsync(new JobDefinitionPatch
                {
                    Schedule = new StorageMoverScheduleInfo { RepeatInterval = "6h" },
                })).Value;
                Assert.AreEqual(StorageMoverScheduleFrequency.Hourly, job.Data.Schedule.Frequency);
                Assert.AreEqual("6h", job.Data.Schedule.RepeatInterval);
                Assert.IsTrue(job.Data.Schedule.IsActive);

                job = (await job.UpdateAsync(new JobDefinitionPatch
                {
                    Schedule = new StorageMoverScheduleInfo { IsActive = false },
                })).Value;
                Assert.IsFalse(job.Data.Schedule.IsActive);
                Assert.AreEqual("6h", job.Data.Schedule.RepeatInterval);

                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await jobs.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("jobdef-hourly-bad-"), CreateJobDefinition("5h")));
                Assert.AreEqual(400, exception.Status);
                Assert.AreEqual("InvalidRequestPropertyValue", exception.ErrorCode);

                await job.DeleteAsync(WaitUntil.Completed);
                Assert.IsFalse(await jobs.ExistsAsync(jobName));
            }
            finally
            {
                await resourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }
    }
}
