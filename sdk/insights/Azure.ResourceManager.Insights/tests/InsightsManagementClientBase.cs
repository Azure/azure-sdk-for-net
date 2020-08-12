// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Insights.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class InsightsManagementClientBase : ManagementRecordedTestBase<InsightsManagementTestEnvironment>
    {
        protected InsightsManagementClientBase(bool isAsync) : base(isAsync)
        {

        }
    }
}
