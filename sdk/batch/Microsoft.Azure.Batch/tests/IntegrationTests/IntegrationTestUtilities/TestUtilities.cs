// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace BatchClientIntegrationTests.IntegrationTestUtilities
{
    using BatchTestCommon;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Common;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;
    using Microsoft.Identity.Client;

    using Constants = Microsoft.Azure.Batch.Constants;

    public static class TestUtilities
    {
        #region Credentials helpers
        private const string BatchResourceUri = "https://batch.core.windows.net/";
        private const string AuthorityUri = "https://login.microsoftonline.com/";

        public static BatchSharedKeyCredentials GetCredentialsFromEnvironment()
        {
            return new BatchSharedKeyCredentials(
                TestCommon.Configuration.BatchAccountUrl, 
                TestCommon.Configuration.BatchAccountName, 
                TestCommon.Configuration.BatchAccountKey);
        }

        public static BatchClient OpenBatchClient(BatchSharedKeyCredentials sharedKeyCredentials, bool addDefaultRetryPolicy = true)
        {
            BatchClient client = BatchClient.Open(sharedKeyCredentials);

            //Force us to get exception if the server returns something we don't expect
            //TODO: To avoid including this test assembly via "InternalsVisibleTo" we resort to some reflection trickery... maybe this property
            //TODO: should just be public?

            //TODO: Disabled for now because the swagger spec does not accurately reflect all properties returned by the server
            //SetDeserializationSettings(client);

            if (!addDefaultRetryPolicy)
            {
                client.CustomBehaviors = client.CustomBehaviors.Where(behavior => !(behavior is RetryPolicyProvider)).ToList();
            }

            return client;
        }

        public static async Task<BatchClient> OpenBatchClientFromEnvironmentAsync()
        {
            BatchClient client = OpenBatchClient(GetCredentialsFromEnvironment());

            return client;
        }


        public static async Task<string> GetAccessToken(string[] scopes)
        {
            var app = ConfidentialClientApplicationBuilder.Create(TestCommon.Configuration.ClientId)
                        .WithClientSecret(TestCommon.Configuration.ClientKey)
                        .WithAuthority(new Uri(AuthorityUri + TestCommon.Configuration.BatchTenantID))
                        .Build();

            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return result.AccessToken;
        }

        public static async Task<BatchClient> OpenBatchClientServicePrincipal()
        {
            var token = await GetAccessToken(new string[] { TestCommon.Configuration.BatchAccountUrl + ".default" });

            BatchClient client = BatchClient.Open(new BatchTokenCredentials(TestCommon.Configuration.BatchAccountUrl, token));

            return client;
        }


        public static StagingStorageAccount GetStorageCredentialsFromEnvironment()
        {
            string storageAccountKey = TestCommon.Configuration.StorageAccountKey;
            string storageAccountName = TestCommon.Configuration.StorageAccountName;
            string storageAccountBlobEndpoint = TestCommon.Configuration.StorageAccountBlobEndpoint;

            StagingStorageAccount storageStagingCredentials = new StagingStorageAccount(storageAccountName, storageAccountKey, storageAccountBlobEndpoint);

            return storageStagingCredentials;
        }

        public static string GenerateRandomPassword()
        {
            return Guid.NewGuid().ToString();
        }

        #endregion

        #region Custom assert methods

        public static T AssertThrows<T>(Action codeUnderTest) where T : Exception
        {
            using Task<T> t = AssertThrowsAsync<T>(() =>
                {
                    codeUnderTest();
                    return Task.Delay(0);
                });
            return t.Result;
        }

        public static async Task<T> AssertThrowsAsync<T>(Func<Task> codeUnderTest) where T : Exception
        {
            Type expectedExceptionType = typeof (T);
            Exception caughtException = await RecordExceptionAsync(codeUnderTest).ConfigureAwait(false);

            ThrowIfExceptionIsNotExpected(caughtException, expectedExceptionType);

            return (T)caughtException;
        }

        public static async Task<T> AssertThrowsEventuallyAsync<T>(Func<Task> codeUnderTest, TimeSpan timeout) where T : Exception
        {
            Type expectedExceptionType = typeof(T);
            DateTime now = DateTime.UtcNow;
            DateTime timeoutTime = now.Add(timeout);
            Exception caughtException = null;

            while (caughtException == null && now < timeoutTime)
            {
                //Call the code under test
                caughtException = await RecordExceptionAsync(codeUnderTest).ConfigureAwait(false);

                now = DateTime.UtcNow;
            }

            ThrowIfExceptionIsNotExpected(caughtException, expectedExceptionType);

            return (T)caughtException;
        }

        private static void ThrowIfExceptionIsNotExpected(Exception caughtException, Type expectedExceptionType)
        {
            if (caughtException == null)
            {
                throw new ThrowsException(expectedExceptionType);
            }

            if (!caughtException.GetType().Equals(expectedExceptionType))
            {
                throw new ThrowsException(expectedExceptionType, caughtException);
            }
        }

        private static async Task<Exception> RecordExceptionAsync(Func<Task> codeUnderTest)
        {
            try
            {
                await codeUnderTest().ConfigureAwait(false);
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Works with AggregateException or "Exception" just pass it in :)
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="correctCode"></param>
        public static void AssertIsBatchExceptionAndHasCorrectAzureErrorCode(Exception ex, string correctCode, ITestOutputHelper outputHelper)
        {
            Exception theOneInner = ex;

            if (ex is AggregateException ae)
            {
                // some ugly mechanics all for confirming we get the correct exception and it has the correct "message"
                // there can be only one
                Assert.Single(ae.InnerExceptions);

                // get the one exception
                theOneInner = ae.InnerExceptions[0];
            }

            if (!(theOneInner is BatchException))
            {
                 outputHelper.WriteLine(string.Format("AssertIsBatchExceptionAndHasCorrectAzureErrorCode: incorrect exception: {0}", ex.ToString()));
            }

            // it must have the correct type
            Assert.IsAssignableFrom<BatchException>(theOneInner);

            BatchException be = (BatchException)theOneInner;

            // whew we got it!  check the message
            Assert.Equal(expected: correctCode, actual: be.RequestInformation.BatchError.Code);
        }

        #endregion

        #region Naming helpers

        public static string GenerateResourceId(
            string baseId = null,
            int? maxLength = null,
            [CallerMemberName] string caller = null)
        {
            int actualMaxLength = maxLength ?? 50;

            var guid = Guid.NewGuid().ToString("N");
            if (baseId == null && caller == null)
            {
                return guid;
            }
            else
            {
                const int minRandomCharacters = 10;
                // make the ID only contain alphanumeric or underscore or dash:
                var id = baseId ?? caller;
                var safeBaseId = Regex.Replace(id, "[^A-Za-z0-9_-]", "");
                safeBaseId = safeBaseId.Length > actualMaxLength - minRandomCharacters ? safeBaseId.Substring(0, actualMaxLength - minRandomCharacters) : safeBaseId;
                var result = $"{safeBaseId}_{guid}";
                return result.Length > actualMaxLength ? result.Substring(0, actualMaxLength) : result;
            }
        }

        public static string GetMyName()
        {
            string domainName = Environment.GetEnvironmentVariable("USERNAME");

            return domainName;
        }

        public static string GetTimeStamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd_hh-mm-ss");
        }

        #endregion

        #region Deletion helpers

        public static async Task DeleteJobIfExistsAsync(BatchClient client, string jobId)
        {
            try
            {
                await client.JobOperations.DeleteJobAsync(jobId).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the job and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        public static async Task DeleteJobScheduleIfExistsAsync(BatchClient client, string jobScheduleId)
        {
            try
            {
                await client.JobScheduleOperations.DeleteJobScheduleAsync(jobScheduleId).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the job and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        public static async Task DeletePoolIfExistsAsync(BatchClient client, string poolId)
        {
            try
            {
                await client.PoolOperations.DeletePoolAsync(poolId).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the job and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        public static async Task DeleteCertificateIfExistsAsync(BatchClient client, string thumbprintAlgorithm, string thumbprint)
        {
            try
            {
                await client.CertificateOperations.DeleteCertificateAsync(thumbprintAlgorithm, thumbprint).ConfigureAwait(false);
            }
            catch (BatchException e)
            {
                if (!IsExceptionNotFound(e) && !IsExceptionConflict(e))
                {
                    throw; //re-throw in the case where we tried to delete the cert and got an exception with a status code which wasn't 409 or 404
                }
            }
        }

        #endregion

        #region Display helpers

        public static void DisplayPools(ITestOutputHelper testOutputHelper, IEnumerable<CloudPool> poolsEnumerable)
        {
            List<CloudPool> pools = new List<CloudPool>(poolsEnumerable);

            int numPools = (null != pools) ? pools.Count : 0;

            testOutputHelper.WriteLine("");
            testOutputHelper.WriteLine("Pool count: " + numPools);
            testOutputHelper.WriteLine("");

            foreach (CloudPool curPool in pools)
            {
                testOutputHelper.WriteLine(curPool.Id + ":");
                testOutputHelper.WriteLine("    AllocationState: " + curPool.AllocationState);
                testOutputHelper.WriteLine("    State: " + curPool.State);
                testOutputHelper.WriteLine("    TargetDedicated: " + curPool.TargetDedicatedComputeNodes);
                testOutputHelper.WriteLine("    CurrentDedicated:  " + (curPool.CurrentDedicatedComputeNodes.HasValue ? curPool.CurrentDedicatedComputeNodes.Value.ToString() : "<no value>"));

                if (curPool.Statistics != null)
                {
                    testOutputHelper.WriteLine("        AvgCpu: " + curPool.Statistics.ResourceStatistics.AverageCpuPercentage + ", AvgDisk: " + curPool.Statistics.ResourceStatistics.AverageDiskGiB + ", AvgMemory: " + curPool.Statistics.ResourceStatistics.AverageMemoryGiB + ", DiskReadBytes: " + curPool.Statistics.ResourceStatistics.DiskReadGiB);
                    testOutputHelper.WriteLine("        DiskReadIOps: " + curPool.Statistics.ResourceStatistics.DiskReadIOps);
                    testOutputHelper.WriteLine("        DiskWriteBytes: " + curPool.Statistics.ResourceStatistics.DiskWriteGiB);
                    testOutputHelper.WriteLine("        DiskWriteIOps: " + curPool.Statistics.ResourceStatistics.DiskWriteIOps);
                    testOutputHelper.WriteLine("        NetworkReadBytes: " + curPool.Statistics.ResourceStatistics.NetworkReadGiB);
                    testOutputHelper.WriteLine("        NetworkWriteBytes: " + curPool.Statistics.ResourceStatistics.NetworkWriteGiB);
                    testOutputHelper.WriteLine("        PeakDisk: " + curPool.Statistics.ResourceStatistics.PeakDiskGiB);
                    testOutputHelper.WriteLine("        PeakMemory: " + curPool.Statistics.ResourceStatistics.PeakMemoryGiB);
                    testOutputHelper.WriteLine("        StartTime: " + curPool.Statistics.ResourceStatistics.StartTime);
                    testOutputHelper.WriteLine("        LastUpdateTime: " + curPool.Statistics.ResourceStatistics.LastUpdateTime);
                }
                else
                {
                    testOutputHelper.WriteLine("<no value>");
                }
            }

            testOutputHelper.WriteLine("");
        }

        public static void DisplayJobScheduleLong(ITestOutputHelper testOutputHelper, CloudJobSchedule curWI)
        {
            // job schedule top level simple properties
            testOutputHelper.WriteLine("Id:  " + curWI.Id);
            testOutputHelper.WriteLine("       State: " + curWI.State.ToString());
            testOutputHelper.WriteLine("       " + "URL: " + curWI.Url);
            testOutputHelper.WriteLine("       " + "LastModified: " + (curWI.LastModified.HasValue ? curWI.LastModified.Value.ToLongDateString() : "<null>"));

            // execution INFO
            {
                JobScheduleExecutionInformation wiExInfo = curWI.ExecutionInformation;

                testOutputHelper.WriteLine("       ExeInfo:");
                testOutputHelper.WriteLine("               LastUpdateTime: " + (wiExInfo.EndTime.HasValue ? wiExInfo.EndTime.Value.ToLongDateString() : "<null>"));
                testOutputHelper.WriteLine("               NextRuntime: " + (wiExInfo.NextRunTime.HasValue ? wiExInfo.NextRunTime.Value.ToLongDateString() : "<null>"));
                testOutputHelper.WriteLine("               RecentJob:");

                // RecentJob
                RecentJob rj = wiExInfo.RecentJob;

                if (null == rj)
                {
                    testOutputHelper.WriteLine(" <null>");
                }
                else
                {
                    testOutputHelper.WriteLine("                         Id: " + rj.Id);
                    testOutputHelper.WriteLine("                         Url: " + rj.Url);
                }
            }

            // JobSpecification
            JobSpecification jobSpec = curWI.JobSpecification;

            testOutputHelper.WriteLine("       JobSpecification:");

            if (null == jobSpec)
            {
                testOutputHelper.WriteLine(" <null>");
            }
            else
            {
                testOutputHelper.WriteLine("");
                testOutputHelper.WriteLine("           Priority: " + (jobSpec.Priority.HasValue ? jobSpec.Priority.ToString() : "<null>"));

                JobConstraints jobCon = jobSpec.Constraints;

                testOutputHelper.WriteLine("           Constraints: ");

                if (null == jobCon)
                {
                    testOutputHelper.WriteLine("null");
                }
                else
                {
                    testOutputHelper.WriteLine("");
                    testOutputHelper.WriteLine("             MaxTaskRetryCount: " + (jobCon.MaxTaskRetryCount.HasValue ? jobSpec.Constraints.MaxTaskRetryCount.Value.ToString() : "<null>"));
                    testOutputHelper.WriteLine("             MaxWallClockTime: " + (jobCon.MaxWallClockTime.HasValue ? jobSpec.Constraints.MaxWallClockTime.Value.TotalMilliseconds.ToString() : "<null>"));
                }

                JobManagerTask ijm = jobSpec.JobManagerTask;

                if (null == ijm)
                {
                    testOutputHelper.WriteLine("<null>");
                }
                else
                {
                    testOutputHelper.WriteLine("           JobManagerTask:");
                    testOutputHelper.WriteLine("               CommandLine        : " + ijm.CommandLine);
                    testOutputHelper.WriteLine("               KillJobOnCompletion: " + (ijm.KillJobOnCompletion.HasValue ? ijm.KillJobOnCompletion.Value.ToString() : "<null>"));
                    testOutputHelper.WriteLine("               Id                 : " + ijm.Id);
                    testOutputHelper.WriteLine("               RunExclusive       : " + (ijm.RunExclusive.HasValue ? ijm.RunExclusive.Value.ToString() : "<null>"));

                    IEnumerable<EnvironmentSetting> envSettings = ijm.EnvironmentSettings;

                    if (null != envSettings)
                    {
                        List<EnvironmentSetting> envSettingsList = new List<EnvironmentSetting>(ijm.EnvironmentSettings);
                        testOutputHelper.WriteLine("               EnvironmentSettings.count:" + envSettingsList.Count);
                    }
                    else
                    {
                        testOutputHelper.WriteLine("               EnvironmentSettings: <null>");
                    }

                    IEnumerable<ResourceFile> resFilesProp = ijm.ResourceFiles;

                    if (null != resFilesProp)
                    {
                        List<ResourceFile> resFiles = new List<ResourceFile>();
                        testOutputHelper.WriteLine("               ResourceFiles.count:" + resFiles.Count);
                    }
                    else
                    {
                        testOutputHelper.WriteLine("               ResourceFiles: <null>");
                    }

                    TaskConstraints tc = ijm.Constraints;

                    if (null == tc)
                    {
                        testOutputHelper.WriteLine("               TaskConstraints: <null>");
                    }
                    else
                    {
                        testOutputHelper.WriteLine("               TaskConstraints: ");
                        testOutputHelper.WriteLine("                   MaxTaskRetryCount: " + (tc.MaxTaskRetryCount.HasValue ? tc.MaxTaskRetryCount.Value.ToString() : "<null>"));
                        testOutputHelper.WriteLine("                   MaxWallClockTime: " + (tc.MaxWallClockTime.HasValue ? tc.MaxWallClockTime.Value.TotalMilliseconds.ToString() : "<null>"));
                        testOutputHelper.WriteLine("                   RetentionTime: " + (tc.RetentionTime.HasValue ? tc.RetentionTime.Value.TotalMilliseconds.ToString() : "<null>"));
                    }

                    if (ijm.UserIdentity != null)
                    {
                        testOutputHelper.WriteLine("               UserIdentity: ");
                        testOutputHelper.WriteLine("                   UserName: ", ijm.UserIdentity.UserName);
                        testOutputHelper.WriteLine("                   ElevationLevel: ", ijm.UserIdentity.AutoUser?.ElevationLevel);
                        testOutputHelper.WriteLine("                   Scope: ", ijm.UserIdentity.AutoUser?.Scope);
                    }
                }
            }


            // metadata
            {
                IEnumerable<MetadataItem> mdis = curWI.Metadata;

                testOutputHelper.WriteLine("       Metadata: ");

                if (null == mdis)
                {
                    testOutputHelper.WriteLine("<null>");
                }
                else
                {
                    List<MetadataItem> meta = new List<MetadataItem>(curWI.Metadata);

                    testOutputHelper.WriteLine(" count:" + meta.Count);
                }
            }

            // schedule
            Schedule sched = curWI.Schedule;

            if (null == sched)
            {
                testOutputHelper.WriteLine("       Schedule: <null>");
            }
            else
            {
                testOutputHelper.WriteLine("       Schedule:");
                testOutputHelper.WriteLine("           DoNotRunAfter:" + (sched.DoNotRunAfter.HasValue ? sched.DoNotRunAfter.Value.ToLongDateString() : "<null>"));
                testOutputHelper.WriteLine("           DoNotRunUntil: " + (sched.DoNotRunUntil.HasValue ? sched.DoNotRunUntil.Value.ToLongDateString() : "<null>"));
                testOutputHelper.WriteLine("           RecurrenceInterval: " + (sched.RecurrenceInterval.HasValue ? sched.RecurrenceInterval.Value.TotalMilliseconds.ToString() : "<null>"));
                testOutputHelper.WriteLine("           StartWindow       :" + (sched.StartWindow.HasValue ? sched.StartWindow.Value.TotalMilliseconds.ToString() : "<null>"));
            }

            // stats
            JobScheduleStatistics stats = curWI.Statistics;

            if (null == stats)
            {
                testOutputHelper.WriteLine("       Stats: <null>");
            }
            else
            {
                testOutputHelper.WriteLine("       Stats:");
                testOutputHelper.WriteLine("           LastUpdateTime: " + stats.LastUpdateTime.ToLongDateString());
                testOutputHelper.WriteLine("           KernelCPUTime: " + stats.KernelCpuTime.TotalMilliseconds.ToString());
                testOutputHelper.WriteLine("           NumFailedTasks: " + stats.FailedTaskCount.ToString());
                testOutputHelper.WriteLine("           NumTimesCalled    : " + stats.TaskRetryCount);
                testOutputHelper.WriteLine("           NumSucceededTasks: " + stats.SucceededTaskCount);
                testOutputHelper.WriteLine("           ReadIOGiB      : " + stats.ReadIOGiB);
                testOutputHelper.WriteLine("           ReadIOps         : " + stats.ReadIOps);
                testOutputHelper.WriteLine("           StartTime        : " + stats.StartTime.ToLongDateString());
                testOutputHelper.WriteLine("           Url              : " + stats.Url);
                testOutputHelper.WriteLine("           UserCpuTime      : " + stats.UserCpuTime.TotalMilliseconds.ToString());
                testOutputHelper.WriteLine("           WaitTime         : " + stats.WaitTime.TotalMilliseconds.ToString());
                testOutputHelper.WriteLine("           WallClockTime    : " + stats.WallClockTime.TotalMilliseconds.ToString());
                testOutputHelper.WriteLine("           WriteIOGiB     : " + stats.WriteIOGiB);
                testOutputHelper.WriteLine("           WriteIOps        : " + stats.WriteIOps);
            }

        }

        #endregion

        #region Wait helpers

        public static async Task WaitForPoolToReachStateAsync(BatchClient client, string poolId, AllocationState targetAllocationState, TimeSpan timeout)
        {
            CloudPool pool = await client.PoolOperations.GetPoolAsync(poolId);

            await RefreshBasedPollingWithTimeoutAsync(
                    refreshing: pool,
                    condition: () => Task.FromResult(pool.AllocationState == targetAllocationState),
                    timeout: timeout).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits for the job to enter a its expected state within the given time.
        /// </summary>
        /// <param name="cloudJob">The job whose state to monitor.</param>
        /// <param name="waitFor">How long to wait for the job to reach the target state.</param>
        /// <param name="expected">The target job state to wait for.</param>
        /// <returns></returns>
        public static async Task WaitForJobStateAsync(CloudJob cloudJob, TimeSpan waitFor, JobState expected)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (stopwatch.Elapsed < waitFor && cloudJob.State != expected)
            {
                await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                await cloudJob.RefreshAsync().ConfigureAwait(false);
            }

            if (cloudJob.State != expected)
            {
                throw new TimeoutException($"Job {cloudJob.Id} did not reach expected state {expected} within time {waitFor}, last observed {cloudJob.State}");
            }
        }
        

        /// <summary>
        /// Will throw if timeout is exceeded.
        /// </summary>
        /// <param name="refreshing"></param>
        /// <param name="condition"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static async Task RefreshBasedPollingWithTimeoutAsync(IRefreshable refreshing, Func<Task<bool>> condition, TimeSpan timeout)
        {
            DateTime allocationWaitStartTime = DateTime.UtcNow;
            DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(timeout);

            while (!(await condition().ConfigureAwait(continueOnCapturedContext: false)))
            {
                await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(continueOnCapturedContext: false);
                await refreshing.RefreshAsync().ConfigureAwait(continueOnCapturedContext: false);

                if (DateTime.UtcNow > timeoutAfterThisTimeUtc)
                {
                    throw new Exception("RefreshBasedPollingWithTimeout: Timed out waiting for condition to be met.");
                }
            }
        }

        public static void DeleteCertMonitor(CertificateOperations certOps, ITestOutputHelper testOutputHelper, string thumbAlgo, string thumb)
        {
            bool found;

            testOutputHelper.WriteLine("polling for deletion of thumbprint: " + thumb);

            do
            {
                found = false;

#pragma warning disable CS0618 // Type or member is obsolete
                foreach (Certificate curCert in certOps.ListCertificates())
                {
#pragma warning restore CS0618 // Type or member is obsolete
                    if (thumbAlgo.Equals(curCert.ThumbprintAlgorithm, StringComparison.InvariantCultureIgnoreCase) &&
                        thumb.Equals(curCert.Thumbprint, StringComparison.InvariantCultureIgnoreCase))
                    {
                        testOutputHelper.WriteLine("DeleteCertMonitor: thumb " + curCert.Thumbprint + ", state: " + curCert.State);

                        found = true;

                        break;
                    }
                }

                if (found)
                {
                    System.Threading.Thread.Sleep(5000);
                }
            }
            while (found);
        }

        #endregion


        public static void HelloWorld(
            BatchClient batchCli,
            ITestOutputHelper testOutputHelper,
            CloudPool sharedPool,
            out string jobId,
            out string taskId,
            bool deleteJob = true,
            bool isLinux = false)
        {
            jobId = "HelloWorldJob-" + GetMyName() + "-" + GetTimeStamp();

            try
            {
                // here we show how to use an unbound Job + Commit() to run a simple "Hello World" task
                // get an empty unbound Job
                CloudJob quickJob = batchCli.JobOperations.CreateJob();
                quickJob.Id = jobId;
                quickJob.PoolInformation = new PoolInformation() { PoolId = sharedPool.Id };

                // Commit Job
                quickJob.Commit();

                // get an empty unbound Task
                taskId = "dwsHelloWorldTask";

                const string winPaasHWTaskCmdLine = "cmd /c echo Hello World";
                const string linuxIaasHWTaskCmdLine = "echo Hello World";

                string winnerTaskCmdLine = isLinux ? linuxIaasHWTaskCmdLine : winPaasHWTaskCmdLine;

                CloudTask hwTask = new CloudTask(id: taskId, commandline: winnerTaskCmdLine);

                // Open the new Job as bound.
                CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                // add Task to Job
                boundJob.AddTask(hwTask);

                // wait for the task to complete

                Utilities utilities = batchCli.Utilities;
                TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                taskStateMonitor.WaitAll(
                    boundJob.ListTasks(),
                    TaskState.Completed,
                    TimeSpan.FromMinutes(3));

                CloudTask myCompletedTask = new List<CloudTask>(boundJob.ListTasks(null))[0];

                string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                // confirm that stdout includes correct value
                Assert.Contains("Hello World", stdOut);

                testOutputHelper.WriteLine("StdOut: ");
                testOutputHelper.WriteLine(stdOut);

                testOutputHelper.WriteLine("StdErr: ");
                testOutputHelper.WriteLine(stdErr);
                
            }
            finally
            {
                // delete the job to free the Pool compute nodes.
                if (deleteJob)
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }
        }

        /// <summary>
        /// Waits for a job to be created -- This should be removed when we have a Utilities helper which does this
        /// </summary>
        public static CloudJobSchedule WaitForJobOnJobSchedule(JobScheduleOperations jobScheduleOperations, string jobScheduleId, string expectedJobId = null, TimeSpan? timeout = null)
        {
            //Wait for the job
            TimeSpan jobCreationTimeout = timeout ?? TimeSpan.FromSeconds(30);
            CloudJobSchedule refreshableJobSchedule = jobScheduleOperations.GetJobSchedule(jobScheduleId);
            DateTime jobCreationWaitStartTime = DateTime.UtcNow;
            while (refreshableJobSchedule.ExecutionInformation == null ||
                refreshableJobSchedule.ExecutionInformation.RecentJob == null ||
                (!string.IsNullOrEmpty(expectedJobId) && refreshableJobSchedule.ExecutionInformation.RecentJob.Id != expectedJobId))
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                refreshableJobSchedule.Refresh();
                if (DateTime.UtcNow > jobCreationWaitStartTime.Add(jobCreationTimeout))
                {
                    throw new Exception("Timed out waiting for job");
                }
            }

            return refreshableJobSchedule;
        }

        public static Microsoft.Azure.Batch.Protocol.BatchServiceClient GetServiceClient(BatchClient batchClient)
        {
            object protocolLayer = batchClient.GetType().GetProperty("ProtocolLayer", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(batchClient);
            Microsoft.Azure.Batch.Protocol.BatchServiceClient protoClient = protocolLayer
                .GetType()
                .GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(protocolLayer) as Microsoft.Azure.Batch.Protocol.BatchServiceClient;

            return protoClient;
        }

        #region Private helpers

        private static bool IsExceptionNotFound(BatchException e)
        {
            return e.RequestInformation != null && e.RequestInformation.HttpStatusCode == HttpStatusCode.NotFound;
        }

        private static bool IsExceptionConflict(BatchException e)
        {
            return e.RequestInformation != null && e.RequestInformation.HttpStatusCode == HttpStatusCode.Conflict;
        }

        #endregion
    }
}
