// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Azure.Compute.Batch;
using System.Threading;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    public class BatchLiveTestBase : RecordedTestBase<BatchLiveTestEnvironment>
    {
        public enum TestAuthMethods
        {
            Default,
            ClientSecret,
            NamedKey
        };

        public BatchLiveTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            SanitizedHeaders.Add("client-request-id");
            UseDefaultGuidFormatForClientRequestId = true;
        }

        public BatchLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("client-request-id");
            UseDefaultGuidFormatForClientRequestId = true;
        }

        public bool IsPlayBack()
        {
            return this.Mode == RecordedTestMode.Playback;
        }

        public void TestSleep(int milliseconds)
        {
            if (!IsPlayBack())
            { Thread.Sleep(TimeSpan.FromSeconds(milliseconds)); }
        }

        /// <summary>
        /// Creates a <see cref="BatchClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <param name="useTokenCredential">Whether or not to use a <see cref="TokenCredential"/> to authenticate. An <see cref="AzureKeyCredential"/> is used by default.</param>
        /// <param name="skipInstrumenting">Whether or not instrumenting should be skipped. Avoid skipping it as much as possible.</param>
        /// <returns>The instrumented <see cref="BatchClient" />.</returns>
        public BatchClient CreateBatchClient(TestAuthMethods testAuthMethod = TestAuthMethods.ClientSecret, bool skipInstrumenting = false)
        {
            var options = InstrumentClientOptions(new BatchClientOptions());
            BatchClient client;
            Uri uri = new Uri("https://" + TestEnvironment.BatchAccountURI);

            var authorityHost = TestEnvironment.AuthorityHostUrl;
            switch (testAuthMethod)
            {
                case TestAuthMethods.ClientSecret:
                    {
                        client = new BatchClient(uri, TestEnvironment.Credential, options);
                    }
                    break;
                case TestAuthMethods.NamedKey:
                    {
                        var credential = new AzureNamedKeyCredential(TestEnvironment.BatchAccountName, TestEnvironment.BatchAccountKey);
                        client = new BatchClient(uri, credential, options);
                    }
                    break;
                default:
                    {
                        var credential = new DefaultAzureCredential();
                        client = new BatchClient(uri, credential, options);
                    }
                    break;
            }
            return skipInstrumenting ? client : InstrumentClient(client);
        }

        /// <summary>
        /// Poll all the tasks in the given job and wait for them to reach the completed state.
        /// </summary>
        /// <param name="jobId">The ID of the job to poll</param>
        /// <returns>A task that will complete when all Batch tasks have completed.</returns>
        /// <exception cref="TimeoutException">Thrown if all tasks haven't reached the completed state after a certain period of time</exception>
        public async Task WaitForTasksToComplete(BatchClient client, String jobId, bool isPlayBackMode = false)
        {
            // Note that this timeout should take into account the time it takes for the pool to scale up
            var timeoutAfter = DateTime.Now.AddMinutes(10);
            while (DateTime.Now < timeoutAfter)
            {
                var allComplete = true;
                var tasks = client.GetTasksAsync(jobId, select: new string[] { "id", "state" });
                await foreach (BatchTask task in tasks)
                {
                    if (task.State != BatchTaskState.Completed)
                    {
                        allComplete = false;
                        break;
                    }
                }

                if (allComplete)
                {
                    return;
                }

                if (isPlayBackMode == false)
                { await Task.Delay(10000); }
            }

            throw new TimeoutException("Task(s) did not complete within the specified time");
        }
    }
}
