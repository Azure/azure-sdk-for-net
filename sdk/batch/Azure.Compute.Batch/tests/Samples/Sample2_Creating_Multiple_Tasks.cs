// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace Azure.Compute.Batch.Tests.Samples
{
    /// <summary>
    ///   Class is used as code base for Sample1_CreatePool_Job_Task
    /// </summary>
    ///
    public class Sample2_Creating_Multiple_Tasks
    {
        private BatchClient batchClient;

        public Sample2_Creating_Multiple_Tasks()
        {
            // Create a Batch Client
            CreateBatchClient();

            // Create a Pool
            CreateBatchPool();

            // Create a Job
            CreateBatchJob();
        }

        /// <summary>
        ///   Create multiple tasks in a single request using the CreateTasksAsync method and default settings.
        /// </summary>
        ///
        public async void CreateTasks_Default()
        {
            #region Snippet:Batch_Sample02_CreateTasks_Default
            int tasksCount = 1000;
            List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
            }

            // Create 1000 tasks in a single request using the default settings
            CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks);

            // Print the results
            Console.WriteLine("{0} Tasks Passed, {1} Failed.", result.PassCount, result.FailCount);
            #endregion

            #region Snippet:Batch_Sample02_GetTasks
            var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(await reader.ReadLineAsync());
                }
            }
            #endregion
        }

        /// <summary>
        ///   Create multiple tasks in a single request using the CreateTasksAsync method and specifying CreateTasksResult
        ///   to return the list of BatchTaskCreateResult.
        /// </summary>
        ///
        public async void CreateTasks_ReturnBatchTaskAddResults()
        {
            #region Snippet:Batch_Sample02_CreateTasks_ReturnBatchTaskAddResults
            int tasksCount = 1000;
            List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
            }

            // Create a CreateTaskOptions object with custom settings for the BatchTaskAddResults to be returned.
            CreateTasksOptions createTaskOptions = new CreateTasksOptions(returnBatchTaskAddResults: true);

            // Create 1000 tasks in a single request over 10 parallel requests
            CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

            foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
            {
                Console.WriteLine("Task {0} created with status {1}. ",
                    t.TaskId, t.Status);
            }
            #endregion

            var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(await reader.ReadLineAsync());
                }
            }
        }

        /// <summary>
        ///   Create multiple tasks in a single request using the CreateTasksAsync method with custom
        ///   CreateTaskOptions.
        /// </summary>
        ///
        public async void CreateTasks_ParallelOptions()
        {
            #region Snippet:Batch_Sample02_CreateTasks_ParallelOptions
            int tasksCount = 1000;
            List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
            }

            // Create a CreateTaskOptions object with custom settings for parallelism
            CreateTasksOptions createTaskOptions = new CreateTasksOptions()
            {
                MaxDegreeOfParallelism = 10,
                ReturnBatchTaskCreateResults = true
            };

            // Create 1000 tasks in a single request over 10 parallel requests
            CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

            foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
            {
                Console.WriteLine("Task {0} created with status  {1}. ",
                    t.TaskId, t.Status);
            }
            #endregion

            var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(await reader.ReadLineAsync());
                }
            }
        }

        /// <summary>
        ///   Create multiple tasks in a single request using the CreateTasksAsync method with custom
        ///   CreateTaskOptions.
        /// </summary>
        ///
        public async void CreateTasks_MaxTimeBetweenCallsInSeconds()
        {
            #region Snippet:Batch_Sample02_CreateTasks_MaxTimeBetweenCallsInSeconds
            int tasksCount = 1000;
            List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
            }

            // Create a CreateTaskOptions object with custom settings for
            // parallelism and the max time between calls.  Note calls start off with a delay of
            // 100 milliseconds and only increases if the service returns a 429 (TooManyRequest).
            CreateTasksOptions createTaskOptions = new CreateTasksOptions()
            {
                MaxDegreeOfParallelism = 10,
                MaxTimeBetweenCallsInSeconds = 60,
                ReturnBatchTaskCreateResults = true
            };

            // Create 1000 tasks in a single request over 10 parallel requests
            CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

            foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
            {
                Console.WriteLine("Task {0} created with status  {1}. ",
                    t.TaskId, t.Status);
            }
            #endregion

            var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(await reader.ReadLineAsync());
                }
            }
        }

        /// <summary>
        ///   Create multiple tasks in a single request using the CreateTasksAsync method and default settings.
        /// </summary>
        ///
        public async void CreateTasks_Custom_TaskCollectionResultHandler()
        {
            #region Snippet:Batch_Sample02_CreateTasks_Custom_TaskCollectionResultHandler
            int tasksCount = 1000;
            List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
            }

            // Create a CreateTaskOptions object with a custom CreateTaskResultHandler
            CreateTasksOptions createTaskOptions = new CreateTasksOptions()
            {
                CreateTaskResultHandler = new CustomTaskCollectionResultHandler(),
                ReturnBatchTaskCreateResults = true
            };

            // Create 1000 tasks in a single request using the default settings
            CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

            // Print the status of each task creation
            foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
            {
                Console.WriteLine("Task {0} created with status  {1}. ",
                    t.TaskId, t.Status);
            }
            #endregion

            var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(await reader.ReadLineAsync());
                }
            }
        }

        /// <summary>
        ///   Create multiple tasks in a single request using the CreateTasksAsync method with custom
        ///   CreateTaskOptions.
        /// </summary>
        ///
        public async void CreateTasks_Non_Default()
        {
            #region Snippet:Batch_Sample02_CreateTasks_Non_Default
            int tasksCount = 1000;
            List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
            }

            // Create a CancellationTokenSource object to cancel the operation if need be
            var cts = new CancellationTokenSource();

            // Create a CreateTaskOptions object with custom settings for
            // parallelism and the max time between calls.
            CreateTasksOptions createTaskOptions = new CreateTasksOptions()
            {
                MaxDegreeOfParallelism = 10,
                ReturnBatchTaskCreateResults = true
            };

            try
            {
                // Create 1000 tasks in a single request over 10 parallel requests with a timeout of 10 minutes
                // and a cancellation token
                CreateTasksResult result = await batchClient.CreateTasksAsync(
                    jobId: "jobId",
                    tasksToAdd: tasks,
                    createTasksOptions: createTaskOptions,
                    timeOutInSeconds: TimeSpan.FromMinutes(10),
                    cancellationToken: cts.Token
                    );

                // Print the results
                Console.WriteLine("{0} Tasks Passed, {1} Failed.", result.PassCount, result.FailCount);
            }
            catch (ParallelOperationsException)
            {
                // timeout exception
            }
            catch (OperationCanceledException)
            {
                // cancelation token execptoin
            }

            #endregion

            var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(await reader.ReadLineAsync());
                }
            }
        }

        private void CreateBatchClient()
        {
            #region Snippet:Batch_Sample02_CreateBatchClient

            var credential = new DefaultAzureCredential();
            BatchClient batchClient = new BatchClient(
            new Uri("https://examplebatchaccount.eastus.batch.azure.com"), credential);
            #endregion

            this.batchClient = batchClient;
        }

        private async void CreateBatchJob()
        {
            #region Snippet:Batch_Sample02_CreateBatchJob
            await batchClient.CreateJobAsync(new BatchJobCreateOptions("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
            #endregion
        }

        /// <summary>
        ///   Code to create a Batch mgmt client and call operatrions snippet.
        /// </summary>
        ///
        public async void CreateBatchPool()
        {
            #region Snippet:Batch_Sample02_CreateBatchMgmtClient

            var credential = new DefaultAzureCredential();
            ArmClient _armClient = new ArmClient(credential);
            #endregion

            #region Snippet:Batch_Sample02_GetBatchMgmtAccount
            var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
            BatchAccountResource batchAccount = await _armClient.GetBatchAccountResource(batchAccountIdentifier).GetAsync();
            #endregion

            #region Snippet:Batch_Sample02_PoolCreation
            var poolName = "HelloWorldPool";
            var imageReference = new Azure.ResourceManager.Batch.Models.BatchImageReference()
            {
                Publisher = "canonical",
                Offer = "0001-com-ubuntu-server-jammy",
                Sku = "22_04-lts",
                Version = "latest"
            };
            string nodeAgentSku = "batch.node.ubuntu 22.04";

            ArmOperation<BatchAccountPoolResource> armOperation = await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(
                WaitUntil.Completed, poolName, new BatchAccountPoolData()
                {
                    VmSize = "Standard_DS1_v2",
                    DeploymentConfiguration = new BatchDeploymentConfiguration()
                    {
                        VmConfiguration = new BatchVmConfiguration(imageReference, nodeAgentSku)
                    },
                    ScaleSettings = new BatchAccountPoolScaleSettings()
                    {
                        FixedScale = new BatchAccountFixedScaleSettings()
                        {
                            TargetDedicatedNodes = 1
                        }
                    }
                });
            BatchAccountPoolResource pool = armOperation.Value;
            #endregion
        }

        #region Snippet:Batch_Sample02__CustomTaskCollectionResultHandler
        /// <summary>
        ///  Custom TaskCollectionResultHandler to handle the result of a CreateTasksAsync operation.
        /// </summary>
        private class CustomTaskCollectionResultHandler : TaskResultHandler
        {
            /// <summary>
            /// This handler treats and result without errors as Success, 'TaskExists' errors as failures, retries server errors (HTTP 5xx),
            /// and throws for any other error.
            /// <see cref="AddTaskCollectionTerminatedException"/> on client error (HTTP 4xx).
            /// </summary>
            /// <param name="addTaskResult">The result of a single Add Task operation.</param>
            /// <param name="cancellationToken">The cancellation token associated with the AddTaskCollection operation.</param>
            /// <returns>An <see cref="CreateTaskResultStatus"/> which indicates whether the <paramref name="addTaskResult"/>
            /// is classified as a success or as requiring a retry.</returns>
            public override CreateTaskResultStatus CreateTaskResultHandler(CreateTaskResult addTaskResult, CancellationToken cancellationToken)
            {
                if (addTaskResult == null)
                {
                    throw new ArgumentNullException("addTaskResult");
                }

                CreateTaskResultStatus status = CreateTaskResultStatus.Success;
                if (addTaskResult.BatchTaskResult.Error != null)
                {
                    //Check status code
                    if (addTaskResult.BatchTaskResult.Status == BatchTaskAddStatus.ServerError)
                    {
                        status = CreateTaskResultStatus.Retry;
                    }
                    else if (addTaskResult.BatchTaskResult.Status == BatchTaskAddStatus.ClientError && addTaskResult.BatchTaskResult.Error.Code == BatchErrorCode.TaskExists)
                    {
                        status = CreateTaskResultStatus.Failure; //TaskExists mark as failure
                    }
                    else
                    {
                        //Anything else is a failure -- abort the work flow
                        throw new AddTaskCollectionTerminatedException(addTaskResult);
                    }
                }
                return status;
            }
            #endregion
        }
    }
}
