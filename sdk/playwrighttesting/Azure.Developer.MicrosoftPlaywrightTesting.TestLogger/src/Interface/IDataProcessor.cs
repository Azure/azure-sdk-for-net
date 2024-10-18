// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface IDataProcessor
    {
        TestRunDto GetTestRun();
        TestRunShardDto GetTestRunShard();
        TestResults GetTestCaseResultData(TestResult? testResultSource);
    }
}
