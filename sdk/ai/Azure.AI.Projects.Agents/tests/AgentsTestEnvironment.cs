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
        public string PROJECT_ENDPOINT => GetRecordedVariable(nameof(PROJECT_ENDPOINT), options => options.IsSecret("https://sanitized-host.services.ai.azure.com/api/projects/sanitized-project"));
        public string MODELDEPLOYMENTNAME => GetRecordedVariable("MODEL_DEPLOYMENT_NAME");
        public string EMBEDDINGMODELDEPLOYMENTNAME => GetRecordedVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
        public string AGENT_ID => GetRecordedVariable(nameof(AGENT_ID));
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
