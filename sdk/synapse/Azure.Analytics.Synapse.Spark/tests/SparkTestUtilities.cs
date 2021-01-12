// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.Tests;

namespace Azure.Analytics.Synapse.Spark.Tests
{
    internal static class SparkTestUtilities
    {
        /// <summary>
        /// Create parameters for Spark batch tests.
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        internal static SparkBatchJobOptions CreateSparkJobRequestParameters(this SparkClientTestBase test)
        {
            string name = test.Recording.GenerateName("dontnetbatch");
            string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/wordcount.jar", test.TestEnvironment.StorageFileSystemName, test.TestEnvironment.StorageAccountName);
            return new SparkBatchJobOptions(name, file)
            {
                ClassName = "WordCount",
                Arguments =
                {
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/shakespeare.txt", test.TestEnvironment.StorageFileSystemName, test.TestEnvironment.StorageAccountName),
                    string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/java/wordcount/result/", test.TestEnvironment.StorageFileSystemName, test.TestEnvironment.StorageAccountName),
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
        internal static SparkSessionOptions CreateSparkSessionRequestParameters(this SparkClientTestBase test)
        {
            string name = test.Recording.GenerateName("dotnetsession");
            return new SparkSessionOptions(name)
            {
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };
        }

        internal static async Task<List<SparkBatchJob>> ListSparkBatchJobsAsync(this SparkClientTestBase test, bool detailed = true)
        {
            List<SparkBatchJob> batches = new List<SparkBatchJob>();
            int from = 0;
            int currentPageSize;
            int pageSize = 20;
            do
            {
                SparkBatchJobCollection page = (await test.SparkBatchClient.GetSparkBatchJobsAsync(detailed: detailed, from: from, size: pageSize)).Value;
                currentPageSize = page.Total;
                from += currentPageSize;
                batches.AddRange(page.Sessions);
            } while (currentPageSize == pageSize);
            return batches;
        }

        internal static async Task<List<SparkSession>> ListSparkSessionsAsync(this SparkClientTestBase test, bool detailed = true)
        {
            List<SparkSession> sessions = new List<SparkSession>();
            int from = 0;
            int currentPageSize;
            int pageSize = 20;
            do
            {
                SparkSessionCollection page = (await test.SparkSessionClient.GetSparkSessionsAsync(detailed: detailed, from: from, size: pageSize)).Value;
                currentPageSize = page.Total;
                from += currentPageSize;
                sessions.AddRange(page.Sessions);
            } while (currentPageSize == pageSize);

            return sessions;
        }
    }
}
