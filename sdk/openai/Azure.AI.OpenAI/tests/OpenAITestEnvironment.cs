// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAITestEnvironment : TestEnvironment
    {
        public string NonAzureOpenAIApiKey => GetOptionalVariable("OPENAI_API_KEY");

        public string AzureCognitiveSearchApiKey => GetOptionalVariable("ACS_BYOD_API_KEY");

        public string TestAudioInputPathEnglish => GetOptionalVariable("OAI_TEST_AUDIO_INPUT_ENGLISH_PATH");

        public Uri GetUrlVariable(string variableName) => new(GetRecordedVariable(variableName));

        public bool TryGetUrlVariable(string variableName, out Uri variableValue)
        {
            string maybeVariable = GetOptionalVariable(variableName);
            variableValue = maybeVariable == null ? null : new Uri(GetRecordedVariable(variableName));
            return variableValue != null;
        }

        public AzureKeyCredential GetKeyVariable(string variableName) => new(GetOptionalVariable(variableName) ?? "placeholder");

        public bool TryGetKeyVariable(string variableName, out AzureKeyCredential keyFromVariable)
        {
            string maybeVariable = GetOptionalVariable(variableName);
            keyFromVariable = maybeVariable == null ? null : new AzureKeyCredential(maybeVariable);
            return keyFromVariable != null;
        }

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
