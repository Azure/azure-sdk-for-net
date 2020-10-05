// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Learn.AppConfig.Tests
{
    // To learn more about TestEnvironment classes, please see: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core.TestFramework/README.md
    public class LearnAppConfigEnvironment : TestEnvironment
    {
        public LearnAppConfigEnvironment() : base("api-learn")
        {
        }
    }
}
