// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static System.Net.WebRequestMethods;

namespace Azure.Compute.Batch.Tests.Integration
{
    internal class FileIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FileIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FileIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetTaskFile()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "GetTaskFile", IsPlayBack());
            string poolId = iaasWindowsPoolFixture.PoolId;
            string jobId = "batchJob1";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                await client.CreateJobAsync(new BatchJobCreateOptions(jobId, new BatchPoolInfo() { PoolId = poolId }));

                for (int i = 0; i < 5; i++)
                {
                    string taskId = $"task-{i}";
                    await client.CreateTaskAsync(jobId, new BatchTaskCreateOptions(taskId, $"cmd /c echo Hello World {taskId}"));
                }

                await WaitForTasksToComplete(client, jobId, IsPlayBack());
                var completedTasks = client.GetTasksAsync(jobId, filter: "state eq 'completed'");

                int index = 0;
                await foreach (BatchTask t in completedTasks)
                {
                    var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                    BatchFileProperties batchFilePropertiesesponse = await client.GetTaskFilePropertiesAsync(jobId, t.Id, outputFileName);
                    Assert.IsNotNull(batchFilePropertiesesponse);
                    Assert.IsNotEmpty(batchFilePropertiesesponse.FileUrl);

                    BinaryData fileContents = await client.GetTaskFileAsync(jobId, t.Id, outputFileName);
                    using (var reader = new StreamReader(fileContents.ToStream()))
                    {
                        string line = await reader.ReadLineAsync();
                        Assert.IsNotEmpty(line);
                        Assert.AreEqual($"Hello World task-{index++}", line);
                    }

                    await foreach (BatchNodeFile item in client.GetTaskFilesAsync(jobId, t.Id))
                    {
                        Uri url = item.Uri;
                        long contentLenght = item.Properties != null ? item.Properties.ContentLength : 0;
                    }
                }
            }
            finally
            {
                await client.DeleteJobAsync(jobId);
                await client.DeletePoolAsync(poolId);
            }
        }

        [RecordedTest]
        public async Task DeleteTaskFile()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "DeleteTaskFile", IsPlayBack());
            string poolId = iaasWindowsPoolFixture.PoolId;
            string jobId = "batchJob1";
            string taskId = "batchTask1";
            string outputFileName = "stdout.txt";

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                await client.CreateJobAsync(new BatchJobCreateOptions(jobId, new BatchPoolInfo() { PoolId = poolId }));

                await client.CreateTaskAsync(jobId, new BatchTaskCreateOptions(taskId, $"cmd /c echo Hello World"));

                await WaitForTasksToComplete(client, jobId, IsPlayBack());

                BinaryData fileContents = await client.GetTaskFileAsync(jobId, taskId, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    string line = await reader.ReadLineAsync();
                    Assert.IsNotEmpty(line);
                    Assert.AreEqual($"Hello World", line);
                }

                // delete the file
                Response response = await client.DeleteTaskFileAsync(jobId, taskId, outputFileName);
                Assert.AreEqual(response.Status, 200);

                //verify deleted, we should get an exception because the file is not found
                var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetTaskFileAsync(jobId, taskId, outputFileName));
            }
            finally
            {
                await client.DeleteJobAsync(jobId);
                await client.DeletePoolAsync(poolId);
            }
        }

        [RecordedTest]
        public async Task GetNodeFile()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "GetNodeFile", IsPlayBack());
            string poolId = iaasWindowsPoolFixture.PoolId;
            string jobId = "batchJob1";
            string file = "workitems\\batchJob1\\job-1\\task-0\\stdout.txt";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                await client.CreateJobAsync(new BatchJobCreateOptions(jobId, new BatchPoolInfo() { PoolId = poolId }));

                for (int i = 0; i < 5; i++)
                {
                    string taskId = $"task-{i}";
                    await client.CreateTaskAsync(jobId, new BatchTaskCreateOptions(taskId, $"cmd /c echo Hello World {taskId}"));
                }

                await WaitForTasksToComplete(client, jobId, IsPlayBack());

                await foreach (BatchNode item in client.GetNodesAsync(poolId))
                {
                    BatchFileProperties batchFileProperties = await client.GetNodeFilePropertiesAsync(poolId, item.Id, file);
                    Assert.IsNotNull(batchFileProperties);
                    Assert.IsNotEmpty(batchFileProperties.FileUrl);

                    BinaryData fileContents = await client.GetNodeFileAsync(poolId, item.Id, file);
                    using (var reader = new StreamReader(fileContents.ToStream()))
                    {
                        string line = await reader.ReadLineAsync();
                        Assert.IsNotEmpty(line);
                        //Assert.AreEqual($"Hello World task-{index++}", line);
                    }

                    await client.DeleteNodeFileAsync(poolId, item.Id, file);

                    //verify deleted, we should get an exception because the file is not found
                    var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetNodeFileAsync(poolId, item.Id, file));
                }
            }
            finally
            {
                await client.DeleteJobAsync(jobId);
                await client.DeletePoolAsync(poolId);
            }
        }
    }
}
