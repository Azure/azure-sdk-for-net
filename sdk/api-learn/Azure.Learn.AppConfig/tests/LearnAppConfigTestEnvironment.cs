// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Learn.AppConfig.Tests
{
    // To learn more about TestEnvironment classes, please see: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core.TestFramework/README.md
    public class LearnAppConfigTestEnvironment : TestEnvironment
    {
        public LearnAppConfigTestEnvironment() : base("api-learn")
        {
        }

        public string LearnEndpoint => GetRecordedVariable("API-LEARN_ENDPOINT");
        public string LearnClientId => GetRecordedVariable("API-LEARN_CLIENT_ID");
        public string LearnClientSecret => GetRecordedVariable("API-LEARN_CLIENT_SECRET");
        public string LearnTenantId => GetRecordedVariable("API-LEARN_TENANT_ID");
    }
}
