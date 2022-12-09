// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.JobRouter.Tests.Infrastructure
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class RouterTestEnvironment : CommunicationTestEnvironment
    {
        public const string LiveTestAzureFunctionRouterRuleConnectionStringEnvironmentVariable = "COMMUNICATION_LIVETEST_ROUTER_AZURE_FUNCTION_RULE_CONTAINER";

        public string LiveTestAzureFunctionRouterRuleUrl => GetRecordedVariable(
            LiveTestAzureFunctionRouterRuleConnectionStringEnvironmentVariable,
            options =>
            {
                options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64);
                options.HasSecretConnectionStringParameter("functionKey", SanitizedValue.Base64);
            });

        public Uri LiveTestAzureFunctionRuleEndpoint => new Uri(Core.ConnectionString.Parse(LiveTestAzureFunctionRouterRuleUrl).GetRequired("endpoint"));

        public string LiveTestAzureFunctionRuleAppAccessKey => Core.ConnectionString.Parse(LiveTestAzureFunctionRouterRuleUrl).GetRequired("accesskey");
    }
}
