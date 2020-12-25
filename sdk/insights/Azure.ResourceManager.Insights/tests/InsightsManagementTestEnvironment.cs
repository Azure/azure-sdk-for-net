// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Insights.Tests
{
    public class InsightsManagementTestEnvironment : TestEnvironment
    {
        public InsightsManagementTestEnvironment() : base("insights")
        {
        }
    }
}
