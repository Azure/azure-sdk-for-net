﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAITestEnvironment : TestEnvironment
    {
        public string NonAzureOpenAIApiKey => GetOptionalVariable("OPENAI_API_KEY");

        public string AzureCognitiveSearchApiKey => GetOptionalVariable("ACS_BYOD_API_KEY");

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
