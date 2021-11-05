// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Spark;

namespace Azure.Analytics.Synapse.Tests
{
    public static class SparkTestUtilities
    {
        /// <summary>
        /// Create parameters for Spark batch tests.
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public static SparkBatchJobOptions CreateSparkJobRequestParameters(TestRecording recording, SynapseTestEnvironment testEnvironment)
        {
            string name = recording.GenerateId("dontnetbatch", 16);
            string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/wordcount.jar", testEnvironment.StorageFileSystemName, testEnvironment.StorageAccountName);
            return new SparkBatchJobOptions(name, file)
            {
                ClassName = "WordCount",
                Arguments =
                {
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/shakespeare.txt", testEnvironment.StorageFileSystemName, testEnvironment.StorageAccountName),
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/result/", testEnvironment.StorageFileSystemName, testEnvironment.StorageAccountName),
                },
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };
        }

        /// <summary>
        /// Create parameters for Spark session tests.
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public static SparkSessionOptions CreateSparkSessionRequestParameters(TestRecording recording)
        {
            string name = recording.GenerateId("dotnetsession", 16);
            return new SparkSessionOptions(name)
            {
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };
        }

        public static async Task<List<SparkBatchJob>> ListSparkBatchJobsAsync(SparkBatchClient client, bool detailed = true)
        {
            List<SparkBatchJob> batches = new List<SparkBatchJob>();
            int from = 0;
            int currentPageSize;
            int pageSize = 20;
            do
            {
                SparkBatchJobCollection page = (await client.GetSparkBatchJobsAsync(detailed: detailed, from: from, size: pageSize)).Value;
                currentPageSize = page.Total;
                from += currentPageSize;
                batches.AddRange(page.Sessions);
            } while (currentPageSize == pageSize);
            return batches;
        }

        public static async Task<List<SparkSession>> ListSparkSessionsAsync(SparkSessionClient client, bool detailed = true)
        {
            List<SparkSession> sessions = new List<SparkSession>();
            int from = 0;
            int currentPageSize;
            int pageSize = 20;
            do
            {
                SparkSessionCollection page = (await client.GetSparkSessionsAsync(detailed: detailed, from: from, size: pageSize)).Value;
                currentPageSize = page.Total;
                from += currentPageSize;
                sessions.AddRange(page.Sessions);
            } while (currentPageSize == pageSize);

            return sessions;
        }
    }
}
