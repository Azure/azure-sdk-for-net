// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core.TestFramework;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAITestEnvironment : TestEnvironment
    {
        /// <summary>The name of the environment variable from which the openAI resource's API key will be extracted for the live tests.</summary>
        internal const string OpenAIAuthTokenEnvironmentVariableName = "OPENAI_AUTH_TOKEN";

        public string OpenAIAuthTokenString => GetRecordedVariable(OpenAIAuthTokenEnvironmentVariableName, options => options.IsSecret());
        public void ThrowIfCannotDeploy()
        {
            string[] requiredVariableNames = new string[]
            {
                "TENANT_ID",
                "AUTHORITY_HOST",
                "SUBSCRIPTION_ID",
                "CLIENT_ID",
                "CLIENT_SECRET",
            };

            foreach (string requiredVariableName in requiredVariableNames)
            {
                string optionalVariableValue = GetOptionalVariable(requiredVariableName);
                if (string.IsNullOrEmpty(optionalVariableValue))
                {
                    throw new InvalidOperationException($"Resource deployment is required and no environment value was found for required variable '{requiredVariableName}'.\n"
                        + $"'{Mode}' mode requires full environment specification of an Azure application (service principal) "
                        + "that manages test resources. This includes: Azure tenant ID; Azure authority host; managed subscription ID; and application ID + secret.");
                }
            }
        }
    }
}
