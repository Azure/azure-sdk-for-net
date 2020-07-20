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

        /// <summary>
        /// Wait for the specified number of milliseconds unless we are in mock playback mode.
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        internal static void Wait(this SparkClientTestBase test, int milliseconds)
        {
            test.Recording.Wait(TimeSpan.FromMilliseconds(milliseconds));
        }

        internal static bool IsJobRunning(string livyState, IList<string> livyStates, bool isFinalState = true)
        {
            return isFinalState ? !livyStates.Contains(livyState) : livyStates.Contains(livyState);
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

        internal static async Task<SparkBatchJob> PollSparkBatchJobSubmissionAsync(this SparkClientTestBase test, SparkBatchJob batch)
        {
            return await test.PollAsync(
               batch,
               b => b.State,
               b => test.SparkBatchClient.GetSparkBatchJobAsync(b.Id),
                new List<string>
               {
                   "error",
                   "dead",
                   "success",
                   "killed"
               });
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

        internal static async Task<SparkSession> PollSparkSessionAsync(this SparkClientTestBase test, SparkSession session)
        {
            return await test.PollAsync(
                session,
                s => s.State,
                s => test.SparkSessionClient.GetSparkSessionAsync(s.Id),
                new List<string>
                {
                    "idle",
                    "error",
                    "dead",
                    "success",
                    "killed"
                });
        }

        internal static async Task<SparkStatement> PollSparkSessionStatementAsync(this SparkClientTestBase test, int sessionId, SparkStatement statement)
        {
            return await test.PollAsync(
                statement,
                s => s.State,
                s => test.SparkSessionClient.GetSparkStatementAsync(sessionId, s.Id),
                new List<string>
                {
                    "starting",
                    "waiting",
                    "running",
                    "cancelling"
                },
                isFinalState:false);
        }

        private static async Task<T> PollAsync<T>(
            this SparkClientTestBase test,
            T job,
            Func<T, string> getLivyState,
            Func<T, Task<Response<T>>> refresh,
            IList<string> livyReadyStates,
            bool isFinalState = true,
            int pollingInMilliseconds = default,
            int timeoutInMilliseconds = default,
            Action<T> writeLog = null)
        {
            int timeWaitedInMilliSeconds = 0;
            if (pollingInMilliseconds == default)
            {
                pollingInMilliseconds = 5000;
            }

            while (IsJobRunning(getLivyState(job), livyReadyStates, isFinalState))
            {
                if (timeoutInMilliseconds > 0 && timeWaitedInMilliSeconds >= timeoutInMilliseconds)
                {
                    throw new TimeoutException();
                }

                writeLog?.Invoke(job);
                test.Wait(pollingInMilliseconds);
                timeWaitedInMilliSeconds += pollingInMilliseconds;

                job = await refresh(job);
            }

            return job;
        }
    }
}
