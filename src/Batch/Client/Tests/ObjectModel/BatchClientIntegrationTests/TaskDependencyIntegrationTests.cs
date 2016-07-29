// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BatchClientIntegrationTests.Fixtures;
using BatchClientIntegrationTests.IntegrationTestUtilities;

using BatchTestCommon;

using Microsoft.Azure.Batch;

using Xunit;
using Xunit.Abstractions;


namespace BatchClientIntegrationTests
{
    [Collection("SharedPoolCollection")]
    public class TaskDependencyIntegrationTests
    {
        private ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);
        private readonly PoolFixture poolFixture;

        public TaskDependencyIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        private string GenerateJobId()
        {
            return "id-" + Guid.NewGuid();
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void CanCreateJobWithoutUsesTaskDependencies()
        {
            Action test = () =>
                {
                    using (BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result)
                    {
                        string jobId = GenerateJobId();

                        try
                        {
                            CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                            cloudJob.PoolInformation = new PoolInformation()
                            {
                                PoolId = this.poolFixture.PoolId
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
                };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void CanCreateJobWithUsesTaskDependencies()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result)
                {
                    string jobId = GenerateJobId();

                    try
                    {
                        CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                        cloudJob.PoolInformation = new PoolInformation()
                        {
                            PoolId = this.poolFixture.PoolId
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
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void CanSpecifyTaskDependencyIds()
        {
            using (BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result)
            {
                string jobId = GenerateJobId();

                try
                {
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    unboundJob.PoolInformation = new PoolInformation()
                    {
                        PoolId = this.poolFixture.PoolId
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
}
