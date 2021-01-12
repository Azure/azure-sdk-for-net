// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using asynchronous methods of <see cref="SparkBatchClient"/>.
    /// </summary>
    public partial class Sample1_SubmitSparkJobAsync : SampleFixture
    {
        [Test]
        public async Task SubmitSparkJobAsync()
        {
            #region Snippet:CreateSparkBatchClientAsync
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

            #region Snippet:SubmitSparkBatchJobAsync
            string name = $"batch-{Guid.NewGuid()}";
            string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/wordcount.zip", fileSystem, storageAccount);
            SparkBatchJobOptions request = new SparkBatchJobOptions(name, file)
            {
                ClassName = "WordCount",
                Arguments =
                {
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/shakespeare.txt", fileSystem, storageAccount),
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/result/", fileSystem, storageAccount),
                },
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };

            SparkBatchOperation createOperation = await client.StartCreateSparkBatchJobAsync(request);
            SparkBatchJob jobCreated = await createOperation.WaitForCompletionAsync();
            #endregion

            #region Snippet:ListSparkBatchJobsAsync
            Response<SparkBatchJobCollection> jobs = client.GetSparkBatchJobs();
            foreach (SparkBatchJob job in jobs.Value.Sessions)
            {
                Console.WriteLine(job.Name);
            }
            #endregion

            #region Snippet:GetSparkBatchJobAsync
            SparkBatchJob retrievedJob = await client.GetSparkBatchJobAsync (jobCreated.Id);
            Debug.WriteLine($"Job is returned with name {retrievedJob.Name} and state {retrievedJob.State}");
            #endregion

            #region Snippet:CancelSparkBatchJobAsync
            Response operation = client.CancelSparkBatchJob(jobCreated.Id);
            #endregion
        }
    }
}
