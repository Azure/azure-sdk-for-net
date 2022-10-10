// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Compute.Batch;
using Azure.Compute.Batch.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Task = Azure.Compute.Batch.Models.Task;

namespace Azure.Compute.Tests.SessionTests
{
    internal class TaskClientRecordedTests : BatchRecordedTestBase
    {
        public TaskClientRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task ExecuteTask()
        {
            string jobId = GetId("Job");
            string taskId = GetId("Task");

            BatchServiceClient serviceClient = CreateServiceClient();
            JobClient jobClient = serviceClient.CreateJobClient();
            TaskClient taskClient = serviceClient.CreateTaskClient();

            try
            {
                await jobClient.AddAsync(new Job("testPool", jobId)).ConfigureAwait(false);

                Task task = new(taskId);
                int duration = 5000;
                task.CommandLine = $"cmd /c (echo 'Task {taskId} starting...) && (timeout {duration}) && (echo 'Task {taskId} complete!')";
                await taskClient.AddAsync(jobId, task).ConfigureAwait(false);

                List<Task> tasks = await taskClient.ListAsync(jobId).ToEnumerableAsync();
                Assert.AreNotEqual(tasks.Count, 0);
            }
            finally
            {
                await jobClient.DeleteAsync(jobId);
            }
        }
    }
}
