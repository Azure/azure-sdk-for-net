// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Analytics.Synapse.Spark.Samples
{
    public partial class Snippets : SampleFixture
    {
        private SparkBatchClient batchClient;

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            // Environment variable with the Synapse Spark pool name.
            string sparkPoolName = TestEnvironment.SparkPoolName;

            #region Snippet:CreateBatchClient
            // Create a new access Spark batch client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            SparkBatchClient client = new SparkBatchClient(endpoint: new Uri(workspaceUrl), sparkPoolName: sparkPoolName, credential: new DefaultAzureCredential());
            #endregion

            this.batchClient = client;
        }

        [Test]
        public void CreateSparkBatchJob()
        {
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

            SparkBatchJob jobCreated = batchClient.CreateSparkBatchJob(options);
            #endregion
        }

        [Test]
        public void ListSparkBatchJobs()
        {
            #region Snippet:ListSparkBatchJobs
            Response<SparkBatchJobCollection> jobs = batchClient.GetSparkBatchJobs();
            foreach (SparkBatchJob job in jobs.Value.Sessions)
            {
                Console.WriteLine(job.Name);
            }
            #endregion
        }

        [Test]
        public void CancelSparkBatchJob()
        {
            int jobId = 0;

            #region Snippet:DeleteSparkBatchJob
            Response operation = batchClient.CancelSparkBatchJob(jobId);
            #endregion
        }
    }
}
