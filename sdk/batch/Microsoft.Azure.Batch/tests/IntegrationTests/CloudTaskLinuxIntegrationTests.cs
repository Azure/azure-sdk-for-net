// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using Microsoft.Azure.Batch.Integration.Tests.Extensions;
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
    using Xunit.Abstractions;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;

    [Collection("SharedLinuxPoolCollection")]
    public class CloudTaskLinuxIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public CloudTaskLinuxIntegrationTests(ITestOutputHelper testOutputHelper, IaasLinuxPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void RunTaskAndUploadFiles_FilesAreSuccessfullyUploaded()
        {
            Action test = async () =>
            {
                string containerName = "runtaskanduploadfiles";
                StagingStorageAccount storageAccount = TestUtilities.GetStorageCredentialsFromEnvironment();
                CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(
                    new StorageCredentials(storageAccount.StorageAccount, storageAccount.StorageAccountKey),
                    blobEndpoint: storageAccount.BlobUri,
                    queueEndpoint: null,
                    tableEndpoint: null,
                    fileEndpoint: null);
                CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

                using (BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    string jobId = "RunTaskAndUploadFiles-" + TestUtilities.GetMyName();

                    try
                    {
                        // Create container and writeable SAS
                        var container = blobClient.GetContainerReference(containerName);
                        await container.CreateIfNotExistsAsync();
                        var sas = container.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                        {
                            Permissions = SharedAccessBlobPermissions.Write,
                            SharedAccessExpiryTime = DateTime.UtcNow.AddDays(1)
                        });
                        var fullSas = container.Uri + sas;

                        CloudJob createJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = this.poolFixture.PoolId });
                        createJob.Commit();

                        const string blobPrefix = "foo/bar";
                        const string taskId = "simpletask";
                        CloudTask unboundTask = new CloudTask(taskId, "echo test")
                        {
                            OutputFiles = new List<OutputFile>
                            {
                                new OutputFile(
                                    filePattern: @"../*.txt",
                                    destination: new OutputFileDestination(new OutputFileBlobContainerDestination(fullSas, blobPrefix)),
                                    uploadOptions: new OutputFileUploadOptions(uploadCondition: OutputFileUploadCondition.TaskCompletion))
                            }
                        };

                        batchCli.JobOperations.AddTask(jobId, unboundTask);

                        var tasks = batchCli.JobOperations.ListTasks(jobId);

                        var monitor = batchCli.Utilities.CreateTaskStateMonitor();
                        monitor.WaitAll(tasks, TaskState.Completed, TimeSpan.FromMinutes(1));

                        // Ensure that the correct files got uploaded
                        var blobs = await BlobStorageExtensions.ListBlobs(container, useFlatBlobListing: true);
                        blobs = blobs.ToList();
                        Assert.Equal(4, blobs.Count()); //There are 4 .txt files created, stdout, stderr, fileuploadout, and fileuploaderr
                        foreach (var blob in blobs)
                        {
                            var blockBlob = blob as CloudBlockBlob;
                            Assert.StartsWith(blobPrefix, blockBlob.Name);
                        }
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                        var container = blobClient.GetContainerReference(containerName);
                        await container.DeleteIfExistsAsync();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void TestContainerTask()
        {
            Action test = () =>
            {
                using (BatchClient client = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    string jobId = "ContainerJob" + TestUtilities.GetMyName();

                    try
                    {
                        var job = client.JobOperations.CreateJob(jobId, new PoolInformation()
                        {
                            PoolId = this.poolFixture.PoolId
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
            };

            SynchronizationContextHelper.RunTest(test, TimeSpan.FromMinutes(10));
        }
    }
}
