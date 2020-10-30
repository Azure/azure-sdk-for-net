// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using IntegrationTestUtilities;
    using Xunit;
    using Microsoft.Azure.Batch.Integration.Tests.IntegrationTestUtilities;
    using Azure.Storage.Blobs;
    using System.Threading.Tasks;

    [Collection("SharedLinuxPoolCollection")]
    public class CloudTaskLinuxIntegrationTests
    {
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public CloudTaskLinuxIntegrationTests(IaasLinuxPoolFixture poolFixture)
        {
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task RunTaskAndUploadFiles_FilesAreSuccessfullyUploaded()
        {
            async Task test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "RunTaskAndUploadFiles-" + TestUtilities.GetMyName();
                string containerName = "runtaskanduploadfiles";
                StagingStorageAccount storageAccount = TestUtilities.GetStorageCredentialsFromEnvironment();
                BlobServiceClient blobClient = BlobUtilities.GetBlobServiceClient(storageAccount);
                BlobContainerClient containerClient = BlobUtilities.GetBlobContainerClient(containerName, blobClient, storageAccount);

                try
                {
                    // Create container and writeable SAS
                    containerClient.CreateIfNotExists();
                    string sasUri = BlobUtilities.GetWriteableSasUri(containerClient, storageAccount);

                    CloudJob createJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    createJob.Commit();

                    const string blobPrefix = "foo/bar";
                    const string taskId = "simpletask";

                    OutputFileDestination destination = new OutputFileDestination(new OutputFileBlobContainerDestination(sasUri, blobPrefix));
                    OutputFileUploadOptions uploadOptions = new OutputFileUploadOptions(uploadCondition: OutputFileUploadCondition.TaskCompletion);
                    CloudTask unboundTask = new CloudTask(taskId, "echo test")
                    {
                        OutputFiles = new List<OutputFile>
                            {
                                new OutputFile(@"../*.txt", destination, uploadOptions)
                            }
                    };

                    batchCli.JobOperations.AddTask(jobId, unboundTask);

                    var tasks = batchCli.JobOperations.ListTasks(jobId);

                    var monitor = batchCli.Utilities.CreateTaskStateMonitor();
                    monitor.WaitAll(tasks, TaskState.Completed, TimeSpan.FromMinutes(1));

                    // Ensure that the correct files got uploaded
                    var blobs = containerClient.GetAllBlobs();
                    Assert.Equal(4, blobs.Count()); //There are 4 .txt files created, stdout, stderr, fileuploadout, and fileuploaderr
                    foreach (var blob in blobs)
                    {
                        Assert.StartsWith(blobPrefix, blob.Name);
                    }
                }
                finally
                {
                    await TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).ConfigureAwait(false);
                    containerClient.DeleteIfExists();
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void TestContainerTask()
        {
            void test()
            {
                using BatchClient client = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "ContainerJob" + TestUtilities.GetMyName();

                try
                {
                    var job = client.JobOperations.CreateJob(jobId, new PoolInformation()
                    {
                        PoolId = poolFixture.PoolId
                    });
                    job.Commit();

                    var newTask = new CloudTask("a", "cat /etc/centos-release")
                    {
                        ContainerSettings = new TaskContainerSettings("centos")
                    };
                    client.JobOperations.AddTask(jobId, newTask);

                    var tasks = client.JobOperations.ListTasks(jobId);

                    var monitor = client.Utilities.CreateTaskStateMonitor();
                    monitor.WaitAll(tasks, TaskState.Completed, TimeSpan.FromMinutes(7));

                    var task = tasks.Single();
                    task.Refresh();

                    Assert.Equal("ContainerPoolNotSupported", task.ExecutionInformation.FailureInformation.Code);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TimeSpan.FromMinutes(10));
        }
    }
}
