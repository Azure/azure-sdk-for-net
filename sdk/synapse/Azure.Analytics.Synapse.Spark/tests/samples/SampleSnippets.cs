// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Analytics.Synapse.Spark.Samples
{
    public partial class Snippets : SampleFixture
    {
        [Test]
        public void SparkSample()
        {
            #region Snippet:CreateBatchClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            string sparkPoolName = TestEnvironment.SparkPoolName;
            SparkBatchClient client = new SparkBatchClient(endpoint: new Uri(workspaceUrl), sparkPoolName: sparkPoolName, credential: new DefaultAzureCredential());
            #endregion

            // Environment variable with the storage account associated with the Synapse workspace endpoint.
            string storageAccount = TestEnvironment.StorageAccountName;

            // Environment variable with the file system of the storage account.
            string fileSystem = TestEnvironment.StorageFileSystemName;

            #region Snippet:CreateBatchJob
            string name = $"batchSample";
            string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/wordcount.jar", fileSystem, storageAccount);
            SparkBatchJobOptions options = new SparkBatchJobOptions(name: name, file: file)
            {
                ClassName = "WordCount",
                Arguments =
                {
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/shakespeare.txt", fileSystem, storageAccount),
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/result/", fileSystem, storageAccount),
                },
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };

            SparkBatchJob jobCreated = client.CreateSparkBatchJob(options);
            #endregion

            #region Snippet:ListSparkBatchJobs
            Response<SparkBatchJobCollection> jobs = client.GetSparkBatchJobs();
            foreach (SparkBatchJob job in jobs.Value.Sessions)
            {
                Console.WriteLine(job.Name);
            }
            #endregion

            #region Snippet:DeleteSparkBatchJob
            /*@@*/int jobId = jobs.Value.Sessions.First().Id;
            // Replace the integer below with your actual job ID.
            //@@ string jobId = 0;
            Response operation = client.CancelSparkBatchJob(jobId);
            #endregion
        }
    }
}
