// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Insights.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class InsightsManagementClientBase : ManagementRecordedTestBase<InsightsManagementTestEnvironment>
    {
        protected static readonly string RgName = "rg1";

        protected InsightsManagementClientBase(bool isAsync) : base(isAsync) { }

        protected InsightsManagementClientBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
    }
}
