// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using BatchClientIntegrationTests.Fixtures;
using BatchClientIntegrationTests.IntegrationTestUtilities;
using BatchTestCommon;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
using Xunit;
using Xunit.Abstractions;


namespace BatchClientIntegrationTests
{
    [Collection("SharedPoolCollection")]
    public class TaskDependencyIntegrationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);
        private readonly PoolFixture poolFixture;

        public TaskDependencyIntegrationTests(PaasWindowsPoolFixture poolFixture)
        {
            this.poolFixture = poolFixture;
        }

        private string GenerateJobId() => $"id-{Guid.NewGuid()}";

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void CanCreateJobWithoutUsesTaskDependencies()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string jobId = GenerateJobId();

                try
                {
                    CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    cloudJob.PoolInformation = new PoolInformation()
                    {
                        PoolId = poolFixture.PoolId
                    };
                    cloudJob.Commit();

                    var boundJob = batchCli.JobOperations.GetJob(jobId);
                    Assert.False(boundJob.UsesTaskDependencies);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void CanCreateJobWithUsesTaskDependencies()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string jobId = GenerateJobId();

                try
                {
                    CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    cloudJob.PoolInformation = new PoolInformation()
                    {
                        PoolId = poolFixture.PoolId
                    };
                    cloudJob.UsesTaskDependencies = true;
                    cloudJob.Commit();

                    var boundJob = batchCli.JobOperations.GetJob(jobId);
                    Assert.True(boundJob.UsesTaskDependencies);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void CanSpecifyTaskDependencyIds()
        {
            using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
            string jobId = GenerateJobId();

            try
            {
                CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                unboundJob.PoolInformation = new PoolInformation()
                {
                    PoolId = poolFixture.PoolId
                };

                unboundJob.UsesTaskDependencies = true;
                unboundJob.Commit();
                var taskId = Guid.NewGuid().ToString();

                IList<TaskIdRange> taskIdRanges = new List<TaskIdRange>
                    {
                        new TaskIdRange(1, 5),
                        new TaskIdRange(8, 8)
                    };

                IList<string> taskIds = new List<string> { "1" };

                var boundJob = batchCli.JobOperations.GetJob(jobId);

                CloudTask taskToAdd = new CloudTask(taskId, "cmd.exe")
                {
                    DependsOn = new TaskDependencies(taskIds, taskIdRanges),
                };

                boundJob.AddTask(taskToAdd);

                CloudTask task = boundJob.GetTask(taskId);
                var dependedOnRange = task.DependsOn.TaskIdRanges.First();
                var dependedOnTaskId = task.DependsOn.TaskIds.First();

                Assert.Equal(1, dependedOnRange.Start);
                Assert.Equal(5, dependedOnRange.End);
                Assert.Equal("1", dependedOnTaskId);

                Assert.True(boundJob.UsesTaskDependencies);
            }
            finally
            {
                TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
            }
        }
    }
}
