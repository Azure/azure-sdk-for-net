// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using synchronous methods of <see cref="SparkBatchClient"/>.
    /// </summary>
    public partial class SubmitSparkJob
    {
        [Test]
        public void SubmitSparkJobSync()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            // Environment variable with the Synapse Spark pool name.
            string sparkPoolName = TestEnvironment.SparkPoolName;

            // Environment variable with the ADLS Gen2 storage account associated with the Synapse workspace.
            string storageAccount = TestEnvironment.StorageAccountName;

            // Environment variable with the file system of ADLS Gen2 storage account associated with the Synapse workspace.
            string fileSystem = TestEnvironment.StorageFileSystemName;

            #region Snippet:SparkBatchSample1SparkBatchClient
            SparkBatchClient client = new SparkBatchClient(new Uri(workspaceUrl), sparkPoolName, new DefaultAzureCredential());
            #endregion

            #region Snippet:SparkBatchSample1SubmitSparkJob
            string name = $"batch-{Guid.NewGuid()}";
            string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/wordcount.jar", fileSystem, storageAccount);
            SparkBatchJobOptions request = new SparkBatchJobOptions(name, file)
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

            SparkBatchJob jobCreated = client.CreateSparkBatchJob(request);
            #endregion

            #region Snippet:SparkBatchSample1GetSparkJob
            SparkBatchJob job = client.GetSparkBatchJob(jobCreated.Id);
            Debug.WriteLine($"Job is returned with name {job.Name} and state {job.State}");
            #endregion

            #region Snippet:SparkBatchSample1CancelSparkJob
            Response operation = client.CancelSparkBatchJob(jobCreated.Id);
            #endregion
        }
    }
}
