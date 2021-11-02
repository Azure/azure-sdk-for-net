// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string LiveTestAzureFunctionRouterRuleUrl => GetRecordedVariable(LiveTestAzureFunctionRouterRuleConnectionStringEnvironmentVariable);

        public Uri LiveTestAzureFunctionRuleEndpoint => new Uri(Core.ConnectionString.Parse(LiveTestAzureFunctionRouterRuleUrl).GetRequired("endpoint"));

        public string LiveTestAzureFunctionRuleAppAccessKey => Core.ConnectionString.Parse(LiveTestAzureFunctionRouterRuleUrl).GetRequired("accesskey");
    }
}
