// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface IServiceClient
    {
        TestRunDto? PatchTestRunInfo(TestRunDto run);
        TestRunShardDto? PostTestRunShardInfo(TestRunShardDto runShard);
        void UploadBatchTestResults(UploadTestResultsRequest uploadTestResultsRequest);
        TestResultsUri? GetTestRunResultsUri();
    }
}
