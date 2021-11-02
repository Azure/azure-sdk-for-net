// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Communication.Tests;

namespace Azure.Communication.JobRouter.Tests.Infrastructure
{
    public class RouterClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        public RouterClientRecordedTestSanitizer()
        {
            AddJsonPathSanitizer("$..token");
            AddJsonPathSanitizer("$..accessToken");
            AddJsonPathSanitizer("$..functionKey");
            AddJsonPathSanitizer("$..appKey");
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
            => variableName switch
            {
                CommunicationTestEnvironment.LiveTestDynamicConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                CommunicationTestEnvironment.LiveTestStaticConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                RouterTestEnvironment.LiveTestAzureFunctionRouterRuleConnectionStringEnvironmentVariable => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
    }
}
