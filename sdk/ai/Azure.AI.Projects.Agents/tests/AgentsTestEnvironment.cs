// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Castle.Components.DictionaryAdapter;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Projects.Agents.Tests
{
    public class AgentsTestEnvironment : TestEnvironment
    {
        public string FOUNDRY_PROJECT_ENDPOINT => GetRecordedVariable(nameof(FOUNDRY_PROJECT_ENDPOINT), options => options.IsSecret("https://sanitized-host.services.ai.azure.com/api/projects/sanitized-project"));
        public string FOUNDRY_MODEL_NAME => GetRecordedVariable(nameof(FOUNDRY_MODEL_NAME));
        public string APPLICATIONINSIGHTS_CONNECTION_STRING => GetRecordedVariable(nameof(APPLICATIONINSIGHTS_CONNECTION_STRING));
        public string AGENT_DOCKER_IMAGE => GetRecordedVariable(nameof(AGENT_DOCKER_IMAGE));
        public string IMAGE_GENERATION_DEPLOYMENT_NAME => GetRecordedVariable(nameof(IMAGE_GENERATION_DEPLOYMENT_NAME));
        public string CUSTOM_BING_CONNECTION_ID => GetRecordedVariable(nameof(CUSTOM_BING_CONNECTION_ID));
        public string BING_CUSTOM_SEARCH_INSTANCE_NAME => GetRecordedVariable(nameof(BING_CUSTOM_SEARCH_INSTANCE_NAME));
        public string OPENAI_FILE_ID => GetRecordedVariable(nameof(OPENAI_FILE_ID));
        public string OPENAI_VECTOR_STORE_ID => GetRecordedVariable(nameof(OPENAI_VECTOR_STORE_ID));
        public string AI_SEARCH_CONNECTION_NAME => GetRecordedVariable(nameof(AI_SEARCH_CONNECTION_NAME));
        public string BING_CONNECTION_ID => GetRecordedVariable(nameof(BING_CONNECTION_ID));
        public string A2A_CONNECTION_ID => GetRecordedVariable(nameof(A2A_CONNECTION_ID));
        public string PLAYWRIGHT_CONNECTION_ID => GetRecordedVariable(nameof(PLAYWRIGHT_CONNECTION_ID));
        public string SHAREPOINT_CONNECTION_ID => GetRecordedVariable(nameof(SHAREPOINT_CONNECTION_ID));
        public string FABRIC_CONNECTION_ID => GetRecordedVariable(nameof(FABRIC_CONNECTION_ID));
        public string STORAGE_QUEUE_URI => GetRecordedVariable(nameof(STORAGE_QUEUE_URI));
        public override Dictionary<string, string> ParseEnvironmentFile() => new()
        {
            { "OPEN-API-KEY", Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "api-key" }
        };

        public override Task WaitForEnvironmentAsync()
        {
            return Task.CompletedTask;
        }

        public override AuthenticationTokenProvider Credential => Mode switch
        {
            RecordedTestMode.Live or RecordedTestMode.Record => new DefaultAzureCredential(),
            _ => base.Credential
        };
    }
}
