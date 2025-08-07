// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface ITestProcessor
    {
        void TestCaseResultHandler(object? sender, TestResultEventArgs e);
        void TestRunStartHandler(object? sender, TestRunStartEventArgs e);
        void TestRunCompleteHandler(object? sender, TestRunCompleteEventArgs e);
    }
}
