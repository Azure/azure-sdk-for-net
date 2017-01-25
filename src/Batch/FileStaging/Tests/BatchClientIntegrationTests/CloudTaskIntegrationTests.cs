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

extern alias fs;  // Temporary bridge until the Batch core NuGet without file staging is published

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using StagingStorageAccount = fs::Microsoft.Azure.Batch.FileStaging.StagingStorageAccount;  // Temporary bridge until the Batch core NuGet without file staging is published
    using FileToStage = fs::Microsoft.Azure.Batch.FileStaging.FileToStage;  // Temporary bridge until the Batch core NuGet without file staging is published
    using TestResources;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;
    using Constants = Microsoft.Azure.Batch.Constants;
    using System.Threading;
    using System.Diagnostics;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    [Collection("SharedPoolCollection")]
    public class CloudTaskIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public CloudTaskIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1535329JobOperationsMissingAddTaskMethods()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    StagingStorageAccount stagingStorageAccount = TestUtilities.GetStorageCredentialsFromEnvironment();

                    string jobId = "Bug1535329Job-" + TestUtilities.GetMyName();

                    try
                    {
                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = this.poolFixture.PoolId });
                        unboundJob.Commit();

                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                        CloudTask unboundTask = new CloudTask(id: "bug1535329Task0", commandline: "hostname");

                        boundJob.AddTask(unboundTask);

                        CloudTask newTaskToAdd = new CloudTask(id: "bug1535329NewTask", commandline: "hostname");

                        // add some files to confirm file staging is working
                        FileToStage wordsDotText = new FileToStage(Resources.LocalWordsDotText, stagingStorageAccount);

                        newTaskToAdd.FilesToStage = new List<IFileStagingProvider>();

                        newTaskToAdd.FilesToStage.Add(wordsDotText);

                        batchCli.JobOperations.AddTask(jobId, newTaskToAdd);

                        bool foundLocalWords = false;

                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                        taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(5));

                        foreach (CloudTask curTask in boundJob.ListTasks())
                        {
                            this.testOutputHelper.WriteLine("TaskId: " + curTask.Id);

                            foreach (NodeFile curFile in curTask.ListNodeFiles(recursive: true))
                            {
                                this.testOutputHelper.WriteLine("    filename: " + curFile.Name);

                                if (curFile.Name.IndexOf("localWords.txt", StringComparison.InvariantCultureIgnoreCase) >= 0)
                                {
                                    Assert.False(foundLocalWords);
                                    foundLocalWords = true;
                                }
                            }
                        }

                        Assert.True(foundLocalWords);
                    }
                    finally
                    {
                        // clean up
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }
}
