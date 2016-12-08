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
    using System.Net;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using StagingStorageAccount = fs::Microsoft.Azure.Batch.FileStaging.StagingStorageAccount;  // Temporary bridge until the Batch core NuGet without file staging is published
    using FileToStage = fs::Microsoft.Azure.Batch.FileStaging.FileToStage;  // Temporary bridge until the Batch core NuGet without file staging is published
    using SequentialFileStagingArtifact = fs::Microsoft.Azure.Batch.FileStaging.SequentialFileStagingArtifact;  // Temporary bridge until the Batch core NuGet without file staging is published
    using Microsoft.Azure.Batch.Protocol;
    using TestResources;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;
    using Constants = Microsoft.Azure.Batch.Constants;

    [Collection("SharedPoolCollection")]
    public class EndToEndIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(1);
        
        public EndToEndIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        /// <summary>
        /// Uses an unbound Job to demonstrate
        ///     1: File Staging (local files are automatically stored in Blobs as part of Commit())
        ///     2: Use of already-existing-SAS  (when data are pre-staged into Blobs and a SAS is "known")
        /// </summary>
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestSampleWithFilesAndPool()
        {
            Action test = () =>
            {
                StagingStorageAccount storageCreds = TestUtilities.GetStorageCredentialsFromEnvironment();

                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "SampleWithFilesJob-" + TestUtilities.GetMyName();


                    try
                    {
                        CloudJob quickJob = batchCli.JobOperations.CreateJob();
                        quickJob.Id = jobId;
                        quickJob.PoolInformation = new PoolInformation() { PoolId = this.poolFixture.PoolId };
                        quickJob.Commit();
                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                        CloudTask myTask = new CloudTask(id: "CountWordsTask", commandline: @"cmd /c dir /s .. & dir & wc localwords.txt");

                        // first we have local files that we want pushed to the compute node before the commandline is invoked
                        FileToStage wordsDotText = new FileToStage(Resources.LocalWordsDotText, storageCreds);                // use "default" mapping to base name of local file

                        myTask.FilesToStage = new List<IFileStagingProvider>();

                        myTask.FilesToStage.Add(wordsDotText);

                        // add the task to the job
                        var artifacts = boundJob.AddTask(myTask);
                        var specificArtifact = artifacts[typeof(FileToStage)];
                        SequentialFileStagingArtifact sfsa = specificArtifact as SequentialFileStagingArtifact;

                        Assert.NotNull(sfsa);

                        // add a million more tasks...

                        // test to ensure the task is read only
                        TestUtilities.AssertThrows<InvalidOperationException>(() => myTask.FilesToStage = new List<IFileStagingProvider>());
                        
                        // Open the new Job as bound.
                        CloudPool boundPool = batchCli.PoolOperations.GetPool(boundJob.ExecutionInformation.PoolId);

                        // wait for the task to complete
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                        taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(10),
                            controlParams: null,
                            additionalBehaviors:
                                new[]
                        {
                            // spam/logging interceptor
                            new Microsoft.Azure.Batch.Protocol.RequestInterceptor((x) =>
                            {
                                this.testOutputHelper.WriteLine("Issuing request type: " + x.GetType().ToString());

                                try
                                {
                                    // print out the compute node states... we are actually waiting on the compute nodes
                                    List<ComputeNode> allComputeNodes = boundPool.ListComputeNodes().ToList();

                                    this.testOutputHelper.WriteLine("    #compute nodes: " + allComputeNodes.Count);

                                    allComputeNodes.ForEach(
                                        (icn) =>
                                        {
                                            this.testOutputHelper.WriteLine("  computeNode.id: " + icn.Id + ", state: " + icn.State);
                                        });
                                }
                                catch (Exception ex)
                                {
                                    // there is a race between the pool-life-job and the end of the job.. and the ListComputeNodes above
                                    Assert.True(false, "SampleWithFilesAndPool probably can ignore this if its pool not found: " + ex.ToString());
                                }
                            })
                        });
                        
                        List<CloudTask> tasks = boundJob.ListTasks(null).ToList();
                        CloudTask myCompletedTask = tasks[0];

                        foreach (CloudTask curTask in tasks)
                        {
                            this.testOutputHelper.WriteLine("Task Id: " + curTask.Id + ", state: " + curTask.State);
                        }

                        boundPool.Refresh();

                        this.testOutputHelper.WriteLine("Pool Id: " + boundPool.Id + ", state: " + boundPool.State);

                        string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                        string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                        this.testOutputHelper.WriteLine("StdOut: ");
                        this.testOutputHelper.WriteLine(stdOut);

                        this.testOutputHelper.WriteLine("StdErr: ");
                        this.testOutputHelper.WriteLine(stdErr);

                        this.testOutputHelper.WriteLine("Task Files:");

                        foreach (NodeFile curFile in myCompletedTask.ListNodeFiles(recursive: true))
                        {
                            this.testOutputHelper.WriteLine("    Filename: " + curFile.Name);
                        }

                        // confirm the files are there
                        Assert.True(FoundFile("localwords.txt", myCompletedTask.ListNodeFiles(recursive: true)), "mising file: localwords.txt");

                        // test validation of StagingStorageAccount

                        TestUtilities.AssertThrows<ArgumentOutOfRangeException>(() => { new StagingStorageAccount(storageAccount: " ", storageAccountKey: "key", blobEndpoint: "blob"); });
                        TestUtilities.AssertThrows<ArgumentOutOfRangeException>(() => { new StagingStorageAccount(storageAccount: "account", storageAccountKey: " ", blobEndpoint: "blob"); });
                        TestUtilities.AssertThrows<ArgumentOutOfRangeException>(() => { new StagingStorageAccount(storageAccount: "account", storageAccountKey: "key", blobEndpoint: ""); });

                        if (null != sfsa)
                        {
                            // TODO: delete the container!
                        }
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        #region Test helpers

        private static bool FoundFile(string fileName, IEnumerable<NodeFile> files)
        {
            // look to see if the file is in the list
            foreach (NodeFile curFile in files)
            {
                if (curFile.Name.IndexOf(fileName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

    }
}
