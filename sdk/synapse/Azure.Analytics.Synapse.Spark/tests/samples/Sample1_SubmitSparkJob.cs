// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.Spark;
using Azure.Identity;
using NUnit.Framework;
using Azure;
using Azure.Core;
using System.Text.Json;

namespace Azure.Analytics.Synapse.Spark.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using synchronous methods of <see cref="SparkBatchClient"/>.
    /// </summary>
    public partial class Sample1_SubmitSparkJob : SamplesBase<SynapseTestEnvironment>
    {
        [Test]
        public void SubmitSparkJobSync()
        {
            #region Snippet:CreateSparkBatchClient
            // Replace the strings below with the spark, endpoint, and file system information
            string sparkPoolName = "<my-spark-pool-name>";
            /*@@*/sparkPoolName = TestEnvironment.SparkPoolName;

            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;

            string storageAccount = "<my-storage-account-name>";
            /*@@*/storageAccount = TestEnvironment.StorageAccountName;

            string fileSystem = "<my-storage-filesystem-name>";
            /*@@*/fileSystem = TestEnvironment.StorageFileSystemName;

            SparkBatchClient client = new SparkBatchClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
            #endregion

            #region Snippet:SubmitSparkBatchJob
            string name = $"batch-{Guid.NewGuid()}";
            string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/wordcount.zip", fileSystem, storageAccount);
            RequestContent request = RequestContent.Create (new {
                name = name,
                className = "WordCount",
                file = file,
                files = new[] {
                        string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/shakespeare.txt", fileSystem, storageAccount),
                        string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/result/", fileSystem, storageAccount),
                },
                driverMemory = "28g",
                driverCores = 4,
                executorMemory = "28g",
                executorCores = 4,
                numExecutors = 2
            });

            SparkBatchOperation createOperation = client.StartCreateSparkBatchJob(request);
            while (!createOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                createOperation.UpdateStatus();
            }
            BinaryData jobCreated = createOperation.Value;
            var id = JsonDocument.Parse(jobCreated.ToMemory()).RootElement.GetProperty("id").GetInt32();
            #endregion

            #region Snippet:ListSparkBatchJobs
            Response jobs = client.GetSparkBatchJobs();
            var jobsDoc = JsonDocument.Parse(jobs.Content.ToMemory());
            foreach (var job in jobsDoc.RootElement.GetProperty("sessions").EnumerateArray())
            {
                if (job.TryGetProperty("name", out var jobName))
                {
                    Console.WriteLine(jobName);
                }
            }
            #endregion

            #region Snippet:GetSparkBatchJob
            Response retrievedJob = client.GetSparkBatchJob (id);
            var retrievedJobDoc = JsonDocument.Parse(retrievedJob.Content.ToMemory());
            if (retrievedJobDoc.RootElement.TryGetProperty("name", out var retrievedJobName))
            {
                Debug.WriteLine($"Job is returned with name {retrievedJobName} and state {retrievedJobDoc.RootElement.GetProperty("state").GetString()}");
            }
            else
            {
                Debug.WriteLine($"Job is returned with state {retrievedJobDoc.RootElement.GetProperty("state").GetString()}");
            }
            #endregion

            #region Snippet:CancelSparkBatchJob
            Response operation = client.CancelSparkBatchJob(id);
            #endregion
        }
    }
}
