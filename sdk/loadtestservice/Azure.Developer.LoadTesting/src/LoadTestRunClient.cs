// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestRunClient
    {
        /// <summary>
        /// UploadTestFile.
        /// </summary>
        public TestRunOperation BeginTestRun(WaitUntil waitUntil, string testRunId, RequestContent content, string oldTestRunId, RequestContext context = null)
        {
            Response initialResponse = CreateOrUpdateTestRun(testRunId, content, oldTestRunId, context);
            TestRunOperation operation = new(testRunId, this, initialResponse);
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion();
            }
            return operation;
        }
    }
}
