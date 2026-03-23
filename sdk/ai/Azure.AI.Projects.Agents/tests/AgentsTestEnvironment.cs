// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Projects.Agents.Tests
{
    public class AgentsTestEnvironment : TestEnvironment
    {
        public string FOUNDRY_PROJECT_ENDPOINT => GetRecordedVariable(nameof(FOUNDRY_PROJECT_ENDPOINT), options => options.IsSecret("https://sanitized-host.services.ai.azure.com/api/projects/sanitized-project"));
        public string FOUNDRY_MODEL_NAME => GetRecordedVariable(nameof(FOUNDRY_MODEL_NAME));
        public string APPLICATIONINSIGHTS_CONNECTION_STRING => GetRecordedVariable(nameof(APPLICATIONINSIGHTS_CONNECTION_STRING));
        public string AGENT_DOCKER_IMAGE => GetRecordedVariable(nameof(AGENT_DOCKER_IMAGE));
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
