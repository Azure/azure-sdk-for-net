// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestRunClient
    {
        /// <summary>
        /// BeginCreateOrUpdateTestRun
        /// </summary>
        public virtual TestRunOperation BeginTestRun(string testRunId, RequestContent content, WaitUntil waitUntil = WaitUntil.Started, string oldTestRunId = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testRunId, nameof(testRunId));

            using var scope = ClientDiagnostics.CreateScope("LoadTestRunClient.BeginCreateOrUpdateTestRun");
            scope.Start();

            try
            {
                Response initialResponse = CreateOrUpdateTestRun(testRunId, content, oldTestRunId, context);
                TestRunOperation operation = new(testRunId, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion();
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// BeginCreateOrUpdateTestRunAsync
        /// </summary>
        public virtual async Task<TestRunOperation> BeginTestRunAsync(string testRunId, RequestContent content, WaitUntil waitUntil = WaitUntil.Started, string oldTestRunId = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(testRunId, nameof(testRunId));

            using var scope = ClientDiagnostics.CreateScope("LoadTestRunClient.BeginCreateOrUpdateTestRun");
            scope.Start();

            try
            {
                Response initialResponse = await CreateOrUpdateTestRunAsync(testRunId, content, oldTestRunId, context).ConfigureAwait(false);
                TestRunOperation operation = new(testRunId, this, initialResponse);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync().ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
